<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/NavBar.Master" AutoEventWireup="true" CodeBehind="VenteForms.aspx.cs" Inherits="AutoBalooWeb.WebForms.VenteForms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHContenu" runat="server">
    <div class="form">
        <h1 id="hh" runat="server">Réservation</h1>
        <hr>
        <div class="row mb-4">
            <div class="col">
                <div class="form-outline">
                    <asp:Label class="lblCars" runat="server"> Date réservé</asp:Label>
                    <asp:Label ID="txtdtRes" runat="server"></asp:Label>
                </div>
            </div>
            <div class="col">
                <div class="form-outline">
                    <asp:Label class="lblCars" runat="server"> Info Voiture</asp:Label>
                    <asp:Label ID="txtVe" runat="server"></asp:Label>
                </div>
            </div>
        </div>
        <p runat="server" class="error text-center" id="ct"></p>
        <div class="text-center">
            <asp:Button ID="btnResCars" runat="server" Text="Confirmer" class="btn btn-primary text-center" OnClick="BtnResCars_Click"/>
            <asp:Button ID="btnCancel" runat="server" Text="Annuler" class="btn btn-secondary text-center" OnClick="BtnCancel_Click"/>
        </div>
    </div>
</asp:Content>
