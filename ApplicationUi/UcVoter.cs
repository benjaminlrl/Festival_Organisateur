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
using System.Windows.Forms.VisualStyles;

namespace ApplicationUi
{
    public partial class UcVoter : UserControl
    {
        private readonly ITournoiService _serviceTournoi;
        private readonly IOrganisateurService _serviceOrganisateur;
        private readonly IJeuService _serviceJeu;
        private readonly IPlateformeService _servicePlateforme;
        private readonly ISoumisVoteService _serviceSoumisVote;
        private Jeu? _jeuSelectionne;
        private SoumisVote? _soumisVoteSelectionne;
        private string filtre;
        private string ordreChamp;
        private readonly Organisateur _organisateurConnecte;
        // Constante de debug pour avoir un utilisateur fictif avec lequel tester les fonctionnalités de vote.
        public UcVoter(Organisateur unOrganisateurConnecte)
        {
            InitializeComponent();

            var context = new ApplicationDbContext();
            _serviceTournoi = new TournoiService(context);
            _serviceOrganisateur = new OrganisateurService(context);
            _serviceJeu = new JeuService(context);
            _servicePlateforme = new PlateformeService(context);
            _serviceSoumisVote = new SoumisVoteService(context);
            _organisateurConnecte = unOrganisateurConnecte;

            _soumisVoteSelectionne = null;

            filtre = "";
            ordreChamp = "ASC";

            dateTimePickerDateDebutVote.Value = DateTime.Now;
            dateTimePickerDateFinVote.Value = DateTime.Now.AddDays(1);

            ChargerClassement();
            ChargerJeux();
            ChargerPlateforme();
            ChargerSoumisVotes();

            AfficherBoutons();

            buttonEffacer.Text = " 🧽  Effacer";

            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcVoter, "Ajouter") == false)
            {
                buttonAjouter.Visible = false;
                DesactiverInputs();
                
            }
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcVoter, "Modifier") == false)
            {
                buttonModifier.Visible = false;
                DesactiverInputs();
            }
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcVoter, "Supprimer") == false)
            {
                buttonSupprimer.Visible = false;
                DesactiverInputs();
            }
            
        }

        #region Données
        private void ChargerSoumisVotes()
        {
            dataGridSoumisVote.DataSource = null;
            dataGridSoumisVote.DataSource = _serviceSoumisVote.Lister(filtre);
            MEP_DataGridSoumisVote();
        }

        private void ChargerJeux()
        {
            comboBoxJeu.DataSource = null;
            comboBoxJeu.DataSource = _serviceJeu.Lister(filtre);
            // charge les jeux dans le comboBox et affiche le titre tout en conservant l'id en valeur
            comboBoxJeu.DisplayMember = "Titre";
            comboBoxJeu.ValueMember = "IdJeu";
        }

        private void ChargerPlateforme()
        {
            if (_jeuSelectionne == null)
            {
                comboBoxPlateforme.DataSource = _servicePlateforme.Lister(filtre);
                return;
            }

            comboBoxPlateforme.DataSource = _jeuSelectionne.Plateformes.ToList(); ;
            // charge les plateformes dans le comboBox et affiche le libellé tout en conservant l'id en valeur
            comboBoxPlateforme.DisplayMember = "Libelle";
            comboBoxPlateforme.ValueMember = "IdPlateforme";
        }

        /// <summary>
        /// Permet de charger les jeux déjà votés 
        /// </summary>
        private void ChargerClassement()
        {
            dataGridClassement.DataSource = null;
            dataGridClassement.DataSource = _serviceSoumisVote.ListerClassmentJeuxVotes();
            MEP_DataGridClassement();
        }

        private void MEP_DataGridSoumisVote()
        {
            // Après avoir lié la DataSource, définir le SortMode de chaque colonne
            foreach (DataGridViewColumn col in dataGridSoumisVote.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.Programmatic;
            } 

            dataGridSoumisVote.Columns["LibellePlateforme"].DisplayIndex = 0;
            dataGridSoumisVote.Columns["TitreJeu"].DisplayIndex = 1;
            dataGridSoumisVote.Columns["DateDebutVote"].DisplayIndex = 2;
            dataGridSoumisVote.Columns["DateFinVote"].DisplayIndex = 3;

            dataGridSoumisVote.Columns["IdJeu"].Visible = false;
            dataGridSoumisVote.Columns["IdPlateforme"].Visible = false;
            dataGridSoumisVote.Columns["Plateforme"].Visible = false;
            dataGridSoumisVote.Columns["Jeu"].Visible = false;
            dataGridSoumisVote.Columns["TauxVoteJeu"].Visible = false;

            dataGridSoumisVote.Columns["LibellePlateforme"].HeaderText = "Plateforme";
            dataGridSoumisVote.Columns["TitreJeu"].HeaderText = "Jeu";
            dataGridSoumisVote.Columns["DateFinVote"].HeaderText = "Date butoire des votes";
            dataGridSoumisVote.Columns["DateDebutVote"].HeaderText = "Date d'ouverture des votes";
        }

        private void MEP_DataGridClassement()
        {
            dataGridClassement.Columns["NbVotes"].DisplayIndex = 2; // A placer en premier à cause des conflits de propriétés calculés
            dataGridClassement.Columns["TitreJeu"].DisplayIndex = 0;
            dataGridClassement.Columns["LibellePlateforme"].DisplayIndex = 1;

            dataGridClassement.Columns["IdPlateforme"].Visible = false;
            dataGridClassement.Columns["IdUser"].Visible = false;
            dataGridClassement.Columns["IdJeu"].Visible = false;
            dataGridClassement.Columns["Plateforme"].Visible = false;
            dataGridClassement.Columns["Jeu"].Visible = false;
            dataGridClassement.Columns["DateVote"].Visible = false;

            dataGridClassement.Columns["TitreJeu"].HeaderText = "Jeu";
            dataGridClassement.Columns["LibellePlateforme"].HeaderText = "Plateforme";
            dataGridClassement.Columns["NbVotes"].HeaderText = "Nombre de votes";

            dataGridClassement.Columns["TitreJeu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridClassement.Columns["LibellePlateforme"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        #endregion

        #region Evènements

        #region Boutons
        public void ButtonAjouter_Click(object sender, EventArgs e)
        {
            // Validation de la sélection de l'espace et de la plateforme avant de créer le poste de jeu
            if (comboBoxJeu.SelectedItem is not Jeu jeuSelectionne
                || comboBoxPlateforme.SelectedItem is not Plateforme plateformeSelectionne)
            {
                MessageBox.Show("Veuillez sélectionner une plateforme et un jeu.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SoumisVote soumisVote = new ()
            {
                IdJeu = (comboBoxJeu.SelectedItem as Jeu).IdJeu,
                IdPlateforme = (comboBoxPlateforme.SelectedItem as Plateforme).IdPlateforme,
                Plateforme = plateformeSelectionne,
                Jeu = jeuSelectionne,
                DateFinVote = dateTimePickerDateFinVote.Value,
                DateDebutVote = dateTimePickerDateDebutVote.Value,

            };
            if (ValiderSoumisVote(soumisVote, false))
            {
                _serviceSoumisVote.Creer(soumisVote);
                _soumisVoteSelectionne = soumisVote;
                
            }
        }
        private void ButtonModifier_Click(object sender, EventArgs e)
        {
            if (dataGridSoumisVote.CurrentRow == null || _soumisVoteSelectionne == null)
            {
                MessageBox.Show("Aucun soumisVote sélectionné", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _soumisVoteSelectionne.DateDebutVote = dateTimePickerDateDebutVote.Value;
            _soumisVoteSelectionne.DateFinVote = dateTimePickerDateFinVote.Value;
            if (ValiderSoumisVote(_soumisVoteSelectionne, true))
            {
                _serviceSoumisVote.Modifier(_soumisVoteSelectionne);
                ChargerSoumisVotes();
                AfficherBoutons();
                Raz_Zones();
            }
        }
        private void ButtonEffacer_Click(object sender, EventArgs e)
        {
            Raz_Zones();
        }
        private void ButtonSupprimer_Click(object sender, EventArgs e)
        {
            if (dataGridSoumisVote.CurrentRow == null || _soumisVoteSelectionne == null)
            {
                MessageBox.Show("Aucun soumisVote sélectionné", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Êtes vous sûr de vouloir supprimer ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            _serviceSoumisVote.Supprimer(_soumisVoteSelectionne.IdJeu, _soumisVoteSelectionne.IdPlateforme);
            _soumisVoteSelectionne = null;
            ChargerJeux();
            AfficherBoutons();
            Raz_Zones();

        }

        #endregion
        private void AfficherBoutons()
        {
            buttonAjouter.Enabled = _soumisVoteSelectionne == null;
            buttonModifier.Enabled = _soumisVoteSelectionne != null;
            buttonSupprimer.Enabled = _soumisVoteSelectionne != null;
            buttonEffacer.Enabled = _soumisVoteSelectionne != null;

            comboBoxJeu.Enabled = _soumisVoteSelectionne == null;
            comboBoxPlateforme.Enabled = _soumisVoteSelectionne == null;
        }
       
        private void DataGridClassement_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // on ne gère pas les cliques sur la première colonne
            if (e.ColumnIndex < 0)
                return;

            // Utiliser un dictionnaire plutôt qu'un switch pour associer les index de colonnes
            // à des fonctions de sélection de clé
            Dictionary<int, string> map = new()
                {
                    {dataGridClassement.Columns["NbVotes"].Index, "NbVotes"},
                    {dataGridClassement.Columns["LibellePlateforme"].Index, "LibellePlateforme"},
                    {dataGridClassement.Columns["TitreJeu"].Index, "TitreJeu"},
                };

            if (!map.TryGetValue(e.ColumnIndex, out string? colonne))
                return;

            ordreChamp = ordreChamp == "ASC" ? "DESC" : "ASC";

            dataGridClassement.DataSource = _serviceSoumisVote.ListerClassmentJeuxVotes(filtre, colonne, ordreChamp);
            dataGridClassement.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection =
                ordreChamp == "ASC" ? SortOrder.Ascending : SortOrder.Descending;

            MEP_DataGridClassement();

            return;
        }

        private void DataGridSoumisVote_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Gérer le trie par ordre des champs en fonction du clique sur la cellule d'en-tête
            if (e.RowIndex < 0)
            {
                // on ne gère pas les cliques sur la première colonne
                if (e.ColumnIndex < 0)
                    return;

                // Utiliser un dictionnaire plutôt qu'un switch pour associer les index de colonnes
                // à des fonctions de sélection de clé
                Dictionary<int, string> map = new ()
                {
                    {dataGridSoumisVote.Columns["DateDebutVote"].Index, "DateDebutVote"},
                    {dataGridSoumisVote.Columns["DateFinVote"].Index, "DateFinVote"},
                    {dataGridSoumisVote.Columns["TitreJeu"].Index, "TitreJeu"},
                    {dataGridSoumisVote.Columns["LibellePlateforme"].Index, "LibellePlateforme"},
                };

                if (!map.TryGetValue(e.ColumnIndex, out string? colonne))
                    return;

                ordreChamp = ordreChamp == "ASC" ? "DESC" : "ASC";

                dataGridSoumisVote.DataSource = _serviceTournoi.Lister(filtre, colonne, ordreChamp);
                dataGridSoumisVote.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection =
                    ordreChamp == "ASC" ? SortOrder.Ascending : SortOrder.Descending;

                MEP_DataGridSoumisVote();
                return;
            }

            _soumisVoteSelectionne = dataGridSoumisVote.Rows[e.RowIndex].DataBoundItem as SoumisVote;

            if (_soumisVoteSelectionne != null)
                RemplirFormulaire();
        }

        /// <summary>
        /// Permet de filtrer les postes de jeu affichés dans le DataGrid en 
        /// fonction du texte saisi dans la zone de recherche.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxRecherche_TextChanged(object sender, EventArgs e)
        {
            filtre = textBoxRecherche.Text;
            ChargerSoumisVotes();
        }
        private void ComboBoxPlateforme_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPlateforme.SelectedItem == null)
                return;

            AfficherBoutons();
        }

        private void ComboBoxJeu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxJeu.SelectedItem == null)
            {
                _jeuSelectionne = null;
                return;
            }

            _jeuSelectionne = (Jeu)comboBoxJeu.SelectedItem;
            textBoxDescription.Text = _jeuSelectionne.Description;

            ChargerPlateforme();

            AfficherBoutons();
        }
        #endregion

        #region Validations
        private bool ValiderSoumisVote(SoumisVote soumisvote, bool estModification)
        {
            var erreurs = _serviceSoumisVote.ValiderSoumisVote(soumisvote, estModification);
            if (erreurs.Count > 0)
            {
                MessageBox.Show(string.Join("\n", erreurs), "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        #endregion

        #region Méthodes

        /// <summary>
        /// Resets all tournament-related input fields and controls to their default values.
        /// </summary>
        /// <remarks>Use this method to clear the current tournament selection and prepare the form for
        /// entering a new tournament. All user input fields are cleared or set to their minimum values, and the status
        /// controls are reset to indicate a planned tournament.</remarks>
        private void Raz_Zones()
        {
            filtre = "";

            _soumisVoteSelectionne = null;

            comboBoxJeu.SelectedItem = null;
            textBoxDescription.Clear();
            textBoxRecherche.Clear();
            comboBoxPlateforme.SelectedItem = null;
            dateTimePickerDateDebutVote.Value = DateTime.Now;
            dateTimePickerDateFinVote.Value = DateTime.Now.AddDays(1);

            ChargerJeux();
            ChargerSoumisVotes();

            AfficherBoutons();
        }

        private void RemplirFormulaire()
        {
            // ComboBox Jeu
            comboBoxJeu.SelectedItem = _soumisVoteSelectionne.Jeu;
            comboBoxJeu.SelectedValue = _soumisVoteSelectionne.IdJeu;

            // ComboBox Plateforme
            comboBoxPlateforme.SelectedItem = _soumisVoteSelectionne.Plateforme;
            comboBoxPlateforme.SelectedValue = _soumisVoteSelectionne.IdPlateforme;

            comboBoxPlateforme.SelectedItem = _soumisVoteSelectionne.IdJeu;
            textBoxDescription.Text = _soumisVoteSelectionne.Jeu.Description;
            dateTimePickerDateDebutVote.Value = _soumisVoteSelectionne.DateDebutVote;
            dateTimePickerDateFinVote.Value = _soumisVoteSelectionne.DateFinVote;

            AfficherBoutons();
        }

        /// <summary>
        /// Permet de désactiver les champs de saisie du formulaire si l'utilisateur 
        /// n'a pas les droits nécessaires pour ajouter ou modifier des espaces.
        /// </summary>
        private void DesactiverInputs()
        {
            comboBoxJeu.Enabled = false;
            textBoxDescription.Enabled = false;
            textBoxRecherche.Enabled = false;
            comboBoxPlateforme.Enabled = false;
            dateTimePickerDateDebutVote.Enabled = false;
            dateTimePickerDateFinVote.Enabled = false;
        }
        #endregion
    }
}
