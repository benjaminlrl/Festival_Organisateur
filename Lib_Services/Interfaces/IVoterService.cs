using Lib_Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Services.Interfaces
{
    public interface IVoterService
    {
        void Creer(Voter vote);
        void Modifier(Voter vote);
        void Supprimer(int idUser, int idJeu, int idPlateforme);
        List<Voter> Lister(string filtre);
        Voter? Obtenir(int idUser, int idJeu, int idPlateforme);

        List<string> ValiderVote(Voter vote);
    }
}
