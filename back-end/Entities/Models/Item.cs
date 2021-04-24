using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Entities.Models
{
    public partial class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int? RestaurantId { get; set; }
        public string ItemDescription { get; set; }
        public decimal? ItemPrice { get; set; }
        public int? ItemCategoryId { get; set; }
        public bool? Active { get; set; }
        public string MainImagePath { get; set; }

        public virtual ItemCategory ItemCategory { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
