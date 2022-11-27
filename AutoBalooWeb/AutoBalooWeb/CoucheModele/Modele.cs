﻿using AutoBalooWeb.CoucheAccesDB;
using System;
using System.Collections.Generic;
using System.Linq;
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
         * méthode qui ajout dans la base de données une commande
         * retour : id cmd créé
         */
        public int AddCmdVM(string userid)
        {
            int id = fabDB.GetCommandeDB().Existe(userid);
            if (id == 0)
                if (fabDB.GetCommandeDB().Ajouter(new Commande(userid)))
                    return fabDB.GetCommandeDB().GetId();
                else
                    return -1;
            else
                return id;
        }
        /**
         * méthode qui add dans la base de données un client 
         * retour : /
         */
        public bool AddClientVM(Client c)
        {
            return fabDB.GetClientDB().Ajouter(c);
        }
        /**
         * méthode qui add dans la base de données le panier 
         * retour : /
         */
        public bool AddPanierVM(Produit p, int idcmd)
        {
            return fabDB.GetPanierDB().Ajouter(new Contenir(p, idcmd, 1));
        }
        /**
         * méthode qui liste dans la base de données tous les produits
         * retour : la liste de tous les produits
         */
        public List<Produit> ListProducts(string txt, int id)
        {
            return fabDB.GetProductDB().ListerPar(txt, id);
        }
        /**
         * méthode qui lit dans la base de données tous les catégories
         * retour : la liste de tous les catégories
         */
        public List<Categorie> ListCategories()
        {
            return fabDB.GetCategorieDB().ListerTous();
        }
        /**
         * méthode qui met à jour dans la base de données la qt dans le panier
         * param numEleve : le numéro de l'élève
         * retour : la liste des cours
         */
        public void UpQtPanierVM(string codebarre, int numCom, int diffqt)
        {
            fabDB.GetPanierDB().UpQtPanierDB(codebarre, numCom, diffqt);
        }
        /**
         * méthode qui liste dans la base de données le panier
         * param numcom : le num Com
         * retour : la liste du panier
         */
        public List<Contenir> ListerPanier(int numCom)
        {
            return fabDB.GetPanierDB().ListerPar(numCom);
        }
        /**
         * méthode qui lit dans la base de données tous les cours non suivis par un élève
         * param numEleve : le numéro de l'élève
         * retour : la liste des cours
         */
        public List<Commande> ListerCmd(string user)
        {
            return fabDB.GetCommandeDB().ListerCmdDB(user);
        }
        /**
         * méthode qui liste
         * param 
         * retour : la liste
         */
        public List<Produit> ListerProdCmd(string user, int idCmd)
        {
            return fabDB.GetProductDB().ListerPar(user, idCmd);
        }
        /**
         * méthode qui
         * param 
         */
        public void UpCmdVM(string add, DateTime date, int idCmd)
        {
            fabDB.GetCommandeDB().UpCmdDB(add, date, idCmd);
        }
    }
}