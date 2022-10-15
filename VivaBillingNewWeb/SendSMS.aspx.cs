using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VivaBillingNewWeb
{
    public partial class SendSMS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                ServerMessage.InnerText = "";

                if (txtBody.Text.Trim() != "")
                {
                    string[] numbers = txtMobile.Text.Split(',');
                    foreach (string number in numbers)
                        if (StaticFunctions.IsValidMobile(number))
                            VivaSMSServices.SendSMS(number, txtBody.Text);
                    ServerMessage.InnerText = "Message sent to valid mobile number(s)";
                }
                else
                {
                    ServerMessage.InnerText = "Please enter the Message in the body";
                }
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
        }
    }
}