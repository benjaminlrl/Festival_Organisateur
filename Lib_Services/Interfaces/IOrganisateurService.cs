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
        List<Organisateur> Lister(string filtre);
        Organisateur? Obtenir(string Login);
        bool EstIdentique(string motDePasse, string Login);
        bool estAutoriser(Organisateur organisateur, Organisateur.LesUC unUC, string action);
        List<string> MdpValide(string motDePasse);
        List<string> IdentifiantValide(string identifiant);
    }
}
