using Lib_Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Services.Interfaces
{
    public interface IPlateformeService
    {
        void Creer(Plateforme plateforme);
        void Modifier(Plateforme plateforme);
        void Supprimer(int idplateforme);
        List<Plateforme> Lister(string filtre);
        Plateforme? Obtenir(int idplateforme);
    }
}
