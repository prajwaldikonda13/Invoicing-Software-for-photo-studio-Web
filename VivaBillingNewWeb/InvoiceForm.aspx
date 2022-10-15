<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="InvoiceForm.aspx.cs" Inherits="VivaBillingNewWeb.InvoiceForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container">

            <div class="" id="Invoice">
                <div class="-dialog  -lg">
                    <div class="-content">

                        <!--  Header -->
                        <div class="-header">
                            <h4 class="-title">Invoice</h4>
                        </div>

                        <!--  body -->
                        <div class="-body">
                            <div style="display: table; word-wrap: break-word; width: 100%;">
                                <div style="display: table-cell;">
                                    <div runat="server" id="ID"></div>
                                    <div runat="server" id="InvoiceName"></div>
                                    <div runat="server" id="InvoiceFirm"></div>
                                    <div runat="server" id="InvoiceAddress"></div>

                                </div>
                                <div style="display: table-cell;">

                                    <div runat="server" id="InvoiceMobile"></div>
                                    <div runat="server" id="InvoiceEmail"></div>
                                    <%--<div runat="server" id="InvoiceDate"></div>--%>
                                    <asp:TextBox TextMode="Date" CssClass="form-control" runat="server" ID="InvoiceDate"></asp:TextBox>
                                    <%--<div runat="server" id="InvoiceTime"></div>--%>

                                </div>
                            </div>
                            <asp:GridView ShowFooter="true" CssClass="table table-striped" runat="server" ID="InvoiceGrid" OnRowDataBound="InvoiceGrid_RowDataBound" AutoGenerateColumns="false">
                                <Columns>

                                    <asp:TemplateField HeaderText="No.">
                                        <ItemTemplate>
                                            <asp:Label runat="server" CssClass="" ID="Number">
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Product">
                                        <ItemTemplate>
                                            <asp:Label runat="server" CssClass="" ID='invoiceProduct'>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Type">
                                        <ItemTemplate>
                                            <asp:Label runat="server" CssClass="" ID="invoiceProductType" Text='<%#Eval("ProductType") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Size">
                                        <ItemTemplate>
                                            <asp:Label runat="server" CssClass="" ID="invoiceProductSize" Text='<%#Eval("ProductSize") %>'>
                                            </asp:Label>
                                        </ItemTemplate>

                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Unit Price">
                                        <ItemTemplate>
                                            <asp:Label runat="server" CssClass="" Text='<%#Eval("UnitPrice") %>'>
                                            </asp:Label>
                                        </ItemTemplate>

                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Quantity">
                                        <ItemTemplate>
                                            <asp:Label runat="server" CssClass="" Text='<%#Eval("Quantity") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label runat="server" ID="InvoiceTotalQuantiy"></asp:Label>
                                        </FooterTemplate>

                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Total">
                                        <ItemTemplate>
                                            <asp:Label runat="server" CssClass="" Text='<%#Eval("TotalPrice") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label runat="server" ID="InvoiceGrandTotal"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <table class="float-right">
                               <tr>
                                   <td><label runat="server" id="lblPrevDue"></label></td>
                                    <td><input class="form-control"  readonly="readonly" runat="server" id="PrevBal"></input></td>
                                </tr>
                                <tr>
                                    <td>Grand Total:</td>
                                    <td><span runat="server"  class="form-control"  id="lblGrandTotal"></span></td>
                                </tr>

                                <tr>
                                    <td>Discount:</td>
                                    <td><asp:TextBox runat="server"  class="form-control"  id="txtDiscount" AutoPostBack="true" OnTextChanged="paid_TextChanged"></asp:TextBox></td>
                                </tr>
                                 <tr>
                                    <td>Final Price:</td>
                                    <td><span runat="server"  class="form-control"  id="finalPrice"></span></td>
                                </tr>
                                <tr>
                                    <td>Paid:</td>
                                    <td>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="paid" AutoPostBack="true" OnTextChanged="paid_TextChanged" />
                                    </td>
                                </tr>
                                <tr>
                                    <td><span runat="server" id="DueLabel">Due:</span></td>
                                    <td>
                                        <input class="form-control" type="text" runat="server" id="due"  readonly="readonly" /></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="btnSave" class="btn btn-danger float-right" OnClientClick="this.style.visibility='hidden';" data-dismiss="" runat="server" OnClick="SaveButton_Click" Text="Confirm and Save"></asp:Button>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        <span runat="server" id="ServerMessage"></span>
        </div>
</asp:Content>