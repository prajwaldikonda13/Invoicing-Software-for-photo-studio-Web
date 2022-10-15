using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using VivaBillingNewWeb.Database;

namespace VivaBillingNewWeb
{
    public partial class AddProductType : System.Web.UI.Page
    {
        static List<ProductTypes> typeList;
        DBConnection dBConnection = new DBConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGridView();
                bindProducts();
            }
        }

        private void bindProducts()
        {
        }

        private void bindGridView()
        {
            try
            {
                ServerMessage.InnerText = "";

                typeList = dBConnection.productTypes.ToList();
                grid.DataSource = typeList;
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
                grid.DataSource = typeList;
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

                string str = StaticFunctions.getValidString(((TextBox)grid.Rows[e.RowIndex].FindControl("txtType")).Text, true, false);
                if (typeList.SingleOrDefault(m => m.Type == str) != null)
                {
                    ServerMessage.InnerText = "Given product type already exists.Please enter another name.";
                    return;
                }
                if (String.IsNullOrEmpty(str))
                {
                    ServerMessage.InnerText = "Input is empty.Please enter valid name.";
                    return;
                }
                var ele = typeList.SingleOrDefault(m => m.ID == typeList.ElementAt(e.RowIndex).ID);
                var entry = dBConnection.Entry(ele);
                if (entry.State == System.Data.Entity.EntityState.Detached)
                    dBConnection.productTypes.Attach(ele);
                ele.Type = str;
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

                var ele = typeList.SingleOrDefault(m => m.ID == typeList.ElementAt(e.RowIndex).ID);
                var entry = dBConnection.Entry(ele);
                if (entry.State == System.Data.Entity.EntityState.Detached)
                    dBConnection.productTypes.Attach(ele);
                dBConnection.productTypes.Remove(ele);
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
                grid.DataSource = typeList;
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

                string str = StaticFunctions.getValidString(ProductType.Value, true, false);
                if (typeList.SingleOrDefault(m => m.Type == str) != null)
                {
                    ServerMessage.InnerText = "Given product type already exists.Please enter another name.";
                    return;
                }
                if (String.IsNullOrEmpty(str))
                {
                    ServerMessage.InnerText = "Input is empty.Please enter valid name.";
                    return;
                }
                dBConnection.productTypes.Add(new ProductTypes { Type = str, /*Product = dBConnection.products.Where(p => p.ID == Convert.ToInt32(products.Items[products.SelectedIndex].Value)).ID*/ });
                dBConnection.SaveChanges();
                bindGridView();
                ServerMessage.InnerText = "";
            }
            catch (Exception ex)
            {
                ServerMessage.InnerText = "Exception:" + ex.Message;
            }
        }
    }
}