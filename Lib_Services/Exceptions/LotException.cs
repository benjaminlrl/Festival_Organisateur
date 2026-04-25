public class LotException : Exception
{
    public int CodeErreur { get; }

    public enum LotErreur
    {
        LibelleRequis = 1,
        LibelleTropLong = 2,
        RangNegatif = 3
    }

    public LotException(string message, int codeErreur) : base(message)
    {
        CodeErreur = codeErreur;
    }
}