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

namespace OrderTrackerv2.HOOemployees
{
	/// <summary>
	/// Summary description for OrdersPending.
	/// </summary>
	public class OrdersPending : OrderTrackerEmpBase
	{
		protected System.Web.UI.WebControls.Panel pnlOrdersPending;
		protected System.Data.SqlClient.SqlDataAdapter adOrdersPending;
		protected OrderTrackerv2.HOOemployees.OrdersPendingData dsOrdersPending;
		protected System.Web.UI.WebControls.HyperLink newOrder;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.WebControls.DataGrid grdArtPending;
		protected System.Web.UI.WebControls.DataGrid grdProductionPending;
		protected System.Web.UI.WebControls.DataGrid grdManagementPending;
		protected System.Web.UI.WebControls.Label lblSales;
		protected System.Web.UI.WebControls.Label lblArt;
		protected System.Web.UI.WebControls.Label lblProduction;
		protected System.Web.UI.WebControls.Label lblManagement;
		protected System.Data.SqlClient.SqlDataAdapter adProductionPending;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected OrderTrackerv2.HOOemployees.ProdData dsProductionPending;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.DataGrid grdOrdersPending;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlDataAdapter adArtPending;
		protected OrderTrackerv2.HOOemployees.ArtPendingData dsArtPending;
		protected System.Data.SqlClient.SqlDataAdapter adManagementPending;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected OrderTrackerv2.HOOemployees.ManagementPendingData dsManagementPending;
		protected System.Data.SqlClient.SqlConnection cnOrderTrackerDB;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			base.HeaderMessage = "Order Manager";

