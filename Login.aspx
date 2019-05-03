<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <table style="width: 328px; height: 117px" class="control">
        <tr>
             <td> User ID: </td>
             <td>  <asp:TextBox class="inputBox" ID="UserIDTextBox" runat="server" required ="true" BackColor="Silver" BorderStyle="None" /> </td>
        </tr>
        <tr>
             <td style="height: 24px"> Password: </td>
             <td style="height: 24px">  <asp:TextBox class="inputBox" ID="PasswordTextBox" runat="server" TextMode="Password" required = "true" BackColor="Silver" BorderStyle="None" /> </td>
        </tr>
        <tr>
            <td>
                 No account? <a href="Register.aspx">Register here!</a>
            </td>
        </tr>
        <tr>
            <td> <asp:Label ID="ErrorLabel" runat="server" Text=""/> </td>
        </tr>
        <tr>
            <td> <asp:Button class="button" ID="ConfirmButton" runat="server" Text="Confirm" Width="186px" OnClick="ConfirmButton_Click" BackColor="#FF9900" BorderStyle="None" ForeColor="White" /> </td>  
        </tr>      
    </table>

</asp:Content>

