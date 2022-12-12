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
                SqlCmd.CommandText = "";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Clear();
                SqlDataReader sqlReader = SqlCmd.ExecuteReader();
                while (sqlReader.Read() == true)
                    //liste.Add( new Vehicule(
                    //Convert.ToInt32(sqlReader["IdVoiture"]),
                    //Convert.ToString(sqlReader["NumChassis"]),
                    //Convert.ToString(sqlReader["Nom"]),
                    //new Marque(Convert.ToInt32(sqlReader["IdMarque"]),Convert.ToString(sqlReader["NomMarque"])),
                    //Convert.ToInt32(sqlReader["Quantite"]),
                    //Convert.ToInt32(sqlReader["Quantite"]),
                    //Convert.ToInt32(sqlReader["Quantite"]),
                    //Convert.ToString(sqlReader["Couleur"]),
                    //Convert.ToDecimal(sqlReader["Kilometrage"]),
                    //Convert.ToDecimal(sqlReader["Prix"]),
                    //Convert.ToInt32(sqlReader["Quantite"]),
                    //Convert.ToString(sqlReader["Couleur"]),
                    //Convert.ToString(sqlReader["Taille"]),
                    //Convert.ToInt32(sqlReader["Actif"]),
                    //new Carburant(Convert.ToInt32(sqlReader["IdCarbu"]), Convert.ToString(sqlReader["NomCarbu"]))));
                    //new Carrosserie(Convert.ToInt32(sqlReader["IdCaro"]), Convert.ToString(sqlReader["NomCaros"]))));
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