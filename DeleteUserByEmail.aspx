<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DeleteUserByEmail.aspx.cs" Inherits="DeleteUserByEmail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>מחיקה לפי אימייל</h1>
    <form action="" method="post">
        <h3>הכנס את האימייל של המשתמש שתרצה להסיר</h3>
        <input type="text" name="uEmail" id="uEmail" value="" />
        <input type="submit" name="del_email" id="del_email" value="שלח" />
    </form>
    <h3><%= userMsg %></h3>
</asp:Content>

