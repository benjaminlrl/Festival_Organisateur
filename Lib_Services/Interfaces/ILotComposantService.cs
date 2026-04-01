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
        List<LotComposant> Lister(string filtre);
        List<LotComposant> ListerParNumeroDunLot(int numero);
        LotComposant? Obtenir(int numero);
        List<string> LotComposantValide(LotComposant lotComposant);
    }
}
