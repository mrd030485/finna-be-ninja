//Josh Marquis 2005
//some basic code used from Beginnning Visual Web Programming in C# by
//Daniel Cazzulino, Victor Garcia Aprea, James Greenwood, and Chris Hart
//Apress 2004

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace OrderTrackerv2.Customers
{
	/// <summary>
	/// Summary description for OrdersPending.
	/// </summary>
	public class OrdersPending : OrderTrackerCustBase
	{
		protected System.Web.UI.WebControls.Panel pnlOrdersPending;
		protected System.Data.SqlClient.SqlDataAdapter adOrdersPending;
		protected OrderTrackerv2.HOOemployees.OrdersPendingData dsOrdersPending;
		protected System.Web.UI.WebControls.HyperLink newOrder;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.DataGrid grdOrdersPending;
		protected System.Web.UI.WebControls.Label lblCust;
		protected System.Data.SqlClient.SqlConnection cnOrderTrackerDB;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			base.HeaderMessage = "Order Manager";

				// Put user code to initialize the page here
				adOrdersPending.SelectCommand.Parameters["@uid"].Value = Page.User.Identity.Name;
				adOrdersPending.Fill( dsOrdersPending );
				grdOrdersPending.DataBind();

				grdOrdersPending.Visible = true;
				lblCust.Visible = true;

			newOrder.NavigateUrl = "ViewOrder2.aspx?newOrder=true&orderNumber=-1";
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
			this.adOrdersPending = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.dsOrdersPending = new OrderTrackerv2.HOOemployees.OrdersPendingData();
			((System.ComponentModel.ISupportInitialize)(this.dsOrdersPending)).BeginInit();
			// 
			// cnOrderTrackerDB
			// 
			this.cnOrderTrackerDB.ConnectionString = ((string)(configurationAppSettings.GetValue("cnOrderTrackerDB.ConnectionString", typeof(string))));
			// 
			// adOrdersPending
			// 
			this.adOrdersPending.SelectCommand = this.sqlSelectCommand1;
			this.adOrdersPending.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "Orders", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("orderNumber", "orderNumber"),
																																																				new System.Data.Common.DataColumnMapping("dueDate", "dueDate"),
																																																				new System.Data.Common.DataColumnMapping("orderDate", "orderDate"),
																																																				new System.Data.Common.DataColumnMapping("name", "name"),
																																																				new System.Data.Common.DataColumnMapping("orderType", "orderType"),
																																																				new System.Data.Common.DataColumnMapping("rushReorderRegular", "rushReorderRegular"),
																																																				new System.Data.Common.DataColumnMapping("artFinished", "artFinished"),
																																																				new System.Data.Common.DataColumnMapping("productionFinished", "productionFinished"),
																																																				new System.Data.Common.DataColumnMapping("orderFinished", "orderFinished")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.Orders.orderNumber, dbo.Orders.dueDate, dbo.Orders.orderDate, dbo.Customers.name, dbo.Orders.orderType, dbo.Orders.rushReorderRegular, dbo.Orders.artFinished, dbo.Orders.productionFinished, dbo.Orders.orderFinished FROM dbo.Orders INNER JOIN dbo.Customers ON dbo.Orders.customerNumber = dbo.Customers.SID WHERE (dbo.Orders.insideRepNumber = @uid) OR (dbo.Orders.outsideRepNumber = @uid)";
			this.sqlSelectCommand1.Connection = this.cnOrderTrackerDB;
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@uid", System.Data.SqlDbType.VarChar, 36, "insideRepNumber"));
			// 
			// dsOrdersPending
			// 
			this.dsOrdersPending.DataSetName = "OrdersPendingData";
			this.dsOrdersPending.Locale = new System.Globalization.CultureInfo("en-US");
			this.Load += new System.EventHandler(this.Page_Load);
			((System.ComponentModel.ISupportInitialize)(this.dsOrdersPending)).EndInit();

		}
		#endregion

		private void grdOrdersPending_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			//set the index
			grdOrdersPending.CurrentPageIndex = e.NewPageIndex;

			//fill the grid again
			adOrdersPending.Fill( dsOrdersPending );
			grdOrdersPending.DataBind();
		}
	}
}
