<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ItemManager.aspx.cs" Inherits="ItemManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="control">
    <a href="AddItem.aspx">Add Item</a>
    <br /> <br />
    <asp:GridView ID="ItemGridView" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="ItemGridView_SelectedIndexChanged"/>
    <br /> <br />
    <table>
        <tr>
            <td> Item ID: </td> <td> <asp:TextBox ID="ItemIDTextBox" runat="server" ReadOnly="True"/> </td>
            <td> <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Item ID is required!" ForeColor="Red" ControlToValidate="ItemIDTextBox" Display="Dynamic" /> </td>
        </tr>
        <tr>
            <td> Item Name: </td> <td> <asp:TextBox ID="ItemNameTextBox" runat="server" required="true" /> </td>
        </tr>
        <tr>
            <td> Price: </td> <td> <asp:TextBox ID="PriceTextBox" runat="server" required="true"/> </td>
            <td> <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red" ErrorMessage="Only non-negative numbers are allowed!" ControlToValidate="PriceTextBox" ValidationExpression="^[+]?\d+(\.\d+)?$"/> </td>
        </tr>
         <tr>
            <td> Promotional Sale Price: </td> 
            <td> <asp:TextBox ID="SalePriceTextBox" runat="server" required="true"/> </td>
            <td>Set to 0 if you do not want to put this item on discount!</td>
            <td> <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ForeColor="Red" ErrorMessage="Only non-negative numbers are allowed!" ControlToValidate="SalePriceTextBox" ValidationExpression="^[+]?\d+(\.\d+)?$"/> </td>
        </tr>
        <tr> 
            <td> Stock: </td> <td> <asp:TextBox ID="StockTextBox" runat="server" TextMode="Number" required="true" MaxLength="4"/> </td>
            <td><asp:RangeValidator ID="RangeValidator1" runat="server" ForeColor="Red" ErrorMessage="Numbers below 1 are not allowed." ControlToValidate="StockTextBox" Display="Dynamic" MaximumValue="999999" MinimumValue="0"></asp:RangeValidator>
        </tr>

        <tr>
            <td> Item Image:  </td> <td> <asp:FileUpload class="interactable" ID="ProductImageFileUpload" runat="server" accept=".png,.jpg,.jpeg" BackColor="darkgray" BorderStyle="None" ForeColor="black" Height="30px" Width="209px"  /> </td>
        </tr>

        <tr>
            <td> <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red" /> </td>
            <td> <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" /></td>
        </tr>
        <tr>
            <td> <asp:Button class="interactable" ID="UpdateButton" runat="server" Text="Update" OnClick="UpdateButton_Click" BorderStyle="None" ForeColor="White" Width="74px"  /> </td>
            <td> <asp:Button class="interactable" ID="DeleteButton" runat="server" Text="Delete" OnClick="DeleteButton_Click" BorderStyle="None" ForeColor="White" Width="73px"  /> </td>
        </tr>
    </table>
      
      
</div>
</asp:Content>

