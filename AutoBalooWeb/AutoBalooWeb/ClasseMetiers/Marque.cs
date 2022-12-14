using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoBalooWeb.ClasseMetiers
{
    public class Marque
    {
        public Marque()
        {
            NomMarque = "";
        }
        public Marque(int idMarque)
        {
            IdMarque = idMarque;
        }
        public Marque(int idMarque, string nomMarque)
        {
            IdMarque = idMarque;
            NomMarque = nomMarque;
        }
        public override string ToString()
        {
            return NomMarque;
        }
        public int IdMarque { get; set; }
        public string NomMarque { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Marque Marque &&
                   IdMarque == Marque.IdMarque &&
                   NomMarque == Marque.NomMarque;
        }
    }
}