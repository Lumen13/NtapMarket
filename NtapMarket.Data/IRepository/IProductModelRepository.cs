using NtapMarket.Data.DBModel;
using NtapMarket.Data.ObjectModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace NtapMarket.Data.IRepository
{
    public interface IProductModelRepository
    {
        List<ProductModel> GetProductModel(int sellerId, int id);
        void PushProductModel(ProductModel productModel);
    }
}
