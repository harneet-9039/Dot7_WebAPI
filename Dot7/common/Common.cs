using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dot7.common
{
    public class Login
    {
        public string LoginID { get; set; }
        public string password { get; set; }
        
    }

    public class Register
    {
        public string LoginID { get; set; }
        public string password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class Restaurant
    {
        public Guid key { get; set; }
        public string RestaurantName { get; set; }
        public string Time { get; set; }
        public string ImageURL { get; set; }
        public string Rating { get; set; }
        public string Cuisines { get; set; }
        public string isFavourite { get; set; }
    }

    public class Token
    {
        public string token { get; set; }
    }

    public class Product
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public string AvailabilityFlag { get; set; }
        public string Price { get; set; }
        public string Veg_nVeg_Flag { get; set; }
    }

    public class Favourite
    {
    public string RestaurantID { get; set; }
    public string LoginID { get; set; }
    public string Count { get; set; }
    }

    public class NavBarData
    {
    public string Name { get; set; }
    public string Email { get; set; }
    }

    public class OrderDetail
    {

        public string FlatNo { get; set; }
        public string LoginID { get; set; }
        public string StreetName { get; set; }
        public string Landmark { get; set; }
        public string JSONData { get; set; }
       
    }

    public class UserOrderDetail
    {

        public string OID { get; set; }
        public string Res_Name { get; set; }
        public string Amount { get; set; }
        public string Date { get; set; }

    }




}
