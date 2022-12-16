using AutoBalooWeb.ClasseMetiers;
using AutoBalooWeb.CoucheModele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AutoBalooWeb.WebForms
{
    public partial class ChangeEtatCars : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.User.Identity.IsAuthenticated || ((Client)Session["Client"]).Admin == 0)
                Response.Redirect("MainPage.aspx");
            if (!Page.IsPostBack)
            {
                //désactivé la liste des états et le bouton Modifier
                DDListEtat.Enabled = false;
                btnUpEtatCars.Enabled = false;

                //Charger les listes
                DDListId.DataSource = ((Modele)Session["CoucheModele"]).ListerVehiculeRes();
                DDListId.DataBind();

                DDListEtat.DataSource = ((Modele)Session["CoucheModele"]).ListEtatRersVM();
                DDListEtat.DataBind();
            }
        }
        protected void DDListId_SelectedIndexChanged(object sender, EventArgs e)
        {
            //activé la liste des états et le bouton Modifier
            DDListEtat.Enabled = true;
            btnUpEtatCars.Enabled = true;
            //désactivé la liste des états et le bouton Modifier si la valeur est "sélectionner un véhicule"
            if (DDListId.SelectedIndex == 0)
            {
                DDListEtat.Enabled = false;
                btnUpEtatCars.Enabled = false;
            }
            else
            {
                Reservation res = null;
                res = ((Modele)Session["CoucheModele"]).GetVehiculeRes(DDListId.SelectedIndex);
                //avoir etat pour veh res
                EtatRes er = ((Modele)Session["CoucheModele"]).GetEtatRes(res.EtatRes);
                Session["EtatRes"] = er.NomEtatRes;
                //désactiver les états passés lors de la réservation
                foreach (ListItem item in DDListEtat.Items)
                {
                    if (item.ToString() != er.NomEtatRes)
                    {
                        item.Attributes.Add("disabled", "disabled");
                    }
                    else
                        break;
                }
                // mettre l'etat de la réservation dans la liste des états
                DDListEtat.SelectedValue = er.NomEtatRes;
            }
        }
        protected void DDListEtat_SelectedIndexChanged(object sender, EventArgs e)
        {
            //désactiver les états passés lors de la réservation
            foreach (ListItem item in DDListEtat.Items)
            {
                if (item.ToString() != Session["EtatRes"].ToString())
                {
                    item.Attributes.Add("disabled", "disabled");
                }
                else
                    break;
            }
        }

        protected void BtnUpEtatCars_Click(object sender, EventArgs e)
        {
            Literal lit = new Literal();
            Reservation res = null;

            res = ((Modele)Session["CoucheModele"]).GetVehiculeRes(DDListId.SelectedIndex);
            if (!((Modele)Session["CoucheModele"]).UpEtatResVM(DDListEtat.SelectedIndex+1, res.Voiture))
            {
                lit.Text = "L 'etat est le meme que avant";
                ct.Controls.Add(lit);
            }
            else
            {
                lit.Text = "Etat changé";
                ct.Controls.Add(lit);
                DDListEtat.Enabled = false;
                btnUpEtatCars.Enabled = false;
                DDListId.SelectedIndex = 0;
            }
        }
    }
}