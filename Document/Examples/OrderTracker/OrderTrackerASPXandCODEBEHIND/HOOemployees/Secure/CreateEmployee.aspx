<%@ Page language="c#" Codebehind="CreateEmployee.aspx.cs" AutoEventWireup="false" Inherits="OrderTrackerv2.HOOemployees.Secure.CreateEmployee" %>
<%@ Register TagPrefix="uc1" TagName="OrderTrackerHeader" Src="../../Controls/OrderTrackerHeader.ascx" %>
<%@ Register TagPrefix="uc1" TagName="OrderTrackerFooter" Src="../../Controls/OrderTrackerFooter.ascx" %>
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
			<P>Fill in the fields below to add a new Employee:<br>
				<b>Bold</b> fields are required!</P>
			<P>
				<TABLE id="tbNewEmployee" cellSpacing="0" cellPadding="0" width="500" border="0">
					<TR>
						<TD><STRONG>Employee Username</STRONG>:</TD>
						<TD>
							<asp:TextBox id="txtUID" runat="server" CssClass="TextBox" MaxLength="36"></asp:TextBox>
							<asp:RequiredFieldValidator id="reqUID" runat="server" ErrorMessage="A UID is required!" ControlToValidate="txtUID"
								Display="None"></asp:RequiredFieldValidator></TD>
					</TR>
					<TR>
						<TD><STRONG>Password</STRONG>:</TD>
						<TD>
							<asp:TextBox id="txtPwd" runat="server" CssClass="TextBox" TextMode="Password" MaxLength="10"></asp:TextBox>
							<asp:RequiredFieldValidator id="reqPwd" runat="server" ErrorMessage="A password is required!" ControlToValidate="txtPwd"
								Display="None"></asp:RequiredFieldValidator></TD>
					</TR>
					<TR>
						<TD><STRONG>Full Name</STRONG>:</TD>
						<TD>
							<asp:TextBox id="txtName" runat="server" CssClass="TextBox" MaxLength="40"></asp:TextBox>
							<asp:RequiredFieldValidator id="reqName" runat="server" ErrorMessage="A name is required!" ControlToValidate="txtName"
								Display="None"></asp:RequiredFieldValidator></TD>
					</TR>
					<TR>
						<TD><STRONG>Employee Type</STRONG>:</TD>
						<TD>
							<asp:TextBox id="txtEmpType" runat="server" CssClass="TextBox" MaxLength="20">Inside Sales</asp:TextBox>
							<asp:RequiredFieldValidator id="reqEmpType" runat="server" ErrorMessage="An employee type is required!" ControlToValidate="txtEmpType"
								Display="None"></asp:RequiredFieldValidator></TD>
					</TR>
					<TR>
						<TD><STRONG>Phone</STRONG>:</TD>
						<TD>
							<asp:TextBox id="txtPhone" runat="server" CssClass="TextBox" MaxLength="12">859-999-9999</asp:TextBox>
							<asp:RequiredFieldValidator id="reqPhone" runat="server" ErrorMessage="A phone number is required!" ControlToValidate="txtPhone"
								Display="None"></asp:RequiredFieldValidator>
							<asp:RegularExpressionValidator id="regPhone" runat="server" ErrorMessage="Enter a valid US Phone Number" ControlToValidate="txtPhone"
								Display="None" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"></asp:RegularExpressionValidator></TD>
					</TR>
					<TR>
						<TD><STRONG>Email</STRONG>:</TD>
						<TD>
							<asp:TextBox id="txtEmail" runat="server" CssClass="TextBox" MaxLength="30"></asp:TextBox>
							<asp:RegularExpressionValidator id="regEmail" runat="server" ErrorMessage="Enter a valid email address!" ControlToValidate="txtEmail"
								Display="None" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></TD>
					</TR>
					<TR>
						<TD><STRONG>Administrator</STRONG>:</TD>
						<TD>
							<asp:TextBox id="txtAdmin" runat="server" CssClass="TextBox" MaxLength="1">0</asp:TextBox>
							<asp:RequiredFieldValidator id="reqAdmin" runat="server" ErrorMessage="An admin option is required!" ControlToValidate="txtAdmin"
								Display="None"></asp:RequiredFieldValidator></TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<asp:Button id="btnAccept" runat="server" CssClass="Button" Text="Accept"></asp:Button></TD>
					</TR>
				</TABLE>
				<asp:Label id="lblMessage" runat="server" CssClass="Normal" ForeColor="Red"></asp:Label><br>
				<asp:ValidationSummary id="valErrors" runat="server" CssClass="Normal"></asp:ValidationSummary>
			</P>
		</form>
	</body>
</HTML>
