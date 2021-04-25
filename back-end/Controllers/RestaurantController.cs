using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebApi.Entities.Models;
using WebApi.Models;
using WebApi.Services;
using WebApi.Messages.Requests.users;
using WebApi.Messages.Response.users;
using System.Collections.Generic;
using System.Net;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private DB_CloudKitchenContext context;

        public RestaurantController(DB_CloudKitchenContext db)
        {
            context = db;
        }

        [Route("restaurant/create")]
        [HttpPost]
        public CreateRestaurantResponse CreateRestaurant([FromBody] CreateRestaurantRequest request)
        {
            try
            {
                if (request != null)
                {
                    var newRestaurant = new Restaurant
                    {
                        RestaurantName = request.RestaurantName ?? "",
                        RestaurantAddress = request.RestaurantAddress ?? "",
                        RestaurantEmail = request.RestaurantEmail ?? "",
                        RestaurantPhone = request.RestaurantPhone ?? "",
                        Longitude = request.Longitude ?? null,
                        Latitude = request.Latitude ?? null,
                    };
                    context.Restaurants.Add(newRestaurant);
                    context.SaveChanges();
                    context.Dispose();
                }
                else
                {
                    return new CreateRestaurantResponse
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest
                    };
                }
                return new CreateRestaurantResponse
                {
                    StatusCode = (int)HttpStatusCode.OK
                };
            }
            catch (Exception e)
            {
                return new CreateRestaurantResponse
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
            }
        }

        [Route("restaurant/update")]
        [HttpPost]
        public UpdateRestaurantResponse UpdateRestaurant([FromBody] UpdateRestaurantRequest request)
        {
            try
            {
                var restaurant = context.Restaurants.FirstOrDefault(p => p.RestaurantId == request.RestaurantId && p.Active == true);
                if (restaurant != null)
                {
                    restaurant.Latitude = request.Latitude;
                    restaurant.Longitude = request.Longitude;
                    restaurant.RestaurantAddress = request.RestaurantAddress;
                    restaurant.RestaurantEmail = request.RestaurantEmail;
                    restaurant.RestaurantPhone = request.RestaurantPhone;
                    restaurant.RestaurantName = request.RestaurantName;
                    context.Restaurants.Update(restaurant);
                    context.SaveChanges();
                    context.Dispose();
                }
                else
                {
                    return new UpdateRestaurantResponse
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest
                    };
                }
                return new UpdateRestaurantResponse
                {
                    StatusCode = (int)HttpStatusCode.OK
                };
            }
            catch (Exception e)
            {
                return new UpdateRestaurantResponse
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
            }
        }

        [Route("restaurant/list")]
        [HttpPost]
        public ListRestaurantResponse ListRestaurant()
        {
            try
            {
                List<Restaurant> listRestaurant = context.Restaurants.ToList() ?? new List<Restaurant>();
                if (listRestaurant != null)
                {
                    context.Dispose();
                    return new ListRestaurantResponse { list = listRestaurant, StatusCode = (int)HttpStatusCode.OK };                    
                }
                else
                {
                    return new ListRestaurantResponse
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest
                    };
                }                
            }
            catch (Exception e)
            {
                return new ListRestaurantResponse
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
            }
        }

        [Route("restaurant/delete")]
        [HttpPost]
        public DeleteRestaurantResponse DeleteRestaurant([FromBody] DeleteRestaurantRequest request)
        {
            try
            {
                var Restaurant = context.Restaurants.FirstOrDefault(p => p.RestaurantId == request.RestaurantId && p.Active == true);
                if (Restaurant != null)
                {                    
                    Restaurant.Active = false;
                    context.Update(Restaurant);
                    context.SaveChanges();
                    context.Dispose();
                    return new DeleteRestaurantResponse
                    {
                        StatusCode = (int)HttpStatusCode.OK
                    };
                }
                else
                {
                    return new DeleteRestaurantResponse
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest
                    };
                }
            }
            catch (Exception e)
            {
                return new DeleteRestaurantResponse
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
            }
        }
    }
}
