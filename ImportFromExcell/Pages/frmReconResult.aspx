<%@ Page Title="Recon Result" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmReconResult.aspx.cs" Inherits="ImportFromExcell.Pages.frmReconResult" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style type="text/css">
        body
        {
            font-family: Tahoma;
            font-size: 8pt;
        }
        table
        {
            border: 1px solid #ccc;
        }
        table th
        {
            background-color: #F7F7F7;
            color: #333;
            font-weight: bold;
        }
        table th, table td
        {
            padding: 5px;
            border-color: #ccc;
        }
    </style>

    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="1250">
        <Columns>
            <asp:BoundField DataField="ReconId" HeaderText="Recon Id" ItemStyle-Width="50"/>
            <asp:BoundField DataField="CompanyId" HeaderText="Company Id" ItemStyle-Width="50" />
            <asp:BoundField DataField="Data" HeaderText="Data"  />
            <asp:BoundField DataField="ReconDate" HeaderText="Recon Date" ItemStyle-Width="100" DataFormatString="{0:dd-MM-yyyy HH:mm}"/>
            <asp:BoundField DataField="ReconStatus" HeaderText="Recon Status" ItemStyle-Width="50" />
            <asp:BoundField DataField="Remarks" HeaderText="Remarks" ItemStyle-Width="60" />
            <asp:BoundField DataField="CreatedBy" HeaderText="CreatedBy" ItemStyle-Width="40" />
            <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" ItemStyle-Width="110" />
            <asp:BoundField DataField="StatusBy" HeaderText="StatusBy" ItemStyle-Width="50"/>
            <asp:BoundField DataField="DayOS" HeaderText="DayOS" ItemStyle-Width="50" ItemStyle-HorizontalAlign="Right"/>
        </Columns>
    </asp:GridView>
    </div>

    <div>
        <br />
        <asp:Button ID="btnExportGrid" runat="server" Text="Export To Excel" Font-Bold="true" onclick="btnExportGrid_Click" />
    </div>
</asp:Content>
