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
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace OrderTrackerv2.HOOemployees
{
	/// <summary>
	/// Summary description for SearchOrder.
	/// </summary>
	public class SearchOrder : OrderTrackerEmpBase
	{
		protected System.Web.UI.WebControls.Label lblLimit;
		protected System.Web.UI.WebControls.DataGrid grdResults;
		protected System.Web.UI.WebControls.Panel pnlSearch;
		protected System.Web.UI.WebControls.TextBox txtCustName;
		protected System.Web.UI.WebControls.TextBox txtCustUName;
		protected System.Web.UI.WebControls.TextBox txtOrderNumber;
		protected System.Web.UI.WebControls.TextBox txtSalesRepUName;
		protected System.Web.UI.WebControls.TextBox txtSalesRepName;
		protected System.Web.UI.WebControls.Button btnSearch;
		protected System.Data.SqlClient.SqlConnection cnOrderTrackerDB;
		protected System.Data.DataSet dsResults;
		protected System.Web.UI.WebControls.Panel pnlResults;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			base.HeaderMessage = "Search for an Order";

			//if we've already searched, let's load the previous search
			if( Session["search"] != null )
				BindFromSession();
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
			this.dsResults = new System.Data.DataSet();
			((System.ComponentModel.ISupportInitialize)(this.dsResults)).BeginInit();
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// cnOrderTrackerDB
			// 
			this.cnOrderTrackerDB.ConnectionString = ((string)(configurationAppSettings.GetValue("cnOrderTrackerDB.ConnectionString", typeof(string))));
			// 
			// dsResults
			// 
			this.dsResults.DataSetName = "NewDataSet";
			this.dsResults.Locale = new System.Globalization.CultureInfo("en-US");
			this.Load += new System.EventHandler(this.Page_Load);
			((System.ComponentModel.ISupportInitialize)(this.dsResults)).EndInit();

		}
		#endregion

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			int limit = Convert.ToInt32(
				ConfigurationSettings.AppSettings["searchLimit"] );

			//limit maximum result size
			string sql = "SELECT TOP " + limit + @"
				[Orders].orderNumber, [Orders].orderDate,
				[Orders].orderType, [Customers].SID, [Customers].name,
				[Employees].UID, [Employees].employeename
			FROM [Orders]
			LEFT OUTER JOIN [Customers] ON
				[Orders].customerNumber = [Customers].SID
			LEFT OUTER JOIN [Employees] ON
				([Orders].insideRepNumber = [Employees].UID OR
					[Orders].outsideRepNumber = [Employees].UID) ";

			//build in the parameters that are accumulated from the search query
			Hashtable values = new Hashtable();

			StringBuilder qry = new StringBuilder();

			if( txtCustName.Text != String.Empty )
			{
				qry.Append( "[Customers].name LIKE @cname AND " );
				values.Add( "@cname", "%" + txtCustName.Text + "%" );
			}
			if( txtCustUName.Text != String.Empty )
			{
				qry.Append( "[Customers].SID LIKE @uname AND " );
				values.Add( "@uname", "%" + txtCustUName.Text + "%" );
			}
			if( txtOrderNumber.Text != String.Empty )
			{
				qry.Append( "[Orders].orderNumber = @onum AND " );
				values.Add( "@onum", txtOrderNumber.Text );
			}
			if( txtSalesRepUName.Text != String.Empty )
			{
				qry.Append( "[Employees].UID LIKE @euname AND " );
				values.Add( "@euname", "%" + txtSalesRepUName.Text + "%" );
			}
			if( txtSalesRepName.Text != String.Empty )
			{
				qry.Append( "[Employees].employeename LIKE @ename AND " );
				values.Add( "@ename", "%" + txtSalesRepName.Text + "%" );
			}

			string filter = qry.ToString();
			if( filter.Length != 0 )
			{
				//get rid of that last AND!
				sql += " WHERE " + filter.Remove( filter.Length - 4, 4 );
			}

			SqlDataAdapter ad = new SqlDataAdapter( sql, cnOrderTrackerDB );
			//add parameters
			foreach( DictionaryEntry prm in values )
			{
				ad.SelectCommand.Parameters.Add(
					prm.Key.ToString(), prm.Value );
			}

			dsResults = new DataSet();

			ad.Fill( dsResults, "Order" );

			//adjust label for results
			if( dsResults.Tables["Order"].Rows.Count < limit )
			{
				lblLimit.Text = "Found " + dsResults.Tables["Order"].Rows.Count + " orders.";
			}
			else
			{
				lblLimit.Text = "This is only the first " + dsResults.Tables["Order"].Rows.Count + " orders.";
			}

			//put results in session
			Session["search"] = dsResults;

			BindFromSession();
		}

		private void BindFromSession()
		{
			dsResults = (DataSet)Session["search"];
			grdResults.DataBind();
		}

		private void btnSearchFurther_Click(object sender, System.EventArgs e)
		{
			dsResults = Session["search"] as DataSet;

			//return a normal search if the session doesn't exist anymore
			if( dsResults == null ) btnSearch_Click( sender, e );

			//here this is a filter not an sql query so no parameters :<
			//similar to the regular search, though
			StringBuilder qry = new StringBuilder();
			if( txtCustName.Text != String.Empty )
			{
				qry.Append( "name LIKE '%" );
				qry.Append( txtCustName.Text ).Append( "%' AND " );
			}
			if( txtCustUName.Text != String.Empty )
			{
				qry.Append( "SID LIKE '%" );
				qry.Append( txtCustUName.Text ).Append( "%' AND " );
			}
			if( txtOrderNumber.Text != String.Empty )
			{
				qry.Append( "orderNumber = " );
				qry.Append( txtOrderNumber.Text ).Append( " AND " );
			}
			if( txtSalesRepUName.Text != String.Empty )
			{
				qry.Append( "UID1 LIKE '%" );
				qry.Append( txtSalesRepUName.Text ).Append( "%' AND " );
			}
			if( txtSalesRepName.Text != String.Empty )
			{
				qry.Append( "employeename LIKE '%" );
				qry.Append( txtSalesRepName.Text ).Append( "%' AND " );
			}

			string filter = qry.ToString();
			if( filter.Length != 0 )
			{
				filter = filter.Remove( filter.Length - 4, 4 );
			}

			DataRow[] rows = dsResults.Tables["Order"].Select( filter );

			//get the results back
			dsResults = dsResults.Clone();
			foreach( DataRow row in rows )
			{
				dsResults.Tables["Order"].ImportRow( row );
			}

			//put the results in the session
			Session["search"] = dsResults;

			BindFromSession();
		}
	}
}
