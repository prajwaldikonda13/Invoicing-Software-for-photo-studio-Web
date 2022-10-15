using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using VivaBillingNewWeb.Database;

namespace VivaBillingNewWeb
{
    public partial class Main : System.Web.UI.Page
    {
        DBConnection dBConnection = new DBConnection();
        static float grandQuantity = 0;
        static float grandTotal = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    ServerMessage.InnerText = "";
                    if (Session["jobsList"] == null)
                        Session["jobsList"] = new List<Jobs>();
                    if (Session["InvoiceFormSaved"] != null)
                    {
                        Session["jobsList"]=new List<Jobs>();//Fo making Ienumerable empty
                        Session["InvoiceFormSaved"] = null;
                        Session["selectedCustomer"] = null;
                    }
                    if (Session["selectedCustomer"] != null)
                    {

                        if ((Session["selectedCustomer"] as Customers).Balance >= 0)
                            BalanceOrDue.InnerText = "Balance:" + (Session["selectedCustomer"] as Customers).Balance;
                        else
                        {
                            BalanceOrDue.InnerText = "Due:" + -1 * (Session["selectedCustomer"] as Customers).Balance;
                        }
                        CustomerName.InnerText = "Customer Name:" + (Session["selectedCustomer"] as Customers).FirstName + " " + (Session["selectedCustomer"] as Customers).LastName + "," + (Session["selectedCustomer"] as Customers).FirmName + "," + (Session["selectedCustomer"] as Customers).MobileNumber + "," + (Session["selectedCustomer"] as Customers).EmailId;
                        filter.Visible = false;
                        customers.Visible = false;
                        BtnChange.Visible = true;
                    }

