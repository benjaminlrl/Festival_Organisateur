public class LotComposantException : Exception
{
    public int CodeErreur { get; }

    public enum LotComposantErreur
    {
        LibelleRequis = 1,
        LibelleTropLong = 2,
        ValeurNegative = 3,
        DescriptionTropLongue = 4
    }

    public LotComposantException(string message, int codeErreur) : base(message)
    {
        CodeErreur = codeErreur;
    }
}