﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NtapMarket.Data.DBModel
{
    public class Product
    {
        public int Id { get; set; }
        public int? ProductCategoryId { get; set; }
        public int SellerId { get; set; }
        public string Name { get; set; }
        public string MarketingInfo { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}
