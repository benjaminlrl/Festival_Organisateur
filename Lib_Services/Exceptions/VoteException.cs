using System;

namespace Lib_Services.Exceptions
{
    public class VoteException : Exception
    {
        public int CodeErreur { get; }

        public enum VoteErreur
        {
            UtilisateurInvalide = 1,
            NbVotesMax = 2,
            DejaVote = 3
        }

        public VoteException(string message, int codeErreur) : base(message)
        {
            CodeErreur = codeErreur;
        }
    }
}