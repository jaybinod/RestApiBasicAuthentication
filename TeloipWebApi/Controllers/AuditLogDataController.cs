using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeloipWebApi.Filters;

namespace TeloipWebApi.Controllers
{
    [BasicAuthentication]
    public class AuditLogDataController : ApiController
    {

        BasicAuthenticationAttribute GetUserDetails = new BasicAuthenticationAttribute();
        // GET: api/AuditLog
        public IEnumerable<AuditLog> GetAllUsers()
        {

            //Update Log
            string usernm = GetUserDetails.GetUserName();
            using (TeloipEntities db = new TeloipEntities())
            {
                return db.AuditLogs.Where(e=>e.EmailAddress==usernm).ToList();
            }
        }


    }
}
