//Josh Marquis 2005
//some basic code used from Beginnning Visual Web Programming in C# by
//Daniel Cazzulino, Victor Garcia Aprea, James Greenwood, and Chris Hart
//Apress 2004

namespace OrderTrackerv2.Controls
{
	using System;
	using System.Collections;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.IO;
	using System.Web;
	using System.Web.Security;
	using System.Web.SessionState;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for OrderTrackerHeader.
	/// </summary>
	public class OrderTrackerHeader : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Image imgOTLeft;
		protected System.Web.UI.WebControls.Image imgOTRight;
		protected System.Web.UI.WebControls.Label lblWelcome;
		protected System.Web.UI.WebControls.Panel employeePanel;
		protected System.Web.UI.WebControls.Panel customerPanel;
		protected System.Web.UI.WebControls.Panel pnlHeaderGlobal;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if( Context.User.Identity.IsAuthenticated )
			{
				string emptype = (string)Context.Session["employeeType"];
				string isadmin = (string)Context.Session["isAdministrator"];

				//If I'm an employee, show the employee options
				if( emptype != null )
				{
					//render the links and panel
					HyperLink reg = new HyperLink();
					
					string cra = Page.Request.PhysicalApplicationPath;

					//check to see if I'm in the secure portion of the site
					if( cra.IndexOf( "Secure" ) == -1 )
						reg.NavigateUrl = "../HOOemployees/Secure/ManageCustomers.aspx";
					else
						reg.NavigateUrl = "../../HOOemployees/Secure/ManageCustomers.aspx";

					reg.Text = "Manage Customers";
					employeePanel.Controls.Add( reg );
					employeePanel.Controls.Add( new LiteralControl( "&nbsp;-&nbsp;" ) );

					reg = new HyperLink();

					//check to see if I'm in the secure portion of the site
					if( cra.IndexOf( "Secure" ) == -1 )
						reg.NavigateUrl = "../HOOemployees/OrdersPending.aspx";
					else
						reg.NavigateUrl = "../../HOOemployees/OrdersPending.aspx";

					reg.Text = "Manage Orders";
					employeePanel.Controls.Add( reg );
					employeePanel.Controls.Add( new LiteralControl( "&nbsp;-&nbsp;" ) );

					employeePanel.Visible = true;
					customerPanel.Visible = false;
				}
				else
				{
					HyperLink reg = new HyperLink();

					string cra = Page.Request.PhysicalApplicationPath;

					//check to see if I'm in the secure portion of the site
					if( cra.IndexOf( "Secure" ) == -1 )
						reg.NavigateUrl = "../Customers/OrdersPending.aspx";
					else
						reg.NavigateUrl = "../../Customers/OrdersPending.aspx";

					reg.Text = "Manage Orders";

					customerPanel.Controls.Add( reg );
					customerPanel.Controls.Add( new LiteralControl( "&nbsp;-&nbsp;" ) );

					reg = new HyperLink();

					//check to see if I'm in the secure portion of the site
					if( cra.IndexOf( "Secure" ) == -1 )
						reg.NavigateUrl = "../HOOemployees/OrdersPending.aspx";
					else
						reg.NavigateUrl = "../../HOOemployees/OrdersPending.aspx";

					reg.Text = "Manage Orders";
					customerPanel.Controls.Add( reg );
					customerPanel.Controls.Add( new LiteralControl( "&nbsp;-&nbsp;" ) );

					employeePanel.Visible = false;
					customerPanel.Visible = true;
				}

				//if I'm an administrator show the administrator options
				if( isadmin == "true" )
				{
					//render the links and panel
					HyperLink reg = new HyperLink();

					string cra = Page.Request.PhysicalApplicationPath;

					//check to see if I'm in the secure portion of the site
					if( cra.IndexOf( "Secure" ) == -1 )
						reg.NavigateUrl = "../HOOemployees/Secure/ManageEmployees.aspx";
					else
						reg.NavigateUrl = "../../HOOemployees/Secure/ManageEmployees.aspx";

					reg.Text = "Manage Employees";
					employeePanel.Controls.Add( reg );
					employeePanel.Controls.Add( new LiteralControl( "&nbsp;-&nbsp;" ) );

					reg = new HyperLink();

					//check to see if I'm in the secure portion of the site
					if( cra.IndexOf( "Secure" ) == -1 )
						reg.NavigateUrl = "../HOOemployees/Secure/BackupDatabase.aspx";
					else
						reg.NavigateUrl = "../../HOOemployees/Secure/BackupDatabase.aspx";

					reg.Text = "Backup Database";
					employeePanel.Controls.Add( reg );
					//adminPanel.Controls.Add( new LiteralControl( "&nbsp;-&nbsp;" ) );

					employeePanel.Visible = true;
				}
				//else
					//employeePanel.Visible = false;
			}
			else
			{
				employeePanel.Visible = false;
				customerPanel.Visible = false;
			}
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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		//accessor method for the message property
		public string Message
		{
			get { return _message; }
			set { _message = value; }
		} string _message = String.Empty;

		//populate the controls with the property values
		protected override void Render( System.Web.UI.HtmlTextWriter writer )
		{
			if( Message != String.Empty )
				this.lblWelcome.Text = Message;
			base.Render( writer );
		}
	}
}
