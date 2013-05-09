//Josh Marquis 2005
//some basic code used from Beginnning Visual Web Programming in C# by
//Daniel Cazzulino, Victor Garcia Aprea, James Greenwood, and Chris Hart
//Apress 2004

using System;
using System.IO;
using System.Web.UI;
using OrderTrackerv2.Controls;

namespace OrderTrackerv2
{
	/// <summary>
	/// Summary description for OrderTrackerEmpBase.
	/// </summary>
	public class OrderTrackerCustBase : System.Web.UI.Page
	{
		protected string HeaderMessage = String.Empty;

		protected override void Render( System.Web.UI.HtmlTextWriter writer )
		{
			//get a reference to the form control
			Control form = Page.Controls[1];

			//create and place the page header
			OrderTrackerHeader header;
			header = (OrderTrackerHeader)this.LoadControl( "~/Controls/OrderTrackerHeader.ascx" );

			header.Message = HeaderMessage;
			form.Controls.AddAt( 0, header );

			//add the subheader custom control
			form.Controls.AddAt( 1, new CustSubHeader() );

			//add space separating from the main content
			form.Controls.AddAt( 2, new LiteralControl( "<p/>" ) );
			form.Controls.AddAt( form.Controls.Count, new LiteralControl( "<p/>" ) );

			//finally add the page footer
			OrderTrackerFooter footer;
			footer = (OrderTrackerFooter)this.LoadControl( "~/Controls/OrderTrackerFooter.ascx" );
			form.Controls.AddAt( Page.Controls[1].Controls.Count, footer );

			//render
			base.Render( writer );
		}

		public OrderTrackerCustBase()
		{
			//
			// TODO: Add constructor logic here
			//
		}

	}
}
