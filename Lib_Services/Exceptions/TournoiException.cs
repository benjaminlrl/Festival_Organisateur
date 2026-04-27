using System;

namespace Lib_Services.Exceptions
{
    public class TournoiException : Exception
    {
        public int CodeErreur { get; }

        public enum TournoiErreur
        {
            //-------------------
            // Exceptions communes à la création et à la modification d'un espace
            //-------------------
            TournoiNull = 0,
            TournoiInexistant = 1,
            TournoiNomRequis = 2,
            TournoiNomExiste = 3,
            TournoiJeuRequis = 4,
            TournoiEspaceRequis = 5,
            TournoiNbParticipantsInvalide = 6,
            TournoiStatutRequis = 7,
            TournoiConflitHoraire = 8,
            TournoiHoraireInvalide = 9,
            TournoiDureeInvalide = 21,
            TournoiInexistantEnBaseDeDonnee = 10,
            TournoiAucuneModification = 11,
            TournoiJeuModifier = 12,
            TournoiStatutTermineModifier = 13,
            TournoiAjoutHorairePassee = 14,
            TournoiNbParticipantsInscrits = 20,

            //-------------------
            // Exceptions uniques à la modification d'un tournoi
            //-------------------
            ModificationTournoiInexistantDb = 9,
            ModificationTournoiAucuneModification = 10,
            ModificationTournoiNumero = 11,
            ModificationTournoiJeu = 12,
            ModificationTournoiStatutTermineModifier = 13,
            ModificationTournoiStatutEncoursModifier = 14,
            ModificationTournoiDbUpdateException = 22,
            ModificationTournoiException = 23,

            //-------------------
            // Exceptions uniques à la suppression d'un tournoi
            //-------------------
            SuppressionTournoiParticipantsExistant = 15,
            SuppressionTournoiDbException = 18,
            SuppressionTournoiException = 19,
            SuppressionTournoiLotExistant = 20,
        }

        public TournoiException(string message, int codeErreur) : base(message)
        {
            CodeErreur = codeErreur;
        }
    }
}