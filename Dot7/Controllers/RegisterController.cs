using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dot7.common;
using Dot7.ServiceTableAdapters;

namespace Dot7.Controllers
{
    public class RegisterController : ApiController
    {
        
        [HttpPost]
        public String RegisterCredentials([FromBody]Register Obj)
        {
            RegisterUserTableAdapter ru = new RegisterUserTableAdapter();
            object obj = ru.RegisterUser(Obj.Name, Obj.LoginID, Obj.password,Obj.Email);
            String Status = obj.ToString();
            if (Status.Equals("true"))
            {
                String message = Request.CreateResponse(HttpStatusCode.Created).ToString();
                return message;
            }
            else if(Status.Equals("exists"))
            {
                String message = Request.CreateErrorResponse(HttpStatusCode.Conflict, Obj.LoginID).ToString();
                return message;
            }
            else
            {
                String message = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, Obj.LoginID).ToString();
                return message;
            }
        }

       /* [HttpGet]
        public IEnumerable<Register> GetUsers()
        {
            List<Register> list = new List<Register>();
            GetUsersTableAdapter gu = new GetUsersTableAdapter();
            foreach (var item in gu.GetUsers())
            {
                list.Add(new Register { Name = item.Name.ToString(), LoginID = item.MobileNo });

            }
            return list;
            

        }*/
    }
}
