using Lib_Entities.Entities;
using Lib_Metier.Data.Configurations;
using Lib_Services.Services;
using Microsoft.EntityFrameworkCore;

[TestClass]
public class ParticiperServiceValidationTests
{
    private ParticiperService _service = null!;
    private ApplicationDbContext _context = null!;

    [TestInitialize]
    public void Init()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new ApplicationDbContext(options);
        _service = new ParticiperService(_context);


        // Espace requis par TournoiService.Obtenir() via Include
        _context.Espaces.Add(new Espace
        {
            IdEspace = 1,
            Nom = "Espace Test",
            Description = "Description",
            Superficie = 20,
            CapaciteMaxi = 10
        });

        _context.Tournois.Add(new Tournoi
        {
            NumeroTournoi = 1,
            NbParticipants = 10,
            Statut = "Planifié",
            Nom = "Tournoi Test",
            IdEspace = 1,
            IdJeu = 1
        });
        _context.SaveChanges();
    }

    [TestCleanup]
    public void Cleanup() => _context.Dispose();

    private static readonly DateTime _dateInscription = new DateTime(2026, 5, 23, 9, 0, 0);
    private Participer ParticipationValide() => new Participer
    {
        IdUser = 1,
        NumeroTournoi = 1,
        Rang = 0,
        ScoreFinal = 0,
        LotRemis = false,
        Evaluation = 5,
        Commentaire = "RAS",
        DateHeureInscription = _dateInscription // date fixe partagée
    };

    // =========================================================================
    // Cas nominal
    // =========================================================================

    [TestMethod]
    public void ParticipationValide_AucuneException()
    {
        _service.ValiderParticipation(ParticipationValide());
    }

    // =========================================================================
    // Tournoi inexistant
    // =========================================================================

    [TestMethod]
    public void TournoiInexistant_ThrowParticiperException()
    {
        var participation = ParticipationValide();
        participation.NumeroTournoi = 999;

        var ex = Assert.Throws<ParticiperException>(
            () => _service.ValiderParticipation(participation));

        Assert.AreEqual((int)ParticiperException.ParticiperErreur.TournoiInexistant, ex.CodeErreur);
    }

    // =========================================================================
    // Création — doublon
    // =========================================================================

    [TestMethod]
    public void Creation_DejaParticipant_ThrowParticiperException()
    {
        AjouterParticipationEnBdd();

        var ex = Assert.Throws<ParticiperException>(
            () => _service.ValiderParticipation(ParticipationValide()));

        Assert.AreEqual((int)ParticiperException.ParticiperErreur.DejaParticipant, ex.CodeErreur);
    }

    // =========================================================================
    // Création — statut tournoi
    // =========================================================================

    [TestMethod]
    public void Creation_TournoiTermine_ThrowParticiperException()
    {
        var tournoi = _context.Tournois.Find(1);
        tournoi!.Statut = "Terminé";
        _context.SaveChanges();

        var ex = Assert.Throws<ParticiperException>(
            () => _service.ValiderParticipation(ParticipationValide()));

        Assert.AreEqual((int)ParticiperException.ParticiperErreur.TournoiTermine, ex.CodeErreur);
    }

    [TestMethod]
    public void Creation_TournoiEnCours_ThrowParticiperException()
    {
        var tournoi = _context.Tournois.Find(1);
        tournoi!.Statut = "En cours";
        _context.SaveChanges();

        var ex = Assert.Throws<ParticiperException>(
            () => _service.ValiderParticipation(ParticipationValide()));

        Assert.AreEqual((int)ParticiperException.ParticiperErreur.TournoiEnCours, ex.CodeErreur);
    }

    // =========================================================================
    // Création — tournoi complet
    // =========================================================================

    [TestMethod]
    public void Creation_TournoiComplet_ThrowParticiperException()
    {
        var tournoi = _context.Tournois.Find(1);
        tournoi!.NbParticipants = 0;
        _context.SaveChanges();

        var ex = Assert.Throws<ParticiperException>(
            () => _service.ValiderParticipation(ParticipationValide()));

        Assert.AreEqual((int)ParticiperException.ParticiperErreur.TournoiComplet, ex.CodeErreur);
    }

    // =========================================================================
    // Création — valeurs par défaut
    // =========================================================================

    [TestMethod]
    public void Creation_RangNonZero_ThrowParticiperException()
    {
        var participation = ParticipationValide();
        participation.Rang = 1;

        var ex = Assert.Throws<ParticiperException>(
            () => _service.ValiderParticipation(participation));

        Assert.AreEqual((int)ParticiperException.ParticiperErreur.RangInvalide, ex.CodeErreur);
    }

    [TestMethod]
    public void Creation_ScoreFinalNonZero_ThrowParticiperException()
    {
        var participation = ParticipationValide();
        participation.ScoreFinal = 10;

        var ex = Assert.Throws<ParticiperException>(
            () => _service.ValiderParticipation(participation));

        Assert.AreEqual((int)ParticiperException.ParticiperErreur.ScoreNegatif, ex.CodeErreur);
    }

    [TestMethod]
    public void Creation_LotRemisTrue_ThrowParticiperException()
    {
        var participation = ParticipationValide();
        participation.LotRemis = true;

        var ex = Assert.Throws<ParticiperException>(
            () => _service.ValiderParticipation(participation));

        Assert.AreEqual((int)ParticiperException.ParticiperErreur.LotRemisParDefaut, ex.CodeErreur);
    }

    // =========================================================================
    // Commun — évaluation
    // =========================================================================

    [TestMethod]
    [DataRow(-1)]
    [DataRow(11)]
    public void EvaluationHorsLimites_ThrowParticiperException(int evaluation)
    {
        var participation = ParticipationValide();
        participation.Evaluation = evaluation;

        var ex = Assert.Throws<ParticiperException>(
            () => _service.ValiderParticipation(participation));

        Assert.AreEqual((int)ParticiperException.ParticiperErreur.EvaluationInvalide, ex.CodeErreur);
    }

    [TestMethod]
    [DataRow(0)]
    [DataRow(5)]
    [DataRow(10)]
    public void EvaluationValide_AucuneException(int evaluation)
    {
        var participation = ParticipationValide();
        participation.Evaluation = evaluation;
        _service.ValiderParticipation(participation);
    }

    // =========================================================================
    // Commun — commentaire
    // =========================================================================

    [TestMethod]
    public void CommentaireTropLong_ThrowParticiperException()
    {
        var participation = ParticipationValide();
        participation.Commentaire = new string('a', 501);

        var ex = Assert.Throws<ParticiperException>(
            () => _service.ValiderParticipation(participation));

        Assert.AreEqual((int)ParticiperException.ParticiperErreur.CommentaireTropLong, ex.CodeErreur);
    }

    [TestMethod]
    public void CommentaireVide_AucuneException()
    {
        var participation = ParticipationValide();
        participation.Commentaire = "";
        _service.ValiderParticipation(participation);
    }

    [TestMethod]
    public void Commentaire500Caracteres_AucuneException()
    {
        // Limite exacte — doit passer
        var participation = ParticipationValide();
        participation.Commentaire = new string('a', 500);
        _service.ValiderParticipation(participation);
    }

    // =========================================================================
    // Modification — participation inexistante
    // =========================================================================

    [TestMethod]
    public void Modification_ParticipationInexistante_ThrowParticiperException()
    {
        // Pas de participation en BDD → Obtenir retourne null
        var ex = Assert.Throws<ParticiperException>(
            () => _service.ValiderParticipation(ParticipationValide(), true));

        Assert.AreEqual((int)ParticiperException.ParticiperErreur.TournoiInexistant, ex.CodeErreur);
    }

    // =========================================================================
    // Modification — rang
    // =========================================================================

    [TestMethod]
    public void Modification_RangNegatif_ThrowParticiperException()
    {
        AjouterParticipationEnBdd();
        var participation = ParticipationValide();
        participation.Rang = -1;

        var ex = Assert.Throws<ParticiperException>(
            () => _service.ValiderParticipation(participation, true));

        Assert.AreEqual((int)ParticiperException.ParticiperErreur.RangNegatif, ex.CodeErreur);
    }

    [TestMethod]
    public void Modification_RangSuperieurNbParticipants_ThrowParticiperException()
    {
        AjouterParticipationEnBdd();
        var participation = ParticipationValide();
        participation.Rang = 11; // NbParticipants = 10

        var ex = Assert.Throws<ParticiperException>(
            () => _service.ValiderParticipation(participation, true));

        Assert.AreEqual((int)ParticiperException.ParticiperErreur.RangInvalide, ex.CodeErreur);
    }

    [TestMethod]
    public void Modification_RangNonZeroTournoiNonTermine_ThrowParticiperException()
    {
        AjouterParticipationEnBdd();
        var participation = ParticipationValide();
        participation.Rang = 1;

        var ex = Assert.Throws<ParticiperException>(
            () => _service.ValiderParticipation(participation, true));

        Assert.AreEqual((int)ParticiperException.ParticiperErreur.RangInvalideTournoiNonTermine, ex.CodeErreur);
    }

    // =========================================================================
    // Modification — score
    // =========================================================================

    [TestMethod]
    public void Modification_ScoreNegatif_ThrowParticiperException()
    {
        AjouterParticipationEnBdd();
        var participation = ParticipationValide();
        participation.ScoreFinal = -1;

        var ex = Assert.Throws<ParticiperException>(
            () => _service.ValiderParticipation(participation, true));

        Assert.AreEqual((int)ParticiperException.ParticiperErreur.ScoreNegatif, ex.CodeErreur);
    }

    [TestMethod]
    public void Modification_ScoreNonZeroTournoiNonTermine_ThrowParticiperException()
    {
        AjouterParticipationEnBdd();
        var participation = ParticipationValide();
        participation.ScoreFinal = 100;

        var ex = Assert.Throws<ParticiperException>(
            () => _service.ValiderParticipation(participation, true));

        Assert.AreEqual((int)ParticiperException.ParticiperErreur.ScoreFinal, ex.CodeErreur);
    }

    // =========================================================================
    // Modification — lot remis
    // =========================================================================

    [TestMethod]
    public void Modification_LotRemisTournoiNonTermine_ThrowParticiperException()
    {
        AjouterParticipationEnBdd();
        var participation = ParticipationValide();
        participation.LotRemis = true;

        var ex = Assert.Throws<ParticiperException>(
            () => _service.ValiderParticipation(participation, true));

        Assert.AreEqual((int)ParticiperException.ParticiperErreur.LotRemisParDefaut, ex.CodeErreur);
    }

    // =========================================================================
    // Modification — date inscription
    // =========================================================================

    [TestMethod]
    public void Modification_DateInscriptionModifiee_ThrowParticiperException()
    {
        AjouterParticipationEnBdd();
        var participation = ParticipationValide();
        participation.DateHeureInscription = DateTime.Now.AddDays(1); // date différente de celle en BDD

        var ex = Assert.Throws<ParticiperException>(
            () => _service.ValiderParticipation(participation, true));

        Assert.AreEqual((int)ParticiperException.ParticiperErreur.ModificationDateInscription, ex.CodeErreur);
    }

    // =========================================================================
    // Modification — aucune modification détectée
    // =========================================================================

    [TestMethod]
    public void Modification_AucuneModification_ThrowParticiperException()
    {
        AjouterParticipationEnBdd();

        var ex = Assert.Throws<ParticiperException>(
            () => _service.ValiderParticipation(ParticipationValide(), true));

        Assert.AreEqual((int)ParticiperException.ParticiperErreur.AucuneModification, ex.CodeErreur);
    }

    // =========================================================================
    // Helpers
    // =========================================================================

    private void AjouterParticipationEnBdd()
    {
        _context.Participer.Add(new Participer
        {
            IdUser = 1,
            NumeroTournoi = 1,
            Rang = 0,
            ScoreFinal = 0,
            LotRemis = false,
            Evaluation = 5,
            Commentaire = "RAS",
            DateHeureInscription = _dateInscription // même date fixe
        });
        _context.SaveChanges();
    }
}