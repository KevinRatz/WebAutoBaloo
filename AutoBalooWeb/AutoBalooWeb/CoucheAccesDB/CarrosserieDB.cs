using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using AutoBalooWeb.ClasseMetiers;
using System.Data;

namespace AutoBalooWeb.CoucheAccesDB
{
    public class CarrosserieDB : BaseDB<Carrosserie>
    {
        /**
         * Constructeur
         * param sqlCmd : la commande SQL contenant la connexion à la base de données
         */
        public CarrosserieDB(SqlCommand sqlCmd) : base(sqlCmd)
        {
        }

        /**
         * méthode qui lit dans la base de données un produit spécifique
         * param num : le numéro du produit
         * retour : produit lu dans la base de données
         *
        public override Produit Charger(string codebarre)
        {
            Produit Produit = null;

            try
            {
                SqlCmd.CommandText = "GetProduit";
                SqlCmd.Parameters.Clear();
                SqlCmd.Parameters.Add("@codebarre", SqlDbType.VarChar).Value = codebarre;
                SqlDataReader sqlReader = SqlCmd.ExecuteReader();
                if (sqlReader.Read() == true)
                    Produit = new Produit(
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
                return Produit;
            }
            catch (Exception e)
            {
                throw new ExceptionAccesDB(e.Message);
            }
        }

        /**
         * méthode qui lit dans la base de données un produit spécifique
         * param num : le numéro du produit
         * retour : produit lu dans la base de données
         */
        public override List<Carrosserie> ListerTous()
        {
            List<Carrosserie> liste = new List<Carrosserie>();
            try
            {
                SqlCmd.CommandText = "Select * from Carrosserie";
                SqlCmd.CommandType = CommandType.Text;
                SqlCmd.Parameters.Clear();
                SqlDataReader sqlReader = SqlCmd.ExecuteReader();
                while (sqlReader.Read() == true)
                    liste.Add(new Carrosserie(
                    Convert.ToInt32(sqlReader["IdCarrosserie"]),
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