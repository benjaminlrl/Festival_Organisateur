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
    public partial class UcParticiper : UserControl
    {
        private readonly ApplicationDbContext _context;
        private readonly ITournoiService _serviceTournoi;
        private readonly IOrganisateurService _serviceOrganisateur;
        private readonly IEspaceService _serviceEspace;
        private readonly IParticiperService _serviceParticiper;
        private readonly IPlateformeService _servicePlateforme;
        private readonly Organisateur _organisateurConnecte;
        private Participer? _participerSelectionne;
        private bool lotRemisSelectionne;
        private string filtre;
        private string ordreChamp;

        public UcParticiper(Organisateur unOrganisateurConnecte)
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
            _serviceTournoi = new TournoiService(_context);
            _serviceOrganisateur = new OrganisateurService(_context);
            _serviceEspace = new EspaceService(_context);
            _serviceParticiper = new ParticiperService(_context);
            _servicePlateforme = new PlateformeService(_context);

            _organisateurConnecte = unOrganisateurConnecte;
            _participerSelectionne = null;
            lotRemisSelectionne = false;

            AfficherBouttons();

            filtre = "";
            ordreChamp = "ASC";
            buttonEffacer.Text = " 🧽  Effacer";

            ChargerUtilisateurs();
            ChargerTournois();
            ChargerParticipations();

            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcEspaces, "Ajouter") == false)
            {
                buttonAjouter.Visible = false;
                DisabledInputs();
            }
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcEspaces, "Modifier") == false)
            {
                buttonModifier.Visible = false;
                DisabledInputs();
            }
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcEspaces, "Supprimer") == false)
            {
                buttonSupprimer.Visible = false;
                DisabledInputs();
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
            comboBoxUtilisateur.DataSource = _serviceParticiper.Lister(""); // TODO: remplacer par un service utilisateur lorsque les utilisateurs seront intégrés
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
            dataGridParticipations.Columns["NomTournoi"].HeaderText = "Tournoi";
            dataGridParticipations.Columns["IdUser"].HeaderText = "Utilisateur";
            dataGridParticipations.Columns["DateHeureInscription"].HeaderText = "Date d'inscription";
        }
        #endregion
        #region Evènements
        #region Boutons
        public void buttonAjouter_Click(object sender, EventArgs e)
        {
            Participer participer = new ()
            {
                Rang = (int)numericUpDownRang.Value,
                ScoreFinal = (int)numericUpDownScoreFinal.Value,
                Commentaire = textBoxCommentaire.Text,
                Evaluation = trackBarEvaluation.Value,
                DateHeureInscription = dateTimePickerDateHeureInscription.Value,
                IdUser = 1,//((Participer)comboBoxUtilisateur.SelectedItem).IdUser lorsque les utilisateurs seront intégrés
                NumeroTournoi = ((Tournoi)comboBoxTournoi.SelectedItem).NumeroTournoi,
                // TODO: voir conflit lucien
                //NumeroTournoi = (int)((Tournoi)comboBoxTournoi.SelectedItem).NumeroTournoi,
                LotRemis = lotRemisSelectionne
            };
            if (ValiderParticipation(participer, false))
            {
                _serviceParticiper.Creer(participer);
                MessageBox.Show("La participation a bien été ajoutée.", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Raz_Zones();
            }

        }
        private void buttonModifier_Click(object sender, EventArgs e)
        {
            if (dataGridParticipations.CurrentRow == null || _participerSelectionne == null)
            {
                MessageBox.Show("Aucune participation sélectionnée", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _participerSelectionne.Rang = (int)numericUpDownRang.Value;
            _participerSelectionne.ScoreFinal = (int)numericUpDownScoreFinal.Value;
            _participerSelectionne.Commentaire = textBoxCommentaire.Text;
            _participerSelectionne.Evaluation = trackBarEvaluation.Value;
            _participerSelectionne.DateHeureInscription = dateTimePickerDateHeureInscription.Value;
            _participerSelectionne.IdUser = 1; //((Participer)comboBoxUtilisateur.SelectedItem).IdUser lorsque les utilisateurs seront intégrés
            _participerSelectionne.NumeroTournoi = ((Tournoi)comboBoxTournoi.SelectedItem).NumeroTournoi;
            _participerSelectionne.LotRemis = lotRemisSelectionne;

            if (ValiderParticipation(_participerSelectionne, true))
            {
                _serviceParticiper.Modifier(_participerSelectionne);
                MessageBox.Show("La participation a bien été modifiée.", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Raz_Zones();
            }
        }
        private void buttonEffacer_Click(object sender, EventArgs e)
        {
            Raz_Zones();
        }
        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            if (dataGridParticipations.CurrentRow == null || _participerSelectionne == null)
            {
                MessageBox.Show("Aucune participation sélectionnée", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _serviceParticiper.Supprimer(_participerSelectionne.IdUser, _participerSelectionne.NumeroTournoi);
            _participerSelectionne = null;
            MessageBox.Show("La participation a bien été supprimée.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Raz_Zones();
        }

        #endregion
        private void dataGridParticipations_CellClick(object sender, DataGridViewCellEventArgs e)
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

                dataGridParticipationsUtilisateur.DataSource = _serviceParticiper.Lister(filtre, colonne, ordreChamp);
                dataGridParticipationsUtilisateur.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = 
                    ordreChamp == "ASC" ? SortOrder.Ascending : SortOrder.Descending;

                MEP_DataGridParticipations();
                return;
            }

            _participerSelectionne = dataGridParticipations.Rows[e.RowIndex].DataBoundItem as Participer;

            if (_participerSelectionne != null)
                RemplirFormulaire();

            AfficherBouttons();
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
            ChargerParticipations();
        }
        private void radioButtonLotRemisFalse_CheckedChanged(object sender, EventArgs e)
        {
            lotRemisSelectionne = false;
        }

        private void radioButtonLotRemisTrue_CheckedChanged(object sender, EventArgs e)
        {
            lotRemisSelectionne = true;
        }
        #endregion
        #region Validations
        /// <summary>
        /// Retourne un booléen indiquant si les informations de la participation sont valides ou non,
        /// en fonction des règles métier définies dans le service Participer.
        /// </summary>
        /// <param name="participer">L'objet Participer à valider.</param>
        /// <returns>Vraie si la participation est valide, sinon faux.</returns>
        private bool ValiderParticipation(Participer participer, bool estModification)
        {
            List<string> erreurs = _serviceParticiper.ValiderParticipation(participer, estModification);
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
        private void DisabledInputs()
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

            AfficherBouttons();
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
                MessageBox.Show("Aucun espace sélectionné.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

            AfficherBouttons();
        }

        /// <summary>
        /// Permet d'afficher ou de masquer les boutons d'action en fonction de la sélection actuelle d'un espace.
        /// </summary>
        private void AfficherBouttons()
        {
            buttonAjouter.Enabled = _participerSelectionne == null;

            // Si aucun espace n'est sélectionné, les boutons de modification, suppression et effacement sont désactivés
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
