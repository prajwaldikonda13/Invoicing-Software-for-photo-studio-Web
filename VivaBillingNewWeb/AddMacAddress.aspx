<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddMacAddress.aspx.cs" Inherits="VivaBillingNewWeb.AddMacAddress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView runat="server" ID="macGrid" CssClass="table table-striped"></asp:GridView>
    <input type="text" runat="server" maxlength="12" id="mac" />
    <asp:Button runat="server" OnClick="Unnamed_Click" Text="Confirm and add" />
    <span runat="server" id="ServerMessage"></span>
</asp:Content>
