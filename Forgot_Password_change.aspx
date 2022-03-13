<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forgot_Password_change.aspx.cs" Inherits="BillionBankProject.Forgot_Password_change" %>

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
            <h1><em><strong><span class="auto-style1">Change Password</span></strong></em></h1>
            <p>
                <asp:Label ID="LblQ" runat="server" Text="AnswerQuestion:"></asp:Label>
            </p>
            <p>
                Please provide answer:
                <asp:TextBox ID="TextBoxAnswer" runat="server"></asp:TextBox>
            </p>
            <p>
                New password:
                <asp:TextBox ID="TextBoxNewPass" runat="server" TextMode="Password"></asp:TextBox>
            </p>
            <p>
                Confirm password:
                <asp:TextBox ID="TextBoxConfirmPass" runat="server" TextMode="Password"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="LblMessage" runat="server" BorderColor="Red"></asp:Label>
            </p>
            <p>
                <asp:Button ID="BtnSave" runat="server" OnClick="BtnSave_Click" Text="Save" />
            </p>
        </div>
    </form>
</body>
</html>
