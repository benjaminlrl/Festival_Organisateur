public class LotException : Exception
{
    public int CodeErreur { get; }

    public enum LotErreur
    {
        LibelleTropLong = 1,
        RangNegatif = 2
    }

    public LotException(string message, int codeErreur) : base(message)
    {
        CodeErreur = codeErreur;
    }
}