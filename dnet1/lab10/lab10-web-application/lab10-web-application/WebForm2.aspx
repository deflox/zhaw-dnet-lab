<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="lab10_web_application.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td><asp:Label ID="Label1" runat="server" Text="Gewicht (kg):"></asp:Label></td>
                <td><asp:TextBox ID="weight" runat="server"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="weight" ErrorMessage="Gewicht muss ausgefüllt sein!" style="z-index: 1; left: 301px; top: 15px; position: absolute"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label2" runat="server" Text="Grösse (m):"></asp:Label></td>
                <td><asp:TextBox ID="height" runat="server"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="height" ErrorMessage="Grösse muss ausgefüllt sein!" style="z-index: 1; left: 300px; top: 53px; position: absolute"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="height" MinimumValue="1.0" MaximumValue="2.8" ErrorMessage="Grösse muss zwischen 1.0 und 2.8 liegen!" style="z-index: 1; left: 302px; top: 53px; position: absolute; bottom: 257px"></asp:RangeValidator>
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
