using System;
using System.Linq;
using VivaBillingNewWeb.Database;

namespace VivaBillingNewWeb
{
    public partial class Logout : System.Web.UI.Page
    {
        DBConnection dBConnection = new DBConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ServerMessage.InnerText = "";
                Session["LoggedIn"] = null;
                Site1.redirectCount = 0;
                Logins login = dBConnection.logins.Where(m => m.IP == (string)Session["LoggedInIP"]).LastOrDefault();
                Session["LoggedInIP"] = null;
                Logins update = login;
                login.LogoutTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, Site1.INDIAN_ZONE);
                dBConnection.Entry(dBConnection.logins.Find(login.ID)).CurrentValues.SetValues(update);
                dBConnection.SaveChanges();
                

                Response.Redirect("Login?mac=" + Session["MacAddress"]+"&r="+ Session["r"]);
            }
            catch(Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
        }
    }
}