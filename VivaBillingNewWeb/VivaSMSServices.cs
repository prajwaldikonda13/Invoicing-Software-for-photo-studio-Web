using System.Net;

namespace VivaBillingNewWeb
{
    public class VivaSMSServices
    {
        public static void SendSMS(string to, string body)
        {
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("your_gateway_address?country=your_country_code&sender=snder_name&route=route&mobiles="+to+"&authkey=your_auth_key&message="+body);
            HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
            System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
            string responseString = respStreamReader.ReadToEnd();
            respStreamReader.Close();
            myResp.Close();
        }
    }
}