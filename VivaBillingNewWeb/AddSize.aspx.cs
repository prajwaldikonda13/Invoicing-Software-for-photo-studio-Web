using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace VivaBillingNewWeb.Database
{
    public partial class AddSize : System.Web.UI.Page
    {
        static List<Sizes> sizeList;
        DBConnection dBConnection = new DBConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGridView();
                bindDropdowns();
            }
        }

        private void bindDropdowns()
        {
        }

        private void bindGridView()
        {
            try
            {
                ServerMessage.InnerText = "";
                sizeList = dBConnection.sizes;
                grid.DataSource = sizeList;
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
                grid.DataSource = sizeList;
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

                string str = StaticFunctions.getValidString(((TextBox)grid.Rows[e.RowIndex].FindControl("txtSize")).Text, false, false);
                if (sizeList.SingleOrDefault(m => m.Size == str) != null)
                {
                    ServerMessage.InnerText = "Error:Size already exists...";
                    return;
                }
                if (String.IsNullOrEmpty(str))
                {
                    ServerMessage.InnerText = "Error:Input is empty please enter valid size...";
                    return;
                }
                var ele = sizeList.SingleOrDefault(m => m.ID == sizeList.ElementAt(e.RowIndex).ID);
                var entry = dBConnection.Entry(ele);
                if (entry.State == System.Data.Entity.EntityState.Detached)
                    dBConnection.sizes.Attach(ele);
                ele.Size = str;
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

                var ele = sizeList.SingleOrDefault(m => m.ID == sizeList.ElementAt(e.RowIndex).ID);
                var entry = dBConnection.Entry(ele);
                if (entry.State == System.Data.Entity.EntityState.Detached)
                    dBConnection.sizes.Attach(ele);
                dBConnection.sizes.Remove(ele);
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
                grid.DataSource = sizeList;
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

                string str = StaticFunctions.getValidString(size.Value, false, false);
                if (sizeList.SingleOrDefault(m => m.Size == str) != null)
                {
                    ServerMessage.InnerText = "Error:Size already exists...";
                    return;
                }
                if (String.IsNullOrEmpty(str))
                {
                    ServerMessage.InnerText = "Error:Input is empty please enter valid size...";
                    return;
                }
                dBConnection.sizes.Add(new Sizes
                {
                    Size = str
                });
                dBConnection.SaveChanges();
                ServerMessage.InnerText = "";
                bindGridView();
            }
            catch (Exception ex)
            {
                ServerMessage.InnerText = "Exception:" + ex.Message;

            }
        }
    }
}