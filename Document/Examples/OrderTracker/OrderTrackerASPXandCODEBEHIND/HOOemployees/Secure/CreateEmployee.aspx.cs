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
	/// Summary description for CreateEmployee.
	/// </summary>
	public class CreateEmployee : OrderTrackerEmpBase
	{
		protected System.Web.UI.WebControls.TextBox txtUID;
		protected System.Web.UI.WebControls.TextBox txtPwd;
		protected System.Web.UI.WebControls.TextBox txtName;
		protected System.Web.UI.WebControls.TextBox txtEmpType;
		protected System.Web.UI.WebControls.TextBox txtPhone;
		protected System.Web.UI.WebControls.TextBox txtEmail;
		protected System.Web.UI.WebControls.TextBox txtAdmin;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqUID;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqPwd;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqName;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqEmpType;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqPhone;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqAdmin;
		protected System.Web.UI.WebControls.RegularExpressionValidator regPhone;
		protected System.Web.UI.WebControls.RegularExpressionValidator regEmail;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.ValidationSummary valErrors;
		protected System.Web.UI.WebControls.Button btnAccept;

		private string addEmp="false";
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			base.HeaderMessage = "Create New Employee";
			addEmp = Request.QueryString["addEmp"];

			//postbacks are caused by validator controls if
			//i'm not using an IE based browser
			if( Page.IsPostBack )
				return;

			//if this is an update of an employee, let them edit their info
			if( Context.User.Identity.IsAuthenticated && addEmp=="false" )
			{
				//change the header
				base.HeaderMessage = "Update my profile";

				SqlConnection con = new SqlConnection(
					"data source=.;initial catalog=OrderTrackerDB;" +
					"user id=webuser;pwd=theinternet" );
				SqlCommand cmd = new SqlCommand(
					"SELECT * FROM [Employees] WHERE UID=@id", con );
				cmd.Parameters.Add( "@id", Page.User.Identity.Name );

				con.Open();
				try
				{
					SqlDataReader reader = cmd.ExecuteReader();

					if( reader.Read() )
					{
						//retrieve a value using the column's position
						int pos = reader.GetOrdinal( "employeename" );
						this.txtName.Text = reader.GetString(pos).ToString().TrimEnd();

						//this time let's try not using the position
						this.txtPhone.Text = reader.GetString( reader.GetOrdinal( "phone" ) ).ToString().TrimEnd();

						//convert the rest directly
						this.txtAdmin.Text = reader[ "administrator" ].ToString().TrimEnd();
						if( this.txtAdmin.Text == "1" )
							this.txtAdmin.Text = "1";
						else
							this.txtAdmin.Text = "0";

						this.txtUID.Text = reader[ "UID" ].ToString().TrimEnd();
						this.txtEmpType.Text = reader[ "employeetype" ].ToString().TrimEnd();
						
						//if the email isn't null, get that too
						pos = reader.GetOrdinal( "email" );
						SqlString cel;
						cel = reader.GetSqlString(pos);
						if( !cel.IsNull )
						{
							this.txtEmail.Text = cel.Value.TrimEnd();
						}
					}
				}
				finally
				{
					//close the connection
					con.Close();
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
			this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void updateEmployee()
		{
			ArrayList values = new ArrayList( 7 );

			//optional values don't have quotes
			string sql = @"
					UPDATE [Employees] SET
						UID='{0}', password='{1}', employeename='{2}', employeetype='{3}',
						phone='{4}', email={5}, administrator='{6}'
					WHERE
						UID='{0}'";

			//add values to replace
			values.Add( Context.User.Identity.Name );
			values.Add( txtPwd.Text );
			values.Add( txtName.Text );
			values.Add( txtEmpType.Text );
			values.Add( txtPhone.Text );

			//add optional values
			if( txtEmail.Text != string.Empty )
				values.Add( "'" + txtEmail.Text + "'" );
			else
				values.Add( "Null" );

			values.Add( txtAdmin.Text );

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
					"Couldn't update your information.<br>" +
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

		private void insertEmployee()
		{
				ArrayList values = new ArrayList( 7 );

				//optional values don't have quotes
				string sql = @"
					INSERT INTO Employees
					(UID, password, employeename, employeetype,
					phone, email, administrator)
					VALUES
					('{0}', '{1}', '{2}', '{3}', '{4}', {5}, '{6}')";

				//add values to replace
				values.Add( txtUID.Text );
				values.Add( txtPwd.Text );
				values.Add( txtName.Text );
				values.Add( txtEmpType.Text );
				values.Add( txtPhone.Text );

				//add optional values
				if( txtEmail.Text != string.Empty )
					values.Add( "'" + txtEmail.Text + "'" );
				else
					values.Add( "Null" );

				values.Add( txtAdmin.Text );

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
				if( addEmp == "true" )
				{
					if( Context.User.Identity.IsAuthenticated )
						insertEmployee();
				}
				else
				{
					if( Context.User.Identity.IsAuthenticated )
						updateEmployee();
				}
			}
			else
			{
				lblMessage.Text = "Fix the following errors and retry:";
			}
		}
	}
}
