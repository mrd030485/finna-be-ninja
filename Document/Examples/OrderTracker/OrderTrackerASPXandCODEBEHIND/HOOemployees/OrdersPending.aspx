<%@ Page language="c#" Codebehind="OrdersPending.aspx.cs" AutoEventWireup="false" Inherits="OrderTrackerv2.HOOemployees.OrdersPending" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>OrdersPending</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Style/iestyle.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Panel id="pnlOrdersPending" runat="server">
				<P>
					<asp:HyperLink id="newOrder" runat="server">Create a New Order</asp:HyperLink>&nbsp;
					<asp:HyperLink id="HyperLink1" runat="server" NavigateUrl="SearchOrder.aspx">Search Orders</asp:HyperLink></P>
				<P>Here are your pending orders:</P>
				<P>
					<asp:Label id="lblSales" runat="server">Sales Orders Pending</asp:Label><BR>
					<asp:DataGrid id=grdOrdersPending runat="server" DataSource="<%# dsOrdersPending %>" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" BorderColor="Gainsboro" Width="100%">
						<AlternatingItemStyle ForeColor="Black" BackColor="WhiteSmoke"></AlternatingItemStyle>
						<ItemStyle ForeColor="Black" BackColor="White"></ItemStyle>
						<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Black"></HeaderStyle>
						<Columns>
							<asp:BoundColumn DataField="orderNumber" SortExpression="orderNumber" HeaderText="Order Number"></asp:BoundColumn>
							<asp:BoundColumn DataField="orderDate" SortExpression="orderDate" HeaderText="Order Date" DataFormatString="{0:d}"></asp:BoundColumn>
							<asp:BoundColumn DataField="dueDate" SortExpression="dueDate" HeaderText="Due Date" DataFormatString="{0:d}"></asp:BoundColumn>
							<asp:BoundColumn DataField="name" SortExpression="name" HeaderText="Customer Name"></asp:BoundColumn>
							<asp:BoundColumn DataField="orderType" SortExpression="orderType" HeaderText="Order Type">
								<ItemStyle HorizontalAlign="Center"></ItemStyle>
							</asp:BoundColumn>
							<asp:BoundColumn DataField="rushReorderRegular" SortExpression="rushReorderRegular" HeaderText="Rush/Reorder/Regular">
								<ItemStyle HorizontalAlign="Center"></ItemStyle>
							</asp:BoundColumn>
							<asp:HyperLinkColumn Text="View/Edit" DataNavigateUrlField="orderNumber" DataNavigateUrlFormatString="ViewOrder2.aspx?orderNumber={0}&amp;newOrder=false"
								HeaderText="View/Edit Order"></asp:HyperLinkColumn>
						</Columns>
						<PagerStyle NextPageText="next&amp;gt;" PrevPageText="&amp;lt;previous" HorizontalAlign="Left"></PagerStyle>
					</asp:DataGrid></P>
				<P>
					<asp:Label id="lblArt" runat="server">Art Orders Pending</asp:Label><BR>
					<asp:DataGrid id=grdArtPending runat="server" DataSource="<%# dsArtPending %>" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" BorderColor="Gainsboro" Width="100%">
						<AlternatingItemStyle ForeColor="Black" BackColor="WhiteSmoke"></AlternatingItemStyle>
						<ItemStyle ForeColor="Black" BackColor="White"></ItemStyle>
						<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Black"></HeaderStyle>
						<Columns>
							<asp:BoundColumn DataField="orderNumber" HeaderText="Order Number"></asp:BoundColumn>
							<asp:BoundColumn DataField="dueDate" HeaderText="Due Date" DataFormatString="{0:d}"></asp:BoundColumn>
							<asp:BoundColumn DataField="artDueDate" HeaderText="Art Due Date" DataFormatString="{0:d}"></asp:BoundColumn>
							<asp:BoundColumn DataField="reorderNumber" HeaderText="Reorder Number"></asp:BoundColumn>
							<asp:BoundColumn DataField="rushReorderRegular" HeaderText="Rush/Reorder/Regular"></asp:BoundColumn>
							<asp:BoundColumn DataField="orderType" HeaderText="Order Type"></asp:BoundColumn>
							<asp:BoundColumn DataField="customerNumber" HeaderText="Customer Number"></asp:BoundColumn>
							<asp:BoundColumn DataField="artFinished" HeaderText="Art Finished"></asp:BoundColumn>
							<asp:BoundColumn DataField="productionFinished" HeaderText="Production Finished"></asp:BoundColumn>
							<asp:BoundColumn DataField="orderFinished" HeaderText="Order Finished"></asp:BoundColumn>
							<asp:HyperLinkColumn Text="View/Edit" DataNavigateUrlField="orderNumber" DataNavigateUrlFormatString="ViewOrder2.aspx?orderNumber={0}&amp;newOrder=false"
								HeaderText="View/Edit Order"></asp:HyperLinkColumn>
						</Columns>
						<PagerStyle NextPageText="next&amp;gt;" PrevPageText="&amp;lt;previous" HorizontalAlign="Left"></PagerStyle>
					</asp:DataGrid></P>
				<P>
					<asp:Label id="lblProduction" runat="server">Production Orders Pending</asp:Label><BR>
					<asp:DataGrid id=grdProductionPending runat="server" DataSource="<%# dsProductionPending %>" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" BorderColor="Gainsboro" Width="100%">
						<AlternatingItemStyle ForeColor="Black" BackColor="WhiteSmoke"></AlternatingItemStyle>
						<ItemStyle ForeColor="Black" BackColor="White"></ItemStyle>
						<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Black"></HeaderStyle>
						<Columns>
							<asp:BoundColumn DataField="orderNumber" SortExpression="orderNumber" HeaderText="Order Number"></asp:BoundColumn>
							<asp:BoundColumn DataField="orderDate" SortExpression="orderDate" HeaderText="Order Date" DataFormatString="{0:d}"></asp:BoundColumn>
							<asp:BoundColumn DataField="dueDate" SortExpression="dueDate" HeaderText="Due Date" DataFormatString="{0:d}"></asp:BoundColumn>
							<asp:BoundColumn DataField="customerNumber" SortExpression="customerNumber" HeaderText="Customer Number"></asp:BoundColumn>
							<asp:BoundColumn DataField="rushReorderRegular" SortExpression="rushReorderRegular" HeaderText="Rush/Reorder/Regular">
								<ItemStyle HorizontalAlign="Center"></ItemStyle>
							</asp:BoundColumn>
							<asp:BoundColumn DataField="artFinished" SortExpression="artFinished" HeaderText="Art Finished"></asp:BoundColumn>
							<asp:BoundColumn DataField="productionFinished" SortExpression="productionFinished" HeaderText="Production Finished"></asp:BoundColumn>
							<asp:BoundColumn DataField="orderFinished" SortExpression="orderFinished" HeaderText="Order Finished"></asp:BoundColumn>
							<asp:HyperLinkColumn Text="View/Edit" DataNavigateUrlField="orderNumber" DataNavigateUrlFormatString="ViewOrder2.aspx?orderNumber={0}&amp;newOrder=false"
								HeaderText="View/Edit Order"></asp:HyperLinkColumn>
						</Columns>
						<PagerStyle NextPageText="next&amp;gt;" PrevPageText="&amp;lt;previous" HorizontalAlign="Left"></PagerStyle>
					</asp:DataGrid></P>
				<P>
					<asp:Label id="lblManagement" runat="server">Management Orders Pending</asp:Label><BR>
					<asp:DataGrid id=grdManagementPending runat="server" DataSource="<%# dsManagementPending %>" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" BorderColor="Gainsboro" Width="100%" PageSize="3">
						<AlternatingItemStyle ForeColor="Black" BackColor="WhiteSmoke"></AlternatingItemStyle>
						<ItemStyle ForeColor="Black" BackColor="White"></ItemStyle>
						<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Black"></HeaderStyle>
						<Columns>
							<asp:BoundColumn DataField="orderNumber" SortExpression="orderNumber" HeaderText="Order Number"></asp:BoundColumn>
							<asp:BoundColumn DataField="orderDate" SortExpression="orderDate" HeaderText="Order Date" DataFormatString="{0:d}"></asp:BoundColumn>
							<asp:BoundColumn DataField="dueDate" SortExpression="dueDate" HeaderText="Due Date" DataFormatString="{0:d}"></asp:BoundColumn>
							<asp:BoundColumn DataField="recDate" SortExpression="recDate" HeaderText="Rec Date" DataFormatString="{0:d}"></asp:BoundColumn>
							<asp:BoundColumn DataField="rushReorderRegular" SortExpression="rushReorderRegular" HeaderText="Rush/Reorder/Regular"></asp:BoundColumn>
							<asp:BoundColumn DataField="orderType" SortExpression="orderType" HeaderText="Order Type"></asp:BoundColumn>
							<asp:BoundColumn DataField="customerNumber" SortExpression="customerNumber" HeaderText="Customer Number"></asp:BoundColumn>
							<asp:BoundColumn DataField="totalDue" SortExpression="totalDue" HeaderText="Total Due"></asp:BoundColumn>
							<asp:BoundColumn DataField="balanceDue" SortExpression="balanceDue" HeaderText="Balance Due"></asp:BoundColumn>
							<asp:BoundColumn DataField="artFinished" SortExpression="artFinished" HeaderText="Art Finished"></asp:BoundColumn>
							<asp:BoundColumn DataField="productionFinished" SortExpression="productionFinished" HeaderText="Production Finished"></asp:BoundColumn>
							<asp:BoundColumn DataField="orderFinished" SortExpression="orderFinished" HeaderText="Order Finished"></asp:BoundColumn>
							<asp:HyperLinkColumn Text="View/Edit" DataNavigateUrlField="orderNumber" DataNavigateUrlFormatString="ViewOrder2.aspx?orderNumber={0}&amp;newOrder=false"
								HeaderText="View/Edit Order"></asp:HyperLinkColumn>
						</Columns>
						<PagerStyle NextPageText="next&amp;gt;" PrevPageText="&amp;lt;previous" HorizontalAlign="Left"></PagerStyle>
					</asp:DataGrid></P>
			</asp:Panel>
		</form>
	</body>
</HTML>
