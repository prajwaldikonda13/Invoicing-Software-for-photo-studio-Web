<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TruncateTables.aspx.cs" Inherits="VivaBillingNewWeb.TruncateTables" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:TextBox runat="server" ID="password" placeholder="Enter password"/>
        <asp:Button runat="server" ID="btn" OnClick="btn_Click"  Text="Confirm delete"/>
</asp:Content>
