using System.ComponentModel.DataAnnotations;
using ApplicationUi;
using Lib_Services;

namespace ApplicationUI.TestUnits
{
    [TestClass]
    public sealed class ValidationTests
    {
        // Tests MdpValide

        [TestMethod]
        public void MdpValide_MoinsDe12Caracteres_RetourneErreur()
        {
            string resultat = Validations.MdpValide("Court1!");
            Assert.AreEqual("Le mot de passe doit contenir plus de 12 caractères.", resultat);
        }

        [TestMethod]
        public void MdpValide_SansMajuscule_RetourneErreur()
        {
            string resultat = Validations.MdpValide("motdepasse123!");
            Assert.AreEqual("Le mot de passe doit contenir au moins 1 majuscule.", resultat);
        }

        [TestMethod]
        public void MdpValide_SansChiffre_RetourneErreur()
        {
            string resultat = Validations.MdpValide("MotDePasseLong!");
            Assert.AreEqual("Le mot de passe doit contenir au moins 1 chiffre.", resultat);
        }

        [TestMethod]
        public void MdpValide_SansCaractereSpecial_RetourneErreur()
        {
            string resultat = Validations.MdpValide("MotDePasseLong1");
            Assert.AreEqual("Le mot de passe doit contenir au moins 1 caractère spéciale.", resultat);
        }

        [TestMethod]
        public void MdpValide_MdpValide_RetourneTrue()
        {
            string resultat = Validations.MdpValide("MotDePasse123!");
            Assert.AreEqual("true", resultat);
        }

        // Tests IdentifiantValide

        [TestMethod]
        public void IdentifiantValide_MoinsDe3Caracteres_RetourneFalse()
        {
            bool resultat = Validations.IdentifiantValide("ab");
            Assert.IsFalse(resultat);
        }

        [TestMethod]
        public void IdentifiantValide_PlusDe12Caracteres_RetourneFalse()
        {
            bool resultat = Validations.IdentifiantValide("IdentifiantTropLong");
            Assert.IsFalse(resultat);
        }

        [TestMethod]
        public void IdentifiantValide_IdentifiantValide_RetourneTrue()
        {
            bool resultat = Validations.IdentifiantValide("MonLogin");
            Assert.IsTrue(resultat);
        }

        [TestMethod]
        public void IdentifiantValide_Exactement3Caracteres_RetourneTrue()
        {
            bool resultat = Validations.IdentifiantValide("abc");
            Assert.IsTrue(resultat);
        }

        [TestMethod]
        public void IdentifiantValide_Exactement12Caracteres_RetourneTrue()
        {
            bool resultat = Validations.IdentifiantValide("MonLoginLong");
            Assert.IsTrue(resultat);
        }
    }
}
