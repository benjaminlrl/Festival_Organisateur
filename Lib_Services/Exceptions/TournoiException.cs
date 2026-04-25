using System;

namespace Lib_Services.Exceptions
{
    public class TournoiException : Exception
    {
        public int CodeErreur { get; }

        public enum TournoiErreur
        {
            NomRequis = 1,
            JeuRequis = 2,
            EspaceRequis = 3,
            NbParticipantsInvalide = 4,
            StatutRequis = 5,
            ConflitHoraire = 6,
            HoraireInvalide = 7
        }

        public TournoiException(string message, int codeErreur) : base(message)
        {
            CodeErreur = codeErreur;
        }
    }
}