<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/NavBar.Master" AutoEventWireup="true" CodeBehind="UpCars.aspx.cs" Inherits="AutoBalooWeb.WebForms.UpCars" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHContenu" runat="server">
    <div class="form">
        <h1>Inscription</h1>
        <div class="">
    <div class="col">
      <div class="form-outline">
        <input type="text" id="form3Example1" class="form-control" />
        <label class="form-label" for="form3Example1">First name</label>
      </div>
    </div>
    <div class="col">
      <div class="form-outline">
        <input type="text" id="form3Example2" class="form-control" />
        <label class="form-label" for="form3Example2">Last name</label>
      </div>
    </div>
  </div>
        <hr>
        <div class="row mb-4">
            
            <div class="col-md-4">
                <asp:Label class="lblCars" runat="server" AssociatedControlID="DDListMarque"> Marque</asp:Label>
                <asp:DropDownList ID="DDListMarque" AutoPostBack="true" runat="server" Height="40px" style="margin-left: 24px"></asp:DropDownList>
            </div>
            <div class="col-md-4 input-group">
                <asp:Label class="lblCars input-group-addon" runat="server" AssociatedControlID="txtNom">Modele </asp:Label>
                <asp:TextBox ID="txtNom" Text="Kevin" runat="server" class="form-control" placeholder="Entrer modèle" required="required"/>
            </div>
        </div>
            <div class="col-md-2">
                <asp:Label class="lblCars" runat="server" AssociatedControlID="txtChassis">Numero chassis</asp:Label>
                <asp:TextBox ID="txtChassis" Text="2" runat="server" class="form-control" required="required"/>
            </div>
            <div class="input-group">
                <asp:Label class="lblCars input-group-addon" runat="server" AssociatedControlID="DDListCarro">Carro </asp:Label>
                <asp:DropDownList ID="DDListCarro" AutoPostBack="true" runat="server" Height="40px" style="margin-left: 24px"></asp:DropDownList>
            </div>
            <div class="input-group">
                <asp:Label class="lblCars input-group-addon" runat="server" AssociatedControlID="txtKm">Km</asp:Label>
                <asp:TextBox ID="txtKm" runat="server" class="form-control"/>
            </div>
            <div class="input-group">
                <asp:Label class="lblCars input-group-addon" runat="server" AssociatedControlID="RBTransm"> Nom</asp:Label>
                <asp:RadioButtonList ID="RBTransm" runat="server" Width="84px">
                    <asp:ListItem>auto</asp:ListItem>
                    <asp:ListItem>man</asp:ListItem>
                </asp:RadioButtonList>
                <asp:DropDownList ID="DDListTrans" AutoPostBack="true" runat="server" Height="40px" style="margin-left: 24px"></asp:DropDownList>
            </div>
            <div id="vitesseGroup" class="input-group" visible="false">
                <asp:Label class="lblCars input-group-addon" runat="server" AssociatedControlID="txtNbVitesse"> Vitesse</asp:Label>
                <asp:TextBox ID="txtNbVitesse" Text="7" runat="server" class="form-control" placeholder="Entrer nb vitesse" required="required"
                    pattern="^([0-9]{1})$" />
            </div>       
            <div class="input-group">
                <asp:Label class="lblCars input-group-addon" runat="server" AssociatedControlID="txtPrix"> Prix</asp:Label>
                <asp:TextBox ID="txtPrix" runat="server" class="form-control" placeholder="Entrer Prix"/>
            </div>
            <div class="input-group">
                <asp:Label class="lblCars input-group-addon" runat="server" AssociatedControlID="DDLCarbu">Carburant</asp:Label>
                <asp:DropDownList ID="DDLCarbu" AutoPostBack="true" runat="server" Height="40px" style="margin-left: 24px"></asp:DropDownList>
            </div>
            <div class="input-group">
                <asp:Label class="lblCars input-group-addon" runat="server" AssociatedControlID="txtAn">An</asp:Label>
                    
                <asp:TextBox id="txtAn" runat="server" class="form-control" TextMode="Date"/>
            </div>       
            <div class="input-group">
                <asp:Label class="lblCars input-group-addon" runat="server" AssociatedControlID="txtPuissance"> Pui</asp:Label>
                <asp:TextBox ID="txtPuissance" Text="81 kW (110 CH)" runat="server" class="form-control" placeholder="Entrer Adresse" required="required"/>
            </div>
            <div class="input-group">
                <asp:Label class="lblCars input-group-addon" runat="server" AssociatedControlID="txtNbPortes"> Portes :</asp:Label>
                <asp:TextBox ID="txtNbPortes" Text="3" runat="server" pattern="^([3,5]{1})$" class="form-control" placeholder="Entrer tel" required="required"/>
                <asp:RadioButtonList ID="RBPortes" RepeatDirection="Horizontal" runat="server" Width="84px">
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                </asp:RadioButtonList> 
            </div>
            <div class="input-group">
                <asp:Label class="lblCars input-group-addon" runat="server" AssociatedControlID="txtCylindres"></asp:Label>
                <asp:TextBox ID="txtCylindres"  runat="server" class="form-control" placeholder="Entrer valeur du cylindré"/>
            </div>       
            <div class="input-group">
                <asp:Label class="lblCars input-group-addon" runat="server" AssociatedControlID="txtCouleur">Couleur</asp:Label>
                <asp:TextBox ID="txtCouleur" runat="server" TextMode="Color" class="form-control" placeholder=""/>
            </div>       
            <div class="input-group">
                <asp:Label class="lblCars input-group-addon" runat="server" AssociatedControlID="dateCtrlTech"></asp:Label>
                <asp:TextBox ID="dateCtrlTech" runat="server" class="form-control" TextMode="Date"/>
            </div>       
            <div class="input-group">
                <asp:Label class="lblCars input-group-addon" runat="server" AssociatedControlID="txtCtEntretien"> CtEntretien</asp:Label>
                <asp:TextBox ID="txtCtEntretien" runat="server" class="form-control"/>
                <asp:RadioButtonList ID="RBCtEnt" RepeatDirection="Horizontal" runat="server">
                    <asp:ListItem>Oui</asp:ListItem>
                    <asp:ListItem>Non</asp:ListItem>
                </asp:RadioButtonList> 
            </div>       
            <div class="input-group">
                <asp:Label class="lblCars input-group-addon" runat="server" AssociatedControlID="RBTrans"> Type</asp:Label>
                <asp:RadioButtonList ID="RBTrans" RepeatDirection="Horizontal" runat="server">
                    <asp:ListItem>Vente</asp:ListItem>
                    <asp:ListItem>Location</asp:ListItem>
                </asp:RadioButtonList>            
            </div>       
            <div class="input-group">
                <asp:Label class="lblCars input-group-addon" runat="server" AssociatedControlID="txtReduct"> Reduction</asp:Label>
                <asp:TextBox ID="txtReduct" runat="server" class="form-control"/>
            </div>       
            <div class="input-group">
                <asp:Label class="lblCars input-group-addon" runat="server" for="InFile">Photo :</asp:Label>
                <input type="file" class="form-control-file" id="InFile">
            </div>       
            <div class="input-group">
                <asp:Label class="lblCars input-group-addon" runat="server" AssociatedControlID="txtdtarv"> Date arv</asp:Label>
                <asp:TextBox ID="txtdtarv" runat="server" class="form-control" TextMode="Date"/>
            </div>
        <%--</div>--%>
        <p runat="server" class="error text-center" id="ct"></p>
        <div class="text-center">
            <asp:Button ID="btnUpCars" runat="server" Text="Modifier" class="btn btn-primary text-center" OnClick="BtnUpCars_Click"/>
        </div>
    </div>
</asp:Content>
