using System;

namespace Lib_Services.Exceptions
{
    public class TournoiException : Exception
    {
        public int CodeErreur { get; }

        public enum TournoiErreur
        {
            TournoiNomRequis = 1,
            TournoiNomExiste = 2,
            TournoiJeuRequis = 3,
            TournoiEspaceRequis = 4,
            TournoiNbParticipantsInvalide = 5,
            TournoiStatutRequis = 6,
            TournoiConflitHoraire = 7,
            TournoiHoraireInvalide = 8,
            TournoiInexistantEnBaseDeDonnee = 9,
            TournoiAucuneModification = 11,
            TournoiJeuModifier = 12,
            TournoiStatutTermineModifier = 13,
            TournoiAjoutHorairePassee = 14,
        }

        public TournoiException(string message, int codeErreur) : base(message)
        {
            CodeErreur = codeErreur;
        }
    }
}