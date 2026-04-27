public class OrganisateurException : Exception
{
    public int CodeErreur { get; }

    public enum OrganisateurErreur
    {
        LoginVide = 1,
        MailVide = 2,
        MdpVide = 3,
        RoleVide = 4,
        LoginTropLong = 5,
        LoginTropCourt = 6,
        MdpEspace = 7,
        MdpTropCourt = 8,
        MdpPasDeMajuscule = 9,
        MdpPasDeChiffre = 10,
        MdpPasDeCaractereSpecial = 11,
        LoginExistant = 12,
        OrganisateurInexistant = 13,
        OrganisateurEstAdmin = 14,
    }

    public OrganisateurException(string message, int codeErreur) : base(message)
    {
        CodeErreur = codeErreur;
    }
}