using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Entities.Models
{
    public partial class Billing
    {
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public int? RestaurantId { get; set; }
        public decimal? BillAmount { get; set; }
        public DateTime? Date { get; set; }
        public int StatusId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual StatusBilling Status { get; set; }
    }
}
