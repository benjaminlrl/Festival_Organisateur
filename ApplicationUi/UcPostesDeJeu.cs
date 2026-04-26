using Lib_Entities.Entities;
using Lib_Metier.Data.Configurations;
using Lib_Services.Exceptions;
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
    public partial class UcPostesDeJeu : UserControl
    {
        private readonly ITournoiService _serviceTournoi;
        private readonly IOrganisateurService _serviceOrganisateur;
        private readonly IEspaceService _serviceEspace;
        private readonly IPosteJeuService _servicePosteJeu;
        private readonly IPlateformeService _servicePlateforme;
        private readonly Organisateur _organisateurConnecte;
        private bool fonctionnelSelectionne;
        private PosteJeu? _posteJeuSelectionne;
        private Tournoi? _tournoiSelectionne;
        // Champ pour stocker le texte de recherche et l'utiliser lors du rechargement des espaces
        private string filtre;
        // Champ pour stocker l'ordre de tri actuel sur la propriété de l'espace (ASC ou DESC)
        // et l'utiliser lors du rechargement des espaces
        private string ordreChamp;
        public event Action<Tournoi>? NaviguerVersTournois;

        public UcPostesDeJeu(Organisateur unOrganisateurConnecte, PosteJeu? posteJeuPreselectionne = null)
        {
            InitializeComponent();
            var context = new ApplicationDbContext();
            _serviceTournoi = new TournoiService(context);
            _serviceOrganisateur = new OrganisateurService(context);
            _serviceEspace = new EspaceService(context);
            _servicePosteJeu = new PosteJeuService(context);
            _servicePlateforme = new PlateformeService(context);

            _organisateurConnecte = unOrganisateurConnecte;
            
            _posteJeuSelectionne = null;
            _tournoiSelectionne = null;

            fonctionnelSelectionne = false;
            labelStatutTournoi.Visible = _posteJeuSelectionne != null;
            dataGridTournois.Visible = _posteJeuSelectionne != null;
            buttonEffacer.Text = " 🧽  Effacer";

            ordreChamp = "DESC";
            filtre = "";

            Raz_Zones();
            // Si un poste de jeu est préselectionné,
            // le formulaire est rempli avec ses données
            if (posteJeuPreselectionne != null)
            {
                _posteJeuSelectionne = posteJeuPreselectionne;
                RemplirFormulaire();
            }

            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcPostesDeJeu, "Ajouter") == false)
            {
                buttonAjouter.Visible = false;
                DesactiverInputs();
            }
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcPostesDeJeu, "Modifier") == false)
            {
                buttonModifier.Visible = false;
                DesactiverInputs();
            }
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcPostesDeJeu, "Supprimer") == false)
            {
                buttonSupprimer.Visible = false;
                DesactiverInputs();
            }
            // TODO: Ajouter un tooltip sur les boutons pour expliquer leur fonction à l'utilisateur
        }

        #region Données
        private void ChargerPostesDeJeu()
        {
            dataGridPostesJeu.DataSource = null;
            dataGridPostesJeu.DataSource = _servicePosteJeu.Lister(filtre);
            MEP_DataGridPostesJeu();
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
            int nbPostesJeuFonctionnels = _servicePosteJeu.NombrePostesJeuFonctionnels();

            labelStatPostesJeuTotal.Text = $"{_servicePosteJeu.NombrePostesJeu()}";

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
        /// Permet de charger les tournois associés à l'espace du poste de jeu séléctionné et d'afficher une indication visuelle
        /// du statut de ces tournois (en cours, planifié ou aucun tournoi).
        /// </summary>
        /// <param name="tournoisEspace">La liste des tournois de l'espace</param>
        private void ChargerTournois(ICollection<Tournoi>? tournoisEspace)
        {
            if (tournoisEspace == null)
            {
                dataGridTournois.DataSource = null;
                dataGridTournois.Visible = false;
                return;
            }
            dataGridTournois.DataSource = tournoisEspace.ToList();
            dataGridTournois.Visible = true;
            MEP_DataGridTournois();
        }

        private void MEP_DataGridPostesJeu()
        {
            DesactiverTrieAutomatique(dataGridPostesJeu);

            dataGridPostesJeu.Columns["Espace"].Visible = false;
            dataGridPostesJeu.Columns["IdEspace"].Visible = false;
            dataGridPostesJeu.Columns["IdPlateforme"].Visible = false;
            dataGridPostesJeu.Columns["Plateforme"].Visible = false;
            dataGridPostesJeu.Columns["NumeroPoste"].Visible = false;
            dataGridPostesJeu.Columns["NomEspace"].HeaderText = "Espace";
            dataGridPostesJeu.Columns["NomPlateforme"].HeaderText = "Plateforme";
            dataGridPostesJeu.Columns["Reference"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void MEP_DataGridTournois()
        {
            dataGridTournois.Visible = true;
            dataGridTournois.Columns["NumeroTournoi"].Visible = false;
            dataGridTournois.Columns["IdEspace"].Visible = false;
            dataGridTournois.Columns["Espace"].Visible = false;
            dataGridTournois.Columns["IdJeu"].Visible = false;
            dataGridTournois.Columns["Jeu"].Visible = false;
            dataGridTournois.Columns["NbParticipants"].Visible = false;
            dataGridTournois.Columns["NomEspace"].Visible = false;
            dataGridTournois.Columns["TitreJeu"].Visible = false;
            dataGridTournois.Columns["Statut"].Visible = false;
            dataGridTournois.Columns["Statut"].Visible = false;
            dataGridTournois.Columns["DureePrevue"].Visible = false;
            dataGridTournois.Columns["Lot"].Visible = false;

            dataGridTournois.Columns["DateHeure"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridTournois.Columns["Nom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridTournois.Columns["DateHeure"].HeaderText = "Début";

            dataGridTournois.Columns["Nom"].DisplayIndex = 1;
        }

        #endregion

        #region Évenements
        #region Boutons
        public void ButtonAjouter_Click(object sender, EventArgs e)
        {
            // Validation de la sélection de l'espace et de la plateforme avant de créer le poste de jeu
            if (comboBoxEspace.SelectedItem is not Espace espaceSelectionne 
                || comboBoxPlateforme.SelectedItem is not Plateforme plateformeSelectionne)
            {
                MessageBox.Show("Veuillez sélectionner une plateforme et un espace.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PosteJeu posteJeu = new ()
            {
                Fonctionnel = fonctionnelSelectionne,
                IdPlateforme = plateformeSelectionne.IdPlateforme,
                IdEspace = espaceSelectionne.IdEspace
            };

            try
            {
                _servicePosteJeu.Creer(posteJeu);
                MessageBox.Show("Le poste de jeu a bien été ajouté.", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Raz_Zones();
            }
            catch (PosteJeuException ex)
            {
                Log.Warning("[{Code}] {Message}", ex.CodeErreur, ex.Message);
                MessageBox.Show(ex.Message);
            }
            catch (DbException ex)
            {
                Log.Error(ex, "Une erreur technique est survenue lors de l'ajout du poste de jeu.");
                MessageBox.Show("Erreur technique, réessayez plus tard.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Une erreur inattendue est survenue.");
                MessageBox.Show("Une erreur inattendue est survenue.");
            }

        }
        private void ButtonModifier_Click(object sender, EventArgs e)
        {
            if (dataGridPostesJeu.CurrentRow == null || _posteJeuSelectionne == null)
                    return;

            _posteJeuSelectionne.Fonctionnel = fonctionnelSelectionne; // true ou false selon le choix de l'utilisateur
            _posteJeuSelectionne.IdEspace = (comboBoxEspace.SelectedItem as Espace).IdEspace;
            _posteJeuSelectionne.IdPlateforme = (comboBoxPlateforme.SelectedItem as Plateforme).IdPlateforme;

            try
            {
                _servicePosteJeu.Modifier(_posteJeuSelectionne);
                MessageBox.Show("Le poste de jeu a bien été modifié.", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Raz_Zones();
            }
            catch (PosteJeuException ex)
            {
                Log.Warning("[{Code}] {Message}", ex.CodeErreur, ex.Message);
                MessageBox.Show(ex.Message);
            }
            catch (DbException ex)
            {
                Log.Error(ex, "Une erreur technique est survenue lors de la modification du poste de jeu.");
                MessageBox.Show("Erreur technique, réessayez plus tard.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Une erreur inattendue est survenue.");
                MessageBox.Show("Une erreur inattendue est survenue.");
            }
        }
        private void ButtonEffacer_Click(object sender, EventArgs e)
        {
            Raz_Zones();
        }
        private void ButtonSupprimer_Click(object sender, EventArgs e)
        {
            if (dataGridPostesJeu.CurrentRow == null || _posteJeuSelectionne == null)
                return;

            if (MessageBox.Show("Êtes vous sûr de vouloir supprimer ?", "Supression", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            _servicePosteJeu.Supprimer(_posteJeuSelectionne.NumeroPoste);
            MessageBox.Show("Le poste de jeu a bien été supprimé.", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Raz_Zones();

        }

        #endregion

        /// <summary>
        /// Redirige vers le formulaire de gestion des tournois en fonction du tournoi sélectionné dans le DataGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridTournois_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            _tournoiSelectionne = dataGridTournois.Rows[e.RowIndex].DataBoundItem as Tournoi;

            if (_tournoiSelectionne != null)
                NaviguerVersTournois?.Invoke(_tournoiSelectionne); // déclenche la navigation vers le form main

        }

        private void DataGridPostesJeu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Gérer le trie par ordre des champs en fonction du clique sur la cellule d'en-tête
            if (e.RowIndex < 0)
            {

                // Utiliser un dictionnaire plutôt qu'un switch pour associer les index de colonnes
                // à des fonctions de sélection de clé
                Dictionary<int, string> map = new ()
                {
                    {dataGridPostesJeu.Columns["Reference"].Index, "Reference"},
                    {dataGridPostesJeu.Columns["Fonctionnel"].Index, "Fonctionnel"},
                    {dataGridPostesJeu.Columns["NomEspace"].Index, "NomEspace"},
                    {dataGridPostesJeu.Columns["Nomplateforme"].Index, "NomPlateforme"},
                };

                // Vérifie si l'index de la colonne est associé a une propriété
                if (!map.TryGetValue(e.ColumnIndex, out string? colonne))
                    return; 
                
                // permutation de l'ordre stocké
                ordreChamp = ordreChamp == "ASC" ? "DESC" : "ASC";

                dataGridPostesJeu.DataSource = _servicePosteJeu.Lister(filtre, colonne, ordreChamp);
                dataGridPostesJeu.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = 
                    ordreChamp == "ASC" ? SortOrder.Ascending : SortOrder.Descending;


                MEP_DataGridPostesJeu();
                return;
            }

            _posteJeuSelectionne = dataGridPostesJeu.Rows[e.RowIndex].DataBoundItem as PosteJeu;

            if (_posteJeuSelectionne != null)
                RemplirFormulaire();

            buttonModifier.Enabled = _posteJeuSelectionne != null;
            buttonSupprimer.Enabled = _posteJeuSelectionne != null;

        }

        private void RadioButtonFonctionnelFalse_CheckedChanged(object sender, EventArgs e)
        {
            fonctionnelSelectionne = false;
        }

        private void RadioButtonFonctionnelTrue_CheckedChanged(object sender, EventArgs e)
        {
            fonctionnelSelectionne = true;
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
            ChargerPostesDeJeu();
        }
        #endregion

        #region Méthodes

        /// <summary>
        /// Permet de désactiver les champs de saisie du formulaire si l'utilisateur 
        /// n'a pas les droits nécessaires pour ajouter ou modifier des espaces.
        /// </summary>
        private void DesactiverInputs()
        {
            textBoxReference.Enabled = false;
            comboBoxEspace.Enabled = false;
            comboBoxPlateforme.Enabled = false;
            radioButtonFonctionnelTrue.Enabled = false;
            radioButtonFonctionnelFalse.Enabled = false;
        }

        /// <summary>
        /// Resets all tournament-related input fields and controls to their default values.
        /// </summary>
        /// <remarks>Use this method to clear the current tournament selection and prepare the form for
        /// entering a new tournament. All user input fields are cleared or set to their minimum values, and the status
        /// controls are reset to indicate a planned tournament.</remarks>
        private void Raz_Zones()
        {
            textBoxReference.ReadOnly = true;
            textBoxReference.Clear();

            comboBoxPlateforme.SelectedItem = _posteJeuSelectionne != null;
            comboBoxEspace.SelectedItem = _posteJeuSelectionne != null;
            radioButtonFonctionnelTrue.Checked = _posteJeuSelectionne != null;
            radioButtonFonctionnelFalse.Checked = _posteJeuSelectionne != null;

            _posteJeuSelectionne = null;

            labelStatutTournoi.Visible = _posteJeuSelectionne != null;
            dataGridTournois.Visible = _posteJeuSelectionne != null;

            comboBoxEspace.Enabled = _posteJeuSelectionne != null;

            filtre = "";

            // Recharger les postes de jeu pour réinitialiser la sélection et les statistiques
            ChargerPostesDeJeu();
            ChargerPlateformes();
            ChargerEspaces();

            AfficherBoutons();
        }

        private void RemplirFormulaire()
        {
            if (_posteJeuSelectionne == null)
            {
                MessageBox.Show("Aucun poste de jeu sélectionné.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            textBoxReference.Text = _posteJeuSelectionne.Reference;

            // ComboBox Espace
            comboBoxEspace.SelectedItem = _posteJeuSelectionne.Espace;
            comboBoxEspace.SelectedValue = _posteJeuSelectionne.IdEspace;

            // ComboBox Plateforme
            comboBoxPlateforme.SelectedItem = _posteJeuSelectionne.Plateforme;
            comboBoxPlateforme.SelectedValue = _posteJeuSelectionne.IdPlateforme;

            // Fonctionnel (RadioButtons)
            if (_posteJeuSelectionne.Fonctionnel)
            {
                radioButtonFonctionnelTrue.Checked = true;
            }
            else
            {
                radioButtonFonctionnelFalse.Checked = true;
            }

            StatutTounois();
            AfficherBoutons();
        }

        /// <summary>
        /// Permet de déterminer d'afficher une indication visuelle sur les tournois associés à l'espace sélectionné, 
        /// en fonction de leur statut (en cours, planifié ou aucun tournoi).
        /// </summary>
        private void StatutTounois()
        {
            if (_posteJeuSelectionne == null)
            {
                labelStatutTournoi.Visible = _posteJeuSelectionne != null;
                return;
            }

            _posteJeuSelectionne.Espace ??= _serviceEspace.Obtenir(_posteJeuSelectionne.IdEspace);

            labelStatutTournoi.Visible = _posteJeuSelectionne != null;
            
            List<Tournoi> enCours = _serviceTournoi.ListerTournoisEnCoursEspace(_posteJeuSelectionne.Espace.IdEspace);
            List<Tournoi> futurs = _serviceTournoi.ListerTournoisPlanifiesEspace(_posteJeuSelectionne.Espace.IdEspace);

            if (enCours.Count > 0)
            {
                labelStatutTournoi.Text = "Tournoi en cours";
                labelStatutTournoi.ForeColor = Color.Maroon;
                labelStatutTournoi.BackColor = Color.FromArgb(255, 128, 128);

                ChargerTournois(enCours);
            }
            else
            {
                if (futurs.Count > 0)
                {
                    labelStatutTournoi.Text = futurs.Count > 1
                        ? "Tournois programmés"
                        : "Tournoi programmé";

                    labelStatutTournoi.ForeColor = Color.Chocolate;
                    labelStatutTournoi.BackColor = Color.FromArgb(255, 224, 192);

                    ChargerTournois(futurs);
                }
                // Si il n'y a ni tournoi en cours ni tournoi planifié, alors l'espace est considéré comme libre
                else
                {
                    labelStatutTournoi.Text = "Espace libre";
                    labelStatutTournoi.ForeColor = Color.DarkGreen;
                    labelStatutTournoi.BackColor = Color.FromArgb(192, 255, 192);
                    ChargerTournois(null);
                }
            }
        }

        /// <summary>
        /// Permet d'afficher ou de masquer les boutons d'action en fonction de la sélection actuelle d'un espace.
        /// </summary>
        private void AfficherBoutons()
        {

            buttonAjouter.Enabled = _posteJeuSelectionne == null;
            comboBoxEspace.Enabled = _posteJeuSelectionne == null;

            // Si aucun espace n'est sélectionné, les boutons de modification, suppression et effacement sont désactivés
            buttonModifier.Enabled = _posteJeuSelectionne != null;
            buttonSupprimer.Enabled = _posteJeuSelectionne != null;
            buttonEffacer.Enabled = _posteJeuSelectionne != null;

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
