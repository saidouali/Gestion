using System;
using System.Collections.Generic;

namespace Gestion
{

    public class Controleur1
    {
        private Modele unModele;
        public Controleur1()
        {
            this.unModele = new Modele("127.0.0.1", "geststock", "root", "");
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

        public User selectWhereUser(int iduser)
        {
            return unModele.selectWhereUser(iduser);
        }

    }

}