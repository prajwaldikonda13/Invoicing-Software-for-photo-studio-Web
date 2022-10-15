using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using VivaBillingNewWeb.Database;

namespace VivaBillingNewWeb
{
    public partial class InvoiceForm : System.Web.UI.Page
    {
        DBConnection dBConnection = new DBConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {

                    ServerMessage.InnerText = "";

                    if (Session["InvoiceFormSaved"] != null)
                        return;
                    Session["selectedCustomer"] = (Customers)Session["MainSelectedCustomer"];
                    Session["balance"]  = (Session["selectedCustomer"] as Customers).Balance ;
                    if ((Session["selectedCustomer"] as Customers).Balance  >= 0)
                    {
                        lblPrevDue.InnerText = "Prev Bal:";
                        PrevBal.Value = (Session["selectedCustomer"] as Customers).Balance  + "";
                    }
                    else
                    {
                        lblPrevDue.InnerText = "Prev Due:";
                        PrevBal.Value = -1 * (Session["selectedCustomer"] as Customers).Balance + "";
                    }
                    //Invoice = dBConnection.invoices.Where(m => m.customer == Session["selectedCustomer"].ID) ;
                    Session["jobsList"] = (List<Jobs>)Session["MainJobsList"];
                    Session["grandQuantity"]  = (float)Session["MainGrandQuantity"];
                    Session["grandTotal"]  = (float)Session["MainGrandTotal"];
                    Session["temp"]  =(float) Session["grandTotal"] ;
                    Session["grandTotal"]  =(float) Session["grandTotal"]  - (float)Session["balance"] ;
                    if((float)Session["grandTotal"] <0)
                    {
                        Session["balance"]  = -1 *(float) Session["grandTotal"] ;
                        Session["grandTotal"]  = 0.0f;
                    }
                    //Invoices invoice = dBConnection.invoices.Where(m => m.ID == jobsList[0].Invoice);
                    //if (invoice != null)
                    //{
                    //    paid.Text = invoice.Paid + "";
                    //    if (Session["selectedCustomer"].Session["balance"]  > 0)
                    //        due.Value ="Session["balance"] :"+ Session["selectedCustomer"].Session["balance"] ;
                    //    else
                    //        due.Value = "Due:"+(invoice.FinalPrice - invoice.Paid) ;

                    //    ID.InnerText =invoice.ID+"";
                    //    InvoiceDate.InnerText = invoice.DateTime.ToString("dd MMM yyyy");
                    //    InvoiceTime.InnerText = invoice.DateTime.ToString("hh:mm tt");
                    //}
                    

                    txtDiscount.Text = "0";
                    Session["discountedPrice"]  =(float) Session["grandTotal"] ;
                    lblGrandTotal.InnerText = Session["grandTotal"]  + "";
                    finalPrice.InnerText = Session["discountedPrice"]  + "";
                    if((float)Session["balance"] >=0)
                    {
                        DueLabel.InnerText = "Balance:";
                        due.Value =Session["balance"] +"";

                    }
                    else
                    {
                        DueLabel.InnerText = "Due:";
                        due.Value = -1 * (float)Session["balance"]  +"";

                    }

                    paid.Text = "0";
                    InvoiceGrid.DataSource = (Session["jobsList"] as List<Jobs>).Where(m => m.UnitPrice > 0);
                    InvoiceGrid.DataBind();


                }
                catch (Exception ex)
                {
                    ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
                }
            }
            if (Session["selectedCustomer"] != null)
            {
                //CustomerName.InnerText = "Customer Name:" + Session["selectedCustomer"].FirstName + " " + Session["selectedCustomer"].LastName + "," + Session["selectedCustomer"].FirmName;
                //filter.Visible = false;
                //customers.Visible = false;

                InvoiceName.InnerText = (Session["selectedCustomer"] as Customers).FirstName + " " + (Session["selectedCustomer"] as Customers).LastName;
                InvoiceFirm.InnerText = (Session["selectedCustomer"] as Customers).FirmName;
                InvoiceMobile.InnerText = (Session["selectedCustomer"] as Customers).MobileNumber;
                InvoiceEmail.InnerText = (Session["selectedCustomer"] as Customers).EmailId;
                InvoiceAddress.InnerText = (Session["selectedCustomer"] as Customers).Flat + "," + (Session["selectedCustomer"] as Customers).Colony + "," + (Session["selectedCustomer"] as Customers).Landmark + "," + (Session["selectedCustomer"] as Customers).City + "," +( Session["selectedCustomer"] as Customers).PinCode + "," + dBConnection.states.SingleOrDefault(m => m.ID == (Session["selectedCustomer"] as Customers).State).Name + "," + dBConnection.countries.SingleOrDefault(m => m.ID == (Session["selectedCustomer"] as Customers).Country).Name;



                
            }
        }
        protected void InvoiceGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                ServerMessage.InnerText = "";

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if ((Session["jobsList"] as List<Jobs>).ElementAt(e.Row.RowIndex).Product > 0 && (Session["jobsList"] as List<Jobs>).ElementAt(e.Row.RowIndex).ProductType > 0 && (Session["jobsList"] as List<Jobs>).ElementAt(e.Row.RowIndex).ProductSize > 0)
                    {
                        (e.Row.FindControl("Number") as Label).Text = e.Row.RowIndex + 1 + ".";
                        (e.Row.FindControl("invoiceProduct") as Label).Text = dBConnection.products.SingleOrDefault(m=>m.ID==(Session["jobsList"] as List<Jobs>).ElementAt(e.Row.RowIndex).Product).Name;
                        (e.Row.FindControl("invoiceProductType") as Label).Text = dBConnection.productTypes.SingleOrDefault(m=>m.ID==(Session["jobsList"] as List<Jobs>).ElementAt(e.Row.RowIndex).ProductType).Type;
                        (e.Row.FindControl("invoiceProductSize") as Label).Text = dBConnection.sizes.SingleOrDefault(m=>m.ID==(Session["jobsList"] as List<Jobs>).ElementAt(e.Row.RowIndex).ProductSize).Size;
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
                    lblTotalPrice.Text = "" + totalPrice;
                    //Session["grandQuantity"]  = Convert.ToInt32(totalQuantity);
                    //Session["grandTotal"]  = Convert.ToInt32(totalPrice);
                    //Session["grandTotal"]  = totalPrice;//Uncomment this if you want price with GST + totalPrice * 0.18f;
                    //Session["temp"]  = Session["grandTotal"] ;
                    //if (Session["selectedCustomer"].Session["balance"]  >= 0)
                    //{
                    //    if (Session["selectedCustomer"].Session["balance"]  <= Session["grandTotal"] )
                    //    {
                    //        Session["grandTotal"]  = Session["grandTotal"]  - Session["selectedCustomer"].Session["balance"] ;
                    //        Session["balance"]  = 0;
                    //    }
                    //    else
                    //    {
                    //        Session["grandTotal"]  = 0;
                    //        Session["balance"]  -= Session["grandTotal"] ;
                    //    }
                    //}
                    //else
                    //{
                    //    Session["grandTotal"]  = Session["grandTotal"]  - Session["selectedCustomer"].Session["balance"] ;
                    //}

                  
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
                //Session["selectedCustomer"] = dBConnection.customers.Where(m => m.ID == ((Customers)Session["MainSelectedCustomer"]).ID);
                float currentPaid = (float)Convert.ToDecimal(paid.Text);
                //Session["discountedPrice"]  = Session["grandTotal"] ;
                string tempStr;
                if ((tempStr = txtDiscount.Text).Contains("%"))
                {
                    tempStr = tempStr.Replace("%", "");
                    Session["discount"]  = (float)Convert.ToDouble(tempStr) * (float)Session["grandTotal"]  / 100;

                }
                else
                    Session["discount"]  = (float)Convert.ToDouble((txtDiscount as TextBox).Text);
                if ((float)Session["discount"]  > (float)Session["grandTotal"]  || (float)Session["discount"]  < 0)
                {
                    Session["discountedPrice"]  = (float)Session["grandTotal"] ;
                    txtDiscount.Text = "0";
                }
                else
                { Session["discountedPrice"]  = (float)Session["grandTotal"]  - (float)Session["discount"] ;txtDiscount.Text = Session["discount"] +""; }
                if (currentPaid < 0)
                {
                    currentPaid = 0;
                    ServerMessage.InnerText = "Paid value can't be negative...";
                    (sender as TextBox).Text = "0";
                }
                if (currentPaid >=(float) Session["discountedPrice"] )
                {
                    DueLabel.InnerText = "Balance:";
                    if ((float)Session["grandTotal"]  != 0)
                        Session["balance"]  = currentPaid - (float)Session["discountedPrice"] ;
                    else
                        Session["balance"]  = (Session["selectedCustomer"] as Customers).Balance  + currentPaid -(float) Session["temp"] ;
                    due.Value = Session["balance"]  + "";
                    //Session["balance"]  = currentPaid + Session["selectedCustomer"].Session["balance"]  - Session["temp"] ;
                }
                else
                {
                    DueLabel.InnerText = "Due:";
                    due.Value = (float)Session["discountedPrice"]  - currentPaid + "";
                    Session["balance"]  = -1 * ((float)Session["discountedPrice"]  - currentPaid);
                }

                finalPrice.InnerText = Session["discountedPrice"]  + "";
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
        }
        protected void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                //(sender as Button).Visible = false;
                ServerMessage.InnerText = "";

                Session["selectedCustomer"] =(Customers)Session["MainSelectedCustomer"];
                if (Session["selectedCustomer"] != null)
                {
                    float currentPaid = (float)Convert.ToDecimal(paid.Text);
                    if (currentPaid < 0)
                    {
                        ServerMessage.InnerText = "Paid amount can't be negative....";
                        return;
                    }
                    
                    //dBConnection.SaveChanges();

                    if (currentPaid >= (float)Session["discountedPrice"] )
                    {
                        //float diff = 0;
                        //balance = currentPaid + Session["selectedCustomer"].Balance - Session["temp"] ;
                        //updatedCustomer.Balance += diff;
                        //currentPaid = Session["grandTotal"] ;
                    }
                    else
                    {
                       // balance = -1 * (Session["grandTotal"]  - currentPaid);
                    }
                    // balance = currentPaid + Session["selectedCustomer"].Balance - Session["temp"] ;

                    string date = InvoiceDate.Text;
                    DateTime dt;
                    if (date != "")
                    {
                        dt = Convert.ToDateTime(date).AddHours(12);
                    }
                    else
                    {
                        dt = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, Site1.INDIAN_ZONE);
                    }



                    
                    DailyCount originalCount = dBConnection.dailyCount.SingleOrDefault(m => m.dateTime.ToShortDateString() == dt.ToShortDateString());
                    if (originalCount == null)
                    {
                        dBConnection.dailyCount.Add(new DailyCount { dateTime = dt, Count = 0 });
                        dBConnection.SaveChanges();
                        
                        originalCount = dBConnection.dailyCount.SingleOrDefault(m => m.dateTime.ToShortDateString() == dt.ToShortDateString());
                    }
                    DailyCount updatedCount = originalCount;
                    updatedCount.Count += currentPaid;

                    float tempPrevBal = (Session["selectedCustomer"] as Customers).Balance;
                    Customers updatedCustomer = (Session["selectedCustomer"] as Customers);
                    updatedCustomer.Balance = (float)Session["balance"];
                    Invoices invoice = new Invoices { DateTime = dt, Paid = currentPaid, FinalPrice = (float)Session["discountedPrice"], customer = (Session["selectedCustomer"] as Customers).ID, PrevBal = tempPrevBal, CurrentBal = (float)Session["balance"], Discount = (float)Session["discount"] };
                    var cust = Session["selectedCustomer"] as Customers;
                    dBConnection.Entry(dBConnection.customers.Find(cust.ID)).CurrentValues.SetValues(updatedCustomer);
                    dBConnection.Entry(dBConnection.dailyCount.Find(originalCount.ID)).CurrentValues.SetValues(updatedCount);
                    dBConnection.invoices.Add(invoice);
                    dBConnection.SaveChanges();
                    
                    
                    

                    long invoiceId = dBConnection.invoices.LastOrDefault().ID;
                    foreach (Jobs job in (Session["jobsList"] as List<Jobs>))
                    {
                        if (job.Quantity > 0 && job.TotalPrice > 0 && job.UnitPrice > 0)
                        {
                            job.Invoice = invoiceId;
                            dBConnection.jobs.Add(job);
                        }
                    }
                    dBConnection.SaveChanges();
                    
                    ServerMessage.InnerHtml = "Invoice saved successfully.<a href='Main'>Go to main page</a> or <a href='PrintInvoice'>Print Ivoice</a>";
                    Session["InvoiceFormSaved"] = true;
                    btnSave.Visible = false;
                    Session["selectedCustomer"] = null;
                    //Response.Redirect("Main");
                }
                else
                {
                    ServerMessage.InnerText = "Please select the customer from main page first.";
                }
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
        }

        protected void txtDiscount_TextChanged(object sender, EventArgs e)
        {
          
        }
    }
}