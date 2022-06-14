using System;
namespace Gestion
{
    public class User
    {
        private int iduser;
        private string email, mdp, nom, prenom, droits;

        public User(int iduser, string email, string mdp, string nom, string prenom,
            string droits)
        {
            this.iduser = iduser;
            this.email = email;
            this.mdp = mdp;
            this.nom = nom;
            this.prenom = prenom;
            this.droits = droits;

        }

        public User(string email, string mdp, string nom, string prenom,
            string droits)
        {
            this.iduser = 0;
            this.email = email;
            this.mdp = mdp;
            this.nom = nom;
            this.prenom = prenom;
            this.droits = droits;

        }

        public int Iduser
        {
            get
            {
                return iduser;
            }
            set
            {
                this.iduser = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                this.email = value;
            }
        }

        public string Mdp
        {
            get
            {
                return mdp;
            }
            set
            {
                this.mdp = value;
            }
        }

        public string Nom
        {
            get
            {
                return nom;
            }
            set
            {
                this.nom = value;
            }
        }

        public string Prenom
        {
            get { return prenom;} 
            set{ this.prenom = value; }
        }

        public string Droits
        {
            get { return droits; }
            set { this.droits = value; }
        }
    }
}
