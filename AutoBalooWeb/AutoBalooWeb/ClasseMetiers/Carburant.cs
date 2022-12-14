using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoBalooWeb.ClasseMetiers
{
    public class Carburant
    {
        public Carburant()
        {
            NomCarbu = "";
        }
        public Carburant(int idCarbu)
        {
            IdCarbu = idCarbu;
        }
        public Carburant(int idCarbu, string nomCarbu)
        {
            IdCarbu = idCarbu;
            NomCarbu = nomCarbu;
        }
        public override string ToString()
        {
            return NomCarbu;
        }
        public int IdCarbu { get; set; }
        public string NomCarbu { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Carburant Carbu &&
                   IdCarbu == Carbu.IdCarbu &&
                   NomCarbu == Carbu.NomCarbu;
        }
    }
}