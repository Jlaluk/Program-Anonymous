using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pgLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        myBusinessLayer = new clsBusinessLayer(Server.MapPath("~/App_Data/"));
        Master.UserFeedBack.Text = "Please enter username and password. If you are new to PA create an account.";
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        clsBusinessLayer myBusinessLayer = new clsBusinessLayer(Server.MapPath("~/App_Data/"));

        bool isValidUser = myBusinessLayer.CheckUserCredentials(Session, txtUsername.Text, txtPassword.Text);

        if (isValidUser)
        {
            Session["NewUser"] = false;
            Session["SessionUsername"] = txtUsername.Text;
            Response.Redirect("~/pgUserDetails.aspx");
        }
        else if (Convert.ToBoolean(Session["LockedSession"]))
        {
            Master.UserFeedBack.Text = "Too many incorrect attempts, login disabled!";
            btnLogin.Visible = false;
        }
        else
        {
            Master.UserFeedBack.Text = "The Username and Password entered are incorrect. Try again.";
        }
    }

    clsBusinessLayer myBusinessLayer;

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        
        //Get Username Length
        int UsernameLength = txtUsername.Text.Length;
        //Get Password Length
        int PasswordLength = txtPassword.Text.Length;
        //Get Usernames from Database
        dsUsers dsFindUser;
        string tempPath = Server.MapPath("~/App_Data/");
        clsBusinessLayer businessLayerObj = new clsBusinessLayer(tempPath);
        dsFindUser = businessLayerObj.FindUser(txtUsername.Text);

        //Check if username already exists
        if (dsFindUser.tblUsers.Rows.Count > 0)
        {
            Master.UserFeedBack.Text = "Username has already been used. Please try a different Username.";
        }
        //Check Username Length
        else if (UsernameLength < 5 || UsernameLength > 12)
        {
            Master.UserFeedBack.Text = "Username must be between 5 and 12 characters in length.";            
        }
        //Check Password Length
        else if (PasswordLength < 6 || PasswordLength > 12)
        {
            Master.UserFeedBack.Text = "Passwords must be between 6 and 12 characters in length.";            
        }
        else
        {
            Session["NewUser"] = true;
            Session["SessionUsername"] = txtUsername.Text;
            myBusinessLayer.InsertUser(txtUsername.Text, txtPassword.Text);
            Response.Redirect("~/pgUserDetails.aspx");
        }
    }
}