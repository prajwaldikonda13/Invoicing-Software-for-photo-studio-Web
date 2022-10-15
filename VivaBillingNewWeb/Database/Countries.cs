using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VivaBillingNewWeb.Database
{
    public class Countries
    {
        public long ID { get; set; }
        public string Name { get; set; }
    }
}