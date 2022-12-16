using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using AutoBalooWeb.ClasseMetiers;
using System.Data;

namespace AutoBalooWeb.CoucheAccesDB
{
    public class ReservationDB : BaseDB<Reservation>
    {
        /**
         * Constructeur
         * param sqlCmd : la commande SQL contenant la connexion à la base de données
         */
        public ReservationDB(SqlCommand sqlCmd) : base(sqlCmd)
        {
        }

        /**
         * méthode qui lit dans la base de données un Reservation spécifique
         * param num : le numéro du Reservation
         * retour : Reservation lu dans la base de données
         */
        public override Reservation Charger(int id)
        {
            Reservation Reservation = null;

            try
            {
                SqlCmd.CommandText = "GetRes";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Clear();
                SqlCmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataReader sqlReader = SqlCmd.ExecuteReader();
                if (sqlReader.Read() == true)
                    Reservation = new Reservation(
                    Convert.ToDateTime(sqlReader["DateRes"]),
                    Convert.ToInt32(sqlReader["IdVoiture"]),
                    Convert.ToInt32(sqlReader["IdClient"]),
                    Convert.ToInt32(sqlReader["EtatRes"]));
                sqlReader.Close();
                return Reservation;
            }
            catch (Exception e)
            {
                throw new ExceptionAccesDB(e.Message);
            }
        }
        /**
        * méthode qui ajoute dans la base de données un Reservation
        * * param obj : le Reservation
        * retour : un booléen indiquant si l'ajout a été réalisé ou non
        */
        public override bool Ajouter(Reservation obj)
        {
            try
            {
                SqlCmd.CommandText = "AddReservation";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Clear();
                SqlCmd.Parameters.Add("@date", SqlDbType.Date).Value = obj.Date;
                SqlCmd.Parameters.Add("@idV", SqlDbType.Int).Value = obj.Voiture;
                SqlCmd.Parameters.Add("@idC", SqlDbType.Int).Value = obj.Client;
                SqlCmd.Parameters.Add("@etatR", SqlDbType.Int).Value = obj.EtatRes;
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
        public override bool Modifier(Reservation obj)
        {
            try
            {
                SqlCmd.CommandText = "update Reservation " +
                "set nom = @Nom, " +
               " prenom = @Prenom, " +
               " poids = @Poids, " +
               " annee = @Annee, " +
               " datenaissance = @DateNaissance, " +
               " nomimage = @NomImage " +
               "where numReservation = @NumReservation";
                SqlCmd.Parameters.Clear();
                SqlCmd.Parameters.Add("@NumReservation", SqlDbType.Int).Value = obj.NumReservation;
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
                SqlCmd.CommandText = "delete from Reservation " +
                "where numReservation = @NumReservation";
                SqlCmd.Parameters.Clear();
                SqlCmd.Parameters.Add("@NumReservation", SqlDbType.Int).Value = num;
                return (SqlCmd.ExecuteNonQuery() == 0) ? false : true;
            }
            catch (Exception e)
            {
                throw new ExceptionAccesDB(e.Message);
            }
        }
        /**
        * méthode qui lit dans la base de données tous les reservations
        * retour : la liste de tous les reservations
        */
        public override List<Reservation> ListerTous()
        {
            List<Reservation> liste = new List<Reservation>();
            try
            {
                SqlCmd.CommandText = "Select * from Reservation";
                SqlCmd.CommandType = CommandType.Text;
                SqlDataReader sqlReader = SqlCmd.ExecuteReader();
                while (sqlReader.Read() == true)
                    liste.Add(new Reservation(
                    Convert.ToDateTime(sqlReader["DateRes"]),
                    Convert.ToInt32(sqlReader["IdVoiture"]),
                    Convert.ToInt32(sqlReader["IdClient"]),
                    Convert.ToInt32(sqlReader["EtatRes"])
                    ));
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