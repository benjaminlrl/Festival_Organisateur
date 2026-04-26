public class PlateformeException : Exception
{
    public int CodeErreur { get; }

    public enum PlateformeErreur
    {
        LibelleRequis = 1,
        IdInvalide = 2,
        LibelleExistant = 3,
        PostesDeJeuExistant = 4,
        JeuxExistant = 5,
        AucuneModification = 6,
    }

    public PlateformeException(string message, int codeErreur) : base(message)
    {
        CodeErreur = codeErreur;
    }
}