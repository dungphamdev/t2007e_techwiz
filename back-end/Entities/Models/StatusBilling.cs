using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Entities.Models
{
    public partial class StatusBilling
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public string CustomerId { get; set; }
        public int? Status { get; set; }
        public DateTime? Date { get; set; }

        public virtual Billing Order { get; set; }
    }
}
