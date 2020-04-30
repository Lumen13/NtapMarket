using NtapMarket.Data.DBModel;
using NtapMarket.Data.IRepository;
using NtapMarket.Data.ObjectModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace NtapMarket.Data.Mock.Repository
{
    public class MockProductRepository : IProductModelRepository
    {
        public List<ProductModel> GetProductModel(int sellerId)
        {
            var productModels = new List<ProductModel>()
            {
                new ProductModel()
                {
                    Id = 1,
                    ProductCategoryId = 1,
                    SellerId = 1,
                    Count = 1,
                    MarketingInfo = "очень интересная вещь. правда правда",
                    Name = "газонокосилка 3000",
                    Price = 30000,

                    ProductCategory = new ProductCategory()
                    {
                        Id = 1,
                        ParentId = null,
                        Name = "газонокосилки",
                        Description = "газонокосилками газонокосилят траву"
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
                    MarketingInfo = "тоже интересная вещь. но не очень",
                    Name = "ледяная скорбь",
                    Price = 40000,

                    ProductCategory = new ProductCategory()
                    {
                        Id = 2,
                        ParentId = null,
                        Name = "WoW",
                        Description = "предметы по WoW"
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
                    MarketingInfo = "невероятно бесполезная штука",
                    Name = "урал 880",
                    Price = 46500
                }
            };

            return productModels;
        }

        public void PushProductModel(ProductModel productModel)
        {
            
        }
    }
}
