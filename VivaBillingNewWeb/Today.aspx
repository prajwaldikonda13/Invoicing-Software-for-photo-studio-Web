<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Today.aspx.cs" Inherits="VivaBillingNewWeb.Today" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="page-header">
  <h1><span runat="server" id="heading"></span><span runat="server" id="count"></span>
  </h1>
</div>
    <asp:TextBox TextMode="Date"  runat="server" ID="datePicker" OnTextChanged="datePicker_TextChanged" CssClass="form-control" AutoPostBack="true" />
        <asp:GridView runat="server" CssClass="table table-striped" AutoGenerateColumns="false" ID="InvoicesGrid" ShowFooter="true" OnRowDataBound="InvoicesGrid_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="ID">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblId" Text='<%#Eval("ID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Customer name">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblCustomerName" ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblDate"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Time">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblTime"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>




                 <asp:TemplateField HeaderText="Total">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="Total"></asp:Label>
                    </ItemTemplate>
                     <FooterTemplate>
                        <asp:Label runat="server" ID="lblTotalToday"></asp:Label>
                     </FooterTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Previous">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="PrevBal" Text='<%#Eval("PrevBal") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>



                  <asp:TemplateField HeaderText="Grand">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblGrandTotal"></asp:Label>
                    </ItemTemplate>
                       <FooterTemplate>
                        <asp:Label runat="server" ID="lblGrandTotalToday"></asp:Label>
                     </FooterTemplate>
                </asp:TemplateField>



                 <asp:TemplateField HeaderText="Discount">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblDiscount"></asp:Label>
                    </ItemTemplate>
                     <FooterTemplate>
                        <asp:Label runat="server" ID="lblTotalDiscountToday"></asp:Label>
                     </FooterTemplate>
                </asp:TemplateField>



                <asp:TemplateField HeaderText="Final">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblTotal" Text='<%#Eval("FinalPrice") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblTotalFinalToday" Text='<%#Eval("FinalPrice") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>



                <asp:TemplateField HeaderText="Paid">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblPaid" Text='<%#Eval("Paid") %>'></asp:Label>
                    </ItemTemplate>
                     <FooterTemplate>
                        <asp:Label runat="server" ID="lblTotalPaidToday"></asp:Label>
                     </FooterTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Due">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblDue" ></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label runat="server" ID="lblTotalDueToday"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>



                

                <asp:TemplateField HeaderText="Bal. after pay">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="CurrentBal" Text='<%#Eval("CurrentBal") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%--<asp:TextBox  runat="server" ID="txtPaid" CssClass="form-control" OnTextChanged="txtPaid_TextChanged" style="margin-top:-8px;" AutoPostBack="true" placeholder="Add amount here to add"></asp:TextBox>--%>
                    </FooterTemplate>
                </asp:TemplateField>
                
        <%--        <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="ShowInvoiceButton" OnClick="ShowInvoiceButton_Click" Text="Show Invoice"></asp:LinkButton>
                    </ItemTemplate>
                     
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="ShowCustomerButton" OnClick="ShowCustomerButton_Click" Text="Show Customer"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="SendEmailInvoice" OnClick="SendEmailInvoice_Click" Text="Send Email Invoice"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>


                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="ShowJobs" OnClick="ShowJobs_Click" Text="Show Jobs"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>--%>
            

               
            
            
            </Columns>
        </asp:GridView>
        <div runat="server" id="ServerMessage"></div>
</asp:Content>