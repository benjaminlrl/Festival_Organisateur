using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationUi
{
    public class Validations
    {
        public static string MdpValide(string motDePasse)
        {
            if (motDePasse.Length < 12)
                return "Le mot de passe doit contenir plus de 12 caractères.";
            if (motDePasse.Any(char.IsUpper) == false)
                return "Le mot de passe doit contenir au moins 1 majuscule.";
            if (motDePasse.Any(char.IsDigit) == false)
                return "Le mot de passe doit contenir au moins 1 chiffre.";
            if (motDePasse.Any(ch => !char.IsLetterOrDigit(ch)) == false)
                return "Le mot de passe doit contenir au moins 1 caractère spéciale.";
            return "true";
        }

        public static bool IdentifiantValide(string identifiant)
        {
            if (identifiant.Length < 3 || identifiant.Length > 12)
                return false;
            return true;
        }
    }
}
