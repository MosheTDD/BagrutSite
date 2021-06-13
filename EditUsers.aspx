<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditUsers.aspx.cs" Inherits="EditUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form name="mySubmit" method="post" action="">
        <h1>שינוי סיסמה</h1>
        <label for="username">שם משתמש</label>
        <br>
        <input type="text" id="uName" name="uName">
        <br>
        <label for="password">סיסמא עכשווית</label>
        <br>
        <input type="password" id="oldUPass" name="oldUPass">
        <br>
        <label for="newPassword">סיסמא חדשה</label>
        <br>
        <input type="password" id="newUPass" name="newUPass">
        <br><br>
        <input type="reset" value="נקה" />
        <input type="submit" name="submit" id="submit" value="שליחה" />
        <h3><%= Session["message"]%></h3>
    </form>
</asp:Content>

