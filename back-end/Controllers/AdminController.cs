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
    public class AdminController : ControllerBase
    {
        private DB_CloudKitchenContext context;

        public AdminController(DB_CloudKitchenContext db)
        {
            context = db;
        }

        [Route("admin/bills/list")]
        [HttpPost]
        public AdminGetAllBillResponse GetAllBill()
        {
            List<AdminGetAllBillModel> listA = new List<AdminGetAllBillModel>();
            var listB = context.Billings.ToList();
            var listC = context.OrderDetails.ToList();
            foreach(var clone in listB)
            {
                foreach(var clone2 in listC)
                {
                    if(clone.OrderId == clone2.OrderId)
                    {
                        listA.Add(new AdminGetAllBillModel
                        {
                            OrderId = clone.OrderId,
                            OrderDate = clone2.OrderDate,
                            OrderLocation = clone2.OrderLocation,
                            OrderItemName = clone2.OrderItemName,
                            OrderItemQty = (int)clone2.OrderItemQty,
                            CustomerId = clone.CustomerId,
                            BillAmount = clone.BillAmount,
                            Date = clone.Date,
                            RestaurantId = clone.RestaurantId,
                            Status = clone.Status
                        });
                    }    
                }                    
            }    
            return new AdminGetAllBillResponse { list = listA,StatusCode = (int)HttpStatusCode.OK };
        }

        [Route("admin/bills/approach")]
        [HttpPost]
        public AdminApproachBillResponse AdminApproachBill(AdminApproachBillRequest request)
        {
            var bill = context.Billings.FirstOrDefault(p => p.OrderId == request.OrderId);
            if (bill != null)
            {
                bill.Status = 2;
                StatusBilling stsbill = new StatusBilling();
                stsbill.OrderId = bill.OrderId;
                stsbill.CustomerId = (int)bill.CustomerId;
                stsbill.Status = bill.Status;
                stsbill.Date = DateTime.Now;
                context.StatusBillings.Add(stsbill);
                context.Billings.Update(bill);
                context.SaveChanges();                
                context.Dispose();
                return new AdminApproachBillResponse { StatusCode = (int)HttpStatusCode.OK };
            }
            return new AdminApproachBillResponse { StatusCode = (int)HttpStatusCode.BadRequest };
        }
    }
}
