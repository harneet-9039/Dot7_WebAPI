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
    public class LoginController : ApiController
    {
        // GET api/values
        [HttpPost]
        public HttpResponseMessage CheckCredentials([FromBody]Login Obj)
        {
            CheckUserCredentialsTableAdapter r = new CheckUserCredentialsTableAdapter();
            object obj = r.CheckUserCredentials(Obj.LoginID, Obj.password);
            Boolean value = Convert.ToBoolean(obj);
            if (value == true)
            {
                var message = Request.CreateResponse(HttpStatusCode.Found);
                message.Headers.Location = new Uri(Request.RequestUri + Obj.LoginID.ToString());
                return message;
            }
            else
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, Obj.LoginID.ToString());
                return message;
            }
        }
    }
}
