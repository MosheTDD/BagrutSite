<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="gallery.aspx.cs" Inherits="gallery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>אמנים ישראלים - גלרייה</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form name="gallery" method="post" action="">
        <table>
            <tr>
                <td>
                    <asp:Image  ImageUrl="https://i.scdn.co/image/5c4c6603c837fea08c844a3eb8f9b19cdd21655b" runat="server" />
                    <asp:Image ImageUrl="https://i1.wp.com/www.lightbaz.com/wp-content/uploads/2017/04/by-tamuz-rachman.jpg?resize=680%2C382" runat="server" />
                    <asp:Image ImageUrl="https://images.genius.com/feb8712d9413cc38d45485480d909839.640x640x1.jpg" runat="server" />
                </td>
            </tr>
        </table>
    </form>
</asp:Content>

