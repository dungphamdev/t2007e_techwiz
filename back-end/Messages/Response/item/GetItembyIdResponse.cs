using WebApi.Entities.Models;
using WebApi.Messages.Response;
using WebApi.Models.items;

namespace WebApi.Controllers
{
    public class GetItembyIdResponse:BaseResponse
    {
        public ItemModel item { get; set; }
    }
}