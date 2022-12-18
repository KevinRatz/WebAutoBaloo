<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CancelRes.aspx.cs" Inherits="WebPaypalTest.WebForms.CancelRes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Payement réussi !!!</h1>

            <asp:Button ID="btnCancel" runat="server" Text="return to vente" class="btn btn-secondary text-center" OnClick="BtnCancel_Click"/>
        </div>
    </form>
</body>
</html>
