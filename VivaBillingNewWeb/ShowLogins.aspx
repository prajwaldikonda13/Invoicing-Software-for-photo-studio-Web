<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ShowLogins.aspx.cs" Inherits="VivaBillingNewWeb.ShowLogins" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:GridView runat="server" ID="gridLogins" OnRowDataBound="gridLogins_RowDataBound" AutoGenerateColumns="false" CssClass="table table-striped">
        <Columns>
            <asp:TemplateField HeaderText="ID">
                <ItemTemplate>
                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="IP Address">
                <ItemTemplate>
                    <asp:Label ID="lblIP" runat="server" Text='<%# Eval("IP") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Login Date Time">
                <ItemTemplate>
                    <asp:Label ID="lblLoginTime" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Logout Date Time">
                <ItemTemplate>
                    <asp:Label ID="lblLogoutTime" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div runat="server" id="ServerMessage"></div>
</asp:Content>