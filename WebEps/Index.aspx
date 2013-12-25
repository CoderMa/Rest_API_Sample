<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebEps.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <h1><%: SampleString %></h1>
    </div>
        <asp:TextBox ID="UserNametex" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="PassWordTex" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Button ID="SubmitBtn" runat="server" OnClick="SubmitBtn_Click" Text="Login" />
        <br />
        <br />
        <asp:Button ID="PostBtn" runat="server" OnClick="PostBtn_Click" Text="Post Sample" />
        <br />
    </form>
</body>
</html>
