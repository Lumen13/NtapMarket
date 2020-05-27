using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace NtapMarket.Data.DBModel
{
    public class ProductImage
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ImageURL { get; set; }
        public IFormFile ImageFile { get; set; }
        //public List<IFormFile> UploadedImages { get; set; }
    }
}
