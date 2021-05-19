<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmB0106.aspx.cs" Inherits="ImportFromExcell.FormB0106" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Import Data B016 from MS Excell</title>
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
</head>
<body>
    <form id="frmB0106" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="AsOfDate" HeaderText="AsOfDate" ItemStyle-Width="50" DataFormatString="{0:dd-MM-yyyy}"/>
            <asp:BoundField DataField="AcctNo" HeaderText="Acct No" ItemStyle-Width="50" />
            <asp:BoundField DataField="AcctName" HeaderText="Acct Name" ItemStyle-Width="250" />
            <asp:BoundField DataField="InstrumentCd" HeaderText="InstrumentCd" ItemStyle-Width="40" />
            <asp:BoundField DataField="ISINCd" HeaderText="ISINCd" ItemStyle-Width="40" />
            <asp:BoundField DataField="InstrumentName" HeaderText="Instrument Name" ItemStyle-Width="300" />
            <asp:BoundField DataField="CpartyAcctNo" HeaderText="Cparty Acct No" ItemStyle-Width="40" />
            <asp:BoundField DataField="TotalQty" HeaderText="Total Qty" ItemStyle-Width="100" DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Right"/>
            <asp:BoundField DataField="SettledQty" HeaderText="Settled Qty" ItemStyle-Width="100" DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Right"/>
            <asp:BoundField DataField="UnsettledQty" HeaderText="Unsettled Qty" ItemStyle-Width="70" DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Right"/>
        </Columns>
    </asp:GridView>
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
    </form>
</body>
</html>