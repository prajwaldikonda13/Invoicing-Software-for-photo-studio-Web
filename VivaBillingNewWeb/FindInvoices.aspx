<%@ Page Title="" Async="true" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FindInvoices.aspx.cs" Inherits="VivaBillingNewWeb.FindInvoices" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div runat="server" id="SelectionPanel">
            <asp:RadioButton runat="server" OnCheckedChanged="SelectionById_CheckedChanged"  GroupName="Selection" ID="SelectionById"   AutoPostBack="true" Text="Search by Id"/>
            <asp:RadioButton runat="server" OnCheckedChanged="SelectionById_CheckedChanged"   GroupName="Selection" ID="SelectionByEmail"   AutoPostBack="true"  Text="Search by email"/>
            <asp:RadioButton runat="server"  OnCheckedChanged="SelectionById_CheckedChanged" Checked="true"   GroupName="Selection" ID="SelectionByMobileNumber"  AutoPostBack="true"  Text="Search by mobile number"/>
            <asp:RadioButton runat="server" OnCheckedChanged="SelectionById_CheckedChanged"  GroupName="Selection" ID="SelectionByName"  AutoPostBack="true"   Text="Search by Name"/>
            <asp:RadioButton runat="server" OnCheckedChanged="SelectionById_CheckedChanged"  GroupName="Selection" ID="SelectionByDate"  AutoPostBack="true" Text="Search by date"/>
        </div>
        <asp:TextBox runat="server" Width="100%" ID="SearchInput" placeholder="Enter customer mobile number and press enter" OnTextChanged="SearchInput_TextChanged"></asp:TextBox>
        <div runat="server" id="DatesPanel" visible="false">
            <div class="input-group mb-3">
            <asp:TextBox runat="server" TextMode="Date" CssClass="form-control" ID="StartDateInput" AutoPostBack="true" placeholder="test" OnTextChanged="SearchInput_TextChanged"></asp:TextBox>
            <asp:TextBox runat="server" TextMode="Date"  CssClass="form-control" ID="EndDateInput" AutoPostBack="true" OnTextChanged="SearchInput_TextChanged"></asp:TextBox>
                </div>
        </div>
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
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Previous">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="PrevBal"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>



                <asp:TemplateField HeaderText="Grand">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblGrandTotal"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>




                 <asp:TemplateField HeaderText="Discount">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("Discount") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Final">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblTotal" Text='<%#Eval("FinalPrice") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Paid">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblPaid" Text='<%#Eval("Paid") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Due">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblDue" ></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label runat="server" ID="TotalDue"></asp:Label>
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
                
                <asp:TemplateField HeaderText="Show">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="ShowInvoiceButton" OnClick="ShowInvoiceButton_Click" Text="Invoice"></asp:LinkButton>
                    </ItemTemplate>
                     
                </asp:TemplateField>

               
                <asp:TemplateField HeaderText="Show">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="ShowCustomerButton" OnClick="ShowCustomerButton_Click" Text="Customer"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Send">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="SendEmailInvoice" OnClick="SendEmailInvoice_Click" Text="Email Invoice"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Show">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="ShowJobs" OnClick="ShowJobs_Click" Text="Jobs"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            

               
            
            
            </Columns>
        </asp:GridView>
        <div runat="server" id="ServerMessage"></div>
</asp:Content>

    
