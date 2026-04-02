using Lib_Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Services.Interfaces
{
    public interface IParticiperService
    {
        void Creer(Participer participer);
        void Modifier(Participer participer);
        void Supprimer(int idUser, int numeroTournoi);
        List<Participer> Lister(string filtre);
        Participer? Obtenir(int idUser, int numeroTournoi);
    }
}
