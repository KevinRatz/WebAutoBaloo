using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using AutoBalooWeb.ClasseMetiers;
using System.Data;

namespace AutoBalooWeb.CoucheAccesDB
{
    public class MarqueDB : BaseDB<Marque>
    {
        /**
         * Constructeur
         * param sqlCmd : la commande SQL contenant la connexion à la base de données
         */
        public MarqueDB(SqlCommand sqlCmd) : base(sqlCmd)
        {
        }

        /**
         * méthode qui lit dans la base de données toutes les marques
         * retour : liste marque
         */
        public override List<Marque> ListerTous()
        {
            List<Marque> liste = new List<Marque>();
            try
            {
                SqlCmd.CommandText = "Select * from Marque";
                SqlCmd.CommandType = CommandType.Text;
                SqlCmd.Parameters.Clear();
                SqlDataReader sqlReader = SqlCmd.ExecuteReader();
                liste.Add(new Marque());
                while (sqlReader.Read() == true)
                    liste.Add(new Marque(
                    Convert.ToInt32(sqlReader["IdMarque"]),
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