<%@Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <h3><marquee ID="marquee" Runat="Server">Great Coffee Sale! Up to 50% on all coffee products until May 10, 2019! Buy now while stocks last!</marquee></h3>
    
    <center> <h1>  HOT DEALS! </h1> </center> 
    
    <marquee BEHAVIOR=ALTERNATE>

    <asp:DataList class="control" ID="DealsList" runat="server" RepeatColumns ="3" CellSpacing ="3" RepeatLayout="Table">
        <ItemTemplate>
            <table>
                <tr>
                    <td>
                        <asp:ImageButton ID="Image1" runat="server" ImageUrl='<%#Eval("ProductImagePath")%>' PostBackUrl='<%#"Details.aspx?id="+Eval("ItemID")%>' Height="100px" Width="120px" />
                    </td>
                </tr>
                <tr>
                    <td> 
                         <center> <strong> <%# Eval("Name") %> </strong> </center>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    
    </marquee>
    <br /> <br /> <br/>
    
       <asp:DataList class="control" ID="ItemList" runat="server" RepeatColumns ="3" CellSpacing ="30" RepeatLayout="Table">
            <ItemTemplate>
                <table>
                    <tr>
                        <td>
                            <asp:ImageButton ID="Image1" runat="server" ImageUrl='<%#Eval("ProductImagePath")%>' PostBackUrl='<%#"Details.aspx?id="+Eval("ItemID")%>' Height="100px" Width="120px" />
                        </td>
                    </tr>
                    <tr>
                        <td> 
                             <strong> <%# Eval("Name") %> </strong>
                        </td>
                    </tr>
                    <tr>
                        <td> 
                             <strong> &#8369;<%# Eval("PricePerItem") %> </strong>
                        </td>
                    </tr>
                    <tr>
                        <td> 
                             <strong> Stock Available: <%# Eval("Stock") %> </strong>
                        </td>
                    </tr>
                    <tr>
                         <td> 
                             <asp:ImageButton ID="DetailsButton" runat="server" imageurl="~/images/detail.jpg"  PostBackUrl='<%#"Details.aspx?id="+Eval("ItemID")%>' BackColor="#FF9933" BorderStyle="None" ForeColor="White"  />
                        </td>
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