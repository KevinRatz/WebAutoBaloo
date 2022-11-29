using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoBalooWeb.ClasseMetiers
{
    public class Carrosserie
    {
        public Carrosserie()
        {

        }
        public Carrosserie(int idCaros, string nomCaros)
        {
            IdCaros = idCaros;
            NomCaros = nomCaros;
        }

        public int IdCaros { get; set; }
        public string NomCaros { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Carrosserie Caros &&
                   IdCaros == Caros.IdCaros &&
                   NomCaros == Caros.NomCaros;
        }
    }
}