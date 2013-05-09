<%@ Page language="c#" Codebehind="addArt.aspx.cs" AutoEventWireup="false" Inherits="OrderTrackerv2.HOOemployees.addArt" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>addArt</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/nav4-0">
		<LINK href="../Style/iestyle.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<P>Choose a file to upload for the art, as well as the position of the art.</P>
			<P>
				<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="50%" border="1">
					<TR>
						<TD>Position:</TD>
						<TD>
							<asp:DropDownList id="artPosition" runat="server" CssClass="TextBox">
								<asp:ListItem Value="Full Front" Selected="True">Full Front</asp:ListItem>
								<asp:ListItem Value="Center Chest">Center Chest</asp:ListItem>
								<asp:ListItem Value="Left Chest">Left Chest</asp:ListItem>
								<asp:ListItem Value="Right Chest">Right Chest</asp:ListItem>
								<asp:ListItem Value="On Pocket">On Pocket</asp:ListItem>
								<asp:ListItem Value="Over Pocket">Over Pocket</asp:ListItem>
								<asp:ListItem Value="Full Back">Full Back</asp:ListItem>
								<asp:ListItem Value="Back Neck">Back Neck</asp:ListItem>
								<asp:ListItem Value="Left Sleeve">Left Sleeve</asp:ListItem>
								<asp:ListItem Value="Right Sleeve">Right Sleeve</asp:ListItem>
								<asp:ListItem Value="Art Only">Art Only</asp:ListItem>
							</asp:DropDownList>
							<asp:RequiredFieldValidator id="reqPosition" runat="server" ErrorMessage="A Position is Required!" ControlToValidate="artPosition"
								Display="None"></asp:RequiredFieldValidator></TD>
					</TR>
					<TR>
						<TD>Artwork:</TD>
						<TD><INPUT class="button" id="uploadArtwork" type="file" runat="server"></TD>
					</TR>
					<TR>
						<TD colspan="2">
							<asp:Button id="btnUpload" runat="server" CssClass="Button" Text="Upload New Artwork"></asp:Button>
							<asp:Button id="Button1" runat="server" CssClass="Button" Text="Replace Artwork"></asp:Button></TD>
					</TR>
				</TABLE>
			</P>
			<P>
				<asp:Label id="errorlabel" runat="server"></asp:Label></P>
			<asp:ValidationSummary id="ValidationSummary1" runat="server" CssClass="Normal" HeaderText="Fix these errors and try again!"></asp:ValidationSummary>
		</form>
	</body>
</HTML>
