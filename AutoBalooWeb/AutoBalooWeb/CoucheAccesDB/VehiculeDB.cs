using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using AutoBalooWeb.ClasseMetiers;
using System.Data;

namespace AutoBalooWeb.CoucheAccesDB
{
    public class VehiculeDB : BaseDB<Vehicule>
    {
        /**
         * Constructeur
         * param sqlCmd : la commande SQL contenant la connexion à la base de données
         */
        public VehiculeDB(SqlCommand sqlCmd) : base(sqlCmd)
        {
        }

        /**
         * méthode qui lit dans la base de données un Vehicule spécifique
         * param num : le numéro du Vehicule
         * retour : Vehicule lu dans la base de données
         */
        public override Vehicule Charger(int id)
        {
            Vehicule Vehicule = null;

            try
            {
                SqlCmd.CommandText = "GetVehicule";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Clear();
                SqlCmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataReader sqlReader = SqlCmd.ExecuteReader();


                while (sqlReader.Read() == true)
                    Vehicule = (new Vehicule(
                        Convert.ToInt32(sqlReader["IdVoiture"]),
                        Convert.ToString(sqlReader["NumChassis"]),
                        Convert.ToString(sqlReader["NomVoit"]),
                        new Marque(Convert.ToInt32(sqlReader["IdMarque"]), Convert.ToString(sqlReader["NomMarque"])),
                        Convert.ToString(sqlReader["Puissance"]),
                        Convert.ToInt32(sqlReader["Nbportes"]),
                        Convert.ToInt32(sqlReader["NbVitesse"]),
                        Convert.ToInt32(sqlReader["Cylindres"]),
                        Convert.ToString(sqlReader["Couleur"]),
                        Convert.ToDecimal(sqlReader["Kilometrage"]),
                        DateTime.Parse(Convert.ToString(sqlReader["Annee"])),
                        DateTime.Parse(Convert.ToString(sqlReader["DateCtrlTech"])),
                        Convert.ToString(sqlReader["CarnetEntretien"]),
                        Convert.ToInt32(sqlReader["TypeTransaction"]),
                        Convert.ToDecimal(sqlReader["Prix"]),
                        Convert.ToInt32(sqlReader["Reduction"]),
                        Convert.ToString(sqlReader["Photo"]),
                        DateTime.Parse(Convert.ToString(sqlReader["DateArrive"])),
                        new Etat(Convert.ToInt32(sqlReader["IdEtat"]), Convert.ToString(sqlReader["NomEtat"])),
                        new Transmission(Convert.ToInt32(sqlReader["IdTransm"]), Convert.ToString(sqlReader["NomTransm"])),
                        new Carburant(Convert.ToInt32(sqlReader["IdCarbu"]), Convert.ToString(sqlReader["NomCarbu"])),
                        new Carrosserie(Convert.ToInt32(sqlReader["IdCarro"]), Convert.ToString(sqlReader["NomCarro"]))

                        ));

                sqlReader.Close();
                return Vehicule;
            }
            catch (Exception e)
            {
                throw new ExceptionAccesDB(e.Message);
            }
        }
        /**
        * méthode qui ajoute dans la base de données un Vehicule
        * * param obj : le Vehicule
        * retour : un booléen indiquant si l'ajout a été réalisé ou non
        */
        public override bool Ajouter(Vehicule obj)
        {
            try
            {
                SqlCmd.CommandText = "AddVehicule";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Clear();
                SqlCmd.Parameters.Add("@num", SqlDbType.VarChar).Value = obj.NumChassis;
                SqlCmd.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.Nom;
                SqlCmd.Parameters.Add("@puissance", SqlDbType.VarChar).Value = obj.Puissance;
                SqlCmd.Parameters.Add("@nbPortes", SqlDbType.Int).Value = obj.NbPortes;
                SqlCmd.Parameters.Add("@nbVitesse", SqlDbType.Int).Value = obj.NbVitesse;
                SqlCmd.Parameters.Add("@cylindres", SqlDbType.Int).Value = obj.Cylindres;
                SqlCmd.Parameters.Add("@couleur", SqlDbType.VarChar).Value = obj.Couleur;
                SqlCmd.Parameters.Add("@kilometrage", SqlDbType.Decimal).Value = obj.Kilometrage;
                SqlCmd.Parameters.Add("@annee", SqlDbType.Date).Value = obj.Année;
                SqlCmd.Parameters.Add("@dateCtrlTech", SqlDbType.Date).Value = obj.DateCtrlTech;
                SqlCmd.Parameters.Add("@carnetEntretien", SqlDbType.VarChar).Value = obj.CarnetEntretien;
                SqlCmd.Parameters.Add("@typeTransaction", SqlDbType.Int).Value = obj.TypeTransaction;
                SqlCmd.Parameters.Add("@prix", SqlDbType.Decimal).Value = obj.Prix;
                SqlCmd.Parameters.Add("@reduction", SqlDbType.Int).Value = obj.Reduction;
                SqlCmd.Parameters.Add("@photo", SqlDbType.VarChar).Value = obj.Photo;
                SqlCmd.Parameters.Add("@dateArrive", SqlDbType.Date).Value = obj.DateArrive;
                SqlCmd.Parameters.Add("@etat", SqlDbType.Int).Value = obj.Etat.IdEtat;
                SqlCmd.Parameters.Add("@transmission", SqlDbType.Int).Value = obj.Transmission.IdTrans;
                SqlCmd.Parameters.Add("@carburant", SqlDbType.Int).Value = obj.Carburant.IdCarbu;
                SqlCmd.Parameters.Add("@carrosserie", SqlDbType.Int).Value = obj.Carrosserie.IdCaros;
                SqlCmd.Parameters.Add("@marque", SqlDbType.Int).Value = obj.Marque.IdMarque;
                return (SqlCmd.ExecuteNonQuery() <= 0) ? false : true;
            }
            catch (Exception e)
            {
                throw new ExceptionAccesDB(e.Message);
            }
        }
        /* méthode qui modifie dans la base de données un élève
        * param obj : l'élève
        * retour : un booléen indiquant si la modification a été réalisée ou non
        */
        public override bool Modifier(Vehicule obj)
        {
            try
            {
                SqlCmd.CommandText = "UpVehicule";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Clear();
                SqlCmd.Parameters.Add("@id", SqlDbType.Int).Value = obj.IdVoiture;
                SqlCmd.Parameters.Add("@num", SqlDbType.VarChar).Value = obj.NumChassis;
                SqlCmd.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.Nom;
                SqlCmd.Parameters.Add("@puissance", SqlDbType.VarChar).Value = obj.Puissance;
                SqlCmd.Parameters.Add("@nbPortes", SqlDbType.Int).Value = obj.NbPortes;
                SqlCmd.Parameters.Add("@nbVitesse", SqlDbType.Int).Value = obj.NbVitesse;
                SqlCmd.Parameters.Add("@cylindres", SqlDbType.Int).Value = obj.Cylindres;
                SqlCmd.Parameters.Add("@couleur", SqlDbType.VarChar).Value = obj.Couleur;
                SqlCmd.Parameters.Add("@kilometrage", SqlDbType.Decimal).Value = obj.Kilometrage;
                SqlCmd.Parameters.Add("@annee", SqlDbType.Date).Value = obj.Année;
                SqlCmd.Parameters.Add("@dateCtrlTech", SqlDbType.Date).Value = obj.DateCtrlTech;
                SqlCmd.Parameters.Add("@carnetEntretien", SqlDbType.VarChar).Value = obj.CarnetEntretien;
                SqlCmd.Parameters.Add("@typeTransaction", SqlDbType.Int).Value = obj.TypeTransaction;
                SqlCmd.Parameters.Add("@prix", SqlDbType.Decimal).Value = obj.Prix;
                SqlCmd.Parameters.Add("@reduction", SqlDbType.Int).Value = obj.Reduction;
                SqlCmd.Parameters.Add("@photo", SqlDbType.VarChar).Value = obj.Photo;
                SqlCmd.Parameters.Add("@dateArrive", SqlDbType.Date).Value = obj.DateArrive;
                SqlCmd.Parameters.Add("@etat", SqlDbType.Int).Value = obj.Etat.IdEtat;
                SqlCmd.Parameters.Add("@transmission", SqlDbType.Int).Value = obj.Transmission.IdTrans+1;
                SqlCmd.Parameters.Add("@carburant", SqlDbType.Int).Value = obj.Carburant.IdCarbu;
                SqlCmd.Parameters.Add("@carrosserie", SqlDbType.Int).Value = obj.Carrosserie.IdCaros;
                SqlCmd.Parameters.Add("@marque", SqlDbType.Int).Value = obj.Marque.IdMarque;
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
        */
        public bool UpEtatResDB(int idEtat, int id)
        {
            try
            {
                SqlCmd.CommandText = "UpEtatRes";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Clear();
                SqlCmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlCmd.Parameters.Add("@idEtat", SqlDbType.Int).Value = idEtat;
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
        */
        public override bool Supprimer(int id)
        {
            try
            {
                SqlCmd.CommandText = "DelCars";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Clear();
                SqlCmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                return (SqlCmd.ExecuteNonQuery() == 0) ? false : true;
            }
            catch (Exception e)
            {
                throw new ExceptionAccesDB(e.Message);
            }
        }
        /**
        * méthode qui lit dans la base de données tous les élèves
        * retour : la liste de tous les élèves
        */
        public override List<Vehicule> ListerTous()
        {
            List<Vehicule> liste = new List<Vehicule>();
            try
            {
                SqlCmd.CommandText = 
                    "Select IdVoiture, NumChassis, Voiture.Nom as NomVoit,Puissance,NbPortes,NbVitesse,Cylindres," +
                    "Couleur,Kilometrage,Annee,DateCtrlTech,CarnetEntretien,TypeTransaction,Prix,Reduction,Photo,DateArrive," +
                    //FOREIGN KEY
                    "Etat as IdEtat,Etat.Nom As NomEtat," +
                    "Transmission As IdTransm,Transmission.Nom As NomTransm," +
                    "Carburant As IdCarbu,Carburant.Nom As NomCarbu," +
                    "Carrosserie As IdCarro,Carrosserie.Nom As NomCarro," +
                    "Marque As IdMarque,Marque.Nom As NomMarque " +
                    //TABLE ET JOIN
                    "from Voiture " +
                    "join Etat on Etat = Etat.IdEtat " +
                    "Join Transmission on Transmission = Transmission.IdTransmission " +
                    "Join Carburant on Carburant = Carburant.IdCarburant " +
                    "Join Carrosserie on Carrosserie = Carrosserie.IdCarrosserie " +
                    "Join Marque on Marque = Marque.IdMarque ;";

                //                --where Reduction != 0 order by reduction,DateArrive-- Acceuil Promo
                //                --where TypeTransaction = 0-- Vente
                //                --where TypeTransaction = 1-- location


                SqlCmd.CommandType = CommandType.Text;
                //SqlCmd.Parameters.Clear();

                SqlCmd.ExecuteNonQuery();

                SqlDataReader sqlReader = SqlCmd.ExecuteReader();
                liste.Add(new Vehicule());

                while (sqlReader.Read() == true)
                    liste.Add(new Vehicule(
                        Convert.ToInt32(sqlReader["IdVoiture"]),
                        Convert.ToString(sqlReader["NumChassis"]),
                        Convert.ToString(sqlReader["NomVoit"]),
                        new Marque(Convert.ToInt32(sqlReader["IdMarque"]), Convert.ToString(sqlReader["NomMarque"])),
                        Convert.ToString(sqlReader["Puissance"]),
                        Convert.ToInt32(sqlReader["Nbportes"]),
                        Convert.ToInt32(sqlReader["NbVitesse"]),
                        Convert.ToInt32(sqlReader["Cylindres"]),
                        Convert.ToString(sqlReader["Couleur"]),
                        Convert.ToDecimal(sqlReader["Kilometrage"]),
                        DateTime.Parse(Convert.ToString(sqlReader["Annee"])),
                        DateTime.Parse(Convert.ToString(sqlReader["DateCtrlTech"])),
                        Convert.ToString(sqlReader["CarnetEntretien"]),
                        Convert.ToInt32(sqlReader["TypeTransaction"]),
                        Convert.ToDecimal(sqlReader["Prix"]),
                        Convert.ToInt32(sqlReader["Reduction"]),
                        Convert.ToString(sqlReader["Photo"]),
                        DateTime.Parse(Convert.ToString(sqlReader["DateArrive"])),
                        new Etat(Convert.ToInt32(sqlReader["IdEtat"]), Convert.ToString(sqlReader["NomEtat"])),
                        new Transmission(Convert.ToInt32(sqlReader["IdTransm"]), Convert.ToString(sqlReader["NomTransm"])),
                        new Carburant(Convert.ToInt32(sqlReader["IdCarbu"]), Convert.ToString(sqlReader["NomCarbu"])),
                        new Carrosserie(Convert.ToInt32(sqlReader["IdCarro"]), Convert.ToString(sqlReader["NomCarro"]))

                        ));


                sqlReader.Close();
            }
            catch (Exception e)
            {
                throw new ExceptionAccesDB(e.Message);
            }

            return liste;
        }

        //Une fonction qui renvoie la liste des voitures selon certains critères

        public override List<Vehicule> ListerTousAvecOptions(int choix)
        {
            //Si choix = 1 : Page Acceuil -> Liste des voiture triée sur la hauteur de la réduction et la date d'arrivée
            //Si choix = 2 : Page Vente -> voiture en vente uniquement
            //Si choix = 3 : Page Location -> voiture en location uniquement
            //Si choix = 4 : Page changeEtatRes -> voiture réservé uniquement
            //Si choix = 5 : Page DelCars -> voiture non réservé ou vente cloturée


            List<Vehicule> liste = new List<Vehicule>();
            try
            {
                SqlCmd.CommandText =
                    "Select Voiture.IdVoiture, NumChassis, Voiture.Nom as NomVoit,Puissance,NbPortes,NbVitesse,Cylindres," +
                    "Couleur,Kilometrage,Annee,DateCtrlTech,CarnetEntretien,TypeTransaction,Prix,Reduction,Photo,DateArrive," +
                    //FOREIGN KEY
                    "Etat as IdEtat,Etat.Nom As NomEtat," +
                    "Transmission As IdTransm,Transmission.Nom As NomTransm," +
                    "Carburant As IdCarbu,Carburant.Nom As NomCarbu," +
                    "Carrosserie As IdCarro,Carrosserie.Nom As NomCarro," +
                    "Marque As IdMarque,Marque.Nom As NomMarque " +
                    //TABLE ET JOIN
                    "from Voiture " +
                    "join Etat on Etat = Etat.IdEtat " +
                    "Join Transmission on Transmission = Transmission.IdTransmission " +
                    "Join Carburant on Carburant = Carburant.IdCarburant " +
                    "Join Carrosserie on Carrosserie = Carrosserie.IdCarrosserie " +
                    "Join Marque on Marque = Marque.IdMarque ";

                //Grâce à choix on sélectionne les options que l'on souhaite ajouter à la commande de récupération de la liste
                if (choix == 1) { SqlCmd.CommandText = SqlCmd.CommandText + " order by reduction Desc,DateArrive Desc ;"; }
                else if (choix == 2) { SqlCmd.CommandText = SqlCmd.CommandText + " where TypeTransaction = 0"; }
                else if (choix == 3) { SqlCmd.CommandText = SqlCmd.CommandText + " where TypeTransaction = 1"; }
                else if (choix == 4) 
                {
                    liste.Add(new Vehicule());
                    SqlCmd.CommandText = SqlCmd.CommandText + " Join Reservation res on res.IdVoiture = Voiture.IdVoiture where res.EtatRes <5"; 
                }
                else if (choix == 5) 
                {
                    liste.Add(new Vehicule());
                    SqlCmd.CommandText = SqlCmd.CommandText + "left outer Join Reservation res on res.IdVoiture = Voiture.IdVoiture where res.IdVoiture is null or res.EtatRes = 5"; 
                }

                SqlCmd.CommandType = CommandType.Text;
                SqlCmd.ExecuteNonQuery();
                SqlDataReader sqlReader = SqlCmd.ExecuteReader();

                //On récupère les données dans une liste
                while (sqlReader.Read() == true)
                    liste.Add(new Vehicule(
                        Convert.ToInt32(sqlReader["IdVoiture"]),
                        Convert.ToString(sqlReader["NumChassis"]),
                        Convert.ToString(sqlReader["NomVoit"]),
                        new Marque(Convert.ToInt32(sqlReader["IdMarque"]), Convert.ToString(sqlReader["NomMarque"])),
                        Convert.ToString(sqlReader["Puissance"]),
                        Convert.ToInt32(sqlReader["Nbportes"]),
                        Convert.ToInt32(sqlReader["NbVitesse"]),
                        Convert.ToInt32(sqlReader["Cylindres"]),
                        Convert.ToString(sqlReader["Couleur"]),
                        Convert.ToDecimal(sqlReader["Kilometrage"]),
                        DateTime.Parse(Convert.ToString(sqlReader["Annee"])),
                        DateTime.Parse(Convert.ToString(sqlReader["DateCtrlTech"])),
                        Convert.ToString(sqlReader["CarnetEntretien"]),
                        Convert.ToInt32(sqlReader["TypeTransaction"]),
                        Convert.ToDecimal(sqlReader["Prix"]),
                        Convert.ToInt32(sqlReader["Reduction"]),
                        Convert.ToString(sqlReader["Photo"]),
                        DateTime.Parse(Convert.ToString(sqlReader["DateArrive"])),
                        new Etat(Convert.ToInt32(sqlReader["IdEtat"]), Convert.ToString(sqlReader["NomEtat"])),
                        new Transmission(Convert.ToInt32(sqlReader["IdTransm"]), Convert.ToString(sqlReader["NomTransm"])),
                        new Carburant(Convert.ToInt32(sqlReader["IdCarbu"]), Convert.ToString(sqlReader["NomCarbu"])),
                        new Carrosserie(Convert.ToInt32(sqlReader["IdCarro"]), Convert.ToString(sqlReader["NomCarro"]))

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