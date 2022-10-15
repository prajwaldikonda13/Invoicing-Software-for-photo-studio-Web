using System;
using System.Linq;
using System.Net;
using VivaBillingNewWeb.Database;
namespace VivaBillingNewWeb
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        public static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        DBConnection dBConnection = new DBConnection();
        public static string oldCommand = string.Empty;
        public static string newCommand = string.Empty;
        public static long redirectCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["LoggedIn"] == null || Session["MacAddress"] == null)
                {
                    //Response.Redirect("login");
                }
                else
                {
                    string PCName = Dns.GetHostEntry(Request.ServerVariables["REMOTE_ADDR"]).HostName;
                    //if (PCName != "Winner")
                    if (dBConnection.dailyCount.SingleOrDefault(m => m.dateTime.ToString("dd MMM yyyy") == TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, Site1.INDIAN_ZONE).ToString("dd MMM yyyy")) == null)
                    {
                        dBConnection.dailyCount.Add(new DailyCount { Count = 0, dateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, Site1.INDIAN_ZONE) });
                        dBConnection.SaveChanges();
                    }
                    //lblIpAddress.InnerText = (string)Session["LoggedInIP"];
                    //lblIpAddress.InnerText = "Pc Name:" + PCName;
                    //lblIpAddress.InnerText = (string)Session["LoggedInIP"];
                    lblIpAddress.InnerText = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, Site1.INDIAN_ZONE).ToString("hh:mm:ss tt");

                    if (redirectCount == 0)
                    {
                        Session["LoggedInIP"] = (string)Session["LoggedInIP"];
                        dBConnection.logins.Add(new Logins { IP = (string)Session["LoggedInIP"], LoginTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, Site1.INDIAN_ZONE), LogoutTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, Site1.INDIAN_ZONE) });
                        dBConnection.SaveChanges();
                        redirectCount++;
                    }
                }
            }
            catch (Exception ex)
            {
                //ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            newCommand = dBConnection.commands.SingleOrDefault().Command;
            if (newCommand != oldCommand)
            {
                oldCommand = newCommand;


                long InvoiceId = Convert.ToInt64(newCommand);
                Session["InvoiceId"] = InvoiceId;
                Response.Redirect("ShowInvoiceById.aspx");
            }
        }
    }
}