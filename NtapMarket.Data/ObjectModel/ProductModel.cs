using NtapMarket.Data.DBModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace NtapMarket.Data.ObjectModel
{
    public class ProductModel : Product
    {
        public List<ProductImage> ProductImage = new List<ProductImage>();
        public List<ProductAttributeModel> ProductAttributeModel = new List<ProductAttributeModel>();
        public List<UserImageModel> UserImageList = new List<UserImageModel>();
        public Seller Seller { get; set; }
        public ProductCategory ProductCategory { get; set; }
    }
}
