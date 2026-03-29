using Lib_Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Services.Interfaces
{
    public interface IJeuService
    {
        void Creer(Jeu jeu);
        void Modifier(Jeu jeu);
        void Supprimer(int idJeu);
        List<Jeu> Lister(string filtre);
        Jeu? Obtenir(int idJeu);
    }
}
