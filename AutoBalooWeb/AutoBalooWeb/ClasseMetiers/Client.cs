using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoBalooWeb.ClasseMetiers
{
    public class Client
    {
        public Client()
        {

        }
        public Client(int idClient, string eMail, string password, string adresse, string nom, string prenom, string tel)
        {
            IdClient = idClient;
            EMail = eMail;
            Password = password;
            Adresse = adresse;
            Nom = nom;
            Prenom = prenom;
            Tel = tel;
        }

        public int IdClient { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public string Adresse { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Tel { get; set; }
    }
}