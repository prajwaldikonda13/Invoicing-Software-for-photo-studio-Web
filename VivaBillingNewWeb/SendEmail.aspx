<%@ Page Title="" Language="C#" Debug="true" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SendEmail.aspx.cs" Inherits="VivaBillingNewWeb.SendEmail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display: table; height: 100vh; width: 100%;">
        <div style="display: table-cell; vertical-align: middle;">
                <asp:TextBox runat="server" TextMode="MultiLine" class="form-control" ID="txtEmail" placeholder="Email Id(emails to multiple ids can be sent by seperating email ids by comma ,)"></asp:TextBox>
                <asp:TextBox runat="server" class="form-control" ID="txtSubject" placeholder="Subject"></asp:TextBox>
                <asp:TextBox runat="server" style="height:50vh;" TextMode="MultiLine" class="form-control" ID="txtBody" placeholder="Body"></asp:TextBox>
                <div>
                    Send using: 
        <asp:RadioButton runat="server" ID="SendByGmail" Text="gmail.com" GroupName="Selection" />
                    <asp:RadioButton runat="server" ID="SendByViva" Text="vivadigitals.com" Checked="true" GroupName="Selection" /><br />
                    <asp:Button runat="server" ID="btnSend" Text="Send Email" CssClass="btn btn-primary" OnClick="btnSend_Click" />
                </div>
                <div runat="server" id="ServerMessage"></div>
        </div>
    </div>
</asp:Content>
<%--Thank you for your waiting. I see you have windows plan, thus use the next settings please:
1) SMTPServer: localhost
2) SMTPPortNumber: 25
Please ensure you are using the SMTP host as 'localhost' and the SMTP port as 25. Also, the SMTP authentication needs to be enabled, and SSL disabled.--%>