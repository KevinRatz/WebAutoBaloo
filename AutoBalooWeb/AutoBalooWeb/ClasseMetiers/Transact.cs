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

        protected Transact(DateTime date, int client, int voiture)
        {
            Date = date;
            Client = client;
            Voiture = voiture;
        }
        protected Transact(Transact t)
        {
            Date = t.Date;
            Client = t.Client;
            Voiture = t.Voiture;
        }

        public override string ToString()
        {
            return Client.ToString() + Voiture.ToString() + Date.ToString();
        }

        public DateTime Date { get; set; }
        public int Client { get; set; }
        public int Voiture { get; set; }
    }
}