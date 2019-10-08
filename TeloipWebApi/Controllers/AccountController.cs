using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TeloipWebApi.Controllers
{
    public class AccountController : ApiController
    {
        
        // GET api/values/5
        public HttpResponseMessage Get(string userpassword)
        {
            var usernamePasswordArray = userpassword.Split(':');
            var userName = usernamePasswordArray[0];
            var password = usernamePasswordArray[1];

            using (TeloipEntities db = new TeloipEntities())
            {
                var entity = db.Users.Any(usr => usr.EmailAddress.Equals(userName) && usr.Password.Equals(password));
                if (entity == false)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Error");
                }
                else
                {
                    //entity.Password = DecodePasswordFrom64(entity.Password);
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
            }
            
        }
    }
}
