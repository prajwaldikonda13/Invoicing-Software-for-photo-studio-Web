<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="VivaBillingNewWeb.Main" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="line-height: 100vh; text-align: center; font-size: 25vw">
        <style>
            th {
                text-align: left;
            }

            body {
                background-image: url("photography.jpeg");
                background-size: cover;
                padding-top:0px;
            }
        </style>
    </div>
    <div class="container">
            <asp:TextBox runat="server" ID="filter" CssClass="form-control" OnTextChanged="filter_TextChanged" AutoPostBack="true" placeholder="Enter name/last name/firm name/mobile number to search the customer" autocomplete="false"></asp:TextBox>
            <span runat="server" style="color:black;" id="CustomerName"></span>
            <asp:LinkButton runat="server" ID="BtnChange" OnClick="BtnChange_Click" Text="Change Customer" Visible="false"></asp:LinkButton>
        <span runat="server" id="BalanceOrDue" class="float-right"></span>
            <asp:GridView runat="server" CssClass="table table-striped" AutoGenerateColumns="false" ID="customers">
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblId" Text='<%#Eval("ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblFirstName" Text='<%#Eval("FirstName") %>'></asp:Label>
                            <%--   </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Last Name">
                    <ItemTemplate>--%>
                            <asp:Label runat="server" ID="lblLastName" Text='<%#Eval("LastName") %>'></asp:Label>
                            <%--  </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Firm Name">
                    <ItemTemplate>--%>
                            <asp:Label runat="server" ID="lblFirmName" Text='<%#Eval("FirmName") %>'></asp:Label>
                            <%-- </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Mobile Number">
                    <ItemTemplate>--%>
                            <asp:Label runat="server" ID="lblMobileNumber" Text='<%#Eval("MobileNumber") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                            <asp:LinkButton Text="Select" runat="server" ID="SelectButton" OnClick="SelectButton_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:GridView ShowFooter="true" CssClass="table table-striped" runat="server" ID="jobsGrid" AutoGenerateColumns="false" OnRowDataBound="jobsGrid_RowDataBound" OnRowDeleting="jobsGrid_RowDeleting">
                <Columns>
                    <asp:TemplateField HeaderText="Product">
                        <ItemTemplate>
                            <asp:DropDownList runat="server" AutoPostBack="true" CssClass="custom-select" ID="products" OnSelectedIndexChanged="products_SelectedIndexChanged">
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Type">
                        <ItemTemplate>
                            <asp:DropDownList runat="server" AutoPostBack="true" CssClass="custom-select" ID="productTypes" OnSelectedIndexChanged="productTypes_SelectedIndexChanged">
                            </asp:DropDownList>
                        </ItemTemplate>
                        <FooterTemplate>
                            <%--<asp:Button runat="server" Class="btn btn-dark btn-block" ID="SaveButton" Text="Save" OnClick="SaveButton_Click"></asp:Button>--%>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Size">
                        <ItemTemplate>
                            <asp:DropDownList runat="server" AutoPostBack="true" CssClass="custom-select" ID="productSizes" OnSelectedIndexChanged="sizes_SelectedIndexChanged">
                            </asp:DropDownList>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Button runat="server" CssClass="btn btn-dark btn-block" ID="ShowInvoiceBtn" Text="Show Invoice" OnClick="ShowInvoiceBtn_Click"></asp:Button>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Unit Price">
                        <ItemTemplate>
                            <asp:TextBox class="form-control" runat="server" ID="unitPrice" ReadOnly="" placeholder="Unit Price"></asp:TextBox>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Button runat="server" CssClass="btn btn-dark btn-block" ID="AddButton" Text="Add more" OnClick="AddButton_Click" />
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:TextBox TextMode="Number" class="form-control" runat="server" AutoPostBack="true" OnTextChanged="quantity_TextChanged" ID="quantity" placeholder="Quantity" value="1" />
                        </ItemTemplate>

                        <FooterTemplate>

                            <button type="button" class="btn btn-primary">
                                Total Items
                                <asp:Label runat="server" CssClass="badge badge-light" ID="grandQuantity" />
                            </button>

                        </FooterTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Total">
                        <ItemTemplate>
                            <asp:TextBox runat="server" CssClass="form-control" ID="totalPrice" ReadOnly="" placeholder="Total Price"></asp:TextBox>
                        </ItemTemplate>

                        <FooterTemplate>
                            <button type="button" class="btn btn-primary">
                                Grand Total
                                <asp:Label runat="server" CssClass="badge badge-light" ID="grandTotal" />
                            </button>
                        </FooterTemplate>

                    </asp:TemplateField>
                    <asp:CommandField ShowDeleteButton="true" DeleteText="&times;" />
                </Columns>

            </asp:GridView>
            <div id="ServerMessage" runat="server"></div>
            <!-- Button to Open the Modal -->
            <%--<button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal">
  Open modal
</button>--%>

            <!-- The Modal -->
    </div>
</asp:Content>