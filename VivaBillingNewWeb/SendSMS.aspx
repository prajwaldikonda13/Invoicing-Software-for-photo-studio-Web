<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SendSMS.aspx.cs" Inherits="VivaBillingNewWeb.SendSMS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style="display: table; height: 100vh; width: 100%;">
        <div style="display: table-cell; vertical-align: middle;">
        <asp:TextBox runat="server" TextMode="MultiLine" class="form-control" ID="txtMobile" placeholder="Mobile Number(Multiple mobile numbers can be seperated by comma ,)"></asp:TextBox>
    <%--<asp:TextBox runat="server" class="form-control" ID="txtSubject" placeholder="Subject"></asp:TextBox>--%>
    <asp:TextBox runat="server" TextMode="MultiLine" style="height:50vh;"  class="form-control" ID="txtBody" placeholder="Body"></asp:TextBox>
    <asp:Button runat="server" ID="btnSend" CssClass="btn btn-primary" Text="Send SMS" OnClick="btnSend_Click" />
         <div runat="server" id="ServerMessage"></div>
            </div>
         </div>
</asp:Content>
