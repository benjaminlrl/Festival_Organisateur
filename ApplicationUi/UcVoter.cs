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
    public partial class UcVoter : UserControl
    {
        private readonly ITournoiService _serviceTournoi;
        private readonly IOrganisateurService _serviceOrganisateur;
        private readonly IJeuService _serviceJeu;
        private readonly IVoterService _serviceVoter;
        private readonly IPlateformeService _servicePlateforme;
        private bool fonctionnelSelectionne;
        private Jeu? _jeuSelectionne;
        private Voter? _voterSelectionne;
        private string filtre;
        private string ordreChamp;
        private readonly Organisateur _organisateurConnecte;
        public UcVoter(Organisateur unOrganisateurConnecte)
        {
            InitializeComponent();
            var context = new ApplicationDbContext();
            _serviceTournoi = new TournoiService(context);
            _serviceOrganisateur = new OrganisateurService(context);
            _serviceJeu = new JeuService(context);
            _servicePlateforme = new PlateformeService(context);
            _serviceVoter = new VoterService(context);
            _jeuSelectionne = null;
            _voterSelectionne = null;
            filtre = "";
            ordreChamp = "ASC";
            _organisateurConnecte = unOrganisateurConnecte;
            ChargerJeux();
            ChargerJeuxVotes();
            buttonSupprimer.Enabled = _jeuSelectionne != null && _voterSelectionne != null;
            buttonVoter.Enabled = _jeuSelectionne != null && _voterSelectionne != null;
            buttonEffacer.Text = " 🧽  Effacer";
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcPostesDeJeu, "Ajouter") == false)
            {
                buttonVoter.Visible = false;
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
        private void ChargerJeux()
        {
            dataGridJeux.DataSource = null;
            dataGridJeux.DataSource = _serviceJeu.Lister(filtre);
            MEP_DataGrid();
        }
        /// <summary>
        /// Permet de charger les jeux déjà votés par l'utilisateur en fonction de la recherche saisie
        /// </summary>
        private void ChargerJeuxVotes()
        {
            dataGridJeuxVotes.DataSource = null;
            dataGridJeuxVotes.DataSource = _serviceVoter.ListerPourUnUtilisateur(1); // TODO: Récupérer l'ID de l'utilisateur connecté
            if (dataGridJeuxVotes.DataSource != null)
                MEP_DataGridJeuxVotes();
        }
        private void ChargerPlateforme()
        {
            comboBoxPlateforme.DataSource = null;
            comboBoxPlateforme.DataSource = _jeuSelectionne.Plateformes.ToList();
            // charge les plateformes dans le comboBox et affiche le libellé tout en conservant l'id en valeur
            comboBoxPlateforme.DisplayMember = "Libelle";
            comboBoxPlateforme.ValueMember = "IdPlateforme";
        }

        /// <summary>
        /// Resets all tournament-related input fields and controls to their default values.
        /// </summary>
        /// <remarks>Use this method to clear the current tournament selection and prepare the form for
        /// entering a new tournament. All user input fields are cleared or set to their minimum values, and the status
        /// controls are reset to indicate a planned tournament.</remarks>
        private void Raz_Zones()
        {
            textBoxTitre.Clear();
            textBoxDescription.Clear();
            comboBoxPlateforme.SelectedItem = null;
            textBoxPegi.Clear();
            _jeuSelectionne = null;
            dataGridJeuxVotes.DataSource = null;
            buttonSupprimer.Enabled = _jeuSelectionne != null && _voterSelectionne != null;
            buttonVoter.Enabled = _jeuSelectionne != null && _voterSelectionne != null;
        }
        private void MEP_DataGrid()
        {
            dataGridJeux.Columns["Titre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridJeux.Columns["IdJeu"].Visible = false;
            dataGridJeux.Columns["Tournois"].Visible = false;
            dataGridJeux.Columns["Plateformes"].Visible = false;
        }

        private void MEP_DataGridJeuxVotes()
        {
            dataGridJeuxVotes.Columns["IdUser"].Visible = false;
            dataGridJeuxVotes.Columns["IdPlateforme"].Visible = false;
            dataGridJeuxVotes.Columns["IdJeu"].Visible = false;
            dataGridJeuxVotes.Columns["Plateforme"].Visible = false;
            dataGridJeuxVotes.Columns["Jeu"].Visible = false;

            dataGridJeuxVotes.Columns["TitreJeu"].HeaderText = "Jeu";
            dataGridJeuxVotes.Columns["LibellePlateforme"].HeaderText = "Plateforme";

            dataGridJeuxVotes.Columns["TitreJeu"].DisplayIndex = 1;
            dataGridJeuxVotes.Columns["LibellePlateforme"].DisplayIndex = 2;


            dataGridJeuxVotes.Columns["TitreJeu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridJeuxVotes.Columns["LibellePlateforme"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridJeuxVotes.Columns["DateVote"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void dataGridJeux_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // on ne gère le clic que sur les lignes, pas sur les en-têtes
            // Ignorer les clics sur l'en-tête (gérés pour le tri)
            // Gérer le trie par ordre des champs en fonction du clique sur la cellule d'en-tête
            if (e.RowIndex < 0)
            {
                // on né gère pas les cliques sur la première colonne
                if (e.ColumnIndex < 1)
                    return;

                var donnees = _serviceJeu.Lister(filtre);

                // Utiliser un dictionnaire plutôt qu'un switch pour associer les index de colonnes
                // à des fonctions de sélection de clé
                var map = new Dictionary<int, Func<Jeu, object>>
                {
                    {dataGridJeux.Columns["Titre"].Index, j => j.Titre},
                    {dataGridJeux.Columns["Description"].Index, j => j.Description},
                    {dataGridJeux.Columns["Pegi"].Index, j => j.Pegi},
                    {dataGridJeux.Columns["AnneeSortie"].Index, j => j.AnneeSortie},
                    {dataGridJeux.Columns["DateSortie"].Index, j => j.DateSortie},
                    {dataGridJeux.Columns["Editeur"].Index, j => j.Editeur},
                };

                if (!map.TryGetValue(e.ColumnIndex, out var keySelector))
                    return;

                dataGridJeux.DataSource = ordreChamp == "ASC"
                    ? donnees.OrderByDescending(keySelector).ToList()
                    : donnees.OrderBy(keySelector).ToList();
                // permute l'ordre du champ
                ordreChamp = ordreChamp == "ASC" ? "DESC" : "ASC";

                MEP_DataGrid();
                return;
            }

            _jeuSelectionne = dataGridJeux.Rows[e.RowIndex].DataBoundItem as Jeu;

            if (_jeuSelectionne != null)
                RemplirFormulaire(_jeuSelectionne);

            buttonSupprimer.Enabled = _jeuSelectionne != null && _voterSelectionne != null;
            buttonVoter.Enabled = _jeuSelectionne != null;

        }

        private void RemplirFormulaire(Jeu jeu)
        {
            textBoxTitre.Text = jeu.Titre;
            textBoxDescription.Text = jeu.Description;
            textBoxEditeur.Text = jeu.Editeur;
            textBoxPegi.Text = jeu.Pegi.ToString();
            ChargerPlateforme();
            dateTimePickerDateSortie.Value = jeu.DateSortie;
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
            ChargerJeux();
        }
        #endregion

        #region Validations
        private bool ValiderVote(Voter vote)
        {
            var erreurs = _serviceVoter.ValiderVote(vote);
            if (erreurs.Any())
            {
                MessageBox.Show(string.Join("\n", erreurs), "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        #endregion

        #region Boutons
        public void buttonVoter_Click(object sender, EventArgs e)
        {

            var voter = new Voter
            {
                IdJeu = _jeuSelectionne.IdJeu,
                IdPlateforme = ((Plateforme)comboBoxPlateforme.SelectedItem).IdPlateforme,
                IdUser = 1,//TODO: Récupérer l'ID de l'utilisateur connecté
                Plateforme = ((Plateforme)comboBoxPlateforme.SelectedItem),
                Jeu = _jeuSelectionne,
                DateVote = DateTime.Now

            };
            if (ValiderVote(voter))
            {
                _serviceVoter.Creer(voter);
                _voterSelectionne = voter;
                buttonSupprimer.Enabled = _jeuSelectionne != null && _voterSelectionne != null;
                buttonVoter.Enabled = _jeuSelectionne != null;
                ChargerJeux();
                ChargerJeuxVotes();
            }
        }
        private void buttonEffacer_Click(object sender, EventArgs e)
        {
            Raz_Zones();
        }
        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            if (dataGridJeux.CurrentRow == null)
                return;

            if (_jeuSelectionne == null || _voterSelectionne == null)
                return;
            var jeu = (Jeu)dataGridJeux.CurrentRow.DataBoundItem;
            
            _serviceVoter.Supprimer(_voterSelectionne.IdUser, _voterSelectionne.IdJeu, _voterSelectionne.IdPlateforme);
            _voterSelectionne = null;
            buttonSupprimer.Enabled = _jeuSelectionne != null && _voterSelectionne != null;
            buttonVoter.Enabled = _jeuSelectionne != null;
            ChargerJeux();
            ChargerJeuxVotes();
            Raz_Zones();

        }

        #endregion
    }
}
