<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminPage.aspx.cs" Inherits="AdminPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="control">
    <h1>Admin Control Panel</h1>

    <table>
        <tr>
            <td> <a href="Transactions.aspx">Transactions</a> </td> 
        </tr>
        <tr><td></td></tr>
        <tr>
            <td> <a href="ItemManager.aspx">Item Manager</a> </td>
        </tr>
        <tr><td></td></tr>
        <tr>
            <td> <a href="Reports.aspx">View Reports</a> </td>
        </tr>
        <tr><td></td></tr>
        <tr>
            <td><a href="AccountsManager.aspx">Accounts Manager</a></td>
        </tr>
        
    </table>
    <br /> <br />
</div>
</asp:Content>


