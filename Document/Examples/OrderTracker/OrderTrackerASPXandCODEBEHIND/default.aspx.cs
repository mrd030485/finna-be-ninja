//Josh Marquis 2005
//some basic code used from Beginnning Visual Web Programming in C# by
//Daniel Cazzulino, Victor Garcia Aprea, James Greenwood, and Chris Hart
//Apress 2004

using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace OrderTrackerv2
{
	/// <summary>
	/// Summary description for _default.
	/// </summary>
	public class _default : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlInputText txtLogin;
		protected System.Web.UI.HtmlControls.HtmlInputText txtPwd;
		protected System.Web.UI.HtmlControls.HtmlInputButton btnLogin;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.HtmlControls.HtmlInputText Text1;
		protected System.Web.UI.HtmlControls.HtmlInputText Password1;
		protected System.Web.UI.HtmlControls.HtmlInputButton Button1;
		protected System.Web.UI.WebControls.Panel pnlError;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			this.btnLogin.ServerClick += new System.EventHandler(this.btnLogin_ServerClick);
			this.Button1.ServerClick += new System.EventHandler(this.Button1_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_ServerClick(object sender, System.EventArgs e)
		{
			this.pnlError.Visible = true;

			SqlConnection con = new SqlConnection(
				"data source=.;initial catalog=OrderTrackerDB;" +
				"user id=webuser;pwd=theinternet" );
			SqlCommand cmd = new SqlCommand(
				@"SELECT SID FROM [Customers]
					WHERE SID=@Uid and password=@Pwd",
				con );

			//add parameters
			cmd.Parameters.Add( "@Uid", txtLogin.Value );
			cmd.Parameters.Add( "@Pwd", txtPwd.Value );
			con.Open();

			string id=null;
			string admin=null;
			string employeetype=null;

			try
			{
				//get the userid
				SqlDataReader reader = cmd.ExecuteReader();
				if( reader.Read() )
				{
					id = reader.GetString( reader.GetOrdinal("SID") );
					lblError.Text += "SID: " + id + "<br>Admin: " + admin + "<br>";
				}
			}
			finally
			{
				con.Close();
			}

			if( id!=null )
			{
				Session["Authenticated"] = "TempAuth";

				//set the user as authenticated and send him to his page
				FormsAuthentication.RedirectFromLoginPage( id, false );
				//Response.Redirect("ManageCustomers.aspx", true);
			}
			else
			{
				this.pnlError.Visible = true;
				this.lblError.Text = "Invalid User ID or password!";
			}
		}

		private void btnLogin_ServerClick(object sender, System.EventArgs e)
		{
			this.pnlError.Visible = true;

			SqlConnection con = new SqlConnection(
				"data source=.;initial catalog=OrderTrackerDB;" +
				"user id=webuser;pwd=theinternet" );
			SqlCommand cmd = new SqlCommand(
				@"SELECT UID, administrator, employeetype FROM [Employees]
					WHERE UID=@Uid and password=@Pwd",
				con );

			//add parameters
			cmd.Parameters.Add( "@Uid", txtLogin.Value );
			cmd.Parameters.Add( "@Pwd", txtPwd.Value );
			con.Open();

			string id=null;
			string admin=null;
			string employeetype=null;

			try
			{
				//get the userid
				SqlDataReader reader = cmd.ExecuteReader();
				if( reader.Read() )
				{
					id = reader.GetString( reader.GetOrdinal("UID") );
					admin = reader.GetString( reader.GetOrdinal("administrator") );
					employeetype = reader.GetString( reader.GetOrdinal("employeetype") );
					lblError.Text += "UID: " + id + "<br>Admin: " + admin + "<br>";
				}
			}
			finally
			{
				con.Close();
			}

			if( id!=null )
			{
				///////////////////////////////////////////////////////////////
				///Here we go with trying to find out if the user is an administrator
				///////////////////////////////////////////////////////////////

				if( admin == "1" )
				{
					Session["isAdministrator"] = "true";
				}
				else if( admin == "0" )
				{
					Session["isAdministrator"] = "false";
				}

				Session["employeeType"] = employeetype;

				Session["Authenticated"] = "TempAuth";

				//set the user as authenticated and send him to his page
				FormsAuthentication.RedirectFromLoginPage( id, false );
				//Response.Redirect("ManageCustomers.aspx", true);
			}
			else
			{
				this.pnlError.Visible = true;
				this.lblError.Text = "Invalid User ID or password!";
			}
		}
	}
}
