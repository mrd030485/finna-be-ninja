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
	/// Summary description for ManageEmployees.
	/// </summary>
	public class ManageEmployees : OrderTrackerEmpBase
	{
		protected System.Web.UI.WebControls.Panel pnlEmployeeList;
		protected System.Data.SqlClient.SqlConnection cnOrderTrackerDB;
		protected System.Data.SqlClient.SqlDataAdapter adEmployeeList;
		protected System.Data.SqlClient.SqlCommand cmdEmployeeList;
		protected OrderTrackerv2.HOOemployees.Secure.employeeListData dsEmployeeList;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.WebControls.DataGrid grdEmployeeList;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			base.HeaderMessage = "Employee List";

			adEmployeeList.Fill( dsEmployeeList );
			grdEmployeeList.DataBind();
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
			this.adEmployeeList = new System.Data.SqlClient.SqlDataAdapter();
			this.cmdEmployeeList = new System.Data.SqlClient.SqlCommand();
			this.dsEmployeeList = new OrderTrackerv2.HOOemployees.Secure.employeeListData();
			((System.ComponentModel.ISupportInitialize)(this.dsEmployeeList)).BeginInit();
			this.grdEmployeeList.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.grdEmployeeList_UpdateCommand);
			this.grdEmployeeList.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.grdEmployeeList_DeleteCommand);
			// 
			// cnOrderTrackerDB
			// 
			this.cnOrderTrackerDB.ConnectionString = ((string)(configurationAppSettings.GetValue("cnOrderTrackerDB.ConnectionString", typeof(string))));
			// 
			// adEmployeeList
			// 
			this.adEmployeeList.SelectCommand = this.cmdEmployeeList;
			this.adEmployeeList.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									 new System.Data.Common.DataTableMapping("Table", "Employees", new System.Data.Common.DataColumnMapping[] {
																																																				  new System.Data.Common.DataColumnMapping("UID", "UID"),
																																																				  new System.Data.Common.DataColumnMapping("password", "password"),
																																																				  new System.Data.Common.DataColumnMapping("employeename", "employeename"),
																																																				  new System.Data.Common.DataColumnMapping("employeetype", "employeetype"),
																																																				  new System.Data.Common.DataColumnMapping("phone", "phone"),
																																																				  new System.Data.Common.DataColumnMapping("email", "email"),
																																																				  new System.Data.Common.DataColumnMapping("administrator", "administrator")})});
			// 
			// cmdEmployeeList
			// 
			this.cmdEmployeeList.CommandText = "SELECT UID, password, employeename, employeetype, phone, email, administrator FRO" +
				"M dbo.Employees";
			this.cmdEmployeeList.Connection = this.cnOrderTrackerDB;
			// 
			// dsEmployeeList
			// 
			this.dsEmployeeList.DataSetName = "employeeListData";
			this.dsEmployeeList.Locale = new System.Globalization.CultureInfo("en-US");
			this.Load += new System.EventHandler(this.Page_Load);
			((System.ComponentModel.ISupportInitialize)(this.dsEmployeeList)).EndInit();

		}
		#endregion


		private void grdEmployeeList_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			//set the index
			grdEmployeeList.CurrentPageIndex = e.NewPageIndex;

			//fill the grid again
			adEmployeeList.Fill( dsEmployeeList );
			grdEmployeeList.DataBind();
		}

		private void grdEmployeeList_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
				// e.Item is the row of the table where the button was 
				// clicked.
				string myUID = e.Item.Cells[0].Text.ToString();
   
				if (e.CommandName == "Delete")
				{
					// Add code here to delete an employee
					SqlConnection con = new SqlConnection(
						"data source=.;initial catalog=OrderTrackerDB;" +
						"user id=webuser;pwd=theinternet" );
					SqlCommand cmd = new SqlCommand(
						"DELETE FROM [Employees] WHERE UID=@id", con );
					cmd.Parameters.Add( "@id", myUID );

					con.Open();
					try
					{
						int a = cmd.ExecuteNonQuery();
					}
					finally
					{
						//close the connection
						con.Close();
					}
				}

				dsEmployeeList.Reset();
				adEmployeeList.Fill( dsEmployeeList );
				grdEmployeeList.DataBind();
		}

		private void grdEmployeeList_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			adEmployeeList.Fill( dsEmployeeList );
			grdEmployeeList.DataBind();
		}
	}
}
