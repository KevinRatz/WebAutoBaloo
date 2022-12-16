﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using AutoBalooWeb.ClasseMetiers;
using System.Data;

namespace AutoBalooWeb.CoucheAccesDB
{
    public class EtatResDB : BaseDB<EtatRes>
    {
        /**
         * Constructeur
         * param sqlCmd : la commande SQL contenant la connexion à la base de données
         */
        public EtatResDB(SqlCommand sqlCmd) : base(sqlCmd)
        {
        }

        /**
         * méthode qui lit dans la base de données un produit spécifique
         * param num : le numéro du produit
         * retour : produit lu dans la base de données
         */
        public override EtatRes Charger(int id)
        {
            EtatRes Produit = null;

            try
            {
                SqlCmd.CommandText = "Select * from EtatReservation where IdEtatRes = @id";
                SqlCmd.CommandType = CommandType.Text;
                SqlCmd.Parameters.Clear();
                SqlCmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataReader sqlReader = SqlCmd.ExecuteReader();
                if (sqlReader.Read() == true)
                    Produit = new EtatRes(
                    Convert.ToInt32(sqlReader["IdEtatRes"]),
                    Convert.ToString(sqlReader["Nom"]));

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
        public override List<EtatRes> ListerTous()
        {
            List<EtatRes> liste = new List<EtatRes>();
            try
            {
                SqlCmd.CommandText = "Select * from EtatReservation";
                SqlCmd.CommandType = CommandType.Text;
                SqlCmd.Parameters.Clear();
                SqlDataReader sqlReader = SqlCmd.ExecuteReader();
                while (sqlReader.Read() == true)
                    liste.Add(new EtatRes(
                    Convert.ToInt32(sqlReader["IdEtatRes"]),
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