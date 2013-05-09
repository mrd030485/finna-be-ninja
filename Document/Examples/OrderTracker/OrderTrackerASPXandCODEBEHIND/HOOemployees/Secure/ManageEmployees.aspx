<%@ Page language="c#" Codebehind="ManageEmployees.aspx.cs" AutoEventWireup="false" Inherits="OrderTrackerv2.HOOemployees.Secure.ManageEmployees" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ManageEmployees</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/nav4-0">
		<LINK href="../../Style/iestyle.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Panel id="pnlEmployeeList" runat="server">
				<P>
					<asp:HyperLink id="HyperLink1" runat="server" NavigateUrl="CreateEmployee.aspx?addEmp=true">Add Employee</asp:HyperLink></P>
				<P>Here are the current employees:</P>
				<P>
					<asp:DataGrid id=grdEmployeeList runat="server" BorderColor="Gainsboro" CellPadding="4" AllowPaging="True" AutoGenerateColumns="False" DataSource="<%# dsEmployeeList %>" Width="100%">
						<AlternatingItemStyle ForeColor="Black" BackColor="WhiteSmoke"></AlternatingItemStyle>
						<ItemStyle ForeColor="Black" BackColor="White"></ItemStyle>
						<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Black"></HeaderStyle>
						<Columns>
							<asp:BoundColumn DataField="UID" SortExpression="UID" HeaderText="Username"></asp:BoundColumn>
							<asp:BoundColumn DataField="employeename" SortExpression="employeename" HeaderText="Employee Name"></asp:BoundColumn>
							<asp:BoundColumn DataField="employeetype" SortExpression="employeetype" HeaderText="Employee Type"></asp:BoundColumn>
							<asp:BoundColumn DataField="email" SortExpression="email" HeaderText="Email Address"></asp:BoundColumn>
							<asp:BoundColumn DataField="administrator" SortExpression="administrator" HeaderText="Administrator?"></asp:BoundColumn>
							<asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
						</Columns>
						<PagerStyle NextPageText="next&amp;gt;" PrevPageText="&amp;lt;previous"></PagerStyle>
					</asp:DataGrid></P>
			</asp:Panel>
		</form>
	</body>
</HTML>
