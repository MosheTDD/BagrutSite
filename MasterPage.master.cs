using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Application["visitCount"] != null)
        {
            if ((bool)Session["firstVisit"])
            {
                Session["firstVisit"] = false;
                Application["visitCount"] = (int)Application["visitCount"] + 1;
            }
        }
        else
        {
            Application["visitCount"] = 1;
        }
    }
}
