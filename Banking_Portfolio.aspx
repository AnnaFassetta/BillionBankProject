<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Banking_Portfolio.aspx.cs"  Inherits="BillionBankProject.Banking_Portfolio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            background-color: #FF99FF;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 605px">
            <h1><strong><em><span class="auto-style1">My Banking Portfolio</span></em></strong></h1>
            <asp:Label ID="LblClientname" runat="server"></asp:Label>
            <br />
            <asp:Label ID="LblDate" runat="server"></asp:Label>
            <br />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" BackColor="#FFCCFF" BorderColor="#666666" BorderStyle="Outset" Height="255px" Width="696px">
                <Columns>
        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:Button ID="btnView" runat="server" CausesValidation="false" CommandArgument='<%# Container.DataItemIndex %>'
                    CommandName="Select" Text="View" OnClick="btnView_Click"/>
            </ItemTemplate>
            <ControlStyle CssClass="btn btn-info" />
        </asp:TemplateField>
    </Columns>

            </asp:GridView>
            <br />
            <br />
            <asp:Label ID="LblIwantTo" runat="server" Text="I want to ..." Font-Size="Medium" style="font-weight: 700; font-size: medium"></asp:Label>
            <br />
            <br />
            <asp:HyperLink ID="HyperlinkTransfer" runat="server" NavigateUrl="~/Transfer.aspx">Transfer money</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperlinkCreate" runat="server" NavigateUrl="~/AccountCreation.aspx">Create account</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperlinkClose0" runat="server" NavigateUrl="~/Profile.aspx">Go to profile</asp:HyperLink>
            <br />
            <asp:Button ID="Button1" runat="server" BackColor="#FF99FF" PostBackUrl="~/Logout.aspx" Text="Logout" />
            <br />
            <br />
            <br />
            
            
            
            <br />
            
            
            
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
