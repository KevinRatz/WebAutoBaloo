using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoBalooWeb.ClasseMetiers
{
    public class Reservation : Transact
    {
        public Reservation() : base()
        {
                
        }
        public Reservation(DateTime dateRes, Vehicule vehicule, Client client, Etat etat) : base(dateRes,client,vehicule)
        {
            Etat = etat;
        }

        public Etat Etat { get; set; }
    }
}