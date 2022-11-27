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
        public VehiculeDB GetProductDB()
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
        * méthode qui fournit une instance de CategorieDB
        * retour : l'instance de CategorieDB
        */
        public EssaiDB GetCategorieDB()
        {
            return new EssaiDB(SqlCmd);
        }
        /**
        * méthode qui fournit une instance de CategorieDB
        * retour : l'instance de CategorieDB
        */
        public CommandeDB GetCommandeDB()
        {
            return new CommandeDB(SqlCmd);
        }
        /**
        * méthode qui fournit une instance de CategorieDB
        * retour : l'instance de CategorieDB
        */
        public PanierDB GetPanierDB()
        {
            return new PanierDB(SqlCmd);
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