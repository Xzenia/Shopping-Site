<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Details.aspx.cs" Inherits="Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="control">
        <tr>
            <td>
                <asp:Image ID="ProductImage" runat="server" Height ="200" Width="300"/>
            </td>
            <td></td>

            <td>
                 <table>
                         <tr>
                            <td>
                                <h1> <asp:Label id ="ProductNameLabel" runat="server" Text="Product Name" /> </h1>
                            </td>
                        </tr>
                        <tr>
                            <td> </td>
                        </tr>
                        <tr>
                            <td>
                                <h2> <asp:Label id ="ProductPriceLabel" runat="server" Text="Product Price" /> </h2>
                            </td>
                        </tr>
                        <tr>
                            <td> </td>
                        </tr>
                        <tr><td></td></tr>
                        <tr>
                            <td> <asp:Label id ="QuantityLabel" runat="server" Text="Quantity: " Font-Size="10pt" /> </td> 
                            <td> <asp:TextBox ID="QuantityTextBox" runat="server" required="true"  TextMode="Number" Text="1" MaxLength="2" /> </td>
                        </tr>
                    </table>
            </td>
        </tr>
    </table>
    <br />
    <asp:Label id ="ProductDescriptionLabel" runat="server" Text="Product Description:<br/> " Font-Size="12pt" />
    <br />
    <center>
    <asp:Label ID="ErrorLabel" runat="server" Text="" ForeColor="White" />
    <br /><br />
    <asp:ImageButton ID="AddToCartButton" runat="server" ImageUrl="~/images/AddToCart.png" OnClick="AddToCartButton_Click" />
    </center>
</asp:Content>

