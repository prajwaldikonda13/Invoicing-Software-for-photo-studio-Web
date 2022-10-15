using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace VivaBillingNewWeb.Controllers
{
    public class VivaController : ApiController
    {
        // GET: api/Viva
        public string[] Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Viva/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Viva
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Viva/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Viva/5
        public void Delete(int id)
        {
        }
    }
}
