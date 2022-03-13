<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forgot_Password.aspx.cs" Inherits="BillionBankProject.Forgot_Password" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-weight: normal;
        }
        .auto-style2 {
            background-color: #FFCCFF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 class="auto-style1"><em><span class="auto-style2">Confirm user</span></em></h1>
        </div>
        <p>
            Email Address:
            <asp:TextBox ID="TextBoxemail" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Confirm" />
    </form>
</body>
</html>
