using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VivaBillingNewWeb.Database;

namespace VivaBillingNewWeb
{
    public partial class ShowCustomerDetails : System.Web.UI.Page
    {
        DBConnection dBConnection = new DBConnection();


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ServerMessage.InnerText = "";
                if (Session["CustomerId"] != null)
                {

                    //public string  { get; set; }
                    //public string  { get; set; }
                    //public string  { get; set; }
                    //public string  { get; set; }
                    //public string  { get; set; }
                    //public string  { get; set; }
                    //public string  { get; set; }
                    //public string  { get; set; }
                    //public string  { get; set; }
                    //public string  { get; set; }
                    //public string  { get; set; }

                    Customers customer = dBConnection.customers.SingleOrDefault(m => m.ID == (long)Session["CustomerId"]);
                    ID.InnerText = customer.ID + "";
                    FirstName.InnerText = customer.FirstName + "";
                    LastName.InnerText = customer.LastName + "";
                    FirmName.InnerText = customer.FirmName + "";
                    EmailId.InnerText = customer.EmailId + "";
                    MobileNumber.InnerText = customer.MobileNumber + "";
                    PinCode.InnerText = customer.PinCode + "";
                    Flat.InnerText = customer.Flat + "";
                    Colony.InnerText = customer.Colony + "";
                    Landmark.InnerText = customer.Landmark + "";
                    City.InnerText = customer.City + "";
                    State.InnerText = customer.State + "";
                    Country.InnerText = customer.Country + "";
                }
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
        }
    }
}