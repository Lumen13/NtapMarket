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
            var products = _dBContext.Products.Where(x => x.SellerId == sellerId && x.IsDeleted == false).ToList();
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

            if (product.IsDeleted == true)
            {
                return null;
            }

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

            if (addedProductModel.UploadedImages != null)
            {
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
            }
            else
            {

            }

            var productModel = GetProductModel(product.Id);

            return productModel;
        }

        public void EditProductModel(ProductModel productModel, int sellerId)
        {
            var product = _dBContext.Products.Find(productModel.Id);
            product.Name = productModel.Name;
            product.Count = productModel.Count;
            product.Price = productModel.Price;
            product.MarketingInfo = productModel.MarketingInfo;
            product.ProductCategoryId = productModel.ProductCategoryId;

            int i = 0;
            foreach (var editImage in productModel.ProductImage)
            {
                var imagePath = $"SellerImages\\sellerId_{sellerId}\\productId_{product.Id}\\";

                var fullPath = $"{_webRootPath}\\wwwroot\\{imagePath}";

                using var filestream = new FileStream(Path.Combine(fullPath, $"file{i++}.png"),
                        FileMode.Create,
                        FileAccess.Write);
                editImage.ImageFile.CopyTo(filestream);
            }

            _dBContext.SaveChanges();
        }

        public void DeleteProducts(int sellerId)
        {
            var products = _dBContext.Products.Where(x => x.SellerId == sellerId);
            foreach (var product in products)
            {
                product.IsDeleted = true;
            }

            _dBContext.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var products = _dBContext.Products.Where(x => x.Id == id);
            foreach (var product in products)
            {
                product.IsDeleted = true;
            }

            _dBContext.SaveChanges();
        }
    }
}
