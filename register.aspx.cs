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
            string uName = Request.Form["uName"];
            string uPass = Request.Form["uPass"];
            int year = int.Parse(Request.Form["year"]);
            string email = Request.Form["email"];
            string megama = Request.Form["megama"];
            string hob = Request.Form["hob"];
            string favArtist = Request.Form["favArtist"];

            string tableName = "WebsiteUsers"; //שם הטבלה
                                               //SQL הכנת משפט
                                               //DB להכנסת הנתונים ל

            string selectQuery = string.Format("SELECT email FROM {0} WHERE email = '{1}'", tableName, email);
            bool exists = MyAdoHelperAccess.IsExist(selectQuery);

            if (MyAdoHelperAccess.IsExist(selectQuery))
            {
                Session["regStatus"] = "המייל קיים במערכת";
                Response.Redirect("SignUpMessage.aspx");
            }
            else
            {
                string sql = string.Format("INSERT INTO {0} (uName, birthYear, uPass, email, hobbies, megama, favArtist) VALUES ('{1}', {2}, '{3}', '{4}', '{5}', '{6}', '{7}')"
                    , tableName, uName, year, uPass, email, hob, megama, favArtist);
                MyAdoHelperAccess.DoQuery(sql);
                Session["regStatus"] = "ההרשמה בוצע";
                Response.Redirect("SignUpMessage.aspx");
            }
            Response.End();
        }
    }
}