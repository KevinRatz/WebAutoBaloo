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
        public Essai(DateTime dateRes, int vehicule, int client) : base(dateRes, client, vehicule)
        {
        }
    }
}