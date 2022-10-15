using System.Net;
using System.Net.Mail;

namespace VivaBillingNewWeb
{
    public class VivaEmailServices
    {
        public static void SendEmail(string to, string subject, string body,bool sendByGmail)
        {
            string from, username, password;
            if(sendByGmail)
            {
                from = "your_email_id";
                username = "your_username";
                password = "your_password";
            }
            else
            {
                from = "your_username";
                username = "your_userid";
                password = "your_password";
            }
            using (MailMessage mm = new MailMessage(from,to))
            {
                mm.From = new MailAddress(from, "main_name_to_show");
                mm.Subject = subject;
                mm.Body = body;
                //if (fuAttachment.HasFile)
                //{
                //    string FileName = Path.GetFileName(fuAttachment.PostedFile.FileName);
                //    mm.Attachments.Add(new Attachment(fuAttachment.PostedFile.InputStream, FileName));
                //}
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                NetworkCredential NetworkCred = new NetworkCredential(username, password);
                if (sendByGmail)
                {
                    smtp = new SmtpClient();
                    smtp.Host = "smtp_server_address";
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;//Change as needed
                }
                else
                {
                    smtp = new SmtpClient();
                    smtp.Host = "your_host_address";
                    smtp.EnableSsl = false;
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 25;//Change as needed
                }
                //ServicePointManager.ServerCertificateValidationCallback = delegate (object s,
                //       System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                //       System.Security.Cryptography.X509Certificates.X509Chain chain,
                //       System.Net.Security.SslPolicyErrors sslPolicyErrors)
                //{
                //    return true;
                //};
                smtp.Send(mm);
                // ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email sent.');", true);
            }
        }
    }
}