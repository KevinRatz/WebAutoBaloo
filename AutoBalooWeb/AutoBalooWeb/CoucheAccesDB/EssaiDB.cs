using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using AutoBalooWeb.ClasseMetiers;
using System.Data;

namespace AutoBalooWeb.CoucheAccesDB
{
    public class EssaiDB : BaseDB<Essai>
    {
        /**
         * Constructeur
         * param sqlCmd : la commande SQL contenant la connexion à la base de données
         */
        public EssaiDB(SqlCommand sqlCmd) : base(sqlCmd)
        {
        }

        /**
         * méthode qui lit dans la base de données un Essai spécifique
         * param num : le numéro du Essai
         * retour : Essai lu dans la base de données
         *
        public override Essai Charger(string codebarre)
        {
            Essai Essai = null;

            try
            {
                SqlCmd.CommandText = "GetEssai";
                SqlCmd.Parameters.Clear();
                SqlCmd.Parameters.Add("@codebarre", SqlDbType.VarChar).Value = codebarre;
                SqlDataReader sqlReader = SqlCmd.ExecuteReader();
                if (sqlReader.Read() == true)
                    Essai = new Essai(
                    Convert.ToString(sqlReader["CodeBarre"]),
                    Convert.ToString(sqlReader["Nom"]),
                    Convert.ToDecimal(sqlReader["Prix"]),
                    Convert.ToInt32(sqlReader["Quantite"]),
                    Convert.ToString(sqlReader["Couleur"]),
                    Convert.ToString(sqlReader["Taille"]),
                    Convert.ToInt32(sqlReader["Actif"]),
                    new Essai(Convert.ToString(sqlReader["NomCat"])),
                    new Genre(Convert.ToString(sqlReader["NomGenre"])));

                sqlReader.Close();
                return Essai;
            }
            catch (Exception e)
            {
                throw new ExceptionAccesDB(e.Message);
            }
        }
        /**
        * méthode qui ajoute dans la base de données un Essai
        * * param obj : le Essai
        * retour : un booléen indiquant si l'ajout a été réalisé ou non
        *
        public override bool Ajouter(Essai obj)
        {
            try
            {
                SqlCmd.CommandText = "AddProduct";
                SqlCmd.Parameters.Clear();
                SqlCmd.Parameters.Add("@Nom", SqlDbType.VarChar).Value = obj.Nom;
                SqlCmd.Parameters.Add("@Prenom", SqlDbType.VarChar).Value = obj.Prenom;
                SqlCmd.Parameters.Add("@email", SqlDbType.VarChar).Value = obj.Email;
                SqlCmd.Parameters.Add("@mdp", SqlDbType.VarChar).Value = obj.MotDePasse;
                SqlCmd.Parameters.Add("@adresse", SqlDbType.VarChar).Value = obj.Adresse;
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
        *
        public override bool Modifier(Essai obj)
        {
            try
            {
                SqlCmd.CommandText = "update Essai " +
                "set nom = @Nom, " +
               " prenom = @Prenom, " +
               " poids = @Poids, " +
               " annee = @Annee, " +
               " datenaissance = @DateNaissance, " +
               " nomimage = @NomImage " +
               "where numEssai = @NumEssai";
                SqlCmd.Parameters.Clear();
                SqlCmd.Parameters.Add("@NumEssai", SqlDbType.Int).Value = obj.NumEssai;
                SqlCmd.Parameters.Add("@Nom", SqlDbType.VarChar).Value = obj.Nom;
                SqlCmd.Parameters.Add("@Prenom", SqlDbType.VarChar).Value = obj.Prenom;
                SqlCmd.Parameters.Add("@Poids", SqlDbType.Int).Value = obj.Poids;
                SqlCmd.Parameters.Add("@Annee", SqlDbType.Int).Value = obj.Annee;
                SqlCmd.Parameters.Add("@DateNaissance", SqlDbType.Char).Value =
                obj.DateNaissance.ToString("dd-MM-yyyy");
                SqlCmd.Parameters.Add("@NomImage", SqlDbType.Char).Value = obj.NomImage;
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
        *
        public override bool Supprimer(int num)
        {
            try
            {
                SqlCmd.CommandText = "delete from Essai " +
                "where numEssai = @NumEssai";
                SqlCmd.Parameters.Clear();
                SqlCmd.Parameters.Add("@NumEssai", SqlDbType.Int).Value = num;
                return (SqlCmd.ExecuteNonQuery() == 0) ? false : true;
            }
            catch (Exception e)
            {
                throw new ExceptionAccesDB(e.Message);
            }
        }
        /**
        * méthode qui lit dans la base de données tous les Essais
        * retour : la liste de tous les Essais
        */
        public override List<Essai> ListerTous()
        {
            List<Essai> liste = new List<Essai>();
            try
            {
                SqlCmd.CommandText = "Select * from Essai";
                SqlCmd.CommandType = CommandType.Text;
                SqlDataReader sqlReader = SqlCmd.ExecuteReader();
                while (sqlReader.Read() == true)
                    liste.Add( new Essai(
                    Convert.ToDateTime(sqlReader["DateEssai"]),
                    Convert.ToInt32(sqlReader["IdVoiture"]),
                    Convert.ToInt32(sqlReader["IdClient"])));
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