<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountCreation.aspx.cs" Inherits="BillionBankProject.AccountCreation" %>

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
        <h1><strong><em><span class="auto-style1">Account Creation</span></em></strong></h1>
        <br />
        <br />
        <asp:Label ID="LblCreationMessage" runat="server"></asp:Label>
        <br />
        <asp:Label ID="LblAccountType" runat="server" Text="Account type:"></asp:Label>
&nbsp;<asp:DropDownList ID="DropDownListAccount" runat="server">
            <asp:ListItem>SAVINGS ACCOUNT</asp:ListItem>
            <asp:ListItem>CHEQUE ACCOUNT</asp:ListItem>
            <asp:ListItem>FLEX ACCOUNT</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="LblAccountName" runat="server" Text="Account Name:"></asp:Label>
&nbsp;<asp:TextBox ID="TextBoxAccountName" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="BrnCreate" runat="server" OnClick="BrnCreate_Click" Text="Create" />
        <br />
        <asp:Button ID="Button1" runat="server" BackColor="#FF99FF" PostBackUrl="~/Logout.aspx" Text="Logout" />
        <br />
        <asp:Button ID="Button2" runat="server" PostBackUrl="~/Banking_Portfolio.aspx" Text="Back" />
        <br />
    </form>
</body>
</html>
