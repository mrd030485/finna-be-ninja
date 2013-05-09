using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;

namespace OrderTrackerv2 
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public Global()
		{
			InitializeComponent();
		}	
		
		protected void Application_Start(Object sender, EventArgs e)
		{

		}
 
		protected void Session_Start(Object sender, EventArgs e)
		{

		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_Error(Object sender, EventArgs e)
		{

		}

		protected void Session_End(Object sender, EventArgs e)
		{

		}

		protected void Application_End(Object sender, EventArgs e)
		{

		}

		private void Global_AcquireRequestState(object sender, System.EventArgs e)
		{ 
			//This tells the global to check whether code "Name-John" is in the session 
			//variable, called "Authenticated". To say it simple, 
			//checks, whether someone set this 
			//variable.
			if((string)Session["Authenticated"] != "TempAuth")
				// If yes, do nothing, so the requested page will load.
			{
				// If it's not set yet, redirect to the login page, 
				// if the caller is not the login page already. If it is, we don't 
				//want loops, so let is load
				if(!Request.Path.EndsWith("Login.aspx"))
				{
					Response.Redirect("Login.aspx");
					Response.End();
				}
			}
		}
			
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.components = new System.ComponentModel.Container();
			//this.AcquireRequestState += new System.EventHandler(this.Global_AcquireRequestState);
		}
		#endregion
	}
}

