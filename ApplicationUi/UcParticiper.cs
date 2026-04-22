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
        private readonly ITournoiService _serviceTournoi;
        private readonly IOrganisateurService _serviceOrganisateur;
        private readonly IEspaceService _serviceEspace;
        private readonly IParticiperService _serviceParticiper;
        private readonly IPlateformeService _servicePlateforme;
        private Participer? _participerSelectionne;
        private string filtre;
        private string ordreChamp;
        private readonly Organisateur _organisateurConnecte;
        private bool lotRemisSelectionne;

        public UcParticiper(Organisateur unOrganisateurConnecte)
        {
            InitializeComponent();
            var context = new ApplicationDbContext();
            _serviceTournoi = new TournoiService(context);
            _serviceOrganisateur = new OrganisateurService(context);
            _serviceEspace = new EspaceService(context);
            _serviceParticiper = new ParticiperService(context);
            _servicePlateforme = new PlateformeService(context);
            _participerSelectionne = null;
            lotRemisSelectionne = false;
            filtre = "";
            ordreChamp = "ASC";
            _organisateurConnecte = unOrganisateurConnecte;
            ChargerUtilisateurs();
            ChargerTournois();
            ChargerParticipations();
            buttonModifier.Enabled = _participerSelectionne != null;
            buttonSupprimer.Enabled = _participerSelectionne != null;
            buttonEffacer.Text = " 🧽  Effacer";
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcPostesDeJeu, "Ajouter") == false)
            {
                buttonAjouter.Visible = false;
            }
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcPostesDeJeu, "Modifier") == false)
            {
                buttonModifier.Visible = false;
            }
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcPostesDeJeu, "Supprimer") == false)
            {
                buttonSupprimer.Visible = false;
            }
        }

        #region Evènements
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
            MEP_DataGrid();
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

        /// <summary>
        /// Resets all tournament-related input fields and controls to their default values.
        /// </summary>
        /// <remarks>Use this method to clear the current tournament selection and prepare the form for
        /// entering a new tournament. All user input fields are cleared or set to their minimum values, and the status
        /// controls are reset to indicate a planned tournament.</remarks>
        private void Raz_Zones()
        {
            textBoxCommentaire.Clear();
            comboBoxUtilisateur.SelectedItem = null;
            comboBoxTournoi.SelectedItem = null;
            _participerSelectionne = null;
            buttonModifier.Enabled = _participerSelectionne != null;
            buttonSupprimer.Enabled = _participerSelectionne != null;
            radioButtonLotRemisTrue.Checked = false;
            radioButtonLotRemisFalse.Checked = false;
        }
        private void MEP_DataGrid()
        // TODO: Modifier les données de la grille pour afficher le nom de l'espace
        // et le nom de la plateforme au lieu des ids
        // et masquer les colonnes idEspace et idPlateforme
        {
            dataGridParticipations.Columns["Tournoi"].Visible = false;
            dataGridParticipations.Columns["NumeroTournoi"].Visible = false;
            dataGridParticipations.Columns["NomTournoi"].HeaderText = "Tournoi";
            dataGridParticipations.Columns["IdUser"].HeaderText = "Utilisateur";
            dataGridParticipations.Columns["DateHeureInscription"].HeaderText = "Date d'inscription";
        }

        private void dataGridParticipations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Gérer le trie par ordre des champs en fonction du clique sur la cellule d'en-tête
            if (e.RowIndex < 0)
            {

                // Utiliser un dictionnaire plutôt qu'un switch pour associer les index de colonnes
                // à des fonctions de sélection de clé
                var map = new Dictionary<int, string>
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


                MEP_DataGrid();
                return;
            }

            _participerSelectionne = dataGridParticipations.Rows[e.RowIndex].DataBoundItem as Participer;

            if (_participerSelectionne != null)
                RemplirFormulaire(_participerSelectionne);

            buttonModifier.Enabled = _participerSelectionne != null;
            buttonSupprimer.Enabled = _participerSelectionne != null;

        }

        private void RemplirFormulaire(Participer participer)
        {
            numericUpDownRang.Value = participer.Rang;
            numericUpDownScoreFinal.Value = participer.ScoreFinal ?? 0;
            textBoxCommentaire.Text = participer.Commentaire;
            trackBarEvaluation.Value = participer.Evaluation ?? 0;
            dateTimePickerDateHeureInscription.Value = participer.DateHeureInscription;

            comboBoxUtilisateur.SelectedItem = participer.IdUser;

            comboBoxTournoi.SelectedItem = participer.Tournoi;
            comboBoxTournoi.SelectedValue = participer.NumeroTournoi;

            // LotRemis (RadioButtons)
            if (participer.LotRemis)
            {
                radioButtonLotRemisTrue.Checked = true;
                lotRemisSelectionne = true;
            }
            else
            {
                radioButtonLotRemisFalse.Checked = true;
                lotRemisSelectionne = false;
            }

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
        private bool ValiderParticiper(Participer participer, bool estModification)
        {
            var erreurs = _serviceParticiper.ValiderParticiper(participer, estModification);
            if (erreurs.Any())
            {
                MessageBox.Show(string.Join("\n", erreurs), "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        #endregion

        #region Boutons
        public void buttonAjouter_Click(object sender, EventArgs e)
        {
            Participer participer = new Participer
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
            if (ValiderParticiper(participer, false))
            {                
                _serviceParticiper.Creer(participer);
                ChargerParticipations();
                Raz_Zones();
            }

        }
        private void buttonModifier_Click(object sender, EventArgs e)
        {
            if (dataGridParticipations.CurrentRow == null)
                return;

            if (_participerSelectionne == null)
                return;
            Participer Participer = (Participer)dataGridParticipations.CurrentRow.DataBoundItem;

            _participerSelectionne.Rang = (int)numericUpDownRang.Value;
            _participerSelectionne.ScoreFinal = (int)numericUpDownScoreFinal.Value;
            _participerSelectionne.Commentaire = textBoxCommentaire.Text;
            _participerSelectionne.Evaluation = trackBarEvaluation.Value;
            _participerSelectionne.DateHeureInscription = dateTimePickerDateHeureInscription.Value;
            _participerSelectionne.IdUser = 1; //((Participer)comboBoxUtilisateur.SelectedItem).IdUser lorsque les utilisateurs seront intégrés
            _participerSelectionne.NumeroTournoi = ((Tournoi)comboBoxTournoi.SelectedItem).NumeroTournoi;
            // TODO: voir conflit lucien
            //puisque NumeroTournoi est une clé primaire, elle ne peut pas être null
            //_participerSelectionne.NumeroTournoi = (int)((Tournoi)comboBoxTournoi.SelectedItem).NumeroTournoi;
            _participerSelectionne.LotRemis = lotRemisSelectionne;

            if (ValiderParticiper(_participerSelectionne, true))
            {
                _serviceParticiper.Modifier(_participerSelectionne);
                ChargerParticipations();
                Raz_Zones();
            }
        }
        private void buttonEffacer_Click(object sender, EventArgs e)
        {
            Raz_Zones();
        }
        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            if (dataGridParticipations.CurrentRow == null)
                return;

            if (_participerSelectionne == null)
                return;
            Participer Participer = (Participer)dataGridParticipations.CurrentRow.DataBoundItem;

            _serviceParticiper.Supprimer(_participerSelectionne.IdUser, _participerSelectionne.NumeroTournoi);
            _participerSelectionne = null;
            ChargerParticipations();
            Raz_Zones();
        }

        #endregion
    }
}
