using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using AutoBalooWeb.ClasseMetiers;
using System.Data;

namespace AutoBalooWeb.CoucheAccesDB
{
    public class CarburantDB : BaseDB<Carburant>
    {
        /**
         * Constructeur
         * param sqlCmd : la commande SQL contenant la connexion à la base de données
         */
        public CarburantDB(SqlCommand sqlCmd) : base(sqlCmd)
        {
        }

        /**
         * méthode qui lit dans la base de données toutes les carbu
         * retour : List carbu
         */
        public override List<Carburant> ListerTous()
        {
            List<Carburant> liste = new List<Carburant>();
            try
            {
                SqlCmd.CommandText = "Select * from Carburant";
                SqlCmd.CommandType = CommandType.Text;
                SqlCmd.Parameters.Clear();
                SqlDataReader sqlReader = SqlCmd.ExecuteReader();
                liste.Add(new Carburant());
                while (sqlReader.Read() == true)
                    liste.Add(new Carburant(
                    Convert.ToInt32(sqlReader["IdCarburant"]),
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