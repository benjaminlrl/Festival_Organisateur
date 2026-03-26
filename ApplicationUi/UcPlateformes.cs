using Lib_Entities.Entities;
using Lib_Metier.Data.Configurations;
using Lib_Services.Interfaces;
using Lib_Services.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ApplicationUi
{
    public partial class UcPlateformes : UserControl
    {
        private readonly IPlateformeService _servicePlateforme;
        private readonly IOrganisateurService _serviceOrganisateur;
        private readonly IEspaceService _serviceEspace;
        private Plateforme? _plateformeSelectionee = null;
        private string filtre;
        private string ordreChamp;
        private readonly Organisateur _organisateurConnecte;
        public UcPlateformes(Organisateur unOrganisateurConnecte)
        {
            InitializeComponent();
            _serviceOrganisateur = new OrganisateurService(new ApplicationDbContext());
            _servicePlateforme = new PlateformeService(new ApplicationDbContext());
            buttonModifier.Enabled = _plateformeSelectionee != null;
            buttonSupprimer.Enabled = _plateformeSelectionee != null;
            filtre = "";
            buttonEffacer.Text = " 🧽  Effacer";
            ordreChamp = "ASC";
            _organisateurConnecte = unOrganisateurConnecte;
            ChargerPlateformes();
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcPlateformes, "Ajouter") == false)
            {
                buttonAjouter.Visible = false;
            }
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcPlateformes, "Modifier") == false)
            {
                buttonModifier.Visible = false;
            }
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcPlateformes, "Supprimer") == false)
            {
                buttonSupprimer.Visible = false;
            }
        }

        #region Evènements
        private void ChargerPlateformes()
        {
            dataGridPlateformes.DataSource = null;
            dataGridPlateformes.DataSource = _servicePlateforme.Lister(filtre);
            MEP_DataGrid();
        }

        private void ChargerPostesJeu()
        {
            dataGridPostesJeu.DataSource = null;
            dataGridPostesJeu.DataSource = _plateformeSelectionee.PostesJeu.ToList();
            MEP_DataGridPostesJeu();
        }

        /// <summary>
        /// Resets all tournament-related input fields and controls to their default values.
        /// </summary>
        /// <remarks>Use this method to clear the current tournament selection and prepare the form for
        /// entering a new tournament. All user input fields are cleared or set to their minimum values, and the status
        /// controls are reset to indicate a planned tournament.</remarks>
        private void Raz_Zones()
        {
            textBoxNom.Clear();
        }
        private void MEP_DataGrid()
        // TODO: Modifier les données de la grille pour afficher les informations du poste de jeu 
        {
            dataGridPlateformes.Columns["idPlateforme"].Visible = false;
            dataGridPlateformes.Columns["PostesJeu"].Visible = false;
        }

        private void MEP_DataGridPostesJeu()
        {
            dataGridPostesJeu.Columns["Espace"].Visible = false;
            dataGridPostesJeu.Columns["IdPlateforme"].Visible = false;
            dataGridPostesJeu.Columns["IdEspace"].Visible = false;
            dataGridPostesJeu.Columns["Plateforme"].Visible = false;
            dataGridPostesJeu.Columns["NumeroPoste"].Visible = false;
            dataGridPostesJeu.Columns["NomEspace"].Visible = false;
            dataGridPostesJeu.Columns["NomPlateforme"].Visible = false;
            dataGridPostesJeu.Columns["Reference"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void dataGridPlateformes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Gérer le trie par ordre des champs en fonction du clique sur la cellule d'en-tête
            if (e.RowIndex < 0)
            {
                var donnees = _servicePlateforme.Lister(filtre);

                // Utiliser un dictionnaire plutôt qu'un switch pour associer les index de colonnes
                // à des fonctions de sélection de clé
                var map = new Dictionary<int, Func<Plateforme, object>>
                {
                    {dataGridPlateformes.Columns["Libelle"].Index, p => p.Libelle},
                };

                if (!map.TryGetValue(e.ColumnIndex, out var keySelector))
                    return;

                dataGridPlateformes.DataSource = ordreChamp == "ASC"
                    ? donnees.OrderByDescending(keySelector).ToList()
                    : donnees.OrderBy(keySelector).ToList();

                ordreChamp = ordreChamp == "ASC" ? "DESC" : "ASC";

                MEP_DataGrid();
                return;
            }

            _plateformeSelectionee = dataGridPlateformes.Rows[e.RowIndex].DataBoundItem as Plateforme;

            if (_plateformeSelectionee != null)
                RemplirFormulaire(_plateformeSelectionee);

            buttonModifier.Enabled = _plateformeSelectionee != null;
            buttonSupprimer.Enabled = _plateformeSelectionee != null;
        }

        private void RemplirFormulaire(Plateforme plateforme)
        {
            textBoxNom.Text = plateforme.Libelle;
            ChargerPostesJeu();
        }
        #endregion

        #region Validations
        private bool ValiderPLateforme()
        {
            return true;
        }

        /// <summary>
        /// Permet de filtrer les résultats affichés dans la grille des plateformes 
        /// en fonction du texte saisi dans la zone de recherche.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxRecherche_TextChanged(object sender, EventArgs e)
        {
            filtre = textBoxRecherche.Text;
            ChargerPlateformes();
        }

        #endregion

        #region Boutons
        public void buttonAjouter_Click(object sender, EventArgs e)
        {
            if (ValiderPLateforme())
            {
                var plateforme = new Plateforme
                {
                    Libelle = textBoxNom.Text
                };
                _servicePlateforme.Creer(plateforme);
                ChargerPlateformes();
                Raz_Zones();
            }

        }
        private void buttonModifier_Click(object sender, EventArgs e)
        {
            if (dataGridPlateformes.CurrentRow == null)
                return;

            if (_plateformeSelectionee == null)
                return;
            var plateforme = (Plateforme)dataGridPlateformes.CurrentRow.DataBoundItem;

            _plateformeSelectionee.Libelle = textBoxNom.Text;

            _servicePlateforme.Modifier(_plateformeSelectionee);
            ChargerPlateformes();
            Raz_Zones();
        }
        private void buttonEffacer_Click(object sender, EventArgs e)
        {
            Raz_Zones();
        }
        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            if (dataGridPlateformes.CurrentRow == null)
                return;

            if (_plateformeSelectionee == null)
                return;
            var posteJeu = (PosteJeu)dataGridPlateformes.CurrentRow.DataBoundItem;

            _servicePlateforme.Supprimer(_plateformeSelectionee.IdPlateforme);
            _plateformeSelectionee = null;
            ChargerPlateformes();
            Raz_Zones();

        }
        #endregion

        private void dataGridPlateformes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
