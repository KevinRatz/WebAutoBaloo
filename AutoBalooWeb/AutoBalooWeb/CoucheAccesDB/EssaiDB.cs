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
         * méthode qui lit dans la base de données un Categorie spécifique
         * param num : le numéro du Categorie
         * retour : Categorie lu dans la base de données
         *
        public override Categorie Charger(string codebarre)
        {
            Categorie Categorie = null;

            try
            {
                SqlCmd.CommandText = "GetCategorie";
                SqlCmd.Parameters.Clear();
                SqlCmd.Parameters.Add("@codebarre", SqlDbType.VarChar).Value = codebarre;
                SqlDataReader sqlReader = SqlCmd.ExecuteReader();
                if (sqlReader.Read() == true)
                    Categorie = new Categorie(
                    Convert.ToString(sqlReader["CodeBarre"]),
                    Convert.ToString(sqlReader["Nom"]),
                    Convert.ToDecimal(sqlReader["Prix"]),
                    Convert.ToInt32(sqlReader["Quantite"]),
                    Convert.ToString(sqlReader["Couleur"]),
                    Convert.ToString(sqlReader["Taille"]),
                    Convert.ToInt32(sqlReader["Actif"]),
                    new Categorie(Convert.ToString(sqlReader["NomCat"])),
                    new Genre(Convert.ToString(sqlReader["NomGenre"])));

                sqlReader.Close();
                return Categorie;
            }
            catch (Exception e)
            {
                throw new ExceptionAccesDB(e.Message);
            }
        }
        /**
        * méthode qui ajoute dans la base de données un Categorie
        * * param obj : le Categorie
        * retour : un booléen indiquant si l'ajout a été réalisé ou non
        *
        public override bool Ajouter(Categorie obj)
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
        public override bool Modifier(Categorie obj)
        {
            try
            {
                SqlCmd.CommandText = "update Categorie " +
                "set nom = @Nom, " +
               " prenom = @Prenom, " +
               " poids = @Poids, " +
               " annee = @Annee, " +
               " datenaissance = @DateNaissance, " +
               " nomimage = @NomImage " +
               "where numCategorie = @NumCategorie";
                SqlCmd.Parameters.Clear();
                SqlCmd.Parameters.Add("@NumCategorie", SqlDbType.Int).Value = obj.NumCategorie;
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
                SqlCmd.CommandText = "delete from Categorie " +
                "where numCategorie = @NumCategorie";
                SqlCmd.Parameters.Clear();
                SqlCmd.Parameters.Add("@NumCategorie", SqlDbType.Int).Value = num;
                return (SqlCmd.ExecuteNonQuery() == 0) ? false : true;
            }
            catch (Exception e)
            {
                throw new ExceptionAccesDB(e.Message);
            }
        }
        /**
        * méthode qui lit dans la base de données tous les categories
        * retour : la liste de tous les categories
        */
        public override List<Categorie> ListerTous()
        {
            List<Categorie> liste = new List<Categorie>();
            try
            {
                SqlCmd.CommandText = "Select * from Categorie";
                SqlCmd.CommandType = CommandType.Text;
                SqlDataReader sqlReader = SqlCmd.ExecuteReader();
                while (sqlReader.Read() == true)
                    liste.Add( new Categorie(
                    Convert.ToInt32(sqlReader["IdCat"]),
                    Convert.ToString(sqlReader["Nom"])));
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