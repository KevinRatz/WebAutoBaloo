using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using AutoBalooWeb.ClasseMetiers;
using System.Data;

namespace AutoBalooWeb.CoucheAccesDB
{
    public class LocationDB : BaseDB<Location>
    {
        /**
         * Constructeur
         * param sqlCmd : la commande SQL contenant la connexion à la base de données
         */
        public LocationDB(SqlCommand sqlCmd) : base(sqlCmd)
        {
        }
        
        /**
        * méthode qui ajoute dans la base de données une Location
        * * param obj : la Location
        * retour : un booléen indiquant si l'ajout a été réalisé ou non
        */
        public override bool Ajouter(Location obj)
        {
            try
            {
                SqlCmd.CommandText = "AddLocation";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Clear();
                SqlCmd.Parameters.Add("@dateD", SqlDbType.Date).Value = obj.Date;
                SqlCmd.Parameters.Add("@idV", SqlDbType.Int).Value = obj.Voiture;
                SqlCmd.Parameters.Add("@idC", SqlDbType.Int).Value = obj.Client;
                SqlCmd.Parameters.Add("@dateF", SqlDbType.Date).Value = obj.DateFin;
                return (SqlCmd.ExecuteNonQuery() <= 0) ? false : true;
            }
            catch (Exception e)
            {
                throw new ExceptionAccesDB(e.Message);
            }
        }
        /**
        * méthode qui lit dans la base de données tous les Locations
        * retour : la liste de tous les Locations
        */
        public override List<Location> ListerTous()
        {
            List<Location> liste = new List<Location>();
            try
            {
                SqlCmd.CommandText = "Select * from Location";
                SqlCmd.CommandType = CommandType.Text;
                SqlDataReader sqlReader = SqlCmd.ExecuteReader();
                while (sqlReader.Read() == true)
                    liste.Add( new Location(
                    Convert.ToDateTime(sqlReader["DateDebut"]),
                    Convert.ToInt32(sqlReader["IdVoiture"]),
                    Convert.ToInt32(sqlReader["IdClient"]),
                    Convert.ToDateTime(sqlReader["DateFin"])));
                sqlReader.Close();
            }
            catch (Exception e)
            {
                throw new ExceptionAccesDB(e.Message);
            }

            return liste;
        }
        /**
        * méthode qui lit dans la base de données tous les Locations
        * retour : la liste de tous les Locations
        */
        public List<Location> ListerBy(int idV)
        {
            List<Location> liste = new List<Location>();
            try
            {
                SqlCmd.CommandText = "Select * from Location where IdVoiture = @id";
                SqlCmd.CommandType = CommandType.Text;
                SqlCmd.Parameters.Clear();
                SqlCmd.Parameters.Add("@id", SqlDbType.Int).Value = idV;
                SqlDataReader sqlReader = SqlCmd.ExecuteReader();
                while (sqlReader.Read() == true)
                    liste.Add( new Location(
                    Convert.ToDateTime(sqlReader["DateDebut"]),
                    Convert.ToInt32(sqlReader["IdVoiture"]),
                    Convert.ToInt32(sqlReader["IdClient"]),
                    Convert.ToDateTime(sqlReader["DateFin"])));
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