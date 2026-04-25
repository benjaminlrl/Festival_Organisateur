public class PlateformeException : Exception
{
    public int CodeErreur { get; }

    public enum PlateformeErreur
    {
        LibelleRequis = 1,
        IdInvalide = 2,
        LibelleExistant = 3
    }

    public PlateformeException(string message, int codeErreur) : base(message)
    {
        CodeErreur = codeErreur;
    }
}