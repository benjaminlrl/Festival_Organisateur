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
        private readonly IJoueurService _serviceJoueur;
        private readonly Organisateur _organisateurConnecte;
        private Participer? _participationSelectionnee;
        private bool lotRemisSelectionne;
        private string filtre;
        private string ordreChamp;
        private string ordreChampJoueur;
        public Action<Tournoi>? NaviguerVersTournois;

        public UcParticiper(Organisateur unOrganisateurConnecte)
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
            _serviceTournoi = new TournoiService(_context);
            _serviceOrganisateur = new OrganisateurService(_context);
            _serviceParticiper = new ParticiperService(_context);
            _serviceJoueur = new JoueurService(_context);

            _organisateurConnecte = unOrganisateurConnecte;
            _participationSelectionnee = null;
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

            if (_participationSelectionnee != null)
                dataGridParticipationsJoueur.DataSource = _serviceParticiper.ListerParJoueur(_participationSelectionnee.IdUser, filtre);

            MEP_DataGridParticipationsJoueur();
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
            comboBoxUtilisateur.DataSource = _serviceJoueur.Lister(""); // TODO: remplacer par un service utilisateur lorsque les utilisateurs seront intégrés
            // charge les participations dans le comboBox et affiche l'id tout en conservant l'id en valeur
            comboBoxUtilisateur.DisplayMember = "IdUser";
            comboBoxUtilisateur.ValueMember = "IdUser";
        }

        private void MEP_DataGridParticipations()
        {
            DesactiverTrieAutomatique(dataGridParticipations);

            dataGridParticipations.Columns["Tournoi"]!.Visible = false;
            dataGridParticipations.Columns["NumeroTournoi"]!.Visible = false;
            dataGridParticipations.Columns["Rang"]!.Visible = false;
            dataGridParticipations.Columns["Evaluation"]!.Visible = false;
            dataGridParticipations.Columns["Commentaire"]!.Visible = false;
            dataGridParticipations.Columns["ScoreFinal"]!.Visible = false;
            dataGridParticipations.Columns["LotRemis"]!.Visible = false;

            dataGridParticipations.Columns["NomTournoi"]!.HeaderText = "Tournoi";
            dataGridParticipations.Columns["IdUser"]!.HeaderText = "Utilisateur";
            dataGridParticipations.Columns["DateHeureInscription"]!.HeaderText = "Date d'inscription";

            dataGridParticipations.Columns["NomTournoi"]!.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridParticipations.Columns["IdUser"]!.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridParticipations.Columns["DateHeureInscription"]!.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void MEP_DataGridParticipationsJoueur()
        {
            DesactiverTrieAutomatique(dataGridParticipationsJoueur);

            if (_participationSelectionnee != null)
            {

                dataGridParticipationsJoueur.Columns["Tournoi"]!.Visible = false;
                dataGridParticipationsJoueur.Columns["NumeroTournoi"]!.Visible = false;
                dataGridParticipationsJoueur.Columns["Rang"]!.Visible = false;
                dataGridParticipationsJoueur.Columns["Evaluation"]!.Visible = false;
                dataGridParticipationsJoueur.Columns["Commentaire"]!.Visible = false;
                dataGridParticipationsJoueur.Columns["ScoreFinal"]!.Visible = false;
                dataGridParticipationsJoueur.Columns["LotRemis"]!.Visible = false;
                dataGridParticipationsJoueur.Columns["DateHeureInscription"]!.Visible = false;
                dataGridParticipationsJoueur.Columns["NomTournoi"]!.HeaderText = "Tournoi";
                dataGridParticipationsJoueur.Columns["IdUser"]!.HeaderText = "Utilisateur";

                dataGridParticipationsJoueur.Columns["NomTournoi"]!.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridParticipationsJoueur.Columns["IdUser"]!.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }
        #endregion

        #region Evènements
        #region Boutons
        public void ButtonAjouter_Click(object sender, EventArgs e)
        {
            Participer participation = new()
            {
                Rang = (int)numericUpDownRang.Value,
                ScoreFinal = (int)numericUpDownScoreFinal.Value,
                Commentaire = textBoxCommentaire.Text,
                Evaluation = trackBarEvaluation.Value,
                DateHeureInscription = DateTime.Now,
                IdUser = ((Joueur)comboBoxUtilisateur.SelectedItem!).IdUser,
                NumeroTournoi = (comboBoxTournoi.SelectedItem as Tournoi)!.NumeroTournoi,
                LotRemis = lotRemisSelectionne
            };

            try
            {
                _serviceParticiper.Creer(participation);
                MessageBox.Show("La participation a bien été ajoutée.", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Raz_Zones();
            }
            catch (ParticiperException ex)
            {
                Log.Warning("[{Code}] {Message}", ex.CodeErreur, ex.Message);
                MessageBox.Show(ex.Message, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (dataGridParticipations.CurrentRow == null || _participationSelectionnee == null)
            {
                Log.Warning("Aucune participation sélectionné.");
                MessageBox.Show("Aucune participation sélectionnée", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _participationSelectionnee.Rang = (int)numericUpDownRang.Value;
            _participationSelectionnee.ScoreFinal = (int)numericUpDownScoreFinal.Value;
            _participationSelectionnee.Evaluation = trackBarEvaluation.Value;
            _participationSelectionnee.Commentaire = textBoxCommentaire.Text;
            _participationSelectionnee.IdUser = ((Joueur)comboBoxUtilisateur.SelectedItem!).IdUser;
            _participationSelectionnee.NumeroTournoi = (comboBoxTournoi.SelectedItem as Tournoi)!.NumeroTournoi;
            _participationSelectionnee.LotRemis = lotRemisSelectionne;

            ModifierParticipation(_participationSelectionnee);
        }
        private void ButtonEffacer_Click(object sender, EventArgs e)
        {
            Raz_Zones();
        }
        private void ButtonSupprimer_Click(object sender, EventArgs e)
        {
            if (dataGridParticipations.CurrentRow == null || _participationSelectionnee == null)
            {
                Log.Warning("Aucune participation sélectionné.");
                MessageBox.Show("Aucune participation sélectionnée", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Êtes vous sûr de vouloir supprimer ?", "Suppression",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            SupprimerParticipation(false);
        }

        #endregion
        private void DataGridParticipations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Gérer le trie par ordre des champs en fonction du clique sur la cellule d'en-tête
            if (e.RowIndex < 0)
            {

                // Utiliser un dictionnaire plutôt qu'un switch pour associer les index de colonnes
                // à des fonctions de sélection de clé
                Dictionary<int, string> map = new()
                {
                    {dataGridParticipations.Columns["IdUser"]!.Index, "IdUser"},
                    {dataGridParticipations.Columns["NomTournoi"]!.Index, "NomTournoi"},
                    {dataGridParticipations.Columns["DateHeureInscription"]!.Index, "DateHeureInscription"},
                    {dataGridParticipations.Columns["Evaluation"]!.Index, "Evaluation"},
                    {dataGridParticipations.Columns["Rang"]!.Index, "Rang"},
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

            _participationSelectionnee = dataGridParticipations.Rows[e.RowIndex].DataBoundItem as Participer;

            if (_participationSelectionnee != null)
                RemplirFormulaire();

            AfficherBoutons();
        }

        private void DataGridParticipationsJoueur_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Gérer le trie par ordre des champs en fonction du clique sur la cellule d'en-tête
            if (e.RowIndex < 0 && _participationSelectionnee != null)
            {

                // Utiliser un dictionnaire plutôt qu'un switch pour associer les index de colonnes
                // à des fonctions de sélection de clé
                Dictionary<int, string> map = new()
                {
                    {dataGridParticipationsJoueur.Columns["NomTournoi"]!.Index, "NomTournoi"},
                    {dataGridParticipationsJoueur.Columns["IdUser"]!.Index, "IdUser"},
                };

                if (!map.TryGetValue(e.ColumnIndex, out string? colonne))
                    return;

                ordreChampJoueur = ordreChampJoueur == "ASC" ? "DESC" : "ASC";

                dataGridParticipationsJoueur.DataSource = _serviceParticiper.ListerParJoueur(
                    _participationSelectionnee.IdUser, filtre, colonne, ordreChampJoueur);

                dataGridParticipationsJoueur.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection =
                    ordreChampJoueur == "ASC" ? SortOrder.Ascending : SortOrder.Descending;

                MEP_DataGridParticipationsJoueur();
                return;
            }

            _participationSelectionnee = dataGridParticipationsJoueur.Rows[e.RowIndex].DataBoundItem as Participer;

            if (_participationSelectionnee != null)
                RemplirFormulaire();

            AfficherBoutons();
        }


        private void dataGridParticipations_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

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
        /// Permet de déterminer d'afficher une indication visuelle sur les tournois associés à l'espace sélectionné, 
        /// en fonction de leur statut (en cours, planifié ou aucun tournoi).
        /// </summary>
        private void StatutTournois()
        {
            if (_participationSelectionnee?.Tournoi == null)
            {
                labelStatutTournoi.Text = "Statut";
                labelStatutTournoi.ForeColor = Color.DarkGray;
                labelStatutTournoi.BackColor = Color.White;
                return;
            }


            switch (_participationSelectionnee.Tournoi.Statut)
            {
                case "En cours":
                    labelStatutTournoi.Text = "Tournoi en cours";
                    labelStatutTournoi.ForeColor = Color.Maroon;
                    labelStatutTournoi.BackColor = Color.FromArgb(255, 128, 128);
                    break;

                case "Planifié":
                    labelStatutTournoi.Text = "Planifié";
                    labelStatutTournoi.ForeColor = Color.Chocolate;
                    labelStatutTournoi.BackColor = Color.FromArgb(255, 224, 192);
                    break;

                case "Terminé":
                    labelStatutTournoi.Text = "Terminé";
                    labelStatutTournoi.ForeColor = Color.DarkGreen;
                    labelStatutTournoi.BackColor = Color.FromArgb(192, 255, 192);
                    break;

                default:
                    labelStatutTournoi.Text = "Statut";
                    labelStatutTournoi.ForeColor = Color.DarkGray;
                    labelStatutTournoi.BackColor = Color.White;
                    break;
            }
        }

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

            _participationSelectionnee = null;

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

            StatutTournois();
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
            if (_participationSelectionnee == null)
            {
                Log.Warning("Aucun espace sélectionné.");
                MessageBox.Show("Aucun espace sélectionné.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            numericUpDownRang.Maximum = _participationSelectionnee.Tournoi!.NbParticipants;
            numericUpDownRang.Value = _participationSelectionnee.Rang;
            trackBarEvaluation.Value = _participationSelectionnee.Evaluation;
            numericUpDownScoreFinal.Value = _participationSelectionnee.ScoreFinal;
            textBoxCommentaire.Text = _participationSelectionnee.Commentaire;
            dateTimePickerDateHeureInscription.Value = _participationSelectionnee.DateHeureInscription;

            comboBoxUtilisateur.SelectedValue = _participationSelectionnee.IdUser;

            comboBoxTournoi.SelectedItem = _participationSelectionnee.Tournoi;
            comboBoxTournoi.SelectedValue = _participationSelectionnee.NumeroTournoi;

            // LotRemis (RadioButtons)
            if (_participationSelectionnee.LotRemis)
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
            StatutTournois();
            AfficherBoutons();
        }

        /// <summary>
        /// Permet d'afficher ou de masquer les boutons d'action en 
        /// fonction de la sélection actuelle d'une participation'.
        /// </summary>
        private void AfficherBoutons()
        {
            buttonAjouter.Enabled = true;

            // Si aucune participation n'est sélectionnée, les boutons de modification,
            // suppression et effacement sont désactivés
            buttonModifier.Enabled = _participationSelectionnee != null;
            buttonSupprimer.Enabled = _participationSelectionnee != null;
            buttonEffacer.Enabled = _participationSelectionnee != null;
        }

        /// <summary>
        /// Permet de désactiver le tri automatique sur les colonnes d'un DataGridView 
        /// pour gérer le tri manuellement dans l'événement CellClick.
        /// </summary>
        /// <param name="dataGrid">Le DataGridView dont les colonnes doivent être configurées.</param>
        static void DesactiverTrieAutomatique(DataGridView dataGrid)
        {
            foreach (DataGridViewColumn col in dataGrid.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }

        /// <summary>
        /// Permet de modifier une participation en gérant les différentes exceptions qui peuvent survenir,
        /// notamment lorsqu'il existe des postes de jeu associés à la participation.
        /// </summary>
        private void ModifierParticipation(Participer? participation)
        {
            try
            {
                _serviceParticiper.Modifier(participation);
                MessageBox.Show("La participation a bien été modifiée.", "Modification",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Raz_Zones();
            }
            catch (ParticiperException ex)
            {
                Log.Warning("[{Code}] {Message}", ex.CodeErreur, ex.Message);
                MessageBox.Show(ex.Message);
            }
            catch (DbException ex)
            {
                Log.Error(ex, "Erreur technique lors de la modification de la participation.");
                MessageBox.Show("Erreur technique, réessayez plus tard.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erreur inattendue lors de la modification de la participation.");
                MessageBox.Show("Une erreur inattendue est survenue. \n" +
                    ex.Message);
            }
        }

        /// <summary>
        /// Permets de supprimer une participation en gérant les différentes exceptions qui peuvent survenir,
        /// notamment lorsque la participation est associé a un tournoi en cours
        /// <param name="forcerTournoi"></param>
        private void SupprimerParticipation(bool forcerTournoi)
        {
            try
            {
                _serviceParticiper.Supprimer(_participationSelectionnee!.IdUser, _participationSelectionnee!.NumeroTournoi,
                    forcerTournoi);

                if (!forcerTournoi)
                    MessageBox.Show("La participation a bien été supprimée.", "Suppression",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("La participation a bien été supprimée malgrès un tournoi en cours", "Suppression",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                Raz_Zones();
            }
            catch (ParticiperException ex) when (ex.CodeErreur == (int)ParticiperException.ParticiperErreur.SuppressionParticiperTournoiExistant && !forcerTournoi)
            {
                Log.Warning("[{Code}] {Message}", ex.CodeErreur, ex.Message);
                if (MessageBox.Show("Impossible de supprimer la participation puisqu'elle est associé à tounoi en cours.\n" +
                    "Voulez-vous forcer sa suppression ?", "Suppression",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                    return;

                SupprimerParticipation(true); // rappel avec le forçage
            }
            catch (ParticiperException ex)
            {
                Log.Warning("[{Code}] {Message}", ex.CodeErreur, ex.Message);
                MessageBox.Show(ex.Message);
            }
            catch (DbException ex)
            {
                Log.Error(ex, "Erreur technique lors de la suppression de la participation.");
                MessageBox.Show("Erreur technique, réessayez plus tard.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erreur inattendue lors de la suppression de la participation.");
                MessageBox.Show("Une erreur inattendue est survenue.\n" +
                    ex.Message);
            }
        }
        #endregion
    }
}
