<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/NavBar.Master" AutoEventWireup="true" CodeBehind="LocationForms.aspx.cs" Inherits="AutoBalooWeb.WebForms.LocationForms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHContenu" runat="server">
    <div class="form">
        <h1>Location d'une voiture</h1>
        <hr>
        <div class="row mb-4">
            <div class="col">
                <div class="form-outline">
                    <asp:Label class="lblCars" runat="server" AssociatedControlID="txtdtdeb"> Date de début</asp:Label>
                    <asp:TextBox ID="txtdtdeb" runat="server" class="form-control" TextMode="Date" AutoPostBack="true" onkeypress="return false;" OnTextChanged="txtdtdeb_TextChanged"/>
                </div>
            </div>
            <div class="col">
                <div class="form-outline">
                    <asp:Label class="lblCars" runat="server" AssociatedControlID="txtdtfin"> Date de fin</asp:Label>
                    <asp:TextBox ID="txtdtfin" runat="server" class="form-control" TextMode="Date"/>
                </div>
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
            <asp:Button ID="btnLouerCars" runat="server" Text="Confirmer" class="btn btn-primary text-center" OnClick="BtnLouerCars_Click"/>
            <asp:Button ID="btnCancel" runat="server" Text="Annuler" class="btn btn-secondary text-center" OnClick="BtnCancel_Click"/>
       </div>
    </div>
</asp:Content>
