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
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace OrderTrackerv2
{
	/// <summary>
	/// Summary description for LoadImage.
	/// </summary>
	public class LoadImage : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			string orderNum = Request.QueryString["orderNumber"];
			string position = Request.QueryString["position"];

			// create an image object, using the filename we just retrieved
			SqlConnection cnOrderTracker = new SqlConnection(
				"data source=.;initial catalog=OrderTrackerDB;" +
				"user id=webuser;pwd=theinternet" );
			SqlCommand adOrder = new SqlCommand(
				@"SELECT [ArtThumbnail].image, [ArtThumbnail].type
				FROM [ArtThumbnail] WHERE [ArtThumbnail].orderNumber=@Onum
				AND [ArtThumbnail].position = @pos", cnOrderTracker );
			adOrder.Parameters.Add( "@Onum", orderNum );
			adOrder.Parameters.Add( "@pos", position );

			try
			{
				cnOrderTracker.Open();
				SqlDataReader reader = adOrder.ExecuteReader();

				if ( reader.Read()) //yup we found our image
				{
					Response.ContentType = reader["type"].ToString();
					Response.BinaryWrite( (byte[]) reader["image"] );
					
					cnOrderTracker.Close();
				}
				//connection.Close();

				//Byte[] imageData = (Byte[])reader.g;
					//System.IO.MemoryStream stream = new System.IO.MemoryStream(imageData);

					//System.Web.UI.WebControls.Image Image1;
					//	Bitmap temp;
					//temp = new Bitmap( stream );
			}
			finally
			{
				cnOrderTracker.Close();
			}
			/*make a memory stream to work with the image bytes
			MemoryStream imageStream = new MemoryStream();

			// put the image into the memory stream
			thumbnailImage.Save(imageStream, System.Drawing.Imaging.ImageFormat.Jpeg);

			// make byte array the same size as the image
			byte[] imageContent = new Byte[imageStream.Length];

			// rewind the memory stream
			imageStream.Position = 0;

			// load the byte array with the image
			imageStream.Read(imageContent, 0, (int)imageStream.Length);

			// return byte array to caller with image type
			Response.ContentType = "image/jpeg";
			Response.BinaryWrite(imageContent);*/
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
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
