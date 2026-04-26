using Lib_Entities.Entities;
using Lib_Metier.Data.Configurations;
using Lib_Services.Exceptions;
using Lib_Services.Services;
using Microsoft.EntityFrameworkCore;

[TestClass]
public class TournoiServiceValidationTests
{
    private TournoiService _service = null!;
    private ApplicationDbContext _context = null!;

    // Date fixe un lundi (jour sans restriction d'horaire) à 14h
    private static readonly DateTime _dateTournoiValide = new DateTime(2026, 5, 25, 14, 0, 0);

    [TestInitialize]
    public void Init()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new ApplicationDbContext(options);
        _service = new TournoiService(_context);

        // Espace et Jeu requis pour les Include dans Lister() et Obtenir()
        _context.Espaces.Add(new Espace
        {
            IdEspace = 1,
            Nom = "Espace Test",
            Description = "Description",
            Superficie = 20,
            CapaciteMaxi = 10
        });
        _context.Jeux.Add(new Jeu
        {
            IdJeu = 1,
            Titre = "Jeu Test",
            Editeur = "Editeur Test",
            Description = "Description",
            Pegi = 3,
            DateSortie = new DateTime(2026, 04, 20),
            AnneeSortie = "2026"
        });
        _context.SaveChanges();
    }

    [TestCleanup]
    public void Cleanup() => _context.Dispose();

    private Tournoi TournoiValide() => new Tournoi
    {
        Nom = "Tournoi Test",
        DateHeure = _dateTournoiValide,
        NbParticipants = 10,
        DureePrevue = 30,
        Statut = "Planifié",
        IdEspace = 1,
        IdJeu = 1
    };

    // =========================================================================
    // Cas nominal
    // =========================================================================

    [TestMethod]
    public void TournoiValide_AucuneException()
    {
        _service.ValiderTournoi(TournoiValide());
    }

    // =========================================================================
    // Nom
    // =========================================================================

    [TestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void NomVideOuBlanc_ThrowTournoiException(string nom)
    {
        var tournoi = TournoiValide();
        tournoi.Nom = nom;

        var ex = Assert.Throws<TournoiException>(
            () => _service.ValiderTournoi(tournoi));

        Assert.AreEqual((int)TournoiException.TournoiErreur.NomRequis, ex.CodeErreur);
    }

    [TestMethod]
    public void Creation_NomDejaExistant_ThrowTournoiException()
    {
        // Arrange — tournoi avec le même nom déjà en BDD
        _context.Tournois.Add(new Tournoi
        {
            NumeroTournoi = 1,
            Nom = "Tournoi Test",
            DateHeure = _dateTournoiValide.AddDays(1),
            NbParticipants = 10,
            DureePrevue = 30,
            Statut = "Planifié",
            IdEspace = 1,
            IdJeu = 1
        });
        _context.SaveChanges();

        var ex = Assert.Throws<TournoiException>(
            () => _service.ValiderTournoi(TournoiValide(), false));

        Assert.AreEqual((int)TournoiException.TournoiErreur.NomRequis, ex.CodeErreur);
    }

    [TestMethod]
    public void Modification_NomDejaExistant_AucuneException()
    {
        // En modification, le doublon de nom ne doit pas lever d'exception
        _context.Tournois.Add(new Tournoi
        {
            NumeroTournoi = 1,
            Nom = "Tournoi Test",
            DateHeure = _dateTournoiValide,
            NbParticipants = 10,
            DureePrevue = 30,
            Statut = "Planifié",
            IdEspace = 1,
            IdJeu = 1
        });
        _context.SaveChanges();

        var tournoi = TournoiValide();
        tournoi.NumeroTournoi = 1;

        // Ne doit pas lever d'exception car estModification = true
        _service.ValiderTournoi(tournoi, true);
    }

    // =========================================================================
    // Jeu
    // =========================================================================

    [TestMethod]
    [DataRow(0)]
    [DataRow(-1)]
    public void IdJeuInvalide_ThrowTournoiException(int idJeu)
    {
        var tournoi = TournoiValide();
        tournoi.IdJeu = idJeu;

        var ex = Assert.Throws<TournoiException>(
            () => _service.ValiderTournoi(tournoi));

        Assert.AreEqual((int)TournoiException.TournoiErreur.JeuRequis, ex.CodeErreur);
    }

    // =========================================================================
    // Espace
    // =========================================================================

    [TestMethod]
    [DataRow(0)]
    [DataRow(-1)]
    public void IdEspaceInvalide_ThrowTournoiException(int idEspace)
    {
        var tournoi = TournoiValide();
        tournoi.IdEspace = idEspace;

        var ex = Assert.Throws<TournoiException>(
            () => _service.ValiderTournoi(tournoi));

        Assert.AreEqual((int)TournoiException.TournoiErreur.EspaceRequis, ex.CodeErreur);
    }

    // =========================================================================
    // NbParticipants
    // =========================================================================

    [TestMethod]
    [DataRow(0)]
    [DataRow(-1)]
    public void NbParticipantsInvalide_ThrowTournoiException(int nbParticipants)
    {
        var tournoi = TournoiValide();
        tournoi.NbParticipants = nbParticipants;

        var ex = Assert.Throws<TournoiException>(
            () => _service.ValiderTournoi(tournoi));

        Assert.AreEqual((int)TournoiException.TournoiErreur.NbParticipantsInvalide, ex.CodeErreur);
    }

    // =========================================================================
    // DureePrevue
    // =========================================================================

    [TestMethod]
    [DataRow(0)]
    [DataRow(-1)]
    public void DureePrevueInvalide_ThrowTournoiException(int duree)
    {
        var tournoi = TournoiValide();
        tournoi.DureePrevue = duree;

        var ex = Assert.Throws<TournoiException>(
            () => _service.ValiderTournoi(tournoi));

        Assert.AreEqual((int)TournoiException.TournoiErreur.HoraireInvalide, ex.CodeErreur);
    }

    // =========================================================================
    // Statut
    // =========================================================================

    [TestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void StatutVideOuBlanc_ThrowTournoiException(string statut)
    {
        var tournoi = TournoiValide();
        tournoi.Statut = statut;

        var ex = Assert.Throws<TournoiException>(
            () => _service.ValiderTournoi(tournoi));

        Assert.AreEqual((int)TournoiException.TournoiErreur.StatutRequis, ex.CodeErreur);
    }

    // =========================================================================
    // Conflit horaire
    // =========================================================================

    [TestMethod]
    public void ConflitHoraire_TournoiDejaEnCours_ThrowTournoiException()
    {
        // Arrange — tournoi déjà en cours dans le même espace à la même heure
        _context.Tournois.Add(new Tournoi
        {
            NumeroTournoi = 1,
            Nom = "Tournoi Existant",
            DateHeure = _dateTournoiValide,
            NbParticipants = 10,
            DureePrevue = 60,
            Statut = "En cours",
            IdEspace = 1,
            IdJeu = 1
        });
        _context.SaveChanges();

        var tournoi = TournoiValide();
        tournoi.Nom = "Nouveau Tournoi";
        tournoi.Statut = "En cours";

        var ex = Assert.Throws<TournoiException>(
            () => _service.ValiderTournoi(tournoi));

        Assert.AreEqual((int)TournoiException.TournoiErreur.ConflitHoraire, ex.CodeErreur);
    }

    [TestMethod]
    public void ConflitHoraire_TournoiDansLaMemePeriode_ThrowTournoiException()
    {
        // Arrange — tournoi existant de 14h à 15h dans le même espace
        _context.Tournois.Add(new Tournoi
        {
            NumeroTournoi = 1,
            Nom = "Tournoi Existant",
            DateHeure = _dateTournoiValide,
            NbParticipants = 10,
            DureePrevue = 60,
            Statut = "Planifié",
            IdEspace = 1,
            IdJeu = 1
        });
        _context.SaveChanges();

        // Nouveau tournoi à 14h30 dans le même espace → chevauche le premier
        var tournoi = TournoiValide();
        tournoi.Nom = "Nouveau Tournoi";
        tournoi.DateHeure = _dateTournoiValide.AddMinutes(30);

        var ex = Assert.Throws<TournoiException>(
            () => _service.ValiderTournoi(tournoi));

        Assert.AreEqual((int)TournoiException.TournoiErreur.ConflitHoraire, ex.CodeErreur);
    }

    [TestMethod]
    public void PasDeConflitHoraire_EspaceDifferent_AucuneException()
    {
        // Tournoi dans un espace différent → pas de conflit
        _context.Espaces.Add(new Espace
        {
            IdEspace = 2,
            Nom = "Espace 2",
            Description = "Description",
            Superficie = 20,
            CapaciteMaxi = 10
        });
        _context.Tournois.Add(new Tournoi
        {
            NumeroTournoi = 1,
            Nom = "Tournoi Existant",
            DateHeure = _dateTournoiValide,
            NbParticipants = 10,
            DureePrevue = 60,
            Statut = "Planifié",
            IdEspace = 2, // espace différent
            IdJeu = 1
        });
        _context.SaveChanges();

        // Ne doit pas lever d'exception car espace différent
        _service.ValiderTournoi(TournoiValide());
    }

    // =========================================================================
    // Horaires (Samedi / Dimanche)
    // =========================================================================

    [TestMethod]
    public void Samedi_HoraireAvant10h_ThrowTournoiException()
    {
        var tournoi = TournoiValide();
        tournoi.Nom = "Tournoi Samedi Tôt";
        tournoi.DateHeure = new DateTime(2026, 5, 23, 9, 0, 0); // samedi 23 mai 2026 à 9h

        var ex = Assert.Throws<TournoiException>(
            () => _service.ValiderTournoi(tournoi));

        Assert.AreEqual((int)TournoiException.TournoiErreur.HoraireInvalide, ex.CodeErreur);
    }

    [TestMethod]
    public void Samedi_HoraireApres20h_ThrowTournoiException()
    {
        var tournoi = TournoiValide();
        tournoi.Nom = "Tournoi Samedi Tard";
        tournoi.DateHeure = new DateTime(2026, 5, 23, 21, 0, 0); // samedi 23 mai 2026 à 21h

        var ex = Assert.Throws<TournoiException>(
            () => _service.ValiderTournoi(tournoi));

        Assert.AreEqual((int)TournoiException.TournoiErreur.HoraireInvalide, ex.CodeErreur);
    }

    [TestMethod]
    public void Samedi_HoraireValide_AucuneException()
    {
        var tournoi = TournoiValide();
        tournoi.Nom = "Tournoi Samedi Valide";
        tournoi.DateHeure = new DateTime(2026, 5, 23, 14, 0, 0); // samedi 23 mai 2026 à 14h

        _service.ValiderTournoi(tournoi);
    }

    [TestMethod]
    public void Dimanche_HoraireAvant10h_ThrowTournoiException()
    {
        var tournoi = TournoiValide();
        tournoi.Nom = "Tournoi Dimanche Tôt";
        tournoi.DateHeure = new DateTime(2026, 5, 24, 9, 0, 0); // dimanche 24 mai 2026 à 9h

        var ex = Assert.Throws<TournoiException>(
            () => _service.ValiderTournoi(tournoi));

        Assert.AreEqual((int)TournoiException.TournoiErreur.HoraireInvalide, ex.CodeErreur);
    }

    [TestMethod]
    public void Dimanche_HoraireApres18h_ThrowTournoiException()
    {
        var tournoi = TournoiValide();
        tournoi.Nom = "Tournoi Dimanche Tard";
        tournoi.DateHeure = new DateTime(2026, 5, 24, 19, 0, 0); // dimanche 24 mai 2026 à 19h

        var ex = Assert.Throws<TournoiException>(
            () => _service.ValiderTournoi(tournoi));

        Assert.AreEqual((int)TournoiException.TournoiErreur.HoraireInvalide, ex.CodeErreur);
    }

    [TestMethod]
    public void Dimanche_HoraireValide_AucuneException()
    {
        var tournoi = TournoiValide();
        tournoi.Nom = "Tournoi Dimanche Valide";
        tournoi.DateHeure = new DateTime(2026, 5, 24, 14, 0, 0); // dimanche 24 mai 2026 à 14h

        _service.ValiderTournoi(tournoi);
    }

    [TestMethod]
    public void Lundi_NImporteQuelHoraire_AucuneException()
    {
        // Les jours de semaine n'ont pas de restriction d'horaire
        var tournoi = TournoiValide();
        tournoi.Nom = "Tournoi Lundi";
        tournoi.DateHeure = new DateTime(2026, 5, 25, 8, 0, 0); // lundi 25 mai 2026 à 8h

        _service.ValiderTournoi(tournoi);
    }
}