using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Test.Models
{
    public class Order
    {
        public System.Guid OrderId { get; set; }
        public string ServiceName { get; set; }
        public int Quantity { get; set; }
        public decimal Rate { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public System.Guid JobId { get; set; }

        public virtual Jobs Job { get; set; }

    }
}