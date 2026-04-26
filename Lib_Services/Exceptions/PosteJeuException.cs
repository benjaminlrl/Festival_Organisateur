public class PosteJeuException : Exception
{
    public int CodeErreur { get; }

    public enum PosteJeuErreur
    {
        ReferenceRequise = 1,
        EspaceRequis = 2,
        PlateformeRequise = 3,
        ReferenceExistante = 4,
        AucuneModification = 5,
        EspaceDifferent = 6,
        ModificationPosteInexistante = 7,
        ModificationPostePlateformeDifferente = 8,
        ModificationPosteEspaceDifferent = 9,
    }

    public PosteJeuException(string message, int codeErreur) : base(message)
    {
        CodeErreur = codeErreur;
    }
}