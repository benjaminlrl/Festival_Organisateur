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
    public partial class UcTournois : UserControl
    {
        private readonly ApplicationDbContext _context;
        private readonly Organisateur _organisateurConnecte;
        private readonly ITournoiService _serviceTournoi;
        private readonly IEspaceService _serviceEspace;
        private readonly IOrganisateurService _serviceOrganisateur;
        private readonly IJeuService _serviceJeu;
        private string statutSelectionne;
        private Tournoi? _tournoiSelectionne = null;
        private string filtre;
        private string ordreChamp;

        public UcTournois(Organisateur unOrganisateurConnecte)
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
            _serviceOrganisateur = new OrganisateurService(_context);
            _serviceTournoi = new TournoiService(_context);
            _serviceEspace = new EspaceService(_context);
            _serviceJeu = new JeuService(_context);

            _organisateurConnecte = unOrganisateurConnecte;
            _tournoiSelectionne = null;
            statutSelectionne = "Planifié";

            AfficherBoutons();

            filtre = "";
            ordreChamp = "ASC";
            buttonEffacer.Text = " 🧽  Effacer";

            ChargerTournois();
            ChargerEspaces();
            ChargerJeux();           

            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcTournois, "Ajouter") == false)
            {
                buttonAjouter.Visible = false;
                DesactiverInputs();
            }
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcTournois, "Modifier") == false)
            {
                buttonModifier.Visible = false;
                DesactiverInputs();
            }
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcTournois, "Supprimer") == false)
            {
                buttonSupprimer.Visible = false;
                DesactiverInputs();
            }
        }

        #region Données
        private void ChargerTournois()
        {
            dataGridTournois.DataSource = null;
            dataGridTournois.DataSource = _serviceTournoi.Lister(filtre);
            MEP_DataGridTournois();
        }

        private void ChargerJeux()
        {
            comboBoxJeu.DataSource = null;
            comboBoxJeu.DataSource = _serviceJeu.Lister("");
            // charge les jeux dans le comboBox et affiche le titre tout en conservant l'id en valeur
            comboBoxJeu.DisplayMember = "Titre";
            comboBoxJeu.ValueMember = "IdJeu";
        }
        private void MEP_DataGridTournois()
        {
            DesactiverTrieAutomatique(dataGridTournois);

            dataGridTournois.Columns["NumeroTournoi"].Visible = false;
            dataGridTournois.Columns["IdEspace"].Visible = false;
            dataGridTournois.Columns["Espace"].Visible = false;
            dataGridTournois.Columns["IdJeu"].Visible = false;
            dataGridTournois.Columns["Jeu"].Visible = false;

            dataGridTournois.Columns["NomEspace"].HeaderText = "Espace";
            dataGridTournois.Columns["TitreJeu"].HeaderText = "Jeu";

            dataGridTournois.Columns["Nom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
        private void ChargerEspaces()
        {
            comboBoxEspace.DataSource = null;
            comboBoxEspace.DataSource = _serviceEspace.Lister("");
            comboBoxEspace.DisplayMember = "Nom";
            comboBoxEspace.ValueMember = "IdEspace";
        }
        #endregion

        #region Evènements

        #region Boutons
        private void ButtonAjouter_Click(object sender, EventArgs e)
        {
            Tournoi tournoi = new ()
            {
                Nom = textBoxNom.Text,
                DateHeure = dateTimePickerDateTournoi.Value,
                NbParticipants = (int)numericUpDownNbParticip.Value,
                DureePrevue = (int)numericUpDownDuree.Value,
                Statut = statutSelectionne,
                IdEspace = (comboBoxEspace.SelectedItem as Espace).IdEspace,
                IdJeu = (comboBoxJeu.SelectedItem as Jeu).IdJeu,
            };

            if (ValiderTournoi(tournoi, false))
            {
                _serviceTournoi.Creer(tournoi);
                MessageBox.Show("Le tournoi a bien été ajouté.", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Raz_Zones();
            }
        }
        private void ButtonModifier_Click(object sender, EventArgs e)
        {
            if (dataGridTournois.CurrentRow == null || _tournoiSelectionne == null)
            {
                MessageBox.Show("Aucun tournoi sélectionné", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _tournoiSelectionne.Nom = textBoxNom.Text;
            _tournoiSelectionne.DateHeure = dateTimePickerDateTournoi.Value;
            _tournoiSelectionne.NbParticipants = (int)numericUpDownNbParticip.Value;
            _tournoiSelectionne.DureePrevue = (int)numericUpDownDuree.Value;
            _tournoiSelectionne.Statut = statutSelectionne;
            _tournoiSelectionne.IdEspace = (comboBoxEspace.SelectedItem as Espace).IdEspace;
            _tournoiSelectionne.IdJeu = (comboBoxJeu.SelectedItem as Jeu).IdJeu;

            if (ValiderTournoi(_tournoiSelectionne, true))
            {
                _serviceTournoi.Modifier(_tournoiSelectionne);
                MessageBox.Show("Le tournoi a bien été modifié.", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Raz_Zones();
            }
        }
        private void ButtonEffacer_Click(object sender, EventArgs e)
        {
            Raz_Zones();
        }
        private void ButtonSupprimer_Click(object sender, EventArgs e)
        {
            if (dataGridTournois.CurrentRow == null || _tournoiSelectionne == null)
            {
                MessageBox.Show("Aucun tournoi sélectionné", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _serviceTournoi.Supprimer(_tournoiSelectionne.NumeroTournoi);
            Raz_Zones();
        }
        #endregion
        private void DataGridTournois_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Gérer le trie par ordre des champs en fonction du clique sur la cellule d'en-tête
            if (e.RowIndex < 0)
            {

                // Utiliser un dictionnaire plutôt qu'un switch pour associer les index de colonnes
                // à des fonctions de sélection de clé
                Dictionary<int, string> map = new()
                {
                    {dataGridTournois.Columns["DateHeure"].Index, "DateHeure"},
                    {dataGridTournois.Columns["NbParticipants"].Index, "NbParticipants"},
                    {dataGridTournois.Columns["DureePrevue"].Index, "DureePrevue"},
                    {dataGridTournois.Columns["Nom"].Index, "Nom"},
                    {dataGridTournois.Columns["Statut"].Index, "Statut"},
                };

                if (!map.TryGetValue(e.ColumnIndex, out string? colonne))
                    return;

                ordreChamp = ordreChamp == "ASC" ? "DESC" : "ASC";

                dataGridTournois.DataSource = _serviceTournoi.Lister(filtre, colonne, ordreChamp);
                dataGridTournois.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection =
                    ordreChamp == "ASC" ? SortOrder.Ascending : SortOrder.Descending;

                MEP_DataGridTournois();
                return;
            }

            _tournoiSelectionne = dataGridTournois.Rows[e.RowIndex].DataBoundItem as Tournoi;

            if (_tournoiSelectionne != null)
                RemplirFormulaire();

            AfficherBoutons();
        }
        private void RadioButtonPlanifié_CheckedChanged(object sender, EventArgs e)
        {
            statutSelectionne = "Planifié";
        }
        private void RadioButtonEnCours_CheckedChanged(object sender, EventArgs e)
        {
            statutSelectionne = "En cours";
        }
        private void RadioButtonTermine_CheckedChanged(object sender, EventArgs e)
        {
            statutSelectionne = "Terminé";
        }

        /// <summary>
        /// Permet de filtrer la liste des tournois affichés en fonction du texte saisi dans la zone de recherche.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxRecherche_TextChanged(object sender, EventArgs e)
        {
            filtre = textBoxRecherche.Text;
            ChargerTournois();
        }

        #endregion

        #region Validations
        /// <summary>
        /// Retourne un booléen indiquant si les informations de la participation sont valides ou non,
        /// en fonction des règles métier définies dans le service Participer.
        /// </summary>
        /// <param name="tournoi">L'objet Tournoi à valider.</param>
        /// <returns>Vraie si le tournoi est valide, sinon faux.</returns>
        private bool ValiderTournoi(Tournoi tournoi, bool estModification)
        {
            List<string> erreurs = _serviceTournoi.ValiderTournoi(tournoi, estModification);
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
        /// Permet de désactiver les champs de saisie du formulaire si l'utilisateur 
        /// n'a pas les droits nécessaires pour ajouter ou modifier des espaces.
        /// </summary>
        private void DesactiverInputs()
        {
            textBoxNom.Enabled = false;

            comboBoxEspace.Enabled = false;
            comboBoxJeu.Enabled = false;
            dateTimePickerDateTournoi.Enabled = false;
            numericUpDownNbParticip.Enabled = false;
            numericUpDownDuree.Enabled = false;
            radioButtonEnCours.Enabled = false;
            radioButtonPlanifié.Enabled = false;
            radioButtonTermine.Enabled = false;
        }

        /// <summary>
        /// Permet d'afficher ou de masquer les boutons d'action en fonction de la sélection actuelle d'un espace.
        /// </summary>
        private void AfficherBoutons()
        {
            buttonAjouter.Enabled = _tournoiSelectionne == null;

            // Si aucun espace n'est sélectionné, les boutons de modification, suppression et effacement sont désactivés
            buttonModifier.Enabled = _tournoiSelectionne != null;
            buttonSupprimer.Enabled = _tournoiSelectionne != null;
            buttonEffacer.Enabled = _tournoiSelectionne != null;
        }

        /// <summary>
        /// Resets all tournament-related input fields and controls to their default values.
        /// </summary>
        /// <remarks>Use this method to clear the current tournament selection and prepare the form for
        /// entering a new tournament. All user input fields are cleared or set to their minimum values, and the status
        /// controls are reset to indicate a planned tournament.</remarks>
        private void Raz_Zones()
        {
            filtre = "";

            _tournoiSelectionne = null;

            textBoxNom.Clear();

            comboBoxEspace.SelectedItem = null;
            comboBoxJeu.SelectedItem = null;
            dateTimePickerDateTournoi.Value = dateTimePickerDateTournoi.MinDate;
            numericUpDownNbParticip.Value = numericUpDownNbParticip.Minimum;
            numericUpDownDuree.Value = numericUpDownDuree.Minimum;
            radioButtonEnCours.Checked = false;
            radioButtonPlanifié.Checked = false;
            radioButtonTermine.Checked = false;

            ChargerTournois();
            ChargerEspaces();
            ChargerJeux();

            AfficherBoutons();
        }

        /// <summary>
        /// Remplit les champs du formulaire avec les informations du tournoi spécifié.
        /// </summary>
        /// <remarks>Cette méthode met à jour les contrôles du formulaire pour refléter les propriétés du
        /// tournoi fourni. Elle doit être appelée lors de l'affichage ou de la modification d'un tournoi
        /// existant.</remarks>
        private void RemplirFormulaire()
        {
            if (_tournoiSelectionne == null)
            {
                MessageBox.Show("Aucun tournoi sélectionné.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            textBoxNom.Text = _tournoiSelectionne.Nom;
            dateTimePickerDateTournoi.Value = _tournoiSelectionne.DateHeure;
            numericUpDownNbParticip.Value = _tournoiSelectionne.NbParticipants;
            numericUpDownDuree.Value = _tournoiSelectionne.DureePrevue;

            // ComboBox Espace
            comboBoxEspace.SelectedItem = _tournoiSelectionne.Espace;
            comboBoxEspace.SelectedValue = _tournoiSelectionne.IdEspace;

            // ComboBox Jeu
            comboBoxJeu.SelectedItem = _tournoiSelectionne.Jeu;
            comboBoxJeu.SelectedValue = _tournoiSelectionne.IdJeu;

            // Statut (RadioButtons)
            radioButtonPlanifié.Checked = _tournoiSelectionne.Statut == "Planifié";
            radioButtonEnCours.Checked = _tournoiSelectionne.Statut == "En cours";
            radioButtonTermine.Checked = _tournoiSelectionne.Statut == "Terminé";

            AfficherBoutons();
        }

        /// <summary>
        /// Permet de désactiver le tri automatique sur les colonnes d'un DataGridView pour gérer le tri manuellement dans l'événement CellClick.
        /// </summary>
        /// <param name="dataGrid">Le DataGridView dont les colonnes doivent être configurées.</param>
        static void DesactiverTrieAutomatique(DataGridView dataGrid)
        {
            foreach (DataGridViewColumn col in dataGrid.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }
        #endregion
    }
}

