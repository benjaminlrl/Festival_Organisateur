public class ParticiperException : Exception
{
    public int CodeErreur { get; }

    public enum ParticiperErreur
    {
        DejaParticipant = 1,
        ScoreNegatif = 2,
        RangNegatif = 3,
        EvaluationInvalide = 4,
        CommentaireTropLong = 5,
        TournoiInexistant = 6,
        TournoiComplet = 7,
        TournoiTermine = 8,
        TournoiEnCours = 9,
        AucuneModification = 10,
        ModificationUtilisateur = 11,
        ModificationDateInscription = 12,
        RangInvalideTournoiNonTermine = 13,
        RangInvalide = 14,
        LotRemisParDefaut = 15,
        ScoreFinal = 16,
        ParticipationTournoiChevauchee = 17,

    }

    public ParticiperException(string message, int codeErreur) : base(message)
    {
        CodeErreur = codeErreur;
    }
}