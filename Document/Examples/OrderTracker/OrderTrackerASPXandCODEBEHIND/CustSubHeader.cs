using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrderTrackerv2.Controls;

namespace OrderTrackerv2
{
	/// <summary>
	/// Summary description for CustSubHeader.
	/// </summary>
	public class CustSubHeader : WebControl
	{
		public CustSubHeader()
		{
			this.Width = new Unit( 100, UnitType.Percentage );
			this.CssClass = "SubHeader";
		}

		//property to allow user to define the URL for the add employee page
		public string addEmpUrl
		{
			get { return _addemp; }
			set { _addemp = value; }
		} string _addemp = string.Empty;

		//this method is called when the control is being built
		protected override void CreateChildControls()
		{
				Label lbl;
				HyperLink reg = new HyperLink();

				int controlCount=0;

				//if the user is authenticated, we will render their name
				if( !Context.User.Identity.IsAuthenticated )
				{
					reg.NavigateUrl = Context.Request.ApplicationPath +
						Path.AltDirectorySeparatorChar + "Customers" +
						Path.AltDirectorySeparatorChar + "Secure" +
						Path.AltDirectorySeparatorChar + "Login.aspx";

					reg.Text = "Login";

					this.Controls.AddAt( controlCount, reg );
					controlCount++;
					//add a couple of blank spaces and a separator char
					this.Controls.AddAt( controlCount, new LiteralControl( "&nbsp;-&nbsp;" ) );
					controlCount++;

					HyperLink logout = new HyperLink();
					logout.NavigateUrl = Context.Request.ApplicationPath + 
						Path.AltDirectorySeparatorChar + "Logout.aspx";

					logout.Text = "Logout";

					this.Controls.AddAt( controlCount, reg );
					controlCount++;
					//add a couple of blank spaces and a separator char
					this.Controls.AddAt( controlCount, new LiteralControl( "&nbsp;-&nbsp;" ) );
					controlCount++;
				}

				this.Controls.AddAt( controlCount, new LiteralControl( Page.User.Identity.Name ) );
				controlCount++;

				//add a couple of blank spaces and a separator char
				this.Controls.Add( new LiteralControl( "&nbsp;-&nbsp;" ) );

				//add a label with the current data
				lbl = new Label();
				lbl.Text = DateTime.Now.ToLongDateString();
				this.Controls.Add( lbl );
		}
	}
}
