public class LotException : Exception
{
    public int CodeErreur { get; }

    public enum LotErreur
    {
        LibelleVide = 1,
        TournoiVide = 2,
        LibelleTropLong = 3,
        RangNegatif = 4,
        LotInexistant = 5,
    }

    public LotException(string message, int codeErreur) : base(message)
    {
        CodeErreur = codeErreur;
    }
}