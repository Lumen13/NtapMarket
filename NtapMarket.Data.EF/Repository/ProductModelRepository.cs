using NtapMarket.Data.DBModel;
using NtapMarket.Data.IRepository;
using NtapMarket.Data.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace NtapMarket.Data.EF.Repository
{
    public class ProductModelRepository : IProductModelRepository
    {
        private DBContext _dBContext { get; set; }

        public ProductModelRepository(string connectionString)
        {
            _dBContext = new DBContext(connectionString);
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

        public ProductModel GetProductModel(int Id)
        {
            return null;
        }

        public ProductModel SetProductModel()
        {
            return null;
        }

        public void PushProductModel(ProductModel productModel)
        {

        }
    }
}
