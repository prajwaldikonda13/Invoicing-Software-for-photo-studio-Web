using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using VivaBillingNewWeb.Database;

namespace VivaBillingNewWeb
{
    public partial class PrintInvoice : System.Web.UI.Page
    {
        DBConnection dBConnection = new DBConnection();
        Customers customer;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["InvoiceId"] != null && Request.QueryString["username"] != null && Request.QueryString["password"] != null)
                {
                    if (Request.QueryString["username"] == "vivaadmin" && Request.QueryString["password"] == "viva@9270")
                    {
                        long id = Convert.ToInt32(Request.QueryString["InvoiceId"]);
                        Session["InvoiceId"] = id;
                        BindInvoiceData(true);
                        return;
                    }
                    else
                    {
                        //Response.Redirect("Login");
                    }
                }
                else if (Session["LoggedIn"] == null)
                {
                    //Response.Redirect("Login");
                }
                CustomerAddress.InnerText = "";
                EmailAddress.InnerText = "";
                FirmName.InnerText = "";
                CustomerMobileNumber.InnerText = "";
                CustomerName.InnerText = "";
                Date.InnerText = "";
                due.InnerText = "";
                paid.InnerText = "";
                Time.InnerText = "";
                if (Session["InvoiceId"] != null)
                {
                    BindInvoiceData(true);
                }
               
            }

        }

        protected void InvoiceIdInput_TextChanged(object sender, EventArgs e)
        {
        }

        private void BindInvoiceData(bool IsSessionSet)
        {
            if ((Session["invoice"] = dBConnection.invoices.Where(m=>m.ID==(long)Session["InvoiceId"])) != null)
            {
                customer = dBConnection.customers.SingleOrDefault(m => m.ID ==(Session["invoice"] as Invoices).customer);
                if ((Session["invoice"] as Invoices).PrevBal >= 0)
                {
                    lblPrevDue.InnerText = "Prev Bal:";
                    PrevBal.InnerText =(Session["invoice"] as Invoices).PrevBal + "";
                }
                else
                {
                    lblPrevDue.InnerText = "Prev Due:";
                    PrevBal.InnerText = -1 *(Session["invoice"] as Invoices).PrevBal + "";
                }
                paid.InnerText =(Session["invoice"] as Invoices).Paid + "";
                if ((Session["invoice"] as Invoices).CurrentBal >= 0)
                {
                    DueLabel.InnerText = "Balance:";
                    due.InnerText = "" +(Session["invoice"] as Invoices).CurrentBal;
                }
                else
                {
                    DueLabel.InnerText = "Due:";
                    due.InnerText = "" + -1 *(Session["invoice"] as Invoices).CurrentBal;
                }

                ID.InnerText =(Session["invoice"] as Invoices).ID + "";
                StringBuilder sb = new StringBuilder();

                if (customer.FirmName != "NA")
                    sb.Append("," + customer.FirmName);
                if (customer.EmailId != "NA")
                    sb.Append("," + customer.EmailId);
                if (customer.MobileNumber != "NA")
                    sb.Append("," + customer.MobileNumber);
                if (customer.Flat != "NA") sb.Append(',' + customer.Flat);
                if (customer.Colony != "NA") sb.Append("," + customer.Colony);
                if (customer.Landmark != "NA") sb.Append("," + customer.Landmark);
                if (customer.City != "NA") sb.Append("," + customer.City);
                if (customer.PinCode != "NA") sb.Append("," + customer.PinCode);
                sb.Append("," + dBConnection.states.SingleOrDefault(m => m.ID == customer.State).Name);
                sb.Append(","+ dBConnection.countries.SingleOrDefault(m => m.ID == customer.Country).Name);
                if (sb[0] == ',') sb[0] = ' ';
                CustomerAddress.InnerHtml = sb.ToString();

                CustomerName.InnerText = customer.FirstName + " " + customer.LastName;
                Date.InnerText =(Session["invoice"] as Invoices).DateTime.ToString("dd MMM yyyy");
                paid.InnerText =(Session["invoice"] as Invoices).Paid + "";
                Time.InnerText =(Session["invoice"] as Invoices).DateTime.ToString("hh:mm tt");
                lblDiscount.InnerText =(Session["invoice"] as Invoices).Discount + "";
                lblFinalPrice.InnerText = (Session["invoice"] as Invoices).FinalPrice+"";
                lblGrandTotal.InnerText =(Session["invoice"] as Invoices).Discount +(Session["invoice"] as Invoices).FinalPrice+"";
                long id = (long)Session["InvoiceId"];
                Session["jobsList"]  = dBConnection.jobs.Where(m => m.Invoice == Convert.ToInt32((long)Session["InvoiceId"]));
            }
            else
            {
                paid.InnerText = "";
                due.InnerText = "";
                Session["jobsList"]  = new List<Jobs>();
            }
            InvoiceGrid.DataSource = (Session["jobsList"] as List<Jobs>);
            InvoiceGrid.DataBind();
        }

        protected void InvoiceGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                {
                    (e.Row.FindControl("Number") as Label).Text = e.Row.RowIndex + 1 + ".";
                    (e.Row.FindControl("invoiceProduct") as Label).Text = dBConnection.products.SingleOrDefault(m=>m.ID==(Session["jobsList"] as List<Jobs>).ElementAt(e.Row.RowIndex).Product).Name;
                    (e.Row.FindControl("invoiceProductType") as Label).Text = dBConnection.productTypes.SingleOrDefault(m => m.ID == (Session["jobsList"] as List<Jobs>).ElementAt(e.Row.RowIndex).ProductType).Type;
                    (e.Row.FindControl("invoiceProductSize") as Label).Text = dBConnection.sizes.SingleOrDefault(m => m.ID == (Session["jobsList"] as List<Jobs>).ElementAt(e.Row.RowIndex).ProductSize).Size;
                }
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                int totalQuantity = 0;
                float totalPrice = 0;
                foreach (Jobs job in (Session["jobsList"] as List<Jobs>))
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

                //Session["invoice"].FinalPrice = totalPrice;//Uncomment this if you want gst + totalPrice * 0.18f;
                //finalPrice.InnerText =(Session["invoice"] as Invoices).FinalPrice + "";
            }
        }

        protected void paid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                return;
                //string str = Regex.Replace(Paid.InnerText, @"\s+", "").Trim();
                string str = StaticFunctions.getValidString(paid.InnerText, false, false);

                if (str != "")
                {
                    Invoices updatedInvoice = new Invoices();
                    if (Session["invoice"] != null)
                    {
                        updatedInvoice =(Session["invoice"] as Invoices);
                        updatedInvoice.Paid = (float)Convert.ToDecimal(paid.InnerText);
                        dBConnection.Entry<Invoices>(dBConnection.invoices.Find(Convert.ToInt32((Session["invoice"] as Invoices).ID))).CurrentValues.SetValues(updatedInvoice);
                        dBConnection.SaveChanges();
                        

                        Session["jobsList"]  = dBConnection.jobs.Where(m => m.Invoice == Convert.ToInt32((Session["invoice"] as Invoices).ID)); 
                        InvoiceGrid.DataSource = (Session["jobsList"] as List<Jobs>);
                        InvoiceGrid.DataBind();
                    }
                }
                else
                {
                    //ServerMessage.InnerText = "Error:Invalid input...";
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            Response.Redirect("PrintInvoice");
        }
    }
}