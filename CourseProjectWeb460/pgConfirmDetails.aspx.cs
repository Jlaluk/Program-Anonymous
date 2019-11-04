using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pgConfirmDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (PreviousPage.IsCrossPagePostBack)
            {
                

                Master.UserFeedBack.Text = "Please confirm user details.";

                lblUsername.Text = PreviousPage.Username.Text;
                lblCity.Text = PreviousPage.City.Text;
                lblState.Text = PreviousPage.State.Text;
                lblFavProgram.Text = PreviousPage.FavoriteProgrammingLanguage.Text;
                lblLeastProgram.Text = PreviousPage.LeastFavoriteProgrammingLanguage.Text;
                lblDate.Text = PreviousPage.DateLast.Text;
                lblUserID.Text = PreviousPage.UserID.Text;
            }
        }
        catch (Exception)
        {
            Master.UserFeedBack.Text = "There was an error updating your account information. ";
        }


    }





    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Master.UserFeedBack.Text = "Your Account has been Updated";
        Session["NewUser"] = false;

        string tempPath = Server.MapPath("~/App_Data/");
        clsBusinessLayer myBusinessLayer = new clsBusinessLayer(tempPath);


        try
        {
            myBusinessLayer.UpdateUser(lblUsername.Text, lblCity.Text, lblState.Text, lblFavProgram.Text, lblLeastProgram.Text, lblDate.Text, Convert.ToInt32(lblUserID.Text));
            Button1.Visible = false;
        }


        catch (Exception error)
        {
            string message = "Error updating user information, please check input values. ";
            Session["NewUser"] = true;
            Master.UserFeedBack.Text = message + error.Message;
        }
        
    }

    protected void btnAccount_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/pgUserDetails.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}
