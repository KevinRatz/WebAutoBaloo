<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReturnRes.aspx.cs" Inherits="WebPaypalTest.WebForms.ReturnRes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Fin du paiement</h1>
            
            <asp:Button ID="btnConf" runat="server" Text="Confirmer" class="btn btn-secondary text-center" OnClick="BtnConf_Click"/>
            <asp:Button ID="btnCancel" runat="server" Text="return" class="btn btn-secondary text-center" OnClick="BtnCancel_Click"/>
        
            <asp:Literal ID="litInfo" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>
