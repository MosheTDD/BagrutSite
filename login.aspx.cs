using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Form["mySubmit"] != null)
        {
            if (Request.Form["uName"] == "moshe" && Request.Form["pass"] == "12345" && (int)Session["count"] != 0)
            {
                Session["ok"] = true;
                Response.Redirect("gallery.aspx");
            }
            else
            {
                if ((int)Session["count"] != 0)
                {
                    Session["count"] = (int)Session["count"] - 1;
                    string str = "טעית בשם משתמש או בסיסמא";
                    str = str + "</ br>";
                    str = str + " נשארו לך";
                    str = str + Session["count"].ToString();
                    str = str + "ניסיונות";
                    Session["message"] = str;
                    ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", Session["message"].ToString(), true);
                }
                else
                {
                    Session["count"] = 0;
                    Response.Write("נגמרו לך הנסיונות");
                }
        
            }
        }
    }    
}