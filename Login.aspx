<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <table>
        <tr>
             <td> User ID: </td>
             <td>  <asp:TextBox ID="UserIDTextBox" runat="server" required ="true" /> </td>
        </tr>
        <tr>
             <td> Password: </td>
             <td>  <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" required = "true" /> </td>
        </tr>
        <tr>
            <td> <asp:Label ID="ErrorLabel" runat="server" Text=""/> </td>
        </tr>
        <tr>
            <td> <asp:Button ID="ConfirmButton" runat="server" Text="Confirm" Width="101px" OnClick="ConfirmButton_Click" /> </td>  
        </tr>      
    </table>
</asp:Content>

