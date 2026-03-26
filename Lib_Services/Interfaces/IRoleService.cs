using Lib_Entities.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Lib_Services.Interfaces
{
    public interface IRoleService
    {
        void Creer(Role role);
        void Modifier(Role role);
        void Supprimer(Role role);
        Role? Obtenir(string Libelle);
        List<Role> Lister(string filtre);
    }
}
