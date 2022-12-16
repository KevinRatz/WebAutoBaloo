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
                    <asp:Label class="lblCars" runat="server" AssociatedControlID="txtdtRes"> Date réservé</asp:Label>
                    <asp:TextBox ID="txtdtRes" runat="server" class="form-control" TextMode="Date"/>
                </div>
            </div>
        </div>
        <p runat="server" class="error text-center" id="ct"></p>
        <div class="text-center">
            <asp:Button ID="btnResCars" runat="server" Text="Réservé" class="btn btn-primary text-center" OnClick="BtnResCars_Click"/>
        </div>
    </div>
</asp:Content>
