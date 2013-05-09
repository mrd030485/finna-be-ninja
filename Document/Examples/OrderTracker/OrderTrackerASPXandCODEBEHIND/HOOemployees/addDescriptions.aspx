<%@ Page language="c#" Codebehind="addDescriptions.aspx.cs" AutoEventWireup="false" Inherits="OrderTrackerv2.HOOemployees.addDescriptions" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>addArt</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/nav4-0" name="vs_targetSchema">
		<LINK href="../Style/iestyle.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<P>Enter Descriptions of the Art For the Shirt:</P>
			<P>
				<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="1">
					<TR>
						<TD><STRONG><FONT color="red">Art Approved:
									<asp:checkbox id="chkApproved" runat="server"></asp:checkbox><asp:label id="date" runat="server"></asp:label></FONT></STRONG></TD>
						<TD>&nbsp;</TD>
					</TR>
					<TR>
						<TD vAlign="bottom"><STRONG><FONT color="red">Front:</FONT></STRONG></TD>
						<TD vAlign="bottom"><STRONG><FONT color="red">Location:</FONT></STRONG>
							<asp:dropdownlist id="cbFrontLocation" runat="server" CssClass="TextBox">
								<asp:ListItem Value="None" Selected="True">None</asp:ListItem>
								<asp:ListItem Value="Left Chest">Left Chest</asp:ListItem>
								<asp:ListItem Value="Full Front">Full Front</asp:ListItem>
								<asp:ListItem Value="Center Chest">Center Chest</asp:ListItem>
								<asp:ListItem Value="Right Chest">Right Chest</asp:ListItem>
								<asp:ListItem Value="On Pocket">On Pocket</asp:ListItem>
								<asp:ListItem Value="Over Pocket">Over Pocket</asp:ListItem>
							</asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD colSpan="2"><asp:textbox id="txtFrontD" runat="server" CssClass="TextBox" Rows="10" TextMode="MultiLine"
								Width="100%">no description</asp:textbox></TD>
					</TR>
					<TR>
						<TD vAlign="bottom"><STRONG><FONT color="red">Back:</FONT></STRONG></TD>
						<TD vAlign="bottom"><STRONG><FONT color="red">Location:</FONT></STRONG>
							<asp:dropdownlist id="cbBackLocation" runat="server" CssClass="TextBox">
								<asp:ListItem Value="None" Selected="True">None</asp:ListItem>
								<asp:ListItem Value="Full Back">Full Back</asp:ListItem>
								<asp:ListItem Value="Back Neck">Back Neck</asp:ListItem>
							</asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD colSpan="2"><asp:textbox id="txtBackD" runat="server" CssClass="TextBox" Rows="10" TextMode="MultiLine" Width="100%">no description</asp:textbox></TD>
					</TR>
					<TR>
						<TD><STRONG><FONT color="red">Sleeve:</FONT></STRONG></TD>
						<TD><STRONG><FONT color="red">Location:</FONT></STRONG>
							<asp:dropdownlist id="cbSleeveLocation" runat="server" CssClass="TextBox">
								<asp:ListItem Value="None" Selected="True">None</asp:ListItem>
								<asp:ListItem Value="Left Sleeve">Left Sleeve</asp:ListItem>
								<asp:ListItem Value="Right Sleeve">Right Sleeve</asp:ListItem>
							</asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD colSpan="2"><asp:textbox id="txtSleeveD" runat="server" CssClass="TextBox" Rows="10" TextMode="MultiLine"
								Width="100%">no description</asp:textbox></TD>
					</TR>
					<TR>
						<TD vAlign="bottom"><STRONG><FONT color="red">Other:</FONT></STRONG></TD>
						<TD vAlign="bottom"></TD>
					</TR>
					<TR>
						<TD colSpan="2"><asp:textbox id="txtOtherD" runat="server" CssClass="TextBox" Rows="10" TextMode="MultiLine"
								Width="100%">no description</asp:textbox></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD align="right"><asp:button id="acceptButton" runat="server" CssClass="Button" CausesValidation="False" Text="Save Art Description"></asp:button></TD>
					</TR>
				</TABLE>
			</P>
			<P><asp:label id="lblerror" runat="server"></asp:label></P>
			<asp:validationsummary id="ValidationSummary1" runat="server" CssClass="Normal" HeaderText="Fix these errors and try again!"></asp:validationsummary></form>
	</body>
</HTML>
