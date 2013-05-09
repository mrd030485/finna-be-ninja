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
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using OrderTrackerv2;

namespace OrderTrackerv2.HOOemployees
{
	/// <summary>
	/// Summary description for viewOrder.
	/// </summary>
	public class viewOrder : OrderTrackerEmpBase
	{
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.TextBox txtDueDate;
		protected System.Web.UI.WebControls.TextBox txtRecDate;
		protected System.Web.UI.WebControls.TextBox txtReorderNum;
		protected System.Web.UI.WebControls.TextBox txtPO;
		protected System.Web.UI.WebControls.TextBox txtXOrderNum;
		protected System.Web.UI.WebControls.TextBox txtShipping;
		protected System.Web.UI.WebControls.DropDownList cbType;
		protected System.Web.UI.WebControls.TextBox txtArtist;
		protected System.Web.UI.WebControls.TextBox txtArtDueDate;
		protected System.Web.UI.WebControls.TextBox txtContactName;
		protected System.Web.UI.WebControls.TextBox txtAddress;
		protected System.Web.UI.WebControls.TextBox txtEmail;
		protected System.Web.UI.WebControls.TextBox txtCity;
		protected System.Web.UI.WebControls.TextBox txtState;
		protected System.Web.UI.WebControls.TextBox txtZip;
		protected System.Web.UI.WebControls.TextBox txtPhone;
		protected System.Web.UI.WebControls.TextBox txtCellPhone;
		protected System.Web.UI.WebControls.TextBox txtFax;
		protected System.Web.UI.WebControls.DropDownList cbRushRegReorder;
		protected System.Web.UI.WebControls.Panel pnlImages;
		protected System.Web.UI.WebControls.Label lblerror;

		private HyperLink editArt;
		private HyperLink addArt;
		protected System.Web.UI.WebControls.Label createOrderLabel;

		protected System.Web.UI.WebControls.LinkButton searchForCustomer;
		protected System.Web.UI.WebControls.LinkButton searchForContact;
		protected System.Web.UI.WebControls.Panel pnlShirtList;
		protected System.Web.UI.WebControls.TextBox txtPMSCharge;
		protected System.Web.UI.WebControls.TextBox txtSetUpCharge;
		protected System.Web.UI.WebControls.TextBox txtArtCharge;
		protected System.Web.UI.WebControls.TextBox txtCustomerName;
		protected System.Web.UI.WebControls.PlaceHolder shirtList;


		protected System.Data.SqlClient.SqlDataAdapter adShirtData;
		protected OrderTrackerv2.HOOemployees.ShirtData dsShirtData;
		protected DataSet dsOrder;
		protected DataSet dsImageData;

		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Data.SqlClient.SqlConnection cnOrderTrackerDB;
		protected System.Web.UI.WebControls.LinkButton LinkButton1;
		protected System.Web.UI.WebControls.Panel pnlAddShirtMenu;
		protected System.Web.UI.WebControls.Button btnAddShirt;
		protected System.Web.UI.WebControls.TextBox txtSubTotal;
		protected System.Web.UI.WebControls.TextBox txtSalesTax;
		protected System.Web.UI.WebControls.TextBox txtShippingAmt;
		protected System.Web.UI.WebControls.TextBox txtTotalDue;
		protected System.Web.UI.WebControls.TextBox txtDeposit;
		protected System.Web.UI.WebControls.TextBox txtBalanceDue;
		protected anOrder tempOrder;
		protected System.Web.UI.WebControls.DropDownList txtSleevePocket;
		protected System.Web.UI.WebControls.TextBox txt24;
		protected System.Web.UI.WebControls.TextBox txt68;
		protected System.Web.UI.WebControls.TextBox txt1012;
		protected System.Web.UI.WebControls.TextBox txt1416;
		protected System.Web.UI.WebControls.TextBox txtS;
		protected System.Web.UI.WebControls.TextBox txtM;
		protected System.Web.UI.WebControls.TextBox txtL;
		protected System.Web.UI.WebControls.DropDownList txtShirtType;
		protected System.Web.UI.WebControls.TextBox txtColor;
		protected System.Web.UI.WebControls.TextBox txtXL;
		protected System.Web.UI.WebControls.TextBox txtXXL;
		protected System.Web.UI.WebControls.TextBox txtXXXL;
		protected System.Web.UI.WebControls.TextBox txtXXXXL;
		protected System.Web.UI.WebControls.TextBox txtStyleNum;
		protected System.Web.UI.WebControls.TextBox txtDescription;
		protected System.Web.UI.WebControls.TextBox txtManufacturer;
		protected System.Web.UI.WebControls.TextBox txtUnitPrice;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		protected System.Web.UI.WebControls.Label lblSubTotal;
		protected System.Web.UI.WebControls.Label lblSalesTax;
		protected System.Web.UI.WebControls.Label lblShipping;
		protected System.Web.UI.WebControls.TextBox txtRushCharge;
		protected System.Web.UI.WebControls.Label lblTotalDue;
		protected System.Web.UI.WebControls.Label lblBalanceDue;
		protected System.Web.UI.WebControls.Button btnAddUpdate;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Web.UI.WebControls.TextBox txtInsideRep;
		protected System.Web.UI.WebControls.TextBox txtOutsideRep;
		protected System.Web.UI.WebControls.Panel pnlProduction;
		protected System.Web.UI.WebControls.TextBox txtColorsFront;
		protected System.Web.UI.WebControls.TextBox txtColorsBack;
		protected System.Web.UI.WebControls.TextBox txtColorsSleeve;
		protected System.Data.SqlClient.SqlCommand sqlCommand2;

		private string orderNum;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlCommand3;
		protected System.Data.SqlClient.SqlDataAdapter adOrderInfo;
		protected System.Web.UI.WebControls.Panel pnlOrderInfo;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand2;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand2;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand2;
		protected OrderTrackerv2.HOOemployees.OrderData dsOrderData;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand3;
		protected System.Web.UI.WebControls.DataGrid DataGrid2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected OrderTrackerv2.HOOemployees.SpeedData dsSpeedData;
		protected OrderTrackerv2.HOOemployees.OrderTypes dsOrderTypes;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		private SqlDataReader orderReader;

		private void Page_Load(object sender, System.EventArgs e)
		{
			//if( Page.IsPostBack )
			//return;

			//orderNum = Request.QueryString["orderNumber"];

			//here is where the hiding/editing will happen for different types of users

			if( Request.QueryString["newOrder"] == "true" )
			{
				handleNewOrder();
			}
			else if( Request.QueryString["newOrder"] == "inProgress" )
			{
				handleInProgressOrder();
			}
			else if( Request.QueryString["newOrder"] == "false" )
			{
				handleOrder();
			}
			else
				return;
		}

		//this is for brand-spankin' new orders
		private void handleNewOrder()
		{
			searchForCustomer.Visible = true;
			searchForContact.Visible = true;
			LinkButton1.Visible = false;
			pnlShirtList.Visible = false;

			txtDate.Text = DateTime.Now.ToShortDateString();

			btnAddUpdate.Text = "Add Order";

			base.HeaderMessage = "New Order";
		}

		//this is for orders that are in the process of being entered
		private void handleInProgressOrder()
		{
			searchForCustomer.Visible = true;
			searchForContact.Visible = true;
			LinkButton1.Visible = false;
			pnlShirtList.Visible = false;

			base.HeaderMessage = "New Order";

			tempOrder = new anOrder();

			string selectedContact = (string)Session["selectedContact"];
			string selectedCust = (string)Session["selectedCustomer"];

			//load all the information from the previously stored temporary session
			tempOrder = (anOrder)Session["inProgressOrder"];
			txtDate.Text = tempOrder.date;
			txtDueDate.Text = tempOrder.dueDate;

			if( selectedContact != null )
			{
				SqlConnection cnOrderTracker = new SqlConnection(
					ConfigurationSettings.AppSettings["cnOrderTrackerDB.ConnectionString"]);
				SqlDataAdapter adOrder = new SqlDataAdapter(
					"SELECT CID, name FROM [ContactPeople] WHERE [ContactPeople].CID=@cid", cnOrderTracker );
				adOrder.SelectCommand.Parameters.Add( "@cid", selectedContact );

				try
				{
					//initialize the dataset and fill it with data
					dsOrder = new DataSet();
					adOrder.Fill( dsOrder, "ContactData" );

					//Session["CustomerData"] = dsOrder;

					//finally, use the dataset to fill in (there SHOULD only be one)
					foreach ( DataRow row in dsOrder.Tables["ContactData"].Rows )
					{
						txtContactName.Text = row["name"].ToString();
					}
				}
				finally
				{
					cnOrderTracker.Close();
					//adOrder.Dispose();
				}
			}

			if( selectedCust != null )
			{
				SqlConnection cnOrderTracker = new SqlConnection(
					ConfigurationSettings.AppSettings["cnOrderTrackerDB.ConnectionString"]);
				SqlDataAdapter adOrder = new SqlDataAdapter(
					"SELECT * FROM [Customers] WHERE [Customers].SID=@cid", cnOrderTracker );
				adOrder.SelectCommand.Parameters.Add( "@cid", selectedCust );

				try
				{
					//initialize the dataset and fill it with data
					dsOrder = new DataSet();
					adOrder.Fill( dsOrder, "CustomerData" );

					//Session["CustomerData"] = dsOrder;

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
					//adOrder.Dispose();
				}
			}

			//here we want to try loading the temporary order from the session state
		}