			//show the correct grid depending on the user
			if( Session["employeetype"].ToString().Trim() == "Inside Sales" ||
				Session["employeetype"].ToString().Trim() == "Outside Sales" )
			{
				// Put user code to initialize the page here
				adOrdersPending.SelectCommand.Parameters["@uid"].Value = Page.User.Identity.Name;
				adOrdersPending.Fill( dsOrdersPending );
				grdOrdersPending.DataBind();

				grdArtPending.Visible = false;
				lblArt.Visible = false;
				grdOrdersPending.Visible = true;
				lblSales.Visible = true;
				grdProductionPending.Visible = false;
				lblProduction.Visible = false;
				grdManagementPending.Visible = false;
				lblManagement.Visible = false;
			}
			else if( Session["employeetype"].ToString().Trim() == "Art" )
			{
				// Put user code to initialize the page here
				adArtPending.Fill( dsArtPending );
				grdArtPending.DataBind();

				grdArtPending.Visible = true;
				lblArt.Visible = true;
				grdOrdersPending.Visible = false;
				lblSales.Visible = false;
				grdProductionPending.Visible = false;
				lblProduction.Visible = false;
				grdManagementPending.Visible = false;
				lblManagement.Visible = false;
			}
			else if( Session["employeetype"].ToString().Trim() == "Production" )
			{
				// Put user code to initialize the page here
				adProductionPending.Fill( dsProductionPending );
				grdProductionPending.DataBind();

				grdArtPending.Visible = false;
				lblArt.Visible = false;
				grdOrdersPending.Visible = false;
				lblSales.Visible = false;
				grdProductionPending.Visible = true;
				lblProduction.Visible = true;
				grdManagementPending.Visible = false;
				lblManagement.Visible = false;
			}
			else if( Session["employeetype"].ToString().Trim() == "Management" )
			{
				// Put user code to initialize the page here
				adManagementPending.Fill( dsManagementPending );
				grdManagementPending.DataBind();

				grdArtPending.Visible = false;
				lblArt.Visible = false;
				grdOrdersPending.Visible = false;
				lblSales.Visible = false;
				grdProductionPending.Visible = false;
				lblProduction.Visible = false;
				grdManagementPending.Visible = true;
				lblManagement.Visible = true;
			}
			else if( Session["employeetype"].ToString().Trim() == "Administrator" )
			{
				adOrdersPending.SelectCommand.Parameters["@uid"].Value = Page.User.Identity.Name;
				adOrdersPending.Fill( dsOrdersPending );
				grdOrdersPending.DataBind();
				adManagementPending.Fill( dsManagementPending );
				grdManagementPending.DataBind();
				adProductionPending.Fill( dsProductionPending );
				grdProductionPending.DataBind();
				adArtPending.Fill( dsArtPending );
				grdArtPending.DataBind();

				grdArtPending.Visible = true;
				lblArt.Visible = true;
				grdOrdersPending.Visible = true;
				lblSales.Visible = true;
				grdProductionPending.Visible = true;
				lblProduction.Visible = true;
				grdManagementPending.Visible = true;
				lblManagement.Visible = true;
			}

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
			this.adProductionPending = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.dsProductionPending = new OrderTrackerv2.HOOemployees.ProdData();
			this.adArtPending = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.dsArtPending = new OrderTrackerv2.HOOemployees.ArtPendingData();
			this.adManagementPending = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.dsManagementPending = new OrderTrackerv2.HOOemployees.ManagementPendingData();
			((System.ComponentModel.ISupportInitialize)(this.dsOrdersPending)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsProductionPending)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsArtPending)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsManagementPending)).BeginInit();
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
			// 
			// adProductionPending
			// 
			this.adProductionPending.SelectCommand = this.sqlSelectCommand2;
			this.adProductionPending.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										  new System.Data.Common.DataTableMapping("Table", "Orders", new System.Data.Common.DataColumnMapping[] {
																																																					new System.Data.Common.DataColumnMapping("orderNumber", "orderNumber"),
																																																					new System.Data.Common.DataColumnMapping("dueDate", "dueDate"),
																																																					new System.Data.Common.DataColumnMapping("orderDate", "orderDate"),
																																																					new System.Data.Common.DataColumnMapping("artDueDate", "artDueDate"),
																																																					new System.Data.Common.DataColumnMapping("rushReorderRegular", "rushReorderRegular"),
																																																					new System.Data.Common.DataColumnMapping("customerNumber", "customerNumber"),
																																																					new System.Data.Common.DataColumnMapping("numColorsFront", "numColorsFront"),
																																																					new System.Data.Common.DataColumnMapping("numColorsBack", "numColorsBack"),
																																																					new System.Data.Common.DataColumnMapping("numColorsSleeve", "numColorsSleeve"),
																																																					new System.Data.Common.DataColumnMapping("artFinished", "artFinished"),
																																																					new System.Data.Common.DataColumnMapping("productionFinished", "productionFinished"),
																																																					new System.Data.Common.DataColumnMapping("orderFinished", "orderFinished")})});
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT orderNumber, dueDate, orderDate, artDueDate, rushReorderRegular, customerN" +
				"umber, numColorsFront, numColorsBack, numColorsSleeve, artFinished, productionFi" +
				"nished, orderFinished FROM dbo.Orders WHERE (productionFinished = 0)";
			this.sqlSelectCommand2.Connection = this.cnOrderTrackerDB;
			// 
			// dsProductionPending
			// 
			this.dsProductionPending.DataSetName = "ProdData";
			this.dsProductionPending.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// adArtPending
			// 
			this.adArtPending.SelectCommand = this.sqlSelectCommand3;
			this.adArtPending.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								   new System.Data.Common.DataTableMapping("Table", "Orders", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("orderNumber", "orderNumber"),
																																																			 new System.Data.Common.DataColumnMapping("dueDate", "dueDate"),
																																																			 new System.Data.Common.DataColumnMapping("reorderNumber", "reorderNumber"),
																																																			 new System.Data.Common.DataColumnMapping("artDueDate", "artDueDate"),
																																																			 new System.Data.Common.DataColumnMapping("rushReorderRegular", "rushReorderRegular"),
																																																			 new System.Data.Common.DataColumnMapping("orderType", "orderType"),
																																																			 new System.Data.Common.DataColumnMapping("customerNumber", "customerNumber"),
																																																			 new System.Data.Common.DataColumnMapping("artFinished", "artFinished"),
																																																			 new System.Data.Common.DataColumnMapping("productionFinished", "productionFinished"),
																																																			 new System.Data.Common.DataColumnMapping("orderFinished", "orderFinished")})});
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT orderNumber, dueDate, reorderNumber, artDueDate, rushReorderRegular, order" +
				"Type, customerNumber, artFinished, productionFinished, orderFinished FROM dbo.Or" +
				"ders WHERE (artFinished = 0)";
			this.sqlSelectCommand3.Connection = this.cnOrderTrackerDB;
			// 
			// dsArtPending
			// 
			this.dsArtPending.DataSetName = "ArtPendingData";
			this.dsArtPending.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// adManagementPending
			// 
			this.adManagementPending.SelectCommand = this.sqlSelectCommand4;
			this.adManagementPending.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										  new System.Data.Common.DataTableMapping("Table", "Orders", new System.Data.Common.DataColumnMapping[] {
																																																					new System.Data.Common.DataColumnMapping("orderNumber", "orderNumber"),
																																																					new System.Data.Common.DataColumnMapping("orderDate", "orderDate"),
																																																					new System.Data.Common.DataColumnMapping("dueDate", "dueDate"),
																																																					new System.Data.Common.DataColumnMapping("recDate", "recDate"),
																																																					new System.Data.Common.DataColumnMapping("rushReorderRegular", "rushReorderRegular"),
																																																					new System.Data.Common.DataColumnMapping("orderType", "orderType"),
																																																					new System.Data.Common.DataColumnMapping("customerNumber", "customerNumber"),
																																																					new System.Data.Common.DataColumnMapping("totalDue", "totalDue"),
																																																					new System.Data.Common.DataColumnMapping("balanceDue", "balanceDue"),
																																																					new System.Data.Common.DataColumnMapping("artFinished", "artFinished"),
																																																					new System.Data.Common.DataColumnMapping("productionFinished", "productionFinished"),
																																																					new System.Data.Common.DataColumnMapping("orderFinished", "orderFinished")})});
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = "SELECT orderNumber, orderDate, dueDate, recDate, rushReorderRegular, orderType, c" +
				"ustomerNumber, totalDue, balanceDue, artFinished, productionFinished, orderFinis" +
				"hed FROM dbo.Orders WHERE (balanceDue < totalDue)";
			this.sqlSelectCommand4.Connection = this.cnOrderTrackerDB;
			// 
			// dsManagementPending
			// 
			this.dsManagementPending.DataSetName = "ManagementPendingData";
			this.dsManagementPending.Locale = new System.Globalization.CultureInfo("en-US");
			this.Load += new System.EventHandler(this.Page_Load);
			((System.ComponentModel.ISupportInitialize)(this.dsOrdersPending)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsProductionPending)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsArtPending)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsManagementPending)).EndInit();

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
