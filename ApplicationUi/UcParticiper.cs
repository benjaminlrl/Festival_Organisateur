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
            // TODO: Ajouter un tooltip sur les boutons pour expliquer leur fonction à l'utilisateur
            // TODO: Ajouter un graphique pour indiquer le nombre de postes de jeu
            // fonctionnels vs non fonctionnels
            // TODO: ajouter une option de filtrage croissant décroissant sur la référence du poste de jeu
        }

        #region Evènements
        private void ChargerParticipations()
        {
            dataGridParticipations.DataSource = null;
            dataGridParticipations.DataSource = _serviceParticiper.Lister(filtre);
            MEP_DataGrid();
            ChargerStatistiques();
        }

        private void ChargerTournois()
        {
            comboBoxTournoi.DataSource = null;
            comboBoxTournoi.DataSource = _serviceTournoi.Lister("");
            // charge les tournois dans le comboBox et affiche le nom tout en conservant l'id en valeur
            comboBoxTournoi.DisplayMember = "Nom";
            comboBoxTournoi.ValueMember = "NumeroTournoi";
        }

        private void ChargerUtilisateurs()
        {
            comboBoxUtilisateur.DataSource = null;
            comboBoxUtilisateur.DataSource = _serviceParticiper.Lister("");
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
            radioButtonLotRemisTrue.Checked = false;
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
            // on ne gère le clic que sur les lignes, pas sur les en-têtes
            // Ignorer les clics sur l'en-tête (gérés pour le tri)
            // Gérer le trie par ordre des champs en fonction du clique sur la cellule d'en-tête
            if (e.RowIndex < 0)
            {
                var donnees = _serviceParticiper.Lister(filtre);

                // Utiliser un dictionnaire plutôt qu'un switch pour associer les index de colonnes
                // à des fonctions de sélection de clé
                var map = new Dictionary<int, Func<Participer, object>>
                {
                    {dataGridParticipations.Columns["IdUser"].Index, p => p.IdUser},
                    {dataGridParticipations.Columns["NomTournoi"].Index, p => p.Tournoi.Nom},
                    {dataGridParticipations.Columns["DateHeureInscription"].Index, p => p.DateHeureInscription},
                    {dataGridParticipations.Columns["Evaluation"].Index, p => p.Evaluation},
                    {dataGridParticipations.Columns["Rang"].Index, p => p.Rang},
                };

                if (!map.TryGetValue(e.ColumnIndex, out var keySelector))
                    return;

                dataGridParticipationsUtilisateur.DataSource = ordreChamp == "ASC"
                    ? donnees.OrderByDescending(keySelector).ToList()
                    : donnees.OrderBy(keySelector).ToList();

                ordreChamp = ordreChamp == "ASC" ? "DESC" : "ASC";

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
            numericUpDownRang.Value = _participerSelectionne.Rang;
            numericUpDownScoreFinal.Value = (int)_participerSelectionne.ScoreFinal;
            textBoxCommentaire.Text = _participerSelectionne.Commentaire;
            trackBarEvaluation.Value = _participerSelectionne.Evaluation;
            dateTimePickerDateHeureInscription.Value = _participerSelectionne.DateHeureInscription;
            comboBoxUtilisateur.SelectedItem = _participerSelectionne.IdUser;
            comboBoxTournoi.SelectedItem = _participerSelectionne.NumeroTournoi;

            // LotRemis (RadioButtons)
            if (participer.LotRemis)
            {
                radioButtonLotRemisTrue.Checked = true;
            }
            else
            {
                radioButtonLotRemisTrue.Checked = true;
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
        private bool ValiderParticiper()
        {
            return true;
        }
        #endregion

        #region Boutons
        public void buttonAjouter_Click(object sender, EventArgs e)
        {
            if (ValiderParticiper())
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
                    LotRemis = lotRemisSelectionne
                };
                _serviceParticiper.Creer(participer);
                ChargerParticipations();
                Raz_Zones();
            }

        }
        private void buttonModifier_Click(object sender, EventArgs e)
        {
            if (dataGridParticipationsUtilisateur.CurrentRow == null)
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
            _participerSelectionne.LotRemis = lotRemisSelectionne;

            _serviceParticiper.Modifier(_participerSelectionne);
            ChargerParticipations();
            Raz_Zones();
        }
        private void buttonEffacer_Click(object sender, EventArgs e)
        {
            Raz_Zones();
        }
        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            if (dataGridParticipationsUtilisateur.CurrentRow == null)
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

        private void radioButtonLotRemisFalse_Click(object sender, EventArgs e)
        {

        }
    }
}
