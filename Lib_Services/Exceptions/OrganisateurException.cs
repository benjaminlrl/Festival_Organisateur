public class OrganisateurException : Exception
{
    public int CodeErreur { get; }

    public enum OrganisateurErreur
    {
        LibelleTropLong = 2,
        LibelleTropCourt = 3,
        MdpEspace = 4,
        MdpTropCourt = 5,
        MdpPasDeMajuscule = 6,
        MdpPasDeChiffre = 7,
        MdpPasDeCaractereSpecial = 8,
        LoginExistant = 9,
    }

    public OrganisateurException(string message, int codeErreur) : base(message)
    {
        CodeErreur = codeErreur;
    }
}