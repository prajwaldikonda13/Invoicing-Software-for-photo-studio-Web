using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI.WebControls;
using VivaBillingNewWeb.Database;

namespace VivaBillingNewWeb
{
    public partial class Today : System.Web.UI.Page
    {
        DBConnection dBConnection = new DBConnection();
        List<Invoices> InvoicesList = new List<Invoices>();
        float totalDueToday;
        float grandTotalToday;
        float totalDiscountToday;
        float totalToday;
        float totalPaidToday;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ServerMessage.InnerText = "";
                count.InnerText = "......Cash Count:" + dBConnection.dailyCount.SingleOrDefault(m => m.dateTime.ToString("dd MMM yyyy") == TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, Site1.INDIAN_ZONE).ToString("dd MMM yyyy")).Count;
                heading.InnerText = "Invoices for date:" + TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow,Site1.INDIAN_ZONE).ToString("dd MMM yyyy");
                InvoicesList = dBConnection.invoices.Where(m => m.DateTime.ToString("dd MMM yyyy") == TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, Site1.INDIAN_ZONE).ToString("dd MMM yyyy"));
                InvoicesGrid.DataSource = InvoicesList;
                InvoicesGrid.DataBind();
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
        }
        protected void InvoicesGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                Customers customer = null;
                Label customerName = e.Row.FindControl("lblCustomerName") as Label;
                Label time = e.Row.FindControl("lblTime") as Label;
                Label date = e.Row.FindControl("lblDate") as Label;
                Label due = e.Row.FindControl("lblDue") as Label;
                Label invoiceTotal = e.Row.FindControl("Total") as Label;
                Label grandTotal = e.Row.FindControl("lblGrandTotal") as Label;
                Label discount = e.Row.FindControl("lblDiscount") as Label;
                Label currentbal = e.Row.FindControl("CurrentBal") as Label;
                Label PrevBal = e.Row.FindControl("PrevBal") as Label;
                int rowIndex = e.Row.RowIndex;
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    customer = dBConnection.customers.SingleOrDefault(m => m.ID == InvoicesList.ElementAt(e.Row.RowIndex).customer);
                    
                    if (customer != null)
                    {
                        customerName.Text = customer.FirstName + " " + customer.LastName + "," + customer.FirmName;
                    }
                    time.Text = InvoicesList.ElementAt(rowIndex).DateTime.ToString("hh:mm tt");
                    date.Text = InvoicesList.ElementAt(rowIndex).DateTime.ToString("dd MMM yyyy");
                    due.Text = InvoicesList.ElementAt(rowIndex).FinalPrice - InvoicesList.ElementAt(rowIndex).Paid + "";

                    var diff = InvoicesList.ElementAt(rowIndex).FinalPrice - InvoicesList.ElementAt(rowIndex).Paid;
                    if (diff > 0)
                        totalDueToday += InvoicesList.ElementAt(rowIndex).FinalPrice - InvoicesList.ElementAt(rowIndex).Paid;


                    totalDiscountToday += InvoicesList.ElementAt(rowIndex).Discount;
                    totalPaidToday += InvoicesList.ElementAt(rowIndex).Paid;



                    float gt = InvoicesList.ElementAt(rowIndex).FinalPrice + InvoicesList.ElementAt(rowIndex).Discount;
                    grandTotalToday += gt;
                    float tempTotal;
                    if (gt != 0)
                        tempTotal = gt + InvoicesList.ElementAt(rowIndex).PrevBal ;
                    else
                        tempTotal = InvoicesList.ElementAt(rowIndex).Paid + InvoicesList.ElementAt(rowIndex).PrevBal - InvoicesList.ElementAt(rowIndex).CurrentBal;
                    invoiceTotal.Text = tempTotal+"";
                    totalToday += tempTotal;



                    var val = InvoicesList.ElementAt(rowIndex).FinalPrice - InvoicesList.ElementAt(rowIndex).Paid;
                    if (val < 0)
                        due.Text = "0";
                    else
                        due.Text = val + "";

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

                    discount.Text = InvoicesList.ElementAt(rowIndex).Discount+"";
                    grandTotal.Text = InvoicesList.ElementAt(rowIndex).FinalPrice + InvoicesList.ElementAt(rowIndex).Discount+ "";
                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    (e.Row.FindControl("lblTotalDueToday") as Label).Text = "Due:" + totalDueToday;
                    (e.Row.FindControl("lblGrandTotalToday") as Label).Text = "Grand:" + grandTotalToday;
                    (e.Row.FindControl("lblTotalDiscountToday") as Label).Text = "Discount:" + totalDiscountToday;
                    (e.Row.FindControl("lblTotalPaidToday") as Label).Text = "Paid:" + totalPaidToday;
                    (e.Row.FindControl("lblTotalToday") as Label).Text = "Total:" + totalToday;
                    totalDueToday = 0;
                    grandTotalToday = 0;
                    totalDiscountToday = 0;
                    totalPaidToday = 0;
                    totalToday = 0;
                }
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
        }

        protected void datePicker_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ServerMessage.InnerText = "";
                count.InnerText = "......Cash Count:" + dBConnection.dailyCount.SingleOrDefault(m => m.dateTime.ToString("dd MMM yyyy") == Convert.ToDateTime(datePicker.Text).ToString("dd MMM yyyy")).Count;
                heading.InnerText = "Invoices for date:" + Convert.ToDateTime(datePicker.Text).ToString("dd MMM yyyy");
                InvoicesList = dBConnection.invoices.Where(m => m.DateTime.ToString("dd MMM yyyy") == Convert.ToDateTime(datePicker.Text).ToString("dd MMM yyyy"));
                InvoicesGrid.DataSource = InvoicesList;
                InvoicesGrid.DataBind();
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
        }
    }
}