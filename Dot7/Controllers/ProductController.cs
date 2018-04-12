using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dot7.ServiceTableAdapters;
using Dot7.common;
namespace Dot7.Controllers
{
    public class ProductController : ApiController
    {
        [HttpGet]
        public IEnumerable<Product> getProducts(string id)
        {
            List<Product> list = new List<Product>();
            GetProductsTableAdapter GP = new GetProductsTableAdapter();
            foreach (var item in GP.GetProducts(id))
            {
                list.Add(new Product { ProductID = item.ProductID.ToString(), ProductName = item.ProductName, ProductImage = item.ProductImage, Price = item.Price, AvailabilityFlag = item.Availability, Veg_nVeg_Flag = item.VnNV });

            }
            return list;
        }

        [Route("Products/GetOrders")]
        [HttpGet]
        public IEnumerable<UserOrderDetail> GetUserOrders(string id)
        {
            List<UserOrderDetail> list = new List<UserOrderDetail>();
            GetOrdersTableAdapter GP = new GetOrdersTableAdapter();
      
            foreach (var item in GP.GetOrders(id))
            {
                list.Add(new UserOrderDetail { OID = item.OID.ToString(), Res_Name = item.R_Name, Amount = item.PaymentAmount, Date = item.Date });

            }
            return list;
        }
    }
}
