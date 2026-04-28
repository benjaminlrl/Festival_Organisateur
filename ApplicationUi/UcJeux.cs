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
    public partial class UcJeux : UserControl
    {
        private readonly IOrganisateurService _serviceOrganisateur;
        private readonly IJeuService _serviceJeu;
        private readonly IPlateformeService _servicePlateforme;
        private Jeu? _jeuSelectionne;
        private string filtre;
        private string ordreChamp;
        private readonly Organisateur _organisateurConnecte;
        public UcJeux(Organisateur unOrganisateurConnecte, Jeu? JeuPreselectionne = null)
        {
            InitializeComponent();
            var context = new ApplicationDbContext();
            _serviceOrganisateur = new OrganisateurService(context);
            _serviceJeu = new JeuService(context);
            _servicePlateforme = new PlateformeService(context);

            _organisateurConnecte = unOrganisateurConnecte;
            _jeuSelectionne = null;

            filtre = "";
            ordreChamp = "DESC";
            buttonEffacer.Text = " 🧽  Effacer";

            Raz_Zones();

            if (_serviceOrganisateur.EstAutoriser(_organisateurConnecte, Organisateur.LesUC.UcPostesDeJeu, "Ajouter") == false)
            {
                buttonAjouter.Visible = false;
                DesactiverInputs();
            }
            if (_serviceOrganisateur.EstAutoriser(_organisateurConnecte, Organisateur.LesUC.UcPostesDeJeu, "Modifier") == false)
            {
                buttonModifier.Visible = false;
                DesactiverInputs();
            }
            if (_serviceOrganisateur.EstAutoriser(_organisateurConnecte, Organisateur.LesUC.UcPostesDeJeu, "Supprimer") == false)
            {
                buttonSupprimer.Visible = false;
                DesactiverInputs();
            }
            // TODO: Ajouter un tooltip sur les boutons pour expliquer leur fonction à l'utilisateur
        }

        #region Données
        private void ChargerJeux()
        {
            dataGridJeux.DataSource = null;
            dataGridJeux.DataSource = _serviceJeu.Lister(filtre);
            MEP_DataGridJeux();
        }

        private void ChargerPlateformes()
        {
            checkedListBoxPlateforme.DataSource = null;
            checkedListBoxPlateforme.DataSource = _servicePlateforme.Lister("");

            // charge les plateformes dans le comboBox et affiche le libellé tout en conservant l'id en valeur
            checkedListBoxPlateforme.DisplayMember = "Libelle";
            checkedListBoxPlateforme.ValueMember = "IdPlateforme";
        }

        private void ChargerPegi()
        {
            comboBoxPegi.DataSource = Enum.GetValues<ConstanteService.PEGI>()
                                  .ToList();
        }

        private void MEP_DataGridJeux()
        {
            DesactiverTrieAutomatique(dataGridJeux);

            dataGridJeux.Columns["Titre"]!.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridJeux.Columns["Description"]!.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridJeux.Columns["Pegi"]!.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridJeux.Columns["AnneeSortie"]!.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            dataGridJeux.Columns["IdJeu"]!.Visible = false;
            dataGridJeux.Columns["Tournois"]!.Visible = false;
            dataGridJeux.Columns["Plateformes"]!.Visible = false;
            dataGridJeux.Columns["DateSortie"]!.Visible = false;
            dataGridJeux.Columns["Editeur"]!.Visible = false;

            dataGridJeux.Columns["AnneeSortie"]!.HeaderText = "Sortie";
        }

        #endregion

        #region Evènements
        #region Boutons
        public void ButtonAjouter_Click(object sender, EventArgs e)
        {
            Jeu jeu = new()
            {
                Titre = textBoxTitre.Text,
                Description = textBoxDescription.Text,
                Editeur = textBoxEditeur.Text,
                Pegi = (int)(ConstanteService.PEGI)comboBoxPegi.SelectedValue!,
                Plateformes = checkedListBoxPlateforme.CheckedItems
                                  .Cast<Plateforme>()
                                  .ToList(),
                DateSortie = dateTimePickerDateSortie.Value
            };

            AjouterJeu(jeu);
        }
        private void ButtonModifier_Click(object sender, EventArgs e)
        {
            if (dataGridJeux.CurrentRow == null)
                return;

            if (_jeuSelectionne == null)
                return;

            _jeuSelectionne.Titre = textBoxTitre.Text;
            _jeuSelectionne.Description = textBoxDescription.Text; ;
            _jeuSelectionne.Editeur = textBoxEditeur.Text;
            _jeuSelectionne.Pegi = (int)(ConstanteService.PEGI)comboBoxPegi.SelectedValue!;
            _jeuSelectionne.Plateformes = checkedListBoxPlateforme.CheckedItems
                          .Cast<Plateforme>()
                          .ToList();
            _jeuSelectionne.DateSortie = dateTimePickerDateSortie.Value;

            ModifierJeu(_jeuSelectionne);
        }
        private void ButtonEffacer_Click(object sender, EventArgs e)
        {
            Raz_Zones();
        }
        private void ButtonSupprimer_Click(object sender, EventArgs e)
        {
            if (dataGridJeux.CurrentRow == null || _jeuSelectionne == null)
                return;

            if (MessageBox.Show("Êtes vous sûr de vouloir supprimer ?", "Suppression",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            SupprimerJeu();
        }

        #endregion

        private void DataGridJeux_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Gérer le trie par ordre des champs en fonction du clique sur la cellule d'en-tête
            if (e.RowIndex < 0)
            {

                // Utiliser un dictionnaire plutôt qu'un switch pour associer les index de colonnes
                // à des fonctions de sélection de clé
                Dictionary<int, string> map = new()
                {
                    {dataGridJeux.Columns["Titre"]!.Index, "Titre"},
                    {dataGridJeux.Columns["Description"]!.Index, "Description"},
                    {dataGridJeux.Columns["Pegi"]!.Index, "Pegi"},
                    {dataGridJeux.Columns["AnneeSortie"]!.Index, "AnneeSortie"},
                    {dataGridJeux.Columns["DateSortie"]!.Index, "DateSortie"},
                    {dataGridJeux.Columns["Editeur"]!.Index, "Editeur"},
                };

                if (!map.TryGetValue(e.ColumnIndex, out string? colonne))
                    return;

                ordreChamp = ordreChamp == "ASC" ? "DESC" : "ASC";

                dataGridJeux.DataSource = _serviceJeu.Lister(filtre, colonne, ordreChamp);
                dataGridJeux.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection =
                    ordreChamp == "ASC" ? SortOrder.Ascending : SortOrder.Descending;

                MEP_DataGridJeux();
                return;
            }

            _jeuSelectionne = dataGridJeux.Rows[e.RowIndex].DataBoundItem as Jeu;

            if (_jeuSelectionne != null)
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
            ChargerJeux();
        }
        #endregion

        #region Méthodes
        /// <summary>
        /// Permet de désactiver les champs de saisie du formulaire si l'utilisateur 
        /// n'a pas les droits nécessaires pour ajouter ou modifier des espaces.
        /// </summary>
        private void DesactiverInputs()
        {
            textBoxTitre.Enabled = false;
            textBoxDescription.Enabled = false;
            textBoxEditeur.Enabled = false;
            checkedListBoxPlateforme.Enabled = false;
            comboBoxPegi.Enabled = false;
            dateTimePickerDateSortie.Enabled = false;
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
            textBoxEditeur.Clear();

            _jeuSelectionne = null;

            checkedListBoxPlateforme.SelectedItem = null;
            comboBoxPegi.SelectedItem = null;
            dateTimePickerDateSortie.Value = dateTimePickerDateSortie.MinDate;

            ChargerJeux();
            ChargerPlateformes();
            ChargerPegi();

            AfficherBoutons();
        }

        /// <summary>
        /// Permet d'afficher ou de masquer les boutons d'action en fonction de la sélection actuelle d'un jeu.
        /// </summary>
        private void RemplirFormulaire()
        {
            if (_jeuSelectionne == null)
            {
                MessageBox.Show("Aucun jeu sélectionné.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            textBoxTitre.Text = _jeuSelectionne.Titre;
            textBoxDescription.Text = _jeuSelectionne.Description;
            textBoxEditeur.Text = _jeuSelectionne.Editeur;

            comboBoxPegi.SelectedItem = (ConstanteService.PEGI)_jeuSelectionne.Pegi;

            // CheckBox plateforme, pour l aséléction multiple des plateformes
            // on dit explicitement "ces object sont des Plateforme"
            foreach (Plateforme p in checkedListBoxPlateforme.Items.Cast<Plateforme>().ToList())
            {
                checkedListBoxPlateforme.SetItemChecked(
                    checkedListBoxPlateforme.Items.IndexOf(p),
                    _jeuSelectionne.Plateformes.Any(jp => jp.IdPlateforme == p.IdPlateforme)
                );
            }

            dateTimePickerDateSortie.Value = _jeuSelectionne.DateSortie;

            AfficherBoutons();
        }

        /// <summary>
        /// Permet d'afficher ou de masquer les boutons d'action en fonction de la sélection actuelle d'un espace.
        /// </summary>
        private void AfficherBoutons()
        {
            buttonAjouter.Enabled = true;

            // Si aucun espace n'est sélectionné, les boutons de modification, suppression et effacement sont désactivés
            buttonModifier.Enabled = _jeuSelectionne != null;
            buttonSupprimer.Enabled = _jeuSelectionne != null;
            buttonEffacer.Enabled = _jeuSelectionne != null;
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
        /// <summary>
        /// Permets de modifier un jeu en gérant les différentes exceptions qui peuvent survenir,
        /// </summary>
        private void ModifierJeu(Jeu? jeu)
        {
            try
            {
                _serviceJeu.Modifier(jeu);
                MessageBox.Show("Le jeu a bien été modifié.", "Modification",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Raz_Zones();
            }
            catch (JeuException ex)
            {
                Log.Warning("[{Code}] {Message}", ex.CodeErreur, ex.Message);
                MessageBox.Show(ex.Message, "Modification",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (DbException ex)
            {
                Log.Error(ex, "Une erreur technique est survenue lors de la modification du jeu.");
                MessageBox.Show("Erreur technique, réessayez plus tard.", "Modification",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Une erreur inattendue est survenue.");
                MessageBox.Show("Une erreur inattendue est survenue.", "Modification",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Permets de supprimer un jeu en gérant les différentes exceptions qui peuvent survenir,
        /// </summary>
        private void SupprimerJeu()
        {
            try
            {
                _serviceJeu.Supprimer(_jeuSelectionne!.IdJeu);                
                MessageBox.Show("Le jeu a bien été supprimé.", "Suppression",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Raz_Zones();
            }
            catch (JeuException ex)
            {
                Log.Warning("[{Code}] {Message}", ex.CodeErreur, ex.Message);
                MessageBox.Show(ex.Message, "Suppression",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (DbException ex)
            {
                Log.Error(ex, "Erreur technique lors de la suppression du jeu");
                MessageBox.Show("Erreur technique, réessayez plus tard.", "Suppression",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erreur inattendue lors de la suppression du jeu");
                MessageBox.Show("Une erreur inattendue est survenue.", "Suppression",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Permet d'ajouter un jeu
        /// </summary>
        /// <param name="jeu"></param>
        private void AjouterJeu(Jeu? jeu)
        {
            try
            {
                _serviceJeu.Creer(jeu);
                MessageBox.Show("Le jeu a bien été ajouté.", "Ajout",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Raz_Zones();
            }
            catch (JeuException ex)
            {
                Log.Warning("[{Code}] {Message}", ex.CodeErreur, ex.Message);
                MessageBox.Show(ex.Message, "Ajout",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (DbException ex)
            {
                Log.Error(ex, "Une erreur technique est survenue lors de l'ajout du jeu.");
                MessageBox.Show("Erreur technique, réessayez plus tard.", "Ajout",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Une erreur inattendue est survenue.");
                MessageBox.Show("Une erreur inattendue est survenue.", "Ajout",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion
    }
}
