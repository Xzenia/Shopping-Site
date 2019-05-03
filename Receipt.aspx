<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Receipt.aspx.cs" Inherits="Receipt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Table ID="OrderTable" runat="server" class="control">
        <asp:TableRow>
            <asp:TableCell> Item Name</asp:TableCell>
            <asp:TableCell> Price </asp:TableCell>
            <asp:TableCell> Quantity </asp:TableCell>
            <asp:TableCell> Total </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:Label ID="TotalCostLabel" runat="server" />


</asp:Content>

