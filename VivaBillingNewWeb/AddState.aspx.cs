using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using VivaBillingNewWeb.Database;

namespace VivaBillingNewWeb
{
    public partial class AddState : System.Web.UI.Page
    {
        static List<States> stateList;
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

                stateList = dBConnection.states;
                grid.DataSource = stateList;
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
                bindGridView();
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

                States old = stateList.ElementAt(e.RowIndex);
                States updated = old;
                updated.Name = StaticFunctions.getValidString(((TextBox)grid.Rows[e.RowIndex].FindControl("txtSize")).Text, false, false);
                if (updated.Name != "")
                {
                    States check = dBConnection.states.SingleOrDefault(m => m.Name == updated.Name);
                    if (check == null)
                    {
                        dBConnection.Entry(dBConnection.states.Find(old.ID)).CurrentValues.SetValues(updated);
                        dBConnection.SaveChanges();
                        

                        grid.EditIndex = -1;
                        bindGridView();
                    }
                    else
                    {
                        ServerMessage.InnerText = "Given state already exists....";
                    }
                }
                else
                {
                    ServerMessage.InnerText = "Error:state already exists...";
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
                ServerMessage.InnerText = "";

                dBConnection.states.Remove(dBConnection.states.SingleOrDefault(m=>m.ID==stateList.ElementAt(e.RowIndex).ID));
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
                bindGridView();
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

                string str = StaticFunctions.getValidString(state.Value, true, false);
                if (str != "" && str != " ")
                {
                    States states = dBConnection.states.SingleOrDefault(m => m.Name == str);
                    if (states == null)
                    {
                        dBConnection.states.Add(new States
                        { 
                            Name = str
                        });
                        dBConnection.SaveChanges();
                        

                        ServerMessage.InnerText = "";
                        bindGridView();
                    }
                    else
                    {
                        ServerMessage.InnerText = "Error:State already exists...";
                    }
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