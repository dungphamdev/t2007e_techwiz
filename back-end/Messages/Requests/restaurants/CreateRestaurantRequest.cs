namespace WebApi.Controllers
{
    public class CreateRestaurantRequest
    {
        public string RestaurantName { get; set; }
        public string RestaurantAddress { get; set; }
        public string RestaurantEmail { get; set; }
        public string RestaurantPhone { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }
    }
}