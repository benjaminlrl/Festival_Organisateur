using Lib_Entities.Entities;
using Lib_Metier.Data.Configurations;
using Lib_Services.Interfaces;
using Lib_Services.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Serilog;

namespace ApplicationUi
{
    public partial class UcParticiper : UserControl
    {
        private readonly ApplicationDbContext _context;
        private readonly ITournoiService _serviceTournoi;
        private readonly IOrganisateurService _serviceOrganisateur;
        private readonly IParticiperService _serviceParticiper;
        private readonly Organisateur _organisateurConnecte;
        private Participer? _participerSelectionne;
        private bool lotRemisSelectionne;
        private string filtre;
        private string ordreChamp;
        private string ordreChampJoueur;

        public UcParticiper(Organisateur unOrganisateurConnecte)
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
            _serviceTournoi = new TournoiService(_context);
            _serviceOrganisateur = new OrganisateurService(_context);
            _serviceParticiper = new ParticiperService(_context);

            _organisateurConnecte = unOrganisateurConnecte;
            _participerSelectionne = null;
            lotRemisSelectionne = false;

            dateTimePickerDateHeureInscription.Enabled = false;
            dateTimePickerDateHeureInscription.MinDate = DateTime.Now.AddMonths(-3);
            dateTimePickerDateHeureInscription.MaxDate = DateTime.Now;

            filtre = "";
            ordreChamp = "DESC";
            ordreChampJoueur = "DESC";
            buttonEffacer.Text = " 🧽  Effacer";

            Raz_Zones();

            if (_serviceOrganisateur.EstAutoriser(_organisateurConnecte, Organisateur.LesUC.UcEspaces, "Ajouter") == false)
            {
                buttonAjouter.Visible = false;
                DesactiverInputs();
            }
            if (_serviceOrganisateur.EstAutoriser(_organisateurConnecte, Organisateur.LesUC.UcEspaces, "Modifier") == false)
            {
                buttonModifier.Visible = false;
                DesactiverInputs();
            }
            if (_serviceOrganisateur.EstAutoriser(_organisateurConnecte, Organisateur.LesUC.UcEspaces, "Supprimer") == false)
            {
                buttonSupprimer.Visible = false;
                DesactiverInputs();
            }
        }
        #region Données
        /// <summary>
        /// Met à jour l'affichage des participations dans le contrôle de grille de données en appliquant le filtre
        /// courant.
        /// </summary>
        /// <remarks>Cette méthode recharge la liste des participations affichées et met à jour les
        /// statistiques associées. Elle doit être appelée après toute modification du filtre ou des données
        /// sous-jacentes pour garantir que l'affichage reste cohérent.</remarks>
        private void ChargerParticipations()
        {
            dataGridParticipations.DataSource = null;
            dataGridParticipations.DataSource = _serviceParticiper.Lister(filtre);
            MEP_DataGridParticipations();
            ChargerStatistiques();
        }

        /// <summary>
        /// Met à jour l'affichage des participations dans le contrôle de grille de données en appliquant le filtre
        /// courant.
        /// </summary>
        /// <remarks>Cette méthode recharge la liste des participations affichées et met à jour les
        /// statistiques associées. Elle doit être appelée après toute modification du filtre ou des données
        /// sous-jacentes pour garantir que l'affichage reste cohérent.</remarks>
        private void ChargerParticipationsJoueur()
        {
            dataGridParticipationsJoueur.DataSource = null;

            if (_participerSelectionne != null)
                dataGridParticipationsJoueur.DataSource = _serviceParticiper.ListerParJoueur(_participerSelectionne.IdUser,filtre);

            MEP_DataGridParticipationsJoueur();
            ChargerStatistiques();
        }

