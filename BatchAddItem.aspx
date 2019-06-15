<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BatchAddItem.aspx.cs" Inherits="BatchAddItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
          <h3>Input new items by batch</h3>
          <br />
          <p> You can now add multiple items for sale through MS Excel. Upload the Excel file containing the data for the new items to add them in the database. <br />Template can be downloaded here. </p>
          <br />
          <asp:FileUpload ID="ExcelFileUpload" runat="server" accept=".xls, .xlsx" BackColor="darkgray" BorderStyle="None" ForeColor="black"  />
          <br /> <br />
          <center><asp:Button ID="UploadButton" runat="server" Text="Upload File" BackColor="#FF9933" BorderStyle="None" ForeColor="White" OnClick="UploadButton_Click"  /></center>
</asp:Content>

