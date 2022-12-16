using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoBalooWeb.ClasseMetiers
{
    public class EtatRes
    {
        public EtatRes()
        {

        }
        public EtatRes(int idEtatRes, string nomEtatRes)
        {
            IdEtatRes = idEtatRes;
            NomEtatRes = nomEtatRes;
        }

        public int IdEtatRes { get; set; }
        public string NomEtatRes { get; set; }

        public override string ToString()
        {
            return NomEtatRes;
        }

        public override bool Equals(object obj)
        {
            return obj is EtatRes EtatRes &&
                   IdEtatRes == EtatRes.IdEtatRes &&
                   NomEtatRes == EtatRes.NomEtatRes;
        }
    }
}