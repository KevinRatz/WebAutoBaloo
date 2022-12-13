using AutoBalooWeb.ClasseMetiers;
using AutoBalooWeb.CoucheAccesDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace AutoBalooWeb.CoucheModele
{
    public class Modele
    {
        private FabriqueDB fabDB;
        public Modele()
        {
            fabDB = new FabriqueDB();
        }
        /**
         * méthode qui valide l'user dans la base de données et retourne id
         * retour : /
         */
        public string ValidateUserVM(string user, string mdp)
        {
            return fabDB.GetClientDB().ValidateUserDB(user, mdp);
        }
        /**
         * méthode qui add dans la base de données un client 
         * retour : /
         */
        public bool AddClientVM(Client c, bool gmail)
        {
            if(!gmail)
                return fabDB.GetClientDB().Ajouter(c);
            else    
                return fabDB.GetClientDB().AddGmailClient(c);
        }
        /**
         * méthode qui add dans la base de données un client 
         * retour : /
         */
        public Client GetClientVM(string c)
        {
            return fabDB.GetClientDB().GetClient(c);
        }
        /**
         * méthode qui add dans la base de données un client 
         * retour : /
         */
        public Vehicule GetVehiculeVM(int v)
        {
            return fabDB.GetVehiculeDB().Charger(v);
        }
        /**
         * méthode qui add dans la base de données un vehicule 
         * retour : /
         */
        public bool AddVehiculeVM(Vehicule v)
        {
            if (!IsValide(v))
                return false;
            else
                return fabDB.GetVehiculeDB().Ajouter(v);
        }

        private bool IsValide(Vehicule v)
        {
            if (v.NumChassis != null && Regex.IsMatch(v.NumChassis, "$[0-9]{1,}^") && v.Nom != null && v.Nom.Length < 50 && 
                v.Puissance != null && v.Puissance.Length < 50 && v.NbPortes != 0 && v.NbVitesse != 0 && v.Cylindres != 0 && 
                v.Couleur != null && v.Couleur.Length < 50 && v.Kilometrage != 0 && v.Année != null && v.CarnetEntretien != null && v.TypeTransaction != 0 &&
               v.Prix != 0 && v.Reduction != 0 && v.Photo != null && v.DateArrive != null)
                return true;
            return false;
        }

        /**
* méthode qui retourne la liste des véhicules 
* retour : La liste des véhicules
*/
        public List<Vehicule> ListVehiculeVM()
        {
            return fabDB.GetVehiculeDB().ListerTous();
        }
        public List<Vehicule> ListVehiculeVMAvecOptions(int choix)
        {
            return fabDB.GetVehiculeDB().ListerTousAvecOptions(choix);
        }


        /**
         * méthode qui liste dans la base de données tous les produits
         * retour : la liste de tous les produits
         */
        public bool UpVehiculeVM(Vehicule v)
        {
            return fabDB.GetVehiculeDB().Modifier(v);
        }
        /**
         * méthode qui lit dans la base de données tous les catégories
         * retour : la liste de tous les catégories
         */
        public List<Etat> ListEtats()
        {
            return fabDB.GetEtatDB().ListerTous();
        }
        /**
         * méthode qui lit dans la base de données tous les catégories
         * retour : la liste de tous les catégories
         */
        public List<Marque> ListMarques()
        {
            return fabDB.GetMarqueDB().ListerTous();
        }
        /**
         * méthode qui lit dans la base de données tous les catégories
         * retour : la liste de tous les catégories
         */
        public List<Carrosserie> ListCarrosseries()
        {
            return fabDB.GetCarrosserieDB().ListerTous();
        }
        /**
         * méthode qui lit dans la base de données tous les catégories
         * retour : la liste de tous les catégories
         */
        public List<Carburant> ListCarburants()
        {
            return fabDB.GetCarburantDB().ListerTous();
        }
        /**
         * méthode qui liste dans la base de données le panier
         * param numcom : le num Com
         * retour : la liste du panier
         *
        public List<Contenir> ListerPanier(int numCom)
        {
            return fabDB.GetPanierDB().ListerPar(numCom);
        }
        /**
         * méthode qui lit dans la base de données tous les cours non suivis par un élève
         * param numEleve : le numéro de l'élève
         * retour : la liste des cours
         *
        public List<Commande> ListerCmd(string user)
        {
            return fabDB.GetCommandeDB().ListerCmdDB(user);
        }
        /**
         * méthode qui liste
         * param 
         * retour : la liste
         *
        public List<Produit> ListerProdCmd(string user, int idCmd)
        {
            return fabDB.GetProductDB().ListerPar(user, idCmd);
        }
        /**
         * méthode qui
         * param 
         *
        public void UpCmdVM(string add, DateTime date, int idCmd)
        {
            fabDB.GetCommandeDB().UpCmdDB(add, date, idCmd);
        }*/
    }
}