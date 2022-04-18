<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="lab10.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="weight" runat="server" style="z-index: 1; left: 120px; top: 15px; position: absolute"></asp:TextBox>
        <asp:TextBox ID="height" runat="server" style="z-index: 1; left: 119px; top: 53px; position: absolute; margin-top: 0px; bottom: 254px;"></asp:TextBox>
        <asp:TextBox ID="BMI" runat="server" style="z-index: 1; left: 119px; top: 90px; position: absolute"></asp:TextBox>
        <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 10px; top: 15px; position: absolute" Text="Gewicht (kg):"></asp:Label>
        <asp:Label ID="Label2" runat="server" style="z-index: 1; left: 9px; top: 55px; position: absolute" Text="Grösse (m):"></asp:Label>
        <asp:Label ID="Label3" runat="server" style="z-index: 1; left: 13px; top: 91px; position: absolute" Text="BMI:"></asp:Label>
        <asp:Button ID="reset" runat="server" OnClick="Button1_Click1" style="z-index: 1; left: 10px; top: 129px; position: absolute" Text="Reset" />
        <asp:Button ID="calculate" runat="server" style="z-index: 1; left: 76px; top: 129px; position: absolute" Text="Calculate" OnClick="Button2_Click" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="weight" ErrorMessage="Gewicht muss ausgefüllt sein!" style="z-index: 1; left: 301px; top: 15px; position: absolute"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="height" ErrorMessage="Grösse muss ausgefüllt sein!" style="z-index: 1; left: 300px; top: 53px; position: absolute"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="height" MinimumValue="1.0" MaximumValue="2.8" ErrorMessage="Grösse muss zwischen 1.0 und 2.8 liegen!" style="z-index: 1; left: 302px; top: 53px; position: absolute; bottom: 257px"></asp:RangeValidator>
    </form>
</body>
</html>
