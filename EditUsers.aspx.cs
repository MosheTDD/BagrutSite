using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditUsers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["isUser"] = false;
        bool isUser = (bool)Session["isUser"];

        if (isUser)
        {
            Session["message"] = "";
            string tableName = "WebsiteUsers";
            string uName_m = Request.Form["uName"];
            string oldUPass_m = Request.Form["oldUPass"];
            string newUPass_m = Request.Form["newUPass"];

            if (Request.Form["submit"] != null)
            {
                string selectQuery = string.Format("SELECT * FROM {0} WHERE uName = '{1}' AND uPass='{2}'", tableName,
                    uName_m, oldUPass_m);
                string sql = string.Format("UPDATE {0} SET uPass='{1}' WHERE uName = '{2}' AND uPass = '{3}'",
                    tableName, newUPass_m, uName_m, oldUPass_m);
                if (MyAdoHelperAccess.IsExist(selectQuery))
                {
                    int rows = MyAdoHelperAccess.RowsAffected(sql);
                    Session["message"] = "הסיסמא שונתה בהצלחה";
                    Response.Redirect("Messages.aspx");
                }
                else
                {
                    Session["message"] = "שם המשתמש או הסיסמא אינם נכונים";
                    Response.Redirect("Messages.aspx");
                }
            }
        }
        else Response.Redirect("login.aspx");
    }
}