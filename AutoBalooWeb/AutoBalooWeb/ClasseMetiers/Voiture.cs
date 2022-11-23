using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoBalooWeb.ClasseMetiers
{
    public class Voiture
    {
        public Voiture()
        {
            //test
            //NumChassis = numChassis;
            //Nom = nom;
            //Puissance = puissance;
            //NbPortes = nbPortes;
            //NbVitesse = nbVitesse;
            //Cylindres = cylindres;
            //Couleur = couleur;
            //Kilometrage = kilometrage;
            //Année = année;
            //DateCtrlTech = dateCtrlTech;
            //CarnetEntretien = carnetEntretien;
            //TypeTransaction = typeTransaction;
            //Prix = prix;
            //Reduction = reduction;
            //Etat = etat;
            //Transmission = transmission;
            //Carburant = carburant;
            //Carrosserie = carrosserie;
        }
        public Voiture(string numChassis, string nom, string puissance, int nbPortes, int nbVitesse, int cylindres, string couleur, int kilometrage, DateTime année, DateTime dateCtrlTech, string carnetEntretien, int typeTransaction, int prix, int reduction, string etat, string transmission, string carburant, string carrosserie)
        {
            NumChassis = numChassis;
            Nom = nom;
            Puissance = puissance;
            NbPortes = nbPortes;
            NbVitesse = nbVitesse;
            Cylindres = cylindres;
            Couleur = couleur;
            Kilometrage = kilometrage;
            Année = année;
            DateCtrlTech = dateCtrlTech;
            CarnetEntretien = carnetEntretien;
            TypeTransaction = typeTransaction;
            Prix = prix;
            Reduction = reduction;
            Etat = etat;
            Transmission = transmission;
            Carburant = carburant;
            Carrosserie = carrosserie;
        }
        
        public int IdVoiture { get; set; }
        public string NumChassis { get; set; }
        public string Nom { get; set; }
        public string Puissance { get; set; }
        public int NbPortes { get; set; }
        public int NbVitesse { get; set; }
        public int Cylindres { get; set; }
        public string Couleur { get; set; }
        public int Kilometrage { get; set; }
        public DateTime Année { get; set; }
        public DateTime DateCtrlTech { get; set; }
        public string CarnetEntretien { get; set; }
        public int TypeTransaction { get; set; }
        public int Prix { get; set; }
        public int Reduction { get; set; }
        public string Etat { get; set; }
        public string Transmission { get; set; }
        public string Carburant { get; set; }
        public string Carrosserie { get; set; }
    }
}