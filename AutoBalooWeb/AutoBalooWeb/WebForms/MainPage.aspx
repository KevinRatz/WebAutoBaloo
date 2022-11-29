<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/NavBar.Master" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="AutoBalooWeb.WebForms.MainPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHContenu" runat="server">
    <div class="col-xs-12 text-md-left text-center">
        <div style="color: #FFFFFF; margin-left: 798px">
            <h1 class="form-signin-heading">AutoBaloo</h1> 
        </div>
            
        <br />
        Recherche :
            
        <%--<asp:DropDownList ID="DropDownList1" AutoPostBack="true" runat="server" Height="40px" style="margin-left: 24px" OnTextChanged="DropDownList1_TextChanged">
        </asp:DropDownList>--%>
        <br />
        <br />
    </div>
</asp:Content>
