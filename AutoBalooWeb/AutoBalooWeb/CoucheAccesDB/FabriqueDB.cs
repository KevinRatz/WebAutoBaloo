using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace AutoBalooWeb.CoucheAccesDB
{
    public class FabriqueDB
    {
        private SqlCommand SqlCmd;
        public FabriqueDB()
        {
            /**
            * Constructeur : il crée la connexion initiale avec la base de données
            */
            try
            {
                SqlCmd = new SqlCommand();
                SqlCmd.Connection = new SqlConnection("Data Source=" + Environment.MachineName + "\\SQLEXPRESS;Initial Catalog=AutoBaloo;Integrated Security=True");
                SqlCmd.Connection.Open();
            }
            catch (Exception e)
            {
                throw new ExceptionAccesDB(e.Message);
            }
        }
        /**
        * méthode qui fournit une instance de ProductDB
        * retour : l'instance de ProductDB
        */
        public VehiculeDB GetVehiculeDB()
        {
            return new VehiculeDB(SqlCmd);
        }
        /**
        * méthode qui fournit une instance de ClientDB
        * retour : l'instance de ClientDB
        */
        public ClientDB GetClientDB()
        {
            return new ClientDB(SqlCmd);
        }
        /**
        * méthode qui fournit une instance de EssaiDB
        * retour : l'instance de EssaiDB
        */
        public EssaiDB GetEssaiDB()
        {
            return new EssaiDB(SqlCmd);
        }
        /**
        * méthode qui fournit une instance de ReservationDB
        * retour : l'instance de ReservationDB
        */
        public ReservationDB GetReservationDB()
        {
            return new ReservationDB(SqlCmd);
        }
        /**
        * méthode qui fournit une instance de LocationDB
        * retour : l'instance de LocationDB
        */
        public LocationDB GetLocationDB()
        {
            return new LocationDB(SqlCmd);
        }

        /**
        * méthode qui débute explicitement une transaction
        */
        public void DebutTransaction()
        {
            SqlCmd.Transaction = SqlCmd.Connection.BeginTransaction();
        }
        /**
        * méthode qui valider la transaction courante
        */
        public void ValiderTransaction()
        {
            SqlCmd.Transaction.Commit();
        }
        /**
        * méthode qui annule la transaction courante
        */
        public void AnnulerTransaction()
        {
            SqlCmd.Transaction.Rollback();
        }
    }
}