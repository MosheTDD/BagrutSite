using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DeleteUserByEmail : System.Web.UI.Page
{
    public string userMsg = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        bool isAdmin = (bool)Session["isAdmin"];
        if (isAdmin)
        {
            string tableName = "WebsiteUsers";
            string selectQuery = "";

            if (Request.Form["del_email"] != null)
            {
                string uEmail_m = Request.Form["uEmail"];
                selectQuery = string.Format("SELECT * FROM {0} WHERE email = '{1}'", tableName, uEmail_m);

                if (MyAdoHelperAccess.IsExist(selectQuery))
                {
                    string sql = string.Format("DELETE FROM {0} WHERE email = '{1}'", tableName, uEmail_m);
                    userMsg = MyAdoHelperAccess.RowsAffected(sql).ToString() + " משתמש שנמחק - " + uEmail_m;
                }
                else
                {
                    userMsg = "המשתמש לא נמצא";
                }
            }
        }
        else Response.Redirect("login.aspx");
    }
}