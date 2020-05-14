using Microsoft.AspNetCore.Http;
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

        ProductModel SetProductModel
            (string name,
            int count, 
            decimal price, 
            string marketingInfo,
            string CategoryName,
            string CategoryDescription,
            string AttributeModelName,
            string AttributeModelValue,
            string AttributeModelDescription,
            ProductCategory SelectModel,
            IFormFileCollection uploadedFiles);

        void PushProductModel(ProductModel productModel);
    }
}
