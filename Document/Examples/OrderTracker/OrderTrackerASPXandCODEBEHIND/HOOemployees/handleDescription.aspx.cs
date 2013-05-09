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

namespace OrderTrackerv2.HOOemployees
{
	/// <summary>
	/// Summary description for handleDescription.
	/// </summary>
	public class handleDescription : OrderTrackerEmpBase
	{
		protected System.Web.UI.WebControls.CheckBox chkApproved;
		protected System.Web.UI.WebControls.DropDownList cbFrontL;
		protected System.Web.UI.WebControls.TextBox txtFrontD;
		protected System.Web.UI.WebControls.DropDownList cbBackL;
		protected System.Web.UI.WebControls.TextBox txtBackD;
		protected System.Web.UI.WebControls.DropDownList cbSleeveL;
		protected System.Web.UI.WebControls.Label dateApproved;

		private string orderNum=null;
		protected System.Web.UI.WebControls.TextBox txtSleeveD;
		protected System.Web.UI.WebControls.TextBox txtOtherD;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Button btnAddDesc;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator4;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		private bool hasDescription;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			orderNum = Request.QueryString["orderNumber"].ToString();

			if( Page.IsPostBack )
				return;

			if( loadDescription() )
			{
				base.HeaderMessage = "Update Art for Order " + orderNum;
				btnAddDesc.Text = "Update Description";
				//hasDescription = true;
			}
			else
			{
				base.HeaderMessage = "Add Art to Order " + orderNum;
				btnAddDesc.Text = "Add Description";
				//hasDescription = false;
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
			this.btnAddDesc.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private bool loadDescription()
		{
			bool returnvalue = false;

			SqlConnection con = new SqlConnection(
				"data source=.;initial catalog=OrderTrackerDB;" +
				"user id=webuser;pwd=theinternet" );
			SqlCommand cmd = new SqlCommand(
				"SELECT * FROM [Art] WHERE orderNumber=@onum", con );
			cmd.Parameters.Add( "@onum", orderNum );

			con.Open();

			try
			{
				SqlDataReader reader = cmd.ExecuteReader();

				if( reader.Read() )
				{
					string empty = reader["orderNumber"].ToString();

					this.txtFrontD.Text = reader["frontDescription"].ToString();
					this.txtBackD.Text = reader["backDescription"].ToString();
					this.txtSleeveD.Text = reader["sleeveDescription"].ToString();
					this.txtOtherD.Text = reader["otherDescription"].ToString();
					this.cbFrontL.SelectedValue = reader["frontLocation"].ToString().Trim();
					this.cbBackL.SelectedValue = reader["backLocation"].ToString().Trim();
					this.cbSleeveL.SelectedValue = reader["sleeveLocation"].ToString().Trim();

					if( reader["dateCompleted"].ToString() != string.Empty )
					{
						DateTime tempdate = DateTime.Parse( reader["dateCompleted"].ToString() );
						this.dateApproved.Text = tempdate.ToShortDateString();
					}
					
					bool myvalue = bool.Parse( reader["artApproved"].ToString().Trim() );
					if( myvalue )
						this.chkApproved.Checked = true;
					else
						this.chkApproved.Checked = false;

					returnvalue = true;
				}
			}
			finally
			{
				con.Close();
				con.Dispose();
			}

			return returnvalue;
		}

		private void insertDescription()
		{
			ArrayList values2 = new ArrayList(10);

			//insert blank art information
			string sqlstring2 = @"
					INSERT INTO [Art] (
						orderNumber, frontDescription, backDescription, sleeveDescription,
						otherDescription, frontLocation, backLocation, sleeveLocation,
						dateCompleted, artApproved )
					VALUES
					('{0}', {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, '{9}')";

			values2.Add( Int32.Parse(orderNum) );
			values2.Add( "'" + txtFrontD.Text + "'" );
			values2.Add( "'" + txtBackD.Text + "'" );
			values2.Add( "'" + txtSleeveD.Text + "'" );
			values2.Add( "'" + txtOtherD.Text + "'" );
			values2.Add( "'" + cbFrontL.SelectedValue.ToString() + "'" );
			values2.Add( "'" + cbBackL.SelectedValue.ToString() + "'" );
			values2.Add( "'" + cbSleeveL.SelectedValue.ToString() + "'" );
			if( chkApproved.Checked )
			{
				values2.Add( dateApproved.Text );
				if( chkApproved.Checked.ToString() == bool.FalseString )
					values2.Add( 0 );
				else
					values2.Add( 1 );
			}
			else
			{
				values2.Add( "Null" );
				if( chkApproved.Checked.ToString() == bool.FalseString )
					values2.Add( 0 );
				else
					values2.Add( 1 );
			}

			//fill string
			sqlstring2 = String.Format( sqlstring2, values2.ToArray() );

			//connect and do the insert
			SqlConnection con = new SqlConnection(
				"data source=.;initial catalog=OrderTrackerDB;" +
				"user id=webuser;pwd=theinternet");
			SqlCommand cmd = new SqlCommand( sqlstring2, con );
			con.Open();

			try
			{
				cmd.ExecuteNonQuery();
			}
			catch( SqlException se )
			{
				lblError.Visible = true;
				lblError.Text =
					"Insert could not be performed.<br>" +
					se.Message.ToString();
			}
			finally
			{
				//we always need to close the connection
				con.Close();
			}
		}

		private void updateDescription()
		{
			ArrayList values = new ArrayList();

			string sql = @"
				UPDATE [Art] SET
					orderNumber='{0}', frontDescription='{1}', backDescription='{2}',
					sleeveDescription='{3}', otherDescription='{4}', frontLocation='{5}',
					backLocation='{6}', sleeveLocation='{7}', dateCompleted={8},
					artApproved='{9}'
				WHERE
					orderNumber='{10}'";

			values.Add( orderNum );
			values.Add( txtFrontD.Text );
			values.Add( txtBackD.Text );
			values.Add( txtSleeveD.Text );
			values.Add( txtOtherD.Text );
			values.Add( cbFrontL.SelectedValue.ToString() );
			values.Add( cbBackL.SelectedValue.ToString() );
			values.Add( cbSleeveL.SelectedValue.ToString() );

			if( chkApproved.Checked )
			{
				values.Add( "'" + DateTime.Now.ToShortDateString() + "'" );
				values.Add( 1 );
			}
			else
			{
				values.Add( "Null" );
				values.Add( 0 );
			}

			values.Add( orderNum );

			sql = string.Format( sql, values.ToArray() );

			SqlConnection con = new SqlConnection(
				"data source=.;initial catalog=OrderTrackerDB;" +
				"user id=webuser;pwd=theinternet" );
			SqlCommand cmd = new SqlCommand( sql, con );
			con.Open();

			try
			{
				cmd.ExecuteNonQuery();
			}
			catch( SqlException se )
			{
				lblError.Text += "Could not update description<br>" + se.Message;
			}
			finally
			{
				con.Close();
				con.Dispose();
			}
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			if( btnAddDesc.Text == "Update Description" )
			{
				updateDescription();
			}
			else
			{
				insertDescription();
			}

			Response.Redirect( "handleDescription.aspx?orderNumber=" + orderNum );
		}
	}
}
