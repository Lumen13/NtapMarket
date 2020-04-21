using System;
using System.Collections.Generic;
using System.Text;

namespace NtapMarket.Data.DBModel
{
    public class Order
    {
        public int Id { get; set; }
        public int PurchaserId { get; set; } 
        public int SellerId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime SendTime { get; set; }
    }
}
