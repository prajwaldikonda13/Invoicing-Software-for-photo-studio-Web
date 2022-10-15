using System;
using System.Collections.Generic;

namespace VivaBillingNewWeb
{
    public partial class SendEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServerMessage.Visible = false;
            if (ServerMessage.InnerText != "")
                ServerMessage.Visible = true;
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                ServerMessage.InnerText = "";

                string[] emails = StaticFunctions.getValidString(txtEmail.Text, false, true).Split(',');
                foreach (string email in emails)
                    if (StaticFunctions.IsValidEmail(email))
                    {
                        if (txtBody.Text.Trim() == "")
                        {
                            ServerMessage.InnerText = "Please enter the valid text in email body";
                        }
                        else
                        {
                            if (SendByViva.Checked)
                            {
                                VivaEmailServices.SendEmail(txtEmail.Text, txtSubject.Text, txtBody.Text, false);
                                ServerMessage.InnerText = "Email(s) sent successfully to valid email ids";
                            }
                            else if (SendByGmail.Checked)
                            {
                                VivaEmailServices.SendEmail(txtEmail.Text, txtSubject.Text, txtBody.Text, true);
                                ServerMessage.InnerText = "Email(s) sent successfully to valid email ids";
                            }
                        }
                    }
                    else
                    {
                        ServerMessage.InnerText = "Please enter a valid email";
                    }
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
        }
    }
}