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
    [Route("api/restaurant")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private DB_CloudKitchenContext context;

        public RestaurantController(DB_CloudKitchenContext db)
        {
            context = db;
        }
    }
}
