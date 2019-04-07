<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddItemPage.aspx.cs" Inherits="AddItemPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2> Add new item </h2>
    <a href="AdminPage.aspx">Back to Admin Page</a>
    <br /> <br />
    <table>
        <tr>
            <td> Item Name: </td> <td> <asp:TextBox ID="ItemNameTextBox" runat="server" required="true" /> </td>
        </tr>
        <tr>
            <td> Price: </td> <td> <asp:TextBox ID="PriceTextBox" runat="server" required="true"/> </td>
            <td> <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red" ErrorMessage="Only non-negative numbers are allowed!" ControlToValidate="PriceTextBox" ValidationExpression="^[+]?\d+(\.\d+)?$"/> </td>
        </tr>
        <tr> 
            <td> Stock: </td> <td> <asp:TextBox ID="StockTextBox" runat="server" required="true"/> </td>
        </tr>
        <tr>
            <td> <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red" /> </td>
            
        </tr>
        <tr>
            <td> <asp:Button ID="AddButton" runat="server" Text="Add Item" OnClick="AddButton_Click"  /> </td>
        </tr>
    </table>
</asp:Content>

