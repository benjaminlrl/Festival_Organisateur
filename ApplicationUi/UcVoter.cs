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
            _serviceVoter = new VoterService(context);
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
            AfficherBouttons();

            buttonEffacer.Text = " 🧽  Effacer";

            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcPostesDeJeu, "Ajouter") == false)
            {
                buttonAjouter.Visible = false;
            }
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcPostesDeJeu, "Supprimer") == false)
            {
                buttonSupprimer.Visible = false;
            }
        }

        #region Evènements
        private void ChargerSoumisVotes()
        {
            dataGridSoumisVote.DataSource = null;
            dataGridSoumisVote.DataSource = _serviceSoumisVote.Lister(filtre);
            MEP_DataGrid();
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

        private void AfficherBouttons()
        {
            buttonAjouter.Enabled = _soumisVoteSelectionne == null;
            buttonModifier.Enabled = _soumisVoteSelectionne != null;
            buttonSupprimer.Enabled = _soumisVoteSelectionne != null;
            buttonEffacer.Enabled = _soumisVoteSelectionne != null;

            comboBoxJeu.Enabled = _soumisVoteSelectionne == null;
            comboBoxPlateforme.Enabled = _soumisVoteSelectionne == null;

        }

        /// <summary>
        /// Resets all tournament-related input fields and controls to their default values.
        /// </summary>
        /// <remarks>Use this method to clear the current tournament selection and prepare the form for
        /// entering a new tournament. All user input fields are cleared or set to their minimum values, and the status
        /// controls are reset to indicate a planned tournament.</remarks>
        private void Raz_Zones()
        {
            comboBoxJeu.SelectedItem = null;
            textBoxDescription.Clear();
            textBoxRecherche.Clear();
            comboBoxPlateforme.SelectedItem = null;
            _soumisVoteSelectionne = null;
            dateTimePickerDateDebutVote.Value = DateTime.Now;
            dateTimePickerDateFinVote.Value = DateTime.Now.AddDays(1);
            AfficherBouttons();
        }
        private void MEP_DataGrid()
        {
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

        private void dataGridClassement_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // on ne gère le clic que sur les lignes, pas sur les en-têtes
            // Ignorer les clics sur l'en-tête (gérés pour le tri)
            // Gérer le trie par ordre des champs en fonction du clique sur la cellule d'en-tête
            //if (e.RowIndex < 0)
            //{
            //    // on né gère pas les cliques sur la première colonne
            //    if (e.ColumnIndex < 1)
            //        return;

            //    var donnees = _serviceVoter.Lister(filtre);

            //    // Utiliser un dictionnaire plutôt qu'un switch pour associer les index de colonnes
            //    // à des fonctions de sélection de clé
            //    var map = new Dictionary<int, Func<Voter, object>>
            //    {
            //        {dataGridClassement.Columns["TitreJeu"].Index, v => v.TitreJeu},
            //        {dataGridClassement.Columns["Plateforme"].Index, v => v.Plateforme},
            //        {dataGridClassement.Columns["DateVote"].Index, v => v.DateVote},
            //    };

            //    if (!map.TryGetValue(e.ColumnIndex, out var keySelector))
            //        return;

            //    dataGridClassement.DataSource = ordreChampVotes == "ASC"
            //        ? donnees.OrderByDescending(keySelector).ToList()
            //        : donnees.OrderBy(keySelector).ToList();
            //    // permute l'ordre du champ
            //    ordreChampVotes = ordreChampVotes == "ASC" ? "DESC" : "ASC";
            //    MEP_DataGridClassement();
            //    return;
            //}

            //_voterSelectionne = dataGridClassement.Rows[e.RowIndex].DataBoundItem as Voter;
            //_soumisVoteSelectionne = _voterSelectionne?.Jeu;

            //if (_soumisVoteSelectionne != null && _voterSelectionne != null)
            //    RemplirFormulaire(_soumisVoteSelectionne);

        }

        private void dataGridSoumisVote_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Gérer le trie par ordre des champs en fonction du clique sur la cellule d'en-tête
            if (e.RowIndex < 0)
            {
                // on ne gère pas les cliques sur la première colonne
                if (e.ColumnIndex < 0)
                    return;

                var donnees = _serviceSoumisVote.Lister(filtre);

                // Utiliser un dictionnaire plutôt qu'un switch pour associer les index de colonnes
                // à des fonctions de sélection de clé
                var map = new Dictionary<int, Func<SoumisVote, object>>
                {
                    {dataGridSoumisVote.Columns["DateDebutVote"].Index, sv => sv.DateDebutVote},
                    {dataGridSoumisVote.Columns["DateFinVote"].Index, sv => sv.DateFinVote},
                    {dataGridSoumisVote.Columns["TitreJeu"].Index, sv => sv.DateFinVote},
                    {dataGridSoumisVote.Columns["LibellePlateforme"].Index, sv => sv.DateFinVote},
                };

                if (!map.TryGetValue(e.ColumnIndex, out var keySelector))
                    return;

                dataGridSoumisVote.DataSource = ordreChamp == "ASC"
                    ? donnees.OrderByDescending(keySelector).ToList()
                    : donnees.OrderBy(keySelector).ToList();
                // permute l'ordre du champ
                ordreChamp = ordreChamp == "ASC" ? "DESC" : "ASC";
                MEP_DataGrid();
                return;
            }

            _soumisVoteSelectionne = dataGridSoumisVote.Rows[e.RowIndex].DataBoundItem as SoumisVote;

            if (_soumisVoteSelectionne != null)
                RemplirFormulaire();
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
            ChargerSoumisVotes();
        }
        #endregion

        #region Validations
        private bool ValiderSoumisVote(SoumisVote soumisvote, bool estModification)
        {
            var erreurs = _serviceSoumisVote.ValiderSoumisVote(soumisvote, estModification);
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

            SoumisVote soumisVote = new SoumisVote
            {
                IdJeu = ((Jeu)comboBoxJeu.SelectedItem).IdJeu,
                IdPlateforme = ((Plateforme)comboBoxPlateforme.SelectedItem).IdPlateforme,
                Plateforme = (Plateforme)comboBoxPlateforme.SelectedItem,
                Jeu = (Jeu)comboBoxJeu.SelectedItem,
                DateFinVote = dateTimePickerDateFinVote.Value,
                DateDebutVote = dateTimePickerDateDebutVote.Value,

            };
            if (ValiderSoumisVote(soumisVote, false))
            {
                _serviceSoumisVote.Creer(soumisVote);
                _soumisVoteSelectionne = soumisVote;
                ChargerJeux();
                ChargerSoumisVotes();
                AfficherBouttons();
            }
        }
        private void buttonModifier_Click(object sender, EventArgs e)
        {
            _soumisVoteSelectionne.DateDebutVote = dateTimePickerDateDebutVote.Value;
            _soumisVoteSelectionne.DateFinVote = dateTimePickerDateFinVote.Value;
            if (ValiderSoumisVote(_soumisVoteSelectionne, true))
            {
                _serviceSoumisVote.Modifier(_soumisVoteSelectionne);
                ChargerSoumisVotes();
                AfficherBouttons();
                Raz_Zones();
            }
        }
        private void buttonEffacer_Click(object sender, EventArgs e)
        {
            Raz_Zones();
        }
        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            if (dataGridSoumisVote.CurrentRow == null)
                return;

            if (_soumisVoteSelectionne == null)
                return;
            var soumisVote = (SoumisVote)dataGridSoumisVote.CurrentRow.DataBoundItem;

            if (MessageBox.Show("Êtes vous sûr de vouloir supprimer ?", "Validation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            _serviceSoumisVote.Supprimer(_soumisVoteSelectionne.IdJeu, _soumisVoteSelectionne.IdPlateforme);
            _soumisVoteSelectionne = null;
            ChargerJeux();
            AfficherBouttons();
            Raz_Zones();

        }

        #endregion

        private void comboBoxPlateforme_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPlateforme.SelectedItem == null)
                return;
            AfficherBouttons();
        }

        private void comboBoxJeu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxJeu.SelectedItem == null)
            {
                _jeuSelectionne = null;
                return;
            }
               
            _jeuSelectionne = (Jeu)comboBoxJeu.SelectedItem;
            textBoxDescription.Text = _jeuSelectionne.Description;
            ChargerPlateforme();
            AfficherBouttons();
        }
    }
}
