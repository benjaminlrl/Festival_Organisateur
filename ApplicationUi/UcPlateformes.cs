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
    public partial class UcPlateformes : UserControl
    {
        private readonly ApplicationDbContext _context;
        private readonly IPlateformeService _servicePlateforme;
        private readonly IOrganisateurService _serviceOrganisateur;
        private Plateforme? _plateformeSelectionee;
        private PosteJeu? _posteJeuSelectionne;
        private Jeu? _jeuSelectionne;
        private string filtre;
        private string ordreChamp;
        private readonly Organisateur _organisateurConnecte;
        public event Action<PosteJeu>? NaviguerVersPostesJeu;
        public event Action<Jeu>? NaviguerVersJeux;
        public UcPlateformes(Organisateur unOrganisateurConnecte, Plateforme? plateformePreselectionnee = null)
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
            _serviceOrganisateur = new OrganisateurService(_context);
            _servicePlateforme = new PlateformeService(_context);

            _organisateurConnecte = unOrganisateurConnecte;
            _plateformeSelectionee = null;
            _posteJeuSelectionne = null;
            _jeuSelectionne=null;

            dataGridJeux.Visible = false;
            dataGridPostesJeu.Visible = false;

            filtre = "";
            buttonEffacer.Text = " 🧽  Effacer";
            ordreChamp = "DESC";

            Raz_Zones();

            if (plateformePreselectionnee != null)
            {
                _plateformeSelectionee = plateformePreselectionnee;
                RemplirFormulaire();
            }

            if (_serviceOrganisateur.EstAutoriser(_organisateurConnecte, Organisateur.LesUC.UcPlateformes, "Ajouter") == false)
            {
                buttonAjouter.Visible = false;
                DesactiverInputs();
            }
            if (_serviceOrganisateur.EstAutoriser(_organisateurConnecte, Organisateur.LesUC.UcPlateformes, "Modifier") == false)
            {
                buttonModifier.Visible = false;
                DesactiverInputs();
            }
            if (_serviceOrganisateur.EstAutoriser(_organisateurConnecte, Organisateur.LesUC.UcPlateformes, "Supprimer") == false)
            {
                buttonSupprimer.Visible = false;
                DesactiverInputs();
            }
        }

        #region Données
        private void ChargerPlateformes()
        {
            dataGridPlateformes.DataSource = null;
            dataGridPlateformes.DataSource = _servicePlateforme.Lister(filtre);
            MEP_DataGridPlateformes();
        }

        private void ChargerPostesJeu()
        {
            labelPostesJeu.Visible = true;
            dataGridPostesJeu.Visible = true;
            dataGridPostesJeu.DataSource = null;
            dataGridPostesJeu.DataSource = _plateformeSelectionee.PostesJeu.ToList();
            MEP_DataGridPostesJeu();
        }

        private void ChargerJeux()
        {
            labelJeux.Visible = true;
            dataGridJeux.Visible = true;
            dataGridJeux.DataSource = null;
            dataGridJeux.DataSource = _plateformeSelectionee.Jeux.ToList();
            MEP_DataGridJeux();
        }

        private void MEP_DataGridPlateformes()
        {
            dataGridPlateformes.Columns["idPlateforme"].Visible = false;
            dataGridPlateformes.Columns["PostesJeu"].Visible = false;
            dataGridPlateformes.Columns["Jeux"].Visible = false;
        }
        private void MEP_DataGridJeux()
        {
            dataGridJeux.Columns["Titre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridJeux.Columns["Editeur"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridJeux.Columns["Pegi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridJeux.Columns["AnneeSortie"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridJeux.Columns["IdJeu"].Visible = false;
            dataGridJeux.Columns["DateSortie"].Visible = false;
            dataGridJeux.Columns["Description"].Visible = false;
            dataGridJeux.Columns["Tournois"].Visible = false;
            dataGridJeux.Columns["Plateformes"].Visible = false;
        }

        private void MEP_DataGridPostesJeu()
        {
            dataGridPostesJeu.Columns["Espace"].Visible = false;
            dataGridPostesJeu.Columns["IdPlateforme"].Visible = false;
            dataGridPostesJeu.Columns["IdEspace"].Visible = false;
            dataGridPostesJeu.Columns["Plateforme"].Visible = false;
            dataGridPostesJeu.Columns["NumeroPoste"].Visible = false;
            dataGridPostesJeu.Columns["NomEspace"].Visible = false;
            dataGridPostesJeu.Columns["NomPlateforme"].Visible = false;

            dataGridPostesJeu.Columns["Reference"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        #endregion

        #region Évenements

        #region Boutons
        public void ButtonAjouter_Click(object sender, EventArgs e)
        {
            Plateforme plateforme = new()
            {
                Libelle = textBoxNom.Text
            };

            try
            {
                _servicePlateforme.Creer(plateforme);
                MessageBox.Show("La plateforme a bien été ajoutée.", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Raz_Zones();
            }
            catch (PlateformeException ex)
            {
                Log.Warning("[{Code}] {Message}", ex.CodeErreur, ex.Message);
                MessageBox.Show(ex.Message, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DbException ex)
            {
                Log.Error(ex, "Une erreur technique est survenue lors de l'ajout de la plateforme.");
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
            if (dataGridPlateformes.CurrentRow == null || _plateformeSelectionee == null)
            {
                MessageBox.Show("Aucune plateforme sélectionnée", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _plateformeSelectionee.Libelle = textBoxNom.Text;

            try
            {
                _servicePlateforme.Modifier(_plateformeSelectionee);
                MessageBox.Show("La plateforme a bien été modifiée.", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Raz_Zones();
            }
            catch (PlateformeException ex)
            {
                Log.Warning("[{Code}] {Message}", ex.CodeErreur, ex.Message);
                MessageBox.Show(ex.Message, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DbException ex)
            {
                Log.Error(ex, "Une erreur technique est survenue lors de la modification de la plateforme.");
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
            if (dataGridPlateformes.CurrentRow == null || _plateformeSelectionee == null)
            {
                MessageBox.Show("Aucune plateforme sélectionnée", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _servicePlateforme.Supprimer(_plateformeSelectionee.IdPlateforme);
                MessageBox.Show("La plateforme a bien été supprimée.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Raz_Zones();
            }
            catch (PlateformeException ex)
            {
                Log.Warning("[{Code}] {Message}", ex.CodeErreur, ex.Message);
                MessageBox.Show(ex.Message, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DbException ex)
            {
                Log.Error(ex, "Une erreur technique est survenue lors de l'ajout de la plateforme.");
                MessageBox.Show("Erreur technique, réessayez plus tard.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Une erreur inattendue est survenue.");
                MessageBox.Show("Une erreur inattendue est survenue.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion
        /// <summary>
        /// Redirige vers le formulaire de gestion des postes de jeu en transmettant la plateforme sélectionnée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridPostesJeu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            _posteJeuSelectionne = dataGridPostesJeu.Rows[e.RowIndex].DataBoundItem as PosteJeu;

            if (_posteJeuSelectionne != null)
                NaviguerVersPostesJeu?.Invoke(_posteJeuSelectionne); // déclenche la navigation vers le form main
        }

        /// <summary>
        /// Redirige vers le formulaire de gestion des jeux en transmettant le jeu sélectionné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridJeux_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            _jeuSelectionne = dataGridJeux.Rows[e.RowIndex].DataBoundItem as Jeu;

            if (_jeuSelectionne != null)
                NaviguerVersJeux?.Invoke(_jeuSelectionne); // déclenche la navigation vers le form main
        }

        private void DataGridPlateformes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Gérer le trie par ordre des champs en fonction du clique sur la cellule d'en-tête
            if (e.RowIndex < 0)
            {
                // Utiliser un dictionnaire plutôt qu'un switch pour associer les index de colonnes
                // à des fonctions de sélection de clé
                Dictionary<int, string> map = new()
                {
                    {dataGridPlateformes.Columns["Libelle"].Index, "Libelle"},
                };

                if (!map.TryGetValue(e.ColumnIndex, out string? colonne))
                    return;

                // permuter l'ordre de tri entre ASC et DESC
                ordreChamp = ordreChamp == "ASC" ? "DESC" : "ASC";

                dataGridPlateformes.DataSource = _servicePlateforme.Lister(filtre, colonne, ordreChamp);
                dataGridPlateformes.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection =
                    ordreChamp == "ASC" ? SortOrder.Ascending : SortOrder.Descending;

                MEP_DataGridPlateformes();
                return;
            }

            _plateformeSelectionee = dataGridPlateformes.Rows[e.RowIndex].DataBoundItem as Plateforme;

            if (_plateformeSelectionee != null)
                RemplirFormulaire();

            AfficherBoutons();
        }

        /// <summary>
        /// Permet de filtrer les résultats affichés dans la grille des plateformes 
        /// en fonction du texte saisi dans la zone de recherche.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxRecherche_TextChanged(object sender, EventArgs e)
        {
            filtre = textBoxRecherche.Text;
            ChargerPlateformes();
        }
        #endregion

        #region Méthodes

        /// <summary>
        /// Remplit les champs du formulaire avec les données de la plateforme sélectionnée
        /// </summary>
        private void RemplirFormulaire()
        {
            if (_plateformeSelectionee == null)
                return;

            textBoxNom.Text = _plateformeSelectionee.Libelle;

            ChargerPostesJeu();
            ChargerJeux();

            AfficherBoutons();
        }

        /// <summary>
        /// Remet a zéro toutes les zones du formulaire, 
        /// réinitialise les variables de sélection et de filtre, 
        /// recharge la liste des plateformes 
        /// et met à jour l'affichage des boutons en conséquence.
        /// </summary>
        private void Raz_Zones()
        {
            textBoxNom.Clear();

            _plateformeSelectionee = null;
            _posteJeuSelectionne = null;
            _jeuSelectionne = null;

            dataGridJeux.DataSource = null;
            dataGridPostesJeu.DataSource = null;
            dataGridJeux.Visible = false;
            dataGridPostesJeu.Visible = false;

            filtre = "";

            ChargerPlateformes();

            AfficherBoutons();
        }
        /// <summary>
        /// Permet d'afficher ou de masquer les boutons d'action en fonction de la sélection actuelle d'une plateforme.
        /// </summary>
        private void AfficherBoutons()
        {
            buttonAjouter.Enabled = true;

            // Si aucun espace n'est sélectionné, les boutons de modification, suppression et effacement sont désactivés
            buttonModifier.Enabled = _plateformeSelectionee != null;
            buttonSupprimer.Enabled = _plateformeSelectionee != null;
            buttonEffacer.Enabled = _plateformeSelectionee != null;
        }

        /// <summary>
        /// Permet de désactiver les champs de saisie du formulaire si l'utilisateur 
        /// n'a pas les droits nécessaires pour ajouter ou modifier des espaces.
        /// </summary>
        private void DesactiverInputs()
        {
            textBoxNom.Enabled = false;
        }
        #endregion
    }
}
