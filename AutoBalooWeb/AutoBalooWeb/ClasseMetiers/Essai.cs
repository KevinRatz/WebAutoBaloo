using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoBalooWeb.ClasseMetiers
{
    public class Essai : Transact
    {
        public Essai() : base()
        {

        }
        public Essai(DateTime dateRes, Vehicule vehicule, Client client, Etat etat) : base(dateRes, client, vehicule)
        {
        }
    }
}