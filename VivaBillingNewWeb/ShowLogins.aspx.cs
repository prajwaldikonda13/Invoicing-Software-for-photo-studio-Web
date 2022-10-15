using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VivaBillingNewWeb.Database;

namespace VivaBillingNewWeb
{
    public partial class ShowLogins : System.Web.UI.Page
    {
        DBConnection dBConnection = new DBConnection();
        List<Logins> listLogins;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ServerMessage.InnerText = "";
                if (!IsPostBack)
                {
                    listLogins = dBConnection.logins;
                    gridLogins.DataSource = listLogins;
                    gridLogins.DataBind();
                }
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
        }

        protected void gridLogins_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                ServerMessage.InnerText = "";
                int rowIndex = e.Row.RowIndex;
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label loginTime = e.Row.FindControl("lblLoginTime") as Label;
                    Label logoutTime = e.Row.FindControl("lblLogoutTime") as Label;
                    loginTime.Text = listLogins.ElementAt(rowIndex).LoginTime.ToString("dd MMM yyyy") + "," + listLogins.ElementAt(rowIndex).LoginTime.ToString("hh:mm:ss tt");
                    logoutTime.Text = listLogins.ElementAt(rowIndex).LogoutTime.ToString("dd MMM yyyy") + "," + listLogins.ElementAt(rowIndex).LogoutTime.ToString("hh:mm:ss tt");
                }
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
        }
    }
}