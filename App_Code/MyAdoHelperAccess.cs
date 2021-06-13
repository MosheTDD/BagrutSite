using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.OleDb;


/// <summary>
/// Summary description for MyAdoHelper
/// פעולות עזר לשימוש במסד נתונים מסוג אקסס
///  App_Data המסד ממוקם בתקיה 
/// </summary>

public class MyAdoHelperAccess
{
    public MyAdoHelperAccess()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static OleDbConnection ConnectToDb()
    {
        //string fileName = "xxx/mdf"; //שם הקובץ
        string fileName = "BagrutSiteUsersDB.mdb";   //שם הקובץ

        string path = HttpContext.Current.Server.MapPath("App_Data/");//מיקום מסד בפורוייקט
        path += fileName;
        //string path = HttpContext.Current.Server.MapPath("App_Data/" + fileName);//מאתר את מיקום מסד הנתונים מהשורש ועד התקייה בה ממוקם המסד
        string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + path;//נתוני ההתחברות הכוללים מיקום וסוג המסד
        OleDbConnection conn = new OleDbConnection(connString);
        return conn;
    }

    /// <summary>
    /// To Execute update / insert / delete queries
    ///  הפעולה מקבלת שם קובץ ומשפט לביצוע ומבצעת את הפעולה על המסד
    /// </summary>
    public static DataTable ExecuteDataTable(string sql)
    {
        OleDbConnection conn = ConnectToDb();
        conn.Open();

        OleDbDataAdapter tableAdapter = new OleDbDataAdapter(sql, conn);
        DataTable dt = new DataTable();
        tableAdapter.Fill(dt);
        return dt;
    }

    public static string PrintDataTable(string sql)
    {
        DataTable dt = ExecuteDataTable(sql);
        string bColor;
        string admin;
        bool color = false;
        string str = "";
        foreach (DataRow row in dt.Rows)
        {
            if (color)
            {
                bColor = " bColor='#7289da'";
            }
            else
            {
                bColor = " bColor='#2c2f33'";
            }
            if ((bool)row["IsAdmin"])
            {
                admin = "כן";
            }
            else
            {
                admin = "לא";
            }

            str += "<tr" + bColor + ">";
            str += "<td>" + row["uName"] + "</td>";
            str += "<td>" + row["uPass"] + "</td>";
            str += "<td>" + row["birthYear"] + "</td>";
            str += "<td>" + row["email"] + "</td>";
            str += "<td>" + row["hobbies"] + "</td>";
            str += "<td>" + row["megama"] + "</td>";
            str += "<td>" + row["favArtist"] + "</td>";
            str += "<td>" + admin + "</td>";
            str += "</tr>";
            color = !color;
        }
        return str;
    }


    public static void DoQuery(string sql)//הפעולה מקבלת שם מסד נתונים ומחרוזת מחיקה/ הוספה/ עדכון
    //ומבצעת את הפקודה על המסד הפיזי
    {
        OleDbConnection conn = ConnectToDb();
        conn.Open();  //פתיחת קישור
        OleDbCommand com = new OleDbCommand(sql, conn);
        com.ExecuteNonQuery();  //ביצוע פעולת עדכון שהוגדרה
        com.Dispose();      //שחרור משאבים
        conn.Close();       //סגירת קישור
    }

    /// <summary>
    /// To Execute update / insert / delete queries
    ///  הפעולה מקבלת שם קובץ ומשפט לביצוע ומחזירה את מספר השורות שהושפעו מביצוע הפעולה
    /// </summary>
    public static int RowsAffected(string sql)
    //הפעולה מקבלת מסלול מסד נתונים ופקודת עדכון
    //ומבצעת את הפקודה על המסד הפיזי
    {
        OleDbConnection conn = ConnectToDb();
        conn.Open();
        OleDbCommand com = new OleDbCommand(sql, conn);
        int rowsA = com.ExecuteNonQuery();
        conn.Close();
        return rowsA;
    }


    /// <summary>
    /// הפעולה מקבלת שם קובץ ומשפט לחיפוש ערך - מחזירה אמת אם הערך נמצא ושקר אחרת
    /// </summary>
    public static bool IsExist(string sql)
    //הפעולה מקבלת שם קובץ ומשפט בחירת נתון ומחזירה אמת אם הנתונים קיימים ושקר אחרת
    {
        //ConnectToDb - שיטת חיבור למאגר נתונים
        OleDbConnection conn = ConnectToDb();
        conn.Open();
        OleDbCommand com = new OleDbCommand(sql, conn);
        OleDbDataReader data = com.ExecuteReader(); //ביצוע אחזור
        bool found;
        // אם יש נתונים לקריאה יושם אמת אחרת שקר - הערך קיים במסד הנתונים
        found = (bool)data.Read();
        conn.Close();
        return found;
    }
   

    
    public void ExecuteNonQuery(string sql)
    {
        OleDbConnection conn = ConnectToDb();
        conn.Open();
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        cmd.ExecuteNonQuery();
        conn.Close();
    }

   
    public static DataTable GetFullTable(string tbl)
    {

        return GetTable("select * from " + tbl);
    }

    public static DataTable GetTable(string sqlStr)
    {
        OleDbConnection con = MyAdoHelperAccess.ConnectToDb();
        OleDbCommand cmd = new OleDbCommand(sqlStr, con);

        DataTable dt = new DataTable();
        OleDbDataAdapter adp = new OleDbDataAdapter();
        adp.SelectCommand = cmd;

        adp.Fill(dt);
        return dt;
    }


   

}
