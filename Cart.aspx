<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <asp:DataList ID="ItemList" runat="server" RepeatColumns ="3" CellSpacing ="3" RepeatLayout="Table" class="control" Width="774px">
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
                         <strong> Quantity: x <%# Eval("Quantity") %> </strong>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    <br />
      <center> <asp:Label ID="ErrorLabel" runat="server" Text="" ForeColor="Red" /> </center>
    <br /> <br /> 
    <center> <asp:Button class="button" ID="OrderItemsButton" runat="server" Text="Order Items" Height="32px" Width="220px" OnClick="OrderItemsButton_Click" BackColor="#FF9933" BorderStyle="None" ForeColor="White" /> </center>

</asp:Content>

