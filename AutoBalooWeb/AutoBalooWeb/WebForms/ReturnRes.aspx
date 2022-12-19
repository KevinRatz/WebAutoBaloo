<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/NavBar.Master" AutoEventWireup="true" CodeBehind="ReturnRes.aspx.cs" Inherits="AutoBalooWeb.WebForms.ReturnRes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHContenu" runat="server">
        <div class="form">
            <h1>Confirmer le paiement</h1>
            
            <asp:Button ID="btnConf" runat="server" Text="Confirmer" class="btn btn-primary text-center" OnClick="BtnConf_Click"/>
            <asp:Button ID="btnCancel" runat="server" Text="Annuler" class="btn btn-secondary text-center" OnClick="BtnCancel_Click"/>
        
            <asp:Literal ID="litInfo" runat="server"></asp:Literal>
        </div>
</asp:Content>
