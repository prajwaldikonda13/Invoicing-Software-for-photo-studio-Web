using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using VivaBillingNewWeb.Database;

namespace VivaBillingNewWeb
{
    public partial class ShowInvoiceById : System.Web.UI.Page
    {
        DBConnection dBConnection = new DBConnection();
        private static List<Jobs> jobsList;
        static Invoices invoice;
        Customers customer;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    ServerMessage.InnerText = "";
                    InvoiceAddress.InnerText = "";
                    InvoiceEmail.InnerText = "";
                    InvoiceFirm.InnerText = "";
                    InvoiceMobile.InnerText = "";
                    InvoiceName.InnerText = "";
                    InvoiceDate.InnerText = "";
                    InvoiceName.InnerText = "";
                    paid.Text = "";



                    if (invoice != null)
                    {

                        ID.InnerText = invoice.ID + "";
                        InvoiceDate.InnerText = invoice.DateTime.ToString("dd MMM yyyy");
                        InvoiceTime.InnerText = invoice.DateTime.ToString("hh:mm tt");
                    }

                    InvoiceTime.InnerText = "";
                    if (Session["InvoiceId"] != null)
                    {
                        BindInvoiceData(true);
                    }
                }
                catch (Exception ex)
                {
                    ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
                }


            }
        }

        protected void InvoiceIdInput_TextChanged(object sender, EventArgs e)
        {
        }

        private void BindInvoiceData(bool IsSessionSet)
        {
            try
            {
                ServerMessage.InnerText = "";
                if ((invoice = dBConnection.invoices.SingleOrDefault(m=>m.ID==(long)Session["InvoiceId"])) != null)
                {
                    customer = dBConnection.customers.SingleOrDefault(m => m.ID == invoice.customer);
                    if (invoice.PrevBal >= 0)
                    {
                        lblPrevDue.InnerText = "Prev Bal:";
                        PrevBal.Value = invoice.PrevBal + "";
                    }
                    else
                    {
                        lblPrevDue.InnerText = "Prev Due:";
                        PrevBal.Value = -1 * invoice.PrevBal + "";
                    }
                    paid.Text = invoice.Paid + "";
                    if (invoice.CurrentBal > 0)
                    {
                        DueLabel.InnerText = "Balance:";
                        due.Value = "" + invoice.CurrentBal;
                    }
                    else
                    {
                        DueLabel.InnerText = "Due:";
                        due.Value = "" + -1 * invoice.CurrentBal;
                    }

                   

                    ID.InnerText = invoice.ID + "";
                    InvoiceAddress.InnerText = customer.Flat + "," + customer.Colony + "," + customer.Landmark + "," + customer.City + "," + customer.PinCode + "," + dBConnection.states.SingleOrDefault(m => m.ID == customer.State).Name + "," + dBConnection.countries.SingleOrDefault(m => m.ID == customer.Country).Name + ",";
                    InvoiceEmail.InnerText = customer.EmailId;
                    InvoiceFirm.InnerText = customer.FirmName;
                    InvoiceMobile.InnerText = customer.MobileNumber;
                    InvoiceName.InnerText = customer.FirstName + " " + customer.LastName;
                    InvoiceDate.InnerText = invoice.DateTime.ToString("dd MMM yyyy");
                    InvoiceName.InnerText = customer.FirstName + customer.LastName + "";
                    paid.Text = invoice.Paid + "";
                    InvoiceTime.InnerText = invoice.DateTime.ToString("hh:mm tt");
                    ServerMessage.InnerText = "";
                    jobsList = dBConnection.jobs.Where(m => m.Invoice == Convert.ToInt32((long)Session["InvoiceId"]));
                }
                else
                {
                    ServerMessage.InnerText = "No invoice found with given id";
                    paid.Text = "";
                    jobsList = new List<Jobs>();
                }
                InvoiceGrid.DataSource = jobsList;
                InvoiceGrid.DataBind();
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
        }

        protected void InvoiceGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                ServerMessage.InnerText = "";
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    {
                        (e.Row.FindControl("Number") as Label).Text = e.Row.RowIndex + 1 + ".";
                        (e.Row.FindControl("invoiceProduct") as Label).Text = dBConnection.products.SingleOrDefault(m=>m.ID==jobsList.ElementAt(e.Row.RowIndex).Product).Name;
                        (e.Row.FindControl("invoiceProductType") as Label).Text = dBConnection.productTypes.SingleOrDefault(m => m.ID==jobsList.ElementAt(e.Row.RowIndex).ProductType).Type;
                        (e.Row.FindControl("invoiceProductSize") as Label).Text = dBConnection.sizes.SingleOrDefault(m => m.ID==jobsList.ElementAt(e.Row.RowIndex).ProductSize).Size;
                    }
                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    int totalQuantity = 0;
                    float totalPrice = 0;
                    foreach (Jobs job in jobsList)
                    {
                        if (job.Product > 0 && job.ProductSize > 0 && job.ProductType > 0)
                        {
                            totalQuantity += Convert.ToInt32(job.Quantity);
                            totalPrice += Convert.ToInt32(job.TotalPrice);
                        }
                    }
                    Label lblTotalQuantity = e.Row.FindControl("InvoiceTotalQuantiy") as Label;
                    Label lblTotalPrice = e.Row.FindControl("InvoiceGrandTotal") as Label;
                    lblTotalQuantity.Text = "" + totalQuantity;
                    lblTotalPrice.Text = totalPrice + "";
                    finalPrice.InnerText = invoice.FinalPrice + "";
                }
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
        }

        protected void paid_TextChanged(object sender, EventArgs e)
        {
            try
            {

                ServerMessage.InnerText = "";
                return;
                string str = Regex.Replace(paid.Text, @"\s+", "").Trim();

                if (str != "")
                {
                    Invoices updatedInvoice = new Invoices();
                    if (invoice != null)
                    {
                        updatedInvoice = invoice;
                        updatedInvoice.Paid = (float)Convert.ToDecimal(paid.Text);
                        dBConnection.Entry<Invoices>(dBConnection.invoices.Find(Convert.ToInt32(invoice.ID))).CurrentValues.SetValues(updatedInvoice);
                        dBConnection.SaveChanges();

                        jobsList = dBConnection.jobs.Where(m => m.Invoice == Convert.ToInt32(invoice.ID)) ;
                        InvoiceGrid.DataSource = jobsList;
                        InvoiceGrid.DataBind();
                        ServerMessage.InnerText = "";
                    }
                }
                else
                {
                    ServerMessage.InnerText = "Error:Invalid input...";
                }
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                ServerMessage.InnerText = "";
                Response.Redirect("PrintInvoice");
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
        }
    }
}