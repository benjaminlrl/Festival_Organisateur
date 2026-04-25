using System;

namespace Lib_Services.Exceptions
{
    public class TournoiException : Exception
    {
        public int CodeErreur { get; }

        public enum TournoiErreur
        {
            NomRequis = 1,
            NomExiste = 2,
            JeuRequis = 3,
            EspaceRequis = 4,
            NbParticipantsInvalide = 5,
            StatutRequis = 6,
            ConflitHoraire = 7,
            HoraireInvalide = 8
        }

        public TournoiException(string message, int codeErreur) : base(message)
        {
            CodeErreur = codeErreur;
        }
    }
}