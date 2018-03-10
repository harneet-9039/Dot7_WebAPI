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
    //[Authorize]
   

    public class ValuesController : ApiController
    {

        
        // GET api/values
        public IEnumerable<string> Get()
        {

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]Login credentials)
        {
            CheckUserCredentialsTableAdapter r = new CheckUserCredentialsTableAdapter();
            object obj = r.CheckUserCredentials(credentials.LoginID, credentials.password);
            Boolean value = Convert.ToBoolean(obj);
            if(value==true)
            {

            }
            else
            {

            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
