using Lib_Entities.Entities;
using Lib_Metier.Data.Configurations;
using Lib_Services.Interfaces;
using Lib_Services.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace ApplicationUi
{
    public partial class UcPostesDeJeu : UserControl
    {
        private readonly ITournoiService _serviceTournoi;
        private readonly IEspaceService _serviceEspace;
        private readonly IPosteJeuService _servicePosteJeu;
        private readonly IPlateformeService _servicePlateforme;
        private bool fonctionnelSelectionne;
        private PosteJeu? _posteJeuSelectionne;
        private string filtre;
        private string ordreChamp;
        private readonly Organisateur _organisateurConnecte;

        public UcPostesDeJeu(Organisateur unOrganisateurConnecte)
        {
            InitializeComponent();
            _serviceTournoi = new TournoiService(new ApplicationDbContext());
            _serviceEspace = new EspaceService(new ApplicationDbContext());
            _servicePosteJeu = new PosteJeuService(new ApplicationDbContext());
            _servicePlateforme = new PlateformeService(new ApplicationDbContext());
            _posteJeuSelectionne = null;
            fonctionnelSelectionne = false;
            filtre = "";
            ordreChamp = "ASC";
            _organisateurConnecte = unOrganisateurConnecte;
            ChargerPlateformes();
            ChargerEspaces();
            ChargerPostesDeJeu();
            buttonModifier.Enabled = _posteJeuSelectionne != null;
            buttonSupprimer.Enabled = _posteJeuSelectionne != null;
            buttonEffacer.Text = " 🧽  Effacer";
            // TODO: Ajouter un tooltip sur les boutons pour expliquer leur fonction à l'utilisateur
            // TODO: Ajouter un graphique pour indiquer le nombre de postes de jeu
            // fonctionnels vs non fonctionnels
            // TODO: ajouter une option de filtrage croissant décroissant sur la référence du poste de jeu
        }
        #region Evènements
        private void ChargerPostesDeJeu()
        {
            dataGridPostesJeu.DataSource = null;
            dataGridPostesJeu.DataSource = _servicePosteJeu.Lister(filtre);
            MEP_DataGrid();
            ChargerStatistiques();
        }

        private void ChargerEspaces()
        {
            comboBoxEspace.DataSource = null;
            comboBoxEspace.DataSource = _serviceEspace.Lister("");
            // charge les espaces dans le comboBox et affiche le nom tout en conservant l'id en valeur
            comboBoxEspace.DisplayMember = "Nom";
            comboBoxEspace.ValueMember = "IdEspace";
        }

        private void ChargerPlateformes()
        {
            comboBoxPlateforme.DataSource = null;
            comboBoxPlateforme.DataSource = _servicePlateforme.Lister("");
            // charge les plateformes dans le comboBox et affiche le libellé tout en conservant l'id en valeur
            comboBoxPlateforme.DisplayMember = "Libelle";
            comboBoxPlateforme.ValueMember = "IdPlateforme";
        }

        /// <summary>
        /// Permet de charger les statistiques liées aux postes de jeu, notamment le nombre total de postes 
        /// et le nombre de postes fonctionnels.
        /// Les statistiques sont affichées dans des labels dédiés, 
        /// avec une indication visuelle (couleur) pour les postes fonctionnels.
        /// Cette méthode est appelée après le chargement des postes pour garantir 
        /// que les statistiques sont à jour.
        /// </summary>
        private void ChargerStatistiques()
        {
            // Un espace libre est un espae qui n'a pas de tournoi associé
            int nbPostesJeuFonctionnels = _servicePosteJeu.Lister("").Count(e => e.Fonctionnel == true);

            labelStatPostesJeuTotal.Text = $"{_servicePosteJeu.Lister("").Count()}";

            if (nbPostesJeuFonctionnels == 0)
            {
                labelStatPostesJeuFonctionnels.Text = "Aucun poste fonctionnel";
                labelStatPostesJeuFonctionnels.ForeColor = Color.Red;
            }
            else
            {
                labelStatPostesJeuFonctionnels.Text = $"Fonctionnels : {nbPostesJeuFonctionnels}";
                labelStatPostesJeuFonctionnels.ForeColor = Color.Green;
            }
        }

        /// <summary>
        /// Resets all tournament-related input fields and controls to their default values.
        /// </summary>
        /// <remarks>Use this method to clear the current tournament selection and prepare the form for
        /// entering a new tournament. All user input fields are cleared or set to their minimum values, and the status
        /// controls are reset to indicate a planned tournament.</remarks>
        private void Raz_Zones()
        {
            textBoxReference.Clear();
            comboBoxPlateforme.SelectedItem = null;
            comboBoxEspace.SelectedItem = null;
            _posteJeuSelectionne = null;
            buttonModifier.Enabled = _posteJeuSelectionne != null;
            buttonSupprimer.Enabled = _posteJeuSelectionne != null;
            radioButtonFonctionnelTrue.Checked = false;
            radioButtonFonctionnelFalse.Checked = false;
        }
        private void MEP_DataGrid()
        // TODO: Modifier les données de la grille pour afficher le nom de l'espace
        // et le nom de la plateforme au lieu des ids
        // et masquer les colonnes idEspace et idPlateforme
        {
            dataGridPostesJeu.Columns["Espace"].Visible = false;
            dataGridPostesJeu.Columns["IdEspace"].Visible = false;
            dataGridPostesJeu.Columns["IdPlateforme"].Visible = false;
            dataGridPostesJeu.Columns["Plateforme"].Visible = false;
            dataGridPostesJeu.Columns["NumeroPoste"].Visible = false;
            dataGridPostesJeu.Columns["NomEspace"].HeaderText = "Espace";
            dataGridPostesJeu.Columns["NomPlateforme"].HeaderText = "Plateforme";
            dataGridPostesJeu.Columns["Reference"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void dataGridPostesJeu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // on ne gère le clic que sur les lignes, pas sur les en-têtes
            // Ignorer les clics sur l'en-tête (gérés pour le tri)
            // Gérer le trie par ordre des champs en fonction du clique sur la cellule d'en-tête
            if (e.RowIndex < 0)
            {
                var donnees = _servicePosteJeu.Lister(filtre);

                // Utiliser un dictionnaire plutôt qu'un switch pour associer les index de colonnes
                // à des fonctions de sélection de clé
                var map = new Dictionary<int, Func<PosteJeu, object>>
                {
                    {dataGridPostesJeu.Columns["Reference"].Index, p => p.Reference},
                    {dataGridPostesJeu.Columns["Fonctionnel"].Index, p => p.Fonctionnel},
                    {dataGridPostesJeu.Columns["NomEspace"].Index, p => p.NomEspace},
                    {dataGridPostesJeu.Columns["Nomplateforme"].Index, p => p.NomPlateforme},
                };

                if (!map.TryGetValue(e.ColumnIndex, out var keySelector))
                    return;

                dataGridPostesJeu.DataSource = ordreChamp == "ASC"
                    ? donnees.OrderByDescending(keySelector).ToList()
                    : donnees.OrderBy(keySelector).ToList();

                ordreChamp = ordreChamp == "ASC" ? "DESC" : "ASC";

                MEP_DataGrid();
                return;
            }

            _posteJeuSelectionne = dataGridPostesJeu.Rows[e.RowIndex].DataBoundItem as PosteJeu;

            if (_posteJeuSelectionne != null)
                RemplirFormulaire(_posteJeuSelectionne);

            buttonModifier.Enabled = _posteJeuSelectionne != null;
            buttonSupprimer.Enabled = _posteJeuSelectionne != null;

        }

        private void RemplirFormulaire(PosteJeu posteJeu)
        {
            textBoxReference.Text = posteJeu.Reference;

            // ComboBox Espace
            comboBoxEspace.SelectedItem = posteJeu.Espace;
            comboBoxEspace.SelectedValue = posteJeu.IdEspace;

            // ComboBox Plateforme
            comboBoxPlateforme.SelectedItem = posteJeu.Plateforme;
            comboBoxPlateforme.SelectedValue = posteJeu.IdPlateforme;

            // Fonctionnel (RadioButtons)
            if (posteJeu.Fonctionnel)
            {
                radioButtonFonctionnelTrue.Checked = true;
            }
            else
            {
                radioButtonFonctionnelFalse.Checked = true;
            }
        }

        private void radioButtonFonctionnelFalse_CheckedChanged(object sender, EventArgs e)
        {
            fonctionnelSelectionne = false;
        }

        private void radioButtonFonctionnelTrue_CheckedChanged(object sender, EventArgs e)
        {
            fonctionnelSelectionne = true;
        }

        /// <summary>
        /// Permet de filtrer les postes de jeu affichés dans le DataGrid en 
        /// fonction du texte saisi dans la zone de recherche.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxRecherche_TextChanged(object sender, EventArgs e)
        {
            filtre = textBoxRecherche.Text;
            ChargerPostesDeJeu();
        }
        #endregion
        #region Validations
        private bool ValiderPosteJeu()
        {
            // valider que la référence n'est pas vide ou composée uniquement d'espaces
            if (string.IsNullOrWhiteSpace(textBoxReference.Text))
            {
                MessageBox.Show("La référence du poste de jeu est obligatoire.",
                    "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                // on efface le contenu pour forcer l'utilisateur à saisir une valeur valide
                textBoxReference.Clear();
                return false;
            }
            else
            {
                // vérifie que la référence saisie n'existe pas déjà pour un autre poste de jeu
                if (_servicePosteJeu.ReferenceExiste(textBoxReference.Text) != null)
                {
                    MessageBox.Show($"Le poste de {textBoxReference.Text} existe déjà",
                        "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // on efface le contenu pour forcer l'utilisateur à saisir une valeur valide
                    textBoxReference.Clear();
                    return false;
                }
            }
            return true;
        }
        #endregion
        #region Boutons
        public void buttonAjouter_Click(object sender, EventArgs e)
        {
            if (ValiderPosteJeu())
            {
                var posteJeu = new PosteJeu
                {
                    Reference = textBoxReference.Text,
                    Fonctionnel = fonctionnelSelectionne,
                    IdPlateforme = ((Plateforme)comboBoxPlateforme.SelectedItem).IdPlateforme,
                    IdEspace = ((Espace)comboBoxEspace.SelectedItem).IdEspace
                };
                _servicePosteJeu.Creer(posteJeu);
                ChargerPostesDeJeu();
                Raz_Zones();
            }

        }
        private void buttonModifier_Click(object sender, EventArgs e)
        {
            if (dataGridPostesJeu.CurrentRow == null)
                return;

            if (_posteJeuSelectionne == null)
                return;
            var posteJeu = (PosteJeu)dataGridPostesJeu.CurrentRow.DataBoundItem;

            _posteJeuSelectionne.Reference = textBoxReference.Text;
            _posteJeuSelectionne.Fonctionnel = fonctionnelSelectionne; // true ou false selon le choix de l'utilisateur
            _posteJeuSelectionne.IdEspace = ((Espace)comboBoxEspace.SelectedItem).IdEspace;
            _posteJeuSelectionne.IdPlateforme = ((Plateforme)comboBoxPlateforme.SelectedItem).IdPlateforme;

            _servicePosteJeu.Modifier(_posteJeuSelectionne);
            ChargerPostesDeJeu();
            Raz_Zones();
        }
        private void buttonEffacer_Click(object sender, EventArgs e)
        {
            Raz_Zones();
        }
        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            if (dataGridPostesJeu.CurrentRow == null)
                return;

            if (_posteJeuSelectionne == null)
                return;
            var posteJeu = (PosteJeu)dataGridPostesJeu.CurrentRow.DataBoundItem;

            _servicePosteJeu.Supprimer(_posteJeuSelectionne.NumeroPoste);
            _posteJeuSelectionne = null;
            ChargerPostesDeJeu();
            Raz_Zones();

        }

        #endregion

    }
}
