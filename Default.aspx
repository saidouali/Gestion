<%@ Page Language="C#" %>
<%@ Import Namespace="Gestion" %>
<%@ Import Namespace="System.Collections.Generic" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>Site Gestion de stock </title>
         <link rel="stylesheet" href="style.css">
</head>
<body>
    <center>
        <% 
                //le code C#
                Controleur unControleur = new Controleur();
                string message = "";
            %>
           <h1 id="fs-title"> Site Gestion de Reservation </h1>
            <img src="images/aut.png" width="100" height="100">
            <br/>
                 
           <%
               if (Session["email"] == null) {
            %>
            
            <!--#include file="vue/vue_connexion.aspx"-->
            <%
                }
            %>
            <%
                if (Request.Form["connecter"] != null) {
                    string email = Request.Form["email"];
                    string mdp = Request.Form["mdp"];
                    string droits = Request.Form["droits"];
                    User unUser = new User(email, mdp, "", "", "");
                    unUser = unControleur.selectWhereUser(unUser);

                    if (unUser != null) {
                        message += "Connexion Bienvenue : " + unUser.Nom;
                        Session.Add("email", unUser.Email);
                        Session.Add("droits", unUser.Droits);

                    } else {
                        message += "Veuillez vérifier vos identifiants";
                    }
                }

            %>

            <%= message %>
            
            
            
            <%
                if (Session["email"] != null)
                {

                    Document leDocument = null;

                    if (Request["action"] != null)
                    {
                        string action = Request["action"];
                        int idreservation = int.Parse(Request["idreservation"]);

                        if (action == "sup")
                        {
                            unControleur.deleteReservation(idreservation);
                        }
                        else if (action == "edit")
                        {

                            //récupérer le document sélectionné pour être modifié 
                            leDocument = unControleur.selectWhereDocument(idreservation);

                        }
                    }
            %>


          <!--#include file="vue/vue_insert.aspx"-->
            
            <%
                if (Request.Form["modifier"] != null)
                {
                    int idreservation = int.Parse(Request.Form["idreservation"]);
                    string nom = Request.Form["nom"];
                    string prenom = Request.Form["prenom"];
                    string specialite = Request.Form["specialite"];
                    int reference = int.Parse(Request.Form["reference"]);
                    float quantite = float.Parse(Request.Form["quantite"]);
                    string emplacement = Request.Form["emplacement"];

                    //instanciation d'un Document 
                    Document unDocument = new Document(idreservation, nom, prenom, specialite, reference, quantite, emplacement);
                    //appel pour update 
                    unControleur.updateReservation(unDocument);
                }

                if (Request.Form["valider"] != null){
                    string nom = Request.Form["nom"];
                    string prenom = Request.Form["prenom"];
                    string specialite = Request.Form["specialite"];
                    int reference = int.Parse(Request.Form["reference"]);
                    float quantite = float.Parse(Request.Form["quantite"]);
                    string emplacement = Request.Form["emplacement"];


                    //instanciation d'un Document 
                    Document unDocument = new Document(nom, prenom, specialite, reference, quantite, emplacement);
                    //insertion dans la base via le controleur 
                    unControleur.insertReservation(unDocument);

                }
            %>
            <%
                //recupération des reservations de la base
                List<Document> lesReservations = unControleur.selectAllReservations();
            %>
             
             
        <a href="Default3.aspx" id="pagination">Next</a>
        <br /> <a href="Default.aspx?connexion=DeConnexion " id="pag">Deconnexion</a><br /><br />
         
            <% 

                }

                if (Request["connexion"] == "DeConnexion") {
                    Session.Clear();
                    Response.Redirect("Default.aspx");
                }
         %>
        
</center>
    </body>
    </html>


 