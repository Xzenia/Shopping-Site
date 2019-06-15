<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditProfile.aspx.cs" Inherits="ProfilePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3 class="control"> Edit Account Details </h3>
    <br />
    <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red" Text=""/>
    <br /> 
    <table class="control" runat="server" id="ContentTable">
        <tr>
            <td style="width: 198px"> New Username: </td>
            <td style="width: 124px">  <asp:TextBox class="inputBox" ID="UsernameTextBox" runat="server" required ="true" BackColor="Silver" BorderStyle="None"  Width="172px"/> </td>
        </tr>
        <tr>
            <td style="height: 17px; width: 198px;"> First Name: </td>
            <td style="height: 17px; width: 124px;">  <asp:TextBox class="inputBox" ID="FirstNameTextBox" runat="server" required ="true" BackColor="Silver" BorderStyle="None" Width="172px"/> </td>
        </tr>
        <tr>
            <td style="height: 17px; width: 198px;"> Last Name: </td>
            <td style="height: 17px; width: 124px;">  <asp:TextBox class="inputBox" ID="LastNameTextBox" runat="server" required ="true" BackColor="Silver" BorderStyle="None" Width="172px"/> </td>
        </tr>
         <tr>
            <td style="width: 198px"> Email: </td>
            <td style="width: 124px">  <asp:TextBox class="inputBox" ID="EmailTextBox" runat="server" required ="true" BackColor="Silver" BorderStyle="None" Width="172px"/> </td>
        </tr>
        <tr>
            <td style="width: 198px"> Address: </td>
            <td style="width: 124px">  <asp:TextBox class="inputBox" ID="AddressTextBox" runat="server" required ="true" BackColor="Silver" BorderStyle="None" TextMode="MultiLine"/> </td>
        </tr>
        <tr>
             <td>Password: </td>
             <td>  <asp:TextBox ID="PasswordTextBox" class="inputBox" runat="server" TextMode="Password" Width="124px"  BackColor="Silver"/> </td>
             <td> <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Passwords must have a minimum of 8 characters!" ForeColor ="Red" ControlToValidate="PasswordTextBox" Display="Dynamic" MaximumValue="256" MinimumValue="8" Type="Integer" /></td>
        </tr>
        <tr>
             <td>Confirm Password: </td>
             <td>  <asp:TextBox ID="ConfirmPasswordTextBox" class="inputBox" runat="server" TextMode="Password" Width="124px"  BackColor="Silver"/> </td>
            <td> <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Passwords are not similar!" ForeColor="Red" ControlToCompare="PasswordTextBox" ControlToValidate="ConfirmPasswordTextBox" Display="Dynamic"/> </td>
        </tr>
    </table>
    <br />
     <center><asp:Button class="interactable" ID="ConfirmButton" runat="server" Text="Confirm Changes" Width="186px" OnClick="ConfirmButton_Click" BorderStyle="None" ForeColor="White" Height="23px" /></center>

</asp:Content>

