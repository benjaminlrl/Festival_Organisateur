public class PosteJeuException : Exception
{
    public int CodeErreur { get; }

    public enum PosteJeuErreur
    {
        ReferenceRequise = 1,
        EspaceRequis = 2,
        PlateformeRequise = 3,
        ReferenceExistante = 4
    }

    public PosteJeuException(string message, int codeErreur) : base(message)
    {
        CodeErreur = codeErreur;
    }
}