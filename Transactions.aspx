<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Transactions.aspx.cs" Inherits="Transactions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView class="control" ID="TransactionGridView" runat="server" AllowPaging="True" AutoGenerateSelectButton="True" Font-Size="8pt" OnSelectedIndexChanged="TransactionGridView_SelectedIndexChanged" OnPageIndexChanging="TransactionGridView_PageIndexChanging" />
    <br /> <br />
    <table>
        <tr>
            <td> 
                <table>
                <tr>
                    <td> Transaction ID: </td>
                    <td> <asp:TextBox ID="TransactionIDTextBox" runat="server" required="true"/> </td>
                </tr>
                <tr>
                    <td> Buyer's Username: </td>
                    <td> <asp:TextBox ID="UsernameTextBox" runat="server" required="true"/> </td>
                </tr>
                <tr>
                    <td> Buyer's Full Name: </td>
                    <td> <asp:TextBox ID="FullNameTextBox" runat="server" required="true"/> </td>
                </tr>
                <tr>
                    <td> Date: </td>
                    <td> <asp:TextBox ID="DateTextBox" runat="server" required="true"/> </td>
                </tr>
                <tr>
                    <td> Time: </td>
                    <td> <asp:TextBox ID="TimeTextBox" runat="server" required="true"/>  </td>
                </tr>
                </table>
            </td>
            <td>
                <table>
                    <tr>
                        <td>Transaction Status: </td>
                        <td> <asp:DropDownList ID="TransactionStatusDropDownList" runat="server" OnSelectedIndexChanged="TransactionStatusDropDownList_SelectedIndexChanged">
                            <asp:ListItem>Pending</asp:ListItem>
                            <asp:ListItem>Delivering</asp:ListItem>
                            <asp:ListItem>Completed</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:CheckBox ID="EmailUserCheckBox" runat="server" Text="Email User?" />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Items Ordered: </td>
                    </tr>
                    <tr>
                        <td> <asp:Label ID="OrderedItemsLabel" runat="server" Text="No Ordered Items." ForeColor="White" /> </td>
                    </tr>
                </table>
                
            </td>
        </tr>
    </table>
    <br /><br />
    <asp:Label ID="ErrorLabel" runat="server" Text="" ForeColor="Red" />
    <br /><br />
    <asp:Button ID="ConfirmButton" runat="server" Text="Save Changes" OnClick="ConfirmButton_Click" />
</asp:Content>

