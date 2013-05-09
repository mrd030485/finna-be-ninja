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
	/// Summary description for addDescriptions2.
	/// </summary>
	public class addDescriptions2 : OrderTrackerEmpBase
	{
		protected System.Web.UI.WebControls.Button acceptButton;
		protected System.Web.UI.WebControls.TextBox txtOtherD;
		protected System.Web.UI.WebControls.TextBox txtSleeveD;
		protected System.Web.UI.WebControls.DropDownList cbSleeveLocation;
		protected System.Web.UI.WebControls.TextBox txtBackD;
		protected System.Web.UI.WebControls.DropDownList cbBackLocation;
		protected System.Web.UI.WebControls.TextBox txtFrontD;
		protected System.Web.UI.WebControls.DropDownList cbFrontLocation;
		protected System.Web.UI.WebControls.Label date;
		protected System.Web.UI.WebControls.CheckBox chkApproved;

		private string addEmp="false";
		private string orderNum=null;
		protected System.Web.UI.WebControls.Label lblerror;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator4;
		private bool hasDescription=false;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			orderNum = Request.QueryString["orderNumber"];

			int answer = loadDescriptionData();

			if( answer > 0 )
			{
				base.HeaderMessage = "Update Art for " + orderNum;
				acceptButton.Text = "Update Descriptions";

				hasDescription = true;
			}
			else
			{
				base.HeaderMessage = "Add Art to " + orderNum;
				acceptButton.Text = "Add Descriptions";

				hasDescription = false;
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

		private int loadDescriptionData()
		{
			int returnvalue = 0;

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
					this.cbFrontLocation.SelectedValue = reader["frontLocation"].ToString().Trim();
					this.cbBackLocation.SelectedValue = reader["backLocation"].ToString().Trim();
					this.cbSleeveLocation.SelectedValue = reader["sleeveLocation"].ToString().Trim();

					if( reader["dateCompleted"].ToString() != string.Empty )
						this.date.Text = reader["dateCompleted"].ToString();
					
					bool myvalue = bool.Parse( reader["artApproved"].ToString().Trim() );
					if( myvalue )
						this.chkApproved.Checked = true;
					else
						this.chkApproved.Checked = false;

					returnvalue=1;
				}
			}
			finally
			{
				con.Close();
				con.Dispose();
			}

			return returnvalue;
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
			values.Add( cbFrontLocation.SelectedValue.ToString() );
			values.Add( cbBackLocation.SelectedValue.ToString() );
			values.Add( cbSleeveLocation.SelectedValue.ToString() );

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
				lblerror.Text += "Could not update description<br>" + se.Message;
			}
			finally
			{
				con.Close();
				con.Dispose();
			}
		}

		private void acceptButton_Click(object sender, System.EventArgs e)
		{
			if( Page.IsValid )
			{
				if( hasDescription )
				{
					updateDescription();
				}
				else
				{

				}
			}
		}
	}
}
