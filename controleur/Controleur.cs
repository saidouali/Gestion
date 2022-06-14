using System;
using System.Collections.Generic;

namespace Gestion
{
    public class Controleur
    {
        private Modele unModele;
        public Controleur()
        {
            this.unModele = new Modele("127.0.0.1", "geststock", "root", "");
        }

        public List<Document> selectAllReservations()
        {
            return unModele.selectAllReservations();
        }

        public List<test> selectAllspecialites()
        {
            return unModele.selectAllspecialites();
        }
        public void insertReservation(Document unDocument)
        {
            //apres des tests sur les champs

            //appel du Modele
            unModele.insertReservation(unDocument);
        }

        public void deleteReservation(int idreservation)
        {
            unModele.deleteReservation(idreservation);
        }
        public void updateReservation(Document unDocument)
        {
            unModele.updateReservation(unDocument);
        }

        public Document selectWhereDocument(int idreservation)
        {
            return unModele.selectWhereDocument(idreservation);
        }

        public User selectWhereUser(User unUser)
        {
            return unModele.selectWhereUser(unUser);
        }

        public List<User> selectAllUser()
        {
            return unModele.selectAllUsers();
        }
        public void insertUser(User unUser)
        {
            //apres des tests sur les champs

            //appel du Modele
            unModele.insertUser(unUser);
        }
    }
}
