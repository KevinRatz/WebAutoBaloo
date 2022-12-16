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
        public Reservation(DateTime dateRes, int vehicule, int client, int etatRes) : base(dateRes,client,vehicule)
        {
            EtatRes = etatRes;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public int EtatRes { get; set; }
    }
}