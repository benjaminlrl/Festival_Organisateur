public class JeuException : Exception
{
    public int CodeErreur { get; }

    public enum JeuErreur
    {
        TitreRequis = 1,
        DescriptionRequise = 2,
        DescriptionTropLongue = 3,
        EditeurRequis = 4,
        DateSortieRequise = 5,
        PegiInvalide = 6,
        TitreExistant = 7
    }

    public JeuException(string message, int codeErreur) : base(message)
    {
        CodeErreur = codeErreur;
    }
}