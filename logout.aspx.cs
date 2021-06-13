using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(bool)Session["isUser"] && !(bool)Session["isAdmin"])
        {
            Session["message"] = "אינך מחובר";
        }
        else
        {
            Session["isUser"] = false;
            Session["isAdmin"] = false;
            Session["message"] = "יציאה מהחשבון בוצעה בהצלחה";
        }
        Response.Redirect("Messages.aspx");
    }
}