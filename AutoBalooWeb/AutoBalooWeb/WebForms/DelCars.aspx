<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/NavBar.Master" AutoEventWireup="true" CodeBehind="DelCars.aspx.cs" Inherits="AutoBalooWeb.WebForms.DelCars" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHContenu" runat="server">
    <div class="form">
        <h1>Supprimer une voiture</h1>
        <hr>
        <div class="row mb-4">
            <div class="col">
                <div class="form-outline">
                    <asp:Label class="lblCars" runat="server" AssociatedControlID="DDListId"> Info Voiture</asp:Label>
                    <asp:DropDownList ID="DDListId" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DDListId_SelectedIndexChanged"></asp:DropDownList>
                </div>
            </div>
        </div>
        <p runat="server" class="error text-center" id="ct"></p>
        <div class="text-center">
            <asp:Button ID="btnDelCars" runat="server" Text="Supprimer" class="btn btn-primary text-center" OnClick="BtnDelCars_Click"/>
        </div>
    </div>>
</asp:Content>
