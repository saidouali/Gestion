<form method="post" action="" id="msform" >
<fieldset>
    <h2>Insertion d'une reservation</h2>
    <table>
        <tr>
            <td>Nom</td>
            <td> <input type="text"name="nom" 
                        value="<%= (leDocument!=null)?leDocument.Nom:"" %>"> </td>
        </tr>
        <tr>
            <td>Prénom</td>
            <td><input type="text" name="prenom"
                       value="<%= (leDocument!=null)?leDocument.Prenom:"" %>"></td>
        </tr>
        <tr>
            <select name="specialite">
                <option selected>Selectionner votre specialiste</option>

             

               
            </select>
           
        </tr>
  <tr>
            <td>Reference</td>
            <td><input type="text" name="reference"
                       value="<%= (leDocument!=null)?leDocument.Reference+"":"" %>"></td>
        </tr>
  <tr>
            <td>Quantite</td>
            <td><input type="text" name="quantite"
                       value="<%= (leDocument!=null)?leDocument.Quantite+"":"" %>"></td>
        </tr>
       
        <tr>
            <td>Emplacement</td>
            <td><input type="text" name="emplacement"
                       value="<%= (leDocument!=null)?leDocument.Emplacement:"" %>"></td>
        </tr>
        <tr>
            <td></td>
            <td><input type="submit" 
  <%= (leDocument!=null)? "name='modifier' value='Modifier'":"name='valider' value='Valider'" %>
                       > </td>
        </tr>
  <%= (leDocument!=null)? "<input type='hidden' name='idreservation' value='"+leDocument.IDreservation+"'>":"" %>
    </table>
</fieldset>
 
</form>
