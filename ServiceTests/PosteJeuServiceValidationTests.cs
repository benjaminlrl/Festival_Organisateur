using Lib_Entities.Entities;
using Lib_Services.Services;
using Lib_Services.Interfaces;

[TestClass]
public class PosteJeuServiceValidationTests
{
    private readonly IPosteJeuService _service = new PosteJeuService(null!);

    // =========================================================================
    // Cas nominal
    // =========================================================================

    [TestMethod]
    public void PosteJeuValide_AucuneException()
    {
        PosteJeu poste = new () { Reference = "PJ-01", NumeroPoste = 1, IdEspace = 1, IdPlateforme = 1, Fonctionnel = true };
        // ne doit pas throw
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
        PosteJeu poste = new () { Reference = reference, NumeroPoste = 1, IdEspace = 1, IdPlateforme = 1, Fonctionnel = true };
        PosteJeuException ex = Assert.ThrowsException<PosteJeuException>(() => _service.ValiderPosteJeu(poste));
        Assert.AreEqual("La référence du poste de jeu est obligatoire.", ex.Message);
        Assert.AreEqual((int)PosteJeuException.PosteJeuErreur.ReferenceRequise, ex.CodeErreur);
    }

    [TestMethod]
    public void ReferenceDejaExistante_AutreNumero_ThrowPosteJeuException()
    {
        PosteJeu poste = new () { NumeroPoste = 2, Reference = "PC-01", IdEspace = 1, IdPlateforme = 1, Fonctionnel = true };
        PosteJeuException ex = Assert.ThrowsException<PosteJeuException>(() => _service.ValiderPosteJeu(poste));
        Assert.AreEqual("Un poste de jeu avec cette référence existe déjà.", ex.Message);
        Assert.AreEqual((int)PosteJeuException.PosteJeuErreur.ReferenceExistante, ex.CodeErreur);
    }

    [TestMethod]
    public void ReferenceDejaExistante_MemeNumero_AucuneException()
    {
        PosteJeu poste = new () { NumeroPoste = 1, Reference = "PC-01", IdEspace = 1, IdPlateforme = 1, Fonctionnel = true };
        // ne doit pas throw
        _service.ValiderPosteJeu(poste);
    }

    // =========================================================================
    // IdEspace
    // =========================================================================

    [TestMethod]
    [DataRow(0)]
    [DataRow(-1)]
    public void IdEspaceInvalide_ThrowPosteJeuException(int idEspace)
    {
        PosteJeu poste = new () { Reference = "PC-01", NumeroPoste = 1, IdEspace = idEspace, IdPlateforme = 1, Fonctionnel = true };
        PosteJeuException ex = Assert.ThrowsException<PosteJeuException>(() => _service.ValiderPosteJeu(poste));
        Assert.AreEqual("L'espace associé est obligatoire.", ex.Message);
        Assert.AreEqual((int)PosteJeuException.PosteJeuErreur.EspaceRequis, ex.CodeErreur);
    }

    [TestMethod]
    public void IdEspaceValide_AucuneException()
    {
        PosteJeu poste = new () { Reference = "PC-01", NumeroPoste = 1, IdEspace = 1, IdPlateforme = 1, Fonctionnel = true };
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
        PosteJeu poste = new () { Reference = "PC-01", NumeroPoste = 1, IdEspace = 1, IdPlateforme = idPlateforme, Fonctionnel = true };
        PosteJeuException ex = Assert.ThrowsException<PosteJeuException>(() => _service.ValiderPosteJeu(poste));
        Assert.AreEqual("La plateforme associée est obligatoire.", ex.Message);
        Assert.AreEqual((int)PosteJeuException.PosteJeuErreur.PlateformeRequise, ex.CodeErreur);
    }

    [TestMethod]
    public void IdPlateformeValide_AucuneException()
    {
        PosteJeu poste = new () { Reference = "PC-01", NumeroPoste = 1, IdEspace = 1, IdPlateforme = 1, Fonctionnel = true };
        _service.ValiderPosteJeu(poste);
    }
}