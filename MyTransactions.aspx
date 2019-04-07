<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MyTransactions.aspx.cs" Inherits="MyTransactions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="TransactionGridView" runat="server"></asp:GridView>
    <br /> <br /> 
    <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red" Text=""/>
</asp:Content>

