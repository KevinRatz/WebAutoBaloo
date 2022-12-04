<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/NavBar.Master" AutoEventWireup="true" CodeBehind="DelCars.aspx.cs" Inherits="AutoBalooWeb.WebForms.DelCars" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHContenu" runat="server">
    <asp:GridView AutoGenerateColumns="False" ID="GridView1" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Height="208px" Width="589px" OnRowDataBound="GridView1_RowDataBound">
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
        <RowStyle BackColor="White" ForeColor="#003399" />
        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        <SortedAscendingCellStyle BackColor="#EDF6F6" />
        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
        <SortedDescendingCellStyle BackColor="#D6DFDF" />
        <SortedDescendingHeaderStyle BackColor="#002876" />
        <Columns>
            <asp:BoundField DataField="CodeBarre" HeaderText="Reference produit"/>
            <asp:BoundField DataField="Nom" HeaderText="Nom"/>
            <asp:BoundField DataField="PrixUnit" HeaderText="PrixUnit"/>
            <asp:BoundField DataField="Quantite" HeaderText="Quantite"/>
            <asp:BoundField DataField="Couleur" HeaderText="Couleur"/>
            <asp:BoundField DataField="Taille" HeaderText="Taille"/>
            <asp:BoundField DataField="Categorie" HeaderText="Categorie"/>
            <asp:BoundField DataField="Genre" HeaderText="Genre"/>
            <asp:BoundField DataField="Actif" HeaderText="Actif"/>
            <asp:TemplateField>
            <ItemTemplate>
                <asp:Button Text="Ajouter au panier" runat="server" ID="btn" OnClick="Panier_Click" />        
            </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
