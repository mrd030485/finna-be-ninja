<%@ Register TagPrefix="uc1" TagName="OrderTrackerFooter" Src="Controls/OrderTrackerFooter.ascx" %>
<%@ Register TagPrefix="uc1" TagName="OrderTrackerHeader" Src="Controls/OrderTrackerHeader.ascx" %>
<%@ Page language="c#" Codebehind="default.aspx.cs" AutoEventWireup="false" Inherits="OrderTrackerv2._default" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>default</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/nav4-0">
		<LINK href="Style/iestyle.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:OrderTrackerHeader id="OrderTrackerHeader1" runat="server"></uc1:OrderTrackerHeader>
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD align="center" bgColor="#ffffff">
						<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="500" border="0">
							<TR>
								<TD>Customer Username:</TD>
								<TD><INPUT class="TextBox" id="Text1" type="text" name="Text1" runat="server"></TD>
							</TR>
							<TR>
								<TD>Customer Password:</TD>
								<TD><INPUT class="TextBox" id="Password1" type="password" name="Password1" runat="server"></TD>
							</TR>
							<TR>
								<TD colSpan="2"><INPUT class="Button" id="Button1" type="button" value="Login" name="Button1" runat="server"></TD>
							</TR>
						</TABLE>
					</TD>
					<TD align="center" bgColor="gainsboro">
						<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="500" border="0">
							<TR>
								<TD>Employee Username:</TD>
								<TD><INPUT class="TextBox" id="txtLogin" type="text" name="Text1" runat="server"></TD>
							</TR>
							<TR>
								<TD>Employee Password:</TD>
								<TD><INPUT class="TextBox" id="txtPwd" type="password" name="Password1" runat="server"></TD>
							</TR>
							<TR>
								<TD colSpan="2"><INPUT class="Button" id="btnLogin" type="button" value="Login" name="btnLogin" runat="server"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<asp:Panel id="pnlError" Runat="server" Visible="False">
				<asp:Label id="lblError" Runat="server" ForeColor="Red"></asp:Label>
			</asp:Panel>
			<uc1:OrderTrackerFooter id="OrderTrackerFooter1" runat="server"></uc1:OrderTrackerFooter>
		</form>
	</body>
</HTML>
