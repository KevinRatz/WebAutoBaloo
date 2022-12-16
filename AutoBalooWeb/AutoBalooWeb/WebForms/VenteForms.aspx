<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/NavBar.Master" AutoEventWireup="true" CodeBehind="VenteForms.aspx.cs" Inherits="AutoBalooWeb.WebForms.VenteForms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHContenu" runat="server">
    <div class="form">
        <h1>Ajouter une voiture</h1>
        <hr>
        <div class="row mb-4">
            <div class="col">
                <div class="form-outline" style="margin-left:-48px;">
                    <asp:Label class="lblCars" runat="server" AssociatedControlID="txtdtarv"> Date arrivé</asp:Label>
                    <asp:TextBox ID="txtdtarv" runat="server" class="form-control" TextMode="Date"/>
                </div>
            </div>
        </div>
        <p runat="server" class="error text-center" id="ct"></p>
        <div class="text-center">
            <asp:Button ID="btnAddCars" runat="server" Text="Ajouter" class="btn btn-primary text-center" OnClick="BtnAddCars_Click"/>
        </div>
    </div>
</asp:Content>
