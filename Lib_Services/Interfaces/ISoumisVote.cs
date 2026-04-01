using Lib_Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Services.Interfaces
{
    public interface ISoumisVoteService
    {
        void Creer(SoumisVote soumisVote);
        void Modifier(SoumisVote soumisVote);
        void Supprimer(int idJeu, int idPlateforme);
        List<SoumisVote> Lister(string filtre);
        SoumisVote? Obtenir(int idJeu, int idPlateforme);

        List<string> ValiderSoumisVote(SoumisVote soumisVote);
    }
}
