<%@ Page language="c#" Codebehind="Default.aspx.cs" AutoEventWireup="false" Inherits="OrderTrackerv2.Customers._Default" %>
<%@ Register TagPrefix="uc1" TagName="OrderTrackerHeader" Src="../Controls/OrderTrackerHeader.ascx" %>
<%@ Register TagPrefix="uc1" TagName="OrderTrackerFooter" Src="../Controls/OrderTrackerFooter.ascx" %>
<%@ Register TagPrefix="ap" Namespace="OrderTrackerv2" Assembly="OrderTrackerv2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Default</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Style/iestyle.css" type="text/css" rel="stylesheet">
		<LINK href="../Style/iestyle.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<P class="Normal">Welcome to the Customer Section of the Order Tracker!</P>
			<P class="Normal">
				<asp:PlaceHolder id="phNav" runat="server"></asp:PlaceHolder></P>
			<P>&nbsp;</P>
		</form>
	</body>
</HTML>
