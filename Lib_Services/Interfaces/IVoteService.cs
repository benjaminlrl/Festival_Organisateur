using Lib_Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Services.Interfaces
{
    public interface IVoteService
    {
        void Creer(Vote vote);
        void Modifier(Vote vote);
        void Supprimer(int idUser, int idJeu, int idPlateforme);
        List<Vote> Lister(string filtre);
        Vote? Obtenir(int idUser, int idJeu, int idPlateforme);

        List<string> ValiderVote(Vote vote);
    }
}
