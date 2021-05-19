<%@ Page Title="Import Data PCI from MS Excell" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmPci.aspx.cs" Inherits="ImportFromExcell.Pages.frmPci" %>


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
                <asp:BoundField DataField="EODDate" HeaderText="EOD Date" ItemStyle-Width="70" DataFormatString="{0:yyyy-MM-dd}"/>
                <asp:BoundField DataField="AccountNumber" HeaderText="Account Number" ItemStyle-Width="45" />
                <asp:BoundField DataField="CCY" HeaderText="CCY" ItemStyle-Width="30" />
                <asp:BoundField DataField="SDQty" HeaderText="SD Qty" ItemStyle-Width="80" ItemStyle-HorizontalAlign="Right"/>
                <asp:BoundField DataField="AcctTypeDesc" HeaderText="Acct Type Desc" ItemStyle-Width="40" />
                <asp:BoundField DataField="TDQty" HeaderText="TD Qty" ItemStyle-Width="90" ItemStyle-HorizontalAlign="Right"/>
                <asp:BoundField DataField="ClosingPrice" HeaderText="Closing Price" ItemStyle-Width="60" ItemStyle-HorizontalAlign="Right"/>
                <asp:BoundField DataField="SDMktValue" HeaderText="SD Mkt Value" ItemStyle-Width="40" ItemStyle-HorizontalAlign="Right"/>
                <asp:BoundField DataField="CUSIP" HeaderText="CUSIP" ItemStyle-Width="60" />
                <asp:BoundField DataField="SYMBOL" HeaderText="SYMBOL" ItemStyle-Width="30" />
                <asp:BoundField DataField="ISIN" HeaderText="ISIN" ItemStyle-Width="45" />
                <asp:BoundField DataField="StaleInd" HeaderText="Stale Ind" ItemStyle-Width="30" />
                <asp:BoundField DataField="ClosingPriceDate" HeaderText="Closing Price Date" ItemStyle-Width="70" DataFormatString="{0:yyyy-MM-dd}"/>
                <asp:BoundField DataField="TDMktValue" HeaderText="TD Mkt Value" ItemStyle-Width="35" ItemStyle-HorizontalAlign="Right" />
                <asp:BoundField DataField="ListedMarket" HeaderText="Listed Market" ItemStyle-Width="30" />
                <asp:BoundField DataField="SecurityType" HeaderText="Security Type" ItemStyle-Width="70" />
                <asp:BoundField DataField="SecurityDescription" HeaderText="Security Description" ItemStyle-Width="200" />
            </Columns>
        </asp:GridView>
    </div>

     <br />
    <asp:Label ID="lblNote" runat="server" Text="Note: Convert your Excel date format to 'yyyy-MM-dd' "/>
    <br />
    <asp:TextBox ID="txtCopied" runat="server" TextMode="MultiLine" AutoPostBack="true"
        OnTextChanged="PasteToGridView" Height="150" Width="1250" />
        <br />
    <asp:Button ID="btnInsert" runat="server" Text="Save" Font-Bold="true" onclick="btnInsert_Click" /><br />
    <asp:Label ID="lblMsg" runat="server"/>

    <script type="text/javascript">
        window.onload = function () {
            document.getElementById("<%=txtCopied.ClientID %>").onpaste = function () {
                var txt = this;
                setTimeout(function () {
                    __doPostBack(txt.name, '');
                }, 100);
            }
        };
    </script>

</asp:Content>


