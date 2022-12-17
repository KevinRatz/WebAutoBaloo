<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/NavBar.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="AutoBalooWeb.WebForms.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHContenu" runat="server">

    <div class="form">
        <h1>Inscription</h1>
        <hr>
        <div>
            <div class="input-group">
                <asp:Label class="icon input-group-addon" runat="server" AssociatedControlID="txtNom"><i class="icon-user"></i></asp:Label>
                <asp:TextBox ID="txtNom" Text="" runat="server" class="form-control" placeholder="Entrer Nom"/>
            </div>
            <div class="input-group">
                <asp:Label class="icon input-group-addon" runat="server" AssociatedControlID="txtPrenom"><i class="icon-user"></i></asp:Label>
                <asp:TextBox ID="txtPrenom" Text="Kevin" runat="server" class="form-control" placeholder="Entrer Prenom" required="required"/>
            </div>
            <div class="input-group">
                <asp:Label class="icon input-group-addon" runat="server" AssociatedControlID="txtAdd"><i class="icon-home"></i></asp:Label>
                <asp:TextBox ID="txtAdd" Text="rue de sclessin" runat="server" class="form-control" placeholder="Entrer Adresse" required="required"/>
            </div>
            <div class="input-group">
                <asp:Label class="icon input-group-addon" runat="server" AssociatedControlID="txtTel"><i class="icon-phone"></i></asp:Label>
                <asp:TextBox ID="txtTel" Text="0494458515" runat="server" class="form-control" placeholder="Entrer tel" required="required"/>
            </div>
            <div class="input-group">
                <asp:Label class="icon input-group-addon" runat="server" AssociatedControlID="txtEmail"><i class="icon-envelope "></i></asp:Label>
                <asp:TextBox ID="txtEmail" Text="kev.r@stu.be" runat="server" TextMode="Email" class="form-control" placeholder="Entrer Email"
                    pattern="^([\w\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" />
            </div>
            <div class="input-group">
                <asp:Label class="icon input-group-addon" runat="server" AssociatedControlID="txtPwd"><i class="icon-lock"></i></asp:Label>
                <asp:TextBox ID="txtPwd"  runat="server" TextMode="Password" ToolTip="Mot de passe doit contenir: Minimum 8 caracteres at-least 1 Alphabet and 1 Number"
                    class="form-control" placeholder="Entrer mot de passe" pattern="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{2,}$"/>
            </div>       
            <div class="input-group">
                    <asp:Label class="icon input-group-addon" runat="server" AssociatedControlID="txtConfirmPassword"><i class="icon-lock"></i></asp:Label>
                    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" class="form-control" placeholder="Confirmer Mot de passe"/>
            </div>
        </div>
        <p runat="server" class="error text-center" id="ct"></p>
        <div class="text-center">
            <asp:Button ID="btnSignup" runat="server" Text="S'inscrire" class="btn btn-primary text-center" OnClick="BtnSignup_Click"/>
        </div>
        <hr class="hr-text" data-content="OU"/><p style="text-align:center;margin-top:-30px;">OU</p>
        
        <div class="text-center">
            <span  class="spanSignIn">
                <svg xmlns="http://www.w3.org/2000/svg" width="22" height="24" viewBox="0 0 22 24" fill="none"><path fill-rule="evenodd" clip-rule="evenodd" d="M12.1354 5.75C14.0004 5.75 15.4794 6.396 16.4204 7.33L19.0744 4.676C17.3544 3 14.9584 2 12.1354 2C8.1984 2 4.8554 4.148 3.1704 7.302L6.2004 9.7C7.0974 7.39 9.3304 5.75 12.1354 5.75Z" fill="#E94435"></path><path fill-rule="evenodd" clip-rule="evenodd" d="M5.7708 11.9896C5.7708 11.1806 5.9248 10.4106 6.2008 9.7006L3.1708 7.3016C2.4238 8.7006 1.9998 10.2946 1.9998 11.9896C1.9998 13.7206 2.4098 15.3266 3.1358 16.7256L6.1958 14.3026C5.9248 13.5956 5.7708 12.8206 5.7708 11.9896Z" fill="#F8BB15"></path><path fill-rule="evenodd" clip-rule="evenodd" d="M15.8107 17.3084C14.8667 17.8694 13.6267 18.2294 12.0107 18.2294C9.3627 18.2294 7.1007 16.6654 6.1957 14.3034L3.1357 16.7254C4.7837 19.9024 8.0767 22.0004 12.0107 22.0004C14.7537 22.0004 17.0727 21.1524 18.7877 19.6654L15.8107 17.3084Z" fill="#34A751"></path><path fill-rule="evenodd" clip-rule="evenodd" d="M22 11.9896C22 11.3086 21.931 10.6436 21.801 9.9996H12V13.9996H18.062L18.018 14.2496C17.784 15.4466 17.068 16.5606 15.811 17.3086L18.788 19.6656C20.818 17.9056 22 15.2466 22 11.9896Z" fill="#547DBE"></path></svg>
            </span>
            <asp:Button ID="BtnGgl" runat="server" Text="S’identifier avec Google" class="btn btn-primary" OnClick="BtnGgl_Click"> </asp:Button>
        </div>   
    </div>
</asp:Content>
