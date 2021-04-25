using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApi.Entities.Models;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private DB_CloudKitchenContext context;

        public ItemController(DB_CloudKitchenContext db)
        {
            context = db;
        }

        [Route("item/list")]
        [HttpPost]
        public ListItemResponse ListItem()
        {
            try
            {
                List<Item> listItem = context.Items.ToList() ?? new List<Item>();
                if (listItem != null)
                {
                    context.Dispose();
                    return new ListItemResponse { list = listItem, StatusCode = (int)HttpStatusCode.OK };
                }
                else
                {
                    return new ListItemResponse
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest
                    };
                }
            }
            catch (Exception e)
            {
                return new ListItemResponse
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
            }
        }

        [Route("item/create")]
        [HttpPost]
        public CreateItemResponse CreateItem(CreateItemRequest request)
        {
            try
            {
                if (request != null)
                {
                    var newItem = new Item
                    {
                        ItemName = request.ItemName ?? null,
                        RestaurantId = request.RestaurantId ?? null,
                        ItemDescription = request.ItemDescription ?? "",
                        ItemPrice = request.ItemPrice ?? null,
                        ItemCategoryId = request.ItemCategoryId ?? null,
                        MainImagePath = request.MainImagePath ?? ""
                    };
                    context.Items.Add(newItem);
                    context.SaveChanges();
                    context.Dispose();
                }
                else
                {
                    return new CreateItemResponse
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest
                    };
                }
                return new CreateItemResponse
                {
                    StatusCode = (int)HttpStatusCode.OK
                };
            }
            catch (Exception e)
            {
                return new CreateItemResponse
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
            }
        }

        [Route("item/update")]
        [HttpPost]
        public UpdateItemResponse UpdateItem(UpdateItemRequest request)
        {
            try
            {
                if (request != null)
                {
                    Item item = context.Items.FirstOrDefault(p => p.ItemId == request.ItemId && p.Active == true);
                    if(item != null)
                    {
                        item.ItemCategoryId = request.ItemCategoryId ?? null;
                        item.ItemDescription = request.ItemDescription ?? "";
                        item.ItemName = request.ItemName ?? "";
                        item.ItemPrice = request.ItemPrice ?? null;
                        item.MainImagePath = request.MainImagePath ?? "";
                        item.RestaurantId = request.RestaurantId ?? null;
                        context.Update(item);
                        context.SaveChanges();
                        context.Dispose();
                    }
                    else
                    {
                        return new UpdateItemResponse
                        {
                            StatusCode = (int)HttpStatusCode.BadRequest
                        };
                    }
                }
                else
                {
                    return new UpdateItemResponse
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest
                    };
                }
                return new UpdateItemResponse
                {
                    StatusCode = (int)HttpStatusCode.OK
                };
            }
            catch (Exception e)
            {
                return new UpdateItemResponse
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
            }
        }

        [Route("item/delete")]
        [HttpPost]
        public DeleteItemResponse DeleteItem(DeleteItemRequest request)
        {
            try
            {
                if (request != null)
                {
                    Item item = context.Items.FirstOrDefault(p => p.ItemId == request.ItemId && p.Active == true);
                    if (item != null)
                    {
                        item.Active = false;
                        context.Update(item);
                        context.SaveChanges();
                        context.Dispose();
                    }
                    else
                    {
                        return new DeleteItemResponse
                        {
                            StatusCode = (int)HttpStatusCode.BadRequest
                        };
                    }
                }
                else
                {
                    return new DeleteItemResponse
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest
                    };
                }
                return new DeleteItemResponse
                {
                    StatusCode = (int)HttpStatusCode.OK
                };
            }
            catch (Exception e)
            {
                return new DeleteItemResponse
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
            }
        }
    }
}
