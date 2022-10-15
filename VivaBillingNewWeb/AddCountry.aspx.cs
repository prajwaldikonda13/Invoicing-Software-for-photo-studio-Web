using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.UI.WebControls;
using VivaBillingNewWeb.Database;

namespace VivaBillingNewWeb
{
    public partial class AddCountry : System.Web.UI.Page
    {
        static List<Countries> countryList;
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
                countryList = dBConnection.countries.ToList();
                grid.DataSource = countryList;
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
                grid.DataSource = countryList;
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

                string str= StaticFunctions.getValidString(((TextBox)grid.Rows[e.RowIndex].FindControl("txtSize")).Text, true, false);
                if(countryList.SingleOrDefault(m=>m.Name==str)!=null)
                {
                    ServerMessage.InnerText = "Country with given name already exists.Please provide another name.";
                    return;
                }
                var ele = countryList.ElementAt(e.RowIndex);
                var entry = dBConnection.Entry(ele);
                if (entry.State == EntityState.Detached)
                    dBConnection.countries.Attach(ele);
                ele.Name = str;
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
                var ele = countryList.SingleOrDefault(m => m.ID == countryList.ElementAt(e.RowIndex).ID);
                var entry = dBConnection.Entry(ele);
                if (entry.State == EntityState.Detached)
                    dBConnection.countries.Attach(ele);
                dBConnection.countries.Remove(ele);
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
                grid.DataSource = countryList;
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

                string str = StaticFunctions.ConvertToTitleCase(StaticFunctions.getValidString(country.Value, true, false));
                if(countryList.SingleOrDefault(m=>m.Name==str)!=null)
                {
                    ServerMessage.InnerText = "Country with given name already exists.";
                    return;
                }
                if (str != "")
                {
                    dBConnection.countries.Add(new Countries
                    {
                        Name = str
                    });
                    dBConnection.SaveChanges();
                    ServerMessage.InnerText = "";
                    bindGridView();
                }
                else
                {
                    ServerMessage.InnerText = "Error:Empty input...";

                }
            }
            catch (Exception ex)
            {
                ServerMessage.InnerHtml = "Exception:<br>Message=" + ex.Message + "<br>Data=:" + ex.Data + "<br>Helplink=" + ex.HelpLink + "<br>HResult=" + ex.HResult + "<br>InnerException=" + ex.InnerException + "<br>Source=" + ex.Source + "<br>StackTrace=" + ex.StackTrace + "<br>TargetSite" + ex.TargetSite;

            }
        }
    }
}