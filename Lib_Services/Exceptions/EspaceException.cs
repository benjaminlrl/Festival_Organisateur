public class EspaceException : Exception
{
    public int CodeErreur { get; }

    public enum EspaceErreur
    {
        NomRequis = 1,
        DescriptionRequise = 2,
        SuperficieInsuffisante = 3,
        SuperficieTropGrande = 4,
        CapaciteNegative = 5,
        CapaciteTropGrande = 6
    }

    public EspaceException(string message, int codeErreur) : base(message)
    {
        CodeErreur = codeErreur;
    }
}