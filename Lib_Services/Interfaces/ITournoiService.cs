using Lib_Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Services.Interfaces
{
    public interface ITournoiService
    {
        void Creer(Tournoi tournoi);
        void Modifier(Tournoi tournoi);
        void Supprimer(int numeroTournoi);
        List<Tournoi> Lister(string filtre);
        Tournoi? Obtenir(int numeroTournoi);

        List<string> ValiderTournoi(Tournoi tournoi);
    }
}
