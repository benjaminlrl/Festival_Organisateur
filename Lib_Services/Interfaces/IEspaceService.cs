using Lib_Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Services.Interfaces
{
    public interface IEspaceService
    {
        void Creer(Espace espace);
        void Modifier(Espace espace);
        void Supprimer(int idEspace);
        List<Espace> Lister();
        Espace? Obtenir(int idEspace);
    }
}
