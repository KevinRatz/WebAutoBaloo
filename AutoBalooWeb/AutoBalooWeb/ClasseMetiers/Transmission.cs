using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoBalooWeb.ClasseMetiers
{
    public class Transmission
    {
        public Transmission()
        {

        }
        public Transmission(int idTrans, string nomTrans)
        {
            IdTrans = idTrans;
            NomTrans = nomTrans;
        }

        public int IdTrans { get; set; }
        public string NomTrans { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Transmission Trans &&
                   IdTrans == Trans.IdTrans &&
                   NomTrans == Trans.NomTrans;
        }
    }
}