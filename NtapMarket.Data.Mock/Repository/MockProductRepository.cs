using NtapMarket.Data.DBModel;
using NtapMarket.Data.IRepository;
using NtapMarket.Data.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace NtapMarket.Data.Mock.Repository
{
    public class MockProductRepository : IProductModelRepository
    {
        private List<ProductModel> _productModels = new List<ProductModel>()
        {
            new ProductModel()
            {
                Id = 1,
                ProductCategoryId = 1,
                SellerId = 1,
                Count = 1,
                MarketingInfo = "Очень интересная вещь. правда правда",
                Name = "Газонокосилка 3000",
                Price = 30000,

                ProductCategory = new ProductCategory()
                {
                    Id = 1,
                    ParentId = null,
                    Name = "Газонокосилки",
                    Description = "Газонокосилками газонокосилят траву"
                },

                Seller = new Seller()
                {
                    Id = 1,
                    Name = "Борис",
                    Email = "kolbaska@mail.ru",
                    Phone = "88002220022"
                }
            },

            new ProductModel()
            {
                Id = 2,
                SellerId = 2,
                ProductCategoryId = 2,
                Count = 2,
                MarketingInfo = "Тоже интересная вещь. но не очень",
                Name = "Ледяная скорбь",
                Price = 40000,

                ProductCategory = new ProductCategory()
                {
                    Id = 2,
                    ParentId = null,
                    Name = "WoW",
                    Description = "Предметы из вселенной WoW"
                },

                Seller = new Seller()
                {
                    Id = 2,
                    Name = "Ванька",
                    Email = "sosiska@mail.ru",
                    Phone = "88002220021"
                }
            },

            new ProductModel()
            {
                Id = 3,
                SellerId = 1,
                ProductCategoryId = 1,
                Count = 1,
                MarketingInfo = "Невероятно бесполезная штука",
                Name = "Урал 880",
                Price = 46500,

                ProductCategory = new ProductCategory()
                {
                    Id = 1,
                    ParentId = null,
                    Name = "Газонокосилки",
                    Description = "Газонокосилками газонокосилят траву"
                },

                Seller = new Seller()
                {
                    Id = 2,
                    Name = "Ванька",
                    Email = "sosiska@mail.ru",
                    Phone = "88002220021"
                }
            }
        };

        public List<ProductModel> GetProductModels(int sellerId)
        {
            var productList = new List<ProductModel>();

            for (int i = 0; i < _productModels.Count; i++)
            {
                if (_productModels[i].SellerId == sellerId)
                {
                    productList.Add(_productModels[i]);
                }
            }

            return productList;
        }

        public ProductModel GetProductModel(int productId)
        {
            var result = _productModels.FirstOrDefault(x => x.Id == productId);

            return result;
        }

        public void PushProductModel(ProductModel productModel)
        {
            
        }
    }
}
