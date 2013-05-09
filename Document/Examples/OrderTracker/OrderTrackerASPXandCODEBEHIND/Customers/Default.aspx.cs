//Josh Marquis 2005
//some basic code used from Beginnning Visual Web Programming in C# by
//Daniel Cazzulino, Victor Garcia Aprea, James Greenwood, and Chris Hart
//Apress 2004

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace OrderTrackerv2.Customers
{
	/// <summary>
	/// Summary description for _Default.
	/// </summary>
	public class _Default : OrderTrackerCustBase
	{
		protected System.Web.UI.WebControls.PlaceHolder phNav;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Table tb = new Table();
			tb.Width = new Unit( 100, UnitType.Percentage );
			TableRow row;
			TableCell cell;
			
			HyperLink lnk;

			if( Context.User.Identity.IsAuthenticated )
			{
				//create a new blank table row
				row = new TableRow();

				//set up the news link
				lnk = new HyperLink();
				lnk.Text = "News";
				lnk.NavigateUrl = "News.aspx";

				//create the cell and add the link
				cell = new TableCell();
				cell.Controls.Add(lnk);

				//add the new cell to the row
				row.Cells.Add(cell);
			}
			else
			{
				//code for unauthenticated users here
			}

			//finally, add the table to the placeholder
			phNav.Controls.Add(tb);
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
