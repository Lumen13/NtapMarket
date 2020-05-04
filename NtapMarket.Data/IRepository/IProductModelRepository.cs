using NtapMarket.Data.DBModel;
using NtapMarket.Data.ObjectModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace NtapMarket.Data.IRepository
{
    public interface IProductModelRepository
    {
        List<ProductModel> GetProductModels(int sellerId);

        ProductModel GetProductModel(int Id);

        void PushProductModel(ProductModel productModel);
    }
}
