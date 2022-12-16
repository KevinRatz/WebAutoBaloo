<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/NavBar.Master" AutoEventWireup="true" CodeBehind="ChangeEtatCars.aspx.cs" Inherits="AutoBalooWeb.WebForms.ChangeEtatCars" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHContenu" runat="server">
    <div class="form" style="height: auto; padding-bottom: 20px;">
        <h1>Changement d'état d'une voiture</h1>
        <hr>
        <div class="row mb-4">
            <div class="col">
                <div class="form-outline">
                    <asp:Label class="lblCars" runat="server" AssociatedControlID="DDListId"> Id Voiture</asp:Label>
                    <asp:DropDownList ID="DDListId" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DDListId_SelectedIndexChanged"></asp:DropDownList>
                </div>
            </div>
            <div class="col">
                <div class="form-outline">
                    <asp:Label class="lblCars" runat="server" AssociatedControlID="DDListEtat"> Etat de la voiture</asp:Label>
                    <asp:DropDownList ID="DDListEtat" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DDListEtat_SelectedIndexChanged"></asp:DropDownList>
                </div>
            </div>
        </div>
        <p runat="server" class="error text-center" id="ct"></p>
        <div class="text-center">
            <asp:Button ID="btnUpEtatCars" runat="server" Text="Modifier" class="btn btn-primary text-center" OnClick="BtnUpEtatCars_Click"/>
        </div>
    </div>
</asp:Content>
