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
        EspaceNomRequis = 2,
        EspaceDescriptionRequise = 3,
        EspaceSuperficieInsuffisante = 4,
        EspaceSuperficieTropGrande = 5,
        EspaceCapaciteNegative = 6,
        EspaceCapaciteTropGrande = 7,
        EspaceNomExiste = 8,
        EspaceNomExistePostesJeu = 12,

        //-------------------
        // Exceptions uniques à la modification d'un espace
        //-------------------
        ModificationEspaceInexistant = 9,
        ModificationEspaceId = 10,
        ModificationEspaceAucune = 11,
        ModificationEspaceNomLettresExistePostesJeu = 13,
        ModificationEspacePosteJeuEspaceNom = 14,
        ModificationEspaceAucunPosteJeu = 15,

        //-------------------
        // Exceptions uniques à la suppression d'un espace
        //-------------------
        SuppressionEspaceTournoiExistant = 16,
        SuppressionEspacePosteJeuExistant = 17,
        SuppressionEspaceDbUpdateException = 18,
        SuppressionEspaceException = 19,
        SuppressionEspacePosteJeuErreur = 20,
        SuppressionEspacePosteJeuDbErreur = 21,

        //-------------------
        // Exceptions uniques à l'ajout d'un jeu
        //-------------------
        AjoutEspaceException = 17,
        AjoutEspaceDbUpdateException = 18,
    }

    public EspaceException(string message, int codeErreur) : base(message)
    {
        CodeErreur = codeErreur;
    }
}