using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Entities.Models
{
    public partial class OrderDetail
    {
        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string OrderLocation { get; set; }
        public string OrderItemName { get; set; }
        public string OrderItemQty { get; set; }
        public int OrderDetailId { get; set; }

        public virtual Billing Order { get; set; }
    }
}
