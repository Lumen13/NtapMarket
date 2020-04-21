using System;
using System.Collections.Generic;
using System.Text;

namespace NtapMarket.Data.DBModel
{
    public class ProductAttributeValue
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ProductAttributeId { get; set; }
        public string Value { get; set; }
    }
}
