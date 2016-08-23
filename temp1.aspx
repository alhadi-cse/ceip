<%@ Page Language="C#" AutoEventWireup="true" CodeFile="temp1.aspx.cs" Inherits="temp1" %>

<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Temp Page</title>
    <link href="Styles/temp.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.corner.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            //$(".popup").corner("top");
            //$(".popup_header").corner("top");
            //$("#popup_map_layer").draggable();
            //$(".popup").draggable({ handle: ".popup_header" });
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">

        <asp:TextBox ID="txtInput" runat="server" Width="300px"></asp:TextBox>
        <br />

        <asp:Button ID="btnEncrypt" runat="server" Text="Encrypt" OnClick="btnEncrypt_Click" />

        <asp:Button ID="btnDecrypt" runat="server" Text="Decrypt" OnClick="btnDecrypt_Click" />
        <br />
        <asp:TextBox ID="txtOutput" runat="server" Width="300px"></asp:TextBox>



    </form>
</body>
</html>
