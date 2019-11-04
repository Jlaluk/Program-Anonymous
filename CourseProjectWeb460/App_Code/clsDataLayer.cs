using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;


public class clsDataLayer
{
    OleDbConnection dbConnection;

    public clsDataLayer(string Path)
    {
        dbConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Path);
    }

    public dsUsers findUser(string Username)
    {
        string sqlStmt = "SELECT * FROM tblUsers where Username like '" + Username + "'";
        OleDbDataAdapter sqlDataAdapter = new OleDbDataAdapter(sqlStmt, dbConnection);

        dsUsers loginDataSet = new dsUsers();
        sqlDataAdapter.Fill(loginDataSet.tblUsers);

        return loginDataSet;
    }

    public dsApplications listApplications(string Username)
    {

        //Select all applications from tblPrograms
        OleDbDataAdapter sqlDataAdapter = new OleDbDataAdapter("SELECT * FROM tblPrograms WHERE Username = '" + Username + "'", dbConnection);

        //Fills information gathered via data adapter
        dsApplications myApplications = new dsApplications();
        sqlDataAdapter.Fill(myApplications.tblPrograms);

        //Returns all applications
        return myApplications;
    }


    public dsUsers deleteUser(string Username)
    {
        string sqlStmt = "DELETE FROM tblUsers WHERE Username = '" + Username + "'";
        OleDbDataAdapter sqlDataAdapter = new OleDbDataAdapter(sqlStmt, dbConnection);

        dsUsers loginDataSet = new dsUsers();
        sqlDataAdapter.Fill(loginDataSet.tblUsers);

        return loginDataSet;
    }

    public void UpdateUser(string username, string city, string state, string favoriteLanguage, string leastFavoriteLanguage,
        string dateLastProgramCompleted, int userID)
    {
        dbConnection.Open();

        string sqlStmt = "UPDATE tblUsers SET Username = @username, " +
            "City = @city, " +
            "State = @state, " +
            "FavoriteLanguage = @favoritelanguage, " +
            "LeastFavoriteLanguage = @leastfavoritelanguage, " +
            "LastProgramDate = @datelastprogramcompleted " +
            "WHERE (tblUsers.UserID = @id)";

        OleDbCommand dbCommand = new OleDbCommand(sqlStmt, dbConnection);

        OleDbParameter param = new OleDbParameter("@username", username);
        dbCommand.Parameters.Add(param);

        dbCommand.Parameters.Add(new OleDbParameter("@city", city));
        dbCommand.Parameters.Add(new OleDbParameter("@state", state));
        dbCommand.Parameters.Add(new OleDbParameter("@favoritelanguage", favoriteLanguage));
        dbCommand.Parameters.Add(new OleDbParameter("@leastfavoritelanguage", leastFavoriteLanguage));
        dbCommand.Parameters.Add(new OleDbParameter("@datelastprogramcompleted", dateLastProgramCompleted));
        dbCommand.Parameters.Add(new OleDbParameter("@id", userID));

        dbCommand.ExecuteNonQuery();

        dbConnection.Close();
    }

    public bool ValidateUser(string username, string password)
    {
        //Open connection to database
        dbConnection.Open();

        //SQL command Selecting all users in database whose accounts are not locked
        string sqlStmt = "SELECT * FROM tblUsers WHERE Username = @username AND Psswrd = @psswrd";

        //Applies sql command to database conneciton
        OleDbCommand dbCommand = new OleDbCommand(sqlStmt, dbConnection);

        //Sets username and password to match database
        dbCommand.Parameters.Add(new OleDbParameter("@username", username));
        dbCommand.Parameters.Add(new OleDbParameter("@psswrd", password));

        //Applies command to connection and starts sqldatareader
        OleDbDataReader dr = dbCommand.ExecuteReader();

        //True/False if account is valid
        Boolean isValidAccount = dr.Read();

        //Close Connection to database
        dbConnection.Close();

        return isValidAccount;
    }

    public void InsertUser(string Username, string Password)
    {
        dbConnection.Open();

        string sqlStmt = "INSERT INTO tblUsers (Username, Psswrd) ";
        sqlStmt += "VALUES (@username, @psswrd)";

        OleDbCommand dbCommand = new OleDbCommand(sqlStmt, dbConnection);

        OleDbParameter param = new OleDbParameter("@username", Username);
        dbCommand.Parameters.Add(param);

        dbCommand.Parameters.Add(new OleDbParameter("@psswrd", Password));

        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
    }

}