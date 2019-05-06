<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConfirmEmail.aspx.cs" Inherits="ConfirmEmail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="MessageLabel" runat="server" ForeColor="White"> <h2>Confirmation Email Sent!</h2><p> A confirmation email has been sent to the email provided.<br /> <br />Please enter the five digit number sent in the email to confirm your email address. </p></asp:Label>
    <table>
        <tr>
            <td> <asp:Label ID="ConfirmationCodeLabel" runat="server" Text="Confirmation Code" ForeColor="White" /> </td>
            <td> </td>
            <td> <asp:TextBox ID="ConfirmationCodeTextBox" runat="server" Height="22px"/></td>
        </tr>
    </table>
    <br /> 
    <asp:Label ID="ErrorLabel" runat="server" Text="" ForeColor="White" />
    <br /><br />
    <asp:Button class="interactable" ID="ConfirmButton" runat="server" Text="Confirm" Height="28px" Width="122px" OnClick="ConfirmButton_Click" />

</asp:Content>

