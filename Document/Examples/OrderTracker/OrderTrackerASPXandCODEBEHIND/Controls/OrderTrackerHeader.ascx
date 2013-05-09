<%@ Control Language="c#" AutoEventWireup="false" Codebehind="OrderTrackerHeader.ascx.cs" Inherits="OrderTrackerv2.Controls.OrderTrackerHeader" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<asp:Panel id="pnlHeaderGlobal" runat="server" CssClass="HeaderOrderTracker" BackColor="Black"
	BorderStyle="None" BorderWidth="0px" Width="100%" Font-Bold="True" Font-Names="Tahoma"
	Font-Size="10pt" ForeColor="White" DESIGNTIMEDRAGDROP="24">
	<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
		<TR>
			<TD align="left">
				<asp:Image id="imgOTLeft" BorderWidth="0px" BorderStyle="None" CssClass="HeaderImage" runat="server"
					AlternateText="Screenprinting Press Header Image" ImageUrl="../Images/ordertrackerheader1.jpg"></asp:Image></TD>
			<TD align="right">
				<asp:Image id="imgOTRight" BorderWidth="0px" BorderStyle="None" CssClass="HeaderImage" runat="server"
					AlternateText="OrderTrackerLogo" ImageUrl="../Images/ordertrackerheader2.jpg"></asp:Image></TD>
		</TR>
	</TABLE>
	<asp:Label id="lblWelcome" CssClass="HeaderTitle" runat="server">Welcome to OrderTracker</asp:Label>
</asp:Panel>
<asp:Panel id="employeePanel" runat="server" BackColor="Gainsboro" HorizontalAlign="Left"></asp:Panel>
<asp:Panel id="customerPanel" runat="server" BackColor="Gainsboro"></asp:Panel>
