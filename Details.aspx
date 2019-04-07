<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Details.aspx.cs" Inherits="Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td>
                <h2> <asp:Label id ="ProductNameLabel" runat="server" Text="Product Name" /> </h2>
            </td>
        </tr>
        <tr>
            <td> </td>
        </tr>
        <tr>
            <td>
                <asp:Label id ="ProductPriceLabel" runat="server" Text="Product Price" />
            </td>
        </tr>
        <tr>
            <td> </td>
        </tr>
        <tr>
            <td>
                <asp:Label id ="ProductStockLabel" runat="server" Text="Product Stock" />
            </td>
        </tr>
        <tr>
            <td>
                Quantity: <asp:TextBox ID="QuantityTextBox" runat="server" required="true"  TextMode="Number" Text="0" />
            </td>
        </tr>
    </table>
    <br /> 
    <asp:ImageButton ID="AddToCartButton" runat="server" ImageUrl="~/images/AddToCart.png" OnClick="AddToCartButton_Click" />
</asp:Content>

