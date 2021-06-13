using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminActions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool isAdmin = (bool) Session["isAdmin"];
        if (!isAdmin)
        {
            Session["message"] = "אין לך הרשאה לגשת לדף זה";
            Response.Redirect("Messages.aspx");
            Response.End();
        }
    }
}