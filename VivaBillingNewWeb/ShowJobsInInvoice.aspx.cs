using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using VivaBillingNewWeb.Database;

namespace VivaBillingNewWeb
{
    public partial class ShowJobsInInvoice : System.Web.UI.Page
    {
        DBConnection dBConnection = new DBConnection();
        static List<Jobs> jobsList = new List<Jobs>();
        Customers customer;
        Invoices invoice;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ServerMessage.InnerText = "";
                if ((invoice = dBConnection.invoices.SingleOrDefault(m => m.ID == (long)Session["InvoiceId"])) != null && !IsPostBack)
                {
                    customer = dBConnection.customers.SingleOrDefault(m => m.ID == invoice.customer);
                    CustomerName.InnerText = customer.FirstName + " " + customer.LastName + "," + customer.FirmName;
                    InvoiceDate.InnerText = invoice.DateTime.ToString("dd MMM yyyy");
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }

        }

        private void BindGrid()
        {
            try
            {
                ServerMessage.InnerText = "";
                jobsList = dBConnection.jobs.Where(m => m.Invoice == (long)Session["InvoiceId"]);
                JobsGrid.DataSource = jobsList;
                JobsGrid.DataBind();
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }

        }

        protected void JobsGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                ServerMessage.InnerText = "";
                int rowIndex = e.Row.RowIndex;
                Label Product = e.Row.FindControl("lblProduct") as Label;
                Label ProductType = e.Row.FindControl("lblProductType") as Label;
                Label ProductSize = e.Row.FindControl("lblProductSize") as Label;
                RadioButton StatusNotStarted = e.Row.FindControl("StatusNotStarted") as RadioButton;
                RadioButton StatusInProgress = e.Row.FindControl("StatusInProgress") as RadioButton;
                RadioButton StatusCompleted = e.Row.FindControl("StatusCompleted") as RadioButton;
               
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Product.Text = dBConnection.products.SingleOrDefault(m => m.ID == jobsList.ElementAt(rowIndex).Product).Name;
                    ProductType.Text = dBConnection.productTypes.SingleOrDefault(m => m.ID == jobsList.ElementAt(rowIndex).ProductType).Type;
                    ProductSize.Text = dBConnection.sizes.SingleOrDefault(m => m.ID == jobsList.ElementAt(rowIndex).ProductSize).Size;

                    switch (jobsList.ElementAt(rowIndex).Status)
                    {
                        case "NS":
                            StatusNotStarted.Checked = true;
                            break;
                        case "IP":
                            StatusInProgress.Checked = true;
                            break;
                        case "CO":
                            StatusCompleted.Checked = true;
                            break;
                        default:
                            StatusNotStarted.Checked = true;
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
        }
        protected void StatusNotStarted_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ServerMessage.InnerText = "";
                RadioButton selectedButton = sender as RadioButton;
                int rowIndex = ((sender as RadioButton).NamingContainer as GridViewRow).RowIndex;
                Jobs selectedJob = dBConnection.jobs.SingleOrDefault(m => m.ID == jobsList.ElementAt(rowIndex).ID);
                Invoices invoice = dBConnection.invoices.SingleOrDefault(m => m.ID == selectedJob.Invoice);
                Customers customer = dBConnection.customers.SingleOrDefault(m => m.ID == invoice.customer);
                Jobs updatedJob = selectedJob;
                string subject = "Update regarding status of your jobs";
                string body = "<body style='background-color:white'>We have completed the work of all the products in the invoice given below.Please visit the Viva Digital to issue your order.";
                body += "<center>Customer Name:" + customer.FirstName + " " + customer.LastName + "," + customer.FirmName + "<br>Invoice Date:" + invoice.DateTime.ToString("dd MMM yyyy") + "<br>Invoice Time:" + invoice.DateTime.ToString("hh:mm tt") + @"</center><table border=1 style='border-color:white'><tr><th>No.</th><th>Product</th><th>Type</th><th>Size</th><th>Unit Price</th><th>Quantity</th><th>totalPtice</th></tr>";
                switch ((sender as RadioButton).ID)
                {
                    case "StatusNotStarted":
                        updatedJob.Status = "NS";
                       
                        break;
                    case "StatusInProgress":
                        updatedJob.Status = "IP";
                        break;
                    case "StatusCompleted":
                        updatedJob.Status = "CO";
                        break;
                }
                dBConnection.Entry(dBConnection.jobs.Find(selectedJob.ID)).CurrentValues.SetValues(updatedJob);
                dBConnection.SaveChanges();
                

                jobsList.ToList()[rowIndex] = updatedJob;
                int completed = 0;
                float totalQuantity = 0;
                float totalPrice = 0;
                foreach (Jobs job in jobsList)
                {
                    if (job.Status == "CO")
                    {
                        completed++;
                        totalQuantity += job.Quantity;
                        totalPrice += job.TotalPrice;
                        body += @"<tr>
<td>" + completed + @"</td>
<td>" + dBConnection.products.SingleOrDefault(m => m.ID == job.Product).Name + @"</td>
<td>" + dBConnection.productTypes.SingleOrDefault(m => m.ID == job.ProductType).Type + @"</td>
<td>" + dBConnection.sizes.SingleOrDefault(m => m.ID == job.ProductSize).Size + @"</td>
<td>" + job.UnitPrice + @"</td>
<td>" + job.Quantity + @"</td>
<td>" + job.TotalPrice + @"</td> ";
                    }
                }
                body += @"<tr>
<td></td>
<td></td>
<td></td>
<td></td>
<td></td>
<td>TQ:" + totalQuantity + @"</td>
<td>Total:" + totalPrice + @"</td>
</tr></table>";
                body += "Thank you for joining " +
                    " <b>" +
                    "<span style='color:blue'>V</span>" +
                    "<span style='color:yellow'>i</span>" +
                    "<span style='color:green'>v</span>" +
                    "<span style='color:orange'>a</span>" +
                    " Digital</b>." +
                    "Have a great day.</body>";
                totalQuantity = 0;
                totalPrice = 0;
                if (completed == jobsList.Count())
                    VivaEmailServices.SendEmail(customer.EmailId, subject, body, false);
                completed = 0;
                BindGrid();
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }


        }
    }
}