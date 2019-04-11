<%@Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Purchase.aspx.cs" Inherits="Purchase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:DataList ID="ItemList" runat="server" RepeatColumns ="3" CellSpacing ="3" RepeatLayout="Table">
        <ItemTemplate>
            <table>
                <tr>
                    <td>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("ProductImagePath")%>' Height="100px" Width="120px" />
                    </td>
                </tr>
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
                         <strong> Stock Available: <%# Eval("Stock") %> </strong>
                    </td>
                </tr>
                <tr>
                     <td> 
                         <asp:ImageButton ID="DetailsButton" runat="server" imageurl="~/images/detail.jpg"  PostBackUrl='<%#"Details.aspx?id="+Eval("ItemID")%>' />
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    
    <br />
        <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red" Text="" />
    <br />

    <table>
        <tr> 
            <td> &nbsp;</td>
        </tr>
    </table>
</asp:Content>