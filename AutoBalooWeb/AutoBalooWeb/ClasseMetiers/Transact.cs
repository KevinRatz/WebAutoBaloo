using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoBalooWeb.ClasseMetiers
{
    public abstract class Transact
    {
        protected Transact()
        {

        }

        protected Transact(DateTime date, Client client, Vehicule voiture)
        {
            Date = date;
            Client = client;
            Voiture = voiture;
        }

        public DateTime Date { get; set; }
        public Client Client { get; set; }
        public Vehicule Voiture { get; set; }
    }
}