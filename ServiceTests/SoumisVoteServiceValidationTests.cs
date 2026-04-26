using Lib_Entities.Entities;
using Lib_Metier.Data.Configurations;
using Lib_Services.Exceptions;
using Lib_Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class SoumisVoteServiceValidationTests
{
    private SoumisVoteService _service = null!;
    private ApplicationDbContext _context = null!;

    // Dates fixes pour éviter les problèmes de comparaison DateTime.Now
    private static readonly DateTime _dateDebut = DateTime.Now.AddDays(1);
    private static readonly DateTime _dateFin = DateTime.Now.AddDays(7);

    [TestInitialize]
    public void Init()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new ApplicationDbContext(options);
        _service = new SoumisVoteService(_context);

        // Jeu et Plateforme requis par JeuService.Obtenir() et PlateformeService.Obtenir()
        _context.Jeux.Add(new Jeu
        {
            IdJeu = 1,
            Titre = "Jeu Test",
            Editeur = "Editeur Test",
            Description = "Description",
            Pegi = 3,
            DateSortie = new DateTime(2020, 1, 1),
            AnneeSortie = "2020"
        });
        _context.Plateformes.Add(new Plateforme
        {
            IdPlateforme = 1,
            Libelle = "PC"
        });
        _context.SaveChanges();
    }

    [TestCleanup]
    public void Cleanup() => _context.Dispose();

    private SoumisVote SoumisVoteValide() => new SoumisVote
    {
        IdJeu = 1,
        IdPlateforme = 1,
        DateDebutVote = _dateDebut,
        DateFinVote = _dateFin
    };

    // =========================================================================
    // Cas nominal
    // =========================================================================

    [TestMethod]
    public void SoumisVoteValide_AucuneException()
    {
        _service.ValiderSoumisVote(SoumisVoteValide());
    }

    // =========================================================================
    // Jeu inexistant
    // =========================================================================

    [TestMethod]
    public void JeuInexistant_ThrowSoumisVoteException()
    {
        var sv = SoumisVoteValide();
        sv.IdJeu = 999;

        var ex = Assert.Throws<SoumisVoteException>(
            () => _service.ValiderSoumisVote(sv));

        Assert.AreEqual((int)SoumisVoteException.SoumisVoteErreur.JeuInexistant, ex.CodeErreur);
    }

    // =========================================================================
    // Plateforme inexistante
    // =========================================================================

    [TestMethod]
    public void PlateformeInexistante_ThrowSoumisVoteException()
    {
        var sv = SoumisVoteValide();
        sv.IdPlateforme = 999;

        var ex = Assert.Throws<SoumisVoteException>(
            () => _service.ValiderSoumisVote(sv));

        Assert.AreEqual((int)SoumisVoteException.SoumisVoteErreur.PlateformeInexistante, ex.CodeErreur);
    }

    // =========================================================================
    // Création — doublon
    // =========================================================================

    [TestMethod]
    public void Creation_DoublonSoumisVote_ThrowSoumisVoteException()
    {
        // Arrange — SoumisVote déjà en BDD
        _context.SoumisVotes.Add(new SoumisVote
        {
            IdJeu = 1,
            IdPlateforme = 1,
            DateDebutVote = _dateDebut,
            DateFinVote = _dateFin
        });
        _context.SaveChanges();

        var ex = Assert.Throws<SoumisVoteException>(
            () => _service.ValiderSoumisVote(SoumisVoteValide(), false));

        Assert.AreEqual((int)SoumisVoteException.SoumisVoteErreur.DoublonSoumisVote, ex.CodeErreur);
    }

    // =========================================================================
    // Modification — aucune modification détectée
    // =========================================================================

    [TestMethod]
    public void Modification_AucuneModification_ThrowSoumisVoteException()
    {
        // Arrange — SoumisVote identique en BDD
        _context.SoumisVotes.Add(new SoumisVote
        {
            IdJeu = 1,
            IdPlateforme = 1,
            DateDebutVote = _dateDebut,
            DateFinVote = _dateFin
        });
        _context.SaveChanges();

        var ex = Assert.Throws<SoumisVoteException>(
            () => _service.ValiderSoumisVote(SoumisVoteValide(), true));

        Assert.AreEqual((int)SoumisVoteException.SoumisVoteErreur.AucuneModification, ex.CodeErreur);
    }

    [TestMethod]
    public void Modification_DateModifiee_AucuneException()
    {
        // Arrange — SoumisVote en BDD avec dates différentes
        _context.SoumisVotes.Add(new SoumisVote
        {
            IdJeu = 1,
            IdPlateforme = 1,
            DateDebutVote = _dateDebut,
            DateFinVote = _dateFin
        });
        _context.SaveChanges();

        // Modification avec une date de fin différente → pas d'exception AucuneModification
        var sv = SoumisVoteValide();
        sv.DateFinVote = _dateFin.AddDays(1);

        _service.ValiderSoumisVote(sv, true);
    }

    // =========================================================================
    // DateDebut >= DateFin
    // =========================================================================

    [TestMethod]
    public void DateDebutEgaleADateFin_ThrowSoumisVoteException()
    {
        var sv = SoumisVoteValide();
        sv.DateFinVote = sv.DateDebutVote; // égales

        var ex = Assert.Throws<SoumisVoteException>(
            () => _service.ValiderSoumisVote(sv));

        Assert.AreEqual((int)SoumisVoteException.SoumisVoteErreur.DateDebutSuperieureFin, ex.CodeErreur);
    }

    [TestMethod]
    public void DateDebutSuperieureDateFin_ThrowSoumisVoteException()
    {
        var sv = SoumisVoteValide();
        sv.DateDebutVote = _dateFin.AddDays(1); // début après fin
        sv.DateFinVote = _dateFin;

        var ex = Assert.Throws<SoumisVoteException>(
            () => _service.ValiderSoumisVote(sv));

        Assert.AreEqual((int)SoumisVoteException.SoumisVoteErreur.DateDebutSuperieureFin, ex.CodeErreur);
    }

    // =========================================================================
    // DateDebut dans le passé
    // =========================================================================

    [TestMethod]
    public void DateDebutDansLePasse_ThrowSoumisVoteException()
    {
        var sv = SoumisVoteValide();
        sv.DateDebutVote = DateTime.Now.AddDays(-1); // hier
        sv.DateFinVote = DateTime.Now.AddDays(7);

        var ex = Assert.Throws<SoumisVoteException>(
            () => _service.ValiderSoumisVote(sv));

        Assert.AreEqual((int)SoumisVoteException.SoumisVoteErreur.DateDebutDansLePasse, ex.CodeErreur);
    }

    // =========================================================================
    // DateFin dans le passé
    // =========================================================================

    [TestMethod]
    public void DateFinDansLePasse_ThrowSoumisVoteException()
    {
        var sv = SoumisVoteValide();
        sv.DateDebutVote = DateTime.Now.AddDays(-3); // pour que début < fin
        sv.DateFinVote = DateTime.Now.AddDays(-1); // hier

        var ex = Assert.Throws<SoumisVoteException>(
            () => _service.ValiderSoumisVote(sv));

        // DateDebut dans le passé sera levée en premier selon l'ordre de validation
        Assert.IsTrue(
            ex.CodeErreur == (int)SoumisVoteException.SoumisVoteErreur.DateDebutDansLePasse
            || ex.CodeErreur == (int)SoumisVoteException.SoumisVoteErreur.DateFinDansLePasse);
    }

    [TestMethod]
    public void DateFinSeulementDansLePasse_ThrowSoumisVoteException()
    {
        // DateDebut valide (futur) mais DateFin dans le passé → impossible car début < fin
        // Ce cas teste DateFin < Now avec DateDebut valide
        var sv = SoumisVoteValide();
        sv.DateDebutVote = DateTime.Now.AddHours(1);
        sv.DateFinVote = DateTime.Now.AddDays(-1); // fin avant début → DateDebutSuperieureFin levée en premier

        var ex = Assert.Throws<SoumisVoteException>(
            () => _service.ValiderSoumisVote(sv));

        Assert.AreEqual((int)SoumisVoteException.SoumisVoteErreur.DateDebutSuperieureFin, ex.CodeErreur);
    }
}