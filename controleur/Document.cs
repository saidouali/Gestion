using System;
namespace Gestion
{
    public class Document
    {
        private int idreservation;
        private string nom;
        private string prenom;
        private string specialite;
        private int reference;
        private float quantite;
        private string emplacement;
       

        public Document(int idreservation, string nom, string prenom, string specialite, int reference, float quantite, string emplacement)
        {
            this.idreservation = idreservation;
            this.nom = nom;
            this.prenom = prenom;
            this.specialite = specialite;
            this.reference = reference;
            this.quantite = quantite;
            this.emplacement = emplacement;
            

        }
        public Document(string nom, string prenom, string specialite, int reference, float quantite, string emplacement, string statuts)
        {
            this.idreservation = 0;
            this.nom = nom;
            this.prenom = prenom;
            this.specialite= specialite;
            this.reference= reference;
            this.quantite= quantite;
            this.emplacement= emplacement;
           
        }
        public string Nom
        {
            get { return nom; }
            set { this.nom = value; }
        }
        public string Prenom
        {
            get { return prenom; }
            set { this.prenom = value; }
        }
        public string Specialite
        {
            get { return specialite; }
            set { this.specialite = value; }
        }

        public int Reference
        {
            get { return reference; }
            set { this.reference = value; }
        }
        public float Quantite
        {
            get { return quantite; }
            set { this.quantite= value; }
        }
        public string Emplacement
        {
            get { return emplacement; }
            set { this.emplacement= value; }
        }
       
        public int IDreservation
        {
            get { return idreservation; }
            set { this.idreservation = value; }
        }

    }
}
