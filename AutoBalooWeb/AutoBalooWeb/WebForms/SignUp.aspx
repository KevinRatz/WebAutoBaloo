<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/NavBar.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="AutoBalooWeb.WebForms.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHContenu" runat="server">
    <div "col-xs-12 text-md-left text-center">
            <h2 class="form-signin-heading">Créer un compte</h2>
    </div>
    
    <div class="col col-md-3"></div>
    <div class="col col-md-3">
    <fieldset>
    <legend>Un champ pour le choix de la radio</legend>
    <input type="radio" name="radio" id="radio">
    <label for="radio">Cliquez ici</label>
  </fieldset></div>


    <div class="row ">
        <fieldset>
        <legend>identifiant</legend>
            
                
                <div class="form-group col-md-3">
                        <asp:Label Text="Email" runat="server" AssociatedControlID="txtEmail"/>
                        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" class="form-control" placeholder="Entrer Email" required="required"/>
                
            </div>
            <div class="row ">
                <div class="col col-md-3"></div>
                <div class="form-group col-md-3">
                        <asp:Label Text="Mot de passe" runat="server" AssociatedControlID="txtPwd"/>
                        <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" ToolTip="Password must contain: Minimum 8 characters at-least 1 Alphabet and 1 Number"
                            class="form-control" placeholder="Entrer mot de passe" required="required" pattern="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$"/>
                    </div>

            </div>
            <div class="row ">
                <div class="col col-md-3"></div>
                <div class="form-group col-md-3">        
                        <asp:Label Text="Confirm Password" runat="server" AssociatedControlID="txtConfirmPassword"/>
                        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" class="form-control" placeholder="Confirmer Mot de passe" required="required"/>
                </div>
                </div>

        </fieldset></div>
        <%--<div class="form-group col-md-3">
                    <asp:Label Text="Nom d'utilisateur" runat="server" AssociatedControlID="txtUser"/>
                    <asp:TextBox ID="txtUser" runat="server" class="form-control" placeholder="Entrer nom utilisateur" required="required"/>
        </div>--%>

        <fieldset>
        <legend>infos</legend>
            <div class="row ">
                <div class="col col-md-3"></div>
                <div class="form-group col-md-3">
                    <asp:Label Text="Nom" runat="server" AssociatedControlID="txtNom"/>
                    <asp:TextBox ID="txtNom" runat="server" class="form-control" placeholder="Entrer Nom" required="required"/>
                </div>
            </div>
            <div class="row ">
                <div class="col col-md-3"></div>
                <div class="form-group col-md-3">
                    <asp:Label Text="Prenom" runat="server" AssociatedControlID="txtPrenom"/>
                    <asp:TextBox ID="txtPrenom" runat="server" class="form-control" placeholder="Entrer Prenom" required="required"/>
                </div>
            </div>
            <div class="row">
                <div class="col col-md-3"></div>
                <div class="form-group col-md-3">
                    <asp:Label Text="Adresse" runat="server" AssociatedControlID="txtAdd"/>
                    <asp:TextBox ID="txtAdd" runat="server" class="form-control" placeholder="Entrer Adresse" required="required"/>
                </div>
            </div>
            <div class="row">
                <div class="col col-md-3"></div>
                <div class="form-group col-md-3">
                    <asp:Label Text="tel" runat="server" AssociatedControlID="txtTel"/>
                    <asp:TextBox ID="txtTel" runat="server" class="form-control" placeholder="Entrer tel" required="required"/>
                </div>
            </div>

        </fieldset>
                
            
            <hr/>
            <asp:Button ID="btnSignup" runat="server" Text="Enregistrer" class="btn btn-primary" OnClick="BtnSignup_Click"/>
    <%--</div>--%>
</asp:Content>
