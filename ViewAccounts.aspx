<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewAccounts.aspx.cs"  Inherits="BillionBankProject.ViewAccounts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            background-color: #FFCCFF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1><strong><em><span class="auto-style1">Transaction history</span></em></strong></h1>
            <br />
            <br />
            <br />
            <asp:Label ID="LblAccountType" runat="server" style="font-size: medium"></asp:Label>
&nbsp;<asp:Label ID="LblAccountName" runat="server" style="font-size: medium"></asp:Label>
&nbsp;<asp:Label ID="LblAccountBalance" runat="server" style="font-size: medium"></asp:Label>
&nbsp;<asp:Label ID="LblAccountNumber" runat="server" style="font-size: medium"></asp:Label>
&nbsp;<asp:Label ID="LblAccountDate" runat="server" style="font-size: medium"></asp:Label>
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" BackColor="#FFCCFF" BorderColor="#666666" BorderStyle="Outset" Height="255px" Width="696px">
             
            </asp:GridView>

            <br />
            <asp:Button ID="Button2" runat="server" PostBackUrl="~/Banking_Portfolio.aspx" Text="Back" />

            <br />

        </div>
    </form>
</body>
</html>
