using Newtonsoft.Json;
using System;
using System.Linq;
using System.Web.Http;
using VivaBillingNewWeb.Database;
using System.Web.Http.Results;
using System.Threading.Tasks;

namespace VivaBillingNewWeb.Controllers
{
    public class CustomerController : ApiController
    {
        DBConnection dBConnection = new DBConnection();
        // GET: api/Customer
        public async Task<RedirectResult> Get()
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
            return Redirect("localhost:64723//login.aspx");
        }

        // GET: api/Customer/5
        public string Get(int id)
        {
            try
            {
                return "";// JsonConvert.SerializeObject(dBConnection.customers.Where(m => m.ID == id));
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // POST: api/Customer
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Customer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Customer/5
        public void Delete(int id)
        {
        }
        [HttpPost]
        public string CustomerExistsOrNot([FromBody]Customers customer)
        {
            try
            {
                Redirect("login.aspx");
                return JsonConvert.SerializeObject(dBConnection.customers.Where(m => m.MobileNumber == customer.MobileNumber));
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}