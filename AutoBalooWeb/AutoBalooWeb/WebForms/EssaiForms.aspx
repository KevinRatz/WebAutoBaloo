<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/NavBar.Master" AutoEventWireup="true" CodeBehind="EssaiForms.aspx.cs" Inherits="AutoBalooWeb.WebForms.EssaiForms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHContenu" runat="server">
    <div class="form">
        <h1>Essai d'une voiture</h1>
        <hr>
        <div class="row mb-4">
            <div class="form-outline">
                <asp:Label class="lblCars" runat="server" AssociatedControlID="txtdt"> Date de l'essai</asp:Label>
                <asp:TextBox ID="txtdt" runat="server" class="form-control" TextMode="Date" AutoPostBack="true" OnTextChanged="txtdt_TextChanged"/>
            </div>
        </div>
        <div class="row mb-4">
            
            <div class="col">
                <div class="form-outline">
                    <asp:Label class="lblCars" runat="server"> Info Voiture</asp:Label>
                    <asp:Label ID="txtVe" runat="server"></asp:Label>
                </div>
            </div>
        </div>
        <p runat="server" class="error text-center" id="ct"></p>
        <div class="text-center">
            <asp:Button ID="btnEssaiCars" runat="server" Text="Confirmer" class="btn btn-primary text-center" OnClick="BtnEssaiCars_Click"/>
            <asp:Button ID="btnCancel" runat="server" Text="Annuler" class="btn btn-secondary text-center" OnClick="BtnCancel_Click"/>
        </div>
    </div>
</asp:Content>
