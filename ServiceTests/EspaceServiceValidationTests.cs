using Lib_Entities.Entities;
using Lib_Services.Interfaces;
using Lib_Services.Services;

[TestClass]
public class EspaceServiceValidationTests
{
    private readonly IEspaceService _service = new EspaceService(null!);

    // =========================================================================
    // Cas nominal
    // =========================================================================

    [TestMethod]
    public void EspaceValide_AucuneException()
    {
        Espace espace = new () { Nom = "Salle Alpha", Description = "Une description", Superficie = 30, CapaciteMaxi = 20 };
        // ne doit pas throw
        _service.ValiderEspace(espace);
    }

    // =========================================================================
    // Nom
    // =========================================================================

    [TestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void NomVideOuBlanc_ThrowEspaceException(string nom)
    {
        Espace espace = new () { Nom = nom, Description = "Une description", Superficie = 20, CapaciteMaxi = 10 };
        EspaceException ex = Assert.ThrowsException<EspaceException>(() => _service.ValiderEspace(espace));
        Assert.AreEqual("Le nom est requis.", ex.Message);
        Assert.AreEqual((int)EspaceException.EspaceErreur.NomRequis, ex.CodeErreur);
    }

    // =========================================================================
    // Description
    // =========================================================================

    [TestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void DescriptionVideOuBlanche_ThrowEspaceException(string description)
    {
        Espace espace = new () { Nom = "Salle Alpha", Description = description, Superficie = 20, CapaciteMaxi = 10 };
        EspaceException ex = Assert.ThrowsException<EspaceException>(() => _service.ValiderEspace(espace));
        Assert.AreEqual("La description est requise.", ex.Message);
        Assert.AreEqual((int)EspaceException.EspaceErreur.DescriptionRequise, ex.CodeErreur);
    }

    // =========================================================================
    // Superficie
    // =========================================================================

    [TestMethod]
    [DataRow(8)]
    public void SuperficieTropPetite_ThrowEspaceException(int superficie)
    {
        Espace espace = new () { Nom = "Salle Alpha", Description = "Une description", Superficie = superficie, CapaciteMaxi = 10 };
        EspaceException ex = Assert.ThrowsException<EspaceException>(() => _service.ValiderEspace(espace));
        Assert.AreEqual((int)EspaceException.EspaceErreur.SuperficieInsuffisante, ex.CodeErreur);
    }

    [TestMethod]
    [DataRow(61)]
    public void SuperficieTropGrande_ThrowEspaceException(int superficie)
    {
        Espace espace = new () { Nom = "Salle Alpha", Description = "Une description", Superficie = superficie, CapaciteMaxi = 10 };
        EspaceException ex = Assert.ThrowsException<EspaceException>(() => _service.ValiderEspace(espace));
        Assert.AreEqual((int)EspaceException.EspaceErreur.SuperficieTropGrande, ex.CodeErreur);
    }

    [TestMethod]
    [DataRow(9)]
    [DataRow(60)]
    public void SuperficieLimites_AucuneException(int superficie)
    {
        Espace espace = new () { Nom = "Salle Alpha", Description = "Une description", Superficie = superficie, CapaciteMaxi = 10 };
        // ne doit pas throw
        _service.ValiderEspace(espace);
    }

    // =========================================================================
    // CapaciteMaxi
    // =========================================================================

    [TestMethod]
    [DataRow(-1)]
    [DataRow(-100)]
    public void CapaciteMaxiNegative_ThrowEspaceException(int capacite)
    {
        Espace espace = new () { Nom = "Salle Alpha", Description = "Une description", Superficie = 20, CapaciteMaxi = capacite };
        EspaceException ex = Assert.ThrowsException<EspaceException>(() => _service.ValiderEspace(espace));
        Assert.AreEqual("La capacité maximale doit être positive.", ex.Message);
        Assert.AreEqual((int)EspaceException.EspaceErreur.CapaciteNegative, ex.CodeErreur);
    }

    [TestMethod]
    [DataRow(51)]
    [DataRow(100)]
    public void CapaciteMaxiSuperieure50_ThrowEspaceException(int capacite)
    {
        Espace espace = new () { Nom = "Salle Alpha", Description = "Une description", Superficie = 20, CapaciteMaxi = capacite };
        EspaceException ex = Assert.ThrowsException<EspaceException>(() => _service.ValiderEspace(espace));
        Assert.AreEqual("La capacité maximale ne peut pas être supérieure à 50.", ex.Message);
        Assert.AreEqual((int)EspaceException.EspaceErreur.CapaciteTropGrande, ex.CodeErreur);
    }
}