                    bindCountries();
                    bindStates();
                    if ((Session["jobsList"] as List<Jobs>).Count() == 0)
                        bindJobGrid(true);
                    else if ((Session["jobsList"] as List<Jobs>).Count ()> 0)
                    {
                        if ((Session["jobsList"] as List<Jobs>).ElementAt((Session["jobsList"] as List<Jobs>).Count() - 1).UnitPrice > 0)
                            bindJobGrid(true);
                        else
                            bindJobGrid(false);

                    }
                }
                catch (Exception ex)
                {
                    ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
                }
            }
        }

        public void bindJobGrid(bool add)
        {
            try
            {
                ServerMessage.InnerText = "";

                if (add)
                    Session["jobsList"]=(Session["jobsList"] as List<Jobs>).Concat(new List<Jobs>() { new Jobs { Product = 0, ProductSize = 0, ProductType = 0, Quantity = 0, TotalPrice = 0.0f, UnitPrice = 0.0f, Status = "US" } });
                jobsGrid.DataSource = Session["jobsList"] as List<Jobs>;
                jobsGrid.DataBind();
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
        }
        private void bindStates()
        {
            
        }
        private void bindCountries()
        {
        }
        protected void products_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ServerMessage.InnerText = "";

                DropDownList products = sender as DropDownList;
                int rowIndex = ((GridViewRow)products.NamingContainer).RowIndex;
                string selectedText = products.Items[products.SelectedIndex].Text;
                (Session["jobsList"] as List<Jobs>).ElementAt(rowIndex).Product = dBConnection.products.SingleOrDefault(m => m.Name == selectedText).ID;
                (Session["jobsList"] as List<Jobs>).ElementAt(rowIndex).Quantity = 0.0f;
                bindJobGrid(false);
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
        }

        protected void productTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ServerMessage.InnerText = "";

                DropDownList productTypes = sender as DropDownList;
                string productType = productTypes.Items[productTypes.SelectedIndex].Text;
                int rowIndex = ((GridViewRow)productTypes.NamingContainer).RowIndex;
                (Session["jobsList"] as List<Jobs>).ElementAt(rowIndex).ProductType = dBConnection.productTypes.SingleOrDefault(m => m.Type == productType).ID;
                bindJobGrid(false);
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
        }

        protected void sizes_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                ServerMessage.InnerText = "";

                DropDownList sizes = sender as DropDownList;
                int rowIndex = ((GridViewRow)sizes.NamingContainer).RowIndex;
                (Session["jobsList"] as List<Jobs>).ElementAt(rowIndex).ProductSize = Convert.ToInt32(sizes.Items[sizes.SelectedIndex].Value);
                bindJobGrid(false);
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
        }

        protected void quantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ServerMessage.InnerText = "";

                TextBox quantity = sender as TextBox;
                int rowIndex = (quantity.NamingContainer as GridViewRow).RowIndex;
                DropDownList products = quantity.NamingContainer.FindControl("products") as DropDownList;
                DropDownList types = quantity.NamingContainer.FindControl("productTypes") as DropDownList;
                DropDownList sizes = quantity.NamingContainer.FindControl("productSizes") as DropDownList;

                if (products.SelectedIndex > 0 && types.SelectedIndex > 0 && sizes.SelectedIndex > 0)
                {
                    if ((float)Convert.ToDecimal(quantity.Text) < 1)
                    {
                        quantity.Text = "0";
                        (Session["jobsList"] as List<Jobs>).ElementAt(rowIndex).Quantity = 0;
                    }
                    else
                        (Session["jobsList"] as List<Jobs>).ElementAt(rowIndex).Quantity = (float)Convert.ToDecimal(quantity.Text);
                }
                else
                {
                   
                }
                bindJobGrid(false);
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
        }

        protected void filter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ServerMessage.InnerText = "";


                
                
                Session["customersList"] = dBConnection.customers.Where(m => m.FirmName.ToLower().Contains(filter.Text.ToLower()) || m.FirstName.ToLower().Contains(filter.Text.ToLower()) || m.LastName.ToLower().Contains(filter.Text.ToLower()) || m.MobileNumber.Contains(filter.Text));

                customers.DataSource = Session["customersList"];
                if ((Session["customersList"] as List<Customers>).Count() == 0)
                    ServerMessage.InnerHtml = "No customer found <a  href='CustomerRegistration'>Register customer</a>";
                else
                    ServerMessage.InnerHtml = "";
                customers.DataBind();
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            
            try
            {
                ServerMessage.InnerText = "";

                if ((Session["jobsList"] as List<Jobs>).ElementAt((Session["jobsList"] as List<Jobs>).Count() - 1).UnitPrice > 0)
                    bindJobGrid(true);
                else
                    bindJobGrid(false);
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
        }

        protected void jobsGrid_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            try
            {
                ServerMessage.InnerText = "";

                int rowIndex = e.Row.RowIndex;
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DropDownList products = e.Row.FindControl("products") as DropDownList;
                    DropDownList sizes = e.Row.FindControl("productSizes") as DropDownList;
                    DropDownList types = e.Row.FindControl("productTypes") as DropDownList;
                    TextBox unitPrice = e.Row.FindControl("unitPrice") as TextBox;
                    TextBox totalPrice = e.Row.FindControl("totalPrice") as TextBox;
                    TextBox quantity = e.Row.FindControl("quantity") as TextBox;
                    products.DataSource = dBConnection.products.ToList();
                    products.DataTextField = "Name";
                    products.DataValueField = "ID";
                    products.DataBind();
                    products.Items.Insert(0, new ListItem { Text = "Select product", Value = "0" });
                    products.SelectedIndex = products.Items.IndexOf(products.Items.FindByValue((Session["jobslist"] as List<Jobs>).ElementAt(rowIndex).Product + ""));
                    string productId = products.Items[products.SelectedIndex].Value;
                    string typeId = "";
                    List<Prices> pricesList = dBConnection.prices.Where(p => p.Product == Convert.ToInt32(productId)).ToList();
                    List<ProductTypes> listTypes = new List<ProductTypes>();
                    List<ProductTypes> productTypesList = dBConnection.productTypes.ToList();
                    for (int i = 0; i < productTypesList.Count(); i++)
                    {
                        for (int j = 0; j < pricesList.Count(); j++)
                        {
                            if (pricesList.ElementAt(j).ProductType == productTypesList.ElementAt(i).ID)
                            {
                                listTypes.Add(productTypesList[i]);
                                break;
                            }
                        }
                    }
                    types.DataSource = listTypes;
                    types.DataTextField = "Type";
                    types.DataValueField = "ID";
                    types.DataBind();
                    types.Items.Insert(0, new ListItem { Text = "Select type", Value = "0" });
                    types.SelectedIndex = types.Items.IndexOf(types.Items.FindByValue((Session["jobslist"] as List<Jobs>).ElementAt(rowIndex).ProductType + ""));
                    if (products.SelectedIndex > 0)
                        typeId = types.Items[types.SelectedIndex].Value;
                    string sizeId = "";
                    pricesList = pricesList.Where(p => p.ProductType == Convert.ToInt32(typeId)).ToList();
                    List<Sizes> listSizes = new List<Sizes>();
                    List<Sizes> productSizesList = dBConnection.sizes.ToList();
                    for (int i = 0; i < productSizesList.Count; i++)
                    {
                        for (int j = 0; j < pricesList.Count; j++)
                        {
                            if (pricesList.ElementAt(j).ProductSize == productSizesList.ElementAt(i).ID)
                            {
                                listSizes.Add(productSizesList[i]);
                                break;
                            }
                        }
                    }
                    sizes.DataSource = listSizes;
                    sizes.DataTextField = "Size";
                    sizes.DataValueField = "ID";
                    sizes.DataBind();
                    sizes.Items.Insert(0, new ListItem { Text = "Select size", Value = "0" });
                    sizes.SelectedIndex = sizes.Items.IndexOf(sizes.Items.FindByValue((Session["jobslist"] as List<Jobs>).ElementAt(rowIndex).ProductSize + ""));
                    if (products.SelectedIndex > 0 && types.SelectedIndex > 0)
                        sizeId = sizes.Items[sizes.SelectedIndex].Value;
                    quantity.Text = (Session["jobslist"] as List<Jobs>).ElementAt(rowIndex).Quantity + "";
                    List<Prices> prices = dBConnection.prices.Where(p => p.Product == Convert.ToInt32(productId) && p.ProductType == Convert.ToInt32(typeId) && p.ProductSize == Convert.ToInt32(sizeId));
                    if (prices.Count() > 0)
                    {
                        if ((Session["selectedCustomer"] as Customers).CustomerType == "RC")
                            unitPrice.Text = prices.SingleOrDefault().RegularPrice + "";
                        else
                            unitPrice.Text = prices.SingleOrDefault().CounterPrice + "";
                        totalPrice.Text = Convert.ToInt32(quantity.Text) * Convert.ToInt32(unitPrice.Text) + "";
                        (Session["jobslist"] as List<Jobs>).ElementAt(rowIndex).UnitPrice = (float)Convert.ToDecimal(unitPrice.Text);
                        (Session["jobslist"] as List<Jobs>).ElementAt(rowIndex).TotalPrice = (float)Convert.ToDecimal(totalPrice.Text);
                        grandQuantity += Convert.ToInt32(quantity.Text);
                        grandTotal += Convert.ToInt32(totalPrice.Text);
                    }
                    else
                    {
                       
                        (Session["jobslist"] as List<Jobs>).ElementAt(rowIndex).UnitPrice = 0.0f;
                        (Session["jobslist"] as List<Jobs>).ElementAt(rowIndex).TotalPrice = 0.0f;
                        grandQuantity += 0;
                        grandTotal += 0;
                    }
                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    int totalQuantity = 0;
                    int totalPrice = 0;
                    foreach (Jobs job in (Session["jobsList"] as List<Jobs>))
                    {
                        if (job.Product > 0 && job.ProductSize > 0 && job.ProductType > 0)
                        {
                            totalQuantity += Convert.ToInt32(job.Quantity);
                            totalPrice += Convert.ToInt32(job.TotalPrice);
                        }
                    }
                    Label lblTotalQuantity = e.Row.FindControl("grandQuantity") as Label;
                    Label lblTotalPrice = e.Row.FindControl("grandTotal") as Label;
                    lblTotalQuantity.Text = "" + totalQuantity;
                    lblTotalPrice.Text = "" + totalPrice;
                    grandQuantity = Convert.ToInt32(totalQuantity);
                    grandTotal = Convert.ToInt32(totalPrice);
                }
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
        }

        protected void jobsGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                ServerMessage.InnerText = "";

                int rowIndex = e.RowIndex;
                if ((Session["jobsList"] as List<Jobs>).Count() > 1)
                {
                    List<Jobs> k = Session["jobsList"] as List<Jobs>;
                    Jobs ele = k.ElementAt(rowIndex);
                    Session["jobsList"]=k.Where(m=>!m.Equals(ele));
                    bindJobGrid(false);
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
        }
        protected void SelectButton_Click(object sender, EventArgs e)
        {
            try
            {
                ServerMessage.InnerText = "";
                int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;
                Session["selectedCustomer"] = (Session["customersList"] as List<Customers>).ElementAt(rowIndex);
                Session["MainSelectedCustomer"] = Session["selectedCustomer"];
                if (Session["selectedCustomer"] != null)
                {
                    StringBuilder sb = new StringBuilder("Customer:");
                    sb.Append((Session["selectedCustomer"] as Customers).FirstName);
                    sb.Append(" ");
                    sb.Append((Session["selectedCustomer"] as Customers).LastName);
                    if ((Session["selectedCustomer"] as Customers).FirmName != "NA") sb.Append("," + (Session["selectedCustomer"] as Customers).FirmName);
                    if ((Session["selectedCustomer"] as Customers).MobileNumber != "NA") sb.Append("," + (Session["selectedCustomer"] as Customers).MobileNumber);
                    if ((Session["selectedCustomer"] as Customers).EmailId != "NA") sb.Append("," + (Session["selectedCustomer"] as Customers).EmailId);
                    sb.Append("," +( Session["selectedCustomer"] as Customers).CustomerType);
                    CustomerName.InnerText = sb.ToString();
                    if ((Session["selectedCustomer"] as Customers).Balance >= 0)
                        BalanceOrDue.InnerText = "Balance:" + (Session["selectedCustomer"] as Customers).Balance;
                    else
                    {
                        BalanceOrDue.InnerText = "Due:" + -1 * (Session["selectedCustomer"] as Customers).Balance;
                    }
                    filter.Visible = false;
                    customers.Visible = false;
                    BtnChange.Visible = true;
                    bindJobGrid(false);
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
        }

        protected void InvoiceGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
           
        }

        protected void paid_TextChanged(object sender, EventArgs e)
        {
        }

        protected void ShowInvoiceBtn_Click(object sender, EventArgs e)
        {
            try
            {
                ServerMessage.InnerText = "";

                if (Session["selectedCustomer"] != null)
                {
                    if ((Session["jobslist"] as List<Jobs>).ElementAt(0).Product > 0 && (Session["jobslist"] as List<Jobs>).ElementAt(0).ProductType > 0 && (Session["jobslist"] as List<Jobs>).ElementAt(0).ProductSize > 0 && (Session["jobslist"] as List<Jobs>).ElementAt(0).UnitPrice > 0)
                    {
                        Session["MainJobsList"] = Session["jobsList"];
                        Session["MainGrandQuantity"] = grandQuantity;
                        Session["MainGrandTotal"] = grandTotal;
                        Response.Redirect("InvoiceForm.aspx");
                    }
                    else
                    {
                        ServerMessage.InnerText = "Please make sure that there is atleast one item in your joblist.";
                    }
                }
                else
                {
                    ServerMessage.InnerText = "Please select the customer first to proceed.";
                }
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
        }

        protected void BtnChange_Click(object sender, EventArgs e)
        {
            Session["selectedCustomer"] = null;
            Session["selectedCustomer"] = null;
            CustomerName.InnerText = "";
            filter.Visible = true;
            customers.Visible = true;
            BtnChange.Visible = false;
        }
    }
}