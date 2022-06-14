using System;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Collections.Generic;

namespace Gestion
{
    public class Modele
    {
        private string serveur, bdd, user, mdp;
        //connexion MySQL 
        private MySqlConnection maConnexion;

        public Modele(string serveur, string bdd, string user, string mdp)
        {
            this.serveur = serveur;
            this.bdd = bdd;
            this.user = user;
            this.mdp = mdp;
            //3306 Mysql et 3307 Mariadb
            string url = "SERVER=" + this.serveur + ";Database="
                + this.bdd + ";User Id=" + this.user + ";password=" + this.mdp;

            //instanciation de la connexion
            try
            {
                this.maConnexion = new MySqlConnection(url);
                Console.WriteLine("Connexion reussie");
            }
            catch (Exception exp)
            {
                Console.WriteLine("Erreur de connexion à : " + url);
            }
        }

        public List<Document> selectAllReservations()
        {
            List<Document> lesDocuments = new List<Document>();
            string requete = "select * from reservation  ;";
            try
            {
                this.maConnexion.Open();
                MySqlCommand uneCommande = this.maConnexion.CreateCommand();

                uneCommande.CommandText = requete;

                //execution de la requete  
                //on définit un curseur de lecture des enregistrements
                DbDataReader unReader = uneCommande.ExecuteReader();

                try
                {
                    if (unReader.HasRows) //s'il ya des lignes 
                    {
                        while (unReader.Read())
                        {
                            Document unDocument = new Document(unReader.GetInt32(0),
                                unReader.GetString(1), unReader.GetString(2),
                                unReader.GetString(3), unReader.GetInt32(4),
                                unReader.GetFloat(5), unReader.GetString(6));
                            lesDocuments.Add(unDocument);
                        }
                    }

                }
                finally
                {
                    Console.WriteLine("erreur d'execution de la requete " + requete);
                }

                //extraction des données 

                this.maConnexion.Close();
            }
            catch (Exception exp)
            {
                Console.WriteLine("Erreur Execution: " + requete);
            }
            return lesDocuments;
        }

        public List<test> selectAllspecialite()
        {
            List<test> lestests = new List<test>();
            string requete = "select id, fonction from specialite  ;";
            try
            {
                this.maConnexion.Open();
                MySqlCommand uneCommande = this.maConnexion.CreateCommand();

                uneCommande.CommandText = requete;

                //execution de la requete  
                //on définit un curseur de lecture des enregistrements
                DbDataReader unReader = uneCommande.ExecuteReader();

                try
                {
                    if (unReader.HasRows) //s'il ya des lignes 
                    {
                        while (unReader.Read())
                        {
                            test untest = new test (unReader.GetInt32(0),
                                unReader.GetString(1));
                            lestests.Add(untest);
                        }
                    }

                }
                finally
                {
                    Console.WriteLine("erreur d'execution de la requete " + requete);
                }

                //extraction des données 

                this.maConnexion.Close();
            }
            catch (Exception exp)
            {
                Console.WriteLine("Erreur Execution: " + requete);
            }
            return lestests;
        }

        public void insertspecialite (test untest)
        {
            string requete = "insert into reservation values(null, @fonction);";
            try
            {

            }
        }

        public void insertReservation(Document unDocument)
        {
            string requete = "insert into reservation values (null, @nom, @prenom, @specialite, @reference, @quantite, @emplacement); ";
            try
            {
                this.maConnexion.Open();
                MySqlCommand uneCommande = this.maConnexion.CreateCommand();

                uneCommande.CommandText = requete;

                //la correspondance entre les parametres SQL et prog
                uneCommande.Parameters.AddWithValue("@nom", unDocument.Nom);
                uneCommande.Parameters.AddWithValue("@prenom", unDocument.Prenom);
                uneCommande.Parameters.AddWithValue("@specialite", unDocument.Specialite);
                uneCommande.Parameters.AddWithValue("@reference", unDocument.Reference);
                uneCommande.Parameters.AddWithValue("@quantite", unDocument.Quantite);
                uneCommande.Parameters.AddWithValue("@emplacement", unDocument.Emplacement);
                //execution de la commande
                uneCommande.ExecuteNonQuery();

                this.maConnexion.Close();
            }
            catch (Exception exp)
            {
                Console.WriteLine("Erreur de connexion ");
            }
        }

