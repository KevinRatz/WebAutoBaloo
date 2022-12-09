<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/NavBar.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="AutoBalooWeb.WebForms.SignIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHContenu" runat="server">
    <div class="h-100 d-flex align-items-center justify-content-center">
        <asp:Login 
            ID="Login1"
            DestinationPageUrl="~/WebForms/MainPage.aspx"
            UserNameLabelText="Adresse Email:"
            runat="server" class="text-center"
            BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="14px" ForeColor="#333333" Height="199px" style="margin-top: 120px" Width="500px" 
            OnLoggingIn="OnLoggingIn"
            OnLoginError="OnLoginError"
            OnAuthenticate= "ValidateUser">
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
            <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="12px" ForeColor="#284775" />
            <TextBoxStyle Font-Size="12px" />
            <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="18px" ForeColor="White" />
        </asp:Login>
    </div>
</asp:Content>
