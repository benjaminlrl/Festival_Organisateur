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
        void Supprimer(int idJeu, int idPlateforme, int idUser);
        List<Voter> Lister(string filtre);
        List<Voter> ListerPourUnUtilisateur(int idUser);
        Voter? Obtenir(int idJeu, int idPlateforme, int idUser);

        List<string> ValiderVote(Voter vote);
    }
}
