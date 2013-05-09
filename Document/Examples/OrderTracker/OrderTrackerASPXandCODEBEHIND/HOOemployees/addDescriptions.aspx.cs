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
using System.IO;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using OrderTrackerv2;

namespace OrderTrackerv2.HOOemployees
{
	/// <summary>
	/// Summary description for addDescriptions.
	/// </summary>
	public class addDescriptions : OrderTrackerEmpBase
	{
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Label errorlabel;
		protected System.Drawing.Image Image2;
	
		private string orderNum = null;
		protected System.Web.UI.WebControls.TextBox txtFrontD;
		protected System.Web.UI.WebControls.TextBox txtBackD;
		protected System.Web.UI.WebControls.TextBox txtSleeveD;
		protected System.Web.UI.WebControls.TextBox txtOtherD;
		protected System.Web.UI.WebControls.CheckBox chkApproved;
		protected System.Web.UI.WebControls.Label date;
		protected System.Web.UI.WebControls.DropDownList cbFrontLocation;
		protected System.Web.UI.WebControls.DropDownList cbBackLocation;
		protected System.Web.UI.WebControls.DropDownList cbSleeveLocation;
		protected System.Web.UI.WebControls.Button acceptButton;
		private string pos = null;
		protected System.Web.UI.WebControls.Label lblerror;
		private bool hasDescription = false;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			orderNum = Request.QueryString["orderNumber"];
            
			/*load current description data or initialize description
			sqlDataAdapter1.SelectCommand.Parameters["@onum"].Value = orderNum;
			int isDescription=0;
			isDescription = sqlDataAdapter1.Fill( dsArtData );
			if( isDescription > 0 ) hasDescription=true;
			else hasDescription=false;*/

			int isDescription=0;
			isDescription = loadDescriptionData();
			if( isDescription > 0 ) hasDescription=true;
			else hasDescription=false;

			if( hasDescription )
			{
				base.HeaderMessage = "Update Art Description for Order " + orderNum;
				acceptButton.Text = "Update Description";
			}
			else
			{
				base.HeaderMessage = "Add Art Description for Order " + orderNum;
				acceptButton.Text = "Add Description";
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
			this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void insertDescriptionData()
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
			values2.Add( "'" + cbFrontLocation.SelectedValue.ToString() + "'" );
			values2.Add( "'" + cbBackLocation.SelectedValue.ToString() + "'" );
			values2.Add( "'" + cbSleeveLocation.SelectedValue.ToString() + "'" );
			if( chkApproved.Checked )
			{
				values2.Add( date.Text );
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
				lblerror.Visible = true;
				lblerror.Text =
					"Insert could not be performed.<br>" +
					se.Message.ToString();
			}
			finally
			{
				//we always need to close the connection
				con.Close();
			}
		}

		private void updateDescriptionData()
		{
			ArrayList values2 = new ArrayList(11);

			//insert blank art information
			string sqlstring = @"
					UPDATE [Art] SET
						frontDescription={0}, backDescription={1},
						sleeveDescription={2}, otherDescription={3}, frontLocation={4},
						backLocation={5}, sleeveLocation={6},
						dateCompleted={7}, artApproved='{8}'
					WHERE
						orderNumber='{9}'";

			values2.Add( "'" + txtFrontD.Text + "'" );
			values2.Add( "'" + txtBackD.Text + "'" );
			values2.Add( "'" + txtSleeveD.Text + "'" );
			values2.Add( "'" + txtOtherD.Text + "'" );
			values2.Add( "'" + cbFrontLocation.SelectedValue.ToString() + "'" );
			values2.Add( "'" + cbBackLocation.SelectedValue.ToString() + "'" );
			values2.Add( "'" + cbSleeveLocation.SelectedValue.ToString() + "'" );
			if( chkApproved.Checked )
			{
				values2.Add( date.Text );
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
			values2.Add( Int32.Parse(orderNum) );

			//fill string
			sqlstring = String.Format( sqlstring, values2.ToArray() );

			//connect and do the insert
			SqlConnection con2 = new SqlConnection(
				"data source=.;initial catalog=OrderTrackerDB;" +
				"user id=webuser;pwd=theinternet");
			SqlCommand cmd2 = new SqlCommand( sqlstring, con2 );
			con2.Open();

			try
			{
				cmd2.ExecuteNonQuery();
			}
			catch( SqlException se )
			{
				lblerror.Visible = true;
				lblerror.Text =
					"Update could not be performed.<br>" +
					se.Message.ToString();
			}
			finally
			{
				//we always need to close the connection
				con2.Close();
			}

			/*DataRow artRow = dsArtData.Art.Rows[0];
			artRow.BeginEdit();
			artRow["frontDescription"] = txtFrontD.Text;
			artRow["backDescription"] = txtBackD.Text;
			artRow["sleeveDescription"] = txtSleeveD.Text;
			artRow["otherDescription"] = txtOtherD.Text;
			artRow["frontLocation"] = cbFrontLocation.SelectedValue.ToString();
			artRow["backLocation"] = cbBackLocation.SelectedValue.ToString();
			artRow["sleeveLocation"] = cbSleeveLocation.SelectedValue.ToString();
			if( chkApproved.Checked )
			{
				artRow["dateCompleted"] = DateTime.Now.ToShortDateString();
				artRow["artApproved"] = 1;
			}
			else
			{
				artRow["dateCompleted"] = Convert.DBNull;
				artRow["artApproved"] = 0;
			}

			artRow.EndEdit();

			DataSet dsChanges =	dsArtData.GetChanges(DataRowState.Modified);

			sqlDataAdapter1.Update( dsChanges );
			dsArtData.AcceptChanges();*/
		}

		private int loadDescriptionData()
		{
			int returnvalue=0;

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
					if( reader["frontDescription"].ToString() != string.Empty )
						txtFrontD.Text = reader["frontDescription"].ToString();
					if( reader["backDescription"].ToString() != string.Empty )
						txtBackD.Text = reader["backDescription"].ToString();
					if( reader["sleeveDescription"].ToString() != string.Empty )
						txtSleeveD.Text = reader["sleeveDescription"].ToString();
					if( reader["otherDescription"].ToString() != string.Empty )
						txtOtherD.Text = reader["otherDescription"].ToString();
					if( reader["frontLocation"].ToString() != string.Empty )
						cbFrontLocation.SelectedValue = reader["frontLocation"].ToString().Trim();
					if( reader["backLocation"].ToString() != string.Empty )
						cbBackLocation.SelectedValue = reader["backLocation"].ToString().Trim();
					if( reader["sleeveLocation"].ToString() != string.Empty )
						cbSleeveLocation.SelectedValue = reader["sleeveLocation"].ToString().Trim();
					if( reader["dateCompleted"].ToString() != string.Empty )
						date.Text = reader["dateCompleted"].ToString().Trim();
					if( reader["artApproved"].ToString() != string.Empty )
						chkApproved.Checked = bool.Parse( reader["artApproved"].ToString() );

					returnvalue = 1;
				}
			}
			finally
			{
				//close the connection
				con.Close();
			}

			return returnvalue;
		}

		private void acceptButton_Click(object sender, System.EventArgs e)
		{
			if( hasDescription )
			{
				updateDescriptionData();
			}
			else
			{
				insertDescriptionData();
			}

			Response.Redirect( "addDescriptions.aspx?orderNumber=" + orderNum );
		}
	}
}
