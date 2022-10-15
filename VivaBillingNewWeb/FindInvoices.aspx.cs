using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using VivaBillingNewWeb.Database;

namespace VivaBillingNewWeb
{
    public partial class FindInvoices : System.Web.UI.Page
    {
        DBConnection dBConnection = new DBConnection();
        static List<Invoices> InvoicesList = new List<Invoices>();
        float totalDue;
        List<Customers> CustomersList = new List<Customers>();
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void SearchInput_TextChanged(object sender, EventArgs e)
        {
            DataBinding1();
            ServerMessage.InnerText = "";

        }

        private void DataBinding1()
        {
            ServerMessage.InnerText = "";
            DatesPanel.Visible = false;
            SearchInput.Visible = true;
            string str = Regex.Replace(SearchInput.Text, @"\s+", "").Trim();
            if (str != "" || SelectionByDate.Checked)
            {
                try
                {
                    ServerMessage.InnerText = "";
                    InvoicesList = new List<Invoices>() { };
                    CustomersList = new List<Customers>() { };
                    ServerMessage.InnerText = "";
                    if (SelectionById.Checked)
                    {
                        InvoicesList.Add(dBConnection.invoices.SingleOrDefault(m => m.ID.ToString() == str));
                    }
                    else if (SelectionByMobileNumber.Checked || SelectionByName.Checked || SelectionByEmail.Checked)
                    {
                        if (SelectionByMobileNumber.Checked)
                        {
                            List<Customers> k = dBConnection.customers.Where(m=>m.MobileNumber==str).ToList();
                            CustomersList.AddRange(k);
                        }
                        else if (SelectionByName.Checked)
                        {
                           CustomersList.AddRange(dBConnection.customers.Where(m => m.FirstName.ToLower() == str.ToLower() || m.LastName.ToLower() == str.ToLower() || m.FirmName.ToLower() == str.ToLower()));
                        }
                        else
                        {
                            CustomersList.AddRange(dBConnection.customers.Where(m => m.EmailId == str));
                        }
                        if (CustomersList != null)
                        {
                            foreach (Customers customer in CustomersList)
                            {
                                List<Invoices> k = dBConnection.invoices.Where(m => m.customer == customer.ID).ToList();
                                InvoicesList.AddRange(k);
                            }
                        }
                    }
                    else if (SelectionByDate.Checked)
                    {
                        SearchInput.Visible = false;
                        DatesPanel.Visible = true;
                        {
                            DateTime startDate = Convert.ToDateTime(StartDateInput.Text);
                            DateTime endDate = Convert.ToDateTime(EndDateInput.Text);
                            List<Invoices> k = dBConnection.invoices.Where(m => m.DateTime >= startDate && m.DateTime <= endDate.AddDays(1)).ToList();
                            foreach (var j in k)
                            {
                                Customers temp = dBConnection.customers.SingleOrDefault(m => m.ID == j.customer);
                                if (!CustomersList.Contains(temp))
                                {
                                    CustomersList.Add( temp );
                                }
                            }
                            InvoicesList.AddRange(k);
                        }
                    }
                    if (!(SelectionByDate.Checked || SelectionById.Checked || SelectionByMobileNumber.Checked || SelectionByName.Checked || SelectionByEmail.Checked))
                        ServerMessage.InnerText = "Please select an option...";
                    else if (InvoicesList.Count() == 0)
                        ServerMessage.InnerText = "No invoices found...";
                    BindGrid();
                }
                catch (Exception ex)
                {
                    ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
                }
            }
            else
            {
                ServerMessage.InnerText = "Please enter the input....";
            }
        }

        private void BindGrid()
        {
            InvoicesGrid.DataSource = InvoicesList;
            InvoicesList.Reverse();
            InvoicesGrid.DataBind();
        }

        protected void InvoicesGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Customers customer = null;
            Label customerName = e.Row.FindControl("lblCustomerName") as Label;
            Label invoiceGrandTotal = e.Row.FindControl("lblGrandTotal") as Label;
           Label invoiceTotal = e.Row.FindControl("Total") as Label;
            Label time = e.Row.FindControl("lblTime") as Label;
            Label date = e.Row.FindControl("lblDate") as Label;
            Label due = e.Row.FindControl("lblDue") as Label;
            Label currentbal = e.Row.FindControl("CurrentBal") as Label;
            Label PrevBal = e.Row.FindControl("PrevBal") as Label;

            int rowIndex = e.Row.RowIndex;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                customer = dBConnection.customers.SingleOrDefault(m => m.ID == InvoicesList.ElementAt(e.Row.RowIndex).customer);
               
                if (customer != null)
                {
                    customerName.Text = customer.FirstName + " " + customer.LastName + "," + customer.FirmName+","+customer.CustomerType;
                }
                float gt = InvoicesList.ElementAt(rowIndex).FinalPrice + InvoicesList.ElementAt(rowIndex).Discount;
                if(gt!=0)
                    invoiceTotal.Text =gt + InvoicesList.ElementAt(rowIndex).PrevBal+ "";
                else
                    invoiceTotal.Text = InvoicesList.ElementAt(rowIndex).Paid + InvoicesList.ElementAt(rowIndex).PrevBal - InvoicesList.ElementAt(rowIndex).CurrentBal+ "";


