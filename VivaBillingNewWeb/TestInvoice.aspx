<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestInvoice.aspx.cs" Inherits="VivaBillingNewWeb.TestInvoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form runat="server" id="form1">
        <div id="container">

      <section id="memo">
        <div class="logo">
          <ib-span class="ib_drop_zone" data-tooltip="tooltip" data-placement="top" title="" style="width: 150px; height: 100px;" data-original-title="Drop image or click to upload your logo (max 2MB).<br>For better print resolution use larger image,<br>as it's automatically scaled down."><ib-span>Drop your logo here<br><ib-span>(150 x 100px)</ib-span><input type="file" accept="image/*" class="ib_drop_logo"></ib-span></ib-span><img data-logo="company_logo" src="data:image/gif;base64,R0lGODlhAQABAIAAAAAAAP///yH5BAEAAAAALAAAAAABAAEAAAIBRAA7" style="display: none;"><ib-div class="ib_remove_logo_overlay" data-tooltip="tooltip" data-placement="top"><ib-span class="ib_remove_logo" title="Remove logo"><i class="fa fa-times-circle"></i></ib-span></ib-div>
        </div>

        <div class="company-info">
          <span data-ibcl-id="company_name" class="ibcl_company_name" data-tooltip="tooltip" data-placement="top" title="" contenteditable="true" data-original-title="Enter your company name">Dino Store</span>

          <div class="separator less"></div>

          <span data-ibcl-id="company_address" class="ibcl_company_address" data-tooltip="tooltip" data-placement="top" title="Enter company's address" contenteditable="true">227 Cobblestone Road</span>
          <span data-ibcl-id="company_city_zip_state" class="ibcl_company_city_zip_state" data-tooltip="tooltip" data-placement="top" title="" contenteditable="true" data-original-title="Enter company's zip, city and country">30000 Bedrock, Cobblestone County</span>

          <br>

          <span data-ibcl-id="company_email_web" class="ibcl_company_email_web" data-tooltip="tooltip" data-placement="top" title="Enter company's web and email address" contenteditable="true">http://dinostore.bed | hello@dinostore.bed</span>
          <span data-ibcl-id="company_phone_fax" class="ibcl_company_phone_fax" data-tooltip="tooltip" data-placement="top" title="Enter company's contact phones" contenteditable="true">+555 7 789-1234</span>
        </div>
      </section>

      <section id="invoice-title-number">
      
        <span id="title" data-ibcl-id="invoice_title" class="ibcl_invoice_title" data-tooltip="tooltip" data-placement="top" title="Enter invoice title" contenteditable="true">INVOICE</span>
        <div class="separator"></div>
        <span id="number" data-ibcl-id="invoice_number" class="ibcl_invoice_number" data-tooltip="tooltip" data-placement="top" title="Enter invoice number" contenteditable="true">#1</span>
        
      </section>
      
      <div class="clearfix"></div>
      
      <section id="invoice-info">
        <div>
          <span data-ibcl-id="issue_date_label" class="ibcl_issue_date_label" data-tooltip="tooltip" data-placement="top" title="Enter issue date label" contenteditable="true">Issue Date:</span>
          <span data-ibcl-id="due_date_label" class="ibcl_due_date_label" data-tooltip="tooltip" data-placement="top" title="Enter invoice due date label" contenteditable="true">Due Date:</span>
          <span data-ibcl-id="net_term_label" class="ibcl_net_term_label" data-tooltip="tooltip" data-placement="top" title="Enter net days label" contenteditable="true">Net:</span>
          <span data-ibcl-id="currency_label" class="ibcl_currency_label" data-tooltip="tooltip" data-placement="top" title="Enter invoice currency label" contenteditable="true">Currency:</span>
          <span data-ibcl-id="po_number_label" class="ibcl_po_number_label" data-tooltip="tooltip" data-placement="top" title="Enter P.O. label" contenteditable="true">P.O. #</span>
        </div>
        
        <div>
          <span data-ibcl-id="issue_date" class="ibcl_issue_date" data-tooltip="tooltip" data-placement="top" title="Select invoice issue date" data-date="11/24/2018">11/24/2018</span>
          <span data-ibcl-id="due_date" class="ibcl_due_date" data-tooltip="tooltip" data-placement="top" title="Select invoice due date" data-date="12/15/2018">12/15/2018</span>
          <span data-ibcl-id="net_term" class="ibcl_net_term" data-tooltip="tooltip" data-placement="top" title="Enter invoice net days" contenteditable="true">21</span>
          <span data-ibcl-id="currency" class="ibcl_currency" data-tooltip="tooltip" data-placement="top" title="Enter invoice currency" contenteditable="true">USD</span>
          <span data-ibcl-id="po_number" class="ibcl_po_number" data-tooltip="tooltip" data-placement="top" title="Enter P.O. Number" contenteditable="true">1/3-147</span>
        </div>
      </section>
      
      <section id="client-info">
        <span data-ibcl-id="bill_to_label" class="ibcl_bill_to_label" data-tooltip="tooltip" data-placement="top" title="" contenteditable="true" data-original-title="Enter bill to label">Bill to:</span>
        <div>
          <span class="client-name ibcl_client_name" data-ibcl-id="client_name" data-tooltip="tooltip" data-placement="top" title="" contenteditable="true" data-original-title="Enter client name">Slate Rock and Gravel Company</span>
        </div>
        
        <div>
          <span data-ibcl-id="client_address" class="ibcl_client_address" data-tooltip="tooltip" data-placement="top" title="" contenteditable="true" data-original-title="Enter client address">222 Rocky Way</span>
        </div>
        
        <div>
          <span data-ibcl-id="client_city_zip_state" class="ibcl_client_city_zip_state" data-tooltip="tooltip" data-placement="top" title="" contenteditable="true" data-original-title="Enter client city, zip, country">30000 Bedrock, Cobblestone County</span>
        </div>
        
        <div>
          <span data-ibcl-id="client_phone_fax" class="ibcl_client_phone_fax" data-tooltip="tooltip" data-placement="top" title="" contenteditable="true" data-original-title="Enter client pnone &amp; fax">+555 7 123-5555</span>
        </div>
        
        <div>
          <span data-ibcl-id="client_email" class="ibcl_client_email" data-tooltip="tooltip" data-placement="top" title="" contenteditable="true" data-original-title="Enter client email">fred@slaterockgravel.bed</span>
        </div>
        
        <div>
          <span data-ibcl-id="client_other" class="ibcl_client_other" data-tooltip="tooltip" data-placement="top" title="" contenteditable="true" data-original-title="Enter other client info">Attn: Fred Flintstone</span>
        </div>
      </section>
      
      <div class="clearfix"></div>
      
      <section id="items">
        
        <table cellpadding="0" cellspacing="0">
        
          <tbody><tr>
            <th data-ibcl-id="item_row_number_label" class="ibcl_item_row_number_label" data-tooltip="tooltip" data-placement="top" title=""></th> <!-- Dummy cell for the row number and row commands -->
            <th data-ibcl-id="item_description_label" class="ibcl_item_description_label" data-tooltip="tooltip" data-placement="top" title="Enter item header" contenteditable="true">Item</th>
            <th data-ibcl-id="item_quantity_label" class="ibcl_item_quantity_label" data-tooltip="tooltip" data-placement="top" title="Enter quantity header" contenteditable="true">Quantity</th>
            <th data-ibcl-id="item_price_label" class="ibcl_item_price_label" data-tooltip="tooltip" data-placement="top" title="Enter price header" contenteditable="true">Price</th>
            <th data-ibcl-id="item_discount_label" class="ibcl_item_discount_label" data-tooltip="tooltip" data-placement="top" title="" contenteditable="true" data-original-title="Enter discount header">Discount</th>
            <th data-ibcl-id="item_tax_label" class="ibcl_item_tax_label" data-tooltip="tooltip" data-placement="top" title="Enter tax header" contenteditable="true">Tax</th>
            <th data-ibcl-id="item_line_total_label" class="ibcl_item_line_total_label" data-tooltip="tooltip" data-placement="top" title="Enter line total header" contenteditable="true">Linetotal</th>
          </tr>
          
          <tr data-iterate="item">
            <td data-ibcl-id="item_row_number" class="ibcl_item_row_number" data-tooltip="tooltip" data-placement="top" title="" style="position: relative;"><ib-span class="ib_row_commands" style="height:39px;"><ib-span class="ib_commands"><ib-span class="ib_add" title="Insert row"><i class="fa fa-plus"></i></ib-span><ib-span class="ib_delete" title="Remove row"><i class="fa fa-minus"></i></ib-span><ib-span class="ib_move" title="Drag to reorder" style="cursor: move;"><i class="fa fa-sort"></i></ib-span></ib-span></ib-span><ib-span data-row-number="item_row_number">1</ib-span></td> <!-- Don't remove this column as it's needed for the row commands -->
            <td><span class="show-mobile ibcl_item_description_label" data-ibcl-id="item_description_label" data-tooltip="tooltip" data-placement="top" title="Enter item header" contenteditable="true" style="display: inline;">Item</span> <span data-ibcl-id="item_description" class="ibcl_item_description" data-tooltip="tooltip" data-placement="top" title="Enter item description" contenteditable="true">Frozen Brontosaurus Ribs</span></td>
            <td><span class="show-mobile ibcl_item_quantity_label" data-ibcl-id="item_quantity_label" data-tooltip="tooltip" data-placement="top" title="Enter quantity header" contenteditable="true" style="display: inline;">Quantity</span> <span data-ibcl-id="item_quantity" class="ibcl_item_quantity" data-tooltip="tooltip" data-placement="top" title="Enter quantity" contenteditable="true">2</span></td>
            <td><span class="show-mobile ibcl_item_price_label" data-ibcl-id="item_price_label" data-tooltip="tooltip" data-placement="top" title="Enter price header" contenteditable="true" style="display: inline;">Price</span> <span data-ibcl-id="item_price" class="ibcl_item_price add_currency_left" data-tooltip="tooltip" data-placement="top" title="Enter price" contenteditable="true" data-currency="$">120</span></td>
            <td><span class="show-mobile ibcl_item_discount_label" data-ibcl-id="item_discount_label" data-tooltip="tooltip" data-placement="top" title="Enter discount header" contenteditable="true" style="display: inline;">Discount</span> <span data-ibcl-id="item_discount" class="ibcl_item_discount" data-tooltip="tooltip" data-placement="top" title="Enter discount" contenteditable="true"></span></td>
            <td><span class="show-mobile ibcl_item_tax_label" data-ibcl-id="item_tax_label" data-tooltip="tooltip" data-placement="top" title="Enter tax header" contenteditable="true" style="display: inline;">Tax</span> <span data-ibcl-id="item_tax" class="ibcl_item_tax ib_item_percentage" data-tooltip="tooltip" data-placement="top" title="Enter tax" contenteditable="true">2</span></td>
            <td><span class="show-mobile ibcl_item_line_total_label" data-ibcl-id="item_line_total_label" data-tooltip="tooltip" data-placement="top" title="Enter line total header" contenteditable="true" style="display: inline;">Linetotal</span> <span data-ibcl-id="item_line_total" class="ibcl_item_line_total" data-tooltip="tooltip" data-placement="top" title=""></span></td>
          </tr><tr data-iterate="item">
            <td data-ibcl-id="item_row_number" class="ibcl_item_row_number" data-tooltip="tooltip" data-placement="top" title="" style="position: relative;"><ib-span class="ib_row_commands" style="height:39px;"><ib-span class="ib_commands"><ib-span class="ib_add" title="Insert row"><i class="fa fa-plus"></i></ib-span><ib-span class="ib_delete" title="Remove row"><i class="fa fa-minus"></i></ib-span><ib-span class="ib_move" title="Drag to reorder" style="cursor: move;"><i class="fa fa-sort"></i></ib-span></ib-span></ib-span><ib-span data-row-number="item_row_number">2</ib-span></td> <!-- Don't remove this column as it's needed for the row commands -->
            <td><span class="show-mobile ibcl_item_description_label" data-ibcl-id="item_description_label" data-tooltip="tooltip" data-placement="top" title="Enter item header" contenteditable="true" style="display: inline;">Item</span> <span data-ibcl-id="item_description" class="ibcl_item_description" data-tooltip="tooltip" data-placement="top" title="Enter item description" contenteditable="true">Mammoth Chops</span></td>
            <td><span class="show-mobile ibcl_item_quantity_label" data-ibcl-id="item_quantity_label" data-tooltip="tooltip" data-placement="top" title="Enter quantity header" contenteditable="true" style="display: inline;">Quantity</span> <span data-ibcl-id="item_quantity" class="ibcl_item_quantity" data-tooltip="tooltip" data-placement="top" title="Enter quantity" contenteditable="true">14</span></td>
            <td><span class="show-mobile ibcl_item_price_label" data-ibcl-id="item_price_label" data-tooltip="tooltip" data-placement="top" title="Enter price header" contenteditable="true" style="display: inline;">Price</span> <span data-ibcl-id="item_price" class="ibcl_item_price add_currency_left" data-tooltip="tooltip" data-placement="top" title="Enter price" contenteditable="true" data-currency="$">175</span></td>
            <td><span class="show-mobile ibcl_item_discount_label" data-ibcl-id="item_discount_label" data-tooltip="tooltip" data-placement="top" title="Enter discount header" contenteditable="true" style="display: inline;">Discount</span> <span data-ibcl-id="item_discount" class="ibcl_item_discount ib_item_percentage" data-tooltip="tooltip" data-placement="top" title="Enter discount" contenteditable="true">-10</span></td>
            <td><span class="show-mobile ibcl_item_tax_label" data-ibcl-id="item_tax_label" data-tooltip="tooltip" data-placement="top" title="Enter tax header" contenteditable="true" style="display: inline;">Tax</span> <span data-ibcl-id="item_tax" class="ibcl_item_tax ib_item_percentage" data-tooltip="tooltip" data-placement="top" title="Enter tax" contenteditable="true">5</span></td>
            <td><span class="show-mobile ibcl_item_line_total_label" data-ibcl-id="item_line_total_label" data-tooltip="tooltip" data-placement="top" title="Enter line total header" contenteditable="true" style="display: inline;">Linetotal</span> <span data-ibcl-id="item_line_total" class="ibcl_item_line_total" data-tooltip="tooltip" data-placement="top" title=""></span></td>
          </tr><tr data-iterate="item">
            <td data-ibcl-id="item_row_number" class="ibcl_item_row_number" data-tooltip="tooltip" data-placement="top" title="" style="position: relative;"><ib-span class="ib_row_commands" style="height:39px;"><ib-span class="ib_commands"><ib-span class="ib_add" title="Insert row"><i class="fa fa-plus"></i></ib-span><ib-span class="ib_delete" title="Remove row"><i class="fa fa-minus"></i></ib-span><ib-span class="ib_move" title="Drag to reorder" style="cursor: move;"><i class="fa fa-sort"></i></ib-span></ib-span></ib-span><ib-span data-row-number="item_row_number">3</ib-span></td> <!-- Don't remove this column as it's needed for the row commands -->
            <td><span class="show-mobile ibcl_item_description_label" data-ibcl-id="item_description_label" data-tooltip="tooltip" data-placement="top" title="Enter item header" contenteditable="true" style="display: inline;">Item</span> <span data-ibcl-id="item_description" class="ibcl_item_description" data-tooltip="tooltip" data-placement="top" title="Enter item description" contenteditable="true"></span></td>
            <td><span class="show-mobile ibcl_item_quantity_label" data-ibcl-id="item_quantity_label" data-tooltip="tooltip" data-placement="top" title="Enter quantity header" contenteditable="true" style="display: inline;">Quantity</span> <span data-ibcl-id="item_quantity" class="ibcl_item_quantity" data-tooltip="tooltip" data-placement="top" title="Enter quantity" contenteditable="true"></span></td>
            <td><span class="show-mobile ibcl_item_price_label" data-ibcl-id="item_price_label" data-tooltip="tooltip" data-placement="top" title="Enter price header" contenteditable="true" style="display: inline;">Price</span> <span data-ibcl-id="item_price" class="ibcl_item_price" data-tooltip="tooltip" data-placement="top" title="Enter price" contenteditable="true"></span></td>
            <td><span class="show-mobile ibcl_item_discount_label" data-ibcl-id="item_discount_label" data-tooltip="tooltip" data-placement="top" title="Enter discount header" contenteditable="true" style="display: inline;">Discount</span> <span data-ibcl-id="item_discount" class="ibcl_item_discount" data-tooltip="tooltip" data-placement="top" title="Enter discount" contenteditable="true"></span></td>
            <td><span class="show-mobile ibcl_item_tax_label" data-ibcl-id="item_tax_label" data-tooltip="tooltip" data-placement="top" title="Enter tax header" contenteditable="true" style="display: inline;">Tax</span> <span data-ibcl-id="item_tax" class="ibcl_item_tax" data-tooltip="tooltip" data-placement="top" title="Enter tax" contenteditable="true"></span></td>
            <td><span class="show-mobile ibcl_item_line_total_label" data-ibcl-id="item_line_total_label" data-tooltip="tooltip" data-placement="top" title="Enter line total header" contenteditable="true" style="display: inline;">Linetotal</span> <span data-ibcl-id="item_line_total" class="ibcl_item_line_total" data-tooltip="tooltip" data-placement="top" title=""></span></td>
          </tr><ib-span class="ib_bottom_row_commands"><ib-span class="ib_blue_link ib_add_new_row_link">Add new row</ib-span><ib-span class="ib_blue_link ib_show_hide_columns_link">Configure columns</ib-span><ib-span class="ib_show_hide_columns"><ib-span><input type="checkbox" value="item_row_number"><ib-span>Row number</ib-span></ib-span><ib-span><input type="checkbox" value="item_description"><ib-span>Item</ib-span></ib-span><ib-span><input type="checkbox" value="item_quantity"><ib-span>Quantity</ib-span></ib-span><ib-span><input type="checkbox" value="item_price"><ib-span>Price</ib-span></ib-span><ib-span><input type="checkbox" value="item_discount"><ib-span>Discount</ib-span></ib-span><ib-span><input type="checkbox" value="item_tax"><ib-span>Tax</ib-span></ib-span><ib-span><input type="checkbox" value="item_line_total"><ib-span>Linetotal</ib-span></ib-span></ib-span></ib-span>
          
        </tbody></table>
        
      </section>
      
      <section id="sums">
      
        <table cellpadding="0" cellspacing="0">
          <tbody><tr>
            <th data-ibcl-id="amount_subtotal_label" class="ibcl_amount_subtotal_label" data-tooltip="tooltip" data-placement="top" title="Enter subtotal label" contenteditable="true">Subtotal:</th>
            <td data-ibcl-id="amount_subtotal" class="ibcl_amount_subtotal" data-tooltip="tooltip" data-placement="top" title="">$2,445.00</td>
          </tr>
          
          <tr data-iterate="tax" style="display: table-row;">
            <th data-ibcl-id="tax_name" class="ibcl_tax_name" data-tooltip="tooltip" data-placement="top" title="Enter tax label" contenteditable="true">Tax 1:</th>
            <td data-ibcl-id="tax_value" class="ibcl_tax_value" data-tooltip="tooltip" data-placement="top" title="" data-ib-value="2">$4.80</td>
          </tr><tr data-iterate="tax" style="display: table-row;">
            <th data-ibcl-id="tax_name" class="ibcl_tax_name" data-tooltip="tooltip" data-placement="top" title="Enter tax label" contenteditable="true">Tax 2:</th>
            <td data-ibcl-id="tax_value" class="ibcl_tax_value" data-tooltip="tooltip" data-placement="top" title="" data-ib-value="5">$110.25</td>
          </tr><tr data-iterate="tax" style="display: none;">
            <th data-ibcl-id="tax_name" class="ibcl_tax_name" data-tooltip="tooltip" data-placement="top" title="Enter tax label" contenteditable="true">Tax:</th>
            <td data-ibcl-id="tax_value" class="ibcl_tax_value" data-tooltip="tooltip" data-placement="top" title=""></td>
          </tr>
          
          <tr class="amount-total">
            <th data-ibcl-id="amount_total_label" class="ibcl_amount_total_label" data-tooltip="tooltip" data-placement="top" title="Enter total label" contenteditable="true">Total:</th>
            <td data-ibcl-id="amount_total" class="ibcl_amount_total" data-tooltip="tooltip" data-placement="top" title="">$2,560.05</td>
          </tr>
          
          <!-- You can use attribute data-hide-on-quote="true" to hide specific information on quotes.
               For example Invoicebus doesn't need amount paid and amount due on quotes  -->
          <tr data-hide-on-quote="true">
            <th data-ibcl-id="amount_paid_label" class="ibcl_amount_paid_label" data-tooltip="tooltip" data-placement="top" title="Enter amount paid label" contenteditable="true">Paid:</th>
            <td data-ibcl-id="amount_paid" class="ibcl_amount_paid add_currency_left" data-tooltip="tooltip" data-placement="top" title="Enter amount paid" contenteditable="true" data-currency="$">0.00</td>
          </tr>
          
          <tr data-hide-on-quote="true">
            <th data-ibcl-id="amount_due_label" class="ibcl_amount_due_label" data-tooltip="tooltip" data-placement="top" title="Enter amount due label" contenteditable="true">Amount Due:</th>
            <td data-ibcl-id="amount_due" class="ibcl_amount_due" data-tooltip="tooltip" data-placement="top" title="">$2,560.05</td>
          </tr>
          
        </tbody></table>
        
      </section>
      
      <div class="clearfix"></div>
      
      <section id="terms">
      
        <span class="hidden ibcl_terms_label" data-ibcl-id="terms_label" data-tooltip="tooltip" data-placement="top" title="Enter terms and notes label" contenteditable="true">Terms &amp; Notes</span>
        <div data-ibcl-id="terms" class="ibcl_terms" data-tooltip="tooltip" data-placement="top" title="Enter invoice terms and notes" contenteditable="true">Fred, thank you very much. We really appreciate your business.<br>Please send payments before the due date.</div>
        
      </section>

      <div class="payment-info">
        <div data-ibcl-id="payment_info1" class="ibcl_payment_info1" data-tooltip="tooltip" data-placement="top" title="Enter your payment details" contenteditable="true">Payment details:</div>
        <div data-ibcl-id="payment_info2" class="ibcl_payment_info2" data-tooltip="tooltip" data-placement="top" title="Enter other payment details" contenteditable="true">ACC:123006705</div>
        <div data-ibcl-id="payment_info3" class="ibcl_payment_info3" data-tooltip="tooltip" data-placement="top" title="Enter other payment details" contenteditable="true">IBAN:US100000060345</div>
        <div data-ibcl-id="payment_info4" class="ibcl_payment_info4" data-tooltip="tooltip" data-placement="top" title="Enter other payment details" contenteditable="true">SWIFT:BOA447</div>
        <div data-ibcl-id="payment_info5" class="ibcl_payment_info5" data-tooltip="tooltip" data-placement="top" title="Enter other payment details" contenteditable="true"></div>
      </div>

      <div class="bottom-circles">
        <section>
          <div>
            <div></div>
          </div>
          <div>
            <div>
              <div>
                <div></div>
              </div>
            </div>
          </div>
        </section>
      </div>
    </div>
    </form>
</body>
</html>
