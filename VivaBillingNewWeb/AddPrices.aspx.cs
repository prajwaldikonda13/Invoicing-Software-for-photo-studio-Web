using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using VivaBillingNewWeb.Database;

namespace VivaBillingNewWeb
{
    public partial class AddPrices : System.Web.UI.Page
    {
        static List<Prices> pricesList;
        static List<Products> productsList;
        static List<ProductTypes> typesList;
        static List<Sizes>sizesList;
        DBConnection dBConnection = new DBConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    ServerMessage.InnerText = "";
                    productsList = dBConnection.products.ToList();
                    products.DataSource = productsList;
                    products.DataTextField = "Name";
                    products.DataValueField = "ID";
                    products.DataBind();
                    products.Items.Insert(0, new ListItem { Text = "Select product", Value = "0" });

                    typesList = dBConnection.productTypes.ToList();
                    productTypes.DataSource = typesList;
                    productTypes.DataTextField = "Type";
                    productTypes.DataValueField = "ID";
                    productTypes.DataBind();
                    productTypes.Items.Insert(0, new ListItem { Text = "Select type", Value = "0" });


                    sizesList = dBConnection.sizes.ToList();
                    productSizes.DataSource = sizesList;
                    productSizes.DataTextField = "Size";
                    productSizes.DataValueField = "ID";
                    productSizes.DataBind();
                    productSizes.Items.Insert(0, new ListItem { Text = "Select size", Value = "0" });
                    bindGridView();

                }
                catch (Exception ex)
                {
                    ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
                }

            }
        }
        private void bindGridView()
        {
            try
            {
                ServerMessage.InnerText = "";

                pricesList = dBConnection.prices.ToList();
                grid.DataSource = pricesList;
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
                grid.EditIndex = e.NewEditIndex;
                grid.DataSource = pricesList;
                grid.DataBind();
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
                
                float regularPrice = (float)Convert.ToDecimal(StaticFunctions.getValidString(((TextBox)grid.Rows[e.RowIndex].FindControl("txtRegularPrice")).Text, false, false));
                float counterPrice = (float)Convert.ToDecimal(StaticFunctions.getValidString(((TextBox)grid.Rows[e.RowIndex].FindControl("txtCounterPrice")).Text, false, false));
                if (regularPrice <= 0 || counterPrice <= 0)
                {
                    ServerMessage.InnerText = "Please enter valid prices.";
                    return;
                }

                var ele = pricesList.SingleOrDefault(m => m.ID == pricesList.ElementAt(e.RowIndex).ID);
                var entry = dBConnection.Entry(ele);
                if (entry.State == System.Data.Entity.EntityState.Detached)
                    dBConnection.prices.Attach(ele);
                ele.RegularPrice = regularPrice;
                ele.CounterPrice = counterPrice;
                dBConnection.SaveChanges();
                grid.EditIndex = -1;
                bindGridView();

            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
        }
       
        protected void grid_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            try
            {
                ServerMessage.InnerText = "";
                var ele = pricesList.SingleOrDefault(m => m.ID == pricesList.ElementAt(e.RowIndex).ID);
                var entry = dBConnection.Entry(ele);
                if (entry.State == System.Data.Entity.EntityState.Detached)
                    dBConnection.prices.Attach(ele);
                dBConnection.prices.Remove(ele);
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
                grid.EditIndex = -1;
                grid.DataSource = pricesList;
                grid.DataBind();
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
           
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            try
            {
                ServerMessage.InnerText = "";

                if (products.SelectedIndex > 0 && productTypes.SelectedIndex > 0 && productSizes.SelectedIndex > 0)
                {
                    Products product = productsList.SingleOrDefault(m => m.ID == productsList.ElementAt(products.SelectedIndex - 1).ID);
                    ProductTypes type = typesList.SingleOrDefault(m => m.ID == typesList.ElementAt(productTypes.SelectedIndex - 1).ID);
                    Sizes size = sizesList.SingleOrDefault(m => m.ID == sizesList.ElementAt(productSizes.SelectedIndex - 1).ID);
                    Prices price = pricesList.SingleOrDefault(m => m.Product == product.ID && m.ProductSize == size.ID && m.ProductType == type.ID);
                    if (price != null)
                    {
                        ServerMessage.InnerText = "Price for given combination already exists...";
                        return;

                    }
                    float regularPrice = (float)Convert.ToDecimal(txtRegularPrice.Value);
                    float counterPrice = (float)Convert.ToDecimal(txtCounterPrice.Value);
                    if (regularPrice <= 0 || counterPrice <= 0)
                    {
                        ServerMessage.InnerText = "Please enter valid prices.....";
                        return;
                    }
                    dBConnection.prices.Add(new Prices
                    {
                        Product = product.ID,
                        ProductSize = size.ID,
                        ProductType = type.ID,
                        RegularPrice = regularPrice,
                        CounterPrice = counterPrice
                    });
                    dBConnection.SaveChanges();


                    bindGridView();
                    ServerMessage.InnerText = "";
                }
                else
                {
                    ServerMessage.InnerText = "Please make a valid selection...";
                }
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
        }

        protected void products_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void productTypes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void productSizes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                ServerMessage.InnerText = "";

                int rowIndex = e.Row.RowIndex;
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label product =e.Row.FindControl("lblProduct") as Label;
                    Label productType = e.Row.FindControl("lblProductType") as Label;
                    Label size = e.Row.FindControl("lblProductSize") as Label;
                    product.Text = productsList.SingleOrDefault(m => m.ID == pricesList.ElementAt(rowIndex).Product).Name;
                    productType.Text = typesList.SingleOrDefault(m => m.ID == pricesList.ElementAt(rowIndex).ProductType).Type;
                    size.Text = sizesList.SingleOrDefault(m => m.ID == pricesList.ElementAt(rowIndex).ProductSize).Size;
                }
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }

        }
    }
}