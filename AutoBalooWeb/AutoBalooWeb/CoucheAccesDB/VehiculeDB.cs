using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using AutoBalooWeb.ClasseMetiers;
using System.Data;

namespace AutoBalooWeb.CoucheAccesDB
{
    public class VehiculeDB : BaseDB<Vehicule>
    {
        /**
         * Constructeur
         * param sqlCmd : la commande SQL contenant la connexion à la base de données
         */
        public VehiculeDB(SqlCommand sqlCmd) : base(sqlCmd)
        {
        }

        /**
         * méthode qui lit dans la base de données un Vehicule spécifique
         * param num : le numéro du Vehicule
         * retour : Vehicule lu dans la base de données
         */
        public override Vehicule Charger(int id)
        {
            Vehicule Vehicule = null;

            try
            {
                SqlCmd.CommandText = "GetVehicule";
                SqlCmd.Parameters.Clear();
                SqlCmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                //SqlDataReader sqlReader = SqlCmd.ExecuteReader();
                //if (sqlReader.Read() == true)
                //    Vehicule = new Vehicule(
                //    Convert.ToString(sqlReader["CodeBarre"]),
                //    Convert.ToString(sqlReader["Nom"]),
                //    Convert.ToDecimal(sqlReader["Prix"]),
                //    Convert.ToInt32(sqlReader["Quantite"]),
                //    Convert.ToString(sqlReader["Couleur"]),
                //    Convert.ToString(sqlReader["Taille"]),
                //    Convert.ToInt32(sqlReader["Actif"]),
                //    new Categorie(Convert.ToString(sqlReader["NomCat"])),
                //    new Genre(Convert.ToString(sqlReader["NomGenre"])));

                //sqlReader.Close();
                return Vehicule;
            }
            catch (Exception e)
            {
                throw new ExceptionAccesDB(e.Message);
            }
        }
        /**
        * méthode qui ajoute dans la base de données un Vehicule
        * * param obj : le Vehicule
        * retour : un booléen indiquant si l'ajout a été réalisé ou non
        */
        public override bool Ajouter(Vehicule obj)
        {
            try
            {
                SqlCmd.CommandText = "AddVehicule";
                SqlCmd.Parameters.Clear();
                //SqlCmd.Parameters.Add("@Nom", SqlDbType.VarChar).Value = obj.Nom;
                //SqlCmd.Parameters.Add("@Prenom", SqlDbType.VarChar).Value = obj.Prenom;
                //SqlCmd.Parameters.Add("@email", SqlDbType.VarChar).Value = obj.Email;
                //SqlCmd.Parameters.Add("@mdp", SqlDbType.VarChar).Value = obj.MotDePasse;
                //SqlCmd.Parameters.Add("@adresse", SqlDbType.VarChar).Value = obj.Adresse;
                return (SqlCmd.ExecuteNonQuery() == 0) ? false : true;
            }
            catch (Exception e)
            {
                throw new ExceptionAccesDB(e.Message);
            }
        }
        /**
        * méthode qui modifie dans la base de données un élève
        * param obj : l'élève
        * retour : un booléen indiquant si la modification a été réalisée ou non
        */
        public override bool Modifier(Vehicule obj)
        {
            try
            {
                SqlCmd.CommandText = "update Vehicule " +
                "set nom = @Nom, " +
               " prenom = @Prenom, " +
               " poids = @Poids, " +
               " annee = @Annee, " +
               " datenaissance = @DateNaissance, " +
               " nomimage = @NomImage " +
               "where numVehicule = @NumVehicule";
                //SqlCmd.Parameters.Clear();
                //SqlCmd.Parameters.Add("@NumVehicule", SqlDbType.Int).Value = obj.NumVehicule;
                //SqlCmd.Parameters.Add("@Nom", SqlDbType.VarChar).Value = obj.Nom;
                //SqlCmd.Parameters.Add("@Prenom", SqlDbType.VarChar).Value = obj.Prenom;
                //SqlCmd.Parameters.Add("@Poids", SqlDbType.Int).Value = obj.Poids;
                //SqlCmd.Parameters.Add("@Annee", SqlDbType.Int).Value = obj.Annee;
                //SqlCmd.Parameters.Add("@DateNaissance", SqlDbType.Char).Value =
                //obj.DateNaissance.ToString("dd-MM-yyyy");
                //SqlCmd.Parameters.Add("@NomImage", SqlDbType.Char).Value = obj.NomImage;
                return (SqlCmd.ExecuteNonQuery() == 0) ? false : true;
            }
            catch (Exception e)
            {
                throw new ExceptionAccesDB(e.Message);
            }
        }
        /**
        * méthode qui supprime dans la base de données un élève
        * param num : le numéro de l'élève
        * retour : un booléen indiquant si la suppression a été réalisée ou non
        */
        public override bool Supprimer(int num)
        {
            try
            {
                SqlCmd.CommandText = "delete from Vehicule " +
                "where numVehicule = @NumVehicule";
                SqlCmd.Parameters.Clear();
                SqlCmd.Parameters.Add("@NumVehicule", SqlDbType.Int).Value = num;
                return (SqlCmd.ExecuteNonQuery() == 0) ? false : true;
            }
            catch (Exception e)
            {
                throw new ExceptionAccesDB(e.Message);
            }
        }
        /**
        * méthode qui lit dans la base de données tous les élèves
        * retour : la liste de tous les élèves
        */
        public override List<Vehicule> ListerTous()
        {
            List<Vehicule> liste = new List<Vehicule>();
            try
            {
                SqlCmd.CommandText = 
                    "Select IdVoiture, NumChassis, Voiture.Nom as NomVoit,Puissance,NbPortes,NbVitesse,Cylindres," +
                    "Couleur,Kilometrage,Annee,DateCtrlTech,CarnetEntretien,TypeTransaction,Prix,Reduction,Photo,DateArrive," +
                    //FOREIGN KEY
                    "Etat as IdEtat,Etat.Nom As NomEtat," +
                    "Transmission As IdTransm,Transmission.Nom As NomTransm," +
                    "Carburant As IdCarbu,Carburant.Nom As NomCarbu," +
                    "Carrosserie As IdCarro,Carrosserie.Nom As NomCarro," +
                    "Marque As IdMarque,Marque.Nom As NomMarque " +
                    //TABLE ET JOIN
                    "from Voiture " +
                    "join Etat on Etat = Etat.IdEtat " +
                    "Join Transmission on Transmission = Transmission.IdTransmission " +
                    "Join Carburant on Carburant = Carburant.IdCarburant " +
                    "Join Carrosserie on Carrosserie = Carrosserie.IdCarrosserie " +
                    "Join Marque on Marque = Marque.IdMarque ;";

                //                --where Reduction != 0 order by reduction,DateArrive-- Acceuil Promo
                //                --where TypeTransaction = 0-- Vente
                //                --where TypeTransaction = 1-- location


                SqlCmd.CommandType = CommandType.Text;
                //SqlCmd.Parameters.Clear();

                SqlCmd.ExecuteNonQuery();

                SqlDataReader sqlReader = SqlCmd.ExecuteReader();


                while (sqlReader.Read() == true)
                    liste.Add(new Vehicule(
                        Convert.ToInt32(sqlReader["IdVoiture"]),
                        Convert.ToString(sqlReader["NumChassis"]),
                        Convert.ToString(sqlReader["NomVoit"]),
                        new Marque(Convert.ToInt32(sqlReader["IdMarque"]), Convert.ToString(sqlReader["NomMarque"])),
                        Convert.ToString(sqlReader["Puissance"]),
                        Convert.ToInt32(sqlReader["Nbportes"]),
                        Convert.ToInt32(sqlReader["NbVitesse"]),
                        Convert.ToInt32(sqlReader["Cylindres"]),
                        Convert.ToString(sqlReader["Couleur"]),
                        Convert.ToDecimal(sqlReader["Kilometrage"]),
                        DateTime.Parse(Convert.ToString(sqlReader["Annee"])),
                        DateTime.Parse(Convert.ToString(sqlReader["DateCtrlTech"])),
                        Convert.ToString(sqlReader["CarnetEntretien"]),
                        Convert.ToInt32(sqlReader["TypeTransaction"]),
                        Convert.ToDecimal(sqlReader["Prix"]),
                        Convert.ToInt32(sqlReader["Reduction"]),
                        Convert.ToString(sqlReader["Photo"]),
                        DateTime.Parse(Convert.ToString(sqlReader["DateArrive"])),
                        new Etat(Convert.ToInt32(sqlReader["IdEtat"]), Convert.ToString(sqlReader["NomEtat"])),
                        new Transmission(Convert.ToInt32(sqlReader["IdTransm"]), Convert.ToString(sqlReader["NomTransm"])),
                        new Carburant(Convert.ToInt32(sqlReader["IdCarbu"]), Convert.ToString(sqlReader["NomCarbu"])),
                        new Carrosserie(Convert.ToInt32(sqlReader["IdCarro"]), Convert.ToString(sqlReader["NomCarro"]))

                        ));


                sqlReader.Close();
            }
            catch (Exception e)
            {
                throw new ExceptionAccesDB(e.Message);
            }

            return liste;
        }

