<%@ Page language="c#" Codebehind="handleDescription.aspx.cs" AutoEventWireup="false" Inherits="OrderTrackerv2.HOOemployees.handleDescription" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>handleDescription</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/nav4-0" name="vs_targetSchema">
		<LINK href="../Style/iestyle.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<P>Describe the artwork below:</P>
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="1">
				<TR>
					<TD><STRONG><FONT color="red">Art Approved:</FONT></STRONG>
						<asp:CheckBox id="chkApproved" runat="server"></asp:CheckBox>
						<asp:Label id="dateApproved" runat="server"></asp:Label></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD vAlign="bottom"><STRONG><FONT color="#ff0000">Front Description:
								<asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ErrorMessage="All Descriptions Are Required!"
									Display="None" ControlToValidate="txtFrontD"></asp:RequiredFieldValidator></FONT></STRONG></TD>
					<TD vAlign="bottom"><STRONG><FONT color="#ff0000">Location:</FONT></STRONG>
						<asp:DropDownList id="cbFrontL" runat="server" CssClass="textBox">
							<asp:ListItem Value="None" Selected="True">None</asp:ListItem>
							<asp:ListItem Value="Full Front">Full Front</asp:ListItem>
							<asp:ListItem Value="Center Chest">Center Chest</asp:ListItem>
							<asp:ListItem Value="Left Chest">Left Chest</asp:ListItem>
							<asp:ListItem Value="Right Chest">Right Chest</asp:ListItem>
							<asp:ListItem Value="On Pocket">On Pocket</asp:ListItem>
							<asp:ListItem Value="Over Pocket">Over Pocket</asp:ListItem>
						</asp:DropDownList></TD>
				</TR>
				<TR>
					<TD colSpan="2">
						<asp:TextBox id="txtFrontD" runat="server" CssClass="TextBox" Width="100%" TextMode="MultiLine"
							Rows="10">No description</asp:TextBox></TD>
				</TR>
				<TR>
					<TD vAlign="bottom"><STRONG><FONT color="#ff0000">Back Description:
								<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="All Descriptions Are Required!"
									Display="None" ControlToValidate="txtBackD"></asp:RequiredFieldValidator></FONT></STRONG></TD>
					<TD vAlign="bottom"><STRONG><FONT color="#ff0000">Location:</FONT></STRONG>
						<asp:DropDownList id="cbBackL" runat="server" CssClass="textBox">
							<asp:ListItem Value="None">None</asp:ListItem>
							<asp:ListItem Value="Full Back">Full Back</asp:ListItem>
							<asp:ListItem Value="Back Neck">Back Neck</asp:ListItem>
						</asp:DropDownList></TD>
				</TR>
				<TR>
					<TD colSpan="2">
						<asp:TextBox id="txtBackD" runat="server" CssClass="TextBox" Width="100%" TextMode="MultiLine"
							Rows="10">No description</asp:TextBox></TD>
				</TR>
				<TR>
					<TD vAlign="bottom"><STRONG><FONT color="#ff0000">Sleeve Description:
								<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="All Descriptions Are Required!"
									Display="None" ControlToValidate="txtSleeveD"></asp:RequiredFieldValidator></FONT></STRONG></TD>
					<TD vAlign="bottom"><STRONG><FONT color="#ff0000">Location:</FONT></STRONG>
						<asp:DropDownList id="cbSleeveL" runat="server" CssClass="textBox">
							<asp:ListItem Value="None">None</asp:ListItem>
							<asp:ListItem Value="Left Sleeve">Left Sleeve</asp:ListItem>
							<asp:ListItem Value="Right Sleeve">Right Sleeve</asp:ListItem>
						</asp:DropDownList></TD>
				</TR>
				<TR>
					<TD colSpan="2">
						<asp:TextBox id="txtSleeveD" runat="server" CssClass="TextBox" Width="100%" TextMode="MultiLine"
							Rows="10">No description</asp:TextBox></TD>
				</TR>
				<TR>
					<TD vAlign="bottom"><STRONG><FONT color="#ff0000">Other Description:
								<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="All Descriptions Are Required!"
									Display="None" ControlToValidate="txtOtherD"></asp:RequiredFieldValidator></FONT></STRONG></TD>
					<TD vAlign="bottom"></TD>
				</TR>
				<TR>
					<TD colSpan="2">
						<asp:TextBox id="txtOtherD" runat="server" CssClass="TextBox" Width="100%" TextMode="MultiLine"
							Rows="10">No description</asp:TextBox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD align="right">
						<asp:Button id="btnAddDesc" runat="server" CssClass="Button" Text="Add Description"></asp:Button></TD>
				</TR>
			</TABLE>
			<asp:Label id="lblError" runat="server" ForeColor="Red"></asp:Label>
			<asp:ValidationSummary id="ValidationSummary1" runat="server"></asp:ValidationSummary>
		</form>
	</body>
</HTML>
