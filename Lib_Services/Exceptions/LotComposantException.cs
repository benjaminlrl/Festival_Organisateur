public class LotComposantException : Exception
{
    public int CodeErreur { get; }

    public enum LotComposantErreur
    {
        LibelleVide = 1,
        DescriptionVide = 2,
        LotVide = 3,
        ValeurNegative = 4,
        LibelleTropLong = 5,
        DescriptionTropLongue = 6,
        LotComposantInexistant = 7,
    }

    public LotComposantException(string message, int codeErreur) : base(message)
    {
        CodeErreur = codeErreur;
    }
}