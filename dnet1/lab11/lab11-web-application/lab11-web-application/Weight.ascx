<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Weight.ascx.cs" Inherits="lab11_web_application.Weight" %>

<asp:Label ID="weightLabel" runat="server" Text="Gewicht (kg):"></asp:Label>
<asp:TextBox ID="weight" runat="server"></asp:TextBox>
<asp:DropDownList ID="weightUnit" AutoPostBack="true" OnSelectedIndexChanged="Select" Runat="server">
    <asp:ListItem Text="kg" Value="kg" Selected="true" />
    <asp:ListItem Text="lb" Value="lb" />
</asp:DropDownList>
<asp:RequiredFieldValidator ID="weightRequiredValidator" runat="server" ControlToValidate="weight" ErrorMessage="Gewicht muss ausgefüllt sein!"></asp:RequiredFieldValidator>