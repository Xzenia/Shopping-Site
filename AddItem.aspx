<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddItem.aspx.cs" Inherits="AddItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="control">
    <h2> Add New Item</h2>
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
                            <td>Item Description: </td>
                            <td> <asp:TextBox ID="DescriptionTextBox" runat="server" required="true" Height="61px" Rows="3" Width="199px" TextMode="MultiLine"/> </td>
                        </tr>
                        <tr>
                            <td> Item Image(s):  </td> <td> <asp:FileUpload ID="ProductImageFileUpload" runat="server" accept=".png,.jpg,.jpeg" BackColor="darkgray" BorderStyle="None" ForeColor="black"  /> </td>
                        </tr>
                        <tr>
                            <td> <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red" /> </td>
            
                        </tr>
                        <tr>
                            <td> <asp:Button ID="AddButton" runat="server" Text="Add Item" OnClick="AddButton_Click" BackColor="#FF9933" BorderStyle="None" ForeColor="White"  /> </td>
                        </tr>
                    </table>
    </div>
</asp:Content>

