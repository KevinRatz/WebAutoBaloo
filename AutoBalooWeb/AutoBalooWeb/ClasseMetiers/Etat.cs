using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoBalooWeb.ClasseMetiers
{
    public class Etat
    {
        public Etat()
        {

        }
        public Etat(int idEtat)
        {
            IdEtat = idEtat;
        }
        public Etat(int idEtat, string nomEtat)
        {
            IdEtat = idEtat;
            NomEtat = nomEtat;
        }

        public int IdEtat { get; set; }
        public string NomEtat { get; set; }

        public override string ToString()
        {
            return NomEtat;
        }

        public override bool Equals(object obj)
        {
            return obj is Etat etat &&
                   IdEtat == etat.IdEtat &&
                   NomEtat == etat.NomEtat;
        }
    }
}