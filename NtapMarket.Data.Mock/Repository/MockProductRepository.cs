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
                    }
                }
            };

            return productModels;
        }

        public void PushProductModel(ProductModel productModel)
        {
            
        }
    }
}
