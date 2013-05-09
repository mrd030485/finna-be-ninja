<%@ Page language="c#" Codebehind="ViewOrder2.aspx.cs" AutoEventWireup="false" Inherits="OrderTrackerv2.Customers.Secure.ViewOrder2" %>
<%@ Register TagPrefix="uc1" TagName="OrderTrackerHeader" Src="../Controls/OrderTrackerHeader.ascx" %>
<%@ Register TagPrefix="uc1" TagName="OrderTrackerFooter" Src="../Controls/OrderTrackerFooter.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>View / Edit Order</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Style/iestyle.css" type="text/css" rel="stylesheet">
		<LINK href="../Style/iestyle.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<P><b><FONT color="red">Bold</FONT></b> fields are required</P>
			<P><asp:panel id="pnlKeyPoints" runat="server" Visible="False">
					<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="100%" border="1">
						<TR>
							<TD align="right">Art Approved:</TD>
							<TD>
								<asp:CheckBox id="artApproved" runat="server"></asp:CheckBox></TD>
							<TD align="right">Production Finished:</TD>
							<TD>
								<asp:CheckBox id="productionFinished" runat="server"></asp:CheckBox></TD>
							<TD align="right">Order Finished:</TD>
							<TD>
								<asp:CheckBox id="orderFinished" runat="server"></asp:CheckBox></TD>
						</TR>
					</TABLE>
				</asp:panel></P>
			<P>
				<TABLE id="tbOrderHeader" cellSpacing="2" cellPadding="0" width="100%" border="0">
					<TR>
						<TD><STRONG><FONT color="red">Inside Rep Username:</FONT></STRONG></TD>
						<TD><asp:textbox id="txtInsideRep" runat="server" CssClass="SmallTextBox"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" Display="None" ControlToValidate="txtInsideRep"
								ErrorMessage="An Inside Rep Username is Required"></asp:requiredfieldvalidator></TD>
						<TD><STRONG><FONT color="red">Outside Rep Username:</FONT></STRONG></TD>
						<TD><asp:textbox id="txtOutsideRep" runat="server" CssClass="SmallTextBox"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator3" runat="server" Display="None" ControlToValidate="txtOutsideRep"
								ErrorMessage="An Outside Rep Username is Required"></asp:requiredfieldvalidator></TD>
						<TD></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD bgColor="white"><STRONG><FONT color="#ff0000">Date:</FONT></STRONG></TD>
						<TD bgColor="white"><STRONG><FONT color="red"></FONT></STRONG><asp:textbox id="txtDate" runat="server" CssClass="SmallTextBox">01/01/2005</asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator4" runat="server" Display="None" ControlToValidate="txtDate"
								ErrorMessage="A Date is Required"></asp:requiredfieldvalidator></TD>
						<TD bgColor="white"><STRONG><FONT color="#ff0000">Due Date:</FONT></STRONG></TD>
						<TD bgColor="white"><STRONG><FONT color="red"></FONT></STRONG><asp:textbox id="txtDueDate" runat="server" CssClass="SmallTextBox">01/01/2005</asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator5" runat="server" Display="None" ControlToValidate="txtInsideRep"
								ErrorMessage="A Due Date is Required"></asp:requiredfieldvalidator></TD>
						<TD bgColor="white">Rec Date:</TD>
						<TD bgColor="white"><asp:textbox id="txtRecDate" runat="server" CssClass="SmallTextBox">01/01/2005</asp:textbox></TD>
					</TR>
					<TR>
						<TD>Reorder No:</TD>
						<TD><asp:textbox id="txtReorderNum" runat="server" CssClass="SmallTextBox" MaxLength="10"></asp:textbox></TD>
						<TD>P.O.&nbsp;#:</TD>
						<TD><asp:textbox id="txtPO" runat="server" CssClass="SmallTextBox" MaxLength="10"></asp:textbox></TD>
						<TD>X-Order No:</TD>
						<TD><asp:textbox id="txtXOrderNum" runat="server" CssClass="SmallTextBox" MaxLength="10"></asp:textbox></TD>
					</TR>
					<TR>
						<TD bgColor="#ffffff">Ship Via:</TD>
						<TD bgColor="#ffffff" colSpan="3"><asp:textbox id="txtShipping" runat="server" CssClass="TextBox" MaxLength="20"></asp:textbox></TD>
						<TD vAlign="top" bgColor="#ffffff" rowSpan="3"><STRONG><FONT color="#ff0000">Type:</FONT></STRONG></TD>
						<TD vAlign="top" bgColor="#ffffff" colSpan="2" rowSpan="3"><asp:dropdownlist id=cbType runat="server" CssClass="TextBox" DataTextFormatString="{0}" DataTextField="Type" DataValueField="Type" DataSource="<%# dsOrderTypes %>" DataMember="orderTypes"></asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD>Artist:</TD>
						<TD><asp:textbox id="txtArtist" runat="server" CssClass="SmallTextBox" MaxLength="40" ReadOnly="True"></asp:textbox></TD>
						<TD>Art Due Date:</TD>
						<TD><asp:textbox id="txtArtDueDate" runat="server" CssClass="SmallTextBox">01/01/2005</asp:textbox></TD>
					</TR>
					<TR>
						<TD bgColor="#ffffff"><STRONG><FONT color="#ff0000">Rush/Reorder/X-Order/Regular:</FONT></STRONG></TD>
						<TD bgColor="#ffffff" colSpan="3" rowSpan="2">
							<P><STRONG><FONT color="red"></FONT></STRONG><asp:dropdownlist id=cbRushRegReorder runat="server" CssClass="TextBox" DataTextFormatString="{0}" DataTextField="Speed" DataValueField="Speed" DataSource="<%# dsSpeedData %>" DataMember="Speed"></asp:dropdownlist></P>
						</TD>
					</TR>
				</TABLE>
			</P>
			<P><br>
				(Customers and Contacts must already exist before adding them to the order.)
				<br>
			</P>
			<P>
				<TABLE id="tbOrderHeader2" cellSpacing="2" cellPadding="0" width="100%" border="0">
					<TR>
						<TD><STRONG><FONT color="#ff0000">Name:</FONT></STRONG></TD>
						<TD colSpan="5"><asp:textbox id="txtCustomerName" runat="server" CssClass="TextBox" MaxLength="40" ReadOnly="True"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" Display="None" ControlToValidate="txtCustomerName"
								ErrorMessage="A Customer is Required!"></asp:requiredfieldvalidator></TD>
					</TR>
					<TR>
						<TD bgColor="#ffffff">Contact Person:</TD>
						<TD bgColor="#ffffff" colSpan="5"><asp:textbox id="txtContactName" runat="server" CssClass="TextBox" MaxLength="40" ReadOnly="True"></asp:textbox></TD>
					</TR>
					<TR>
						<TD>Address:</TD>
						<TD colSpan="5"><asp:textbox id="txtAddress" runat="server" CssClass="TextBox" MaxLength="40" ReadOnly="True"></asp:textbox></TD>
					</TR>
					<TR>
						<TD bgColor="#ffffff">City:</TD>
						<TD bgColor="#ffffff"><asp:textbox id="txtCity" runat="server" CssClass="SmallTextBox" MaxLength="20" ReadOnly="True"></asp:textbox></TD>
						<TD bgColor="#ffffff">State:
						</TD>
						<TD bgColor="#ffffff"><asp:textbox id="txtState" runat="server" CssClass="SmallTextBox" MaxLength="2" ReadOnly="True">KY</asp:textbox></TD>
						<TD bgColor="#ffffff">Zip Code:
						</TD>
						<TD bgColor="#ffffff"><asp:textbox id="txtZip" runat="server" CssClass="SmallTextBox" MaxLength="10" ReadOnly="True">99999</asp:textbox></TD>
					</TR>
					<TR>
						<TD>Phone No:</TD>
						<TD colSpan="5"><asp:textbox id="txtPhone" runat="server" CssClass="TextBox" MaxLength="12" ReadOnly="True"></asp:textbox></TD>
					</TR>
					<TR>
						<TD bgColor="#ffffff">Cell Phone No:</TD>
						<TD bgColor="#ffffff" colSpan="5"><asp:textbox id="txtCellPhone" runat="server" CssClass="TextBox" MaxLength="12" ReadOnly="True"></asp:textbox></TD>
					</TR>
					<TR>
						<TD>Fax No:</TD>
						<TD colSpan="5"><asp:textbox id="txtFax" runat="server" CssClass="TextBox" MaxLength="12" ReadOnly="True"></asp:textbox></TD>
					</TR>
					<TR>
						<TD bgColor="#ffffff">Email Address:</TD>
						<TD bgColor="#ffffff" colSpan="5"><asp:textbox id="txtEmail" runat="server" CssClass="TextBox" MaxLength="30" ReadOnly="True"></asp:textbox></TD>
					</TR>
				</TABLE>
			</P>
			<P><br>
				<br>
			</P>
			<P>
				<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" border="0">
					<TR>
						<TD align="right">Total Colors Front:</TD>
						<TD><asp:textbox id="txtColorsFront" runat="server" CssClass="TinyTextBox">0</asp:textbox></TD>
						<TD align="right">Total Colors Back:</TD>
						<TD><asp:textbox id="txtColorsBack" runat="server" CssClass="TinyTextBox">0</asp:textbox></TD>
					</TR>
					<TR>
						<TD align="right">Total Colors Sleeve:</TD>
						<TD><asp:textbox id="txtColorsSleeve" runat="server" CssClass="TinyTextBox">0</asp:textbox></TD>
						<TD align="right"></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD></TD>
						<TD></TD>
						<TD></TD>
					</TR>
				</TABLE>
			</P>
			<p><asp:panel id="pnlShirtList" runat="server">Here is the current shirt order list: 
