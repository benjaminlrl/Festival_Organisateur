using Lib_Entities.Entities;
using Lib_Metier.Data.Configurations;
using Lib_Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Services
{
    [TestClass]
    public class PosteJeuServiceValidationTests
    {
        private readonly PosteJeuService _service = new PosteJeuService(null!);

        // =========================================================================
        // Cas nominal
        // =========================================================================

        [TestMethod]
        public void PosteJeuValide_RetourneAucuneErreur()
        {
            var poste = new PosteJeu { Reference = "PJ-01", NumeroPoste = 1, IdEspace = 1, IdPlateforme = 1, Fonctionnel = true };
            Assert.IsEmpty(_service.ValiderPosteJeu(poste));
        }

        // =========================================================================
        // Référence
        // =========================================================================

        [TestMethod]
        [DataRow("")]
        [DataRow("   ")]
        public void ReferenceVideOuBlanche_RetourneErreur(string reference)
        {
            var poste = new PosteJeu { Reference = reference, NumeroPoste = 1, IdEspace = 1, IdPlateforme = 1, Fonctionnel = true };
            CollectionAssert.Contains(_service.ValiderPosteJeu(poste), "La référence du poste de jeu est obligatoire.");
        }

        [TestMethod]
        public void ReferenceDejaExistante_AutreNumero_RetourneErreur()
        {

            // Nouveau poste avec la même référence mais numéro différent
            var poste = new PosteJeu { NumeroPoste = 2, Reference = "PC-01", IdEspace = 1, IdPlateforme = 1, Fonctionnel = true };
            CollectionAssert.Contains(_service.ValiderPosteJeu(poste), "Un poste de jeu avec cette référence existe déjà.");
        }

        [TestMethod]
        public void ReferenceDejaExistante_MemeNumero_PasErreur()
        {
            var poste = new PosteJeu { NumeroPoste = 1, Reference = "PC-01", IdEspace = 1, IdPlateforme = 1, Fonctionnel = true };
            CollectionAssert.DoesNotContain(_service.ValiderPosteJeu(poste), "Un poste de jeu avec cette référence existe déjà.");
        }

        // =========================================================================
        // NumeroPoste
        // =========================================================================

        [TestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(-100)]
        public void NumeroPosteInvalide_RetourneErreur(int numero)
        {
            var poste = new PosteJeu { Reference = "PC-01", NumeroPoste = numero, IdEspace = 1, IdPlateforme = 1, Fonctionnel = true };
            CollectionAssert.Contains(_service.ValiderPosteJeu(poste), "Le numéro du poste doit être supérieur à zéro.");
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(10)]
        public void NumeroPosteValide_PasErreur(int numero)
        {
            var poste = new PosteJeu { Reference = "PC-01", NumeroPoste = numero, IdEspace = 1, IdPlateforme = 1, Fonctionnel = true };
            CollectionAssert.DoesNotContain(_service.ValiderPosteJeu(poste), "Le numéro du poste doit être supérieur à zéro.");
        }

        // =========================================================================
        // IdEspace
        // =========================================================================

        [TestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        public void IdEspaceInvalide_RetourneErreur(int idEspace)
        {
            var poste = new PosteJeu { Reference = "PC-01", NumeroPoste = 1, IdEspace = idEspace, IdPlateforme = 1, Fonctionnel = true };
            CollectionAssert.Contains(_service.ValiderPosteJeu(poste), "L'espace associé est obligatoire.");
        }

        [TestMethod]
        public void IdEspaceValide_PasErreur()
        {
            var poste = new PosteJeu { Reference = "PC-01", NumeroPoste = 1, IdEspace = 1, IdPlateforme = 1, Fonctionnel = true };
            CollectionAssert.DoesNotContain(_service.ValiderPosteJeu(poste), "L'espace associé est obligatoire.");
        }

        // =========================================================================
        // IdPlateforme
        // =========================================================================

        [TestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        public void IdPlateformeInvalide_RetourneErreur(int idPlateforme)
        {
            var poste = new PosteJeu { Reference = "PC-01", NumeroPoste = 1, IdEspace = 1, IdPlateforme = idPlateforme, Fonctionnel = true };
            CollectionAssert.Contains(_service.ValiderPosteJeu(poste), "La plateforme associée est obligatoire.");
        }

        [TestMethod]
        public void IdPlateformeValide_PasErreur()
        {
            var poste = new PosteJeu { Reference = "PC-01", NumeroPoste = 1, IdEspace = 1, IdPlateforme = 1, Fonctionnel = true };
            CollectionAssert.DoesNotContain(_service.ValiderPosteJeu(poste), "La plateforme associée est obligatoire.");
        }

        // =========================================================================
        // Erreurs multiples
        // =========================================================================

        [TestMethod]
        public void ToutesLesProprietesInvalides_RetourneToutesLesErreurs()
        {
            var poste = new PosteJeu { Reference = "", NumeroPoste = 0, IdEspace = 0, IdPlateforme = 0, Fonctionnel = true };
            var erreurs = _service.ValiderPosteJeu(poste);
            CollectionAssert.Contains(erreurs, "La référence du poste de jeu est obligatoire.");
            CollectionAssert.Contains(erreurs, "Le numéro du poste doit être supérieur à zéro.");
            CollectionAssert.Contains(erreurs, "L'espace associé est obligatoire.");
            CollectionAssert.Contains(erreurs, "La plateforme associée est obligatoire.");
        }
    }
}