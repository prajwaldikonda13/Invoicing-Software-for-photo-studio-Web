<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ShowCustomerDetails.aspx.cs" Inherits="VivaBillingNewWeb.ShowCustomerDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table class="table table-striped">
            <tr> 
            <td>
                <span>ID:</span>
            </td>
               <td>
                <span runat="server" id="ID"></span>

               </td> 
        </tr>
            <tr>
                <td>
            <span>First Name:</span>

                </td>
                <td>
                    <span runat="server" id="FirstName"></span>
                </td>
                </tr>
        <tr>
            <td>
            <span>Last Name:</span>

            </td>
            <td>
            <span runat="server" id="LastName"></span>

            </td>
        </tr>
            <tr>
            <td>
                <span>Firm Name:</span>
            </td>
                <td>
                <span runat="server" id="FirmName"></span>

                </td>
       </tr>
            <tr>
           <td>
                <span>Email Id:</span>
           </td>
                <td>
                    <span runat="server" id="EmailId"></span>
                </td>
       </tr>
            <tr>
               <td>
                    <span>Mobile Number:</span>
               </td>
                <td>
                    <span runat="server" id="MobileNumber"></span>
                </td>
       </tr>
            <tr>
            
                <td>
                    <span>PinCode:</span>
                </td>
                <td>
                    <span runat="server" id="PinCode"></span>
                </td>
                </tr>
        <tr>
            <td>
            <span>Flat:</span>

            </td>
            <td>
            <span runat="server" id="Flat"></span>

            </td>
            </tr>
       <tr>
            <td>
                <span>Colony:</span>
            </td><td>
                <span runat="server" id="Colony"></span>
                 </td>
           </tr>
       <tr>
           <td>
                <span>Landmark:</span>
           </td>
           <td>
               <span runat="server" id="Landmark"></span>
           </td>
       </tr>
            <tr>
            <td>
                <span>City:</span>
            </td>
                <td>
                    <span runat="server" id="City"></span>
                </td>
        </tr>
        <tr>
            <td>
                <span>State:</span>
            </td>
            <td>
                <span runat="server" id="State"></span>
            </td>
        </tr>
            <tr>
            <td>
                <span>Country:</span>
            </td><td>
                <span runat="server" id="Country"></span>
                 </td>
        </tr>
        </table>
    <div runat="server" id="ServerMessage"></div>
</asp:Content> 