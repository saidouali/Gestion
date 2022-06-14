<%@ Page Language="C#" %>
<%@ Import Namespace="Gestion" %>
<%@ Import Namespace="System.Collections.Generic" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>Site de Gestion de stock </title>
         <link rel="stylesheet" href="style.css">
</head>
<body>
    <center>
          <% 
                //le code C#
                Controleur unControleur = new Controleur();
                string message = "";
            %>

        <!--#include file="vue/vue_inscription.aspx"-->
        <%
            if(Request.Form["Inscrire"] !=null)
            {
              
                string nom = Request.Form["nom"];
                string prenom = Request.Form["prenom"];
                string email = Request.Form["email"];
                string mdp = Request.Form["mdp"];
                string droits = Request.Form["droits"];

                 //instanciation d'un Document 
                  User unUser = new User(nom, prenom, email, mdp, droits);
                  //insertion dans la base via le controleur 
                   unControleur.insertUser(unUser);
            }                
                    %>
             

        <a href="Default.aspx">Se Connecter</a> 

    </center>
    </body>
    </html>