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
                        <tr>
                            <td>
                                <asp:Label id ="ProductStockLabel" runat="server" Text="Stock Available: " />
                            </td>
                        </tr>
                        <tr>
                            <td> <asp:Label id ="QuantityLabel" runat="server" Text="Quantity: " /> </td> 
                            <td> <asp:TextBox ID="QuantityTextBox" runat="server" required="true"  TextMode="Number" Text="1" MaxLength="3" /> </td>
                            <td> <asp:RangeValidator ID="RangeValidator" runat="server" ForeColor="Red" ErrorMessage="Only numbers from 1-999 are allowed." ControlToValidate="QuantityTextBox" Display="Dynamic" Type="Integer" MinimumValue="1" MaximumValue="999"  /> </td>
                        </tr>
                     <tr>
                         <td> </td>
                     </tr>
                     
                     <tr>
                         <td> </td>
                     </tr>
                     <tr>
                         <td> <asp:Label id ="ProductDescriptionLabel" runat="server" Text="Quantity: " /> </td>
                     </tr>

                    </table>
            </td>
        </tr>
    </table>
    <br /> 
    <center>
    <asp:Label ID="ErrorLabel" runat="server" Text="" ForeColor="White" />
    <br /><br />
    <asp:ImageButton ID="AddToCartButton" runat="server" ImageUrl="~/images/AddToCart.png" OnClick="AddToCartButton_Click" />
    </center>
</asp:Content>

