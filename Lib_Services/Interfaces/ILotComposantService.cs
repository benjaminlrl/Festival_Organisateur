using Lib_Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Services.Interfaces
{
    public interface ILotComposantService
    {
        void Creer(LotComposant lotComposant);
        void Modifier(LotComposant lotComposant);
        void Supprimer(int numero);
        List<LotComposant> Lister();
        LotComposant? Obtenir(int numero);
    }
}
