using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using VivaBillingNewWeb.Database;

namespace VivaBillingNewWeb
{
    public partial class ShowCustomers : System.Web.UI.Page
    {
        DBConnection dBConnection = new DBConnection();
        static List<Customers> customerList;
        Customers customer;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            bindGridView();
        }

        private void bindGridView()
        {
            try
            {
                ServerMessage.InnerText = "";
                customerList = dBConnection.customers;
                grid.DataSource = customerList;
                grid.DataBind();
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
           
        }

        protected void grid_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            try
            {
                ServerMessage.InnerText = "";
                btnAddCustomer.Visible = false;
                ServerMessage.InnerText = "";
                grid.EditIndex = e.NewEditIndex;
                bindGridView();
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
           
        }

        protected void grid_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            try
            {
                ServerMessage.InnerText = "";
                var s = "";
                if (grid.EditIndex != e.RowIndex)
                    return;
                DropDownList CustType = (grid.Rows[e.RowIndex].FindControl("drpCustomerType") as DropDownList);
                DropDownList state = (grid.Rows[e.RowIndex].FindControl("drpState") as DropDownList);
                DropDownList country = (grid.Rows[e.RowIndex].FindControl("drpCountry") as DropDownList);
                customer = new Customers()
                {

                    ID = customerList.ElementAt(e.RowIndex).ID,
                    FirmName = (s = StaticFunctions.getValidString(((TextBox)grid.Rows[e.RowIndex].FindControl("txtFirmName")).Text, true, false)) == "" ? "NA" : s,
                    City = (s = StaticFunctions.getValidString(((TextBox)grid.Rows[e.RowIndex].FindControl("txtCity")).Text, false, false)) == "" ? "NA" : s,
                    Colony = (s = StaticFunctions.getValidString(((TextBox)grid.Rows[e.RowIndex].FindControl("txtColony")).Text, false, false)) == "" ? "NA" : s,
                    Country = Convert.ToInt64(country.Items[country.SelectedIndex].Value),
                    EmailId = (s = StaticFunctions.getValidString(((TextBox)grid.Rows[e.RowIndex].FindControl("txtEmailId")).Text, false, true)) == "" ? "NA" : s,
                    FirstName = StaticFunctions.getValidString(((TextBox)grid.Rows[e.RowIndex].FindControl("txtFirstName")).Text, false, false),
                    Flat = (s = StaticFunctions.getValidString(((TextBox)grid.Rows[e.RowIndex].FindControl("txtFlat")).Text, false, false)) == "" ? "NA" : s,
                    Landmark = (s = StaticFunctions.getValidString(((TextBox)grid.Rows[e.RowIndex].FindControl("txtLandmark")).Text, true, false)) == "" ? "NA" : s,
                    LastName = StaticFunctions.getValidString(((TextBox)grid.Rows[e.RowIndex].FindControl("txtLastName")).Text, false, false),
                    MobileNumber = (s = StaticFunctions.getValidString(((TextBox)grid.Rows[e.RowIndex].FindControl("txtMobileNumber")).Text, false, false)) == "" ? "NA" : s,
                    PinCode = (s = StaticFunctions.getValidString(((TextBox)grid.Rows[e.RowIndex].FindControl("txtPinCode")).Text, false, false)) == "" ? "NA" : s,
                    CustomerType = CustType.Text
            };

                if (customer.FirstName == "" || customer.LastName == "")
                {
                    ServerMessage.InnerText = "Please enter first name and last name";
                    return;
                }
                Customers temp = null;
                if (customer.MobileNumber != "NA")
                    temp = dBConnection.customers.SingleOrDefault(m => m.MobileNumber == customer.MobileNumber);

                if (temp != null)
                {
                    if (temp.Equals(customerList.ElementAt(e.RowIndex)))
                        temp = null;
                    else
                        ServerMessage.InnerText = "Customer with given mobile number already exists.";
                }
                Customers temp1 = null;
                if (customer.EmailId != "NA")
                    temp1 = dBConnection.customers.SingleOrDefault(m => m.EmailId == customer.EmailId);
                if (temp1 != null)
                {
                    if (temp1 == customerList.ElementAt(e.RowIndex))
                        temp1 = null;
                    else
                        ServerMessage.InnerText = "Customer with given Email Id already exists.";
                }
                Customers temp2 = null;
                if (customer.EmailId == "NA" && customer.MobileNumber == "NA")
                {
                    temp2 = dBConnection.customers.SingleOrDefault(m => m.FirstName == customer.FirstName && m.LastName == customer.LastName);
                    if (temp2 != null)
                    {
                        if (temp2 == customerList.ElementAt(e.RowIndex))
                            temp2 = null;
                        else
                            ServerMessage.InnerText = "Customer with given Name already exists.";
                    }
                }
                temp = temp1 = temp2 = null;
                if (temp==null && temp1 ==null && temp2==null)
                {
                    dBConnection.Entry(dBConnection.customers.Find(customer.ID)).CurrentValues.SetValues(customer);
                    dBConnection.SaveChanges();
                    

                    ServerMessage.InnerText = "Customer added successfully....";
                }
                btnAddCustomer.Visible = true;
                grid.EditIndex = -1;
                bindGridView();
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }

           
        }

       
        private string getValidString(string str)
        {
            str = Regex.Replace(str, @"\s+", " ").ToLower().Trim();
            return str;
        }
        protected void grid_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            try
            {
                ServerMessage.InnerText = "";
                btnAddCustomer.Visible = true;
                ServerMessage.InnerText = "";
                dBConnection.customers.Remove(dBConnection.customers.SingleOrDefault(m=>m.ID==customerList.ElementAt(e.RowIndex).ID));
                dBConnection.SaveChanges();
                

                bindGridView();
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
           
        }

