using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Form["submit"] != null)
        {
            string uName_m = Request.Form["uName"];
            string uPass_m = Request.Form["uPass"];
            int year_m = int.Parse(Request.Form["year"]);
            string email_m = Request.Form["email"];
            string megama_m = Request.Form["megama"];
            string hobbie_m = Request.Form["hobbies"];
            string favArtist_m = Request.Form["favArtist"];

            string tableName = "WebsiteUsers"; //שם הטבלה
                                               //SQL הכנת משפט
                                               //DB להכנסת הנתונים ל

            string selectQuery = string.Format("SELECT email FROM {0} WHERE email = '{1}'", tableName, email_m);

            if (MyAdoHelperAccess.IsExist(selectQuery))
            {
                Session["message"] = "המייל קיים במערכת";
                Response.Redirect("Messages.aspx");
            }
            else
            {
                string sql = string.Format("INSERT INTO {0} (uName, birthYear, uPass, email, hobbies, megama, favArtist) VALUES ('{1}', {2}, '{3}', '{4}', '{5}', '{6}', '{7}')"
                    , tableName, uName_m, year_m, uPass_m, email_m, hobbie_m, megama_m, favArtist_m);
                MyAdoHelperAccess.DoQuery(sql);
                Session["message"] = "ההרשמה בוצע";
                Response.Redirect("Messages.aspx");
            }
            Response.End();
        }
    }
}