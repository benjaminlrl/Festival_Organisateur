using Lib_Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Services.Interfaces
{
    public interface IOrganisateurService
    {
        void Creer(Organisateur organisateur);
        void Modifier(Organisateur organisateur);
        void Supprimer(string Login);
        List<Organisateur> Lister();
        Organisateur? Obtenir(string Login);
        bool EstIdentique(string motPasse, string Login);
    }
}
