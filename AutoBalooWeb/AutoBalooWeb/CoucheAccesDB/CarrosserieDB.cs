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
         * méthode qui lit dans la base de données toutes les carrosseries
         * retour : List carrosseries
         */
        public override List<Carrosserie> ListerTous()
        {
            List<Carrosserie> liste = new List<Carrosserie>();
            try
            {
                SqlCmd.CommandText = "Select * from Carrosserie";
                SqlCmd.CommandType = CommandType.Text;
                SqlCmd.Parameters.Clear();
                liste.Add(new Carrosserie());
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