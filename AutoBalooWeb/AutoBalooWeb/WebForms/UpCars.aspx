<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/NavBar.Master" AutoEventWireup="true" CodeBehind="UpCars.aspx.cs" Inherits="AutoBalooWeb.WebForms.UpCars" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHContenu" runat="server">
    <div class="form">
        <h1>Inscription</h1>
        <hr>
        <div>
            <div class="input-group">
                <asp:Label class="icon input-group-addon" runat="server" AssociatedControlID="txtChassis"><i class="icon-user"></i></asp:Label>
                <asp:TextBox ID="txtChassis" Text="" runat="server" class="form-control" placeholder="Entrer Numero chassis" required="required"/>
            </div>
            <div class="input-group">
                <asp:Label class="icon input-group-addon" runat="server" AssociatedControlID="txtMarque"><i class="icon-user"></i></asp:Label>
                <asp:TextBox ID="txtMarque" Text="Kevin" runat="server" class="form-control" placeholder="Entrer modèle" required="required"/>
            </div>
            <div class="input-group">
                <asp:Label class="icon input-group-addon" runat="server" AssociatedControlID="txtNom"><i class="icon-user"></i></asp:Label>
                <asp:TextBox ID="txtNom" Text="Kevin" runat="server" class="form-control" placeholder="Entrer modèle" required="required"/>
            </div>
            <div class="input-group">
                <asp:Label class="icon input-group-addon" runat="server" AssociatedControlID="txtNom"><i class="icon-user"></i></asp:Label>
                <asp:TextBox ID="txtCarro" Text="Kevin" runat="server" class="form-control" placeholder="Entrer modèle" required="required"/>
            </div>
            <div class="input-group">
                <asp:Label class="icon input-group-addon" runat="server" AssociatedControlID="txtNom"><i class="icon-user"></i></asp:Label>
                <asp:TextBox ID="txtNom" Text="Kevin" runat="server" class="form-control" placeholder="Entrer modèle" required="required"/>
            </div>       
            <div class="input-group">
                    <asp:Label class="icon input-group-addon" runat="server" AssociatedControlID="txtConfirmPassword"><i class="icon-lock"></i></asp:Label>
                    <asp:TextBox ID="txtPrix" runat="server" class="form-control" placeholder="Confirmer Mot de passe"/>
            </div>
            <div class="input-group">
                <asp:Label class="icon input-group-addon" runat="server" AssociatedControlID="txtPuissance"><i class="icon-home"></i></asp:Label>
                <asp:TextBox ID="txtPuissance" Text="rue de sclessin" runat="server" class="form-control" placeholder="Entrer Adresse" required="required"/>
            </div>
            <div class="input-group">
                <asp:Label class="icon input-group-addon" runat="server" AssociatedControlID="txtNbPortes"><i class="icon-phone"></i></asp:Label>
                <asp:TextBox ID="txtNbPortes" Text="0494458515" runat="server" class="form-control" placeholder="Entrer tel" required="required"/>
            </div>
            <div class="input-group">
                <asp:Label class="icon input-group-addon" runat="server" AssociatedControlID="txtNbVitesse"><i class="icon-envelope "></i></asp:Label>
                <asp:TextBox ID="txtNbVitesse" Text="kev.r@stu.be" runat="server" TextMode="Email" class="form-control" placeholder="Entrer Email" required="required"
                    pattern="^([\w\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" />
            </div>
            <div class="input-group">
                <asp:Label class="icon input-group-addon" runat="server" AssociatedControlID="txtPwd"><i class="icon-lock"></i></asp:Label>
                <asp:TextBox ID="txtCylindres"  runat="server" ToolTip="Mot de passe doit contenir: Minimum 8 caracteres at-least 1 Alphabet and 1 Number"
                    class="form-control" placeholder="Entrer mot de passe" pattern="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{2,}$"/>
            </div>       
            <div class="input-group">
                    <asp:Label class="icon input-group-addon" runat="server" AssociatedControlID="txtConfirmPassword"><i class="icon-lock"></i></asp:Label>
                    <asp:TextBox ID="txtCouleur" runat="server" class="form-control" placeholder="Confirmer Mot de passe"/>
            </div>       
            <div class="input-group">
                    <asp:Label class="icon input-group-addon" runat="server" AssociatedControlID="txtConfirmPassword"><i class="icon-lock"></i></asp:Label>
                    <asp:TextBox ID="txtKm" runat="server" class="form-control" placeholder="Confirmer Mot de passe"/>
            </div>       
            <div class="input-group">
                    <asp:Label class="icon input-group-addon" runat="server" AssociatedControlID="txtConfirmPassword"><i class="icon-lock"></i></asp:Label>
                <date    
                <asp:TextBox ID="txtAn" runat="server" class="form-control" placeholder="Confirmer Mot de passe"/>
            </div>       
            <div class="input-group">
                    <asp:Label class="icon input-group-addon" runat="server" AssociatedControlID="txtConfirmPassword"><i class="icon-lock"></i></asp:Label>
                    <asp:TextBox ID="txtCouleur" runat="server" class="form-control" placeholder="Confirmer Mot de passe"/>
            </div>       
            <div class="input-group">
                    <asp:Label class="icon input-group-addon" runat="server" AssociatedControlID="txtConfirmPassword"><i class="icon-lock"></i></asp:Label>
                    <asp:TextBox ID="txtCtEntretien" runat="server" class="form-control" placeholder="Confirmer Mot de passe"/>
            </div>       
            <div class="input-group">
                    <asp:Label class="icon input-group-addon" runat="server" AssociatedControlID="txtConfirmPassword"><i class="icon-lock"></i></asp:Label>
                    <asp:TextBox ID="txtTpTransact" runat="server" class="form-control" placeholder="Confirmer Mot de passe"/>
            </div>       
            <div class="input-group">
                    <asp:Label class="icon input-group-addon" runat="server" AssociatedControlID="txtConfirmPassword"><i class="icon-lock"></i></asp:Label>
                    <asp:TextBox ID="txtReduct" runat="server" class="form-control" placeholder="Confirmer Mot de passe"/>
            </div>       
            <div class="input-group">
                    <asp:Label class="icon input-group-addon" runat="server" AssociatedControlID="txtConfirmPassword"><i class="icon-lock"></i></asp:Label>
                    <asp:TextBox ID="txtphoto" runat="server" class="form-control" placeholder="Confirmer Mot de passe"/>
            </div>       
            <div class="input-group">
                    <asp:Label class="icon input-group-addon" runat="server" AssociatedControlID="txtConfirmPassword"><i class="icon-lock"></i></asp:Label>
                    <asp:TextBox ID="txtdtarrv" runat="server" class="form-control" placeholder="Confirmer Mot de passe"/>
            </div>       
            <div class="input-group">
                    <asp:Label class="icon input-group-addon" runat="server" AssociatedControlID="txtConfirmPassword"><i class="icon-lock"></i></asp:Label>
                    
            </div>       
            <div class="input-group">
                    <asp:Label class="icon input-group-addon" runat="server" AssociatedControlID="txtConfirmPassword"><i class="icon-lock"></i></asp:Label>
                    
            </div>
        </div>
        <p runat="server" class="error text-center" id="ct"></p>
        <div class="text-center">
        <asp:Button ID="btnSignup" runat="server" Text="S'inscrire" class="btn btn-primary text-center" OnClick="BtnSignup_Click"/>
        </div>
    </div>
</asp:Content>
