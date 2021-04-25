using WebApi.Entities.Models;
using WebApi.Messages.Response;

namespace WebApi.Controllers
{
    public class GetItembyIdResponse:BaseResponse
    {
        public Item item { get; set; }
    }
}