<asp:DataGrid id=DataGrid1 runat="server" DataMember="ShirtOrders" DataSource="<%# dsShirtData %>" Width="100%" BorderWidth="2px" BorderColor="WhiteSmoke" AutoGenerateColumns="False" DataKeyField="totalQty">
						<AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
						<HeaderStyle Font-Bold="True" ForeColor="Black" BackColor="Gainsboro"></HeaderStyle>
						<Columns>
							<asp:BoundColumn DataField="totalQty" SortExpression="totalQty" HeaderText="QTY" DataFormatString="{0:G}"></asp:BoundColumn>
							<asp:TemplateColumn>
								<HeaderTemplate>
									Description: Brand, Color, Material, Weight
								</HeaderTemplate>
								<ItemTemplate>
									<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0">
										<TR>
											<TD><STRONG>Sleeve/Pocket:</STRONG>
												<asp:Label id=Label1 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.sleeveOrPocket", "{0}") %>'>
												</asp:Label></TD>
											<TD><STRONG>2/4:</STRONG>
												<asp:Label id=Label2 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.num_24", "{0}") %>'>
												</asp:Label></TD>
											<TD><STRONG>6/8:</STRONG>
												<asp:Label id=Label3 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.num_68", "{0}") %>'>
												</asp:Label></TD>
											<TD><STRONG>10/12:</STRONG>
												<asp:Label id=Label4 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.num_1012", "{0}") %>'>
												</asp:Label></TD>
											<TD><STRONG>14/16:</STRONG>
												<asp:Label id=Label5 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.num_1416", "{0}") %>'>
												</asp:Label><STRONG></STRONG></TD>
											<TD><STRONG>S:</STRONG>
												<asp:Label id=Label6 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.num_s", "{0}") %>'>
												</asp:Label></TD>
											<TD><STRONG>M:</STRONG>
												<asp:Label id=Label7 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.num_m", "{0}") %>'>
												</asp:Label></TD>
											<TD><STRONG>L:</STRONG>
												<asp:Label id=Label8 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.num_l", "{0}") %>'>
												</asp:Label></TD>
										</TR>
										<TR>
											<TD><STRONG>Type:</STRONG>
												<asp:Label id=Label9 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.type", "{0}") %>'>
												</asp:Label></TD>
											<TD colSpan="3"><STRONG>Color:</STRONG>
												<asp:Label id=Label10 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.color", "{0}") %>'>
												</asp:Label></TD>
											<TD><STRONG>XL:</STRONG>
												<asp:Label id=Label11 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.num_xl", "{0}") %>'>
												</asp:Label></TD>
											<TD><STRONG>XXL:</STRONG>
												<asp:Label id=Label12 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.num_xxl", "{0}") %>'>
												</asp:Label></TD>
											<TD><STRONG>XXXL:</STRONG>
												<asp:Label id=Label13 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.num_xxxl", "{0}") %>'>
												</asp:Label></TD>
											<TD><STRONG>XXXXL:</STRONG>
												<asp:Label id=Label14 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.num_xxxxl", "{0}") %>'>
												</asp:Label></TD>
										</TR>
										<TR>
											<TD><STRONG>Manufacturer:</STRONG>
												<asp:Label id=Label15 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.manufacturer", "{0}") %>'>
												</asp:Label></TD>
											<TD colSpan="3"><STRONG>Style:</STRONG>
												<asp:Label id=Label16 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.styleNum", "{0}") %>'>
												</asp:Label></TD>
											<TD colSpan="4"><STRONG>Desc:</STRONG>
												<asp:Label id=Label17 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.description", "{0}") %>'>
												</asp:Label></TD>
										</TR>
									</TABLE>
								</ItemTemplate>
							</asp:TemplateColumn>
							<asp:BoundColumn DataField="unitPrice" SortExpression="unitPrice" HeaderText="Unit Price" DataFormatString="{0:c}"></asp:BoundColumn>
							<asp:BoundColumn DataField="totalPrice" SortExpression="totalPrice" HeaderText="Total Price" DataFormatString="{0:c}"></asp:BoundColumn>
						</Columns>
					</asp:DataGrid></asp:panel><br>
				<br>
				<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
					<TR>
						<TD bgColor="#ffffff">Rush Charge:</TD>
						<TD align="right" width="33%" bgColor="#ffffff" colSpan="2">$
							<asp:textbox id="txtRushCharge" runat="server" CssClass="SmallTextBox" MaxLength="10">0.00</asp:textbox></TD>
					</TR>
					<TR>
						<TD>Ink Change/PMS Matching Charge:</TD>
						<TD align="right" width="33%" colSpan="2">$
							<asp:textbox id="txtPMSCharge" runat="server" CssClass="SmallTextBox" MaxLength="10">0.00</asp:textbox></TD>
					</TR>
					<TR>
						<TD bgColor="#ffffff">Set-Up Charge (1 charge per color per location):</TD>
						<TD align="right" width="33%" bgColor="#ffffff" colSpan="2">$
							<asp:textbox id="txtSetUpCharge" runat="server" CssClass="SmallTextBox" MaxLength="10">0.00</asp:textbox></TD>
					</TR>
					<TR>
						<TD>Art/Typesetting Charge:</TD>
						<TD align="right" width="33%" colSpan="2">$
							<asp:textbox id="txtArtCharge" runat="server" CssClass="SmallTextBox" MaxLength="10">0.00</asp:textbox></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD align="right" bgColor="#ffffff">Sub-Total:</TD>
						<TD align="right" bgColor="#ffffff"><asp:label id="lblSubTotal" runat="server"></asp:label>$
							<asp:textbox id="txtSubTotal" runat="server" CssClass="SmallTextBox" MaxLength="10">0.00</asp:textbox></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD align="right">Sales Tax:</TD>
						<TD align="right"><asp:label id="lblSalesTax" runat="server"></asp:label>$
							<asp:textbox id="txtSalesTax" runat="server" CssClass="SmallTextBox" MaxLength="10">0.00</asp:textbox></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD align="right" bgColor="#ffffff">Shipping:</TD>
						<TD align="right" bgColor="#ffffff"><asp:label id="lblShipping" runat="server"></asp:label>$
							<asp:textbox id="txtShippingAmt" runat="server" CssClass="SmallTextBox" MaxLength="10">0.00</asp:textbox></TD>
					</TR>
					<TR>
						<TD bgColor="gainsboro"></TD>
						<TD align="right" bgColor="gainsboro"><STRONG>Total Due:</STRONG></TD>
						<TD align="right" bgColor="gainsboro"><asp:label id="lblTotalDue" runat="server"></asp:label>$
							<asp:textbox id="txtTotalDue" runat="server" CssClass="SmallTextBox" MaxLength="10">0.00</asp:textbox></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD align="right" bgColor="#ffffff">Deposit:</TD>
						<TD align="right" bgColor="#ffffff">$
							<asp:textbox id="txtDeposit" runat="server" CssClass="SmallTextBox" MaxLength="10">0.00</asp:textbox></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD align="right">Balance Due:</TD>
						<TD align="right"><asp:label id="lblBalanceDue" runat="server"></asp:label>$
							<asp:textbox id="txtBalanceDue" runat="server" CssClass="SmallTextBox" MaxLength="10">0.00</asp:textbox></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD align="right"></TD>
						<TD align="right"><asp:button id="btnAccept" runat="server" CssClass="Button" Text="Accept"></asp:button></TD>
					</TR>
				</TABLE>
			</p>
			<P><asp:label id="lblMessage" runat="server" CssClass="Normal" ForeColor="Red"></asp:label><br>
			</P>
			<P><asp:validationsummary id="valErrors" runat="server" CssClass="Normal"></asp:validationsummary></P>
			<br>
			<asp:panel id="pnlImages" runat="server"></asp:panel></form>
	</body>
</HTML>
