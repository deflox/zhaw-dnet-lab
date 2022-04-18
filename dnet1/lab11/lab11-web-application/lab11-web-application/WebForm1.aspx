<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="lab11_web_application.WebForm1" %>
<%@ Register TagPrefix="my" TagName="Weight" Src="Weight.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <my:Weight ID="weightElement" Runat="server" />
            </tr>
            <tr>
                <td><asp:Label ID="heightLabel" runat="server" Text="Grösse (m):"></asp:Label></td>
                <td><asp:TextBox ID="height" runat="server"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="heightRequiredValidator" runat="server" ControlToValidate="height" ErrorMessage="Grösse muss ausgefüllt sein!" style="z-index: 1; left: 300px; top: 53px; position: absolute"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rangeRequiredValidator" runat="server" ControlToValidate="height" MinimumValue="1.0" MaximumValue="2.8" ErrorMessage="Grösse muss zwischen 1.0 und 2.8 liegen!" style="z-index: 1; left: 302px; top: 53px; position: absolute; bottom: 257px"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="Label3" runat="server" Text="BMI:"></asp:Label></td>
                <td><asp:TextBox ID="BMI" runat="server"></asp:TextBox></td>
                <td></td>
            </tr>
            <tr>
                <td><asp:Button ID="calculate" runat="server" Text="Calculate" OnClick="Button2_Click" /></td>
                <td><asp:Button ID="reset" runat="server" OnClick="Button1_Click1" Text="Reset" /></td>
                <td></td>
            </tr>
        </table>
    </form>
</body>
</html>
