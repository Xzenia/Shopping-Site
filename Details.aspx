<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Details.aspx.cs" Inherits="Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td>
                <asp:Image ID="ProductImage" runat="server" Height ="200" Width="300"/>
            </td>
            <td></td>

            <td>
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
                                Quantity: <asp:TextBox ID="QuantityTextBox" runat="server" required="true"  TextMode="Number" Text="1" MaxLength="3" />
                                <td><asp:RangeValidator ID="RangeValidator1" runat="server" ForeColor="Red" ErrorMessage="Only numbers from 1-999 are allowed." ControlToValidate="QuantityTextBox" Display="Dynamic" MaximumValue="999" MinimumValue="1"></asp:RangeValidator>
                            </td>
                        </tr>
                    </table>
            </td>
        </tr>
    </table>
    
    <br /> 
    <asp:ImageButton ID="AddToCartButton" runat="server" ImageUrl="~/images/AddToCart.png" OnClick="AddToCartButton_Click" />
</asp:Content>

