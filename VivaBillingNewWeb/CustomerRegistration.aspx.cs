using System;
using System.Collections.Generic;
using System.Linq;
using VivaBillingNewWeb.Database;

namespace VivaBillingNewWeb
{
    public partial class CustomerRegistration : System.Web.UI.Page
    {
        DBConnection dBConnection = new DBConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindCountries();
                bindStates();
                //customerType.DataSource = new List<string>() { "Counter Customer","Regular Customer"};
                //customerType.DataBind();
            }
            ServerMessage.InnerText = "";
        }
        private void bindStates()
        {
            try
            {
                ServerMessage.InnerText = "";
                Session["stateList"] = dBConnection.states;
                states.DataSource = Session["stateList"];
                states.DataValueField = "ID";
                states.DataTextField = "Name";
                states.DataBind();
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }

        }
        private void bindCountries()
        {
            try
            {
                ServerMessage.InnerText = "";

                Session["invoice"] = dBConnection.countries;
                countries.DataSource = Session["invoice"];
                countries.DataValueField = "ID";
                countries.DataTextField = "Name";
                countries.DataBind();
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }

        }
        protected void submit_Click(object sender, EventArgs e)
        {
            try
            {
                ServerMessage.InnerText = "";

               
                createCustomerObject();
                if ((Session["customer"] as Customers).FirstName == "" || (Session["customer"] as Customers).LastName == "")
                {
                    ServerMessage.InnerText = "Please enter first name and last name";
                    return;
                }
                Customers temp = null;
                if ((Session["customer"] as Customers).MobileNumber != "NA")
                    temp = dBConnection.customers.SingleOrDefault(m => m.MobileNumber == (Session["customer"] as Customers).MobileNumber);

                if (temp != null)
                {
                    MobileError.InnerText = "Customer with given mobile number already exists.";
                    MobileError.Visible = true;
                }
                Customers temp1 = null;
                if ((Session["customer"] as Customers).EmailId != "NA")
                    temp1 = dBConnection.customers.SingleOrDefault(m => m.EmailId == (Session["customer"] as Customers).EmailId);
                if (temp1 != null)
                {
                    EmailError.InnerText = "Customer with given Email Id already exists.";
                    EmailError.Visible = true;
                }
                Customers temp2 = null;
                if ((Session["customer"] as Customers).EmailId == "NA" && (Session["customer"] as Customers).MobileNumber == "NA")
                {
                    temp2 = dBConnection.customers.SingleOrDefault(m => m.FirstName == (Session["customer"] as Customers).FirstName && m.LastName == (Session["customer"] as Customers).LastName);
                    if (temp2 != null)
                    {
                        ServerMessage.InnerText = "Customer with given Name already exists.";
                    }
                }
                if (temp == null && temp1 == null && temp2 == null)
                {
                    dBConnection.customers.Add((Session["customer"] as Customers));
                    dBConnection.SaveChanges();
                    
                    ServerMessage.InnerText = "Customer added successfully....";
                }
               
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
        }
        private void createCustomerObject()
        {
            var s = "";
            Session["customer"] = new Customers()
            {
                FirmName = (s = StaticFunctions.getValidString(firmName.Value, true, false)) == "" ? "NA" : s,
                City = (s = StaticFunctions.getValidString(city.Value, false, false)) == "" ? "NA" : s,
                Colony = (s = StaticFunctions.getValidString(colony.Value, false, false)) == "" ? "NA" : s,
                Country = (Session["invoice"] as List<Countries>).ElementAt(countries.SelectedIndex).ID,
                EmailId = (s = StaticFunctions.getValidString(emailId.Value, false, true)) == "" ? "NA" : s,
                FirstName = StaticFunctions.getValidString(firstName.Value, false, false),
                Flat = (s = StaticFunctions.getValidString(flatNo.Value, false, false)) == "" ? "NA" : s,
                Landmark = (s = StaticFunctions.getValidString(landmark.Value, true, false)) == "" ? "NA" : s,
                LastName = StaticFunctions.getValidString(lastName.Value, false, false),
                MobileNumber = (s = StaticFunctions.getValidString(mobile.Value, false, false)) == "" ? "NA" : s,
                PinCode = (s = StaticFunctions.getValidString(pinCode.Value, false, false)) == "" ? "NA" : s,
                State = (Session["stateList"] as List<States>).ElementAt(states.SelectedIndex).ID,
                Balance = 0,
                CustomerType = typeCounterCustomer.Checked ? "CC" : "RC"
            };
        }

        protected void Reset_Click(object sender, EventArgs e)
        {
            firstName.Value = "";
            lastName.Value = "";
            firmName.Value = "";
            emailId.Value = "";
            mobile.Value = "";
            flatNo.Value = "";
            landmark.Value = "";
            city.Value = "";
            colony.Value = "";
            pinCode.Value = "";
        }


        protected void SendOtpBtn_Click1(object sender, EventArgs e)
        {

            try
            {
                ServerMessage.InnerText = "";

            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
        }

        private EmailVerifications generateEmailVerification()
        {
            try
            {
                ServerMessage.InnerText = "";

                return null;
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
                return null;
            }
        }

        private MobileVerifications generateMobileVerification()
        {
            try
            {
                ServerMessage.InnerText = "";

               
                return null;
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
                return null;
            }
        }

        protected void hasMobile_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}