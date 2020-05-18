using Microsoft.AspNetCore.Http;
using NtapMarket.Data.ObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NtapMarket.Web.Seller.Models
{
    public class UserProductVM : IAddedProductModel
    {
        [Required]
        [DisplayName("Название продукта")]
        [MaxLength(50, ErrorMessage = "Название слишком длинное")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Количество единиц товара (штук)")]
        public int Count { get; set; }

        [Required]
        public decimal Price { get; set; }

        [MaxLength(1000, ErrorMessage = "Описание слишком длинное")]
        public string MarketingInfo { get; set; }

        public int? CategoryId { get; set; }

        [MaxLength(10, ErrorMessage = "Максимальное число аттрибутов - 10")]
        public List<IAddedProductAttributeModel> UserAttributes { get; set; }

        [MaxLength(10, ErrorMessage = "Максимальное кол-во изображений - 10")]
        public List<IFormFile> UploadedImages { get; set; }
    }

    public class UserProductAttributeVM : IAddedProductAttributeModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Название слишком длинное")]
        public string Name { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Название слишком длинное")]
        public string Value { get; set; }

        [MaxLength(300, ErrorMessage = "Описание слишком длинное")]
        public string Description { get; set; }
    }
}
