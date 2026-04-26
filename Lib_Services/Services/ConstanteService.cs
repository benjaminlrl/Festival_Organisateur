using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Services.Services
{
    public static class ConstanteService
    {
        public static class Voter
        {
            public const int NbMaxVotesParJoueur = 5;
        }

        public enum PEGI
        {
            Pegi3 = 3,
            Pegi7 = 7,
            Pegi12 = 12,
            Pegi16 = 16,
            Pegi18 = 18
        }
    }
}
