<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="BillionBankProject.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    </head>
<body>
    <form id="form1" runat="server">
        <h1 style="height: 34px; width: 599px; background-color: #FF99FF">Profile</h1>
        <br />
        <br />
        <asp:Label ID="LabelError" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="LblFirstName" runat="server" Text="First Name:"></asp:Label>
&nbsp;<asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:RequiredFieldValidator ID="ValidateFName" runat="server" ControlToValidate ="TextBoxName" ErrorMessage="No Blanks"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="LblSurname" runat="server" Text="Surname:"></asp:Label>
&nbsp;<asp:TextBox ID="TextBoxSurname" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ValidateSName" runat="server" ControlToValidate ="TextBoxSurname" ErrorMessage="No Blanks"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="LblID" runat="server" Text="ID Number:"></asp:Label>
&nbsp;<asp:TextBox ID="TextBoxID" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ValidateID" runat="server" ControlToValidate ="TextBoxID" ErrorMessage="No Blanks"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="LblEmail" runat="server" Text="Email:"></asp:Label>
&nbsp;<asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="ValidateEmail" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="TextBoxEmail" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
        <br />
        <br />
        <asp:Label ID="LblAddress" runat="server" Text="Home Address:"></asp:Label>
&nbsp;<asp:TextBox ID="TextBoxAddress" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ValidateAddress" runat="server" ControlToValidate ="TextBoxAddress" ErrorMessage="No Blanks"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="LblContact" runat="server" Text="Contact Number:"></asp:Label>
&nbsp;<asp:TextBox ID="TextBoxContact" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ValidateContact" runat="server" ControlToValidate ="TextBoxContact" ErrorMessage="No Blanks"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="Lblpassword" runat="server" Text="Password:"></asp:Label>
&nbsp;<asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ValidatePassword" runat="server" ControlToValidate ="TextBoxPassword" ErrorMessage="No Blanks"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="LblconfirmPassword" runat="server" Text="Confirm Password:"></asp:Label>
&nbsp;<asp:TextBox ID="TextBoxConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ValidateConfirmPassword" runat="server" ControlToValidate ="TextBoxConfirmPassword" ErrorMessage="No Blanks"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="LblQuestion" runat="server" ClientIDMode="AutoID" Text="Password Question?"></asp:Label>
&nbsp;<asp:TextBox ID="TextBoxPasswordQuestion" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ValidatePasswordQuestion" runat="server" ControlToValidate ="TextBoxPasswordQuestion" ErrorMessage="No Blanks"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="LblQuestion0" runat="server" ClientIDMode="AutoID" Text="Password Question Answer:"></asp:Label>
&nbsp;<asp:TextBox ID="TextBoxPasswordQuestionAnswer" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ValidatePasswordQuestionAnswer" runat="server" ControlToValidate ="TextBoxPasswordQuestionAnswer" ErrorMessage="No Blanks"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Button ID="BtnSave" runat="server" Text="Save" OnClick="BtnSave_Click" />
        <br />
        <asp:Button ID="Button2" runat="server" PostBackUrl="~/Banking_Portfolio.aspx" Text="Back" />
    </form>
</body>
</html>
