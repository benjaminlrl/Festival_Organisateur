public class JeuException : Exception
{
    public int CodeErreur { get; }

    public enum JeuErreur
    {
        //-------------------
        // Exceptions communes à la création et à la modification d'un jeu
        //-------------------
        JeuNull = 0,
        JeuInexistant = 1,
        JeuTitreRequis = 2,
        JeuDescriptionRequise = 3,
        JeuDescriptionTropLongue = 4,
        JeuEditeurRequis = 5,
        JeuDateSortieRequise = 6,
        JeuPegiInvalide = 7,
        JeuTitreExistant = 8,

        //-------------------
        // Exceptions uniques à la modification d'un jeu
        //-------------------
        ModificationJeuInexistant = 9,
        ModificationJeuId = 10,
        ModificationJeuAucune = 11,

        //-------------------
        // Exceptions uniques à la suppression d'un jeu
        //-------------------
        SuppressionJeuTournoiExistant = 12,
        SuppressionJeuDbUpdateException = 13,
        SuppressionJeuException = 14,
    }

    public JeuException(string message, int codeErreur) : base(message)
    {
        CodeErreur = codeErreur;
    }
}