using System;

namespace Lib_Services.Exceptions
{
    public class JeuSoumisVoteException : Exception
    {
        public int CodeErreur { get; }

        public enum JeuSoumisVoteErreur
        {
            JeuInexistant = 1,
            PlateformeInexistante = 2,
            DoublonJeuSoumisVote = 3,
            AucuneModification = 4,
            DateDebutSuperieureFin = 5,
            DateDebutDansLePasse = 6,
            DateFinDansLePasse = 7
        }

        public JeuSoumisVoteException(string message, int codeErreur) : base(message)
        {
            CodeErreur = codeErreur;
        }
    }
}