<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <asp:DataList ID="ItemList" runat="server" RepeatColumns ="1" CellSpacing ="3" RepeatLayout="Table" class="control" Width="774px">
        <ItemTemplate>
            <table>
                <tr>
                    <td>
                        <asp:Image ID="ProductImage" runat="server" ImageUrl='<%# Eval("ProductImagePath") %>' Height="150px" Width="100px"/>
                    </td>
                    <td>
                          <table>
                                <tr>
                                    <td> 
                                         <strong> <%# Eval("Name") %> </strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td> 
                                         <strong> Price: <%# Eval("PricePerItem") %> </strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td> 
                                         <strong> Quantity: x <%# Eval("Quantity") %> </strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <strong>Total Price: <%# Convert.ToInt32(Eval("Quantity")) * Convert.ToDouble(Eval("PricePerItem")) %> </strong>
                                    </td>
                                </tr>
                                
                          </table>
                    </td>
                    <td>
                        <asp:ImageButton ID="Image1" runat="server" Imageurl="~/images/x-button.png" Height="24px" Width="24px" PostBackUrl='<%#"~/Cart.aspx?RemoveItem="+Eval("Id")%>'/>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    <br />
      <center> <asp:Label ID="ErrorLabel" runat="server" Text="" ForeColor="Red" /> </center>
    <br /> <br /> 
    <center> <asp:Button class="interactable" ID="OrderItemsButton" runat="server" Text="Order Items" Height="32px" Width="220px" OnClick="OrderItemsButton_Click" BorderStyle="None" ForeColor="White" /> </center>

</asp:Content>

