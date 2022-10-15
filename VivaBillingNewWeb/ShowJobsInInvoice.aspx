<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ShowJobsInInvoice.aspx.cs" Inherits="VivaBillingNewWeb.ShowJobsInInvoice" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div style="text-align:center">
            <div><span>Customer Name:</span><span><span runat="server" id="CustomerName"></span></span></div>
        <div><span>Invoice Date:</span><span runat="server" id="InvoiceDate"></span></div>
        </div>

        <asp:GridView runat="server" CssClass="table table-striped" AutoGenerateColumns="false" ID="JobsGrid" ShowFooter="true" OnRowDataBound="JobsGrid_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="ID">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblId" Text='<%#Eval("ID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Product">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblProduct"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Product Type">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblProductType"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Product Size">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblProductSize"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               
                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblQuantity" Text='<%#Eval("Quantity") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Unit Price">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblUnitPrice" Text='<%#Eval("UnitPrice") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total Price">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblTotal" Text='<%#Eval("TotalPrice") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:RadioButton runat="server" ID="StatusNotStarted" AutoPostBack="true" OnCheckedChanged="StatusNotStarted_CheckedChanged" Text="Not started" GroupName="StatusGroup"/>
                        <asp:RadioButton runat="server" ID="StatusInProgress"  AutoPostBack="true" OnCheckedChanged="StatusNotStarted_CheckedChanged" Text="In progress" GroupName="StatusGroup"/>
                        <asp:RadioButton runat="server" ID="StatusCompleted"  AutoPostBack="true" OnCheckedChanged="StatusNotStarted_CheckedChanged" Text="Completed" GroupName="StatusGroup"/>
                        <%--<asp:Label runat="server" ID="lblStatus"></asp:Label>--%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Invoice Id">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblInvoiceId" Text='<%#Eval("Invoice") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    <div runat="server" id="ServerMessage"></div>
</asp:Content>