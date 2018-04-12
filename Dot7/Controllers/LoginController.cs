using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dot7.ServiceTableAdapters;
using Dot7.common;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;

namespace Dot7.Controllers
{
    public class LoginController : ApiController
    {
        // GET api/values
        [HttpPost]
        public String CheckCredentials([FromBody]Login Obj)
        {
            CheckUserCredentialsTableAdapter r = new CheckUserCredentialsTableAdapter();
            object obj = r.CheckUserCredentials(Obj.LoginID, Obj.password);
            String value = Convert.ToString(obj);
            if (value.Equals("true"))
            {
                String message = Request.CreateResponse(HttpStatusCode.Found).ToString();
                return message;
            }
            else if (value.Equals("false"))
            {
                String message = Request.CreateErrorResponse(HttpStatusCode.NotFound, Obj.LoginID).ToString();
                return message;
            }
            else
            {
                String message = Request.CreateErrorResponse(HttpStatusCode.Forbidden, Obj.LoginID).ToString();
                return message;
            }
        }

        [Route("Login/UpdatePassword")]
        [HttpPost]
        public String UpdatePassword([FromBody]Login Obj)
        {
            UpdatePasswordTableAdapter UP = new UpdatePasswordTableAdapter();
            object obj = UP.UpdatePassword(Obj.LoginID, Obj.password);
            Boolean status = Convert.ToBoolean(obj);
            if (status == true)
            {
                String message = Request.CreateResponse(HttpStatusCode.Accepted).ToString();
                return message;
            }
            else
            {
                String message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, Obj.LoginID).ToString();
                return message;
            }
        }

        [Route("Login/CheckValidLogin")]
        [HttpPost]
        public String CheckValidity([FromBody]Login chk)
        {
            ValidateLoginUserTableAdapter vl = new ValidateLoginUserTableAdapter();
            object obj = vl.ValidateLoginUser(chk.LoginID);
            Boolean status = Convert.ToBoolean(obj);
            if (status == true)
            {
                String message = Request.CreateResponse(HttpStatusCode.Found).ToString();
                return message;
            }
            else
            {
                String message = Request.CreateErrorResponse(HttpStatusCode.NotFound, chk.LoginID).ToString();
                return message;
            }
        }

        [Route("Login/Firebase")]
        [HttpPost]
        public string SendPushNotification([FromBody]Token token)
        {
            try
            {
                string applicationID = "";
                string senderId = "";
                string deviceId = token.token.ToString();
                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                var data = new
                {
                    to = deviceId,
                    notification = new
                    {
                        body = "Welcome to DOT7!!",
                        sound = "Enabled"
                    }
                };

                var serializer = new JavaScriptSerializer();

                var json = serializer.Serialize(data);
                Byte[] byteArray = Encoding.UTF8.GetBytes(json);
                tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
                tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                tRequest.ContentLength = byteArray.Length;

                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                string str = sResponseFromServer;
                            }
                        }
                    }
                }
                return "HELLO";
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return str;
            }
        }
    }
    }
    
