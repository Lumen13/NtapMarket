using System;
using System.Collections.Generic;
using System.Text;

namespace NtapMarket.Data.DBModel
{
    public class OrderElement
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
    }
}
