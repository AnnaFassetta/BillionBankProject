<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Transfer.aspx.cs" Inherits="BillionBankProject.Transfer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            background-color: #FFCCFF;
        }
        .auto-style2 {
            color: #FFFFFF;
            background-color: #FF3300;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1><strong><em><span class="auto-style1">Transfer Money</span></em></strong></h1>
        </div>
        <p>
            <em><strong><span class="auto-style2">Tranfers can only be done within one account type.</span></strong></em></p>
        <p>
            Select Accounts Below:</p>
        <p>
            Account Type: <asp:DropDownList ID="DropDownListAccountTypes" OnSelectedIndexChanged ="DropDownListAccountTypes_SelectedIndexChanged" AutoPostBack ="true" runat="server">
            <asp:ListItem>SAVINGS ACCOUNT</asp:ListItem>
            <asp:ListItem>CHEQUE ACCOUNT</asp:ListItem>
            <asp:ListItem>FLEX ACCOUNT</asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>
            From: <asp:DropDownList ID="DropDownListAccountFrom" runat="server">
            </asp:DropDownList>
&nbsp; To:
            <asp:DropDownList ID="DropDownListAccountTo" runat="server">
            </asp:DropDownList>
        </p>
        <p>
            Amount: <asp:TextBox ID="TextBoxAmount" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblDisplay" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Button ID="BtnSave" runat="server" OnClick="BtnSave_Click" Text="Save" />
        </p>
        <p>
            <asp:Button ID="Button2" runat="server" PostBackUrl="~/Banking_Portfolio.aspx" Text="Back" />
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" BackColor="#FF99FF" PostBackUrl="~/Logout.aspx" Text="Logout" />
        </p>
    </form>
</body>
</html>
