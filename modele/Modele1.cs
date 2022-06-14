using System;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Collections.Generic;

namespace Gestion
{
    public class Modele1
    {
        private string serveur, bdd, user, mdp;
        //connexion MySQL 
        private MySqlConnection maConnexion;

        public Modele1(string serveur, string bdd, string user, string mdp)
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
            string requete = "insert into user values (null, @nom, @prenom, @email, @mdp, @droits); ";
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
        }
        public User selectWhereUser(int iduser)
        {
            string requete = "select * from user where iduser=@id;";
            User unUser = null;

            try
            {
                this.maConnexion.Open();
                MySqlCommand uneCommande = this.maConnexion.CreateCommand();
                uneCommande.CommandText = requete;
                uneCommande.Parameters.AddWithValue("@id", iduser);

                DbDataReader unReader = uneCommande.ExecuteReader();

                try
                {
                    if (unReader.HasRows) //s'il ya des lignes 
                    {
                        if (unReader.Read())
                        {
                            unUser = new User(unReader.GetInt32(0),
                                 unReader.GetString(1), unReader.GetString(2),
                                 unReader.GetString(3), unReader.GetString(4),
                                 unReader.GetString(5)); ;

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
            return unUser;
        }
    }

}

