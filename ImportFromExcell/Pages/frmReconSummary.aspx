<%@ Page Title="Recon Summary" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmReconSummary.aspx.cs" Inherits="ImportFromExcell.Pages.frmReconSummary" %>


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
            <asp:BoundField DataField="ReconId" HeaderText="Recon Id" ItemStyle-Width="70"/>
            <asp:BoundField DataField="CompanyId" HeaderText="Company Id" ItemStyle-Width="70" />
            <asp:BoundField DataField="ReconGenerationDate" HeaderText="Recon Generation Date" ItemStyle-Width="120" DataFormatString="{0:dd-MM-yyyy HH:mm}"/>
            <asp:BoundField DataField="ReconName" HeaderText="ReconName"  />
            
            <asp:BoundField DataField="HouseCount" HeaderText="House Count" ItemStyle-Width="60" ItemStyle-HorizontalAlign="Right"/>
            <asp:BoundField DataField="ForeignCount" HeaderText="Foreign Count" ItemStyle-Width="60" ItemStyle-HorizontalAlign="Right"/>
            <asp:BoundField DataField="HX" HeaderText="HX" ItemStyle-Width="60" ItemStyle-HorizontalAlign="Right"/>
            <asp:BoundField DataField="FX" HeaderText="FX" ItemStyle-Width="60" ItemStyle-HorizontalAlign="Right"/>
            <asp:BoundField DataField="UM" HeaderText="UM" ItemStyle-Width="60" ItemStyle-HorizontalAlign="Right"/>
        </Columns>
    </asp:GridView>
    </div>

    <div>
        <br />
        <asp:Button ID="btnExportGrid" runat="server" Text="Export To Excel" Font-Bold="true" onclick="btnExportGrid_Click" />
    </div>
</asp:Content>
