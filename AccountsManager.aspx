<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AccountsManager.aspx.cs" Inherits="AccountsManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h3>Note</h3>
    <p>
        Account Type is represented as numbers: <br />
        1 - Admin <br />
        2 - Member
    </p>
    <br />
    <asp:GridView ID="AccountGridView" runat="server" AutoGenerateSelectButton="True" AutoGenerateColumns="False" OnSelectedIndexChanged="AccountGridView_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="AccountID" HeaderText="Account ID" ReadOnly="True" />
            <asp:BoundField DataField="Username" HeaderText="Username" />
            <asp:BoundField DataField="FirstName" HeaderText="First Name" />
            <asp:BoundField DataField="LastName" HeaderText="Last Name" />
            <asp:BoundField DataField="AccountAddress" HeaderText="Address" />
            <asp:BoundField DataField="EmailAddress" HeaderText="Email" />
            <asp:BoundField DataField="IsEmailConfirmed" HeaderText="Is Email Confirmed?" />
            <asp:BoundField DataField="AccountType" HeaderText="Account Type" />
        </Columns>
    </asp:GridView>

    <br /> <br />

    <table>
        <tr>
            <td> 
                 <table>
                        <tr>
                            <td>Account ID: </td>
                            <td> <asp:TextBox ID="AccountIDTextBox" runat="server" required="true" ReadOnly="True" /> </td>
                        </tr>
                        <tr>
                            <td>Username: </td>
                            <td> <asp:TextBox ID="UsernameTextBox" runat="server" required="true" ReadOnly="True"/> </td>
                        </tr>
                        <tr>
                            <td>First Name: </td>
                            <td> <asp:TextBox ID="FirstNameTextBox" runat="server" required="true" ReadOnly="True"/> </td>
                        </tr>
                        <tr>
                            <td>Last Name: </td>
                            <td> <asp:TextBox ID="LastNameTextBox" runat="server" required="true" ReadOnly="True"/> </td>
                        </tr>
                        <tr>
                            <td>Address: </td>
                            <td> <asp:TextBox ID="AddressTextBox" runat="server" required="true" ReadOnly="True"/> </td>
                        </tr>
                </table>
            </td>
            <td>
                <table>
                    <tr>
                        <td>Email: </td>
                        <td> <asp:TextBox ID="EmailTextBox" runat="server" required="true" ReadOnly="True"/> </td>
                    </tr>
                    <tr>
                        <td>Account Type: </td>
                        <td> <asp:DropDownList ID="AccountTypeDropDownList" runat="server" Height="16px" Width="129px" >
                            <asp:ListItem Value="1">Admin</asp:ListItem>
                            <asp:ListItem Value="2">Member</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
       
</asp:Content>

