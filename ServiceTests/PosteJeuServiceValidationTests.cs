using Lib_Entities.Entities;
using Lib_Metier.Data.Configurations;
using Lib_Services.Services;
using Microsoft.EntityFrameworkCore;

[TestClass]
public class PosteJeuServiceValidationTests
{
    private PosteJeuService _service = null!;
    private ApplicationDbContext _context = null!;

    [TestInitialize]
    public void Init()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new ApplicationDbContext(options);
        _service = new PosteJeuService(_context);
    }

    [TestCleanup]
    public void Cleanup() => _context.Dispose();

    // =========================================================================
    // Cas nominal
    // =========================================================================

    [TestMethod]
    public void PosteJeuValide_AucuneException()
    {
        PosteJeu poste = new() { NumeroPoste = 1, IdEspace = 1, IdPlateforme = 1, Fonctionnel = true };
        poste.SetReference(new Espace { IdEspace = 1, Nom = "Nintendo" }, poste.NumeroPoste);

        _service.ValiderPosteJeu(poste);
    }

    // =========================================================================
    // Référence
    // =========================================================================

    [TestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void ReferenceVideOuBlanche_ThrowPosteJeuException(string reference)
    {
        PosteJeu poste = new() { Reference = reference, NumeroPoste = 1, IdEspace = 1, IdPlateforme = 1, Fonctionnel = true };

        PosteJeuException ex = Assert.Throws<PosteJeuException>(
            () => _service.ValiderPosteJeu(poste));

        Assert.AreEqual("La référence du poste de jeu est obligatoire.", ex.Message);
        Assert.AreEqual((int)PosteJeuException.PosteJeuErreur.ReferenceRequise, ex.CodeErreur);
    }

    [TestMethod]
    public void ReferenceDejaExistante_AutreNumero_ThrowPosteJeuException()
    {
        // Arrange — poste existant en BDD
        PosteJeu poste1 = new() { NumeroPoste = 1, IdEspace = 1, IdPlateforme = 1, Fonctionnel = true };
        poste1.SetReference(new Espace { IdEspace = 1, Nom = "Nintendo" }, 1);
        _context.PostesJeu.Add(poste1);
        _context.SaveChanges();

        // Nouveau poste avec la même référence mais numéro différent
        PosteJeu poste2 = new() { NumeroPoste = 2, IdEspace = 1, IdPlateforme = 1, Fonctionnel = true };
        poste2.SetReference(new Espace { IdEspace = 1, Nom = "Nintendo" }, 1);

        PosteJeuException ex = Assert.Throws<PosteJeuException>(
            () => _service.ValiderPosteJeu(poste2, false));

        Assert.AreEqual("Un poste de jeu avec cette référence existe déjà.", ex.Message);
        Assert.AreEqual((int)PosteJeuException.PosteJeuErreur.ReferenceExistante, ex.CodeErreur);
    }

    // =========================================================================
    // IdEspace
    // =========================================================================

    [TestMethod]
    [DataRow(0)]
    [DataRow(-1)]
    public void IdEspaceInvalide_ThrowPosteJeuException(int idEspace)
    {
        PosteJeu poste = new() { NumeroPoste = 1, IdEspace = idEspace, IdPlateforme = 1, Fonctionnel = true };
        poste.Reference = "PJ-NIN-001";

        PosteJeuException ex = Assert.Throws<PosteJeuException>(
            () => _service.ValiderPosteJeu(poste));

        Assert.AreEqual("L'espace associé est obligatoire.", ex.Message);
        Assert.AreEqual((int)PosteJeuException.PosteJeuErreur.EspaceRequis, ex.CodeErreur);
    }

    [TestMethod]
    public void IdEspaceValide_AucuneException()
    {
        PosteJeu poste = new() { NumeroPoste = 1, IdEspace = 1, IdPlateforme = 1, Fonctionnel = true };
        poste.SetReference(new Espace { IdEspace = 1, Nom = "Nintendo" }, poste.NumeroPoste);
        _service.ValiderPosteJeu(poste);
    }

    // =========================================================================
    // IdPlateforme
    // =========================================================================

    [TestMethod]
    [DataRow(0)]
    [DataRow(-1)]
    public void IdPlateformeInvalide_ThrowPosteJeuException(int idPlateforme)
    {
        PosteJeu poste = new() { NumeroPoste = 1, IdEspace = 1, IdPlateforme = idPlateforme, Fonctionnel = true };
        poste.SetReference(new Espace { IdEspace = 1, Nom = "Nintendo" }, poste.NumeroPoste);

        PosteJeuException ex = Assert.Throws<PosteJeuException>(
            () => _service.ValiderPosteJeu(poste));

        Assert.AreEqual("La plateforme associée est obligatoire.", ex.Message);
        Assert.AreEqual((int)PosteJeuException.PosteJeuErreur.PlateformeRequise, ex.CodeErreur);
    }

    [TestMethod]
    public void IdPlateformeValide_AucuneException()
    {
        PosteJeu poste = new() { NumeroPoste = 1, IdEspace = 1, IdPlateforme = 1, Fonctionnel = true };
        poste.SetReference(new Espace { IdEspace = 1, Nom = "Nintendo" }, poste.NumeroPoste);
        _service.ValiderPosteJeu(poste);
    }

    // =========================================================================
    // Modification — Aucune modification détectée
    // =========================================================================

    [TestMethod]
    public void Modification_AucuneModification_ThrowPosteJeuException()
    {
        PosteJeu poste = new() { NumeroPoste = 1, IdEspace = 1, IdPlateforme = 1, Fonctionnel = true };
        poste.SetReference(new Espace { IdEspace = 1, Nom = "Nintendo" }, 1);
        _context.PostesJeu.Add(poste);
        _context.SaveChanges();

        PosteJeu memePoste = new() { NumeroPoste = 1, IdEspace = 1, IdPlateforme = 1, Fonctionnel = true };
        memePoste.SetReference(new Espace { IdEspace = 1, Nom = "Nintendo" }, 1);

        PosteJeuException ex = Assert.Throws<PosteJeuException>(
            () => _service.ValiderPosteJeu(memePoste, true));

        Assert.AreEqual((int)PosteJeuException.PosteJeuErreur.AucuneModification, ex.CodeErreur);
    }

    // =========================================================================
    // Modification — Espace différent
    // =========================================================================

    [TestMethod]
    public void Modification_EspaceDifferent_ThrowPosteJeuException()
    {
        PosteJeu poste = new() { NumeroPoste = 1, IdEspace = 1, IdPlateforme = 1, Fonctionnel = true };
        poste.SetReference(new Espace { IdEspace = 1, Nom = "Nintendo" }, 1);
        _context.PostesJeu.Add(poste);
        _context.SaveChanges();

        PosteJeu posteModifie = new() { NumeroPoste = 1, IdEspace = 2, IdPlateforme = 1, Fonctionnel = true };
        posteModifie.SetReference(new Espace { IdEspace = 2, Nom = "Sony" }, 1);

        PosteJeuException ex = Assert.Throws<PosteJeuException>(
            () => _service.ValiderPosteJeu(posteModifie, true));

        Assert.AreEqual((int)PosteJeuException.PosteJeuErreur.EspaceDifferent, ex.CodeErreur);
    }
}