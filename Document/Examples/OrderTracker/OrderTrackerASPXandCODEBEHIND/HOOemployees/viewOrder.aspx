<%@ Page language="c#" Codebehind="viewOrder.aspx.cs" AutoEventWireup="false" Inherits="OrderTrackerv2.HOOemployees.viewOrder" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>viewOrder</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Style/iestyle.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<P><asp:label id="createOrderLabel" runat="server" Font-Size="Smaller">Fields in <b><font color="red">Bold</font></b> are required</asp:label></P>
			<P>
				<table id="tbOrderHeader" cellSpacing="2" cellPadding="0" width="100%" border="0">
					<TR>
						<TD><STRONG><FONT color="red">Inside Rep Username:</FONT></STRONG></TD>
						<TD><asp:textbox id="txtInsideRep" runat="server" CssClass="SmallTextBox"></asp:textbox>
							<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="An Inside Rep Username is Required"
								Display="None" ControlToValidate="txtInsideRep"></asp:RequiredFieldValidator></TD>
						<TD><STRONG><FONT color="red">Outside Rep Username:</FONT></STRONG></TD>
						<TD><asp:textbox id="txtOutsideRep" runat="server" CssClass="SmallTextBox"></asp:textbox></TD>
						<TD></TD>
						<TD></TD>
					</TR>
					<tr>
						<TD bgColor="white"><STRONG><FONT color="#ff0000">Date:</FONT></STRONG></TD>
						<td bgColor="white"><STRONG><FONT color="red"></FONT></STRONG><asp:textbox id="txtDate" runat="server" CssClass="SmallTextBox">01/01/2005</asp:textbox></td>
						<TD bgColor="white"><STRONG><FONT color="#ff0000">Due Date:</FONT></STRONG></TD>
						<td bgColor="white"><STRONG><FONT color="red"></FONT></STRONG><asp:textbox id="txtDueDate" runat="server" CssClass="SmallTextBox">01/01/2005</asp:textbox></td>
						<TD bgColor="white">Rec Date:</TD>
						<td bgColor="white"><asp:textbox id="txtRecDate" runat="server" CssClass="SmallTextBox">01/01/2005</asp:textbox></td>
					</tr>
					<tr>
						<TD>Reorder No:</TD>
						<td><asp:textbox id="txtReorderNum" runat="server" CssClass="SmallTextBox" MaxLength="10"></asp:textbox></td>
						<TD>P.O.&nbsp;#:</TD>
						<td><asp:textbox id="txtPO" runat="server" CssClass="SmallTextBox" MaxLength="10"></asp:textbox></td>
						<TD>X-Order No:</TD>
						<td><asp:textbox id="txtXOrderNum" runat="server" CssClass="SmallTextBox" MaxLength="10"></asp:textbox></td>
					</tr>
					<tr>
						<TD bgColor="#ffffff">Ship Via:</TD>
						<td bgColor="#ffffff" colSpan="3"><asp:textbox id="txtShipping" runat="server" CssClass="TextBox" MaxLength="20"></asp:textbox></td>
						<TD vAlign="top" bgColor="#ffffff" rowSpan="3"><STRONG><FONT color="#ff0000">Type:</FONT></STRONG></TD>
						<td vAlign="top" bgColor="#ffffff" colSpan="2" rowSpan="3"><asp:dropdownlist id="cbType" runat="server" CssClass="TextBox" DataSource='<%# dsOrderTypes %>' DataValueField="Type" DataTextField="Type" DataMember="OrderTypes">
							</asp:dropdownlist></td>
					</tr>
					<tr>
						<TD>Artist:</TD>
						<td><asp:textbox id="txtArtist" runat="server" CssClass="SmallTextBox" MaxLength="40" ReadOnly="True"></asp:textbox></td>
						<TD>Art Due Date:</TD>
						<td><asp:textbox id="txtArtDueDate" runat="server" CssClass="SmallTextBox">01/01/2005</asp:textbox></td>
					</tr>
					<tr>
						<TD bgColor="#ffffff"><STRONG><FONT color="#ff0000">Rush/Reorder/X-Order/Regular:</FONT></STRONG></TD>
						<td bgColor="#ffffff" colSpan="3" rowSpan="2"><STRONG><FONT color="red"></FONT></STRONG><asp:dropdownlist id="cbRushRegReorder" runat="server" CssClass="TextBox" DataSource='<%# dsSpeedData %>' DataValueField="Speed" DataTextField="Speed" DataMember="SpeedTypes" ></asp:dropdownlist></td>
					</tr>
				</table>
			</P>
			<P><br>
				&nbsp;
			</P>
			<P>
				<table id="tbOrderHeader2" cellSpacing="2" cellPadding="0" width="100%" border="0">
					<tr>
						<TD><STRONG><FONT color="#ff0000">Name:</FONT></STRONG></TD>
						<td colSpan="5"><asp:textbox id="txtCustomerName" runat="server" CssClass="TextBox" MaxLength="40" ReadOnly="True"></asp:textbox><asp:linkbutton id="searchForCustomer" runat="server">Search for a Customer</asp:linkbutton></td>
					</tr>
					<tr>
						<TD bgColor="#ffffff">Contact Person:</TD>
						<td bgColor="#ffffff" colSpan="5"><asp:textbox id="txtContactName" runat="server" CssClass="TextBox" MaxLength="40" ReadOnly="True"></asp:textbox><asp:linkbutton id="searchForContact" runat="server">Search for a Contact</asp:linkbutton></td>
					</tr>
					<tr>
						<TD>Address:</TD>
						<td colSpan="5"><asp:textbox id="txtAddress" runat="server" CssClass="TextBox" MaxLength="40" ReadOnly="True"></asp:textbox></td>
					</tr>
					<tr>
						<TD bgColor="#ffffff">City:</TD>
						<td bgColor="#ffffff"><asp:textbox id="txtCity" runat="server" CssClass="SmallTextBox" MaxLength="20" ReadOnly="True"></asp:textbox></td>
						<TD bgColor="#ffffff">State:
						</TD>
						<td bgColor="#ffffff"><asp:textbox id="txtState" runat="server" CssClass="SmallTextBox" MaxLength="2" ReadOnly="True">KY</asp:textbox></td>
						<TD bgColor="#ffffff">Zip Code:
						</TD>
						<td bgColor="#ffffff"><asp:textbox id="txtZip" runat="server" CssClass="SmallTextBox" MaxLength="10" ReadOnly="True">99999</asp:textbox></td>
					</tr>
					<tr>
						<TD>Phone No:</TD>
						<td colSpan="5"><asp:textbox id="txtPhone" runat="server" CssClass="TextBox" MaxLength="12" ReadOnly="True"></asp:textbox></td>
					</tr>
					<tr>
						<TD bgColor="#ffffff">Cell Phone No:</TD>
						<td bgColor="#ffffff" colSpan="5"><asp:textbox id="txtCellPhone" runat="server" CssClass="TextBox" MaxLength="12" ReadOnly="True"></asp:textbox></td>
					</tr>
					<tr>
						<TD>Fax No:</TD>
						<td colSpan="5"><asp:textbox id="txtFax" runat="server" CssClass="TextBox" MaxLength="12" ReadOnly="True"></asp:textbox></td>
					</tr>
					<tr>
						<TD bgColor="#ffffff">Email Address:</TD>
						<td bgColor="#ffffff" colSpan="5"><asp:textbox id="txtEmail" runat="server" CssClass="TextBox" MaxLength="30" ReadOnly="True"></asp:textbox></td>
					</tr>
				</table>
			</P>
			<P>
				<asp:ValidationSummary id="ValidationSummary1" runat="server"></asp:ValidationSummary><asp:panel id="pnlShirtList" runat="server">
					<P>Here is the current shirt order list:</P>
					<P>
						<asp:DataGrid id=DataGrid1 runat="server" DataMember="ShirtOrders" DataSource="<%# dsShirtData %>" DataKeyField="totalQty" AutoGenerateColumns="False" BorderColor="WhiteSmoke" BorderWidth="2px" Width="100%">
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
								<asp:ButtonColumn Text="Delete" HeaderText="Delete Shirt" CommandName="Delete"></asp:ButtonColumn>
							</Columns>
						</asp:DataGrid>
						<asp:LinkButton id="LinkButton1" runat="server">Show Add Shirt Menu</asp:LinkButton></P>
				</asp:panel>
			<P><asp:panel id="pnlAddShirtMenu" runat="server" HorizontalAlign="Right" Visible="False">
					<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="0">
						<TR>
							<TD align="right"><STRONG><FONT color="red">Sleeve/Pocket:</FONT></STRONG></TD>
							<TD>
								<asp:DropDownList id="txtSleevePocket" runat="server" CssClass="MediumTextBox">
									<asp:ListItem Value="ss" Selected="True">Short Sleeve</asp:ListItem>
									<asp:ListItem Value="ls">Long Sleeve</asp:ListItem>
									<asp:ListItem Value="Pocket">Pocket</asp:ListItem>
								</asp:DropDownList></TD>
							<TD align="right"><STRONG><FONT color="red">2/4:</FONT></STRONG></TD>
							<TD>
								<asp:TextBox id="txt24" runat="server" CssClass="TinyTextBox">0</asp:TextBox></TD>
							<TD align="right"><STRONG><FONT color="red">6/8:</FONT></STRONG></TD>
							<TD>
								<asp:TextBox id="txt68" runat="server" CssClass="TinyTextBox">0</asp:TextBox></TD>
							<TD align="right"><STRONG><FONT color="red">10/12:</FONT></STRONG></TD>
							<TD>
								<asp:TextBox id="txt1012" runat="server" CssClass="TinyTextBox">0</asp:TextBox></TD>
							<TD align="right"><STRONG><FONT color="red">14/16:</FONT></STRONG></TD>
							<TD>
								<asp:TextBox id="txt1416" runat="server" CssClass="TinyTextBox">0</asp:TextBox></TD>
							<TD align="right"><STRONG><FONT color="red">S:</FONT></STRONG></TD>
							<TD>
								<asp:TextBox id="txtS" runat="server" CssClass="TinyTextBox">0</asp:TextBox></TD>
							<TD align="right"><STRONG><FONT color="red">M:</FONT></STRONG></TD>
							<TD>
								<asp:TextBox id="txtM" runat="server" CssClass="TinyTextBox">0</asp:TextBox></TD>
							<TD align="right"><STRONG><FONT color="red">L:</FONT></STRONG></TD>
							<TD>
								<asp:TextBox id="txtL" runat="server" CssClass="TinyTextBox">0</asp:TextBox></TD>
						</TR>
						<TR>
							<TD align="right" bgColor="#ffffff"><STRONG><FONT color="red">Type:</FONT></STRONG></TD>
							<TD bgColor="#ffffff">
								<asp:DropDownList id="txtShirtType" runat="server" CssClass="MediumTextBox">
									<asp:ListItem Value="T-Shirt" Selected="True">T-Shirt</asp:ListItem>
									<asp:ListItem Value="Sweat">Sweat</asp:ListItem>
									<asp:ListItem Value="Polo">Polo</asp:ListItem>
									<asp:ListItem Value="Cap">Cap</asp:ListItem>
								</asp:DropDownList></TD>
							<TD align="right" bgColor="#ffffff"><STRONG><FONT color="red">Color:</FONT></STRONG></TD>
							<TD bgColor="#ffffff" colSpan="5">
								<asp:TextBox id="txtColor" runat="server" CssClass="MediumTextBox">Red/Black/Etc.</asp:TextBox></TD>
							<TD align="right" bgColor="#ffffff"><STRONG><FONT color="red">XL:</FONT></STRONG></TD>
							<TD bgColor="#ffffff">
								<asp:TextBox id="txtXL" runat="server" CssClass="TinyTextBox">0</asp:TextBox></TD>
							<TD align="right" bgColor="#ffffff"><STRONG><FONT color="red">XXL:</FONT></STRONG></TD>
							<TD bgColor="#ffffff">
								<asp:TextBox id="txtXXL" runat="server" CssClass="TinyTextBox">0</asp:TextBox></TD>
							<TD align="right" bgColor="#ffffff"><STRONG><FONT color="red">XXXL:</FONT></STRONG></TD>
							<TD bgColor="#ffffff">
								<asp:TextBox id="txtXXXL" runat="server" CssClass="TinyTextBox">0</asp:TextBox></TD>
							<TD align="right" bgColor="#ffffff"><STRONG><FONT color="red">XXXXL:</FONT></STRONG></TD>
							<TD bgColor="#ffffff">
								<asp:TextBox id="txtXXXXL" runat="server" CssClass="TinyTextBox">0</asp:TextBox></TD>
						</TR>
						<TR>
							<TD align="right"><FONT color="#000000">Style #:</FONT></TD>
							<TD>
								<asp:TextBox id="txtStyleNum" runat="server" CssClass="MediumTextBox">none</asp:TextBox></TD>
							<TD align="right"><FONT color="#000000">Description:</FONT></TD>
							<TD colSpan="5">
								<asp:TextBox id="txtDescription" runat="server" CssClass="MediumTextBox">none</asp:TextBox></TD>
							<TD align="right" colSpan="3"><FONT color="red"><STRONG>Manufacturer:</STRONG></FONT></TD>
							<TD colSpan="5">
								<asp:TextBox id="txtManufacturer" runat="server" CssClass="MediumTextBox">Hanes/FruitOftheLoom/Etc</asp:TextBox></TD>
						</TR>
						<TR>
							<TD bgColor="#ffffff"></TD>
							<TD bgColor="#ffffff"></TD>
							<TD align="right" bgColor="#ffffff"><STRONG><FONT color="#ff0000">Unit Price:</FONT></STRONG></TD>
							<TD bgColor="#ffffff" colSpan="5"><FONT color="#ff0000"><FONT color="#000000">$</FONT><STRONG>
										<asp:TextBox id="txtUnitPrice" runat="server" CssClass="TinyTextBox">0</asp:TextBox></STRONG></FONT></TD>
							<TD bgColor="#ffffff" colSpan="3"><STRONG><FONT color="#ff0000"></FONT></STRONG></TD>
							<TD align="right" bgColor="#ffffff" colSpan="5">
								<asp:Button id="btnAddShirt" runat="server" CssClass="Button" Text="Add Shirt"></asp:Button></TD>
						</TR>
					</TABLE>
				</asp:panel></P>
			<P>
				<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
					<TR>
						<TD bgColor="#ffffff">Rush Charge:</TD>
						<TD align="right" width="33%" bgColor="#ffffff" colSpan="2">$
							<asp:textbox id="txtRushCharge" runat="server" CssClass="SmallTextBox" MaxLength="10">0.00</asp:textbox></TD>
					</TR>
					<TR>
						<TD>Ink Change/PMS Matching Charge:</TD>
						<TD align="right" width="33%" colSpan="2">$<asp:textbox id="txtPMSCharge" runat="server" CssClass="SmallTextBox" MaxLength="10">0.00</asp:textbox></TD>
					</TR>
					<TR>
						<TD bgColor="#ffffff">Set-Up Charge (1 charge per color per location):</TD>
						<TD align="right" width="33%" bgColor="#ffffff" colSpan="2">$<asp:textbox id="txtSetUpCharge" runat="server" CssClass="SmallTextBox" MaxLength="10">0.00</asp:textbox></TD>
					</TR>
					<TR>
						<TD>Art/Typesetting Charge:</TD>
						<TD align="right" width="33%" colSpan="2">$<asp:textbox id="txtArtCharge" runat="server" CssClass="SmallTextBox" MaxLength="10">0.00</asp:textbox></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD align="right" bgColor="#ffffff">Sub-Total:</TD>
						<TD align="right" bgColor="#ffffff"><asp:label id="lblSubTotal" runat="server"></asp:label>$<asp:textbox id="txtSubTotal" runat="server" CssClass="SmallTextBox" MaxLength="10">0.00</asp:textbox></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD align="right">Sales Tax:</TD>
						<TD align="right"><asp:label id="lblSalesTax" runat="server"></asp:label>$<asp:textbox id="txtSalesTax" runat="server" CssClass="SmallTextBox" MaxLength="10">0.00</asp:textbox></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD align="right" bgColor="#ffffff">Shipping:</TD>
						<TD align="right" bgColor="#ffffff"><asp:label id="lblShipping" runat="server"></asp:label>$<asp:textbox id="txtShippingAmt" runat="server" CssClass="SmallTextBox" MaxLength="10">0.00</asp:textbox></TD>
					</TR>
					<TR>
						<TD bgColor="gainsboro"></TD>
						<TD align="right" bgColor="gainsboro"><STRONG>Total Due:</STRONG></TD>
						<TD align="right" bgColor="gainsboro"><asp:label id="lblTotalDue" runat="server"></asp:label>$<asp:textbox id="txtTotalDue" runat="server" CssClass="SmallTextBox" MaxLength="10">0.00</asp:textbox></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD align="right" bgColor="#ffffff">Deposit:</TD>
						<TD align="right" bgColor="#ffffff">$<asp:textbox id="txtDeposit" runat="server" CssClass="SmallTextBox" MaxLength="10">0.00</asp:textbox></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD align="right">Balance Due:</TD>
						<TD align="right"><asp:label id="lblBalanceDue" runat="server"></asp:label>$<asp:textbox id="txtBalanceDue" runat="server" CssClass="SmallTextBox" MaxLength="10">0.00</asp:textbox></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD align="right"></TD>
						<TD align="right"><asp:button id="btnAddUpdate" runat="server" CssClass="Button" Text="AddOrder"></asp:button></TD>
					</TR>
				</TABLE>
				<asp:panel id="pnlProduction" runat="server">
					<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" border="0">
						<TR>
							<TD>Total Colors Front:</TD>
							<TD>
								<asp:TextBox id="txtColorsFront" runat="server" CssClass="TinyTextBox">0</asp:TextBox></TD>
							<TD>Total Colors Back:</TD>
							<TD>
								<asp:TextBox id="txtColorsBack" runat="server" CssClass="TinyTextBox">0</asp:TextBox></TD>
						</TR>
						<TR>
							<TD>Total Colors Sleeve:</TD>
							<TD>
								<asp:TextBox id="txtColorsSleeve" runat="server" CssClass="TinyTextBox">0</asp:TextBox></TD>
							<TD></TD>
							<TD></TD>
						</TR>
						<TR>
							<TD></TD>
							<TD></TD>
							<TD></TD>
							<TD></TD>
						</TR>
					</TABLE>
				</asp:panel></P>
			<asp:panel id="pnlImages" runat="server"></asp:panel><asp:label id="lblerror" runat="server"></asp:label></form>
	</body>
</HTML>
