//Josh Marquis 2005
//some basic code used from Beginnning Visual Web Programming in C# by
//Daniel Cazzulino, Victor Garcia Aprea, James Greenwood, and Chris Hart
//Apress 2004

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace OrderTrackerv2.Customers.Secure
{
	/// <summary>
	/// Summary description for ViewOrder2.
	/// </summary>
	public class ViewOrder2 : OrderTrackerCustBase
	{
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.ValidationSummary valErrors;
		protected System.Web.UI.WebControls.Button btnAccept;

		private string newOrder="false";
		protected System.Web.UI.WebControls.TextBox txtInsideRep;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.TextBox txtOutsideRep;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.TextBox txtDueDate;
		protected System.Web.UI.WebControls.TextBox txtReorderNum;
		protected System.Web.UI.WebControls.TextBox txtPO;
		protected System.Web.UI.WebControls.TextBox txtXOrderNum;
		protected System.Web.UI.WebControls.TextBox txtShipping;
		protected System.Web.UI.WebControls.DropDownList cbType;
		protected System.Web.UI.WebControls.TextBox txtArtist;
		protected System.Web.UI.WebControls.TextBox txtArtDueDate;
		protected System.Web.UI.WebControls.DropDownList cbRushRegReorder;
		protected System.Web.UI.WebControls.TextBox txtBalanceDue;
		protected System.Web.UI.WebControls.Label lblBalanceDue;
		protected System.Web.UI.WebControls.TextBox txtDeposit;
		protected System.Web.UI.WebControls.TextBox txtTotalDue;
		protected System.Web.UI.WebControls.Label lblTotalDue;
		protected System.Web.UI.WebControls.TextBox txtShippingAmt;
		protected System.Web.UI.WebControls.Label lblShipping;
		protected System.Web.UI.WebControls.TextBox txtSalesTax;
		protected System.Web.UI.WebControls.Label lblSalesTax;
		protected System.Web.UI.WebControls.TextBox txtSubTotal;
		protected System.Web.UI.WebControls.Label lblSubTotal;
		protected System.Web.UI.WebControls.TextBox txtArtCharge;
		protected System.Web.UI.WebControls.TextBox txtSetUpCharge;
		protected System.Web.UI.WebControls.TextBox txtPMSCharge;
		protected System.Web.UI.WebControls.TextBox txtRushCharge;
		protected System.Web.UI.WebControls.TextBox txtColorsFront;
		protected System.Web.UI.WebControls.TextBox txtColorsBack;
		protected System.Web.UI.WebControls.TextBox txtColorsSleeve;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		protected System.Data.SqlClient.SqlConnection cnOrderTrackerDB;
		protected System.Data.SqlClient.SqlDataAdapter adSpeed;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected OrderTrackerv2.HOOemployees.SpeedData dsSpeedData;
		protected System.Data.SqlClient.SqlDataAdapter adTypes;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected OrderTrackerv2.HOOemployees.OrderTypes dsOrderTypes;
		private string orderNum;
		private string customerNum;
		protected System.Web.UI.WebControls.TextBox txtEmail;
		protected System.Web.UI.WebControls.TextBox txtFax;
		protected System.Web.UI.WebControls.TextBox txtCellPhone;
		protected System.Web.UI.WebControls.TextBox txtPhone;
		protected System.Web.UI.WebControls.TextBox txtZip;
		protected System.Web.UI.WebControls.TextBox txtState;
		protected System.Web.UI.WebControls.TextBox txtCity;
		protected System.Web.UI.WebControls.TextBox txtAddress;
		protected System.Web.UI.WebControls.TextBox txtContactName;
		protected System.Web.UI.WebControls.TextBox txtCustomerName;
		protected System.Web.UI.WebControls.Panel pnlImages;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Panel pnlShirtList;
		protected System.Data.SqlClient.SqlDataAdapter adShirtData;
		protected OrderTrackerv2.HOOemployees.ShirtData dsShirtData;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		private string contactNum;
		private SqlDataReader orderReader;
		private SqlDataReader customerReader;
		protected System.Data.SqlClient.SqlDataAdapter dsDummyOrder;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		protected OrderTrackerv2.HOOemployees.DummyOrderData dummyOrderData1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand2;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand2;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand2;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator3;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator4;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator5;
		protected System.Web.UI.WebControls.Panel pnlKeyPoints;
		protected System.Web.UI.WebControls.CheckBox artApproved;
		protected System.Web.UI.WebControls.CheckBox productionFinished;
		protected System.Web.UI.WebControls.CheckBox orderFinished;
		protected System.Web.UI.WebControls.TextBox txtRecDate;
		private SqlDataReader contactReader;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			newOrder = Request.QueryString["newOrder"].ToString();
			if( Request.QueryString["newOrder"] == "false" )
			{
				orderNum = Request.QueryString["orderNumber"].ToString();
				base.HeaderMessage = "Order: " + orderNum;
			}
			else
				return;

			orderNum = Request.QueryString["orderNumber"];

			//postbacks are caused by validator controls if
			//i'm not using an IE based browser
			if( Page.IsPostBack )
				return;

			adSpeed.Fill( dsSpeedData );
			adTypes.Fill( dsOrderTypes );
			cbType.DataBind();
			cbRushRegReorder.DataBind();

			if( Context.User.Identity.IsAuthenticated )
			{
				//change the header
				if( newOrder == "false" )
				{
					//set visibilities
					pnlImages.Visible = true;
					pnlKeyPoints.Visible = true;

					loadOrderData();
					if( customerNum != null )
						loadCustomerData();
					if( contactNum != null )
						loadContactData();

					loadArtThumbsFromDB();
					loadShirtData();
				}
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
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.adSpeed = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.dsSpeedData = new OrderTrackerv2.HOOemployees.SpeedData();
			this.adTypes = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.dsOrderTypes = new OrderTrackerv2.HOOemployees.OrderTypes();
			this.adShirtData = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDeleteCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand2 = new System.Data.SqlClient.SqlCommand();
			this.dsShirtData = new OrderTrackerv2.HOOemployees.ShirtData();
			this.dsDummyOrder = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.dummyOrderData1 = new OrderTrackerv2.HOOemployees.DummyOrderData();
			((System.ComponentModel.ISupportInitialize)(this.dsSpeedData)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsOrderTypes)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsShirtData)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dummyOrderData1)).BeginInit();
			// 
			// cnOrderTrackerDB
			// 
			this.cnOrderTrackerDB.ConnectionString = ((string)(configurationAppSettings.GetValue("cnOrderTrackerDB.ConnectionString", typeof(string))));
			// 
			// adSpeed
			// 
			this.adSpeed.SelectCommand = this.sqlSelectCommand2;
			this.adSpeed.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																							  new System.Data.Common.DataTableMapping("Table", "Speed", new System.Data.Common.DataColumnMapping[] {
																																																	   new System.Data.Common.DataColumnMapping("Speed", "Speed")})});
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT Speed FROM dbo.Speed";
			this.sqlSelectCommand2.Connection = this.cnOrderTrackerDB;
			// 
			// dsSpeedData
			// 
			this.dsSpeedData.DataSetName = "SpeedData";
			this.dsSpeedData.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// adTypes
			// 
			this.adTypes.SelectCommand = this.sqlSelectCommand3;
			this.adTypes.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																							  new System.Data.Common.DataTableMapping("Table", "orderTypes", new System.Data.Common.DataColumnMapping[] {
																																																			new System.Data.Common.DataColumnMapping("Type", "Type")})});
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT Type FROM dbo.orderTypes";
			this.sqlSelectCommand3.Connection = this.cnOrderTrackerDB;
			// 
			// dsOrderTypes
			// 
			this.dsOrderTypes.DataSetName = "OrderTypes";
			this.dsOrderTypes.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// adShirtData
			// 
			this.adShirtData.DeleteCommand = this.sqlDeleteCommand2;
			this.adShirtData.InsertCommand = this.sqlInsertCommand2;
			this.adShirtData.SelectCommand = this.sqlSelectCommand4;
			this.adShirtData.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								  new System.Data.Common.DataTableMapping("Table", "ShirtOrders", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("orderNumber", "orderNumber"),
																																																				 new System.Data.Common.DataColumnMapping("manufacturer", "manufacturer"),
																																																				 new System.Data.Common.DataColumnMapping("color", "color"),
																																																				 new System.Data.Common.DataColumnMapping("num_24", "num_24"),
																																																				 new System.Data.Common.DataColumnMapping("num_68", "num_68"),
																																																				 new System.Data.Common.DataColumnMapping("num_1012", "num_1012"),
																																																				 new System.Data.Common.DataColumnMapping("num_1416", "num_1416"),
																																																				 new System.Data.Common.DataColumnMapping("num_s", "num_s"),
																																																				 new System.Data.Common.DataColumnMapping("num_m", "num_m"),
																																																				 new System.Data.Common.DataColumnMapping("num_l", "num_l"),
																																																				 new System.Data.Common.DataColumnMapping("num_xl", "num_xl"),
																																																				 new System.Data.Common.DataColumnMapping("num_xxl", "num_xxl"),
																																																				 new System.Data.Common.DataColumnMapping("num_xxxl", "num_xxxl"),
																																																				 new System.Data.Common.DataColumnMapping("num_xxxxl", "num_xxxxl"),
																																																				 new System.Data.Common.DataColumnMapping("num_other", "num_other"),
																																																				 new System.Data.Common.DataColumnMapping("unitPrice", "unitPrice"),
																																																				 new System.Data.Common.DataColumnMapping("styleNum", "styleNum"),
																																																				 new System.Data.Common.DataColumnMapping("description", "description"),
																																																				 new System.Data.Common.DataColumnMapping("type", "type"),
																																																				 new System.Data.Common.DataColumnMapping("sleeveOrPocket", "sleeveOrPocket"),
																																																				 new System.Data.Common.DataColumnMapping("totalQty", "totalQty"),
																																																				 new System.Data.Common.DataColumnMapping("totalPrice", "totalPrice")})});
			this.adShirtData.UpdateCommand = this.sqlUpdateCommand2;
			// 
			// sqlDeleteCommand2
			// 
			this.sqlDeleteCommand2.CommandText = @"DELETE FROM dbo.ShirtOrders WHERE (color = @Original_color) AND (manufacturer = @Original_manufacturer) AND (orderNumber = @Original_orderNumber) AND (num_1012 = @Original_num_1012) AND (num_1416 = @Original_num_1416) AND (num_24 = @Original_num_24) AND (num_68 = @Original_num_68) AND (num_l = @Original_num_l) AND (num_m = @Original_num_m) AND (num_other = @Original_num_other) AND (num_s = @Original_num_s) AND (num_xl = @Original_num_xl) AND (num_xxl = @Original_num_xxl) AND (num_xxxl = @Original_num_xxxl) AND (num_xxxxl = @Original_num_xxxxl) AND (sleeveOrPocket = @Original_sleeveOrPocket) AND (styleNum = @Original_styleNum OR @Original_styleNum IS NULL AND styleNum IS NULL) AND (totalPrice = @Original_totalPrice OR @Original_totalPrice IS NULL AND totalPrice IS NULL) AND (totalQty = @Original_totalQty OR @Original_totalQty IS NULL AND totalQty IS NULL) AND (type = @Original_type) AND (unitPrice = @Original_unitPrice)";
			this.sqlDeleteCommand2.Connection = this.cnOrderTrackerDB;
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_color", System.Data.SqlDbType.NVarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "color", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_manufacturer", System.Data.SqlDbType.NVarChar, 40, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "manufacturer", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_orderNumber", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "orderNumber", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_1012", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_1012", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_1416", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_1416", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_24", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_24", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_68", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_68", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_l", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_l", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_m", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_m", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_other", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_other", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_s", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_s", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_xl", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_xl", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_xxl", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_xxl", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_xxxl", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_xxxl", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_xxxxl", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_xxxxl", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_sleeveOrPocket", System.Data.SqlDbType.NVarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "sleeveOrPocket", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_styleNum", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "styleNum", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_totalPrice", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "totalPrice", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_totalQty", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "totalQty", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_type", System.Data.SqlDbType.NVarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "type", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_unitPrice", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "unitPrice", System.Data.DataRowVersion.Original, null));
			// 
			// sqlInsertCommand2
			// 
			this.sqlInsertCommand2.CommandText = @"INSERT INTO dbo.ShirtOrders(orderNumber, manufacturer, color, num_24, num_68, num_1012, num_1416, num_s, num_m, num_l, num_xl, num_xxl, num_xxxl, num_xxxxl, num_other, unitPrice, styleNum, description, type, sleeveOrPocket) VALUES (@orderNumber, @manufacturer, @color, @num_24, @num_68, @num_1012, @num_1416, @num_s, @num_m, @num_l, @num_xl, @num_xxl, @num_xxxl, @num_xxxxl, @num_other, @unitPrice, @styleNum, @description, @type, @sleeveOrPocket); SELECT orderNumber, manufacturer, color, num_24, num_68, num_1012, num_1416, num_s, num_m, num_l, num_xl, num_xxl, num_xxxl, num_xxxxl, num_other, unitPrice, styleNum, description, type, sleeveOrPocket, totalQty, totalPrice FROM dbo.ShirtOrders WHERE (color = @color) AND (manufacturer = @manufacturer) AND (orderNumber = @orderNumber)";
			this.sqlInsertCommand2.Connection = this.cnOrderTrackerDB;
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@orderNumber", System.Data.SqlDbType.Int, 4, "orderNumber"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@manufacturer", System.Data.SqlDbType.NVarChar, 40, "manufacturer"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@color", System.Data.SqlDbType.NVarChar, 20, "color"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_24", System.Data.SqlDbType.Int, 4, "num_24"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_68", System.Data.SqlDbType.Int, 4, "num_68"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_1012", System.Data.SqlDbType.Int, 4, "num_1012"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_1416", System.Data.SqlDbType.Int, 4, "num_1416"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_s", System.Data.SqlDbType.Int, 4, "num_s"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_m", System.Data.SqlDbType.Int, 4, "num_m"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_l", System.Data.SqlDbType.Int, 4, "num_l"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_xl", System.Data.SqlDbType.Int, 4, "num_xl"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_xxl", System.Data.SqlDbType.Int, 4, "num_xxl"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_xxxl", System.Data.SqlDbType.Int, 4, "num_xxxl"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_xxxxl", System.Data.SqlDbType.Int, 4, "num_xxxxl"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_other", System.Data.SqlDbType.Int, 4, "num_other"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@unitPrice", System.Data.SqlDbType.Money, 8, "unitPrice"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@styleNum", System.Data.SqlDbType.NVarChar, 10, "styleNum"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@description", System.Data.SqlDbType.NVarChar, 1073741823, "description"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@type", System.Data.SqlDbType.NVarChar, 20, "type"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sleeveOrPocket", System.Data.SqlDbType.NVarChar, 2, "sleeveOrPocket"));
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = @"SELECT orderNumber, manufacturer, color, num_24, num_68, num_1012, num_1416, num_s, num_m, num_l, num_xl, num_xxl, num_xxxl, num_xxxxl, num_other, unitPrice, styleNum, description, type, sleeveOrPocket, totalQty, totalPrice FROM dbo.ShirtOrders WHERE (orderNumber = @onum)";
			this.sqlSelectCommand4.Connection = this.cnOrderTrackerDB;
			this.sqlSelectCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@onum", System.Data.SqlDbType.Int, 4, "orderNumber"));
			// 
			// sqlUpdateCommand2
			// 
			this.sqlUpdateCommand2.CommandText = "UPDATE dbo.ShirtOrders SET orderNumber = @orderNumber, manufacturer = @manufactur" +
				"er, color = @color, num_24 = @num_24, num_68 = @num_68, num_1012 = @num_1012, nu" +
				"m_1416 = @num_1416, num_s = @num_s, num_m = @num_m, num_l = @num_l, num_xl = @nu" +
				"m_xl, num_xxl = @num_xxl, num_xxxl = @num_xxxl, num_xxxxl = @num_xxxxl, num_othe" +
				"r = @num_other, unitPrice = @unitPrice, styleNum = @styleNum, description = @des" +
				"cription, type = @type, sleeveOrPocket = @sleeveOrPocket WHERE (color = @Origina" +
				"l_color) AND (manufacturer = @Original_manufacturer) AND (orderNumber = @Origina" +
				"l_orderNumber) AND (num_1012 = @Original_num_1012) AND (num_1416 = @Original_num" +
				"_1416) AND (num_24 = @Original_num_24) AND (num_68 = @Original_num_68) AND (num_" +
				"l = @Original_num_l) AND (num_m = @Original_num_m) AND (num_other = @Original_nu" +
				"m_other) AND (num_s = @Original_num_s) AND (num_xl = @Original_num_xl) AND (num_" +
				"xxl = @Original_num_xxl) AND (num_xxxl = @Original_num_xxxl) AND (num_xxxxl = @O" +
				"riginal_num_xxxxl) AND (sleeveOrPocket = @Original_sleeveOrPocket) AND (styleNum" +
				" = @Original_styleNum OR @Original_styleNum IS NULL AND styleNum IS NULL) AND (t" +
				"ype = @Original_type) AND (unitPrice = @Original_unitPrice); SELECT orderNumber," +
				" manufacturer, color, num_24, num_68, num_1012, num_1416, num_s, num_m, num_l, n" +
				"um_xl, num_xxl, num_xxxl, num_xxxxl, num_other, unitPrice, styleNum, description" +
				", type, sleeveOrPocket, totalQty, totalPrice FROM dbo.ShirtOrders WHERE (color =" +
				" @color) AND (manufacturer = @manufacturer) AND (orderNumber = @orderNumber)";
			this.sqlUpdateCommand2.Connection = this.cnOrderTrackerDB;
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@orderNumber", System.Data.SqlDbType.Int, 4, "orderNumber"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@manufacturer", System.Data.SqlDbType.NVarChar, 40, "manufacturer"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@color", System.Data.SqlDbType.NVarChar, 20, "color"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_24", System.Data.SqlDbType.Int, 4, "num_24"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_68", System.Data.SqlDbType.Int, 4, "num_68"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_1012", System.Data.SqlDbType.Int, 4, "num_1012"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_1416", System.Data.SqlDbType.Int, 4, "num_1416"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_s", System.Data.SqlDbType.Int, 4, "num_s"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_m", System.Data.SqlDbType.Int, 4, "num_m"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_l", System.Data.SqlDbType.Int, 4, "num_l"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_xl", System.Data.SqlDbType.Int, 4, "num_xl"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_xxl", System.Data.SqlDbType.Int, 4, "num_xxl"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_xxxl", System.Data.SqlDbType.Int, 4, "num_xxxl"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_xxxxl", System.Data.SqlDbType.Int, 4, "num_xxxxl"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_other", System.Data.SqlDbType.Int, 4, "num_other"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@unitPrice", System.Data.SqlDbType.Money, 8, "unitPrice"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@styleNum", System.Data.SqlDbType.NVarChar, 10, "styleNum"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@description", System.Data.SqlDbType.NVarChar, 1073741823, "description"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@type", System.Data.SqlDbType.NVarChar, 20, "type"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sleeveOrPocket", System.Data.SqlDbType.NVarChar, 2, "sleeveOrPocket"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_color", System.Data.SqlDbType.NVarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "color", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_manufacturer", System.Data.SqlDbType.NVarChar, 40, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "manufacturer", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_orderNumber", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "orderNumber", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_1012", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_1012", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_1416", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_1416", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_24", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_24", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_68", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_68", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_l", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_l", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_m", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_m", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_other", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_other", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_s", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_s", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_xl", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_xl", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_xxl", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_xxl", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_xxxl", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_xxxl", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_xxxxl", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_xxxxl", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_sleeveOrPocket", System.Data.SqlDbType.NVarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "sleeveOrPocket", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_styleNum", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "styleNum", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_type", System.Data.SqlDbType.NVarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "type", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_unitPrice", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "unitPrice", System.Data.DataRowVersion.Original, null));
			// 
			// dsShirtData
			// 
			this.dsShirtData.DataSetName = "ShirtData";
			this.dsShirtData.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dsDummyOrder
			// 
			this.dsDummyOrder.SelectCommand = this.sqlSelectCommand5;
			this.dsDummyOrder.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								   new System.Data.Common.DataTableMapping("Table", "Orders", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("orderNumber", "orderNumber"),
																																																			 new System.Data.Common.DataColumnMapping("orderDate", "orderDate"),
																																																			 new System.Data.Common.DataColumnMapping("dueDate", "dueDate"),
																																																			 new System.Data.Common.DataColumnMapping("recDate", "recDate"),
																																																			 new System.Data.Common.DataColumnMapping("reorderNumber", "reorderNumber"),
																																																			 new System.Data.Common.DataColumnMapping("shippingMethod", "shippingMethod"),
																																																			 new System.Data.Common.DataColumnMapping("artDueDate", "artDueDate"),
																																																			 new System.Data.Common.DataColumnMapping("rushReorderRegular", "rushReorderRegular"),
																																																			 new System.Data.Common.DataColumnMapping("orderType", "orderType"),
																																																			 new System.Data.Common.DataColumnMapping("xOrderNumber", "xOrderNumber"),
																																																			 new System.Data.Common.DataColumnMapping("customerNumber", "customerNumber"),
																																																			 new System.Data.Common.DataColumnMapping("contactPersonNumber", "contactPersonNumber"),
																																																			 new System.Data.Common.DataColumnMapping("insideRepNumber", "insideRepNumber"),
																																																			 new System.Data.Common.DataColumnMapping("outsideRepNumber", "outsideRepNumber"),
																																																			 new System.Data.Common.DataColumnMapping("numColorsFront", "numColorsFront"),
																																																			 new System.Data.Common.DataColumnMapping("numColorsBack", "numColorsBack"),
																																																			 new System.Data.Common.DataColumnMapping("numColorsSleeve", "numColorsSleeve"),
																																																			 new System.Data.Common.DataColumnMapping("PMScharge", "PMScharge"),
																																																			 new System.Data.Common.DataColumnMapping("setupCharge", "setupCharge"),
																																																			 new System.Data.Common.DataColumnMapping("artCharge", "artCharge"),
																																																			 new System.Data.Common.DataColumnMapping("rushCharge", "rushCharge"),
																																																			 new System.Data.Common.DataColumnMapping("deposit", "deposit"),
																																																			 new System.Data.Common.DataColumnMapping("subtotal", "subtotal"),
																																																			 new System.Data.Common.DataColumnMapping("salesTax", "salesTax"),
																																																			 new System.Data.Common.DataColumnMapping("shipping", "shipping"),
																																																			 new System.Data.Common.DataColumnMapping("totalDue", "totalDue"),
																																																			 new System.Data.Common.DataColumnMapping("balanceDue", "balanceDue")})});
			// 
			// sqlSelectCommand5
			// 
			this.sqlSelectCommand5.CommandText = @"SELECT orderNumber, orderDate, dueDate, recDate, reorderNumber, shippingMethod, artDueDate, rushReorderRegular, orderType, xOrderNumber, customerNumber, contactPersonNumber, insideRepNumber, outsideRepNumber, numColorsFront, numColorsBack, numColorsSleeve, PMScharge, setupCharge, artCharge, rushCharge, deposit, subtotal, salesTax, shipping, totalDue, balanceDue FROM dbo.Orders";
			this.sqlSelectCommand5.Connection = this.cnOrderTrackerDB;
			// 
			// dummyOrderData1
			// 
			this.dummyOrderData1.DataSetName = "DummyOrderData";
			this.dummyOrderData1.EnforceConstraints = false;
			this.dummyOrderData1.Locale = new System.Globalization.CultureInfo("en-US");
			this.Load += new System.EventHandler(this.Page_Load);
			((System.ComponentModel.ISupportInitialize)(this.dsSpeedData)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsOrderTypes)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsShirtData)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dummyOrderData1)).EndInit();

		}
		#endregion

		private void loadOrderData()
		{
			SqlConnection con = new SqlConnection(
				"data source=.;initial catalog=OrderTrackerDB;" +
				"user id=webuser;pwd=theinternet" );
			SqlCommand cmd = new SqlCommand(
				"SELECT * FROM [Orders] WHERE orderNumber=@onum", con );
			cmd.Parameters.Add( "@onum", orderNum );

			con.Open();
			try
			{
				orderReader = cmd.ExecuteReader();

				if( orderReader.Read() )
				{
					//if( orderReader["insideRepNumber"].ToString() != Page.User.Identity.Name.ToString() &&
					//	orderReader["outsideRepNumber"].ToString() != Page.User.Identity.Name.ToString() )
					//	return;

					txtDate.Text = orderReader["orderDate"].ToString().Split( new Char[] {' '} )[0];

					if( orderReader["dueDate"].ToString().Split( new Char[] {' '} )[0] != null )
						txtDueDate.Text = orderReader["dueDate"].ToString().Split( new Char[] {' '} )[0];
				
					if( orderReader["reorderNumber"].ToString() != null )
						txtReorderNum.Text = orderReader["reorderNumber"].ToString();

					if( orderReader["xOrderNumber"].ToString() != null )
						txtXOrderNum.Text = orderReader["xOrderNumber"].ToString();

					if( orderReader["shippingMethod"].ToString() != null )
						txtShipping.Text = orderReader["shippingMethod"].ToString();

					//eventually change the type method to deal with the drop down
					if( orderReader["orderType"].ToString() != null )
					{
						if( cbType.Items.FindByValue( orderReader["orderType"].ToString().Trim() ) != null )
							cbType.SelectedValue = orderReader["orderType"].ToString().Trim();
					}

					if( orderReader["rushReorderRegular"].ToString() != null )
					{
						if( cbRushRegReorder.Items.FindByValue( orderReader["rushReorderRegular"].ToString().Trim() ) != null )
							cbRushRegReorder.SelectedValue = orderReader["rushReorderRegular"].ToString().Trim();
					}

					if( orderReader["artDueDate"].ToString() != null )
						txtArtDueDate.Text = orderReader["artDueDate"].ToString().Split( new Char[] {' '} )[0];

					if( orderReader["customerNumber"].ToString() != null )
					{
						customerNum = orderReader["customerNumber"].ToString();
						Session["SelectedCustomer"] = customerNum;
					}
					else
						customerNum = null;

					if( orderReader["artCharge"].ToString() != null )
						txtArtCharge.Text = orderReader["artCharge"].ToString();

					if( orderReader["setupCharge"].ToString() != null )
						txtSetUpCharge.Text = orderReader["setupCharge"].ToString();

					if( orderReader["PMSCharge"].ToString() != null )
						txtPMSCharge.Text = orderReader["PMSCharge"].ToString();

					if( orderReader["rushCharge"].ToString() != null )
						txtRushCharge.Text = orderReader["rushCharge"].ToString();

					if( orderReader["contactPersonNumber"].ToString() != null )
					{
						contactNum = orderReader["contactPersonNumber"].ToString();
						Session["SelectedContact"] = contactNum;
					}
					else
					{
						contactNum = null;
						Session["SelectedContact"] = "thereisnocontact";
					}

					if( orderReader["deposit"].ToString() != null )
						txtDeposit.Text = orderReader["deposit"].ToString();

					if( orderReader["subtotal"].ToString() != null )
						txtSubTotal.Text = orderReader["subtotal"].ToString();

					if( orderReader["salesTax"].ToString() != null )
						txtSalesTax.Text = orderReader["salesTax"].ToString();

					if( orderReader["shipping"].ToString() != null )
						txtShippingAmt.Text = orderReader["shipping"].ToString();

					if( orderReader["totalDue"].ToString() != null )
						txtTotalDue.Text = orderReader["totalDue"].ToString();

					if( orderReader["balanceDue"].ToString() != null )
						txtBalanceDue.Text = orderReader["balanceDue"].ToString();

					if( orderReader["insideRepNumber"].ToString() != null )
						txtInsideRep.Text = orderReader["insideRepNumber"].ToString();

					if( orderReader["outsideRepNumber"].ToString() != null )
						txtOutsideRep.Text = orderReader["outsideRepNumber"].ToString();

					if( orderReader["numColorsFront"].ToString() != null )
						txtColorsFront.Text = orderReader["numColorsFront"].ToString();

					if( orderReader["numColorsBack"].ToString() != null )
						txtColorsBack.Text = orderReader["numColorsBack"].ToString();

					if( orderReader["numColorsSleeve"].ToString() != null )
						txtColorsSleeve.Text = orderReader["numColorsSleeve"].ToString();

					if( orderReader["artFinished"].ToString() == bool.TrueString )
						artApproved.Checked = true;

					if( orderReader["productionFinished"].ToString() == bool.TrueString )
						productionFinished.Checked = true;

					if( orderReader["orderFinished"].ToString() == bool.TrueString )
						orderFinished.Checked = true;
				}
			}
			finally
			{
				//close the connection
				con.Close();
			}
		}

		private void loadOrderDataSession()
		{
			dummyOrderData1 = (OrderTrackerv2.HOOemployees.DummyOrderData)Session["orderDS"];

				foreach( DataRow row in dummyOrderData1.Orders.Rows )
				{
					if( row["insideRepNumber"].ToString() != Page.User.Identity.Name.ToString() &&
						row["outsideRepNumber"].ToString() != Page.User.Identity.Name.ToString() )
						return;

					txtDate.Text = row["orderDate"].ToString().Split( new Char[] {' '} )[0];

					if( row["dueDate"].ToString().Split( new Char[] {' '} )[0] != null )
						txtDueDate.Text = row["dueDate"].ToString().Split( new Char[] {' '} )[0];
				
					if( row["reorderNumber"].ToString() != string.Empty )
						txtReorderNum.Text = row["reorderNumber"].ToString();

					if( row["xOrderNumber"].ToString() != string.Empty )
						txtXOrderNum.Text = row["xOrderNumber"].ToString();

					if( row["shippingMethod"].ToString() != string.Empty )
						txtShipping.Text = row["shippingMethod"].ToString();

					//eventually change the type method to deal with the drop down
					if( row["orderType"].ToString() != string.Empty )
					{
						if( cbType.Items.FindByValue( row["orderType"].ToString().Trim() ) != null )
							cbType.SelectedValue = row["orderType"].ToString().Trim();
					}

					if( row["rushReorderRegular"].ToString() != string.Empty )
					{
						if( cbRushRegReorder.Items.FindByValue( row["rushReorderRegular"].ToString().Trim() ) != null )
							cbRushRegReorder.SelectedValue = row["rushReorderRegular"].ToString().Trim();
					}

					if( row["artDueDate"].ToString() != string.Empty )
						txtArtDueDate.Text = row["artDueDate"].ToString().Split( new Char[] {' '} )[0];

					if( row["customerNumber"].ToString() != string.Empty )
					{
						customerNum = row["customerNumber"].ToString();
						Session["SelectedCustomer"] = customerNum;
					}
					else
						customerNum = null;

					if( row["artCharge"].ToString() != string.Empty )
						txtArtCharge.Text = row["artCharge"].ToString();

					if( row["setupCharge"].ToString() != string.Empty )
						txtSetUpCharge.Text = row["setupCharge"].ToString();

					if( row["PMSCharge"].ToString() != string.Empty )
						txtPMSCharge.Text = row["PMSCharge"].ToString();

					if( row["rushCharge"].ToString() != string.Empty )
						txtRushCharge.Text = row["rushCharge"].ToString();

					if( row["contactPersonNumber"].ToString() != string.Empty )
					{
						contactNum = row["contactPersonNumber"].ToString();
						Session["SelectedContact"] = contactNum;
					}
					else
					{
						contactNum = null;
						Session["SelectedContact"] = "thereisnocontact";
					}

					if( row["deposit"].ToString() != string.Empty )
						txtDeposit.Text = row["deposit"].ToString();

					if( row["subtotal"].ToString() != string.Empty )
						txtSubTotal.Text = row["subtotal"].ToString();

					if( row["salesTax"].ToString() != string.Empty )
						txtSalesTax.Text = row["salesTax"].ToString();

					if( row["shipping"].ToString() != string.Empty )
						txtShippingAmt.Text = row["shipping"].ToString();

					if( row["totalDue"].ToString() != string.Empty )
						txtTotalDue.Text = row["totalDue"].ToString();

					if( row["balanceDue"].ToString() != string.Empty )
						txtBalanceDue.Text = row["balanceDue"].ToString();

					if( row["insideRepNumber"].ToString() != string.Empty )
						txtInsideRep.Text = row["insideRepNumber"].ToString();

					if( row["outsideRepNumber"].ToString() != string.Empty )
						txtOutsideRep.Text = row["outsideRepNumber"].ToString();

					if( row["numColorsFront"].ToString() != string.Empty )
						txtColorsFront.Text = row["numColorsFront"].ToString();

					if( row["numColorsBack"].ToString() != string.Empty )
						txtColorsBack.Text = row["numColorsBack"].ToString();

					if( row["numColorsSleeve"].ToString() != string.Empty )
						txtColorsSleeve.Text = row["numColorsSleeve"].ToString();

					if( row["artFinished"].ToString() == bool.TrueString )
						artApproved.Checked = true;

					if( row["productionFinished"].ToString() == bool.TrueString )
						productionFinished.Checked = true;

					if( row["orderFinished"].ToString() == bool.TrueString )
						orderFinished.Checked = true;
				}
		}

		private void loadCustomerDataSession()
		{
			string selectedCust = Request.QueryString["selectCust"].ToString();
			customerNum = selectedCust;

			if( selectedCust != null )
			{
				SqlConnection cnOrderTracker = new SqlConnection(
					"data source=.;initial catalog=OrderTrackerDB;" +
					"user id=webuser;pwd=theinternet" );
				SqlDataAdapter temporaryAD = new SqlDataAdapter(
					"SELECT * FROM [Customers] WHERE [Customers].SID=@cid", cnOrderTracker );
				temporaryAD.SelectCommand.Parameters.Add( "@cid", selectedCust );

				try
				{
					//initialize the dataset and fill it with data
					DataSet dsOrder = new DataSet();
					temporaryAD.Fill( dsOrder, "CustomerData" );

					//finally, use the dataset to fill in (there SHOULD only be one)
					foreach ( DataRow row in dsOrder.Tables["CustomerData"].Rows )
					{
						txtCustomerName.Text = row["name"].ToString();
						txtAddress.Text = row["streetAddress"].ToString();
						txtCity.Text = row["city"].ToString();
						txtState.Text = row["state"].ToString();
						txtZip.Text = row["zip"].ToString();
						txtPhone.Text = row["phone"].ToString();

						if( row["cellPhone"].ToString() != null )
							txtCellPhone.Text = row["cellPhone"].ToString();

						if( row["fax"].ToString() != null )
							txtFax.Text = row["fax"].ToString();
				
						if( row["email"].ToString() != null )
							txtEmail.Text = row["email"].ToString();
					}
				}
				finally
				{
					cnOrderTracker.Close();
					temporaryAD.Dispose();
				}
			}
		}
		private void loadCustomerData()
		{
			SqlConnection con = new SqlConnection(
				"data source=.;initial catalog=OrderTrackerDB;" +
				"user id=webuser;pwd=theinternet" );
			SqlCommand cmd = new SqlCommand(
				"SELECT * FROM [Customers] WHERE SID=@cnum", con );
			cmd.Parameters.Add( "@cnum", customerNum );

			con.Open();
			try
			{
				customerReader = cmd.ExecuteReader();

				if( customerReader.Read() )
				{
					//now let's put in the customer information
					if( customerReader["name"].ToString() != null )
						txtCustomerName.Text = customerReader["name"].ToString();

					if( customerReader["SID"].ToString() != null )
						Session["SelectedCustomer"] = customerReader["SID"].ToString();
					else
						Session["SelectedCustomer"] = null;

					if( customerReader["streetAddress"].ToString() != null )
						txtAddress.Text = customerReader["streetAddress"].ToString();

					if( customerReader["city"].ToString() != null )
						txtCity.Text = customerReader["city"].ToString();

					if( customerReader["state"].ToString() != null )
						txtState.Text = customerReader["state"].ToString();

					if( customerReader["zip"].ToString() != null )
						txtZip.Text = customerReader["zip"].ToString();

					if( customerReader["phone"].ToString() != null )
						txtPhone.Text = customerReader["phone"].ToString();

					if( customerReader["cellPhone"].ToString() != null )
						txtCellPhone.Text = customerReader["cellPhone"].ToString();

					if( customerReader["fax"].ToString() != null )
						txtFax.Text = customerReader["fax"].ToString();

					if( customerReader["email"].ToString() != null )
						txtEmail.Text = customerReader["email"].ToString();
				}
			}
			finally
			{
				//close the connection
				con.Close();
			}
		}

		private void loadContactData()
		{
			SqlConnection con = new SqlConnection(
				"data source=.;initial catalog=OrderTrackerDB;" +
				"user id=webuser;pwd=theinternet" );
			SqlCommand cmd = new SqlCommand(
				"SELECT name FROM [ContactPeople] WHERE CID=@cnum", con );
			cmd.Parameters.Add( "@cnum", contactNum );

			con.Open();
			try
			{
				contactReader = cmd.ExecuteReader();

				if( contactReader.Read() )
				{
					//now let's put in the customer information
					if( contactReader["name"].ToString() != null )
						txtContactName.Text = contactReader["name"].ToString();
				}
			}
			finally
			{
				//close the connection
				con.Close();
			}
		}

		private void loadContactDataSession()
		{
			string selectedContact = Request.QueryString["selectCont"].ToString();
			contactNum = selectedContact;

			if( selectedContact != null )
			{
				SqlConnection cnOrderTracker = new SqlConnection(
					"data source=.;initial catalog=OrderTrackerDB;" +
					"user id=webuser;pwd=theinternet" );
				SqlDataAdapter temporaryAD = new SqlDataAdapter(
					"SELECT name FROM [ContactPeople] WHERE [ContactPeople].CID=@cid", cnOrderTracker );
				temporaryAD.SelectCommand.Parameters.Add( "@cid", selectedContact );

				try
				{
					//initialize the dataset and fill it with data
					DataSet dsOrder = new DataSet();
					temporaryAD.Fill( dsOrder, "ContactData" );

					//finally, use the dataset to fill in (there SHOULD only be one)
					foreach ( DataRow row in dsOrder.Tables["ContactData"].Rows )
					{
						txtContactName.Text = row["name"].ToString();
					}
				}
				finally
				{
					cnOrderTracker.Close();
					temporaryAD.Dispose();
				}
			}
		}

		private void loadArtThumbsFromDB()
		{
			SqlConnection cnOrderTracker = new SqlConnection(
				"data source=.;initial catalog=OrderTrackerDB;" +
				"user id=webuser;pwd=theinternet");
			SqlDataAdapter adOrder = new SqlDataAdapter(
				"SELECT [ArtThumbnail].position FROM [ArtThumbnail] WHERE [ArtThumbnail].orderNumber=@Onum", cnOrderTracker );
			adOrder.SelectCommand.Parameters.Add( "@Onum", orderNum );

			int counter=0;

			HyperLink addArt;

			try
			{
				DataSet dsImageData = new DataSet();
				adOrder.Fill( dsImageData, "Images" );
				counter = dsImageData.Tables["Images"].Rows.Count;

				Session["OrderInfoArtData"] = dsImageData;

				foreach ( DataRow row in dsImageData.Tables["Images"].Rows )
				{
					System.Web.UI.WebControls.Image Image1;
					Image1 = new System.Web.UI.WebControls.Image();
					string temp = row["position"].ToString();

					Image1.ImageUrl = "../LoadImage.aspx?orderNumber=" + orderNum + "&position=" + temp;

					pnlImages.Controls.Add( Image1 );
					pnlImages.Controls.Add( new LiteralControl( "<br><br>" ) );
				}
			}
			finally
			{
				cnOrderTracker.Close();
			}

			if( counter < 6 )
			{
				addArt = new HyperLink();
				addArt.Text = "Add New Artwork";
				addArt.NavigateUrl = "addArt.aspx?orderNumber=" + orderNum + "&position=none";

				pnlImages.Controls.Add( addArt );
				pnlImages.Controls.Add( new LiteralControl( "<br><br><hr><br>" ) );
			}
		}

		private void loadShirtData()
		{
			adShirtData.SelectCommand.Parameters["@onum"].Value = orderNum;
			adShirtData.Fill( dsShirtData, "ShirtOrders" );
			DataGrid1.DataBind();

			//if( dsShirtData.Tables["ShirtOrders"].Rows.Count <= 0 )
				//pnlShirtList.Visible = false;
			
			Session["OrderInfoShirtData"] = dsShirtData;
		}
	}
}
