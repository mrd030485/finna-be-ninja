<%@ Page language="c#" Codebehind="ManageCustomers.aspx.cs" AutoEventWireup="false" Inherits="OrderTrackerv2.HOOemployees.Secure.ManageCustomers" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ManageCustomers</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/nav4-0" name="vs_targetSchema">
		<LINK href="../../Style/iestyle.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<asp:panel id="pnlCustomerLinks" Runat="server"></asp:panel><asp:panel id="pnlCustomerList" runat="server">
				<P>Here are the current customers:</P>
				<P>
					<asp:DataGrid id=grdCustomerList runat="server" BorderColor="Gainsboro" CellPadding="4" AllowPaging="True" AutoGenerateColumns="False" DataSource="<%# custData1 %>" Width="100%">
						<AlternatingItemStyle ForeColor="Black" BackColor="WhiteSmoke"></AlternatingItemStyle>
						<ItemStyle ForeColor="Black" BackColor="White"></ItemStyle>
						<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Black"></HeaderStyle>
						<Columns>
							<asp:BoundColumn DataField="name" SortExpression="name" HeaderText="Customer Name"></asp:BoundColumn>
							<asp:BoundColumn DataField="SID" SortExpression="SID" HeaderText="Username"></asp:BoundColumn>
							<asp:BoundColumn DataField="phone" SortExpression="phone" HeaderText="Phone"></asp:BoundColumn>
							<asp:BoundColumn DataField="email" SortExpression="email" HeaderText="Email Address"></asp:BoundColumn>
						</Columns>
						<PagerStyle NextPageText="next&amp;gt;" PrevPageText="&amp;lt;previous"></PagerStyle>
					</asp:DataGrid></P>
			</asp:panel></form>
	</body>
</HTML>
