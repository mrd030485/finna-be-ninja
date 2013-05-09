<%@ Register TagPrefix="uc1" TagName="OrderTrackerFooter" Src="../../Controls/OrderTrackerFooter.ascx" %>
<%@ Register TagPrefix="uc1" TagName="OrderTrackerHeader" Src="../../Controls/OrderTrackerHeader.ascx" %>
<%@ Page language="c#" Codebehind="Login.aspx.cs" AutoEventWireup="false" Inherits="OrderTrackerv2.Customers.Login" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Login</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Style/iestyle.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<P>Fill in the fields below to login to OrderTracker:</P>
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="500" border="0">
				<TR>
					<TD>
						Customer Username:</TD>
					<TD><INPUT class="TextBox" type="text" id="txtLogin" name="Text1" runat="server"></TD>
				</TR>
				<TR>
					<TD>Customer Password:</TD>
					<TD><INPUT class="TextBox" type="password" id="txtPwd" name="Password1" runat="server"></TD>
				</TR>
				<TR>
					<TD colspan="2"><INPUT type="button" value="Login" class="Button" id="btnLogin" runat="server"></TD>
				</TR>
			</TABLE>
			<p>
				<asp:Panel ID="pnlError" Runat="server" Visible="False">
					<asp:Label id="lblError" Runat="server" ForeColor="Red"></asp:Label>
				</asp:Panel>
			</p>
		</form>
	</body>
</HTML>
