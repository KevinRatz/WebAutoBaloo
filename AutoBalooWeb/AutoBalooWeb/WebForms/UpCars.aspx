<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/NavBar.Master" AutoEventWireup="true" CodeBehind="UpCars.aspx.cs" Inherits="AutoBalooWeb.WebForms.UpCars" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHContenu" runat="server">
    <div class="form">
        <h1>Modifier une voiture</h1>
        <hr>
        <div class="row mb-4">
            <div class="form-outline">
                <asp:Label class="lblCars" runat="server" AssociatedControlID="DDListId"> Id voiture</asp:Label>
                <asp:DropDownList ID="DDListId" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DDListId_SelectedIndexChanged"></asp:DropDownList>
            </div>
        </div>
        <div class="row mb-4">
            <div class="col">
                <div class="form-outline">
                    <asp:Label class="lblCars" runat="server" AssociatedControlID="DDListMarque"> Marque</asp:Label>
                    <asp:DropDownList ID="DDListMarque" AutoPostBack="true" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div class="col">
                <div class="form-outline">
                    <asp:Label class="lblCars" runat="server" AssociatedControlID="txtNom">Modèle </asp:Label>
                    <asp:TextBox ID="txtNom" Text="Kevin" runat="server" class="form-control" required="required"/>
                </div>
            </div>
        </div>
        <div class="row mb-4">
            <div class="col">
                <div class="form-outline">
                    <asp:Label class="lblCars" runat="server" AssociatedControlID="txtChassis">N° chassis</asp:Label>
                    <asp:TextBox ID="txtChassis" Text="2" runat="server" class="form-control" required="required"/>
                </div>
            </div>
            <div class="col">
                <div class="form-outline">
                    <asp:Label class="lblCars" runat="server" AssociatedControlID="DDListCarro">Carrosserie </asp:Label>
                    <asp:DropDownList ID="DDListCarro" AutoPostBack="true" runat="server"></asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="row mb-4">
            <div class="col">
                <div class="form-outline">
                    <asp:Label class="lblCars" runat="server" AssociatedControlID="txtKm">Kilométrage (Km)</asp:Label>
                    <asp:TextBox ID="txtKm" runat="server" class="form-control" TextMode="Number" step="any"/>
                </div>
            </div>
            <div class="col">
                <div class="form-outline">
                    <asp:Label class="lblCars" runat="server" AssociatedControlID="txtAn">Année</asp:Label>                    
                    <asp:TextBox id="txtAn" runat="server" class="form-control" TextMode="Date"/>
                </div>
            </div>
        </div>
        <div class="row mb-4">
            <div class="col">
                <div class="form-outline">
                    <asp:Label class="lblCars" runat="server" AssociatedControlID="RBTransm"> Transmission</asp:Label>
                    <asp:RadioButtonList ID="RBTransm" RepeatDirection="Horizontal" AutoPostBack="true" runat="server" OnSelectedIndexChanged="RBTransm_SelectedIndexChanged">
                        <asp:ListItem>Automatique</asp:ListItem>
                        <asp:ListItem>Manuelle</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="col">
                <div id="vitesseHide" runat="server" class="form-outline" style="display:none;">
                    <asp:Label class="lblCars" runat="server" AssociatedControlID="txtNbVitesse"> Vitesse</asp:Label>
                    <asp:TextBox ID="txtNbVitesse" Text="7" runat="server" class="form-control" TextMode="Number" required="required"
                        pattern="^([0-9]{1})$" ToolTip="1 chiffre entre 6 et 9"/>
                </div>
            </div>
        </div>
        <div class="row mb-4">
            <div class="col">
                <div class="form-outline">
                    <asp:Label class="lblCars" runat="server" AssociatedControlID="txtPrix"> Prix (€)</asp:Label>
                    <asp:TextBox ID="txtPrix" runat="server" class="form-control" TextMode="Number" step="any"/>                    
                </div>
            </div>
            <div class="col">
                <div class="form-outline">
                    <asp:Label class="lblCars" runat="server" AssociatedControlID="txtReduct"> Reduction (%)</asp:Label>
                    <asp:TextBox ID="txtReduct" text="0" runat="server" TextMode="Number" class="form-control"/>                  
                </div>
            </div>
        </div>
        <div class="row mb-4">
            <div class="col">
                <div class="form-outline">
                    <asp:Label class="lblCars" runat="server" AssociatedControlID="txtPuissance"> Puissance</asp:Label>
                    <asp:TextBox ID="txtPuissance" Text="81 kW (110 CH)" runat="server" class="form-control" />
                </div>
            </div>
            <div class="col">
                <div class="form-outline">
                    <asp:Label class="lblCars" runat="server" AssociatedControlID="RBPortes"> Portes :</asp:Label>
                    <asp:RadioButtonList ID="RBPortes" RepeatDirection="Horizontal" runat="server" Width="84px">
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                    </asp:RadioButtonList> 
                </div>
            </div>
        </div>
        <div class="row mb-4">
            <div class="col">
                <div class="form-outline">
                    <asp:Label class="lblCars" runat="server" AssociatedControlID="txtCylindres">Cylindrée (cm³)</asp:Label>
                    <asp:TextBox ID="txtCylindres"  runat="server" class="form-control" TextMode="Number"/>                    
                </div>
            </div>
            <div class="col">
                <div class="form-outline">
                    <asp:Label class="lblCars" runat="server" AssociatedControlID="DDListCarbu">Carburant</asp:Label>
                    <asp:DropDownList ID="DDListCarbu" AutoPostBack="true" runat="server"></asp:DropDownList>                       
                </div>
            </div>
        </div>
        <div class="row mb-4">
            <div class="col">
                <div class="form-outline">
                    <asp:Label class="lblCars" runat="server" AssociatedControlID="RBCtEnt"> Controle Entretien</asp:Label>
                    <asp:RadioButtonList ID="RBCtEnt" RepeatDirection="Horizontal" AutoPostBack="true" runat="server" OnSelectedIndexChanged="RBCtEnt_SelectedIndexChanged">
                        <asp:ListItem>Oui</asp:ListItem>
                        <asp:ListItem>Non</asp:ListItem>
                    </asp:RadioButtonList>                     
                </div>
            </div>
            <div class="col">
                <div id="dtCtrlTechH" runat="server" class="form-outline" style="display:none;">
                    <asp:Label class="lblCars" runat="server" AssociatedControlID="dateCtrlTech"> Date Controle Entretien</asp:Label>
                    <asp:TextBox ID="dateCtrlTech" runat="server" class="form-control" TextMode="Date"/>                   
                </div>
            </div>
        </div>
        <div class="row mb-4">
            <div class="col">
                <div class="form-outline">
                    <asp:Label class="lblCars" runat="server" AssociatedControlID="RBTrans"> Type</asp:Label>
                    <asp:RadioButtonList ID="RBTrans"  RepeatLayout="Flow" RepeatDirection="Horizontal" runat="server" style="
    margin: auto 0px;">
                        <asp:ListItem>Vente</asp:ListItem>
                        <asp:ListItem>Location</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="col">
                <div class="form-outline">
                    <asp:Label class="lblCars" runat="server" AssociatedControlID="txtCouleur">Couleur</asp:Label>
                    <asp:TextBox ID="txtCouleur" runat="server" class="form-control" /> 
                </div>
            </div>
        </div>
        <div class="row mb-4">
            <div class="col">
                <div class="form-outline">
                    <asp:Label class="lblCars" runat="server" for="InPhoto">Photo</asp:Label>
                    <input type="file" runat="server" class="form-control-file" id="InPhoto"/>
                    <%--<asp:button id="btnUpload" type="submit" text="Upload" ></asp:button>--%>
                </div>
            </div>
            <div class="col">
                <div class="form-outline" style="margin-left:-48px;">
                    <asp:Label class="lblCars" runat="server" AssociatedControlID="txtdtarv"> Date arrivé</asp:Label>
                    <asp:TextBox ID="txtdtarv" runat="server" class="form-control" TextMode="Date"/>
                </div>
            </div>
        </div>

        <p runat="server" class="error text-center" id="ct"></p>
        <div class="text-center">
            <asp:Button ID="btnUpCars" runat="server" Text="Modifier" class="btn btn-primary text-center" OnClick="BtnUpCars_Click"/>
        </div>
    </div>
</asp:Content>
