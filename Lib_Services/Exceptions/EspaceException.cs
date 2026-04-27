public class EspaceException : Exception
{
    public int CodeErreur { get; }

    public enum EspaceErreur
    {
        //-------------------
        // Exceptions communes à la création et à la modification d'un espace
        //-------------------
        EspaceNull = 0,
        EspaceInexistant = 1,
        NomRequis = 2,
        DescriptionRequise = 3,
        SuperficieInsuffisante = 4,
        SuperficieTropGrande = 5,
        CapaciteNegative = 6,
        CapaciteTropGrande = 7,
        NomExiste = 8,
        NomExistePostesJeu = 12,

        //-------------------
        // Exceptions uniques à la modification d'un espace
        //-------------------
        ModificationEspaceInexistant = 9,
        ModificationEspaceId = 10,
        ModificationEspaceAucune = 11,
        ModificationNomExistePostesJeu = 13,
        ModificationPosteJeuEspaceNom = 14,
        ModificationAucunPosteJeu = 15,

        //-------------------
        // Exceptions uniques à la suppression d'un espace
        //-------------------
        SuppressionEspaceTournoiExistant = 16,
        SuppressionEspacePosteJeuExistant = 17,
        SuppressionEspaceDbUpdateException = 18,
        SuppressionEspaceException = 19,
    }

    public EspaceException(string message, int codeErreur) : base(message)
    {
        CodeErreur = codeErreur;
    }
}