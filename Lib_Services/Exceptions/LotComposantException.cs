public class LotComposantException : Exception
{
    public int CodeErreur { get; }

    public enum LotComposantErreur
    {
        // Exception concernant la création ou la modification
        LibelleVide = 1,
        DescriptionVide = 2,
        LotVide = 3,
        ValeurNegative = 4,
        ValeurZero = 5,
        ValeurTropGrande = 6,
        LibelleTropLong = 7,
        DescriptionTropLongue = 8,

        // Exception concernant la suppression
        SuppressionLotComposantInexistant = 9,
    }

    public LotComposantException(string message, int codeErreur) : base(message)
    {
        CodeErreur = codeErreur;
    }
}