using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoBalooWeb.ClasseMetiers
{
    public class Reservation
    {
        public Reservation()
        {
                
        }
        public Reservation(DateTime dateRes, Vehicule vehicule, Client client, Etat etat)
        {
            DateRes = dateRes;
            Vehicule = vehicule;
            Client = client;
            Etat = etat;
        }

        public DateTime DateRes { get; set; }
        public Vehicule Vehicule { get; set; }
        public Client Client { get; set; }
        public Etat Etat { get; set; }
    }
}