<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProfilePage.aspx.cs" Inherits="ProfilePage" %>

<asp:Content class="control" ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1 class="control"> Account Details </h1>
    <br />
    <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red" Text=""/>
    <br /> 
    <table class="control" runat="server" style="width: 229px">
        <tr>
            <td> Username: </td>
            <td> <asp:Label ID="UsernameLabel" runat="server" Text="" /> </td>
        </tr>
        <tr>
            <td> First Name: </td>
            <td> <asp:Label ID="FirstNameLabel" runat="server" Text="" /> </td>
        </tr>
        <tr>
            <td> Last Name: </td>
            <td> <asp:Label ID="LastNameLabel" runat="server" Text="" /> </td>
        </tr>
        <tr>
            <td> Address: </td>
            <td> <asp:Label ID="AddressLabel" runat="server" Text="" /> </td>
        </tr>
        <tr>
            <td> Account Type:  </td>
            <td> <asp:Label ID="AccountTypeLabel" runat="server" Text="" /> </td>
        </tr>
    </table>

</asp:Content>

