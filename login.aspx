<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>אמנים ישראלים - כניסה</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form name="mySubmit" method="post" action="">
        <h3>כניסה</h3>
      <label for="username">שם משתמש</label>
      <br>
      <input type="text" id="uName" name="uName">
      <br>
      <label for="password">סיסמא</label>
      <br>
      <input type="password" id="uPass" name="uPass">
      <br><br>
        <input type="reset" value="נקה" />
      <input type="submit" name="submit" id="submit" value="כניסה" />
        <h3><%= Session["message"]%></h3>
    </form>
</asp:Content>

