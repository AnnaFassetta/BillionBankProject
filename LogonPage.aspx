<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogonPage.aspx.cs" EnableEventValidation="false" Inherits="BillionBankProject.LogonPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            background-color: #FF99FF;
        }
        .auto-style2 {
            width: 594px;
            height: 401px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <h1 style="height: 34px; width: 599px"><strong><em><span class="auto-style1">Welcome to Billion Bank!&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="BtnRegister" runat="server" OnClick="BtnRegister_Click" Text="Register" />
            </span></em></strong></h1>
        <p>
            <asp:Label ID="LnlUserName" runat="server" Text="User Name:"></asp:Label>
&nbsp;
            <asp:TextBox ID="TextBoxName" runat="server" Height="18px" Width="87px"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="LblPassword" runat="server" Text="Password:"></asp:Label>
            <asp:TextBox ID="TextBoxPassword" runat="server" Height="18px" TextMode="Password" Width="87px"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="LblWrongPassword" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Button ID="BtnLogin" runat="server" Text="Login" OnClick="BtnLogin_Click" />
            <asp:Button ID="BtnForgotPassword" runat="server" Text="Forgot Password" OnClick="BtnForgotPassword_Click" PostBackUrl="~/Forgot_Password.aspx" />
        </p>
        <p>
            <img class="auto-style2" src="ImagesIMG/bank.jpg" /></p>
        <p style="height: 340px; width: 492px">
            &nbsp;</p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
