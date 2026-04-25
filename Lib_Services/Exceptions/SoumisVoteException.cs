using System;

namespace Lib_Services.Exceptions
{
    public class SoumisVoteException : Exception
    {
        public int CodeErreur { get; }

        public enum SoumisVoteErreur
        {
            JeuInexistant = 1,
            PlateformeInexistante = 2,
            DoublonSoumisVote = 3,
            AucuneModification = 4,
            DateDebutSuperieureFin = 5,
            DateDebutDansLePasse = 6,
            DateFinDansLePasse = 7
        }

        public SoumisVoteException(string message, int codeErreur) : base(message)
        {
            CodeErreur = codeErreur;
        }
    }
}