		//this is for orders that have already been entered
		private void handleOrder()
		{
			//if the customer has already been entered, we don't want them
			//to be able to change the customer the order goes with.
			searchForCustomer.Visible = false;
			searchForContact.Visible = false;

			orderNum = Request.QueryString["orderNumber"].ToString();
			base.HeaderMessage = "Order: " + orderNum;

			btnAddUpdate.Text = "Update Order";
			btnAddUpdate.Click += new EventHandler(btnAddUpdate_Click);

			
			sqlDataAdapter2.Fill( dsOrderTypes, "OrderTypes" );
			sqlDataAdapter3.Fill( dsSpeedData, "SpeedTypes" );
			cbRushRegReorder.DataBind();
            cbType.DataBind();
			loadRegularInfoFromDB();

			//Session["sessionOrderData"] = dsOrderData;

			loadShirtInfoFromDB();
			loadArtThumbsFromDB();
			figureTotals();
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
			this.adShirtData = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.dsShirtData = new OrderTrackerv2.HOOemployees.ShirtData();
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand2 = new System.Data.SqlClient.SqlCommand();
			this.adOrderInfo = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDeleteCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand2 = new System.Data.SqlClient.SqlCommand();
			this.dsOrderData = new OrderTrackerv2.HOOemployees.OrderData();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlInsertCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.dsSpeedData = new OrderTrackerv2.HOOemployees.SpeedData();
			this.dsOrderTypes = new OrderTrackerv2.HOOemployees.OrderTypes();
			((System.ComponentModel.ISupportInitialize)(this.dsShirtData)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsOrderData)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsSpeedData)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsOrderTypes)).BeginInit();
			this.txtShipping.TextChanged += new System.EventHandler(this.txtShipping_TextChanged);
			this.searchForCustomer.Click += new System.EventHandler(this.searchForCustomer_Click);
			this.searchForContact.Click += new System.EventHandler(this.searchForContact_Click);
			this.LinkButton1.Click += new System.EventHandler(this.LinkButton1_Click);
			this.btnAddShirt.Click += new System.EventHandler(this.btnAddShirt_Click);
			// 
			// cnOrderTrackerDB
			// 
			this.cnOrderTrackerDB.ConnectionString = ((string)(configurationAppSettings.GetValue("cnOrderTrackerDB.ConnectionString", typeof(string))));
			// 
			// adShirtData
			// 
			this.adShirtData.DeleteCommand = this.sqlDeleteCommand1;
			this.adShirtData.InsertCommand = this.sqlInsertCommand1;
			this.adShirtData.SelectCommand = this.sqlSelectCommand1;
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
			this.adShirtData.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = @"DELETE FROM dbo.ShirtOrders WHERE (color = @Original_color) AND (manufacturer = @Original_manufacturer) AND (orderNumber = @Original_orderNumber) AND (num_1012 = @Original_num_1012) AND (num_1416 = @Original_num_1416) AND (num_24 = @Original_num_24) AND (num_68 = @Original_num_68) AND (num_l = @Original_num_l) AND (num_m = @Original_num_m) AND (num_other = @Original_num_other) AND (num_s = @Original_num_s) AND (num_xl = @Original_num_xl) AND (num_xxl = @Original_num_xxl) AND (num_xxxl = @Original_num_xxxl) AND (num_xxxxl = @Original_num_xxxxl) AND (sleeveOrPocket = @Original_sleeveOrPocket) AND (styleNum = @Original_styleNum OR @Original_styleNum IS NULL AND styleNum IS NULL) AND (totalPrice = @Original_totalPrice OR @Original_totalPrice IS NULL AND totalPrice IS NULL) AND (totalQty = @Original_totalQty OR @Original_totalQty IS NULL AND totalQty IS NULL) AND (type = @Original_type) AND (unitPrice = @Original_unitPrice)";
			this.sqlDeleteCommand1.Connection = this.cnOrderTrackerDB;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_color", System.Data.SqlDbType.NVarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "color", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_manufacturer", System.Data.SqlDbType.NVarChar, 40, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "manufacturer", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_orderNumber", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "orderNumber", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_1012", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_1012", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_1416", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_1416", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_24", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_24", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_68", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_68", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_l", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_l", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_m", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_m", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_other", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_other", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_s", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_s", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_xl", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_xl", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_xxl", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_xxl", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_xxxl", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_xxxl", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_xxxxl", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_xxxxl", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_sleeveOrPocket", System.Data.SqlDbType.NVarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "sleeveOrPocket", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_styleNum", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "styleNum", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_totalPrice", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "totalPrice", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_totalQty", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "totalQty", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_type", System.Data.SqlDbType.NVarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "type", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_unitPrice", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "unitPrice", System.Data.DataRowVersion.Original, null));
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = @"INSERT INTO dbo.ShirtOrders(orderNumber, manufacturer, color, num_24, num_68, num_1012, num_1416, num_s, num_m, num_l, num_xl, num_xxl, num_xxxl, num_xxxxl, num_other, unitPrice, styleNum, description, type, sleeveOrPocket) VALUES (@orderNumber, @manufacturer, @color, @num_24, @num_68, @num_1012, @num_1416, @num_s, @num_m, @num_l, @num_xl, @num_xxl, @num_xxxl, @num_xxxxl, @num_other, @unitPrice, @styleNum, @description, @type, @sleeveOrPocket); SELECT orderNumber, manufacturer, color, num_24, num_68, num_1012, num_1416, num_s, num_m, num_l, num_xl, num_xxl, num_xxxl, num_xxxxl, num_other, unitPrice, styleNum, description, type, sleeveOrPocket, totalQty, totalPrice FROM dbo.ShirtOrders WHERE (color = @color) AND (manufacturer = @manufacturer) AND (orderNumber = @orderNumber)";
			this.sqlInsertCommand1.Connection = this.cnOrderTrackerDB;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@orderNumber", System.Data.SqlDbType.Int, 4, "orderNumber"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@manufacturer", System.Data.SqlDbType.NVarChar, 40, "manufacturer"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@color", System.Data.SqlDbType.NVarChar, 20, "color"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_24", System.Data.SqlDbType.Int, 4, "num_24"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_68", System.Data.SqlDbType.Int, 4, "num_68"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_1012", System.Data.SqlDbType.Int, 4, "num_1012"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_1416", System.Data.SqlDbType.Int, 4, "num_1416"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_s", System.Data.SqlDbType.Int, 4, "num_s"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_m", System.Data.SqlDbType.Int, 4, "num_m"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_l", System.Data.SqlDbType.Int, 4, "num_l"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_xl", System.Data.SqlDbType.Int, 4, "num_xl"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_xxl", System.Data.SqlDbType.Int, 4, "num_xxl"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_xxxl", System.Data.SqlDbType.Int, 4, "num_xxxl"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_xxxxl", System.Data.SqlDbType.Int, 4, "num_xxxxl"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_other", System.Data.SqlDbType.Int, 4, "num_other"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@unitPrice", System.Data.SqlDbType.Money, 8, "unitPrice"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@styleNum", System.Data.SqlDbType.NVarChar, 10, "styleNum"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@description", System.Data.SqlDbType.NVarChar, 1073741823, "description"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@type", System.Data.SqlDbType.NVarChar, 20, "type"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sleeveOrPocket", System.Data.SqlDbType.NVarChar, 2, "sleeveOrPocket"));
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT orderNumber, manufacturer, color, num_24, num_68, num_1012, num_1416, num_s, num_m, num_l, num_xl, num_xxl, num_xxxl, num_xxxxl, num_other, unitPrice, styleNum, description, type, sleeveOrPocket, totalQty, totalPrice FROM dbo.ShirtOrders WHERE (orderNumber = @onum)";
			this.sqlSelectCommand1.Connection = this.cnOrderTrackerDB;
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@onum", System.Data.SqlDbType.Int, 4, "orderNumber"));
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = "UPDATE dbo.ShirtOrders SET orderNumber = @orderNumber, manufacturer = @manufactur" +
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
			this.sqlUpdateCommand1.Connection = this.cnOrderTrackerDB;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@orderNumber", System.Data.SqlDbType.Int, 4, "orderNumber"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@manufacturer", System.Data.SqlDbType.NVarChar, 40, "manufacturer"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@color", System.Data.SqlDbType.NVarChar, 20, "color"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_24", System.Data.SqlDbType.Int, 4, "num_24"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_68", System.Data.SqlDbType.Int, 4, "num_68"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_1012", System.Data.SqlDbType.Int, 4, "num_1012"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_1416", System.Data.SqlDbType.Int, 4, "num_1416"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_s", System.Data.SqlDbType.Int, 4, "num_s"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_m", System.Data.SqlDbType.Int, 4, "num_m"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_l", System.Data.SqlDbType.Int, 4, "num_l"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_xl", System.Data.SqlDbType.Int, 4, "num_xl"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_xxl", System.Data.SqlDbType.Int, 4, "num_xxl"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_xxxl", System.Data.SqlDbType.Int, 4, "num_xxxl"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_xxxxl", System.Data.SqlDbType.Int, 4, "num_xxxxl"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@num_other", System.Data.SqlDbType.Int, 4, "num_other"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@unitPrice", System.Data.SqlDbType.Money, 8, "unitPrice"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@styleNum", System.Data.SqlDbType.NVarChar, 10, "styleNum"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@description", System.Data.SqlDbType.NVarChar, 1073741823, "description"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@type", System.Data.SqlDbType.NVarChar, 20, "type"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sleeveOrPocket", System.Data.SqlDbType.NVarChar, 2, "sleeveOrPocket"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_color", System.Data.SqlDbType.NVarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "color", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_manufacturer", System.Data.SqlDbType.NVarChar, 40, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "manufacturer", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_orderNumber", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "orderNumber", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_1012", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_1012", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_1416", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_1416", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_24", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_24", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_68", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_68", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_l", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_l", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_m", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_m", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_other", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_other", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_s", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_s", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_xl", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_xl", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_xxl", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_xxl", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_xxxl", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_xxxl", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_num_xxxxl", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "num_xxxxl", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_sleeveOrPocket", System.Data.SqlDbType.NVarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "sleeveOrPocket", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_styleNum", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "styleNum", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_type", System.Data.SqlDbType.NVarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "type", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_unitPrice", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "unitPrice", System.Data.DataRowVersion.Original, null));
			// 
			// dsShirtData
			// 
			this.dsShirtData.DataSetName = "shirtData";
			this.dsShirtData.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// sqlCommand1
			// 
			this.sqlCommand1.Connection = this.cnOrderTrackerDB;
			// 
			// sqlCommand2
			// 
			this.sqlCommand2.CommandText = @"UPDATE dbo.Orders SET orderDate = @odate, dueDate = @dueDate, recDate = @recDate, reorderNumber = @reorderNumber, shippingMethod = @shippingMethod, artDueDate = @artDueDate, rushReorderRegular = @rushReorderRegular, orderType = @orderType, xOrderNumber = @xOrderNumber, customerNumber = @customerNumber, contactPersonNumber = @contactPersonNumber, insideRepNumber = @insideRepNumber, outsideRepNumber = @outsideRepNumber, numColorsFront = @numColorsFront, numColorsBack = @numColorsBack, numColorsSleeve = @numColorsSleeve, PMScharge = @PMScharge, setupCharge = @setupCharge, artCharge = @artCharge, rushCharge = @rushCharge, deposit = @deposit, subtotal = @subTotal, salesTax = @salesTax, shipping = @shipping, totalDue = @totalDue, balanceDue = @balanceDue WHERE (orderNumber = @onum)";
			this.sqlCommand2.Connection = this.cnOrderTrackerDB;
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@odate", System.Data.SqlDbType.DateTime, 8, "orderDate"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dueDate", System.Data.SqlDbType.DateTime, 8, "dueDate"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@recDate", System.Data.SqlDbType.DateTime, 8, "recDate"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@reorderNumber", System.Data.SqlDbType.Int, 4, "reorderNumber"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@shippingMethod", System.Data.SqlDbType.NVarChar, 20, "shippingMethod"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@artDueDate", System.Data.SqlDbType.DateTime, 8, "artDueDate"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rushReorderRegular", System.Data.SqlDbType.NVarChar, 1, "rushReorderRegular"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@orderType", System.Data.SqlDbType.NVarChar, 20, "orderType"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@xOrderNumber", System.Data.SqlDbType.Int, 4, "xOrderNumber"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@customerNumber", System.Data.SqlDbType.VarChar, 36, "customerNumber"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contactPersonNumber", System.Data.SqlDbType.VarChar, 36, "contactPersonNumber"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@insideRepNumber", System.Data.SqlDbType.VarChar, 36, "insideRepNumber"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@outsideRepNumber", System.Data.SqlDbType.VarChar, 36, "outsideRepNumber"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@numColorsFront", System.Data.SqlDbType.Int, 4, "numColorsFront"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@numColorsBack", System.Data.SqlDbType.Int, 4, "numColorsBack"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@numColorsSleeve", System.Data.SqlDbType.Int, 4, "numColorsSleeve"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PMScharge", System.Data.SqlDbType.Money, 8, "PMScharge"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@setupCharge", System.Data.SqlDbType.Money, 8, "setupCharge"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@artCharge", System.Data.SqlDbType.Money, 8, "artCharge"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rushCharge", System.Data.SqlDbType.Money, 8, "rushCharge"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@deposit", System.Data.SqlDbType.Money, 8, "deposit"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@subTotal", System.Data.SqlDbType.Money, 8, "subtotal"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@salesTax", System.Data.SqlDbType.Money, 8, "salesTax"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@shipping", System.Data.SqlDbType.Money, 8, "shipping"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@totalDue", System.Data.SqlDbType.Money, 8, "totalDue"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@balanceDue", System.Data.SqlDbType.Money, 8, "balanceDue"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@onum", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "orderNumber", System.Data.DataRowVersion.Original, null));
			// 
			// adOrderInfo
			// 
			this.adOrderInfo.DeleteCommand = this.sqlDeleteCommand2;
			this.adOrderInfo.InsertCommand = this.sqlInsertCommand2;
			this.adOrderInfo.SelectCommand = this.sqlSelectCommand2;
			this.adOrderInfo.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
			this.adOrderInfo.UpdateCommand = this.sqlUpdateCommand2;
			// 
			// sqlDeleteCommand2
			// 
			this.sqlDeleteCommand2.CommandText = "DELETE FROM dbo.Orders WHERE (orderNumber = @Original_orderNumber) AND (PMScharge" +
				" = @Original_PMScharge OR @Original_PMScharge IS NULL AND PMScharge IS NULL) AND" +
				" (artCharge = @Original_artCharge OR @Original_artCharge IS NULL AND artCharge I" +
				"S NULL) AND (artDueDate = @Original_artDueDate OR @Original_artDueDate IS NULL A" +
				"ND artDueDate IS NULL) AND (balanceDue = @Original_balanceDue OR @Original_balan" +
				"ceDue IS NULL AND balanceDue IS NULL) AND (contactPersonNumber = @Original_conta" +
				"ctPersonNumber OR @Original_contactPersonNumber IS NULL AND contactPersonNumber " +
				"IS NULL) AND (customerNumber = @Original_customerNumber OR @Original_customerNum" +
				"ber IS NULL AND customerNumber IS NULL) AND (deposit = @Original_deposit OR @Ori" +
				"ginal_deposit IS NULL AND deposit IS NULL) AND (dueDate = @Original_dueDate OR @" +
				"Original_dueDate IS NULL AND dueDate IS NULL) AND (insideRepNumber = @Original_i" +
				"nsideRepNumber OR @Original_insideRepNumber IS NULL AND insideRepNumber IS NULL)" +
				" AND (numColorsBack = @Original_numColorsBack OR @Original_numColorsBack IS NULL" +
				" AND numColorsBack IS NULL) AND (numColorsFront = @Original_numColorsFront OR @O" +
				"riginal_numColorsFront IS NULL AND numColorsFront IS NULL) AND (numColorsSleeve " +
				"= @Original_numColorsSleeve OR @Original_numColorsSleeve IS NULL AND numColorsSl" +
				"eeve IS NULL) AND (orderDate = @Original_orderDate) AND (orderType = @Original_o" +
				"rderType) AND (outsideRepNumber = @Original_outsideRepNumber OR @Original_outsid" +
				"eRepNumber IS NULL AND outsideRepNumber IS NULL) AND (recDate = @Original_recDat" +
				"e OR @Original_recDate IS NULL AND recDate IS NULL) AND (reorderNumber = @Origin" +
				"al_reorderNumber OR @Original_reorderNumber IS NULL AND reorderNumber IS NULL) A" +
				"ND (rushCharge = @Original_rushCharge OR @Original_rushCharge IS NULL AND rushCh" +
				"arge IS NULL) AND (rushReorderRegular = @Original_rushReorderRegular) AND (sales" +
				"Tax = @Original_salesTax OR @Original_salesTax IS NULL AND salesTax IS NULL) AND" +
				" (setupCharge = @Original_setupCharge OR @Original_setupCharge IS NULL AND setup" +
				"Charge IS NULL) AND (shipping = @Original_shipping OR @Original_shipping IS NULL" +
				" AND shipping IS NULL) AND (shippingMethod = @Original_shippingMethod OR @Origin" +
				"al_shippingMethod IS NULL AND shippingMethod IS NULL) AND (subtotal = @Original_" +
				"subtotal OR @Original_subtotal IS NULL AND subtotal IS NULL) AND (totalDue = @Or" +
				"iginal_totalDue OR @Original_totalDue IS NULL AND totalDue IS NULL) AND (xOrderN" +
				"umber = @Original_xOrderNumber OR @Original_xOrderNumber IS NULL AND xOrderNumbe" +
				"r IS NULL)";
			this.sqlDeleteCommand2.Connection = this.cnOrderTrackerDB;
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_orderNumber", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "orderNumber", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PMScharge", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PMScharge", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_artCharge", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "artCharge", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_artDueDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "artDueDate", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_balanceDue", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "balanceDue", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_contactPersonNumber", System.Data.SqlDbType.VarChar, 36, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "contactPersonNumber", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_customerNumber", System.Data.SqlDbType.VarChar, 36, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "customerNumber", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_deposit", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "deposit", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_dueDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "dueDate", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_insideRepNumber", System.Data.SqlDbType.VarChar, 36, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "insideRepNumber", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_numColorsBack", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "numColorsBack", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_numColorsFront", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "numColorsFront", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_numColorsSleeve", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "numColorsSleeve", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_orderDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "orderDate", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_orderType", System.Data.SqlDbType.NVarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "orderType", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_outsideRepNumber", System.Data.SqlDbType.VarChar, 36, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "outsideRepNumber", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_recDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "recDate", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_reorderNumber", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "reorderNumber", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_rushCharge", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rushCharge", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_rushReorderRegular", System.Data.SqlDbType.NVarChar, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rushReorderRegular", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_salesTax", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "salesTax", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_setupCharge", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "setupCharge", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_shipping", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "shipping", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_shippingMethod", System.Data.SqlDbType.NVarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "shippingMethod", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_subtotal", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "subtotal", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_totalDue", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "totalDue", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_xOrderNumber", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "xOrderNumber", System.Data.DataRowVersion.Original, null));
			// 
			// sqlInsertCommand2
			// 
			this.sqlInsertCommand2.CommandText = @"INSERT INTO dbo.Orders(orderNumber, orderDate, dueDate, recDate, reorderNumber, shippingMethod, artDueDate, rushReorderRegular, orderType, xOrderNumber, customerNumber, contactPersonNumber, insideRepNumber, outsideRepNumber, numColorsFront, numColorsBack, numColorsSleeve, PMScharge, setupCharge, artCharge, rushCharge, deposit, subtotal, salesTax, shipping, totalDue, balanceDue) VALUES (@orderNumber, @orderDate, @dueDate, @recDate, @reorderNumber, @shippingMethod, @artDueDate, @rushReorderRegular, @orderType, @xOrderNumber, @customerNumber, @contactPersonNumber, @insideRepNumber, @outsideRepNumber, @numColorsFront, @numColorsBack, @numColorsSleeve, @PMScharge, @setupCharge, @artCharge, @rushCharge, @deposit, @subtotal, @salesTax, @shipping, @totalDue, @balanceDue); SELECT orderNumber, orderDate, dueDate, recDate, reorderNumber, shippingMethod, artDueDate, rushReorderRegular, orderType, xOrderNumber, customerNumber, contactPersonNumber, insideRepNumber, outsideRepNumber, numColorsFront, numColorsBack, numColorsSleeve, PMScharge, setupCharge, artCharge, rushCharge, deposit, subtotal, salesTax, shipping, totalDue, balanceDue FROM dbo.Orders WHERE (orderNumber = @orderNumber)";
			this.sqlInsertCommand2.Connection = this.cnOrderTrackerDB;
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@orderNumber", System.Data.SqlDbType.Int, 4, "orderNumber"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@orderDate", System.Data.SqlDbType.DateTime, 8, "orderDate"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dueDate", System.Data.SqlDbType.DateTime, 8, "dueDate"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@recDate", System.Data.SqlDbType.DateTime, 8, "recDate"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@reorderNumber", System.Data.SqlDbType.Int, 4, "reorderNumber"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@shippingMethod", System.Data.SqlDbType.NVarChar, 20, "shippingMethod"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@artDueDate", System.Data.SqlDbType.DateTime, 8, "artDueDate"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rushReorderRegular", System.Data.SqlDbType.NVarChar, 1, "rushReorderRegular"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@orderType", System.Data.SqlDbType.NVarChar, 20, "orderType"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@xOrderNumber", System.Data.SqlDbType.Int, 4, "xOrderNumber"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@customerNumber", System.Data.SqlDbType.VarChar, 36, "customerNumber"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contactPersonNumber", System.Data.SqlDbType.VarChar, 36, "contactPersonNumber"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@insideRepNumber", System.Data.SqlDbType.VarChar, 36, "insideRepNumber"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@outsideRepNumber", System.Data.SqlDbType.VarChar, 36, "outsideRepNumber"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@numColorsFront", System.Data.SqlDbType.Int, 4, "numColorsFront"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@numColorsBack", System.Data.SqlDbType.Int, 4, "numColorsBack"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@numColorsSleeve", System.Data.SqlDbType.Int, 4, "numColorsSleeve"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PMScharge", System.Data.SqlDbType.Money, 8, "PMScharge"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@setupCharge", System.Data.SqlDbType.Money, 8, "setupCharge"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@artCharge", System.Data.SqlDbType.Money, 8, "artCharge"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rushCharge", System.Data.SqlDbType.Money, 8, "rushCharge"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@deposit", System.Data.SqlDbType.Money, 8, "deposit"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@subtotal", System.Data.SqlDbType.Money, 8, "subtotal"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@salesTax", System.Data.SqlDbType.Money, 8, "salesTax"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@shipping", System.Data.SqlDbType.Money, 8, "shipping"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@totalDue", System.Data.SqlDbType.Money, 8, "totalDue"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@balanceDue", System.Data.SqlDbType.Money, 8, "balanceDue"));
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = @"SELECT orderNumber, orderDate, dueDate, recDate, reorderNumber, shippingMethod, artDueDate, rushReorderRegular, orderType, xOrderNumber, customerNumber, contactPersonNumber, insideRepNumber, outsideRepNumber, numColorsFront, numColorsBack, numColorsSleeve, PMScharge, setupCharge, artCharge, rushCharge, deposit, subtotal, salesTax, shipping, totalDue, balanceDue FROM dbo.Orders WHERE (orderNumber = @onum)";
			this.sqlSelectCommand2.Connection = this.cnOrderTrackerDB;
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@onum", System.Data.SqlDbType.Int, 4, "orderNumber"));
			// 
			// sqlUpdateCommand2
			// 
			this.sqlUpdateCommand2.CommandText = "UPDATE dbo.Orders SET orderNumber = @orderNumber, orderDate = @orderDate, dueDate" +
				" = @dueDate, recDate = @recDate, reorderNumber = @reorderNumber, shippingMethod " +
				"= @shippingMethod, artDueDate = @artDueDate, rushReorderRegular = @rushReorderRe" +
				"gular, orderType = @orderType, xOrderNumber = @xOrderNumber, customerNumber = @c" +
				"ustomerNumber, contactPersonNumber = @contactPersonNumber, insideRepNumber = @in" +
				"sideRepNumber, outsideRepNumber = @outsideRepNumber, numColorsFront = @numColors" +
				"Front, numColorsBack = @numColorsBack, numColorsSleeve = @numColorsSleeve, PMSch" +
				"arge = @PMScharge, setupCharge = @setupCharge, artCharge = @artCharge, rushCharg" +
				"e = @rushCharge, deposit = @deposit, subtotal = @subtotal, salesTax = @salesTax," +
				" shipping = @shipping, totalDue = @totalDue, balanceDue = @balanceDue WHERE (ord" +
				"erNumber = @Original_orderNumber) AND (PMScharge = @Original_PMScharge OR @Origi" +
				"nal_PMScharge IS NULL AND PMScharge IS NULL) AND (artCharge = @Original_artCharg" +
				"e OR @Original_artCharge IS NULL AND artCharge IS NULL) AND (artDueDate = @Origi" +
				"nal_artDueDate OR @Original_artDueDate IS NULL AND artDueDate IS NULL) AND (bala" +
				"nceDue = @Original_balanceDue OR @Original_balanceDue IS NULL AND balanceDue IS " +
				"NULL) AND (contactPersonNumber = @Original_contactPersonNumber OR @Original_cont" +
				"actPersonNumber IS NULL AND contactPersonNumber IS NULL) AND (customerNumber = @" +
				"Original_customerNumber OR @Original_customerNumber IS NULL AND customerNumber I" +
				"S NULL) AND (deposit = @Original_deposit OR @Original_deposit IS NULL AND deposi" +
				"t IS NULL) AND (dueDate = @Original_dueDate OR @Original_dueDate IS NULL AND due" +
				"Date IS NULL) AND (insideRepNumber = @Original_insideRepNumber OR @Original_insi" +
				"deRepNumber IS NULL AND insideRepNumber IS NULL) AND (numColorsBack = @Original_" +
				"numColorsBack OR @Original_numColorsBack IS NULL AND numColorsBack IS NULL) AND " +
				"(numColorsFront = @Original_numColorsFront OR @Original_numColorsFront IS NULL A" +
				"ND numColorsFront IS NULL) AND (numColorsSleeve = @Original_numColorsSleeve OR @" +
				"Original_numColorsSleeve IS NULL AND numColorsSleeve IS NULL) AND (orderDate = @" +
				"Original_orderDate) AND (orderType = @Original_orderType) AND (outsideRepNumber " +
				"= @Original_outsideRepNumber OR @Original_outsideRepNumber IS NULL AND outsideRe" +
				"pNumber IS NULL) AND (recDate = @Original_recDate OR @Original_recDate IS NULL A" +
				"ND recDate IS NULL) AND (reorderNumber = @Original_reorderNumber OR @Original_re" +
				"orderNumber IS NULL AND reorderNumber IS NULL) AND (rushCharge = @Original_rushC" +
				"harge OR @Original_rushCharge IS NULL AND rushCharge IS NULL) AND (rushReorderRe" +
				"gular = @Original_rushReorderRegular) AND (salesTax = @Original_salesTax OR @Ori" +
				"ginal_salesTax IS NULL AND salesTax IS NULL) AND (setupCharge = @Original_setupC" +
				"harge OR @Original_setupCharge IS NULL AND setupCharge IS NULL) AND (shipping = " +
				"@Original_shipping OR @Original_shipping IS NULL AND shipping IS NULL) AND (ship" +
				"pingMethod = @Original_shippingMethod OR @Original_shippingMethod IS NULL AND sh" +
				"ippingMethod IS NULL) AND (subtotal = @Original_subtotal OR @Original_subtotal I" +
				"S NULL AND subtotal IS NULL) AND (totalDue = @Original_totalDue OR @Original_tot" +
				"alDue IS NULL AND totalDue IS NULL) AND (xOrderNumber = @Original_xOrderNumber O" +
				"R @Original_xOrderNumber IS NULL AND xOrderNumber IS NULL); SELECT orderNumber, " +
				"orderDate, dueDate, recDate, reorderNumber, shippingMethod, artDueDate, rushReor" +
				"derRegular, orderType, xOrderNumber, customerNumber, contactPersonNumber, inside" +
				"RepNumber, outsideRepNumber, numColorsFront, numColorsBack, numColorsSleeve, PMS" +
				"charge, setupCharge, artCharge, rushCharge, deposit, subtotal, salesTax, shippin" +
				"g, totalDue, balanceDue FROM dbo.Orders WHERE (orderNumber = @orderNumber)";
			this.sqlUpdateCommand2.Connection = this.cnOrderTrackerDB;
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@orderNumber", System.Data.SqlDbType.Int, 4, "orderNumber"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@orderDate", System.Data.SqlDbType.DateTime, 8, "orderDate"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dueDate", System.Data.SqlDbType.DateTime, 8, "dueDate"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@recDate", System.Data.SqlDbType.DateTime, 8, "recDate"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@reorderNumber", System.Data.SqlDbType.Int, 4, "reorderNumber"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@shippingMethod", System.Data.SqlDbType.NVarChar, 20, "shippingMethod"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@artDueDate", System.Data.SqlDbType.DateTime, 8, "artDueDate"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rushReorderRegular", System.Data.SqlDbType.NVarChar, 1, "rushReorderRegular"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@orderType", System.Data.SqlDbType.NVarChar, 20, "orderType"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@xOrderNumber", System.Data.SqlDbType.Int, 4, "xOrderNumber"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@customerNumber", System.Data.SqlDbType.VarChar, 36, "customerNumber"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contactPersonNumber", System.Data.SqlDbType.VarChar, 36, "contactPersonNumber"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@insideRepNumber", System.Data.SqlDbType.VarChar, 36, "insideRepNumber"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@outsideRepNumber", System.Data.SqlDbType.VarChar, 36, "outsideRepNumber"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@numColorsFront", System.Data.SqlDbType.Int, 4, "numColorsFront"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@numColorsBack", System.Data.SqlDbType.Int, 4, "numColorsBack"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@numColorsSleeve", System.Data.SqlDbType.Int, 4, "numColorsSleeve"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PMScharge", System.Data.SqlDbType.Money, 8, "PMScharge"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@setupCharge", System.Data.SqlDbType.Money, 8, "setupCharge"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@artCharge", System.Data.SqlDbType.Money, 8, "artCharge"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rushCharge", System.Data.SqlDbType.Money, 8, "rushCharge"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@deposit", System.Data.SqlDbType.Money, 8, "deposit"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@subtotal", System.Data.SqlDbType.Money, 8, "subtotal"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@salesTax", System.Data.SqlDbType.Money, 8, "salesTax"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@shipping", System.Data.SqlDbType.Money, 8, "shipping"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@totalDue", System.Data.SqlDbType.Money, 8, "totalDue"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@balanceDue", System.Data.SqlDbType.Money, 8, "balanceDue"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_orderNumber", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "orderNumber", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PMScharge", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PMScharge", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_artCharge", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "artCharge", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_artDueDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "artDueDate", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_balanceDue", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "balanceDue", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_contactPersonNumber", System.Data.SqlDbType.VarChar, 36, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "contactPersonNumber", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_customerNumber", System.Data.SqlDbType.VarChar, 36, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "customerNumber", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_deposit", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "deposit", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_dueDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "dueDate", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_insideRepNumber", System.Data.SqlDbType.VarChar, 36, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "insideRepNumber", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_numColorsBack", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "numColorsBack", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_numColorsFront", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "numColorsFront", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_numColorsSleeve", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "numColorsSleeve", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_orderDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "orderDate", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_orderType", System.Data.SqlDbType.NVarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "orderType", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_outsideRepNumber", System.Data.SqlDbType.VarChar, 36, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "outsideRepNumber", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_recDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "recDate", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_reorderNumber", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "reorderNumber", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_rushCharge", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rushCharge", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_rushReorderRegular", System.Data.SqlDbType.NVarChar, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rushReorderRegular", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_salesTax", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "salesTax", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_setupCharge", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "setupCharge", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_shipping", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "shipping", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_shippingMethod", System.Data.SqlDbType.NVarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "shippingMethod", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_subtotal", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "subtotal", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_totalDue", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "totalDue", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_xOrderNumber", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "xOrderNumber", System.Data.DataRowVersion.Original, null));
			// 
			// dsOrderData
			// 
			this.dsOrderData.DataSetName = "OrderData";
			this.dsOrderData.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.InsertCommand = this.sqlInsertCommand3;
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "orderTypes", new System.Data.Common.DataColumnMapping[] {
																																																					new System.Data.Common.DataColumnMapping("Type", "Type")})});
			// 
			// sqlInsertCommand3
			// 
			this.sqlInsertCommand3.CommandText = "INSERT INTO dbo.orderTypes(Type) VALUES (@Type); SELECT Type FROM dbo.orderTypes " +
				"WHERE (Type = @Type)";
			this.sqlInsertCommand3.Connection = this.cnOrderTrackerDB;
			this.sqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Type", System.Data.SqlDbType.VarChar, 50, "Type"));
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT Type FROM dbo.orderTypes";
			this.sqlSelectCommand3.Connection = this.cnOrderTrackerDB;
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "Speed", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("Speed", "Speed")})});
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = "SELECT Speed FROM dbo.Speed";
			this.sqlSelectCommand4.Connection = this.cnOrderTrackerDB;
			// 
			// dsSpeedData
			// 
			this.dsSpeedData.DataSetName = "SpeedData";
			this.dsSpeedData.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dsOrderTypes
			// 
			this.dsOrderTypes.DataSetName = "OrderTypes";
			this.dsOrderTypes.Locale = new System.Globalization.CultureInfo("en-US");
			this.Load += new System.EventHandler(this.Page_Load);
			((System.ComponentModel.ISupportInitialize)(this.dsShirtData)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsOrderData)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsSpeedData)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsOrderTypes)).EndInit();

		}
		#endregion

		private void searchForCustomer_Click(object sender, System.EventArgs e)
		{
			//save all the current info
			tempOrder = new anOrder();

			tempOrder.date = txtDate.Text;
			tempOrder.dueDate = txtDueDate.Text;

			Session["inProgressOrder"] = tempOrder;

			if( Request.QueryString["newOrder"] == "true" )
				Response.Redirect( "SearchCustomers.aspx?fromPage=viewOrder&newOrder=inProgress" );
			else if( Request.QueryString["newOrder"] == "inProgress" )
				Response.Redirect( "SearchCustomers.aspx?fromPage=viewOrder&newOrder=inProgress" );
			else if( Request.QueryString["newOrder"] == "false" )
				Response.Redirect( "SearchCustomers.aspx?fromPage=viewOrder&newOrder=false" );
		}

		private void searchForContact_Click(object sender, System.EventArgs e)
		{
			//save all the current info
			tempOrder = new anOrder();

			tempOrder.date = txtDate.Text;
			tempOrder.dueDate = txtDueDate.Text;
			tempOrder.recDate = txtRecDate.Text;
			tempOrder.artDueDate = txtArtDueDate.Text;
			tempOrder.artist = txtArtist.Text;
			//tempOrder.contactUsername = Session["selectedContact"].ToString();
			tempOrder.customerUsername = Session["selectedCustomer"].ToString();

			Session["inProgressOrder"] = tempOrder;

			if( Request.QueryString["newOrder"] == "true" )
				Response.Redirect( "SearchContacts.aspx?fromPage=viewOrder&newOrder=inProgress" );
			else if( Request.QueryString["newOrder"] == "inProgress" )
				Response.Redirect( "SearchContacts.aspx?fromPage=viewOrder&newOrder=inProgress" );
			else if( Request.QueryString["newOrder"] == "false" )
				Response.Redirect( "SearchContacts.aspx?fromPage=viewOrder&newOrder=false" );
		}

		private void LinkButton1_Click(object sender, System.EventArgs e)
		{
			pnlAddShirtMenu.Visible = !pnlAddShirtMenu.Visible;
			if( pnlAddShirtMenu.Visible )
				LinkButton1.Text = "Hide Add Shirt Menu";
			else
				LinkButton1.Text = "Show Add Shirt Menu";
		}

		private void loadRegularInfoFromDB()
		{
			SqlConnection cnOrderTracker = new SqlConnection(
				ConfigurationSettings.AppSettings["cnOrderTrackerDB.ConnectionString"]);
			sqlDataAdapter1 = new SqlDataAdapter(
				"SELECT * FROM [Orders],[Customers] WHERE [Orders].customerNumber=[Customers].SID AND [Orders].orderNumber=@Onum", cnOrderTracker );
			sqlDataAdapter1.SelectCommand.Parameters.Add( "@Onum", orderNum );

			cnOrderTracker.Open();
			SqlCommand cmd = new SqlCommand(
				"SELECT * FROM [Orders],[Customers] WHERE [Orders].customerNumber=[Customers].SID AND [Orders].orderNumber=@Onum", cnOrderTracker );
			cmd.Parameters.Add( "@Onum", orderNum );

			try
			{
				orderReader = cmd.ExecuteReader();

				if( orderReader.Read() )
				{
					if( orderReader["insideRepNumber"].ToString() != Page.User.Identity.Name.ToString() ||
						orderReader["outsideRepNumber"].ToString() != Page.User.Identity.Name.ToString() )
						return;

					txtDate.Text = orderReader["orderDate"].ToString().Split( new Char[] {' '} )[0];

					if( orderReader["dueDate"].ToString().Split( new Char[] {' '} )[0] != null )
						txtDueDate.Text = orderReader["dueDate"].ToString().Split( new Char[] {' '} )[0];

					if( orderReader["recDate"].ToString().Split( new Char[] {' '} )[0] != null )
						txtRecDate.Text = orderReader["recDate"].ToString().Split( new Char[] {' '} )[0];
				
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

					//now let's put in the customer information
					if( orderReader["name"].ToString() != null )
						txtCustomerName.Text = orderReader["name"].ToString();

					if( orderReader["customerNumber"].ToString() != null )
						Session["SelectedCustomer"] = orderReader["customerNumber"].ToString();
					else
						Session["SelectedCustomer"] = null;

					if( orderReader["contactPersonNumber"].ToString() != null )
					{
						Session["SelectedContact"] = orderReader["contactPersonNumber"].ToString();
					}
					else
						Session["SelectedContact"] = "thereisnocontact";

					///////////////////////////////////////////////////////
					///contact info will go here in a bit 
					///////////////////////////////////////////////////////

					if( orderReader["streetAddress"].ToString() != null )
						txtAddress.Text = orderReader["streetAddress"].ToString();

					if( orderReader["city"].ToString() != null )
						txtCity.Text = orderReader["city"].ToString();

					if( orderReader["state"].ToString() != null )
						txtState.Text = orderReader["state"].ToString();

					if( orderReader["zip"].ToString() != null )
						txtZip.Text = orderReader["zip"].ToString();

					if( orderReader["phone"].ToString() != null )
						txtPhone.Text = orderReader["phone"].ToString();

					if( orderReader["cellPhone"].ToString() != null )
						txtCellPhone.Text = orderReader["cellPhone"].ToString();

					if( orderReader["fax"].ToString() != null )
						txtFax.Text = orderReader["fax"].ToString();

					if( orderReader["email"].ToString() != null )
						txtEmail.Text = orderReader["email"].ToString();

					if( orderReader["artCharge"].ToString() != null )
						txtArtCharge.Text = orderReader["artCharge"].ToString();

					if( orderReader["setupCharge"].ToString() != null )
						txtSetUpCharge.Text = orderReader["setupCharge"].ToString();

					if( orderReader["PMSCharge"].ToString() != null )
						txtPMSCharge.Text = orderReader["PMSCharge"].ToString();

					if( orderReader["rushCharge"].ToString() != null )
						txtRushCharge.Text = orderReader["rushCharge"].ToString();

					if( orderReader["deposit"].ToString() != null )
						txtDeposit.Text = orderReader["deposit"].ToString();

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
				}
			}
			catch( SqlException se )
			{
				lblerror.Text += se.Message;
			}
			finally
			{
				cnOrderTrackerDB.Close();
			}

/*			try
			{
				//initialize the dataset and fill it with data
				dsOrder = new DataSet();
				sqlDataAdapter1.Fill( dsOrder, "Order" );

				Session["OrderInfoRegular"] = dsOrder;

				//finally, use the dataset to fill in (there SHOULD only be one)
				foreach ( DataRow row in dsOrder.Tables["Order"].Rows )
				{
					if( row["insideRepNumber"].ToString() != Page.User.Identity.Name.ToString() ||
						row["outsideRepNumber"].ToString() != Page.User.Identity.Name.ToString() )
						return;

					txtDate.Text = row["orderDate"].ToString().Split( new Char[] {' '} )[0];

					if( row["dueDate"].ToString().Split( new Char[] {' '} )[0] != null )
						txtDueDate.Text = row["dueDate"].ToString().Split( new Char[] {' '} )[0];

					if( row["recDate"].ToString().Split( new Char[] {' '} )[0] != null )
						txtRecDate.Text = row["recDate"].ToString().Split( new Char[] {' '} )[0];
				
					if( row["reorderNumber"].ToString() != null )
						txtReorderNum.Text = row["reorderNumber"].ToString();

					if( row["xOrderNumber"].ToString() != null )
						txtXOrderNum.Text = row["xOrderNumber"].ToString();

					if( row["shippingMethod"].ToString() != null )
						txtShipping.Text = row["shippingMethod"].ToString();

					//eventually change the type method to deal with the drop down
					if( row["orderType"].ToString() != null )
					{
						if( cbType.Items.FindByValue( row["orderType"].ToString().Trim() ) != null )
							cbType.SelectedValue = row["orderType"].ToString().Trim();
					}

					if( row["rushReorderRegular"].ToString() != null )
					{
						if( cbRushRegReorder.Items.FindByValue( row["rushReorderRegular"].ToString().Trim() ) != null )
							cbRushRegReorder.SelectedValue = row["rushReorderRegular"].ToString().Trim();
					}

					if( row["artDueDate"].ToString() != null )
						txtArtDueDate.Text = row["artDueDate"].ToString().Split( new Char[] {' '} )[0];

					//now let's put in the customer information
					if( row["name"].ToString() != null )
						txtCustomerName.Text = row["name"].ToString();

					if( row["customerNumber"].ToString() != null )
						Session["SelectedCustomer"] = row["customerNumber"].ToString();
					else
						Session["SelectedCustomer"] = null;

					if( row["contactPersonNumber"].ToString() != null )
					{
						Session["SelectedContact"] = row["contactPersonNumber"].ToString();
					}
					else
						Session["SelectedContact"] = "thereisnocontact";

					///////////////////////////////////////////////////////
					///contact info will go here in a bit 
					///////////////////////////////////////////////////////

					if( row["streetAddress"].ToString() != null )
						txtAddress.Text = row["streetAddress"].ToString();

					if( row["city"].ToString() != null )
						txtCity.Text = row["city"].ToString();

					if( row["state"].ToString() != null )
						txtState.Text = row["state"].ToString();

					if( row["zip"].ToString() != null )
						txtZip.Text = row["zip"].ToString();

					if( row["phone"].ToString() != null )
						txtPhone.Text = row["phone"].ToString();

					if( row["cellPhone"].ToString() != null )
						txtCellPhone.Text = row["cellPhone"].ToString();

					if( row["fax"].ToString() != null )
						txtFax.Text = row["fax"].ToString();

					if( row["email"].ToString() != null )
						txtEmail.Text = row["email"].ToString();

					if( row["artCharge"].ToString() != null )
						txtArtCharge.Text = row["artCharge"].ToString();

					if( row["setupCharge"].ToString() != null )
						txtSetUpCharge.Text = row["setupCharge"].ToString();

					if( row["PMSCharge"].ToString() != null )
						txtPMSCharge.Text = row["PMSCharge"].ToString();

					if( row["rushCharge"].ToString() != null )
						txtRushCharge.Text = row["rushCharge"].ToString();

					if( row["deposit"].ToString() != null )
						txtDeposit.Text = row["deposit"].ToString();

					if( row["deposit"].ToString() != null )
						txtDeposit.Text = row["deposit"].ToString();

					if( row["subtotal"].ToString() != null )
						txtSubTotal.Text = row["subtotal"].ToString();

					if( row["salesTax"].ToString() != null )
						txtSalesTax.Text = row["salesTax"].ToString();

					if( row["shipping"].ToString() != null )
						txtShippingAmt.Text = row["shipping"].ToString();

					if( row["totalDue"].ToString() != null )
						txtTotalDue.Text = row["totalDue"].ToString();

					if( row["balanceDue"].ToString() != null )
						txtBalanceDue.Text = row["balanceDue"].ToString();

					if( row["insideRepNumber"].ToString() != null )
						txtInsideRep.Text = row["insideRepNumber"].ToString();

					if( row["outsideRepNumber"].ToString() != null )
						txtOutsideRep.Text = row["outsideRepNumber"].ToString();

					if( row["numColorsFront"].ToString() != null )
						txtColorsFront.Text = row["numColorsFront"].ToString();

					if( row["numColorsBack"].ToString() != null )
						txtColorsBack.Text = row["numColorsBack"].ToString();

					if( row["numColorsSleeve"].ToString() != null )
						txtColorsSleeve.Text = row["numColorsSleeve"].ToString();
				}
			}
			finally
			{
				cnOrderTracker.Close();
				//adOrder.Dispose();
			}*/
		}
		private void loadArtThumbsFromDB()
		{
			SqlConnection cnOrderTracker = new SqlConnection(
				ConfigurationSettings.AppSettings["cnOrderTrackerDB.ConnectionString"]);
			SqlDataAdapter adOrder = new SqlDataAdapter(
				"SELECT [ArtThumbnail].position FROM [ArtThumbnail] WHERE [ArtThumbnail].orderNumber=@Onum", cnOrderTracker );
			adOrder.SelectCommand.Parameters.Add( "@Onum", orderNum );

			int counter=0;

			try
			{
				dsImageData = new DataSet();
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

					editArt = new HyperLink();
					editArt.Text = "Update " + temp + " Artwork";
					editArt.NavigateUrl = "addArt.aspx?orderNumber=" + orderNum + "&position=" + temp;

					pnlImages.Controls.Add( editArt );
					pnlImages.Controls.Add( new LiteralControl( "<br><hr><br>" ) );
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
		private void loadShirtInfoFromDB()
		{
			adShirtData.SelectCommand.Parameters["@onum"].Value = orderNum;
			adShirtData.Fill( dsShirtData, "ShirtOrders" );
			DataGrid1.DataBind();

			if( dsShirtData.Tables["ShirtOrders"].Rows.Count <= 0 )
				pnlShirtList.Visible = false;
			
			Session["OrderInfoShirtData"] = dsShirtData;
		}

		private void btnAddShirt_Click(object sender, System.EventArgs e)
		{
			int totalnum = Int32.Parse( txt24.Text ) + Int32.Parse( txt68.Text ) + Int32.Parse( txt1012.Text ) +
				Int32.Parse( txt1416.Text ) + Int32.Parse( txtS.Text ) + Int32.Parse( txtM.Text ) +
				Int32.Parse( txtL.Text ) + Int32.Parse( txtXL.Text ) + Int32.Parse( txtXXL.Text ) +
				Int32.Parse( txtXXXL.Text ) + Int32.Parse( txtXXXXL.Text );

			float totalprice = totalnum * float.Parse( txtUnitPrice.Text );

			try
			{
				DataRow temprow;
				temprow = dsShirtData.Tables["ShirtOrders"].NewRow();
				temprow["manufacturer"] = txtManufacturer.Text;
				temprow["num_24"] = Int32.Parse( txt24.Text );		temprow["num_68"] = Int32.Parse( txt68.Text );
				temprow["num_1012"] = Int32.Parse( txt1012.Text );	temprow["num_1416"] = Int32.Parse( txt1416.Text );
				temprow["num_s"] = Int32.Parse( txtS.Text );			temprow["num_m"] = Int32.Parse( txtM.Text );
				temprow["num_l"] = Int32.Parse( txtL.Text );			temprow["num_xl"] = Int32.Parse( txtXL.Text );
				temprow["num_xxl"] = Int32.Parse( txtXXL.Text );		temprow["num_xxxl"] = Int32.Parse( txtXXXL.Text );
				temprow["num_xxxxl"] = Int32.Parse( txtXXXXL.Text );	temprow["num_other"] = 0;
				temprow["orderNumber"] = Int32.Parse( Request.QueryString["orderNumber"].ToString() );		temprow["sleeveOrPocket"] = txtSleevePocket.SelectedValue;
				temprow["styleNum"] = txtStyleNum.Text;				temprow["totalPrice"] = System.Decimal.Parse( totalprice.ToString() );
				temprow["totalQty"] = totalnum;						temprow["type"] = txtShirtType.SelectedValue;
				temprow["unitPrice"] = System.Decimal.Parse( txtUnitPrice.Text );
				temprow["color"] = txtColor.Text;

				dsShirtData.Tables["ShirtOrders"].Rows.Add( temprow );
				adShirtData.Update( dsShirtData );
			}
			finally
			{
				DataGrid1.DataBind();
			}
		}

		private void figureTotals()
		{
			float totalShirtPrice=0;

			//figure out suggested totals
			foreach ( DataRow row in dsShirtData.Tables["ShirtOrders"].Rows )
			{
				totalShirtPrice += float.Parse(row["totalPrice"].ToString());				
			}

			float totalPrice = totalShirtPrice + float.Parse( txtPMSCharge.Text ) +
				float.Parse( txtArtCharge.Text ) + float.Parse( txtSetUpCharge.Text ) +
				float.Parse( txtRushCharge.Text );

			lblSubTotal.Text = "<small>($" + totalPrice.ToString() + ")</small>";

			/*should only be one row for this suggested total
			foreach ( DataRow row in dsOrder.Tables["Order"].Rows )
			{
				float totalDue;
				float salestax = (totalPrice * float.Parse(row["salesTax"].ToString()));
				lblSalesTax.Text = "<small>($" + salestax.ToString() + ")</small>";
				totalDue = totalPrice + float.Parse( row["shipping"].ToString() ) + salestax;
				lblTotalDue.Text = "<small>($" + totalDue.ToString() + ")</small>";
				lblShipping.Text = "<small>($" + row["shipping"].ToString() + ")</small>";
				float balanceDue = totalDue - float.Parse( row["deposit"].ToString() );
				lblBalanceDue.Text = "<small>($" + balanceDue.ToString() + ")</small>";
			}*/

			//should only be one row for this suggested total
				float totalDue;
				float salestax = (totalPrice * float.Parse(orderReader["salesTax"].ToString()));
				lblSalesTax.Text = "<small>($" + salestax.ToString() + ")</small>";
				totalDue = totalPrice + float.Parse( orderReader["shipping"].ToString() ) + salestax;
				lblTotalDue.Text = "<small>($" + totalDue.ToString() + ")</small>";
				lblShipping.Text = "<small>($" + orderReader["shipping"].ToString() + ")</small>";
				float balanceDue = totalDue - float.Parse( orderReader["deposit"].ToString() );
				lblBalanceDue.Text = "<small>($" + balanceDue.ToString() + ")</small>";
		}


		private void btnAddUpdate_Click(object sender, EventArgs e)
		{
			if( !Page.IsValid )
				return;










			//return;


			SqlConnection cnOrderTracker = new SqlConnection(
				"data source=.;initial catalog=OrderTrackerDB;" +
				"user id=webuser;pwd=theinternet");
			//cnOrderTracker.Open();

			//SqlTransaction trans;
			SqlCommand sql = new SqlCommand();

			//trans = cnOrderTracker.BeginTransaction();

			sql.Connection = cnOrderTracker;
			//sql.Transaction = trans;

			//////////////////////////////////
			//new stuff
			//////////////////////////////////

			ArrayList values = new ArrayList( 27 );

			//optional values don't have quotes
			/*string sqlstring = @"
					UPDATE Orders SET orderNumber='{0}',
						orderDate='{1}', dueDate={2}, recDate={3}, reorderNumber={4},
						shippingMethod={5},	artDueDate={6}, rushReorderRegular='{7}',
						orderType='{8}', xOrderNumber={9}, customerNumber='{10}',
						contactPersonNumber={11}, insideRepNumber={12}, outsideRepNumber={13},
						numColorsFront={14}, numColorsBack={15}, numColorsSleeve={16},
						PMScharge={17}, setupCharge={18}, artCharge={19}, rushCharge={20},
						deposit={21}, subTotal={22}, salesTax={23}, shipping={24},
						totalDue={25}, balanceDue={26} 
					WHERE orderNumber='{27}'";*/

			string sqlstring = @"
					UPDATE Orders SET
						orderDate='{0}', dueDate={1}, recDate={2}, reorderNumber={3},
						shippingMethod={4},	artDueDate={5}, rushReorderRegular='{6}',
						orderType='{7}', xOrderNumber={8}, customerNumber='{9}',
						contactPersonNumber={10}, insideRepNumber={11}, outsideRepNumber={12},
						numColorsFront={13}, numColorsBack={14}, numColorsSleeve={15},
						PMScharge={16}, setupCharge={17}, artCharge={18}, rushCharge={19},
						deposit={20}, subTotal={21}, salesTax={22}, shipping={23},
						totalDue={24}, balanceDue={25} 
					WHERE orderNumber='{26}'";

			//add values to replace
			//values.Add( Int32.Parse( orderNum ) );
			values.Add( txtDate.Text );

			if( txtDueDate.Text != string.Empty )
				values.Add( "'" + txtDueDate.Text + "'" );
			else
				values.Add( "Null" );

			if( txtRecDate.Text != string.Empty )
				values.Add( "'" + txtRecDate.Text + "'" );
			else
				values.Add( "Null" );

			if( txtReorderNum.Text != string.Empty )
				values.Add( "'" + txtReorderNum.Text + "'" );
			else
				values.Add( "Null" );

			lblerror.Text += "<br><br>" + txtShipping.Text + "<br><br>";
			if( txtShipping.Text != string.Empty )
				values.Add( "'" + txtShipping.Text + "'" );
			else
				values.Add( "Null" );

			if( txtArtDueDate.Text != string.Empty )
				values.Add( "'" + txtArtDueDate.Text + "'" );
			else
				values.Add( "Null" );

			values.Add( cbRushRegReorder.SelectedValue.ToString() );

			values.Add( cbType.SelectedValue.ToString() );

			if( txtXOrderNum.Text != string.Empty )
				values.Add( "'" + txtXOrderNum.Text + "'" );
			else
				values.Add( "Null" );

			string tmp = Session["SelectedCustomer"] as string;
			values.Add( tmp.Trim() );

			tmp = Session["SelectedContact"] as string;
			if( tmp != "thereisnocontact" )
			{
				values.Add( "'" + tmp.Trim() + "'" );
			}
			else
				values.Add( "Null" );

			if( txtInsideRep.Text != string.Empty )
				values.Add( "'" + txtInsideRep.Text.Trim() + "'" );
			else
				values.Add( "Null" );

			if( txtOutsideRep.Text != string.Empty )
				values.Add( "'" + txtOutsideRep.Text.Trim() + "'" );
			else
				values.Add( "Null" );

			if( txtColorsFront.Text != string.Empty )
				values.Add( "'" + txtColorsFront.Text + "'" );
			else
				values.Add( "Null" );

			if( txtColorsBack.Text != string.Empty )
				values.Add( "'" + txtColorsBack.Text + "'" );
			else
				values.Add( "Null" );

			if( txtColorsSleeve.Text != string.Empty )
				values.Add( "'" + txtColorsSleeve.Text + "'" );
			else
				values.Add( "Null" );

			if( txtPMSCharge.Text != string.Empty )
				//values.Add( "'" + txtPMSCharge.Text + "'" );
				values.Add( Decimal.Parse( txtPMSCharge.Text ) );
			else
				values.Add( "Null" );

			if( txtSetUpCharge.Text != string.Empty )
				//values.Add( "'" + txtSetUpCharge.Text + "'" );
				values.Add( Decimal.Parse( txtSetUpCharge.Text ) );
			else
				values.Add( "Null" );

			if( txtArtCharge.Text != string.Empty )
				//values.Add( "'" + txtArtCharge.Text + "'" );
				values.Add( Decimal.Parse( txtArtCharge.Text ) );
			else
				values.Add( "Null" );

			if( txtRushCharge.Text != string.Empty )
				//values.Add( "'" + txtRushCharge.Text + "'" );
				values.Add( Decimal.Parse( txtRushCharge.Text ) );
			else
				values.Add( "Null" );

			if( txtDeposit.Text != string.Empty )
				//values.Add( "'" + txtDeposit.Text + "'" );
				values.Add( Decimal.Parse( txtDeposit.Text ) );
			else
				values.Add( "Null" );

			if( txtSubTotal.Text != string.Empty )
				//values.Add( "'" + txtSubTotal.Text + "'" );
				values.Add( Decimal.Parse( txtSubTotal.Text ) );
			else
				values.Add( "Null" );

			if( txtSalesTax.Text != string.Empty )
				//values.Add( "'" + txtSalesTax.Text + "'" );
				values.Add( Decimal.Parse( txtSalesTax.Text ) );
			else
				values.Add( "Null" );

			if( txtShippingAmt.Text != string.Empty )
				//values.Add( "'" + txtShippingAmt.Text + "'" );
				values.Add( Decimal.Parse( txtShippingAmt.Text ) );
			else
				values.Add( "Null" );

			if( txtTotalDue.Text != string.Empty )
				//values.Add( "'" + txtTotalDue.Text + "'" );
				values.Add( Decimal.Parse( txtTotalDue.Text ) );
			else
				values.Add( "Null" );

			if( txtBalanceDue.Text != string.Empty )
				//values.Add( "'" + txtBalanceDue.Text + "'" );
				values.Add( Decimal.Parse( txtBalanceDue.Text ) );
			else
				values.Add( "Null" );

			values.Add( Int32.Parse(orderNum) );

			//put all the values into the string
			sqlstring = String.Format( sqlstring, values.ToArray() );

			//sql = new SqlCommand( sqlstring, cnOrderTrackerDB, trans );
			//////////////////////////////////
			///end new stuff
			//////////////////////////////////

			/*SqlCommand sql = new SqlCommand(
				@"UPDATE Orders SET orderDate=@odate, dueDate=@dueDate,
				recDate=@recDate, reorderNumber=@reorderNumber, shippingMethod=@shippingMethod,
				artDueDate=@artDueDate, rushReorderRegular=@rushReorderRegular, orderType=@orderType,
				xOrderNumber=@xOrderNumber, customerNumber=@customerNumber, contactPersonNumber=@contactPersonNumber,
				insideRepNumber=@insideRepNumber, outsideRepNumber=@outsideRepNumber,
				numColorsFront=@numColorsFront, numColorsBack=@numColorsBack, numColorsSleeve=@numColorsSleeve,
				PMScharge=@PMScharge, setupCharge=@setupCharge, artCharge=@artCharge, rushCharge=@rushCharge,
				deposit=@deposit, subTotal=@subTotal, salesTax=@salesTax, shipping=@shipping,
				totalDue=@totalDue, balanceDue=@balanceDue
				WHERE orderNumber=@onum", cnOrderTracker );*/

			//this transaction is considerably larger than other transactions.  I'm going to
			//worry about concurrency here
			
			//cnOrderTracker.Open();
			//SqlTransaction trans = cnOrderTracker.BeginTransaction();
			int numchanged = 0;
			try
			{
				/*sql.CommandText =
					@"UPDATE [Orders] SET orderDate=@odate, dueDate=@dueDate,
				recDate=@recDate, reorderNumber=@reorderNumber, shippingMethod=@shippingMethod,
				artDueDate=@artDueDate, rushReorderRegular=@rushReorderRegular, orderType=@orderType,
				xOrderNumber=@xOrderNumber, customerNumber=@customerNumber, contactPersonNumber=@contactPersonNumber,
				insideRepNumber=@insideRepNumber, outsideRepNumber=@outsideRepNumber,
				numColorsFront=@numColorsFront, numColorsBack=@numColorsBack, numColorsSleeve=@numColorsSleeve,
				PMScharge=@PMScharge, setupCharge=@setupCharge, artCharge=@artCharge, rushCharge=@rushCharge,
				deposit=@deposit, subTotal=@subTotal, salesTax=@salesTax, shipping=@shipping,
				totalDue=@totalDue, balanceDue=@balanceDue
				WHERE orderNumber=@onum";

				sql.Parameters.Add( "@onum", System.Data.SqlTypes.SqlInt32.Parse(orderNum) );
				sql.Parameters.Add( "@odate", txtDate.Text );
				sql.Parameters.Add( "@dueDate", txtDueDate.Text );
				sql.Parameters.Add( "@recDate", txtRecDate.Text );

				if( txtReorderNum.Text.TrimEnd() == "" )
					sql.Parameters.Add( "@reorderNumber", Convert.DBNull );
				else
					sql.Parameters.Add( "@reorderNumber", txtReorderNum.Text );

				if( txtShipping.Text.TrimEnd() == "" )
					sql.Parameters.Add( "@shippingmethod", Convert.DBNull );
				else
					sql.Parameters.Add( "@shippingMethod", txtShipping.Text );

				sql.Parameters.Add( "@artDueDate", txtArtDueDate.Text );
				sql.Parameters.Add( "@rushReorderRegular", cbRushRegReorder.SelectedValue.ToString() );
				sql.Parameters.Add( "@orderType", cbType.SelectedValue.ToString() );

				if( txtXOrderNum.Text.TrimEnd() == "" )
					sql.Parameters.Add( "@xOrderNumber", Convert.DBNull );
				else
					sql.Parameters.Add( "@xOrderNumber", txtXOrderNum.Text );

				if( (string)Session["SelectedCustomer"] != null )
					sql.Parameters.Add( "@customerNumber", (string)Session["SelectedCustomer"] );
				else
					sql.Parameters.Add( "@customerNumber", Convert.DBNull );

				if( (string)Session["SelectedContact"] != null )
					sql.Parameters.Add( "@contactPersonNumber", (string)Session["SelectedContact"] );
				else
					sql.Parameters.Add( "@contactPersonNumber", Convert.DBNull );

				sql.Parameters.Add( "@insideRepNumber", txtInsideRep.Text );
				sql.Parameters.Add( "@outsideRepNumber", txtOutsideRep.Text );
				sql.Parameters.Add( "@numColorsFront", txtColorsFront.Text );
				sql.Parameters.Add( "@numColorsBack", txtColorsBack.Text );
				sql.Parameters.Add( "@numColorsSleeve", txtColorsSleeve.Text );
				sql.Parameters.Add( "@PMScharge", System.Data.SqlTypes.SqlMoney.Parse(txtPMSCharge.Text) );
				sql.Parameters.Add( "@setupCharge", System.Data.SqlTypes.SqlMoney.Parse(txtSetUpCharge.Text) );
				sql.Parameters.Add( "@artCharge", System.Data.SqlTypes.SqlMoney.Parse(txtArtCharge.Text) );
				sql.Parameters.Add( "@rushCharge", System.Data.SqlTypes.SqlMoney.Parse(txtRushCharge.Text) );
				sql.Parameters.Add( "@deposit", System.Data.SqlTypes.SqlMoney.Parse(txtDeposit.Text) );
				sql.Parameters.Add( "@subTotal", System.Data.SqlTypes.SqlMoney.Parse(txtSubTotal.Text) );
				sql.Parameters.Add( "@salesTax", System.Data.SqlTypes.SqlMoney.Parse(txtSalesTax.Text) );
				sql.Parameters.Add( "@shipping", System.Data.SqlTypes.SqlMoney.Parse(txtShippingAmt.Text) );
				sql.Parameters.Add( "@totalDue", System.Data.SqlTypes.SqlMoney.Parse(txtTotalDue.Text) );
				sql.Parameters.Add( "@balanceDue", System.Data.SqlTypes.SqlMoney.Parse(txtBalanceDue.Text) );
				*/

				cnOrderTracker.Open();
				sql.CommandText = sqlstring;
				numchanged = sql.ExecuteNonQuery();
				lblerror.Text += "executed query<br>";
				//trans.Commit();
				lblerror.Text += "committed query<br>";

				//attempt to update the dataset

				//sqlDataAdapter1.Update( dsOrder, "Order" );
			}
			catch( SqlException se )
			{
				lblerror.Text += "rolling back <br>";
				//trans.Rollback();
				lblerror.Text += se.Message.ToString();
			}
			finally
			{
				cnOrderTracker.Close();
				lblerror.Text += "Updated " + numchanged.ToString() + " Database <br>";
			}

			//Response.Redirect( "viewOrder.aspx?orderNumber=" + orderNum + "neworder=false" );
		}

		private void txtShipping_TextChanged(object sender, System.EventArgs e)
		{
			lblerror.Text += "<br><br>TEXT CHANGED<br><br>";
		}
	}
}

