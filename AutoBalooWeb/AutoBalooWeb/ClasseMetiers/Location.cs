using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoBalooWeb.ClasseMetiers
{
    public class Location : Transact
    {
        public Location() : base()
        {

        }
        public Location(DateTime dateRes, Vehicule vehicule, Client client, DateTime dateFin) : base(dateRes, client, vehicule)
        {
            DateFin = dateFin;
        }

        public DateTime DateFin { get; set; }
    }
}