using System.Collections.Generic;
using WebApi.Entities.Models;
using WebApi.Messages.Response;

namespace WebApi.Controllers
{
    public class ListRestaurantResponse:BaseResponse
    {
        public List<Restaurant> list { get; set; }
    }
}