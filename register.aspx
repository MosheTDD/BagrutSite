<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>אמנים ישראלים - הרשמה</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<form name="myForm" method="post" action="">
    <table>
            <tr>
                <td  width="9%">שם משתמש</td>
                <td><input type="text" id="uName" name="uName" /></td>
            </tr>
            <tr>
                <td>סיסמא</td>
                <td><input type="password" id="uPass" name="uPass" /></td>
            </tr>
            <tr>
                <td>אימות סיסמא</td>
                <td><input type="password" id="confirmPass" name="confirmPass" /></td>
            </tr>
            <tr>
                <td>שנת לידה</td>
                <td><input type="text" id="year" name="year"></td>
            </tr>
            <tr>
                <td>אימייל</td>
                <td><input type="text" id="email" name="email" /></td>
            </tr>
            <tr>
                <td>מגמה</td>
                <td>
                    <input type="radio" id="megama" name="megama" value="מדעי מחשב" /> מדעי מחשב <br />
                    <input type="radio" id="megama" name="megama" value="קולנוע" /> קולנוע <br />
                    <input type="radio" id="megama" name="megama" value="פסיכולוגיה" /> פסיכולוגיה <br />
                </td> 
            </tr>
            <tr>
                <td>תחביבים</td>
                <td><input type="checkbox" id="hob" name="hob" value="gaming" /> לשחק במחשב  
                    <br />
                    <input type="checkbox" id="hob" name="hob" value="coding" /> לתכנת
                    <br />
                    <input type="checkbox" id="hob" name="hob" value="workout" /> להתאמן
                    <br />
                </td>
            
            
            </tr>
            <tr>
                <td>האמן האהוב עליך</td>
                <td>
                    <select id="favArtist" name= "favArtist">
                    <option id="favArtist" name= "favArtist" value= "אריק איינשטיין">אריק איינשטיין</option>
                    <option id="favArtist" name= "favArtist" value= "רביד פלוטניק">רביד פלוטניק</option>
                    <option id="favArtist" name= "favArtist" value= "טונה">טונה</option>
                    <option id="favArtist" name= "favArtist" value= "משינה">משינה</option>
                    <option id="favArtist" name= "favArtist" value= "עטר מיינר">עטר מיינר</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td></td>
                <td><input type="reset" value="נקה" />
                    <input type="submit" id="submit" name="submit" value="שלח" />
                </td>
            </tr>
        </table>
    </form>
</asp:Content>

