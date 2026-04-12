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
        List<Tournoi> ListerTournoisTerminesEspace(int idEspace);
        List<Tournoi> ListerTournoisEnCoursEspace(int idEspace);
        List<Tournoi> ListerTournoisPlanifiesEspace(int idEspace);

        Tournoi? Obtenir(int numeroTournoi);

        List<string> ValiderTournoi(Tournoi tournoi);
    }
}
