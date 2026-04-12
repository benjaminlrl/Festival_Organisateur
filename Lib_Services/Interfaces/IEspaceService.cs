using Lib_Entities.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Lib_Services.Interfaces
{
    public interface IEspaceService
    {
        void Creer(Espace espace);
        void Modifier(Espace espace);
        void Supprimer(int idEspace);
        List<Espace> Lister(string filtre = "", string colonne = "Nom", string ordre = "ASC");
        Espace? Obtenir(int idEspace);
        List<string> ValiderEspace(Espace espace);
        int CompterEspacesDisponibles(string filtre);
        public int CompterEspacesTotal(string filtre);
    }
}
