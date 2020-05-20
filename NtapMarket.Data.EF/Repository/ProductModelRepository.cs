using Microsoft.AspNetCore.Http;
using NtapMarket.Data.DBModel;
using NtapMarket.Data.IRepository;
using NtapMarket.Data.ObjectModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace NtapMarket.Data.EF.Repository
{
    public class ProductModelRepository : IProductModelRepository
    {
        private DBContext _dBContext { get; set; }
        private string _webRootPath { get; set; }

        public ProductModelRepository(string connectionString, string webRootPath)
        {
            _dBContext = new DBContext(connectionString);
            _webRootPath = webRootPath;
        }

        public List<ProductModel> GetProductModels(int sellerId)
        {
            List<ProductModel> productModels = new List<ProductModel>();
            var products = _dBContext.Products.Where(x => x.SellerId == sellerId).ToList();
            foreach (var product in products)
            {
                ProductModel model = new ProductModel()
                {
                    Id = product.Id,
                    ProductCategoryId = product.ProductCategoryId,
                    SellerId = product.SellerId,
                    Name = product.Name,
                    MarketingInfo = product.MarketingInfo,
                    Count = product.Count,
                    Price = product.Price
                };

                var category = _dBContext.ProductCategories.Find(product.ProductCategoryId);
                model.ProductCategory = category;

                var seller = _dBContext.Sellers.Find(product.SellerId);
                model.Seller = seller;

                var images = _dBContext.ProductImages.Where(x => x.ProductId == product.Id).ToList();
                model.ProductImage = images;

                var attributeValues = _dBContext.ProductAttributeValues.Where(x => x.ProductId == product.Id).ToList();
                foreach (var attributeValue in attributeValues)
                {
                    var attribute = _dBContext.ProductAttributes.Find(attributeValue.ProductAttributeId);
                    var attributeModel = new ProductAttributeModel()
                    {
                        ProductAttributeId = attribute.Id,
                        ProductAttributeValueId = attributeValue.Id,
                        Name = attribute.Name,
                        Value = attributeValue.Value,
                        Description = attribute.Description
                    };

                    model.ProductAttributeModel.Add(attributeModel);
                }

                productModels.Add(model);
            }

            return productModels;
        }

        public ProductModel GetProductModel(int productId)
        {
            var product = _dBContext.Products.Find(productId);
            var productImages = _dBContext.ProductImages.Where(x => x.ProductId == productId).ToList();
            var attributeValues = _dBContext.ProductAttributeValues.Where(x => x.ProductId == productId).ToList();
            var productCategory = _dBContext.ProductCategories.Find(product.ProductCategoryId);
            var seller = _dBContext.Sellers.Find(product.SellerId);
            var productAttributeModels = new List<ProductAttributeModel>();

            foreach (var attributeValue in attributeValues)
            {
                var attributeInfo = _dBContext.ProductAttributes.Find(attributeValue.ProductAttributeId);
                var productAttributeModel = new ProductAttributeModel()
                {
                    Name = attributeInfo.Name,
                    Value = attributeValue.Value,
                    Description = attributeInfo.Description,
                    ProductAttributeId = attributeInfo.Id,
                    ProductAttributeValueId = attributeValue.Id
                };
                productAttributeModels.Add(productAttributeModel);
            }

            ProductModel productModel = new ProductModel()
            {
                Id = product.Id,
                Name = product.Name,
                Count = product.Count,
                Price = product.Price,
                MarketingInfo = product.MarketingInfo,
                ProductCategoryId = product.ProductCategoryId,
                SellerId = product.SellerId,
                ProductCategory = productCategory,
                Seller = seller,
                ProductImage = productImages,
                ProductAttributeModel = productAttributeModels
            };

            return productModel;
        }

        public ProductModel PushProductModel(IAddedProductModel addedProductModel, int sellerId)
        {
            Product product = new Product()
            {
                Name = addedProductModel.Name,
                Count = addedProductModel.Count,
                Price = addedProductModel.Price,
                MarketingInfo = addedProductModel.MarketingInfo,
                ProductCategoryId = addedProductModel.CategoryId,
                SellerId = sellerId
            };

            _dBContext.Products.Add(product);
            _dBContext.SaveChanges();

            foreach (var addedImage in addedProductModel.UploadedImages)
            {
                var imagePath = $"SellerImages\\sellerId_{sellerId}\\productId_{product.Id}\\";

                var fullPath = $"{_webRootPath}\\wwwroot\\{imagePath}";

                var imageName = Guid.NewGuid() + "." + addedImage.ContentType.Split("/").Last();

                var productImage = new ProductImage()
                {
                    ImageURL = imagePath + imageName,
                    ProductId = product.Id
                };

                if (Directory.Exists(fullPath) == false)
                {
                    Directory.CreateDirectory(fullPath);
                }

                using (var fileStream = new FileStream(fullPath + imageName, FileMode.Create)) 
                {
                    addedImage.CopyTo(fileStream);
                }

                _dBContext.ProductImages.Add(productImage);
                _dBContext.SaveChanges();
            }

            var productModel = GetProductModel(product.Id);

            return productModel;
        }

        public void DeleteProducts(int SellerId)
        {
            for (int i = 0; i < _dBContext.ProductAttributeValues.Count(); i++)
            {
                if (_dBContext.ProductAttributeValues.Local.FirstOrDefault() != null)
                {
                    _dBContext.Remove(_dBContext.ProductAttributes.Local.FirstOrDefault());
                }
            }

            for (int i = 0; i < _dBContext.ProductAttributes.Count(); i++)
            {
                if (_dBContext.ProductAttributes.Local.FirstOrDefault() != null)
                {
                    _dBContext.Remove(_dBContext.ProductAttributes.Local.FirstOrDefault());
                }
            }

            for (int i = 0; i < _dBContext.ProductImages.Count(); i++)
            {
                if (_dBContext.ProductImages.Local.FirstOrDefault() != null)
                {
                    _dBContext.Remove(_dBContext.ProductImages.Local.FirstOrDefault());
                }
            }            

            for (int i = 0; i < _dBContext.Products.Count(); i++)
            {

                if (_dBContext.Products.Local.FirstOrDefault() != null)
                {
                    _dBContext.Remove(_dBContext.Products.Local.FirstOrDefault());
                }
            }

            _dBContext.SaveChanges();
        }
    }
}
