<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CustomerRegistration.aspx.cs" Inherits="VivaBillingNewWeb.CustomerRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .form-group {
            margin: 0;
        }

            .form-group input {
                border: none;
                border-radius: 0;
                border-bottom: 1px solid grey;
                outline: none;
            }

            .form-group *:focus {
                border: none;
                border-bottom: 1px solid black;
            }

        .error {
            display: none;
        }

        .custom-select {
            border: none;
            border-bottom: 1px solid grey;
            outline: none;
        }
    </style>
    <div style="display: block; height: 100vh;">
        <div class="container-fluid" style="display: table; width: 50%; height: 100%">
            <div style="display: table-cell; width: 50vw; vertical-align: middle">
               <%-- <asp:RadioButton runat="server" ID="hasMobile" Checked="true" GroupName="group1" Text="Has Mobile Number" AutoPostBack="true" OnCheckedChanged="hasMobile_CheckedChanged"></asp:RadioButton>
                <asp:RadioButton runat="server" ID="hasEmail" GroupName="group1" Text="Has Email Id" AutoPostBack="true" OnCheckedChanged="hasMobile_CheckedChanged"></asp:RadioButton>
                <asp:RadioButton runat="server" ID="hasBoth" GroupName="group1" Text="Has Both" AutoPostBack="true" OnCheckedChanged="hasMobile_CheckedChanged"></asp:RadioButton>
                <asp:RadioButton runat="server" ID="hasNone" GroupName="group1" Text="Has Nothing" AutoPostBack="true" OnCheckedChanged="hasMobile_CheckedChanged"></asp:RadioButton>--%>

                <div class="form-group">
                    <input type="text" runat="server" class="form-control" id="firstName" placeholder="First Name" />
                </div>
                <div class="form-group">
                    <input type="text" runat="server" class="form-control" id="lastName" placeholder="Last Name" />
                </div>
                <div class="form-group">
                    <input type="text" runat="server" class="form-control" id="firmName" placeholder="Firm name" />
                </div>

                <div class="form-group">
                    <input type="text" runat="server" class="form-control" id="emailId" placeholder="Email Id" />
                    <div runat="server" id="EmailError" visible="false"></div>
                </div>

                <div class="form-group">
                    <input type="text" runat="server" class="form-control" id="mobile" placeholder="Mobile number" ontextchanged="mobile_TextChanged" />
                    <div runat="server" id="MobileError" visible="false"></div>
                </div>

                <div class="form-group">
                    <input type="text" runat="server" class="form-control" id="pinCode" placeholder="6 Digits[0-9] Pin code" />
                </div>
                <div class="form-group">
                    <input type="text" runat="server" class="form-control" id="flatNo" placeholder="Flat / House No./ Floor/ Building " />
                </div>

                <div class="form-group">
                    <input type="text" runat="server" class="form-control" id="colony" placeholder="Colony / Street / Locality  " />
                </div>

                <div class="form-group">
                    <input type="text" runat="server" class="form-control" id="landmark" placeholder="Landmark  " />
                </div>
                <div class="form-group">
                    <input type="text" runat="server" class="form-control" id="city" placeholder="City  " />
                </div>


                <div class="input-group mb-3">
                    <select name="State" class="custom-select" runat="server" id="states" >
                    </select>
                    <select name="Country" class="custom-select" id="countries" runat="server">
                    </select>
                </div>
                Select Customer Type:
                <asp:RadioButton runat="server" ID="typeCounterCustomer" GroupName="customerType" Text="Counter Customer" Checked="true" />
                <asp:RadioButton runat="server" ID="typeRegularCustomer" GroupName="customerType" Text="Regular Customer" />

                <%--<div class="input-group mb-3" runat="server" id="OTPPanel">
                    <input type="text" runat="server" id="EmailOTP" class="form-control" placeholder="Email OTP" />
                    <input type="text" runat="server" id="MobileOTP" class="form-control" placeholder="Mobile OTP" />

                    <div class="input-group mb-3" runat="server">
                        <div runat="server" id="EmailOTPError" visible="false" class="form-control"></div>
                        <div runat="server" id="MobileOTPError" visible="false" class="form-control"></div>
                    </div>
                    <div runat="server" id="EmailOTPSelectionPanel">
                        Send Email OTP using:
                        <asp:RadioButton runat="server" ID="SendByGmail" Text="gmail.com" GroupName="Selection" />
                        <asp:RadioButton runat="server" ID="SendByViva" Text="vivadigitals.com"  GroupName="Selection" checked="true"/>
                    </div>

                    <asp:Button CssClass="btn btn-primary form-control" runat="server" ID="SendOtpBtn" OnClick="SendOtpBtn_Click1" Text="Send OTPs"></asp:Button>

                </div>--%>
                <%-- <div class="input-group mb-3" runat="server">
                    <div runat="server" id="EmailOTPError" class="form-control"></div>
                        <div runat="server" id="MobileOTPError" class="form-control"></div>
                </div>--%>
                <div class="input-group mb-3">
                    <asp:Button CssClass="btn btn-primary form-control" runat="server" ID="Submit" Enabled="true" OnClick="submit_Click" Text="Confirm and add customer"></asp:Button>
                    <%--<asp:Button CssClass="btn btn-danger form-control" runat="server" ID="Reset" OnClick="Reset_Click" Text="Reset"></asp:Button>--%>
                </div>
                <div id="ServerMessage" class="alert alert-primary" runat="server"></div>
            </div>
        </div>
    </div>
</asp:Content>



