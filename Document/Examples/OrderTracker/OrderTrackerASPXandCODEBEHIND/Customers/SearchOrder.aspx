<%@ Page language="c#" Codebehind="SearchOrder.aspx.cs" AutoEventWireup="false" Inherits="OrderTrackerv2.Customers.SearchOrder" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SearchOrder</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/nav4-0" name="vs_targetSchema">
		<LINK href="../Style/iestyle.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="tbResults" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD vAlign="top"><asp:panel id="pnlResults" Runat="server" CssClass="searchResults">Search 
      Results: 
      <HR width="100%" SIZE="1">
<asp:Label id="lblLimit" Runat="server"></asp:Label><BR><BR>
<asp:DataGrid id=grdResults Runat="server" DataSource="<%# dsResults %>" DataMember="Order" CellPadding="4">
								<AlternatingItemStyle ForeColor="Black" BackColor="WhiteSmoke"></AlternatingItemStyle>
								<ItemStyle ForeColor="Black" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Black"></HeaderStyle>
							</asp:DataGrid></asp:panel></TD>
					<TD vAlign="top"><asp:panel id="pnlSearch" runat="server">Search Orders 
      <HR width="100%" SIZE="1">

      <TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD>Order Number:</TD>
									<TD>
										<asp:TextBox id="txtOrderNumber" runat="server" CssClass="MediumTextBox"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD>
										<P>Sales Rep Username:</P>
									</TD>
									<TD>
										<asp:TextBox id="txtSalesRepUName" runat="server" CssClass="MediumTextBox"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD>Sales Rep Name:</TD>
									<TD>
										<asp:TextBox id="txtSalesRepName" runat="server" CssClass="MediumTextBox"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD colSpan="2">
										<asp:Button id="btnSearch" runat="server" CssClass="Button" Text="Search"></asp:Button></TD>
								</TR>
							</TABLE></asp:panel></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
