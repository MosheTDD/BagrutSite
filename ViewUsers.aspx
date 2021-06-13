<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewUsers.aspx.cs" Inherits="ViewUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <form action="" method="post">
        <h3>כל המשתמשים</h3>
        <input type="submit" name="viewAll" value="כל המשתמשים" />

        <h3>חיפוש לפי שם משתמש</h3>
        <input type="text" name="uName"/>
        <input type="submit" name="searchByUsername" value="   חפש   " />
        <br>
        <br>

        <h3>חיפוש לפי מגמה</h3>
        <h4>שנה</h4>
        <input type="text" name="birthYear"/>
        <input type="submit" name="searchByYear" value="   חפש   " />
        </form>
        <br />
        <br />
    <%=users%>
</asp:Content>

