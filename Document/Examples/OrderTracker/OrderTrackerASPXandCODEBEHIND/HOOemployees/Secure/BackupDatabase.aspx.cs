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
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace OrderTrackerv2.HOOemployees.Secure
{
	/// <summary>
	/// Summary description for BackupDatabase.
	/// </summary>
	public class BackupDatabase : OrderTrackerEmpBase
	{
		protected System.Web.UI.WebControls.Button btnBackup;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

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
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = ((string)(configurationAppSettings.GetValue("cnOrderTrackerDB.ConnectionString", typeof(string))));
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnBackup_Click(object sender, System.EventArgs e)
		{
			SqlConnection cn = new SqlConnection(
				"data source=.;initial catalog=OrderTrackerDB;" +
				"user id=webuser;pwd=theinternet" );

			SqlCommand cmd = new SqlCommand("BACKUP DATABASE [OrderTrackerDB] TO DISK = 'C:\\Inetpub\\wwwroot\\OrderTrackerv2\\backup.bak'", cn);
			cn.Open();

			bool dodownload = true;

			try
			{
				cmd.ExecuteNonQuery();
			}
			catch
			{
				dodownload = false;
			}
			finally
			{
				cn.Close();
			}

			if( dodownload )
				DownloadFile( "../../backup.bak", true );
		}

		private void DownloadFile( string fname, bool forceDownload )
		{
			string path = MapPath( fname );
			string name = Path.GetFileName( path );
			string ext = Path.GetExtension( path );
			string type = "";
			// set known types based on file extension  
			if ( ext != null )
			{
				switch( ext.ToLower() )
				{
				    case ".bak":
					case ".htm":
					case ".html":
						type = "text/HTML";
						break;
  
					case ".txt":
						type = "text/plain";
						break;
     
					case ".doc":
					case ".rtf":
						type = "Application/msword";
						break;
				}
			}
			if ( forceDownload )
			{
				Response.AppendHeader( "content-disposition",
					"attachment; filename=" + name );
			}
			if ( type != "" )   
				Response.ContentType = type;
			Response.WriteFile( path );
			Response.End();    
		}
	}
}
