using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Caching;

public class clsBusinessLayer
{

    string dataPath;
    clsDataLayer myDataLayer;

    public clsBusinessLayer(string serverMappedPath)
    {
        dataPath = serverMappedPath;
        myDataLayer = new clsDataLayer(dataPath + "Users.mdb");
    }


    public DataSet WriteApplicationXMLFile(System.Web.Caching.Cache appCache, string Username)
    {
        
        DataSet xmlDataSet = (DataSet)appCache["ApplicationDataSet"];
        
        xmlDataSet.WriteXml(dataPath + Username + ".xml");
        
        return xmlDataSet;
    }

    public bool CheckUserCredentials(System.Web.SessionState.HttpSessionState currentSession, string username, string password)
    {
        //Set starting session as unlocked
        currentSession["LockedSession"] = false;

        //Add one to current attempts
        int totalAttempts = Convert.ToInt32(currentSession["AttemptCount"]) + 1;
        currentSession["AttemptCount"] = totalAttempts;

        //Locks login function when total attempts are met
        if (totalAttempts > 4)
        {
            currentSession["LockedSession"] = true;            
        }

        return myDataLayer.ValidateUser(username, password);
    }

    public string InsertUser(string Username, string Password)
    {
        string resultMessage = "User Added Successfully.";

        try
        {
            //Call method InsertUser from DataLayer
            myDataLayer.InsertUser(Username, Password);
        }
        catch (Exception error)
        {
            //Exception message when update fails
            resultMessage = "Error adding User. ";
            resultMessage = resultMessage = error.Message;
        }

        return resultMessage;
    }

    public dsUsers FindUser(string Username)
    {
        dsUsers dsFoundUser = myDataLayer.findUser(Username);

        if (dsFoundUser.tblUsers.Rows.Count > 0)
        {
            System.Data.DataRow userRecord = dsFoundUser.tblUsers.Rows[0];

            if (userRecord["Username"] == DBNull.Value)
                userRecord["Username"] = string.Empty;
            if (userRecord["City"] == DBNull.Value)
                userRecord["City"] = string.Empty;
            if (userRecord["State"] == DBNull.Value)
                userRecord["State"] = string.Empty;
            if (userRecord["FavoriteLanguage"] == DBNull.Value)
                userRecord["FavoriteLanguage"] = string.Empty;
            if (userRecord["LeastFavoriteLanguage"] == DBNull.Value)
                userRecord["LeastFavoriteLanguage"] = string.Empty;
            if (userRecord["LastProgramDate"] == DBNull.Value)
                userRecord["LastProgramDate"] = string.Empty;            
        }
        return dsFoundUser;
    }

    public dsUsers RemoveUser(string Username)
    {
        dsUsers dsRemoveUser = myDataLayer.deleteUser(Username);

        return dsRemoveUser;
    }

    public dsApplications FillApplications(string Username)
    {
        dsApplications dsFillApplications = myDataLayer.listApplications(Username);

        return dsFillApplications;
    }

    public string UpdateUser(string username, string city, string state, string favoriteLanguage, string leastFavoriteLanguage,
        string dateLastProgramCompleted, int userID)
    {
        string resultMessage = "Customer Updated Successfully.";
        try
        {
            myDataLayer.UpdateUser(username, city, state, favoriteLanguage, leastFavoriteLanguage,
        dateLastProgramCompleted, userID);
        }

        catch(Exception error)
        {
            resultMessage = "Error updating user, check form data.";
            resultMessage = resultMessage + error.Message;
        }
        return resultMessage;

    }
}