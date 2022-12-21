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
         * méthode qui add dans la base de données un client 
         * retour : /
         */
        public Vehicule GetVehiculeByVM(string v)
        {
            return fabDB.GetVehiculeDB().ChargerBy(v);
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
            if (v.NumChassis != null && Regex.IsMatch(v.NumChassis, "^[0-9]{1,}$") && v.Nom != null && v.Nom.Length < 50 && 
                v.Puissance != null && v.Puissance.Length < 50 && v.NbPortes != 0 && v.Cylindres != 0 && 
                v.Couleur != null && v.Couleur.Length < 50 && v.Kilometrage != 0 && v.Année != null && v.CarnetEntretien != null && (v.TypeTransaction == 0|| v.TypeTransaction == 1) &&
               v.Prix != 0 && v.Reduction >= 0 && v.DateArrive != null)
                return true;
            return false;
        }

        /**
         * méthode qui add dans la base de données un vehicule 
         * retour : /
         */
        public bool UpEtatResVM(int idEtat, int id)
        {
            return fabDB.GetVehiculeDB().UpEtatResDB(idEtat,id);
        }

        /**
         * méthode qui add dans la base de données un vehicule 
         * retour : /
         */
        public bool DelVehiculeVM(int id)
        {
            return fabDB.GetVehiculeDB().Supprimer(id);
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
            if (!IsValide(v))
                return false;
            else
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
        public List<EtatRes> ListEtatRersVM()
        {
            return fabDB.GetEtatResDB().ListerTous();
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
         */
        public List<Vehicule> ListerVehiculeRes()
        {
            return fabDB.GetVehiculeDB().ListerTousAvecOptions(4);
        }
        /**
         * méthode qui liste dans la base de données le panier
         * param numcom : le num Com
         * retour : la liste du panier
         */
        public List<Location> ListLocationsByVehiculeVM( int idV)
        {
            return fabDB.GetLocationDB().ListerBy(idV);
        }
        /**
         * méthode qui lit dans la base de données tous les cours non suivis par un élève
         * param numEleve : le numéro de l'élève
         * retour : la liste des cours
         */
        public Reservation GetVehiculeRes(int user)
        {
            return fabDB.GetReservationDB().Charger(user);
        }
        /**
         * méthode qui liste
         * param 
         * retour : la liste
         */
        public EtatRes GetEtatRes(int idCmd)
        {
            return fabDB.GetEtatResDB().Charger(idCmd);
        }
        /**
         * méthode qui add dans la base de données un vehicule 
         * retour : /
         */
        public bool AddResVM(Reservation res)
        {
            return fabDB.GetReservationDB().Ajouter(res);
        }
        /**
         * méthode qui add dans la base de données un vehicule 
         * retour : /
         */
        public bool AddLocationVM(Location l)
        {
            return fabDB.GetLocationDB().Ajouter(l);
        }
        /**
         * méthode qui add dans la base de données un vehicule 
         * retour : /
         */
        public bool AddEssaiVM(Essai e)
        {
            return fabDB.GetEssaiDB().Ajouter(e);
        }
    }
}