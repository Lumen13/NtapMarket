using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace NtapMarket.Data.ObjectModel
{
    public interface IAddedProductModel
    {
        string Name { get; set; }

        int Count { get; set; }

        decimal Price { get; set; }

        string MarketingInfo { get; set; }

        int? CategoryId { get; set; }

        List<IAddedProductAttributeModel> UserAttributes { get; set; }

        List<IFormFile> UploadedImages { get; set; }
    }
}

