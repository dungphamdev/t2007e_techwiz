using System.Collections.Generic;
using WebApi.Entities.Models;
using WebApi.Messages.Response;

namespace WebApi.Controllers
{
    public class ListItemResponse:BaseResponse
    {
        public List<Item> list { get; set; }
    }
}