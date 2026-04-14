using Lib_Entities.Entities;
using Lib_Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Services
{
    [TestClass]
    public class EspaceServiceValidationTests
    {
        private readonly EspaceService _service = new EspaceService(null!);

        // ==========================================================================
        // Cas sans erreur 
        // ==========================================================================

        [TestMethod]
        public void EspaceValide_RetourneAucuneErreur()
        {
            var espace = new Espace { Nom = "Salle Alpha", Description = "Une description", Superficie = 30, CapaciteMaxi = 20 };
            Assert.IsEmpty(_service.ValiderEspace(espace));
        }

        // ==========================================================================
        // Nom 
        // ==========================================================================

        [TestMethod]
        [DataRow("")]
        [DataRow("   ")]
        public void NomVideOuBlanc_RetourneErreur(string nom)
        {
            var espace = new Espace { Nom = nom, Description = "Une description", Superficie = 20, CapaciteMaxi = 10 };
            CollectionAssert.Contains(_service.ValiderEspace(espace), "Le nom est requis.");
        }
        // ==========================================================================
        // Description 
        // ==========================================================================
        [TestMethod]
        [DataRow("")]
        [DataRow("   ")]
        public void DescriptionVideOuBlanche_RetourneErreur(string description)
        {
            var espace = new Espace { Nom = "Salle Alpha", Description = description, Superficie = 20, CapaciteMaxi = 10 };
            CollectionAssert.Contains(_service.ValiderEspace(espace), "La description est requise.");
        }

        // ==========================================================================
        // Service 
        // ==========================================================================

        [TestMethod]
        [DataRow(8)]
        [DataRow(61)]
        public void SuperficieHorsLimites_RetourneErreur(int superficie)
        {
            var espace = new Espace { Nom = "Salle Alpha", Description = "Une description", Superficie = superficie, CapaciteMaxi = 10 };
            Assert.IsTrue(_service.ValiderEspace(espace).Any(e => e.Contains("superficie")));
        }

        [TestMethod]
        [DataRow(9)]
        [DataRow(60)]
        public void SuperficieLimites_RetourneAucuneErreurSuperficie(int superficie)
        {
            var espace = new Espace { Nom = "Salle Alpha", Description = "Une description", Superficie = superficie, CapaciteMaxi = 10 };
            Assert.IsFalse(_service.ValiderEspace(espace).Any(e => e.Contains("superficie")));
        }

        // ==========================================================================
        // Capacité et superficie maximale 
        // ==========================================================================

        [TestMethod]
        [DataRow(-1)]
        [DataRow(-100)]
        public void CapaciteMaxiNegative_RetourneErreur(int capacite)
        {
            var espace = new Espace { Nom = "Salle Alpha", Description = "Une description", Superficie = 20, CapaciteMaxi = capacite };
            CollectionAssert.Contains(_service.ValiderEspace(espace), "La capacité maximale doit être positive.");
        }

        [TestMethod]
        [DataRow(51)]
        [DataRow(100)]
        public void CapaciteMaxiSuperieure50_RetourneErreur(int capacite)
        {
            var espace = new Espace { Nom = "Salle Alpha", Description = "Une description", Superficie = 20, CapaciteMaxi = capacite };
            CollectionAssert.Contains(_service.ValiderEspace(espace), "La superficie ne peut pas être supérieur à 50.");
        }

        // ==========================================================================
        // Erreur multiples
        // ==========================================================================

        [TestMethod]
        public void ToutesLesProprietesInvalides_RetourneToutesLesErreurs()
        {
            var espace = new Espace { Nom = "", Description = "", Superficie = 0, CapaciteMaxi = -1 };
            var erreurs = _service.ValiderEspace(espace);
            CollectionAssert.Contains(erreurs, "Le nom est requis.");
            CollectionAssert.Contains(erreurs, "La description est requise.");
            CollectionAssert.Contains(erreurs, "La superficie ne peut pas être inférieur à 9.");
            CollectionAssert.Contains(erreurs, "La capacité maximale doit être positive.");
        }
    }
}