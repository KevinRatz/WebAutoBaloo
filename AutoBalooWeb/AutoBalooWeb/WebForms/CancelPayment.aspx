<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/NavBar.Master" AutoEventWireup="true" CodeBehind="CancelPayment.aspx.cs" Inherits="AutoBalooWeb.WebForms.CancelPayment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHContenu" runat="server">
    <div class="form">
        <h1>Paiement annulé !!!</h1>
        <asp:Button ID="btnCancel" runat="server" Text="Retour à la vente" class="btn btn-secondary text-center" OnClick="BtnCancel_Click"/>
    </div>
</asp:Content>
