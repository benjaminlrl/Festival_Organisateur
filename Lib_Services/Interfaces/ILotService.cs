using Lib_Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Services.Interfaces
{
    public interface ILotService
    {
        void Creer(Lot lot);
        void Modifier(Lot lot);
        void Supprimer(int numero);
        List<Lot> Lister();
        Lot? Obtenir(int numero);
    }
}
