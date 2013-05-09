//Josh Marquis 2005
//some basic code used from Beginnning Visual Web Programming in C# by
//Daniel Cazzulino, Victor Garcia Aprea, James Greenwood, and Chris Hart
//Apress 2004

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace OrderTrackerv2.HOOemployees.Secure
{
	/// <summary>
	/// Summary description for ManageCustomers.
	/// </summary>
	public class ManageCustomers : OrderTrackerEmpBase
	{
		protected System.Web.UI.WebControls.Panel pnlCustomerList;
		protected System.Data.SqlClient.SqlConnection cnOrderTrackerDB;
		protected System.Web.UI.WebControls.DataGrid grdEmployeeList;
		protected System.Web.UI.WebControls.Panel pnlEmployeeList;
		protected System.Web.UI.WebControls.Panel pnlCustomerLinks;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected OrderTrackerv2.HOOemployees.Secure.CustData custData1;
		protected System.Data.SqlClient.SqlCommand sqlCommand2;
		protected System.Web.UI.WebControls.DataGrid grdCustomerList;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			base.HeaderMessage = "Customer List";

			sqlDataAdapter1.Fill( custData1 );
			grdCustomerList.DataBind();

			if( Context.User.Identity.IsAuthenticated )
			{
				//render the links and panel
				HyperLink reg = new HyperLink();
					
				string cra = this.Page.Request.PhysicalApplicationPath;

				//check to see if I'm in the secure portion of the site
				if( cra.IndexOf( "Secure" ) == -1 )
					reg.NavigateUrl = "CreateCustomer.aspx";
				else
					reg.NavigateUrl = "Secure/CreateCustomer.aspx";

				reg.Text = "Create a Customer";
				pnlCustomerLinks.Controls.Add( reg );
				pnlCustomerLinks.Controls.Add( new LiteralControl( "&nbsp;-&nbsp;" ) );

				reg = new HyperLink();

				//check to see if I'm in the secure portion of the site
				if( cra.IndexOf( "Secure" ) == -1 )
					reg.NavigateUrl = "CreateContact.aspx";
				else
					reg.NavigateUrl = "Secure/CreateContact.aspx";

				reg.Text = "Create a Contact Person";
				pnlCustomerLinks.Controls.Add( reg );
				pnlCustomerLinks.Controls.Add( new LiteralControl( "&nbsp;-&nbsp;" ) );

				reg = new HyperLink();

				//check to see if I'm in the secure portion of the site
				if( cra.IndexOf( "Secure" ) == -1 )
					reg.NavigateUrl = "../SearchCustomers.aspx";
				else
					reg.NavigateUrl = "SearchCustomers.aspx";

				reg.Text = "Search for a Customer";
				pnlCustomerLinks.Controls.Add( reg );
				pnlCustomerLinks.Controls.Add( new LiteralControl( "&nbsp;-&nbsp;" ) );

				reg = new HyperLink();

				//check to see if I'm in the secure portion of the site
				if( cra.IndexOf( "Secure" ) == -1 )
					reg.NavigateUrl = "../SearchContacts.aspx";
				else
					reg.NavigateUrl = "SearchContacts.aspx";

				reg.Text = "Search for a Contact";
				pnlCustomerLinks.Controls.Add( reg );
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
			this.cnOrderTrackerDB = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlCommand2 = new System.Data.SqlClient.SqlCommand();
			this.custData1 = new OrderTrackerv2.HOOemployees.Secure.CustData();
			((System.ComponentModel.ISupportInitialize)(this.custData1)).BeginInit();
			// 
			// cnOrderTrackerDB
			// 
			this.cnOrderTrackerDB.ConnectionString = ((string)(configurationAppSettings.GetValue("cnOrderTrackerDB.ConnectionString", typeof(string))));
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlCommand2;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "Customers", new System.Data.Common.DataColumnMapping[] {
																																																				   new System.Data.Common.DataColumnMapping("SID", "SID"),
																																																				   new System.Data.Common.DataColumnMapping("name", "name"),
																																																				   new System.Data.Common.DataColumnMapping("email", "email"),
																																																				   new System.Data.Common.DataColumnMapping("phone", "phone")})});
			// 
			// sqlCommand2
			// 
			this.sqlCommand2.CommandText = "SELECT SID, name, phone, email FROM dbo.Customers";
			this.sqlCommand2.Connection = this.cnOrderTrackerDB;
			// 
			// custData1
			// 
			this.custData1.DataSetName = "CustData";
			this.custData1.Locale = new System.Globalization.CultureInfo("en-US");
			this.Load += new System.EventHandler(this.Page_Load);
			((System.ComponentModel.ISupportInitialize)(this.custData1)).EndInit();

		}
		#endregion


		private void grdCustomerList_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			//set the index
			grdCustomerList.CurrentPageIndex = e.NewPageIndex;

			//fill the grid again
			sqlDataAdapter1.Fill( custData1 );
			grdCustomerList.DataBind();
		}

		private void grdCustomerList_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			sqlDataAdapter1.Fill( custData1 );
			grdCustomerList.DataBind();
		}
	}
}
