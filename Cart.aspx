<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <asp:DataList ID="ItemList" runat="server" RepeatColumns ="3" CellSpacing ="3" RepeatLayout="Table">
        <ItemTemplate>
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
                         <strong> Stock Available: <%# Eval("Quantity") %> </strong>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    <br />
      <center> <asp:Label ID="ErrorLabel" runat="server" Text="" ForeColor="Red" /> </center>
    <br /> <br /> 
    <center> <asp:Button ID="OrderItemsButton" runat="server" Text="Order Items" Height="32px" Width="220px" OnClick="OrderItemsButton_Click" /> </center>

</asp:Content>