        protected void grid_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            try
            {
                ServerMessage.InnerText = "";
                btnAddCustomer.Visible = true;
                ServerMessage.InnerText = "";
                grid.EditIndex = -1;
                bindGridView();
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
            
        }

        protected void btnAddCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                ServerMessage.InnerText = "";
                if (customerList.ElementAt(customerList.Count() - 1).State == 0)
                    return;
                ServerMessage.InnerText = "";
                dBConnection.customers.Add(new Customers { });
                dBConnection.SaveChanges();
                

                bindGridView();
                btnAddCustomer.Visible = false;
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
            
        }

        protected void grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
               if(e.Row.RowType==DataControlRowType.DataRow)
                {
                    if (e.Row.RowState != DataControlRowState.Edit && grid.EditIndex!=e.Row.RowIndex)
                    {
                        Label state = e.Row.FindControl("lblState") as Label;
                        Label country = e.Row.FindControl("lblCountry") as Label;
                        state.Text = dBConnection.states.SingleOrDefault(m => m.ID == customerList.ElementAt(e.Row.RowIndex).State).Name;
                        country.Text = dBConnection.countries.SingleOrDefault(m => m.ID == customerList.ElementAt(e.Row.RowIndex).Country).Name;

                    }
                    else
                    {
                        DropDownList drpCustomerType;
                        DropDownList drpState;
                        DropDownList drpCountry;
                        drpCustomerType = e.Row.FindControl("drpCustomerType") as DropDownList;
                        drpState = e.Row.FindControl("drpState") as DropDownList;
                        drpCountry = e.Row.FindControl("drpCountry") as DropDownList;

                        drpCustomerType.DataSource = new List<string>() { "CC", "RC" };
                        drpCustomerType.DataBind();
                        drpCustomerType.SelectedIndex = customerList.ElementAt(e.Row.RowIndex).CustomerType == "CC" ? 0 : 1;

                        drpState.DataSource = dBConnection.states;
                        drpState.DataTextField = "Name";
                        drpState.DataValueField = "ID";
                        drpState.DataBind();
                        drpState.SelectedIndex = 0;

                        drpCountry.DataSource = dBConnection.countries;
                        drpCountry.DataTextField = "Name";
                        drpCountry.DataValueField = "ID";
                        drpCountry.DataBind();
                        drpCountry.SelectedIndex = 0;
                    }
                }
                //if ( e.Row.RowIndex==grid.EditIndex && && e.Row.RowType == DataControlRowType.DataRow)
                {
                   

                }
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
        }
    }
}