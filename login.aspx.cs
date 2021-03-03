using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    public string loginMsg = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["loggedIn"] = false;
        if (Request.Form["submit"] != null)
        {
            string uName_m = Request.Form["uName"];
            string uPass_m = Request.Form["uPass"];
            Session["loginMsg"] = "";
            if (uName_m == "moshe" &&  uPass_m == "12345" && (int)Session["count"] != 0)
            {
                Session["loggedIn"] = true;
                Session["uName"] = uName_m;
                Session["uPass"] = uPass_m;
                Response.Redirect("Gallery.aspx");
            }
            else
            {
                if ((int)Session["count"] != 0)
                {
                    Session["count"] = (int)Session["count"] - 1;
                    loginMsg = "טעית בשם משתמש או בסיסמא  נשארו לך " + Session["count"].ToString() + " נסיונות";
                }
                else
                {
                    Session["count"] = 0;
                    loginMsg = "נגמרו לך הנסיונות";
                }
        
            }
        }
    }
}