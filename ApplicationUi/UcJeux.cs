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
    public partial class UcJeux : UserControl
    {
        private readonly ITournoiService _serviceTournoi;
        private readonly IOrganisateurService _serviceOrganisateur;
        private readonly IJeuService _serviceJeu;
        private readonly IPlateformeService _servicePlateforme;
        private bool fonctionnelSelectionne;
        private Jeu? _jeuSelectionne;
        private string filtre;
        private string ordreChamp;
        private readonly Organisateur _organisateurConnecte;
        public UcJeux(Organisateur unOrganisateurConnecte)
        {
            InitializeComponent();
            var context = new ApplicationDbContext();
            _serviceTournoi = new TournoiService(context);
            _serviceOrganisateur = new OrganisateurService(context);
            _serviceJeu = new JeuService(context);
            _servicePlateforme = new PlateformeService(context);
            _jeuSelectionne = null;
            fonctionnelSelectionne = false;
            filtre = "";
            ordreChamp = "ASC";
            _organisateurConnecte = unOrganisateurConnecte;
            ChargerJeux();
            ChargerPlateformes();
            ChargerPegi();
            buttonModifier.Enabled = _jeuSelectionne != null;
            buttonSupprimer.Enabled = _jeuSelectionne != null;
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
        private void ChargerJeux()
        {
            dataGridJeux.DataSource = null;
            dataGridJeux.DataSource = _serviceJeu.Lister(filtre);
            MEP_DataGrid();
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
            comboBoxPegi.DataSource = Enum.GetValues(typeof(Jeu.PEGI))
                                  .Cast<int>()
                                  .ToList();
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
            checkedListBoxPlateforme.SelectedItem = null;
            comboBoxPegi.SelectedItem = null;
            _jeuSelectionne = null;
            buttonModifier.Enabled = _jeuSelectionne != null;
            buttonSupprimer.Enabled = _jeuSelectionne != null;
        }
        private void MEP_DataGrid()
        {
            dataGridJeux.Columns["Titre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridJeux.Columns["IdJeu"].Visible = false;
            dataGridJeux.Columns["Tournois"].Visible = false;
            dataGridJeux.Columns["Plateformes"].Visible = false;
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

            buttonModifier.Enabled = _jeuSelectionne != null;
            buttonSupprimer.Enabled = _jeuSelectionne != null;

        }

        private void RemplirFormulaire(Jeu jeu)
        {
            textBoxTitre.Text = jeu.Titre;
            textBoxDescription.Text = jeu.Description;
            textBoxEditeur.Text = jeu.Editeur;

            // ComboBox Pegi
            comboBoxPegi.SelectedItem = jeu.Pegi;

            // CheckBox plateforme, on dit explicitement "ces object sont des Plateforme"
            foreach (Plateforme p in checkedListBoxPlateforme.Items.Cast<Plateforme>().ToList())
            {
                checkedListBoxPlateforme.SetItemChecked(
                    checkedListBoxPlateforme.Items.IndexOf(p),
                    jeu.Plateformes.Any(jp => jp.IdPlateforme == p.IdPlateforme)
                );
            }
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
        private bool ValiderJeu(Jeu jeu)
        {
            var erreurs = _serviceJeu.ValiderJeu(jeu);
            if (erreurs.Any())
            {
                MessageBox.Show(string.Join("\n", erreurs));
                return false;
            }
            return true;
        }
        #endregion

        #region Boutons
        public void buttonAjouter_Click(object sender, EventArgs e)
        {
            var jeu = new Jeu
            {
                Titre = textBoxTitre.Text,
                Description = textBoxDescription.Text,
                Editeur = textBoxEditeur.Text,
                Pegi = (int)comboBoxPegi.SelectedValue,
                Plateformes = checkedListBoxPlateforme.CheckedItems
                                  .Cast<Plateforme>()
                                  .ToList(),
                DateSortie = dateTimePickerDateSortie.Value
            };
            if (ValiderJeu(jeu))
            { 
                _serviceJeu.Creer(jeu);
                ChargerJeux();
                Raz_Zones();
            }

        }
        private void buttonModifier_Click(object sender, EventArgs e)
        {
            if (dataGridJeux.CurrentRow == null)
                return;

            if (_jeuSelectionne == null)
                return;

            var jeu = (Jeu)dataGridJeux.CurrentRow.DataBoundItem;

            _jeuSelectionne.Titre = textBoxTitre.Text;
            _jeuSelectionne.Description = textBoxDescription.Text; ;
            _jeuSelectionne.Editeur = textBoxEditeur.Text;
            _jeuSelectionne.Pegi = (int)comboBoxPegi.SelectedValue;
            _jeuSelectionne.Plateformes = checkedListBoxPlateforme.CheckedItems
                          .Cast<Plateforme>()
                          .ToList();
            _jeuSelectionne.DateSortie = dateTimePickerDateSortie.Value;

            if (ValiderJeu(_jeuSelectionne))
            {
                _serviceJeu.Modifier(_jeuSelectionne);
                ChargerJeux();
                Raz_Zones();
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

            if (_jeuSelectionne == null)
                return;
            var jeu = (Jeu)dataGridJeux.CurrentRow.DataBoundItem;

            _serviceJeu.Supprimer(_jeuSelectionne.IdJeu);
            _jeuSelectionne = null;
            ChargerJeux();
            Raz_Zones();

        }

        #endregion
    }
}