                invoiceGrandTotal.Text = InvoicesList.ElementAt(rowIndex).FinalPrice + InvoicesList.ElementAt(rowIndex).Discount+ "";
                time.Text = InvoicesList.ElementAt(rowIndex).DateTime.ToString("hh:mm tt");
                date.Text = InvoicesList.ElementAt(rowIndex).DateTime.ToString("dd MMM yyyy");
                var val = InvoicesList.ElementAt(rowIndex).FinalPrice - InvoicesList.ElementAt(rowIndex).Paid;
                if (val < 0)
                    due.Text = "0";
                else
                    due.Text = val + "";
                totalDue += InvoicesList.ElementAt(rowIndex).FinalPrice - InvoicesList.ElementAt(rowIndex).Paid;

                if (InvoicesList.ElementAt(rowIndex).CurrentBal < 0)
                    currentbal.Text = "0";
                else
                    currentbal.Text = InvoicesList.ElementAt(rowIndex).CurrentBal + "";

                if (InvoicesList.ElementAt(rowIndex).PrevBal < 0)
                {
                    PrevBal.Text = -1 * InvoicesList.ElementAt(rowIndex).PrevBal + "";
                    PrevBal.ForeColor = Color.Red;
                }
                else
                {
                    PrevBal.Text = InvoicesList.ElementAt(rowIndex).PrevBal + "";
                    PrevBal.ForeColor = Color.Green;

                }
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
               
                if (CustomersList.ElementAt(0).Balance >= 0)
                    (e.Row.FindControl("TotalDue") as Label).Text = "Balance:" + CustomersList.ElementAt(0).Balance;
                else
                    (e.Row.FindControl("TotalDue") as Label).Text = "Due:" + -1 * CustomersList.ElementAt(0).Balance;
                totalDue = 0;
               
                if (SelectionByMobileNumber.Checked || SelectionByEmail.Checked)
                {
                }
                else
                {
                }
            }
        }
        protected void SelectButton_Click(object sender, EventArgs e)
        {

        }
        protected void ShowInvoiceButton_Click(object sender, EventArgs e)
        {
            long InvoiceId = Convert.ToInt32((((sender as LinkButton).NamingContainer as GridViewRow).FindControl("lblId") as Label).Text);
            Session["InvoiceId"] = InvoiceId;
            Response.Redirect("PrintInvoice.aspx");
        }
        protected void ShowCustomerButton_Click(object sender, EventArgs e)
        {
            long CustomerId = InvoicesList.ElementAt(((sender as LinkButton).NamingContainer as GridViewRow).RowIndex).customer;
            Session["CustomerId"] = CustomerId;
            Response.Redirect("ShowCustomerDetails.aspx");
        }
        protected void ShowJobs_Click(object sender, EventArgs e)
        {
            long InvoiceId = InvoicesList.ElementAt(((sender as LinkButton).NamingContainer as GridViewRow).RowIndex).ID;
            Session["InvoiceId"] = InvoiceId;
            Response.Redirect("ShowJobsInInvoice.aspx");
        }

        protected async void SendEmailInvoice_Click(object sender, EventArgs e)
        {
            Invoices invoice = InvoicesList[((sender as LinkButton).NamingContainer as GridViewRow).RowIndex];
            Customers customer = dBConnection.customers.SingleOrDefault(m => m.ID == invoice.customer);
            long InvoiceId = invoice.ID;
            Session["InvoiceId"] = InvoiceId;

            try
            {
                ServerMessage.InnerText = "";

                HttpClient httpClient = new HttpClient();
                string html = await httpClient.GetStringAsync("http://localhost:64723/printinvoice?InvoiceId=" + InvoiceId);
                VivaEmailServices.SendEmail(customer.EmailId, "Test Invoice", html, true);
            }
            catch (WebException we)
            {
            }
        }

        protected void txtPaid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                return;
                ServerMessage.InnerText = "";

                float CurrentPaid = (float)Convert.ToDouble((sender as TextBox).Text);
                if (CurrentPaid <= 0)
                {
                    ServerMessage.InnerText = "Please enter valid value";
                    return;
                }
               
                Invoices updated = InvoicesList.LastOrDefault();
                Customers cust = dBConnection.customers.SingleOrDefault(m => m.ID == updated.customer);
                Customers updatedCustomer = cust;
                updatedCustomer.Balance += CurrentPaid;
                DailyCount originalCount = dBConnection.dailyCount.SingleOrDefault(m => m.dateTime.ToShortDateString() == TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, Site1.INDIAN_ZONE).ToShortDateString());
                if (originalCount == null)
                {
                    dBConnection.dailyCount.Add(new DailyCount { dateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, Site1.INDIAN_ZONE), Count = 0 });
                    dBConnection.SaveChanges();
                    
                }
                originalCount = dBConnection.dailyCount.SingleOrDefault(m => m.dateTime.ToShortDateString() == TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, Site1.INDIAN_ZONE).ToShortDateString());
                DailyCount updatedCount = originalCount;
                updatedCount.Count += CurrentPaid;
                dBConnection.Entry(dBConnection.invoices.Find(updated.ID)).CurrentValues.SetValues(updated);
                dBConnection.Entry(dBConnection.customers.Find(cust.ID)).CurrentValues.SetValues(updatedCustomer);
                dBConnection.SaveChanges();
                
                
                CurrentPaid = 0;
                DataBinding1();
                ServerMessage.InnerText = "Data updated successfully....";
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
        }
        protected void SelectionById_CheckedChanged(object sender, EventArgs e)
        {

            if (SelectionByDate.Checked)
            {
                DatesPanel.Visible = true;
                SearchInput.Visible = false;
            }
            else
            {
                DatesPanel.Visible = false;
                SearchInput.Visible = true;
            }
            DataBinding1();
        }
    }
}