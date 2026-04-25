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
        TournoiEnCours = 9
    }

    public ParticiperException(string message, int codeErreur) : base(message)
    {
        CodeErreur = codeErreur;
    }
}