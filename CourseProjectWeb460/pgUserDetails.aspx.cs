using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class pgUserDetails : System.Web.UI.Page
{
    clsBusinessLayer myBusinessLayer;

    //Retrieve Username
    public TextBox Username
    { get { return txtUsername; } }
    //Retrieve City
    public TextBox City
    { get { return txtCity; } }
    //Retrieve State
    public TextBox State
    { get { return txtState; } }
    //Retrieve Favorite Programing Language
    public TextBox FavoriteProgrammingLanguage
    { get { return txtFavProgram; } }
    //Retrieve Least Favorite Programing Language
    public TextBox LeastFavoriteProgrammingLanguage
    { get { return txtLeastProgram; } }
    //Retrieve Date for last program completed
    public TextBox DateLast
    { get { return txtDate; } }

    public TextBox UserID
    { get { return txtUserID; } }

    

    protected void Page_Load(object sender, EventArgs e)
    {
        //Uses Master Page Label to display text on load
        Master.UserFeedBack.Text = "Please fill out user detail information below.";

        myBusinessLayer = new clsBusinessLayer(Server.MapPath("~/App_Data/"));

        if (!IsPostBack)
        {            
            fillFields();
        }
    }

    protected void fillFields()
    {
        dsUsers dsFindUser;

        //Call Session Username from previous page
        String SessionUsername;
        SessionUsername = (string)(Session["SessionUsername"]);
        txtUsername.Text = SessionUsername;

        //Fill User Information using session's username
        string tempPath = Server.MapPath("~/App_Data/");
        clsBusinessLayer businessLayerObj = new clsBusinessLayer(tempPath);



        bool NewUser;
        NewUser = (bool)(Session["NewUser"]);
        try
        {

            dsFindUser = businessLayerObj.FindUser(SessionUsername);

            //returning users will get all information filled
            if (NewUser == false)
            {
                txtUsername.Text = dsFindUser.tblUsers[0].Username;
                txtCity.Text = dsFindUser.tblUsers[0].City;
                txtState.Text = dsFindUser.tblUsers[0].State;
                txtFavProgram.Text = dsFindUser.tblUsers[0].FavoriteLanguage;
                txtLeastProgram.Text = dsFindUser.tblUsers[0].LeastFavoriteLanguage;
                txtDate.Text = dsFindUser.tblUsers[0].LastProgramDate;
                txtUserID.Text = Convert.ToString(dsFindUser.tblUsers[0].UserID);
                Session["SessionID"] = dsFindUser.tblUsers[0].UserID;

                //BindApplicationGridView(UserID);
                BindApplicationGridView(txtUsername.Text);

                Master.UserFeedBack.Text = "Information Found";


            }

            //new users will only have username and userID filled
            else
            {
                txtUsername.Text = dsFindUser.tblUsers[0].Username;
                txtUserID.Text = Convert.ToString(dsFindUser.tblUsers[0].UserID);
                Master.UserFeedBack.Text = "Fill in information and Update.";

            }
        }
        catch (Exception error)
        {
            string message = "Something went wrong...";
            Master.UserFeedBack.Text = message + error.Message;
        }
    }

    

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        

    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        dsUsers dsDeleteUser;

        string tempPath = Server.MapPath("~/App_Data/");
        clsBusinessLayer businessLayerObj = new clsBusinessLayer(tempPath);

        try
        {
            dsDeleteUser = businessLayerObj.RemoveUser(txtUsername.Text);

            if(dsDeleteUser.tblUsers.Rows.Count > 0)
            {
                Master.UserFeedBack.Text = "User Deleted";
            }

            else
            {
                Master.UserFeedBack.Text = "User Deleted";
            }
            btnExport.Visible = false;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;

        }
        catch (Exception error)
        {
            string message = "Something went wrong...";
            Master.UserFeedBack.Text = message + error.Message;
        }
    }

    private dsApplications BindApplicationGridView(string Username)
    {
        string tempPath = Server.MapPath("~/App_Data/");
        clsBusinessLayer myBusinessLayer = new clsBusinessLayer(tempPath);

        dsApplications applicationListing = myBusinessLayer.FillApplications(txtUsername.Text);

        gvApplications.DataSource = applicationListing.tblPrograms;

        gvApplications.DataBind();
        Cache.Insert("ApplicationDataSet", applicationListing);

        return applicationListing;
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        gvApplications.DataSource = myBusinessLayer.WriteApplicationXMLFile(Cache, txtUsername.Text);
        gvApplications.DataBind();

        Master.UserFeedBack.Text = "Stats Exported. ";
    }
}