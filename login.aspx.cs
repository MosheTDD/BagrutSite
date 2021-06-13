using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["isUser"] = false;
        Session["message"] = "";
        if (Request.Form["submit"] != null)
        {
            string uName_m = Request.Form["uName"];
            string uPass_m = Request.Form["uPass"];
            string tableName = "WebsiteUsers";

            string selectQuery = string.Format("SELECT uName, uPass, IsAdmin FROM {0} WHERE uName = '{1}' AND uPass = '{2}'", tableName, uName_m, uPass_m);
            DataTable dt = MyAdoHelperAccess.ExecuteDataTable(selectQuery);

            if (dt.Rows.Count > 0)
            {
                bool admin = (bool)dt.Rows[0]["IsAdmin"];
                Session["isUser"] = true;
                if (admin)
                {
                    Session["isAdmin"] = true;
                    Session["message"] = ("<h1> התחברת כמנהל </h1>");
                }
                else
                {
                    Session["isAdmin"] = false;
                    Session["message"] = ("<h1> התחברת כמשתמש </h1>");
                }
                Response.Redirect("Messages.aspx");
            }
            else
            {
                Session["message"] = ("<h3> שם המשתמש או הסיסמא אינם נכונים </h3>");
            }
        }
    }
}