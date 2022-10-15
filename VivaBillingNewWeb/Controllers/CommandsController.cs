using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using VivaBillingNewWeb.Database;

namespace VivaBillingNewWeb.Controllers
{
    public class CommandsController : ApiController
    {
        DBConnection dBConnection =new DBConnection();

        // GET api/<controller>
        public string[] Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public string Post([FromBody]Commands value)
        {
            try
            {
                string[] commandWords = value.Command.ToLower().Split(' ');
                if (commandWords.Contains("show") && commandWords.Contains("customer") && commandWords.Contains("with"))
                {
                    if (commandWords.Contains("id"))
                    {
                        dBConnection.Entry(dBConnection.commands.Find(Convert.ToInt32(1))).CurrentValues.SetValues(new Commands { Command = commandWords[4], ID = 1 });
                        dBConnection.SaveChanges();
                        

                    }
                }
                return "success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}