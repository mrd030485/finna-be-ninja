<%@ Page language="c#" Codebehind="addDescriptions2.aspx.cs" AutoEventWireup="false" Inherits="OrderTrackerv2.HOOemployees.addDescriptions2" %>
<%@ Register TagPrefix="uc1" TagName="OrderTrackerHeader" Src="../Controls/OrderTrackerHeader.ascx" %>
<%@ Register TagPrefix="uc1" TagName="OrderTrackerFooter" Src="../Controls/OrderTrackerFooter.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Add/Update Art Description</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Style/iestyle.css" type="text/css" rel="stylesheet">
		<LINK href="../Style/iestyle.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<P>
				Describe the art below:</P>
			<P>
				<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="1">
					<TR>
						<TD><STRONG><FONT color="red">Art Approved:
									<asp:checkbox id="chkApproved" runat="server"></asp:checkbox>
									<asp:label id="date" runat="server"></asp:label></FONT></STRONG></TD>
						<TD>&nbsp;</TD>
					</TR>
					<TR>
						<TD vAlign="bottom"><STRONG><FONT color="red">Front:
									<asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" Display="None" ControlToValidate="txtFrontD"
										ErrorMessage="A Description is Required!"></asp:RequiredFieldValidator></FONT></STRONG></TD>
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
						<TD colSpan="2">
							<asp:textbox id="txtFrontD" runat="server" CssClass="TextBox" TextMode="MultiLine" Width="100%"
								Rows="10" EnableViewState="False">no description</asp:textbox></TD>
					</TR>
					<TR>
						<TD vAlign="bottom"><STRONG><FONT color="red">Back:
									<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" Display="None" ControlToValidate="txtBackD"
										ErrorMessage="A Description is Required!"></asp:RequiredFieldValidator></FONT></STRONG></TD>
						<TD vAlign="bottom"><STRONG><FONT color="red">Location:</FONT></STRONG>
							<asp:dropdownlist id="cbBackLocation" runat="server" CssClass="TextBox">
								<asp:ListItem Value="None" Selected="True">None</asp:ListItem>
								<asp:ListItem Value="Full Back">Full Back</asp:ListItem>
								<asp:ListItem Value="Back Neck">Back Neck</asp:ListItem>
							</asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<asp:textbox id="txtBackD" runat="server" CssClass="TextBox" TextMode="MultiLine" Width="100%"
								Rows="10" EnableViewState="False">no description</asp:textbox></TD>
					</TR>
					<TR>
						<TD><STRONG><FONT color="red">Sleeve:
									<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" Display="None" ControlToValidate="txtSleeveD"
										ErrorMessage="A Description is Required!"></asp:RequiredFieldValidator></FONT></STRONG></TD>
						<TD><STRONG><FONT color="red">Location:</FONT></STRONG>
							<asp:dropdownlist id="cbSleeveLocation" runat="server" CssClass="TextBox">
								<asp:ListItem Value="None" Selected="True">None</asp:ListItem>
								<asp:ListItem Value="Left Sleeve">Left Sleeve</asp:ListItem>
								<asp:ListItem Value="Right Sleeve">Right Sleeve</asp:ListItem>
							</asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<asp:textbox id="txtSleeveD" runat="server" CssClass="TextBox" TextMode="MultiLine" Width="100%"
								Rows="10" EnableViewState="False">no description</asp:textbox></TD>
					</TR>
					<TR>
						<TD vAlign="bottom"><STRONG><FONT color="red">Other:
									<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" Display="None" ControlToValidate="txtOtherD"
										ErrorMessage="A Description is Required!"></asp:RequiredFieldValidator></FONT></STRONG></TD>
						<TD vAlign="bottom">&nbsp;</TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<asp:textbox id="txtOtherD" runat="server" CssClass="TextBox" TextMode="MultiLine" Width="100%"
								Rows="10" EnableViewState="False">no description</asp:textbox></TD>
					</TR>
					<TR>
						<TD>&nbsp;</TD>
						<TD align="right">
							<asp:button id="acceptButton" runat="server" CssClass="Button" Text="Save Art Description"></asp:button></TD>
					</TR>
				</TABLE>
			</P>
			<P>
				<asp:Label id="lblerror" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
				<br>
				<asp:ValidationSummary id="ValidationSummary1" runat="server"></asp:ValidationSummary>
				<br>
			</P>
		</form>
	</body>
</HTML>
