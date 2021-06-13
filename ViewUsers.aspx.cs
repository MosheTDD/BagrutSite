using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewUsers : System.Web.UI.Page
{
    public string users = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((bool)Session["isAdmin"])
        {
            string tableName = "WebsiteUsers";
            string selectQuery = "";
            string str = "";

            if (Request.Form["viewAll"] != null)
            {
                selectQuery = string.Format("SELECT * From {0}", tableName);
            }
            else
            {
                if (Request.Form["searchByUsername"] != null)
                {
                    selectQuery = string.Format("SELECT * From {0} WHERE uName='{1}'", tableName, Request.Form["uName"]);
                }
                else
                {
                    if (Request.Form["searchByYear"] != null)
                    {
                        selectQuery = string.Format("SELECT * From {0} WHERE birthYear={1}", tableName, Request.Form["birthYear"]);
                    }
                }
            }

            if (selectQuery != "")
            {
                str = MyAdoHelperAccess.PrintDataTable(selectQuery).ToString();
                if (str != "")
                {
                    users += "<table width='100%' border='0' cellspacing='2' cellpadding='1' align='center' style='text-align:center; background:#99aab5;'>";
                    users += "<tr>";
                    users += "<th>שם משתמש</th>";
                    users += "<th>סיסמא</th>";
                    users += "<th>שנת לידה</th>";
                    users += "<th>אימייל</th>";
                    users += "<th>תחביבים</th>";
                    users += "<th>מגמה</th>";
                    users += "<th>אומן אהוב</th>";
                    users += "<th>מנהל</th>";
                    users += str;
                    users += "</table>";
                }
                else
                {
                    users = "אין משתמשים";
                }
            }
        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }
}