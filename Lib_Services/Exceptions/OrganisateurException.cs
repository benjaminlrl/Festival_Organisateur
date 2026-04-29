public class OrganisateurException : Exception
{
    public int CodeErreur { get; }

    public enum OrganisateurErreur
    {
        // Exception concernant la création ou la modification
        LoginVide = 1,
        MailVide = 2,
        MdpVide = 3,
        RoleVide = 4,
        MdpEspace = 5,
        MdpTropCourt = 6,
        MdpPasDeMajuscule = 7,
        MdpPasDeChiffre = 8,
        MdpPasDeCaractereSpecial = 9,
        LoginExistant = 10,
        LoginTropLong = 11,
        LoginTropCourt = 12,
        MailExistant = 13,

        // Exception concernant la suppression
        OrganisateurInexistant = 14,
        OrganisateurEstAdmin = 15,
    }

    public OrganisateurException(string message, int codeErreur) : base(message)
    {
        CodeErreur = codeErreur;
    }
}