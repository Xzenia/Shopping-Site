<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Reports.aspx.cs" Inherits="Reports" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">    
    <asp:ScriptManager ID="ScriptManager1" runat="server"/>
    <rsweb:ReportViewer ID="TransactionReportViewer" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="779px" Height="421px" BackColor="#F8F8F8" EnableTheming="False" ExportContentDisposition="AlwaysAttachment" ViewStateMode="Enabled">
        <localreport reportpath="Reports\AllTransactions.rdlc">
            <datasources>
                <rsweb:ReportDataSource DataSourceId="AllTransactions" Name="AllTransactions" />
            </datasources>
        </localreport>
    </rsweb:ReportViewer>

    <asp:SqlDataSource ID="AllTransactions" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Transactions]"></asp:SqlDataSource>

</asp:Content>

