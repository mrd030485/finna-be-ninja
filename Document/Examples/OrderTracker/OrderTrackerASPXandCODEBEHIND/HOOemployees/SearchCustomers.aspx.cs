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
	/// Summary description for SearchCustomers.
	/// </summary>
	public class SearchCustomers : OrderTrackerEmpBase
	{
		protected System.Web.UI.WebControls.Label lblLimit;
		protected System.Web.UI.WebControls.DataGrid grdResults;
		protected System.Web.UI.WebControls.Panel pnlSearch;
		protected System.Web.UI.WebControls.TextBox txtCustName;
		protected System.Web.UI.WebControls.TextBox txtCustUName;
		protected System.Web.UI.WebControls.Button btnSearch;
		protected System.Data.SqlClient.SqlConnection cnOrderTrackerDB;
		protected System.Data.DataSet dsResults;
		protected System.Web.UI.WebControls.Label lblerror;
		protected System.Web.UI.WebControls.Panel pnlResults;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			base.HeaderMessage = "Search for a Customer";

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
			this.grdResults.SelectedIndexChanged += new System.EventHandler(this.grdResults_SelectedIndexChanged);
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

			//grdResults.AutoGenerateColumns = false;

			//limit maximum result size
			string sql = "SELECT TOP " + limit + @"
				[Customers].SID, [Customers].name
			FROM [Customers] ";

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
				if( dsResults.Tables["Order"].Rows.Count == 1 )
					lblLimit.Text = "Found " + dsResults.Tables["Order"].Rows.Count + " customer.";
				else
					lblLimit.Text = "Found " + dsResults.Tables["Order"].Rows.Count + " customers.";
			}
			else
			{
				lblLimit.Text = "This is only the first " + dsResults.Tables["Order"].Rows.Count + " customers.";
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

		private void grdResults_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string SelectedCustomer = grdResults.SelectedItem.Cells[1].Text;
			Session["SelectedCustomer"] = SelectedCustomer;

			int num = Session.Timeout;

			string temp = Session["SelectedCustomer"].ToString();

			if( Request.QueryString["fromPage"] == "viewOrder" )
				Response.Redirect( "ViewOrder2.aspx?orderNumber=" + Request.QueryString["orderNumber"] +
					"&newOrder=inProgress&selectCust=" + SelectedCustomer + "&selectCont=" +
					Request.QueryString["selectCont"]);
			else
				Response.Redirect( "Secure/CreateCustomer.aspx?customerNum=" + SelectedCustomer );
			//if( Request.QueryString["from"] == "createContact" )
				//lblerror.Text += Page.Request.RawUrl.ToString();
				//lblerror.Text += Page.Request.UrlReferrer.ToString();
				//lblerror.Text += Request.
				//Response.Redirect( Page.Request.RawUrl.ToString() );
		}
	}
}
