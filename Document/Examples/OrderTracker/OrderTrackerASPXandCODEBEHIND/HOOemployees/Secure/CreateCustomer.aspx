<%@ Register TagPrefix="uc1" TagName="OrderTrackerFooter" Src="../../Controls/OrderTrackerFooter.ascx" %>
<%@ Register TagPrefix="uc1" TagName="OrderTrackerHeader" Src="../../Controls/OrderTrackerHeader.ascx" %>
<%@ Page language="c#" Codebehind="CreateCustomer.aspx.cs" AutoEventWireup="false" Inherits="OrderTrackerv2.HOOemployees.Secure.CreateCustomer" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CreateEmployee</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Style/iestyle.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<P>Fill in the fields below to add a new Customer:<br>
				<STRONG>Bold</STRONG> fields are required!</P>
			<P>
				<TABLE id="tbNewEmployee" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD><STRONG>Customer Username</STRONG>:</TD>
						<TD colspan="5">
							<asp:TextBox id="txtUID" runat="server" CssClass="TextBox" MaxLength="36"></asp:TextBox>
							<asp:RequiredFieldValidator id="reqUID" runat="server" ErrorMessage="A UID is required!" ControlToValidate="txtUID"
								Display="None"></asp:RequiredFieldValidator></TD>
					</TR>
					<TR>
						<TD><STRONG>Password</STRONG>:</TD>
						<TD colspan="5">
							<asp:TextBox id="txtPwd" runat="server" CssClass="TextBox" TextMode="Password" MaxLength="10"></asp:TextBox>
							<asp:RequiredFieldValidator id="reqPwd" runat="server" ErrorMessage="A password is required!" ControlToValidate="txtPwd"
								Display="None"></asp:RequiredFieldValidator></TD>
					</TR>
					<TR>
						<TD><STRONG>Name</STRONG>:</TD>
						<TD colspan="5">
							<asp:TextBox id="txtName" runat="server" CssClass="TextBox" MaxLength="40"></asp:TextBox>
							<asp:RequiredFieldValidator id="reqName" runat="server" ErrorMessage="A name is required!" ControlToValidate="txtName"
								Display="None"></asp:RequiredFieldValidator></TD>
					</TR>
					<TR>
						<TD><STRONG>Street Address</STRONG>:</TD>
						<TD colspan="5">
							<asp:TextBox id="txtStreetAddress" runat="server" CssClass="TextBox" MaxLength="40"></asp:TextBox>
							<asp:RequiredFieldValidator id="reqStreetAddr" runat="server" ErrorMessage="A Street Address is Required!" ControlToValidate="txtStreetAddress"
								Display="None"></asp:RequiredFieldValidator></TD>
					</TR>
					<TR>
						<TD><STRONG>City</STRONG>:</TD>
						<TD>
							<asp:TextBox id="txtCity" runat="server" MaxLength="20" CssClass="TextBox"></asp:TextBox></TD>
						<TD><STRONG>State:</STRONG></TD>
						<TD>
							<asp:TextBox id="txtState" runat="server" MaxLength="2" CssClass="SmallTextBox">XX</asp:TextBox>
							<asp:RequiredFieldValidator id="reqState" runat="server" Display="None" ControlToValidate="txtState" ErrorMessage="A State is Required!"></asp:RequiredFieldValidator></TD>
						<TD><STRONG>Zip Code:</STRONG></TD>
						<TD>
							<asp:TextBox id="txtZip" runat="server" MaxLength="10" CssClass="SmallTextBox">99999-9999</asp:TextBox>
							<asp:RequiredFieldValidator id="reqZip" runat="server" Display="None" ControlToValidate="txtZip" ErrorMessage="A Zip Code is Required!"></asp:RequiredFieldValidator></TD>
					</TR>
					<TR>
						<TD><STRONG>Phone</STRONG>:</TD>
						<TD colspan="5">
							<asp:TextBox id="txtPhone" runat="server" CssClass="TextBox" MaxLength="12">859-999-9999</asp:TextBox>
							<asp:RequiredFieldValidator id="reqPhone" runat="server" ErrorMessage="A phone number is required!" ControlToValidate="txtPhone"
								Display="None"></asp:RequiredFieldValidator>
							<asp:RegularExpressionValidator id="regPhone" runat="server" ErrorMessage="Enter a valid US Phone Number" ControlToValidate="txtPhone"
								Display="None" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"></asp:RegularExpressionValidator></TD>
					</TR>
					<TR>
						<TD>Cell Phone:</TD>
						<TD colspan="5">
							<asp:TextBox id="txtCellPhone" runat="server" CssClass="TextBox" MaxLength="12">859-999-9999</asp:TextBox>
							<asp:RegularExpressionValidator id="regCellPhone" runat="server" ErrorMessage="Enter a valid US Phone Number" ControlToValidate="txtCellPhone"
								Display="None" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"></asp:RegularExpressionValidator></TD>
					</TR>
					<TR>
						<TD>Fax:</TD>
						<TD colspan="5">
							<asp:TextBox id="txtFax" runat="server" CssClass="TextBox" MaxLength="12">859-999-9999</asp:TextBox>
							<asp:RegularExpressionValidator id="regFax" runat="server" ErrorMessage="Enter a valid US Phone Number" ControlToValidate="txtFax"
								Display="None" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"></asp:RegularExpressionValidator></TD>
					</TR>
					<TR>
						<TD>Email:</TD>
						<TD colspan="5">
							<asp:TextBox id="txtEmail" runat="server" CssClass="TextBox" MaxLength="30"></asp:TextBox>
							<asp:RegularExpressionValidator id="regEmail" runat="server" ErrorMessage="Enter a valid email address!" ControlToValidate="txtEmail"
								Display="None" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></TD>
					</TR>
					<TR>
						<TD align="center" colSpan="6">
							<asp:Button id="btnAccept" runat="server" CssClass="Button" Text="Accept"></asp:Button></TD>
					</TR>
				</TABLE>
				<asp:Label id="lblMessage" runat="server" CssClass="Normal" ForeColor="Red"></asp:Label><br>
				<asp:ValidationSummary id="valErrors" runat="server" CssClass="Normal"></asp:ValidationSummary>
			</P>
		</form>
	</body>
</HTML>
