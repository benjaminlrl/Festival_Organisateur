public class ParticiperException : Exception
{
    public int CodeErreur { get; }

    public enum ParticiperErreur
    {       
        
        
        //-------------------
        // Exceptions communes à la création et à la modification
        //-------------------
        ParticiperNull = 0,
        ParticiperInexistant = 1,
        ParticiperEvaluationInvalide = 2,
        ParticiperCommentaireTropLong = 3,
        ParticiperTournoiInexistant = 4,
        ParticiperParticipationTournoiChevauchee = 5,
        ParticiperRangNegatif = 6,
        ParticiperRangInvalide = 7,
        ParticiperScoreNegatif = 8,

        //-------------------
        // Exceptions uniques à la modification
        //-------------------
        ModificationParticiperInexistant = 9,
        ModificationParticiperId = 10,
        ModificationParticiperAucune = 11,
        ModificationDateInscription = 12,
        ParticiperRangInvalideTournoiNonTermine = 13,
        ModificationParticiperScoreFinal = 14,
        ModificationParticiperUtilisateur = 15,
        ModificationParticiperLotRemisParDefaut = 16,

        //-------------------
        // Exceptions uniques à la suppression
        //-------------------
        SuppressionParticiperTournoiExistant = 17,
        SuppressionParticiperForcerTournoiEnCours = 18,
        SuppressionParticiperDbUpdateException = 19,
        SuppressionParticiperException = 20,

        //-------------------
        // Exceptions uniques à l'ajout
        //-------------------
        AjoutParticiperDejaParticipant = 21,
        AjoutParticiperTournoiComplet = 22,
        AjoutParticiperTournoiTermine = 23,
        AjoutParticiperTournoiEnCours = 24,
        AjoutParticiperRangInvalide = 25,
        AjoutParticiperLotRemisParDefaut = 26,
        AjoutParticiperScoreNegatif = 27,
        AjoutParticiperException = 28,
        AjoutParticiperDbUpdateException = 29,

    }

    public ParticiperException(string message, int codeErreur) : base(message)
    {
        CodeErreur = codeErreur;
    }
}