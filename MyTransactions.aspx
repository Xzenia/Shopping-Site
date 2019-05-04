<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MyTransactions.aspx.cs" Inherits="MyTransactions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView class="control" ID="TransactionGridView" runat="server" AllowPaging="True" AutoGenerateColumns="False" BorderStyle="Solid" EnableSortingAndPagingCallbacks="True" Font-Overline="False" Font-Size="14pt">
        <Columns>
            <asp:BoundField DataField="Date" HeaderText="Date" ReadOnly="True" SortExpression="String" />
            <asp:BoundField DataField="Time" HeaderText="Time" ReadOnly="True" SortExpression="Time" />
            <asp:BoundField DataField="ItemName" HeaderText="Item Name" ReadOnly="True" SortExpression="ItemName" />
            <asp:BoundField DataField="PricePerItem" HeaderText="Price Per Item" ReadOnly="True" SortExpression="PricePerItem" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" ReadOnly="True" SortExpression="Quantity" />
            <asp:BoundField DataField="TotalItemPrice" HeaderText="Total" ReadOnly="True" SortExpression="TotalItemPrice" />
            <asp:BoundField DataField="TotalTransactionPrice" HeaderText="Overall Price" ReadOnly="True" SortExpression="TotalTransactionPrice" />
        </Columns>
        <RowStyle Wrap="False" />
    </asp:GridView>
    <br /> <br /> 
    
    <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red" Text=""/>
</asp:Content>

