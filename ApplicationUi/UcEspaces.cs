using Lib_Entities.Entities;
using Lib_Metier.Data.Configurations;
using Lib_Services.Interfaces;
using Lib_Services.Services;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace ApplicationUi
{
    public partial class UcEspaces : UserControl
    {
        private readonly IEspaceService _serviceEspace;
        private Espace? _espaceSelectionee = null;
        // Champ pour stocker le texte de recherche et l'utiliser lors du rechargement des espaces
        private string filtre;
        // Champ pour suivre l'ordre de tri actuel sur la colonne Nom
        private string ordreChamp;
        private readonly Organisateur _organisateurConnecte;
        public UcEspaces(Organisateur unOrganisateurConnecte)
        {
            InitializeComponent();
            _serviceEspace = new EspaceService(new ApplicationDbContext());
            buttonModifier.Enabled = _espaceSelectionee != null;
            buttonSupprimer.Enabled = _espaceSelectionee != null;
            buttonEffacer.Text = "🧽  Effacer";
            ordreChamp = "ASC";
            filtre = "";
            _organisateurConnecte = unOrganisateurConnecte;
            ChargerEspaces();
        }
        #region Evènements
        /// <summary>
        /// Charge les espaces depuis la base de données et les affiche dans le DataGridView.
        /// </summary>
        /// <param name="filtre"></param>
        private void ChargerEspaces()
        {
            dataGridEspaces.DataSource = null;
            dataGridEspaces.DataSource = _serviceEspace.Lister(filtre);
            MEP_DataGrid();
            ChargerStatistiques();
        }

        /// <summary>
        /// Charge les postes de jeux de l'espace selectionnee
        /// </summary>
        private void ChargerPostesJeu()
        {
            dataGridPostesJeu.DataSource = null;
            dataGridPostesJeu.DataSource = _espaceSelectionee.PostesJeu.ToList();
            MEP_DataGridPostesJeu();
        }

        /// <summary>
        /// Permet de charger les statistiques liées aux espaces, notamment le nombre total d'espaces 
        /// et le nombre d'espaces libres (sans tournoi associé). 
        /// Les statistiques sont affichées dans des labels dédiés, 
        /// avec une indication visuelle (couleur) pour les espaces libres.
        /// Cette méthode est appelée après le chargement des espaces pour garantir 
        /// que les statistiques sont à jour.
        /// </summary>
        private void ChargerStatistiques()
        {
            // Un espace libre est un espae qui n'a pas de tournoi associé
            int nbEspacesLibres = _serviceEspace.Lister(filtre).Count(e => e.Tournois == null);

            labelStatEspacesTotal.Text = $"{_serviceEspace.Lister("").Count()}";

            if (nbEspacesLibres == 0)
            {
                labelStatEspacesLibres.Text = "Aucun espace libre";
                labelStatEspacesLibres.ForeColor = Color.Red;
            }
            else
            {
                labelStatEspacesLibres.Text = $"Disponibles : {nbEspacesLibres}";
                labelStatEspacesLibres.ForeColor = Color.Green;
            }
        }


        /// <summary>
        /// Resets all tournament-related input fields and controls to their default values.
        /// </summary>
        /// <remarks>Use this method to clear the current tournament selection and prepare the form for
        /// entering a new tournament. All user input fields are cleared or set to their minimum values, and the status
        /// controls are reset to indicate a planned tournament.</remarks>
        private void Raz_Zones()
        {
            textBoxNom.Clear();
            textBoxDescription.Clear();
            numericUpDownCapaciteMaxi.Value = numericUpDownCapaciteMaxi.Minimum;
            numericUpDownSuperficie.Value = numericUpDownSuperficie.Minimum;
            filtre = "";
        }
        private void MEP_DataGrid()
        {
            dataGridEspaces.Columns["idEspace"].Visible = false;
            dataGridEspaces.Columns["Tournois"].Visible = false;
            dataGridEspaces.Columns["PostesJeu"].Visible = false;
            dataGridEspaces.Columns["Nom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void MEP_DataGridPostesJeu()
        {
            dataGridPostesJeu.Columns["Reference"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void dataGridEspaces_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignorer les clics sur l'en-tête (gérés pour le tri)
            if (e.RowIndex < 0)
            {   // ordonner sur les champs descriptions, superficie, capaciteMaxi
                var donnees = _serviceEspace.Lister(filtre);
                var map = new Dictionary<int, Func<Espace, object>>
                {
                    {dataGridEspaces.Columns["Nom"].Index, e => e.Nom },
                    {dataGridEspaces.Columns["Description"].Index, e => e.Description},
                    {dataGridEspaces.Columns["Superficie"].Index, e => e.Superficie},
                    {dataGridEspaces.Columns["CapaciteMaxi"].Index, e => e.CapaciteMaxi},
                };
                if (!map.TryGetValue(e.ColumnIndex, out var keySelector))
                    return;
                // Appliquer le tri
                dataGridEspaces.DataSource = ordreChamp == "ASC"
                    ? donnees.OrderByDescending(keySelector).ToList()
                    : donnees.OrderBy(keySelector).ToList();

                // Inverser l’ordre
                ordreChamp = ordreChamp == "ASC" ? "DESC" : "ASC";

                MEP_DataGrid();
                return;
            }

            // Ne pas recharger le DataSource lors d'un clic sur une cellule : cela réinitialise la sélection
            _espaceSelectionee = dataGridEspaces.Rows[e.RowIndex].DataBoundItem as Espace;

            if (_espaceSelectionee != null)
                RemplirFormulaire(_espaceSelectionee);

            buttonModifier.Enabled = _espaceSelectionee != null;
            buttonSupprimer.Enabled = _espaceSelectionee != null;
        }

        /// <summary>
        /// Remplit les champs du formulaire avec les informations de l'espace spécifié.
        /// </summary>
        /// <remarks>Cette méthode met à jour les contrôles du formulaire pour refléter les propriétés de
        /// l'espace fourni. Elle doit être appelée lors de l'affichage ou de la modification d'un espace
        /// existant.</remarks>
        /// <param name="espace">L'objet Espace contenant les données à afficher dans le formulaire. Ne doit pas être null.</param>
        private void RemplirFormulaire(Espace espace)
        {
            textBoxNom.Text = espace.Nom;
            textBoxDescription.Text = espace.Description;
            numericUpDownCapaciteMaxi.Value = espace.CapaciteMaxi;
            numericUpDownSuperficie.Value = espace.Superficie;
            ChargerPostesJeu(); // Charge les postes de jeu associés à l'espace sélectionné
                                // pour les afficher dans le DataGridView correspondante
        }
        #endregion
        #region Validations
        /// <summary>
        /// Vérifie que les champs obligatoires pour un espace sont valides avant de poursuivre l'opération.
        /// </summary>
        /// <remarks>Affiche une boîte de dialogue d'avertissement pour chaque validation échouée afin
        /// d'informer l'utilisateur de la correction à apporter. Cette méthode doit être appelée avant d'enregistrer ou
        /// de modifier un espace pour garantir l'intégrité des données saisies.</remarks>
        /// <returns>true si tous les champs requis sont valides et respectent les contraintes ; sinon, false.</returns>
        private bool ValiderEspace()
        {

            if (string.IsNullOrWhiteSpace(textBoxNom.Text))
            {
                MessageBox.Show("Le nom de l'espace est requis.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (numericUpDownCapaciteMaxi.Value <= 0)
            {
                MessageBox.Show("La capacité maximale doit être supérieure à zéro.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (numericUpDownSuperficie.Value <= 0)
            {
                MessageBox.Show("La superficie doit être supérieure à zéro.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (textBoxDescription.Text.Length > 500)
            {
                MessageBox.Show("La description ne peut pas dépasser 500 caractères.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (_serviceEspace.Lister("").Any(e => e.Nom == textBoxNom.Text))
            {
                MessageBox.Show("Un autre espace avec ce nom existe déjà.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        #endregion
        #region Boutons
        /// <summary>
        /// Gère l'événement de clic sur le bouton d'ajout pour créer un nouvel espace à partir des informations saisies
        /// par l'utilisateur.
        /// </summary>
        /// <remarks>Cette méthode valide les champs de saisie avant de créer un nouvel espace. Si la
        /// validation échoue, aucun espace n'est ajouté.</remarks>
        /// <param name="sender">L'objet à l'origine de l'événement, généralement le bouton Ajouter.</param>
        /// <param name="e">Les données d'événement associées au clic du bouton.</param>
        public void buttonAjouter_Click(object sender, EventArgs e)
        {
            if (ValiderEspace())
            {
                var espace = new Espace
                {
                    Nom = textBoxNom.Text,
                    Description = textBoxDescription.Text,
                    CapaciteMaxi = (int)numericUpDownCapaciteMaxi.Value,
                    Superficie = (int)numericUpDownSuperficie.Value,
                };
                _serviceEspace.Creer(espace);
                ChargerEspaces();
                Raz_Zones();
            }

        }
        /// <summary>
        /// Gère l'événement de clic sur le bouton de modification pour appliquer les changements apportés à l'espace
        /// sélectionné.
        /// </summary>
        /// <remarks>Cette méthode met à jour les informations de l'espace actuellement sélectionné dans
        /// le tableau, puis recharge la liste des espaces et réinitialise les zones de saisie. Aucun traitement n'est
        /// effectué si aucune ligne n'est sélectionnée ou si aucun espace n'est sélectionné.</remarks>
        /// <param name="sender">L'objet à l'origine de l'événement, généralement le bouton Modifier.</param>
        /// <param name="e">Les données d'événement associées au clic sur le bouton.</param>
        private void buttonModifier_Click(object sender, EventArgs e)
        {
            if (dataGridEspaces.CurrentRow == null)
                return;

            if (_espaceSelectionee == null)
                return;
            var espace = (Espace)dataGridEspaces.CurrentRow.DataBoundItem;

            _espaceSelectionee.Nom = textBoxNom.Text;
            _espaceSelectionee.Description = textBoxDescription.Text;
            _espaceSelectionee.CapaciteMaxi = (int)numericUpDownCapaciteMaxi.Value;
            _espaceSelectionee.Superficie = (int)numericUpDownSuperficie.Value;

            _serviceEspace.Modifier(_espaceSelectionee);
            ChargerEspaces();
            Raz_Zones();
        }
        /// <summary>
        /// Gère l'événement de clic sur le bouton Effacer et réinitialise les zones de saisie du formulaire.
        /// </summary>
        /// <param name="sender">L'objet à l'origine de l'événement, généralement le bouton Effacer.</param>
        /// <param name="e">Les données d'événement associées au clic sur le bouton.</param>
        private void buttonEffacer_Click(object sender, EventArgs e)
        {
            Raz_Zones();
        }
        /// <summary>
        /// Gère l'événement de clic sur le bouton de suppression pour retirer l'espace sélectionné de la liste.
        /// </summary>
        /// <remarks>Cette méthode vérifie qu'une ligne et un espace sont sélectionnés avant de procéder à
        /// la suppression. Après la suppression, la liste des espaces est rechargée et les zones associées sont
        /// réinitialisées.</remarks>
        /// <param name="sender">L'objet source de l'événement, généralement le bouton de suppression.</param>
        /// <param name="e">Les données d'événement associées au clic sur le bouton.</param>
        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            if (dataGridEspaces.CurrentRow == null)
                return;

            if (_espaceSelectionee == null)
                return;
            var espace = (Espace)dataGridEspaces.CurrentRow.DataBoundItem;

            _serviceEspace.Supprimer(_espaceSelectionee.IdEspace);
            _espaceSelectionee = null;
            ChargerEspaces();
            Raz_Zones();

        }
        /// <summary>
        /// Gère l'événement déclenché lorsque le texte de la zone de recherche est modifié.
        /// </summary>
        /// <remarks>Utilisez cet événement pour mettre à jour dynamiquement les résultats de recherche en
        /// fonction de la saisie de l'utilisateur.</remarks>
        /// <param name="sender">L'objet source de l'événement, généralement la zone de texte de recherche.</param>
        /// <param name="e">Les données associées à l'événement de modification du texte.</param>
        private void textBoxRecherche_TextChanged(object sender, EventArgs e)
        {
            filtre = textBoxRecherche.Text;
            ChargerEspaces();
        }

        #endregion

        private void buttonPostesJeu_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridEspaces_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