        /// <summary>
        /// Charge la liste des tournois et met à jour la source de données du contrôle ComboBox pour permettre la
        /// sélection d'un tournoi par son nom.
        /// </summary>
        /// <remarks>Le contrôle ComboBox affiche le nom du tournoi à l'utilisateur tout en conservant
        /// l'identifiant du tournoi comme valeur associée. Cette méthode doit être appelée pour rafraîchir la liste des
        /// tournois disponibles, par exemple après l'ajout ou la suppression d'un tournoi.</remarks>
        private void ChargerTournois()
        {
            comboBoxTournoi.DataSource = null;
            comboBoxTournoi.DataSource = _serviceTournoi.Lister("");
            // charge les tournois dans le comboBox et affiche le nom tout en conservant l'id en valeur
            comboBoxTournoi.DisplayMember = "Nom";
            comboBoxTournoi.ValueMember = "NumeroTournoi";
        }
        /// <summary>
        /// Charge la liste des utilisateurs dans le contrôle de sélection utilisateur et configure l'affichage des
        /// identifiants.
        /// </summary>
        /// <remarks>Cette méthode réinitialise la source de données du contrôle, puis la remplit avec la
        /// liste des utilisateurs obtenue via le service associé. Le champ affiché et la valeur sélectionnée
        /// correspondent à l'identifiant de l'utilisateur. À utiliser pour synchroniser l'interface avec les données
        /// actuelles des utilisateurs.</remarks>
        private void ChargerUtilisateurs()
        {
            comboBoxUtilisateur.DataSource = null;
            comboBoxUtilisateur.DataSource = _serviceParticiper.ListerIdsParticipants(); // TODO: remplacer par un service utilisateur lorsque les utilisateurs seront intégrés
            // charge les participations dans le comboBox et affiche l'id tout en conservant l'id en valeur
            comboBoxUtilisateur.DisplayMember = "IdUser";
            comboBoxUtilisateur.ValueMember = "IdUser";
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
            //// Un espace libre est un espae qui n'a pas de tournoi associé
            //int nbPostesJeuFonctionnels = _serviceParticiper.Lister("").Count(e => e.Fonctionnel == true);

            //labelStatPostesJeuTotal.Text = $"{_serviceParticiper.Lister("").Count()}";

            //if (nbPostesJeuFonctionnels == 0)
            //{
            //    labelStatPostesJeuFonctionnels.Text = "Aucun poste fonctionnel";
            //    labelStatPostesJeuFonctionnels.ForeColor = Color.Red;
            //}
            //else
            //{
            //    labelStatPostesJeuFonctionnels.Text = $"Fonctionnels : {nbPostesJeuFonctionnels}";
            //    labelStatPostesJeuFonctionnels.ForeColor = Color.Green;
            //}
        }
        private void MEP_DataGridParticipations()
        {
            DesactiverTrieAutomatique(dataGridParticipations);

            dataGridParticipations.Columns["Tournoi"].Visible = false;
            dataGridParticipations.Columns["NumeroTournoi"].Visible = false;
            dataGridParticipations.Columns["Rang"].Visible = false;
            dataGridParticipations.Columns["Evaluation"].Visible = false;
            dataGridParticipations.Columns["Commentaire"].Visible = false;
            dataGridParticipations.Columns["ScoreFinal"].Visible = false;
            dataGridParticipations.Columns["LotRemis"].Visible = false;

            dataGridParticipations.Columns["NomTournoi"].HeaderText = "Tournoi";
            dataGridParticipations.Columns["IdUser"].HeaderText = "Utilisateur";
            dataGridParticipations.Columns["DateHeureInscription"].HeaderText = "Date d'inscription";

            dataGridParticipations.Columns["NomTournoi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridParticipations.Columns["IdUser"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridParticipations.Columns["DateHeureInscription"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void MEP_DataGridParticipationsJoueur()
        {
            DesactiverTrieAutomatique(dataGridParticipationsJoueur);
            
            if (_participerSelectionne != null)
            {

                dataGridParticipationsJoueur.Columns["Tournoi"].Visible = false;
                dataGridParticipationsJoueur.Columns["NumeroTournoi"].Visible = false;
                dataGridParticipationsJoueur.Columns["Rang"].Visible = false;
                dataGridParticipationsJoueur.Columns["Evaluation"].Visible = false;
                dataGridParticipationsJoueur.Columns["Commentaire"].Visible = false;
                dataGridParticipationsJoueur.Columns["ScoreFinal"].Visible = false;
                dataGridParticipationsJoueur.Columns["LotRemis"].Visible = false;
                dataGridParticipationsJoueur.Columns["DateHeureInscription"].Visible = false;
                dataGridParticipationsJoueur.Columns["NomTournoi"].HeaderText = "Tournoi";
                dataGridParticipationsJoueur.Columns["IdUser"].HeaderText = "Utilisateur";

                dataGridParticipationsJoueur.Columns["NomTournoi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridParticipationsJoueur.Columns["IdUser"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }
        #endregion

        #region Evènements
        #region Boutons
        public void ButtonAjouter_Click(object sender, EventArgs e)
        {
            Participer participer = new ()
            {
                Rang = (int)numericUpDownRang.Value,
                ScoreFinal = (int)numericUpDownScoreFinal.Value,
                Commentaire = textBoxCommentaire.Text,
                Evaluation = trackBarEvaluation.Value,
                DateHeureInscription = DateTime.Now,
                IdUser = 1,//((Participer)comboBoxUtilisateur.SelectedItem).IdUser lorsque les utilisateurs seront intégrés
                NumeroTournoi = (comboBoxTournoi.SelectedItem as Tournoi).NumeroTournoi,
                LotRemis = lotRemisSelectionne
            };

            try
            {
                _serviceParticiper.Creer(participer);
                MessageBox.Show("La participation a bien été ajoutée.", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Raz_Zones();
            }
            catch (ParticiperException ex)
            {
                Log.Warning("[{Code}] {Message}", ex.CodeErreur, ex.Message);
                MessageBox.Show(ex.Message, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DbException ex)
            {
                Log.Error(ex, "Une erreur technique est survenue lors de l'ajout de la participation.");
                MessageBox.Show("Erreur technique, réessayez plus tard.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Une erreur inattendue est survenue.");
                MessageBox.Show("Une erreur inattendue est survenue.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ButtonModifier_Click(object sender, EventArgs e)
        {
            if (dataGridParticipations.CurrentRow == null || _participerSelectionne == null)
            {
                MessageBox.Show("Aucune participation sélectionnée", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _participerSelectionne.Rang = (int)numericUpDownRang.Value;
            _participerSelectionne.ScoreFinal = (int)numericUpDownScoreFinal.Value;
            _participerSelectionne.Commentaire = textBoxCommentaire.Text;
            _participerSelectionne.Evaluation = trackBarEvaluation.Value;
            _participerSelectionne.IdUser = 1; //((Participer)comboBoxUtilisateur.SelectedItem).IdUser lorsque les utilisateurs seront intégrés
            _participerSelectionne.NumeroTournoi = (comboBoxTournoi.SelectedItem as Tournoi).NumeroTournoi;
            _participerSelectionne.LotRemis = lotRemisSelectionne;

            try
            {
                _serviceParticiper.Modifier(_participerSelectionne);
                MessageBox.Show("La participation a bien été modifiée.", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Raz_Zones();
            }
            catch (ParticiperException ex)
            {
                Log.Warning("[{Code}] {Message}", ex.CodeErreur, ex.Message);
                MessageBox.Show(ex.Message, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DbException ex)
            {
                Log.Error(ex, "Une erreur technique est survenue lors de la modification de la participation.");
                MessageBox.Show("Erreur technique, réessayez plus tard.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Une erreur inattendue est survenue.");
                MessageBox.Show("Une erreur inattendue est survenue.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonEffacer_Click(object sender, EventArgs e)
        {
            Raz_Zones();
        }
        private void ButtonSupprimer_Click(object sender, EventArgs e)
        {
            if (dataGridParticipations.CurrentRow == null || _participerSelectionne == null)
            {
                MessageBox.Show("Aucune participation sélectionnée", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _serviceParticiper.Supprimer(_participerSelectionne.IdUser, _participerSelectionne.NumeroTournoi);
            _participerSelectionne = null;
            MessageBox.Show("La participation a bien été supprimée.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Raz_Zones();
        }

        #endregion
        private void DataGridParticipations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Gérer le trie par ordre des champs en fonction du clique sur la cellule d'en-tête
            if (e.RowIndex < 0)
            {

                // Utiliser un dictionnaire plutôt qu'un switch pour associer les index de colonnes
                // à des fonctions de sélection de clé
                Dictionary<int, string> map = new ()
                {
                    {dataGridParticipations.Columns["IdUser"].Index, "IdUser"},
                    {dataGridParticipations.Columns["NomTournoi"].Index, "NomTournoi"},
                    {dataGridParticipations.Columns["DateHeureInscription"].Index, "DateHeureInscription"},
                    {dataGridParticipations.Columns["Evaluation"].Index, "Evaluation"},
                    {dataGridParticipations.Columns["Rang"].Index, "Rang"},
                };

                if (!map.TryGetValue(e.ColumnIndex, out string? colonne))
                    return;

                ordreChamp = ordreChamp == "ASC" ? "DESC" : "ASC";

                dataGridParticipations.DataSource = _serviceParticiper.Lister(filtre, colonne, ordreChamp);
                dataGridParticipations.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = 
                    ordreChamp == "ASC" ? SortOrder.Ascending : SortOrder.Descending;

                MEP_DataGridParticipations();
                return;
            }

            _participerSelectionne = dataGridParticipations.Rows[e.RowIndex].DataBoundItem as Participer;

            if (_participerSelectionne != null)
                RemplirFormulaire();

            AfficherBoutons();
        }

        private void DataGridParticipationsJoueur_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Gérer le trie par ordre des champs en fonction du clique sur la cellule d'en-tête
            if (e.RowIndex < 0 && _participerSelectionne != null)
            {

                // Utiliser un dictionnaire plutôt qu'un switch pour associer les index de colonnes
                // à des fonctions de sélection de clé
                Dictionary<int, string> map = new()
                {
                    {dataGridParticipationsJoueur.Columns["NomTournoi"].Index, "NomTournoi"},
                    {dataGridParticipationsJoueur.Columns["IdUser"].Index, "IdUser"},
                };

                if (!map.TryGetValue(e.ColumnIndex, out string? colonne))
                    return;

                ordreChampJoueur = ordreChampJoueur == "ASC" ? "DESC" : "ASC";

                dataGridParticipationsJoueur.DataSource = _serviceParticiper.ListerParJoueur(
                    _participerSelectionne.IdUser, filtre, colonne, ordreChampJoueur);

                dataGridParticipationsJoueur.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection =
                    ordreChampJoueur == "ASC" ? SortOrder.Ascending : SortOrder.Descending;

                MEP_DataGridParticipationsJoueur();
                return;
            }

            _participerSelectionne = dataGridParticipations.Rows[e.RowIndex].DataBoundItem as Participer;

            if (_participerSelectionne != null)
                RemplirFormulaire();

            AfficherBoutons();
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
            ChargerParticipations();
            ChargerParticipationsJoueur();

        }
        private void RadioButtonLotRemisFalse_CheckedChanged(object sender, EventArgs e)
        {
            lotRemisSelectionne = false;
        }

        private void RadioButtonLotRemisTrue_CheckedChanged(object sender, EventArgs e)
        {
            lotRemisSelectionne = true;
        }
        #endregion

        #region Méthodes
        /// <summary>
        /// Permet de désactiver les champs de saisie du formulaire si l'utilisateur 
        /// n'a pas les droits nécessaires pour ajouter ou modifier des espaces.
        /// </summary>
        private void DesactiverInputs()
        {
            textBoxCommentaire.Enabled = false;
            comboBoxUtilisateur.Enabled = false;
            comboBoxTournoi.Enabled = false;
            radioButtonLotRemisTrue.Enabled = false;
            radioButtonLotRemisFalse.Enabled = false;
            dateTimePickerDateHeureInscription.Enabled = false;
            numericUpDownScoreFinal.Enabled = false;
            numericUpDownRang.Enabled = false;
            trackBarEvaluation.Enabled = false;
        }

        /// <summary>
        /// Resets all tournament-related input fields and controls to their default values.
        /// </summary>
        /// <remarks>Use this method to clear the current tournament selection and prepare the form for
        /// entering a new tournament. All user input fields are cleared or set to their minimum values, and the status
        /// controls are reset to indicate a planned tournament.</remarks>
        private void Raz_Zones()
        {
            textBoxCommentaire.Clear();

            filtre = "";

            _participerSelectionne = null;

            comboBoxUtilisateur.SelectedItem = null;
            comboBoxTournoi.SelectedItem = null;
            radioButtonLotRemisTrue.Checked = false;
            radioButtonLotRemisFalse.Checked = false;
            dateTimePickerDateHeureInscription.Value = dateTimePickerDateHeureInscription.MinDate;
            numericUpDownScoreFinal.Value = numericUpDownScoreFinal.Minimum;
            numericUpDownRang.Value = numericUpDownRang.Minimum;
            trackBarEvaluation.Value = trackBarEvaluation.Minimum;

            ChargerParticipations();
            ChargerParticipationsJoueur();
            ChargerTournois();
            ChargerUtilisateurs();

            AfficherBoutons();
        }

        /// <summary>
        /// Remplit les champs du formulaire avec les informations de la participation spécifiée.
        /// </summary>
        /// <remarks>Cette méthode met à jour les contrôles du formulaire pour refléter les propriétés de
        /// la participation fournie. Elle doit être appelée lors de l'affichage ou de la modification d'une participation
        /// existante.</remarks>
        private void RemplirFormulaire()
        {
            if (_participerSelectionne == null)
            {
                MessageBox.Show("Aucun espace sélectionné.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            numericUpDownRang.Maximum = _participerSelectionne.Tournoi.NbParticipants;
            numericUpDownRang.Value = _participerSelectionne.Rang;
            numericUpDownScoreFinal.Value = _participerSelectionne.ScoreFinal ?? numericUpDownScoreFinal.Minimum;
            textBoxCommentaire.Text = _participerSelectionne.Commentaire;
            trackBarEvaluation.Value = _participerSelectionne.Evaluation ?? trackBarEvaluation.Minimum;
            dateTimePickerDateHeureInscription.Value = _participerSelectionne.DateHeureInscription;

            comboBoxUtilisateur.SelectedItem = _participerSelectionne.IdUser;

            comboBoxTournoi.SelectedItem = _participerSelectionne.Tournoi;
            comboBoxTournoi.SelectedValue = _participerSelectionne.NumeroTournoi;

            // LotRemis (RadioButtons)
            if (_participerSelectionne.LotRemis)
            {
                radioButtonLotRemisTrue.Checked = true;
                lotRemisSelectionne = true;
            }
            else
            {
                radioButtonLotRemisFalse.Checked = true;
                lotRemisSelectionne = false;
            }

            ChargerParticipationsJoueur();

            AfficherBoutons();
        }

        /// <summary>
        /// Permet d'afficher ou de masquer les boutons d'action en fonction de la sélection actuelle d'un espace.
        /// </summary>
        private void AfficherBoutons()
        {
            buttonAjouter.Enabled = true;

            // Si aucune participation n'est sélectionnée, les boutons de modification, suppression et effacement sont désactivés
            buttonModifier.Enabled = _participerSelectionne != null;
            buttonSupprimer.Enabled = _participerSelectionne != null;
            buttonEffacer.Enabled = _participerSelectionne != null;
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
