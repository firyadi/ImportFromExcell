<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmProcess.aspx.cs" Inherits="ImportFromExcell.Pages.frmProcess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <asp:Button ID="btnProcess" runat="server" Text="Process" Font-Bold="true" onclick="btnProcess_Click" /><br />
        <asp:Label ID="lblMsg" runat="server"/>
    </div>
    
</asp:Content>
