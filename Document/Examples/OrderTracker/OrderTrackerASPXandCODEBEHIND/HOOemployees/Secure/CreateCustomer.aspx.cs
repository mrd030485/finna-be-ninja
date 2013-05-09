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

namespace OrderTrackerv2.HOOemployees.Secure
{
	/// <summary>
	/// Summary description for CreateCustomer.
	/// </summary>
	public class CreateCustomer : OrderTrackerEmpBase
	{
		protected System.Web.UI.WebControls.TextBox txtUID;
		protected System.Web.UI.WebControls.TextBox txtPwd;
		protected System.Web.UI.WebControls.TextBox txtName;
		protected System.Web.UI.WebControls.TextBox txtPhone;
		protected System.Web.UI.WebControls.TextBox txtEmail;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqUID;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqPwd;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqName;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqPhone;
		protected System.Web.UI.WebControls.RegularExpressionValidator regPhone;
		protected System.Web.UI.WebControls.RegularExpressionValidator regEmail;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.ValidationSummary valErrors;
		protected System.Web.UI.WebControls.TextBox txtStreetAddress;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqStreetAddr;
		protected System.Web.UI.WebControls.TextBox txtCity;
		protected System.Web.UI.WebControls.TextBox txtState;
		protected System.Web.UI.WebControls.TextBox txtZip;
		protected System.Web.UI.WebControls.TextBox txtCellPhone;
		protected System.Web.UI.WebControls.RegularExpressionValidator regCellPhone;
		protected System.Web.UI.WebControls.TextBox txtFax;
		protected System.Web.UI.WebControls.RegularExpressionValidator regFax;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqState;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqZip;
		protected System.Web.UI.WebControls.Button btnAccept;

		string customerNum = null;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			base.HeaderMessage = "Create New Customer";

			//postbacks are caused by validator controls if
			//i'm not using an IE based browser
			if( Page.IsPostBack )
				return;

			customerNum = Request.QueryString["customerNum"];

			if( customerNum != null )
			{
				//load customer data
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
			this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void updateCustomer()
		{
			ArrayList values = new ArrayList( 11 );

			//optional values don't have quotes
			string sql = @"
					UPDATE Customers SET
						SID='{0}', password='{1}', name='{2}', streetAddress='{3}',
						city='{4}', state='{5}', zip='{6}', phone='{7}', cellPhone={8},
						fax={9}, email={10}
					WHERE
						SID='{0}'";

			//add values to replace
			values.Add( txtUID.Text );
			values.Add( txtPwd.Text );
			values.Add( txtName.Text );
			values.Add( txtStreetAddress.Text );
			values.Add( txtCity.Text );
			values.Add( txtState.Text );
			values.Add( txtZip.Text );
			values.Add( txtPhone.Text );

			//add optional values
			if( txtEmail.Text != string.Empty )
				values.Add( "'" + txtEmail.Text + "'" );
			else
				values.Add( "Null" );

			if( txtCellPhone.Text != string.Empty )
				values.Add( "'" + txtCellPhone.Text + "'" );
			else
				values.Add( "Null" );

			if( txtFax.Text != string.Empty )
				values.Add( "'" + txtFax.Text + "'" );
			else
				values.Add( "Null" );

			//put all the values into the string
			sql = String.Format( sql, values.ToArray() );

			//connect and do the insert
			SqlConnection con = new SqlConnection(
				"data source=.;initial catalog=OrderTrackerDB;" +
				"user id=webuser;pwd=theinternet");
			SqlCommand cmd = new SqlCommand( sql, con );
			con.Open();

			//this thing is so that when a new customer is added,
			//they will be redirected back to the default page
			bool doredirect=true;

			try
			{
				cmd.ExecuteNonQuery();
			}
			catch( SqlException se )
			{
				doredirect = false;
				this.lblMessage.Visible = true;
				this.lblMessage.Text =
					"Couldn't update customer information.<br>" +
					se.Message.ToString();
			}
			finally
			{
				//we always need to close the connection
				con.Close();
			}

			if( doredirect )
				Response.Redirect( "../Default.aspx" );

		}

		private void insertCustomer()
		{
				ArrayList values = new ArrayList( 11 );

				//optional values don't have quotes
				string sql = @"
					INSERT INTO Customers
					(SID, password, name, streetAddress, city, state, zip,
					phone, cellPhone, fax, email)
					VALUES
					('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', {8}, {9}, {10})";

				//add values to replace
				values.Add( txtUID.Text );
				values.Add( txtPwd.Text );
				values.Add( txtName.Text );
				values.Add( txtStreetAddress.Text );
				values.Add( txtCity.Text );
				values.Add( txtState.Text );
				values.Add( txtZip.Text );
				values.Add( txtPhone.Text );

				//add optional values
				if( txtCellPhone.Text != string.Empty )
					values.Add( "'" + txtCellPhone.Text + "'" );
				else
					values.Add( "Null" );

				if( txtFax.Text != string.Empty )
					values.Add( "'" + txtFax.Text + "'" );
				else
					values.Add( "Null" );

				if( txtEmail.Text != string.Empty )
					values.Add( "'" + txtEmail.Text + "'" );
				else
					values.Add( "Null" );

				//put all the values into the string
				sql = String.Format( sql, values.ToArray() );

				//connect and do the insert
				SqlConnection con = new SqlConnection(
					"data source=.;initial catalog=OrderTrackerDB;" +
					"user id=webuser;pwd=theinternet");
				SqlCommand cmd = new SqlCommand( sql, con );
				con.Open();

				//this thing is so that when a new employee is added,
				//they will be redirected back to the administrator page
				bool doredirect=true;

				try
				{
					cmd.ExecuteNonQuery();
				}
				catch( SqlException se )
				{
					doredirect = false;
					this.lblMessage.Visible = true;
					this.lblMessage.Text =
						"Insert could not be performed.<br>" +
						se.Message.ToString();
				}
				finally
				{
					//we always need to close the connection
					con.Close();
				}

				if( doredirect )
					Response.Redirect( "../Default.aspx" );

		}

		private void btnAccept_Click(object sender, System.EventArgs e)
		{
			if( Page.IsValid )
			{
				if( customerNum != null )
					updateCustomer();
				else
					insertCustomer();
			}
			else
			{
				lblMessage.Text = "Fix the following errors and retry:";
			}
		}
	}
}
