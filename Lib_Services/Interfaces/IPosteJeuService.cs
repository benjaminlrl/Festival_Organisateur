using Lib_Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Services.Interfaces
{
    public interface IPosteJeuService
    {
        void Creer(PosteJeu posteJeu);
        void Modifier(PosteJeu posteJeu);
        void Supprimer(int idPosteJeu);
        List<PosteJeu> Lister(string filtre);
        PosteJeu? Obtenir(int idPosteJeu);
        PosteJeu? ReferenceExiste(string reference);

    }
}
