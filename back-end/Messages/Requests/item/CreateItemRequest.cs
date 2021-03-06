namespace WebApi.Controllers
{
    public class CreateItemRequest
    {
        public string ItemName { get; set; }
        public int? RestaurantId { get; set; }
        public string ItemDescription { get; set; }
        public decimal? ItemPrice { get; set; }
        public int? ItemCategoryId { get; set; }
        public string MainImagePath { get; set; }
    }
}