        //Une fonction qui renvoie la liste des voitures selon certains critères

        public override List<Vehicule> ListerTousAvecOptions(int choix)
        {
            //Si choix = 1 : Page Acceuil -> Liste des voiture triée sur la hauteur de la réduction et la date d'arrivée
            //Si choix = 2 : Page Vente -> voiture en vente uniquement
            //Si choix = 3 : Page Location -> voiture en location uniquement


            List<Vehicule> liste = new List<Vehicule>();
            try
            {
                SqlCmd.CommandText =
                    "Select IdVoiture, NumChassis, Voiture.Nom as NomVoit,Puissance,NbPortes,NbVitesse,Cylindres," +
                    "Couleur,Kilometrage,Annee,DateCtrlTech,CarnetEntretien,TypeTransaction,Prix,Reduction,Photo,DateArrive," +
                    //FOREIGN KEY
                    "Etat as IdEtat,Etat.Nom As NomEtat," +
                    "Transmission As IdTransm,Transmission.Nom As NomTransm," +
                    "Carburant As IdCarbu,Carburant.Nom As NomCarbu," +
                    "Carrosserie As IdCarro,Carrosserie.Nom As NomCarro," +
                    "Marque As IdMarque,Marque.Nom As NomMarque " +
                    //TABLE ET JOIN
                    "from Voiture " +
                    "join Etat on Etat = Etat.IdEtat " +
                    "Join Transmission on Transmission = Transmission.IdTransmission " +
                    "Join Carburant on Carburant = Carburant.IdCarburant " +
                    "Join Carrosserie on Carrosserie = Carrosserie.IdCarrosserie " +
                    "Join Marque on Marque = Marque.IdMarque ";

                //Grâce à choix on sélectionne les options que l'on souhaite ajouter à la commande de récupération de la liste
                if (choix == 1) { SqlCmd.CommandText = SqlCmd.CommandText + " order by reduction Desc,DateArrive Desc ;"; }
                if (choix == 2) { SqlCmd.CommandText = SqlCmd.CommandText + " where TypeTransaction = 0"; }
                if (choix == 3) { SqlCmd.CommandText = SqlCmd.CommandText + " where TypeTransaction = 1"; }

                SqlCmd.CommandType = CommandType.Text;
                SqlCmd.ExecuteNonQuery();
                SqlDataReader sqlReader = SqlCmd.ExecuteReader();

                //On récupère les données dans une liste
                while (sqlReader.Read() == true)
                    liste.Add(new Vehicule(
                        Convert.ToInt32(sqlReader["IdVoiture"]),
                        Convert.ToString(sqlReader["NumChassis"]),
                        Convert.ToString(sqlReader["NomVoit"]),
                        new Marque(Convert.ToInt32(sqlReader["IdMarque"]), Convert.ToString(sqlReader["NomMarque"])),
                        Convert.ToString(sqlReader["Puissance"]),
                        Convert.ToInt32(sqlReader["Nbportes"]),
                        Convert.ToInt32(sqlReader["NbVitesse"]),
                        Convert.ToInt32(sqlReader["Cylindres"]),
                        Convert.ToString(sqlReader["Couleur"]),
                        Convert.ToDecimal(sqlReader["Kilometrage"]),
                        DateTime.Parse(Convert.ToString(sqlReader["Annee"])),
                        DateTime.Parse(Convert.ToString(sqlReader["DateCtrlTech"])),
                        Convert.ToString(sqlReader["CarnetEntretien"]),
                        Convert.ToInt32(sqlReader["TypeTransaction"]),
                        Convert.ToDecimal(sqlReader["Prix"]),
                        Convert.ToInt32(sqlReader["Reduction"]),
                        Convert.ToString(sqlReader["Photo"]),
                        DateTime.Parse(Convert.ToString(sqlReader["DateArrive"])),
                        new Etat(Convert.ToInt32(sqlReader["IdEtat"]), Convert.ToString(sqlReader["NomEtat"])),
                        new Transmission(Convert.ToInt32(sqlReader["IdTransm"]), Convert.ToString(sqlReader["NomTransm"])),
                        new Carburant(Convert.ToInt32(sqlReader["IdCarbu"]), Convert.ToString(sqlReader["NomCarbu"])),
                        new Carrosserie(Convert.ToInt32(sqlReader["IdCarro"]), Convert.ToString(sqlReader["NomCarro"]))

                        ));


                sqlReader.Close();
            }
            catch (Exception e)
            {
                throw new ExceptionAccesDB(e.Message);
            }

            return liste;
        }


    }
}