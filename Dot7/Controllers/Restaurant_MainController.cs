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
    public class Restaurant_MainController : ApiController
    {
        [HttpGet]
        public IEnumerable<Restaurant> getRestaurants(string id)
        {
            List<Restaurant> list = new List<Restaurant>();
            GetRestaurantsTableAdapter gs = new GetRestaurantsTableAdapter();
            foreach (var item in gs.GetRestaurants(id))
            {
                list.Add(new Restaurant { key = item.Key, RestaurantName = item.Restaurant_Name, Time = item.Time, Rating = item.Rating, ImageURL = item.ImageURL, Cuisines = item.Cuisines, isFavourite = item.isFavourite });

            }
            return list;
        }


        [HttpPost]
        public String AddtoFavourite([FromBody]Favourite Value)
        {
            AddtoFavouriteTableAdapter AF = new AddtoFavouriteTableAdapter();
            object Response = AF.AddtoFavourite(Value.RestaurantID, Value.LoginID, Value.Count);
            Boolean chk = Convert.ToBoolean(Response);
            if(chk==true)
            {
                String message = Request.CreateResponse(HttpStatusCode.Accepted).ToString();
                return message;
            }
            else
            {
                String message = Request.CreateErrorResponse(HttpStatusCode.BadGateway, Value.LoginID).ToString();
                return message;
            }
            
        }

        [Route("Restaurant_Main/GetFav")]
        [HttpPost]
        public String GetInitialfav([FromBody]Favourite Value)
        {
            GetInitialFavTableAdapter AF = new GetInitialFavTableAdapter();
            object Response = AF.GetInitialFav(Value.RestaurantID, Value.LoginID);
            Boolean chk = Convert.ToBoolean(Response);
            if (chk == true)
            {
                String message = Request.CreateResponse(HttpStatusCode.Accepted).ToString();
                return message;
            }
            else
            {
                String message = Request.CreateErrorResponse(HttpStatusCode.BadGateway, Value.LoginID).ToString();
                return message;
            }

        }

        [Route("Restaurant_Main/GetNavData")]
        [HttpGet]
        public IEnumerable<NavBarData> GetNavData(string id)
        {
            GetPersonDetailsTableAdapter GP = new GetPersonDetailsTableAdapter();
            List<NavBarData> list = new List<NavBarData>();
            foreach (var item in GP.GetUserData(id))
            {
                
                list.Add(new NavBarData { Name = item.Name, Email = item.Email });

            }
            return list;

        }

       /* [Route("Restaurant_Main/GetUserAddress")]
        [HttpGet]
        public IEnumerable<UserAddress> GetAddress(string id)
        {
            GetUserAddressTableAdapter GP = new GetUserAddressTableAdapter();
            List<UserAddress> list = new List<UserAddress>();
            foreach (var item in GP.GetUserAddress(id))
            {

                list.Add(new UserAddress { AddID = item.AddressID, FlatNo = item.FlatNo, StreetName = item.StreetName, Landmark = item.Landmark, District = item.DistrictName, State = item.StateName, Pincode = item.Pincode });

            }
            return list;

        }*/

        [Route("Restaurant_Main/InsertOrder")]
        [HttpPost]
        public String InsertAdd([FromBody]OrderDetail Value)
        {
            OrderFoodTableAdapter AF = new OrderFoodTableAdapter();
            Value.JSONData = Value.JSONData.Replace("\\\"","\"");
            object Response = AF.OrderFood(Value.FlatNo,Value.StreetName,Value.Landmark,Value.JSONData,Value.LoginID);
            Boolean chk = Convert.ToBoolean(Response);
            if (chk == true)
            {
                String message = Request.CreateResponse(HttpStatusCode.Created).ToString();
                return message;
            }
            else
            {
                String message = Request.CreateErrorResponse(HttpStatusCode.BadGateway, Value.LoginID).ToString();
                return message;
            }

        }
    }
}
