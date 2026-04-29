public class LotException : Exception
{
    public int CodeErreur { get; }

    public enum LotErreur
    {
        // Exception concernant la création ou la modification
        LibelleVide = 1,
        TournoiVide = 2,
        LibelleTropLong = 3,
        RangNegatif = 4,
        RangZero = 5,
        RangTropGrand = 6,

        // Exception concernant la suppression
        LotInexistant = 7,
    }

    public LotException(string message, int codeErreur) : base(message)
    {
        CodeErreur = codeErreur;
    }
}