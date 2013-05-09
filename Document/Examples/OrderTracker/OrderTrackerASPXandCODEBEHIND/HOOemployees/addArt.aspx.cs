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
	/// Summary description for addArt.
	/// </summary>
	public class addArt : OrderTrackerEmpBase
	{
		protected System.Web.UI.WebControls.DropDownList artPosition;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqPosition;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Button btnUpload;
		protected System.Data.DataSet ds;
		protected System.Web.UI.HtmlControls.HtmlInputFile uploadArtwork;
		protected System.Web.UI.WebControls.Label errorlabel;
		protected System.Drawing.Image Image2;
		protected System.Web.UI.WebControls.Button Button1;
	
		private string orderNum = null;
		private string pos = null;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			orderNum = Request.QueryString["orderNumber"];
			pos = Request.QueryString["position"];

			if( pos != "none" )
			{
				artPosition.SelectedValue = pos;
				btnUpload.Visible = false;
			}
			else
			{
				Button1.Visible = false;
			}
			//orderNum = "51047";
			base.HeaderMessage = "Add Art to Order " + orderNum;
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
			this.ds = new System.Data.DataSet();
			((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
			this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
			// 
			// ds
			// 
			this.ds.DataSetName = "NewDataSet";
			this.ds.Locale = new System.Globalization.CultureInfo("en-US");
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);
			((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();

		}
		#endregion


		private void btnUpload_Click(object sender, System.EventArgs e)
		{
			if (Page.IsValid) //save the image
			{
				Stream imgStream = uploadArtwork.PostedFile.InputStream;
				int imgLen = uploadArtwork.PostedFile.ContentLength;
				string imgContentType = uploadArtwork.PostedFile.ContentType;
				string imgPosition = artPosition.SelectedValue;
				byte[] imgBinaryData = new byte[imgLen];
				int n = imgStream.Read(imgBinaryData,0,imgLen);

				int RowsAffected = SaveToDB( imgPosition, imgBinaryData,imgContentType);
				if ( RowsAffected>0 )
				{
					Response.Redirect( "viewOrder.aspx?orderNumber=" + orderNum + "&newOrder=false");
				}
				else
				{
					errorlabel.Text = "An error occurred uploading the image";
				}

			}
		}

		private int SaveToDB(string imgPosition, byte[] imgbin, string imgcontenttype)
		{
			//use the web.config to store the connection string
			SqlConnection connection = new SqlConnection(
				"data source=.;initial catalog=OrderTrackerDB;" +
				"user id=webuser;pwd=theinternet" );
			SqlCommand command = new SqlCommand(
				@"INSERT INTO ArtThumbnail (orderNumber, filename, position, image, type)
				VALUES (@order_num, @file_name, @img_pos, @img_data, @img_contenttype)", connection );

			SqlParameter param0 = new SqlParameter( "@order_num", SqlDbType.Int, 4 );
			param0.Value = Int32.Parse( orderNum );
			command.Parameters.Add( param0 );

			SqlParameter param1 = new SqlParameter( "@file_name", SqlDbType.NChar, 20 );
			param1.Value = uploadArtwork.PostedFile.FileName;
			command.Parameters.Add( param1 );

			SqlParameter param2 = new SqlParameter( "@img_pos", SqlDbType.NChar,20 );
			param2.Value = imgPosition;
			command.Parameters.Add( param2 );

			SqlParameter param3 = new SqlParameter( "@img_data", SqlDbType.Image );
			param3.Value = imgbin;
			command.Parameters.Add( param3 );

			SqlParameter param4 = new SqlParameter( "@img_contenttype", SqlDbType.NChar,50 );
			param4.Value = imgcontenttype;
			command.Parameters.Add( param4 );

			int numRowsAffected=0;
			try
			{
				connection.Open();
				numRowsAffected = command.ExecuteNonQuery();
			}
			catch
			{
				numRowsAffected = -1;
			}
			finally
			{
				connection.Close();
			}

			return numRowsAffected;
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			if (Page.IsValid) //save the image
			{
				Stream imgStream = uploadArtwork.PostedFile.InputStream;
				int imgLen = uploadArtwork.PostedFile.ContentLength;
				string imgContentType = uploadArtwork.PostedFile.ContentType;
				string imgPosition = artPosition.SelectedValue;
				byte[] imgBinaryData = new byte[imgLen];
				int n = imgStream.Read(imgBinaryData,0,imgLen);

				int RowsAffected = ChangeArtToDB( imgPosition, imgBinaryData,imgContentType);
				if ( RowsAffected>0 )
				{
					Response.Redirect( "viewOrder.aspx?orderNumber=" + orderNum + "&newOrder=false" );
				}
				else
				{
					errorlabel.Text = "An error occurred uploading the image";
				}

			}
		}

		private int ChangeArtToDB(string imgPosition, byte[] imgbin, string imgcontenttype)
		{
			//use the web.config to store the connection string
			SqlConnection connection = new SqlConnection(
				"data source=.;initial catalog=OrderTrackerDB;" +
				"user id=webuser;pwd=theinternet" );
			SqlCommand command = new SqlCommand(
				@"UPDATE [ArtThumbnail] SET
						filename=@file_name, image=@img_data, type=@img_contenttype
					WHERE
						orderNumber=@order_num AND position=@img_pos", connection );

			SqlParameter param0 = new SqlParameter( "@file_name", SqlDbType.NChar, 20 );
			param0.Value = uploadArtwork.PostedFile.FileName;
			command.Parameters.Add( param0 );

			SqlParameter param1 = new SqlParameter( "@img_data", SqlDbType.Image );
			param1.Value = imgbin;
			command.Parameters.Add( param1 );

			SqlParameter param2 = new SqlParameter( "@img_contenttype", SqlDbType.NChar,50 );
			param2.Value = imgcontenttype;
			command.Parameters.Add( param2 );

			SqlParameter param3 = new SqlParameter( "@order_num", SqlDbType.Int, 4 );
			param3.Value = Int32.Parse( orderNum );
			command.Parameters.Add( param3 );

			SqlParameter param4 = new SqlParameter( "@img_pos", SqlDbType.NChar,20 );
			param4.Value = imgPosition;
			command.Parameters.Add( param4 );

			int numRowsAffected=0;
			try
			{
				connection.Open();
				numRowsAffected = command.ExecuteNonQuery();
			}
			catch
			{
				numRowsAffected = -1;
			}
			finally
			{
				connection.Close();
			}

			return numRowsAffected;
		}
	}
}
