  <div class="col-md-8 mx-auto bg-light rounded p-4">
        <h5 class="text-center font-weight-bold">Barre de recherche</h5>
        <hr class="my-1">
        <h5 class="text-center text-secondary">**Recherche par nom, prenom ou mobile avec espace sans (. ; -)</h5>
          <div class="input-group">
            <input type="text" name="search" id="annuaire" class="form-control form-control-lg rounded-0 border-info" placeholder="**Search..." autocomplete="off" required>
            <div class="input-group-append">
            </div>
          </div>


  </div>

  <div id="searchresult"></div>

<script type="text/javascript" src="annuaire.js"></script>

  <script type="text/javascript">

      $(document).ready(function () {
          $("#annuaire").keyup(function () {
              var input = $(this).val();
              // alert(input);

              if (input != "")
                  if (input != "input") {


                      $.ajax({

                          url: 'annuaire.php',
                          method: "POST",
                          data: { input: input },

                          success: function (data) {
                              $("#searchresult").html(data);
                          }
                      });

                  } else {

                      $("#searchresult").css("display", "none");
                  }
          });
      });
  </script>
<?php
    if (isset($_POST['input'])) {
   $input = $_POST['input'];
   $query = "SELECT * FROM reservation WHERE noms LIKE '{$input}%' ";
   $result = mysqli_query ($con,$query);

    ?>
<table border="1" id="reserve">
    
    <tr>
        <th>Id Reservation</th> <th>Nom</th> <th>Prénom</th>
        <th>Specialite</th> <th>Reference</th> <th>Quantite</th>
        <th> Emplacement </th> <th>Opérations</th> <th>Statuts</th>
    </tr>
   
    <% 
        string chaine = ""; 

    foreach(Document unDocument in lesReservations)
    {
        chaine += "<tr> <td>" + unDocument.IDreservation + "</td><td>" + unDocument.Nom ; 
        chaine += "</td><td>" + unDocument.Prenom + "</td><td>" + unDocument.Specialite + "</td>";
        chaine += "<td>" + unDocument.Reference + "</td> <td>" + unDocument.Quantite + "</td>"; 
        chaine += "<td>" + unDocument.Emplacement + "</td>"; 
    
        chaine += "<td> <a href='Default.aspx?action=sup&idreservation=" + unDocument.IDreservation + "'>"; 
        chaine += "<img src='images/del.png' height='40' width='40'></a>";
    
        chaine += "<a href='Default.aspx?action=edit&idreservation=" + unDocument.IDreservation + "'>"; 
        chaine += "<img src='images/th.png' height='40' width='40'></a>";
     
        chaine += "</td>"; 
        if ((string )Session["droits"] == "admin"){


         chaine +="<td> <a href='accepter.aspx?action=accep&idreservation=" + unDocument.IDreservation +"'>";
        chaine += "<img src='images/accep.png' height='40' width='40'></a>";

        chaine +="<a href='refuser.aspx?action=refus&idreservation=" + unDocument.IDreservation +"'>";
        chaine += "<img src='images/refus.png' height='40' width='40'></a>";

        
        chaine += "</td>";
                }      

        chaine += "</tr>"; 

      
    }
    %>
    <%= chaine %>
  
</table>

    