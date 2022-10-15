using System;
using System.Collections.Generic;
using System.Linq;
using VivaBillingNewWeb.Database;

namespace VivaBillingNewWeb
{
    public partial class Login : System.Web.UI.Page
    {
        DBConnection dBConnection = new DBConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ServerMessage.InnerText = "";
                List<string> allowedMacAddresses = new List<string>();
                foreach (MacAddresses mac in dBConnection.macAddresses)
                {
                    allowedMacAddresses.Add( mac.MAC );
                }
                string r = Request.QueryString["r"];
                if (!allowedMacAddresses.Contains(Request.QueryString["mac"]) && Request.QueryString["mac"] != "0C9D92A4048B" || r.Length != 175)
                {
                }
                else
                {
                    Session["MacAddress"] = Request.QueryString["mac"];
                    Session["r"] = Request.QueryString["r"];
                }
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;

            }
        }

        

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                ServerMessage.InnerText = "";

                {
                    if (username.Value == "vivaadmin" && (password.Value == "viva@9270"))//|| password.Value == "a"))
                    {
                        string ip = (Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ??
                       Request.ServerVariables["REMOTE_ADDR"]).Split(',')[0].Trim();
                        if (false)//(string)Session["LoggedInIP"] == ip)
                        {
                            ServerMessage.InnerText = "User with given IP already logged in.....";
                        }
                        else
                        {
                            
                            Session["LoggedIn"] = true;
                            Session["LoggedInIP"] = ip;
                            Response.Redirect("Main");
                        }
                    }
                    else
                    {
                        ServerMessage.InnerText = "Invalid user id and/or password.....";
                    }
                }
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;

            }
        }
    }
}