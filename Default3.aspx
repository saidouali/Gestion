<%@ Page Language="C#" %>
<%@ Import Namespace="Gestion" %>
<%@ Import Namespace="System.Collections.Generic" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title> Site de Gestion </title>
   <link rel="stylesheet" href="style.css" />
    <script src="/Script.js"></script>
   
</head>
<body>
    <center>
           <% 
                //le code C#
                Controleur unControleur = new Controleur();
                string message = "";
            %>
          <h1 id="fs-title"> Site Gestion de Stock</h1>
            <img src="images/aut.png" width="100" height="100">

   
</div>
          <%
               if (Session["email"] == null) {
            %>
            
            <!--#include file="vue/vue_connexion.aspx"-->
            <%
                }
            %>

        <%=message %>
        <%
              if (Session["email"] != null) {
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


                if (Request.Form["valider"] != null)
                {
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
     
        <h3> Liste des reservations  </h3>
            <%
                //recupération des reservations de la base
                List<Document> lesReservations = unControleur.selectAllReservations();
            
            %>
             
              <!--#include file="vue/vue_lister.aspx"-->

            <% 

                }

                if (Request["connexion"] == "DeConnexion") {
                    Session.Clear();
                    Response.Redirect("Default2.aspx");
                }
         %>
        </center>
<br />  <br />  <a href="Default.aspx" id="pagine">Retour</a> 
   
 <a href="http://localhost:50697/Default1.aspx" id="pagination">Enregister une commande ?</a>
    <br />
   <script>
       // Vanilla JS table filter
       // Source: https://blog.pagesd.info/2019/09/30/rechercher-filtrer-table-javascript/

       (function () {
           "use strict";

           var TableFilter = (function () {
               var search;

               function dquery(selector) {
                   // Renvoie un tableau des éléments correspondant au sélecteur
                   return Array.prototype.slice.call(document.querySelectorAll(selector));
               }

               function onInputEvent(e) {
                   // Récupère le texte à rechercher
                   var input = e.target;
                   search = input.value.toLocaleLowerCase();
                   // Retrouve les lignes où effectuer la recherche
                   // (l'attribut data-table de l'input sert à identifier la table à filtrer)
                   var selector = input.getAttribute("data-table") + " tbody tr";
                   var rows = dquery(selector);
                   // Recherche le texte demandé sur les lignes du tableau
                   [].forEach.call(rows, filter);
                   // Mise à jour du compteur de ligne (s'il y en a un de défini)
                   // (l'attribut data-count de l'input sert à identifier l'élément où afficher le compteur)
                   var writer = input.getAttribute("data-count");
                   if (writer) {
                       // S'il existe un attribut data-count, on compte les lignes visibles
                       var count = rows.reduce(function (t, x) { return t + (x.style.display === "none" ? 0 : 1); }, 0);
                       // Puis on affiche le compteur
                       dquery(writer)[0].textContent = count;
                   }
               }

               function filter(row) {
                   // Mise en cache de la ligne en minuscule
                   if (row.lowerTextContent === undefined)
                       row.lowerTextContent = row.textContent.toLocaleLowerCase();
                   // Masque la ligne si elle ne contient pas le texte recherché
                   row.style.display = row.lowerTextContent.indexOf(search) === -1 ? "none" : "table-row";
               }

               return {
                   init: function () {
                       // Liste des champs de saisie avec un attribut data-table
                       var inputs = dquery("input[data-table]");
                       [].forEach.call(inputs, function (input) {
                           // Déclenche la recherche dès qu'on saisi un filtre de recherche
                           input.oninput = onInputEvent;
                           // Si on a déjà une valeur (suite à navigation arrière), on relance la recherche
                           if (input.value !== "") input.oninput({ target: input });
                       });
                   }
               };

           })();

           TableFilter.init();
       })();
   </script>
</body>
</html>
