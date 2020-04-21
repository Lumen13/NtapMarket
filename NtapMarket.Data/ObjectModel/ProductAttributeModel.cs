using System;
using System.Collections.Generic;
using System.Text;

namespace NtapMarket.Data.ObjectModel
{
    public class ProductAttributeModel
    {
        public int ProductAttributeId { get; set; }
        public int ProductAttributeValueId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    }
}
