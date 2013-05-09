<%@ Register TagPrefix="ap" Namespace="OrderTrackerv2" Assembly="OrderTrackerv2" %>
<%@ Register TagPrefix="uc1" TagName="OrderTrackerHeader" Src="../Controls/OrderTrackerHeader.ascx" %>
<%@ Page language="c#" Codebehind="News.aspx.cs" AutoEventWireup="false" Inherits="OrderTrackerv2.HOOemployees.News" %>
<%@ Register TagPrefix="uc1" TagName="OrderTrackerFooter" Src="../Controls/OrderTrackerFooter.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>News</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Style/iestyle.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<P>
				<uc1:OrderTrackerHeader id="OrderTrackerHeader1" runat="server" message="Welcome to the News page"></uc1:OrderTrackerHeader>
				<ap:empSubHeader id="SubHeader1" runat="server" /></P>
			<P>Welcome to the news for today!</P>
			<P>
				<uc1:OrderTrackerFooter id="OrderTrackerFooter1" runat="server"></uc1:OrderTrackerFooter></P>
		</form>
	</body>
</HTML>
