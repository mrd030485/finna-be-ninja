<%@ Page language="c#" Codebehind="SearchCustomers.aspx.cs" AutoEventWireup="false" Inherits="OrderTrackerv2.HOOemployees.SearchCustomers" %>
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
					<TD vAlign="top" width="50%"><asp:panel id="pnlResults" Runat="server" CssClass="searchResults" Width="100%">Search Results: 
      <HR width="100%" SIZE="1">
<asp:Label id="lblLimit" Runat="server"></asp:Label><BR><BR>
<asp:DataGrid id=grdResults Width="100%" Runat="server" AllowPaging="True" CellPadding="4" DataMember="Order" DataSource="<%# dsResults %>">
								<SelectedItemStyle ForeColor="White" BackColor="Maroon"></SelectedItemStyle>
								<AlternatingItemStyle ForeColor="Black" BackColor="WhiteSmoke"></AlternatingItemStyle>
								<ItemStyle ForeColor="Black" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Black"></HeaderStyle>
								<Columns>
									<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
								</Columns>
							</asp:DataGrid></asp:panel></TD>
					<TD vAlign="top" width="50%"><asp:panel id="pnlSearch" runat="server">Search Customers 
      <HR width="100%" SIZE="1">

      <TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD>Customer Name:</TD>
									<TD>
										<asp:TextBox id="txtCustName" runat="server" CssClass="MediumTextBox"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD>Customer Username:</TD>
									<TD>
										<asp:TextBox id="txtCustUName" runat="server" CssClass="MediumTextBox"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD colSpan="2">
										<asp:Button id="btnSearch" runat="server" CssClass="Button" Text="Search"></asp:Button></TD>
								</TR>
							</TABLE></asp:panel></TD>
				</TR>
			</TABLE>
			<asp:Label id="lblerror" runat="server"></asp:Label>
		</form>
	</body>
</HTML>
