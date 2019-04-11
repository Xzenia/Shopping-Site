﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <table>
        <tr>
            <td>First Name: </td>
            <td>  <asp:TextBox ID="FirstNameTextBox" runat="server" required ="true" /> </td>
        </tr>
        <tr>
             <td>Last Name: </td>
             <td>  <asp:TextBox ID="LastNameTextBox" runat="server" required ="true"/> </td>
        </tr>
        <tr>
             <td>Address: </td>
             <td>  <asp:TextBox ID="AddressTextBox" runat="server" required ="true" /> </td>
        </tr>
        <tr>
             <td>Password: </td>
             <td>  <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" required ="true"/> </td>
        </tr>
        <tr>
             <td>Confirm Password: </td>
             <td>  <asp:TextBox ID="ConfirmPasswordTextBox" runat="server" TextMode="Password" required ="true"/> </td>
            <td> <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Passwords are not similar!" ForeColor="Red" ControlToCompare="PasswordTextBox" ControlToValidate="ConfirmPasswordTextBox" Display="Dynamic"/> </td>
        </tr>
        
        <tr>
            <td></td>
        </tr>
        <tr>
            <td> Already have an account? <a href ="Login.aspx"> Log in!</a></td>
        </tr>
        <tr>
            <td> <asp:Label ID="ErrorLabel" runat="server" Text=""/> </td>
        </tr>
        <tr>
            <td> <asp:Button ID="ConfirmButton" runat="server" Text="Confirm" Width="101px" OnClick="ConfirmButton_Click" /> </td>  
        </tr>
    </table>
</asp:Content>
