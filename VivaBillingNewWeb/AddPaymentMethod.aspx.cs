using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace VivaBillingNewWeb.Database
{
    public partial class AddPaymentMethod : System.Web.UI.Page
    {
        static List<PaymentMethods> paymentMethodList;
        DBConnection dBConnection = new DBConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGridView();
            }
        }
        private void bindGridView()
        {
            try
            {
                ServerMessage.InnerText = "";
                paymentMethodList = dBConnection.paymentMethods.ToList();
                grid.DataSource = paymentMethodList;
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
                grid.DataSource = paymentMethodList;
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

                string str = StaticFunctions.getValidString(((TextBox)grid.Rows[e.RowIndex].FindControl("txtName")).Text, true, false);
                if(paymentMethodList.SingleOrDefault(m=>m.Name==str)!=null)
                {
                    ServerMessage.InnerText = "Error:Payment method already exists.....";
                    return;
                }

                if (str != "" && str != " ")
                {
                    var ele = paymentMethodList.SingleOrDefault(m => m.ID == paymentMethodList.ElementAt(e.RowIndex).ID);
                    var entry = dBConnection.Entry(ele);
                    if (entry.State == System.Data.Entity.EntityState.Detached)
                        dBConnection.paymentMethods.Attach(ele);
                    ele.Name = str;
                    dBConnection.SaveChanges();
                    grid.EditIndex = -1;
                    bindGridView();
                }
                else
                {
                    ServerMessage.InnerText = "Error:Input is empty...";
                }
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
                var ele = paymentMethodList.SingleOrDefault(m => m.ID == paymentMethodList.ElementAt(e.RowIndex).ID);
                var entry = dBConnection.Entry(ele);
                if (entry.State == System.Data.Entity.EntityState.Detached)
                    dBConnection.paymentMethods.Attach(ele);
                dBConnection.paymentMethods.Remove(ele);
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
                grid.EditIndex = -1;
                grid.DataSource = paymentMethodList;
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
                string str = StaticFunctions.getValidString(PaymentMethod.Value, true, false);
                if (paymentMethodList.SingleOrDefault(m => m.Name == str) != null)
                {
                    ServerMessage.InnerText = "Error:Payment method already exists.....";
                    return;
                }
               
                if ( str != "" && str != " ")
                {
                    dBConnection.paymentMethods.Add(new PaymentMethods { Name = str });
                    dBConnection.SaveChanges();
                    ServerMessage.InnerText = "";
                    bindGridView();
                }
                else
                {
                    ServerMessage.InnerText = "Error:Input is empty.....";
                }
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;
            }
            
        }
    }
}
