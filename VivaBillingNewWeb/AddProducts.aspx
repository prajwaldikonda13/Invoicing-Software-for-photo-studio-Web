<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddProducts.aspx.cs" Inherits="VivaBillingNewWeb.AddProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:GridView runat="server" ID="grid" CssClass="table table-striped" AutoGenerateColumns="false" OnRowEditing="grid_RowEditing" OnRowUpdating="grid_RowUpdating" OnRowDeleting="grid_RowDeleting" OnRowCancelingEdit="grid_RowCancelingEdit">
            <Columns>
                <asp:CommandField ShowCancelButton="true" FooterText="footer" ControlStyle-CssClass="btn btn-dark" ShowDeleteButton="true" HeaderText="hi" ButtonType="Button" ShowEditButton="true" ShowHeader="true" />
                <asp:TemplateField HeaderText="ID">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblID" Text='<%#Eval("ID") %>'></asp:Label>
                    </ItemTemplate>
                    <%--<EditItemTemplate>
                        <asp:TextBox runat="server" ID="txtId"  Text='<%#Eval("EmailId") %>'></asp:TextBox>
                    </EditItemTemplate>--%>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblName" Text='<%#Eval("Name") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="txtName" Text='<%#Eval("Name") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
      
        
        
       
             

        <div class="input-group mb-3">
                       <input class="form-control" type="text" runat="server" id="name" />
            <div class="input-group-append">
                   <asp:Button runat="server" CssClass="btn btn-primary form-control" ID="Add" OnClick="Add_Click" Text="Add product" />
                
            </div>
        </div>

        <div runat="server" id="ServerMessage"></div>
</asp:Content>

    
