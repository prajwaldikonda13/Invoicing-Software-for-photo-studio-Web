using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using VivaBillingNewWeb.Database;

namespace VivaBillingNewWeb
{
    public partial class TruncateTables : System.Web.UI.Page
    {
        DBConnection dBConnection = new DBConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            if(password.Text=="some_password")
            {
                List<string> nodelete = new List<string>() { "__MigrationHistory", "Countries", "States" };
                    List<string> results = dBConnection.Database.SqlQuery<string>("SELECT name FROM sys.tables ORDER BY name").ToList();
                foreach(string tablename in results)
                {
                    if(!nodelete.Contains(tablename))
                    {
                        dBConnection.Database.ExecuteSqlCommand("TRUNCATE TABLE [" + tablename + "]");
                        dBConnection.SaveChanges();
                    }
                }
            }
        }
    }
}