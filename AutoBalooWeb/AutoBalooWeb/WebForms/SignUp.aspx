﻿<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/NavBar.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="AutoBalooWeb.WebForms.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHContenu" runat="server">

    <div class="form">
        <h1>Inscription</h1>
        <hr>
        <div>
            <div class="input-group">
                <asp:Label class="icon input-group-addon" Text="Nom" runat="server" AssociatedControlID="txtNom"><i class="icon-user"></i></asp:Label>
                <asp:TextBox ID="txtNom" Text="Ratz" runat="server" class="form-control" placeholder="Entrer Nom" required="required"/>
            </div>
            <div class="input-group">
                <asp:Label class="icon input-group-addon" Text="Prenom" runat="server" AssociatedControlID="txtPrenom"><i class="icon-user"></i></asp:Label>
                <asp:TextBox ID="txtPrenom" Text="Kevin" runat="server" class="form-control" placeholder="Entrer Prenom" required="required"/>
            </div>
            <div class="input-group">
                <asp:Label class="icon input-group-addon" Text="Adresse" runat="server" AssociatedControlID="txtAdd"><i class="icon-home"></i></asp:Label>
                <asp:TextBox ID="txtAdd" Text="rue de sclessin" runat="server" class="form-control" placeholder="Entrer Adresse" required="required"/>
            </div>
            <div class="input-group">
                <asp:Label class="icon input-group-addon" Text="tel" runat="server" AssociatedControlID="txtTel"><i class="icon-phone"></i></asp:Label>
                <asp:TextBox ID="txtTel" Text="0494458515" runat="server" class="form-control" placeholder="Entrer tel" required="required"/>
            </div>
            <div class="input-group">
                <asp:Label class="icon input-group-addon" Text="" runat="server" AssociatedControlID="txtEmail"><i class="icon-envelope "></i></asp:Label>
                <asp:TextBox ID="txtEmail" Text="kev.r@stu.be" runat="server" TextMode="Email" class="form-control" placeholder="Entrer Email" required="required"/>
            </div>
            <div class="input-group">
                <asp:Label class="icon input-group-addon" Text="" runat="server" AssociatedControlID="txtPwd"><i class="icon-lock"></i></asp:Label>
                <asp:TextBox ID="txtPwd"  runat="server" TextMode="Password" ToolTip="Password must contain: Minimum 8 characters at-least 1 Alphabet and 1 Number"
                    class="form-control" placeholder="Entrer mot de passe" required="required" pattern="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$"/>
            </div>       
            <div class="input-group">
                    <asp:Label class="icon input-group-addon" Text="Confirm Password" runat="server" AssociatedControlID="txtConfirmPassword"><i class="icon-lock"></i></asp:Label>
                    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" class="form-control" placeholder="Confirmer Mot de passe" required="required"/>
            </div>
        </div>
        <div class="col-md-12 text-center">
        <asp:Button ID="btnSignup" runat="server" Text="S'inscrire" class="btn btn-primary text-center" OnClick="BtnSignup_Click"/>
        </div>
        <hr class="hr-text" data-content="OU"/><p style="text-align:center;margin-top:-30px;">OU</p>
                    
    </div>
        <%--  </div>
                    <asp:Label Text="Nom d'utilisateur" runat="server" AssociatedControlID="txtUser"/>
                    <asp:TextBox ID="txtUser" runat="server" class="form-control" placeholder="Entrer nom utilisateur" required="required"/>
        </div>--%>
        
                
           

        <%-- </fieldset>--%>
                
            
            
</asp:Content>
