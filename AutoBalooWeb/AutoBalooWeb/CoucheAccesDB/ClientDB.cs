using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using AutoBalooWeb.ClasseMetiers;
using System.Data;

namespace AutoBalooWeb.CoucheAccesDB
{
    public class ClientDB : BaseDB<Client>
    {
        /**
         * Constructeur
         * param sqlCmd : la commande SQL contenant la connexion à la base de données
         */
        public ClientDB(SqlCommand sqlCmd) : base(sqlCmd)
        {
        }

        /**
 * méthode qui lit dans la base de données un élève spécifique
 * param num : le numéro de l'élève
 * retour : l'élève lu dans la base de données
 *
        public override Client Charger(string email)
        {
            Client client = null;

            try
            {
                SqlCmd.CommandText = "GetClient";
                SqlCmd.Parameters.Clear();
                SqlCmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                SqlDataReader sqlReader = SqlCmd.ExecuteReader();
                if (sqlReader.Read() == true)
                    client = new Client(
                    Convert.ToString(sqlReader["nom"]),
                   Convert.ToString(sqlReader["prenom"]),
                   Convert.ToString(sqlReader["Email"]),
                   Convert.ToString(sqlReader["adresse"]));
                sqlReader.Close();
                return client;
            }
            catch (Exception e)
            {
                throw new ExceptionAccesDB(e.Message);
            }
        }
        /**
        * méthode qui ajoute dans la base de données un élève
        * * param obj : l'élève
        * retour : un booléen indiquant si l'ajout a été réalisé ou non
        */
        public override bool Ajouter(Client obj)
        {
            try
            {
                SqlCmd.CommandText = "AddClient";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Clear();
                SqlCmd.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.Nom;
                SqlCmd.Parameters.Add("@prenom", SqlDbType.VarChar).Value = obj.Prenom;
                SqlCmd.Parameters.Add("@adresse", SqlDbType.VarChar).Value = obj.Adresse;
                SqlCmd.Parameters.Add("@email", SqlDbType.VarChar).Value = obj.EMail;
                SqlCmd.Parameters.Add("@mdp", SqlDbType.VarChar).Value = obj.Password;
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
        public override bool Modifier(Client obj)
        {
            try
            {
                SqlCmd.CommandText = "update Client " +
                "set nom = @Nom, " +
               " prenom = @Prenom, " +
               " poids = @Poids, " +
               " annee = @Annee, " +
               " datenaissance = @DateNaissance, " +
               " nomimage = @NomImage " +
               "where numClient = @NumClient";
                SqlCmd.Parameters.Clear();
                SqlCmd.Parameters.Add("@NumClient", SqlDbType.Int).Value = obj.NumClient;
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
        */
        public string ValidateUserDB(string user, string mdp)
        {
            string userId ="invalid";

            try
            {
                SqlCmd.CommandText = "ValidateUser";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Clear();
                SqlCmd.Parameters.AddWithValue("@Email", user);
                SqlCmd.Parameters.AddWithValue("@Password", mdp);
                // Execute la commande
                SqlDataReader sqlreader = SqlCmd.ExecuteReader();
                if (sqlreader.Read())
                {
                    userId = Convert.ToString(sqlreader["EMail"]);
                }
                sqlreader.Close();
                return userId;
            }
            catch (Exception e)
            {
                throw new ExceptionAccesDB(e.Message);
            }
        }
    }
}