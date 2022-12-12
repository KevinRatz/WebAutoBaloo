using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AutoBalooWeb.CoucheAccesDB
{
    public class BaseDB<T>
    {
        protected SqlCommand SqlCmd;
        /**
        * Constructeur
        * param sqlCmd : la commande SQL contenant la connexion à la base de données
        */
        public BaseDB(SqlCommand sqlCmd)
        {
            SqlCmd = sqlCmd;
        }
        /**
        * Méthodes dont le comportement doit être défini dans les sous-classes DAO
        */
        public virtual T Charger(int num)
        {
            return default(T);
        }
        public virtual bool Ajouter(T obj)
        {
            return false;
        }
        public virtual bool Modifier(T obj)
        {
            return false;
        }
        public virtual bool Supprimer(int num)
        {
            return false;
        }
        public virtual List<T> ListerTous()
        {
            return null;
        }
        public virtual List<T> ListerTousAvecOptions(int choix)
        {
            return null;
        }
        public virtual List<T> ListerPar(string txt, int id)
        {
            return null;
        }

    }
}