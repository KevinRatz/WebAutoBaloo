using AutoBalooWeb.CoucheAccesDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoBalooWeb.ClasseMetiers
{
    public class Vehicule
    {
        public Vehicule()
        {
            //test
            IdVoiture = 0;

            NumChassis = "";
            Nom = "";
            Marque = new Marque(1,"Sélectionner un véhicule");
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
            //Photo = photo;
            //DateArrive = dateArrive;
            //Etat = etat;
            //Transmission = transmission;
            //Carburant = carburant;
            //Carrosserie = carrosserie;
        }

        public Vehicule(int idVoiture, string numChassis, string nom, Marque marque, string puissance, int nbPortes, int nbVitesse, int cylindres, string couleur, decimal kilometrage, DateTime année, DateTime dateCtrlTech, string carnetEntretien, int typeTransaction, decimal prix, int reduction, string photo, DateTime dateArrive, Etat etat, Transmission transmission, Carburant carburant, Carrosserie carrosserie)
        {
            IdVoiture = idVoiture;
            NumChassis = numChassis;
            Nom = nom;
            Marque = marque;
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
            Photo = photo;
            DateArrive = dateArrive;
            Etat = etat;
            Transmission = transmission;
            Carburant = carburant;
            Carrosserie = carrosserie;
        }

        public Vehicule(Vehicule v)
        {
            IdVoiture = v.IdVoiture;
            NumChassis = v.NumChassis;
            Nom = v.Nom;
            Marque = v.Marque;
            Puissance = v.Puissance;
            NbPortes = v.NbPortes;
            NbVitesse = v.NbVitesse;
            Cylindres = v.Cylindres;
            Couleur = v.Couleur;
            Kilometrage = v.Kilometrage;
            Année = v.Année;
            DateCtrlTech = v.DateCtrlTech;
            CarnetEntretien = v.CarnetEntretien;
            TypeTransaction = v.TypeTransaction;
            Prix = v.Prix;
            Reduction = v.Reduction;
            Photo = v.Photo;
            DateArrive = v.DateArrive;
            Etat = v.Etat;
            Transmission = v.Transmission;
            Carburant = v.Carburant;
            Carrosserie = v.Carrosserie;
        }

        public Vehicule(string numChassis, string nom, Marque marque, string puissance, int nbPortes, int nbVitesse, int cylindres, string couleur, decimal kilometrage, DateTime année, DateTime dateCtrlTech, string carnetEntretien, int typeTransaction, decimal prix, int reduction, string photo, DateTime dateArrive, Etat etat, Transmission transmission, Carburant carburant, Carrosserie carrosserie)
        {
            NumChassis = numChassis;
            Nom = nom;
            Marque = marque;
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
            Photo = photo;
            DateArrive = dateArrive;
            Etat = etat;
            Transmission = transmission;
            Carburant = carburant;
            Carrosserie = carrosserie;
        }

        public override string ToString()
        {
            return (Marque.NomMarque + " " + Nom + ((IdVoiture == 0) ? "" : ":" + NumChassis));
        }

        public int IdVoiture { get; set; }
        public string NumChassis { get; set; }
        public string retString { get { return ToString(); } }
        public string Nom { get; set; }
        public Marque Marque { get; set; }
        public string Puissance { get; set; }
        public int NbPortes { get; set; }
        public int NbVitesse { get; set; }
        public int Cylindres { get; set; }
        public string Couleur { get; set; }
        public Decimal Kilometrage { get; set; }
        public DateTime Année { get; set; }
        public DateTime DateCtrlTech { get; set; }
        public string CarnetEntretien { get; set; }
        public int TypeTransaction { get; set; }
        public Decimal Prix { get; set; }
        public int Reduction { get; set; }
        public string Photo { get; set; }
        public DateTime DateArrive { get; set; }
        public Etat Etat { get; set; }
        public Transmission Transmission { get; set; }
        public Carburant Carburant { get; set; }
        public Carrosserie Carrosserie { get; set; }
    }
}