        public void deleteReservation(int idreservation)
        {
            string requete = "delete from reservation where idreservation =@idreservation;";
            try
            {
                this.maConnexion.Open();
                MySqlCommand uneCommande = this.maConnexion.CreateCommand();
                uneCommande.CommandText = requete;
                uneCommande.Parameters.AddWithValue("@idreservation", idreservation);
                uneCommande.ExecuteNonQuery();

                this.maConnexion.Close();
            }
            catch (Exception exp)
            {
                Console.WriteLine("Erreur sur la requete : " + requete);
            }
        }
        public void updateReservation(Document unDocument)
        {

            string requete = "update reservation set nom=@nom, prenom=@prenom," +
                "specialite=@specialite, reference=@reference, quantite=@quantite, emplacement=@emplacement " +
                "where idreservation=@id;";
            try
            {
                this.maConnexion.Open();
                MySqlCommand uneCommande = this.maConnexion.CreateCommand();

                uneCommande.CommandText = requete;
                uneCommande.Parameters.AddWithValue("@id", unDocument.IDreservation);
                uneCommande.Parameters.AddWithValue("@nom", unDocument.Nom);
                uneCommande.Parameters.AddWithValue("@prenom", unDocument.Prenom);
                uneCommande.Parameters.AddWithValue("@specialite", unDocument.Specialite);
                uneCommande.Parameters.AddWithValue("@reference", unDocument.Reference);
                uneCommande.Parameters.AddWithValue("@quantite", unDocument.Quantite);
                uneCommande.Parameters.AddWithValue("@emplacement", unDocument.Emplacement);
                uneCommande.ExecuteNonQuery();

                this.maConnexion.Close();

            }
            catch (Exception exp)
            {
                Console.WriteLine("Erreur sur la requete : " + requete);
            }
        }
        public Document selectWhereDocument(int idreservation)
        {
            string requete = "select * from reservation where idreservation=@id;";
            Document unDocument = null;

            try
            {
                this.maConnexion.Open();
                MySqlCommand uneCommande = this.maConnexion.CreateCommand();
                uneCommande.CommandText = requete;
                uneCommande.Parameters.AddWithValue("@id", idreservation);

                DbDataReader unReader = uneCommande.ExecuteReader();

                try
                {
                    if (unReader.HasRows) //s'il ya des lignes 
                    {
                        if (unReader.Read())
                        {
                            unDocument = new Document(unReader.GetInt32(0),
                                 unReader.GetString(1), unReader.GetString(2),
                                 unReader.GetString(3), unReader.GetInt32(4),
                                 unReader.GetFloat(5), unReader.GetString(6)); ;

                        }
                    }

                }
                finally
                {
                    Console.WriteLine("erreur d'execution de la requete " + requete);
                }

                this.maConnexion.Close();
            }
            catch (Exception exp)
            {
                Console.WriteLine("Erreur sur la requete : " + requete);
            }
            return unDocument;
        }
      
        public User selectWhereUser(User unUser)
        {
            string requete = "select * from user where email=@email and mdp=@mdp ;";
            User leUser = null;

            try
            {
                this.maConnexion.Open();
                MySqlCommand uneCommande = this.maConnexion.CreateCommand();
                uneCommande.CommandText = requete;
                uneCommande.Parameters.AddWithValue("@email", unUser.Email);
                uneCommande.Parameters.AddWithValue("@mdp", unUser.Mdp);

                DbDataReader unReader = uneCommande.ExecuteReader();

                try
                {
                    if (unReader.HasRows) //s'il ya des lignes 
                    {
                        if (unReader.Read())
                        {
                            leUser = new User(unReader.GetInt32(0),
                               unReader.GetString(1), unReader.GetString(2),
                               unReader.GetString(3), unReader.GetString(4),
                               unReader.GetString(5));

                        }
                    }

                }
                finally
                {
                    Console.WriteLine("erreur d'execution de la requete " + requete);
                }

                this.maConnexion.Close();
            }
            catch (Exception exp)
            {
                Console.WriteLine("Erreur sur la requete : " + requete);
                Console.WriteLine(exp.Message);
                Console.WriteLine(exp.StackTrace);
            }
            return leUser;
        }

        public List<User> selectAllUsers()
        {
            List<User> lesUsers = new List<User>();
            string requete = "select * from user ;";
            try
            {
                this.maConnexion.Open();
                MySqlCommand uneCommande = this.maConnexion.CreateCommand();

                uneCommande.CommandText = requete;

                //execution de la requete  
                //on définit un curseur de lecture des enregistrements
                DbDataReader unReader = uneCommande.ExecuteReader();

                try
                {
                    if (unReader.HasRows) //s'il ya des lignes 
                    {
                        while (unReader.Read())
                        {
                            User unUser = new User(unReader.GetInt32(0),
                                unReader.GetString(1), unReader.GetString(2),
                                unReader.GetString(3), unReader.GetString(4),
                                unReader.GetString(5));
                            lesUsers.Add(unUser);
                        }
                    }

                }
                finally
                {
                    Console.WriteLine("erreur d'execution de la requete " + requete);
                }

                //extraction des données 

                this.maConnexion.Close();
            }
            catch (Exception exp)
            {
                Console.WriteLine("Erreur Execution: " + requete);
            }
            return lesUsers;
        }
        public void insertUser(User unUser)
        {
            string requete = "insert into user values (null, @nom, @prenom," +
                    "@email, @mdp, @droits); ";

            try
            {
                this.maConnexion.Open();
                MySqlCommand uneCommande = this.maConnexion.CreateCommand();

                uneCommande.CommandText = requete;

                //la correspondance entre les parametres SQL et prog
                uneCommande.Parameters.AddWithValue("@nom", unUser.Nom);
                uneCommande.Parameters.AddWithValue("@prenom", unUser.Prenom);
                uneCommande.Parameters.AddWithValue("@email", unUser.Email);
                uneCommande.Parameters.AddWithValue("@mdp", unUser.Mdp);
                uneCommande.Parameters.AddWithValue("@droits", unUser.Droits);
                //execution de la commande
                uneCommande.ExecuteNonQuery();

                this.maConnexion.Close();
            }
            catch (Exception exp)
            {
                Console.WriteLine("Erreur de connexion ");
            }
            @mdp = System.Security.Cryptography.MD5CryptoServiceProvider.
        }
      
    }
}
