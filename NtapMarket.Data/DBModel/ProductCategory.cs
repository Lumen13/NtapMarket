using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NtapMarket.Data.DBModel
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
