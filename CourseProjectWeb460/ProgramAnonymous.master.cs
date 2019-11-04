using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProgramAnonymous : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Generate user GUID only on first time its loaded
        if (!Page.IsPostBack)
        {
            lblGUID.Text = System.Guid.NewGuid().ToString();
        }
    }

    //Allows Content Pages to change message being displayed
    public Label UserFeedBack
    {
        get { return lblUserFeedback; }
        set { lblUserFeedback = value; }
    }
}
