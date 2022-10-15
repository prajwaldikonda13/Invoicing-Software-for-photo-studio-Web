using System;
using System.Linq;
using VivaBillingNewWeb.Database;

namespace VivaBillingNewWeb
{
    public partial class AddMacAddress : System.Web.UI.Page
    {
        DBConnection dBConnection = new DBConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ServerMessage.InnerText = "";
                macGrid.DataSource = dBConnection.macAddresses.ToList();
                macGrid.DataBind();
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
        }
        protected void Unnamed_Click(object sender, EventArgs e)
        {
            try
            {
                ServerMessage.InnerText = "";
                if (dBConnection.macAddresses.SingleOrDefault(m => m.MAC == mac.Value) == null)
                {
                    dBConnection.macAddresses.Add(new MacAddresses { MAC = mac.Value.ToUpper() });
                    dBConnection.SaveChanges();
                    ServerMessage.InnerText = "Mac address added successfully...";
                }
                else
                {
                    ServerMessage.InnerText = "Mac address already added";
                }
                macGrid.DataSource = dBConnection.macAddresses.ToList();
                macGrid.DataBind();
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
        }
    }
}