using Lib_Entities.Entities;
using Lib_Metier.Data.Configurations;
using Lib_Services.Interfaces;
using Lib_Services.Services;
using Lib_Services.Exceptions;
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
    public partial class UcOrganisateurs : UserControl
    {
        private readonly IOrganisateurService _serviceOrganisateur;
        private readonly IRoleService _serviceRole;
        private Organisateur? _organisateurSelectionne = null;
        private Organisateur? _unNouveauOrganisateur = null;
        private readonly Organisateur _organisateurConnecte;
        string filtre;
        string ordreChamp = "DESC";

        public UcOrganisateurs(Organisateur unOrganisateurConnecte)
        {
            InitializeComponent();
            var context = new ApplicationDbContext();
            _serviceOrganisateur = new OrganisateurService(context);
            _serviceRole = new RoleService(context);
            _organisateurConnecte = unOrganisateurConnecte;
            filtre = "";
            Raz_Zones();
            if (_serviceOrganisateur.EstAutoriser(_organisateurConnecte, Organisateur.LesUC.UcOrganisateurs, "Ajouter") == false)
            {
                boutonAjouter.Visible = false;
            }
            if (_serviceOrganisateur.EstAutoriser(_organisateurConnecte, Organisateur.LesUC.UcOrganisateurs, "Modifier") == false)
            {
                boutonModifier.Visible = false;
            }
            if (_serviceOrganisateur.EstAutoriser(_organisateurConnecte, Organisateur.LesUC.UcOrganisateurs, "Supprimer") == false)
            {
                boutonSupprimer.Visible = false;
            }
        }

        #region Chargement

        /// <summary>
        /// Charge la liste des organisateurs dans le DataGrid en excluant les comptes administrateurs.
        /// Applique le filtre de recherche en cours avant d'afficher les données.
        /// </summary>
        private void ChargerOrganisateurs()
        {
            dataGridOrganisateurs.DataSource = null;
            var listeOrganisateur = _serviceOrganisateur.Lister(filtre)
                .Where(o => !o.Login.Contains("admin"))
                .ToList();
            dataGridOrganisateurs.DataSource = listeOrganisateur;
            MEP_DataGrid();
        }

        /// <summary>
        /// Met en page le DataGrid des organisateurs en configurant la visibilité
        /// et l'ordre d'affichage des colonnes.
        /// </summary>
        private void MEP_DataGrid()
        {
            // On affiche et modifie l'affichage des colonnes du dataGrid
            DesactiverTrieAutomatique(dataGridOrganisateurs);

            dataGridOrganisateurs.Columns["IdRole"]!.Visible = false;
            dataGridOrganisateurs.Columns["Login"]!.DisplayIndex = 0;
            dataGridOrganisateurs.Columns["Mail"]!.DisplayIndex = 1;
            dataGridOrganisateurs.Columns["motPasse"]!.Visible = false;
            dataGridOrganisateurs.Columns["Role"]!.Visible = false;
            dataGridOrganisateurs.Columns["NomRole"]!.HeaderText = "Rôle";
            dataGridOrganisateurs.Columns["Login"]!.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridOrganisateurs.Columns["Mail"]!.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        /// <summary>
        /// Charge la liste des rôles disponibles dans la ComboBox.
        /// Applique le filtre de recherche en cours avant d'afficher les données.
        /// </summary>
        private void ChargerRoles()
        {
            comboBoxRole.DataSource = null;
            comboBoxRole.DataSource = _serviceRole.Lister(filtre);
            comboBoxRole.DisplayMember = "Libelle";
            comboBoxRole.ValueMember = "IdRole";
        }

        /// <summary>
        /// Remet tous les champs du formulaire à vide et désélectionne l'organisateur en cours.
        /// Désactive également les boutons Modifier et Supprimer.
        /// </summary>
        private void Raz_Zones()
        {
            textBoxLogin.Clear();
            textBoxMail.Clear();
            textBoxMotDePasse.Clear();
            comboBoxRole.SelectedItem = null;
            _organisateurSelectionne = null;
            boutonModifier.Enabled = _organisateurSelectionne != null;
            boutonSupprimer.Enabled = _organisateurSelectionne != null;
            ChargerOrganisateurs();
            ChargerRoles();
        }

        /// <summary>
        /// Remplit les champs du formulaire avec les données de l'organisateur sélectionné.
        /// Le mot de passe n'est pas affiché par sécurité.
        /// </summary>
        /// <param name="organisateur">L'organisateur dont les données sont affichées.</param>
        private void RemplirFormulaire(Organisateur organisateur)
        {
            textBoxLogin.Text = organisateur.Login;
            textBoxMail.Text = organisateur.Mail;
            textBoxMotDePasse.Clear();
            comboBoxRole.SelectedValue = organisateur.IdRole;
        }

        #endregion

        #region Validations
        /// <summary>
        /// Permet de voir si tout les champs d'un organisateur ne sont pas vides
        /// </summary>
        /// <returns>true si tout est respectés, sinon false.</returns>
        public bool ChampVide()
        {
            if (string.IsNullOrWhiteSpace(textBoxLogin.Text))
            {
                MessageBox.Show("Le Login ne peut pas être vide", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxMail.Text))
            {
                MessageBox.Show("Le Mail ne peut pas être vide", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxMotDePasse.Text))
            {
                MessageBox.Show("Le Mot de Passe ne peut pas être vide", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (comboBoxRole.SelectedValue == null)
            {
                MessageBox.Show("Le Rôle ne peut pas être vide", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        #endregion

        #region Evènements

        /// <summary>
        /// Crée un nouvel organisateur avec les données saisies dans le formulaire.
        /// Vérifie que les champs sont valides, que le login n'existe pas déjà,
        /// et que l'identifiant et le mot de passe respectent les règles de validation.
        /// </summary>
        private void BoutonAjouter_Click(object sender, EventArgs e)
        {
            // On check si les champs sont vides
            if (ChampVide() == false)
            {
                return;
            }

            // On crée un nouveau organisateur avec les données des champs
            _unNouveauOrganisateur = new Organisateur
            {
                Login = textBoxLogin.Text,
                Mail = textBoxMail.Text,
                motPasse = textBoxMotDePasse.Text,
                IdRole = (int)comboBoxRole.SelectedValue
            };

            try
            {
                _serviceOrganisateur.Creer(_unNouveauOrganisateur);
                MessageBox.Show("L'organisateur a bien été ajouté.", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ChargerOrganisateurs();
                Raz_Zones();
            }
            catch (OrganisateurException ex)
            { 
                Log.Warning("[{Code}] {Message}", ex.CodeErreur, ex.Message);
                MessageBox.Show(ex.Message);
            }
            catch (DbException ex)
            {
                Log.Error(ex, "Une erreur technique est survenue lors de l'ajout de l'organisateur.");
                MessageBox.Show("Erreur technique, réessayez plus tard.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Une erreur inattendue est survenue.");
                MessageBox.Show("Une erreur inattendue est survenue.");
            }
        }

        /// <summary>
        /// Modifie l'organisateur sélectionné avec les nouvelles valeurs saisies.
        /// Vérifie que les champs sont valides et que le login n'a pas été modifié.
        /// Le mot de passe est hashé via BCrypt avant d'être sauvegardé.
        /// </summary>
        private void BoutonModifier_Click(object sender, EventArgs e)
        {
            // On check s'il a bien selectionné un organisateur à modifier
            if (_organisateurSelectionne == null)
            {
                MessageBox.Show("Aucun Organisateur sélectionné.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // On check si il essaye de modifier le login (on a pas le droit)
            if (textBoxLogin.Text != _organisateurSelectionne.Login)
            {
                MessageBox.Show("Vous ne pouvez pas modifier le login d'un organisateur.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxLogin.Text = _organisateurSelectionne.Login;
                return;
            }

            try
            {
                // Modifiée seulement les valeurs qui ont été modifiées
                if (textBoxMail.Text != "" || _organisateurSelectionne.Mail != textBoxMail.Text)
                    _organisateurSelectionne.Mail = textBoxMail.Text;
                if (textBoxMotDePasse.Text != "" || _organisateurSelectionne.motPasse != textBoxMotDePasse.Text)
                    _organisateurSelectionne.motPasse = textBoxMotDePasse.Text;
                if ((int)comboBoxRole.SelectedValue != _organisateurSelectionne.IdRole)
                    _organisateurSelectionne.IdRole = (int)comboBoxRole.SelectedValue;

                MessageBox.Show("L'organisateur a bien été modifié.", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _serviceOrganisateur.Modifier(_organisateurSelectionne);
                ChargerOrganisateurs();
                Raz_Zones();
            }
            catch (OrganisateurException ex)
            {
                Log.Warning("[{Code}] {Message}", ex.CodeErreur, ex.Message);
                MessageBox.Show(ex.Message);
            }
            catch (DbException ex)
            {
                Log.Error(ex, "Une erreur technique est survenue lors de la modification de l'organisateur.");
                MessageBox.Show("Erreur technique, réessayez plus tard.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Une erreur inattendue est survenue.");
                MessageBox.Show("Une erreur inattendue est survenue.");
            }
        }

        /// <summary>
        /// Supprime l'organisateur sélectionné après vérification.
        /// Empêche la suppression de son propre compte et des comptes Administrateur.
        /// </summary>
        private void BoutonSupprimer_Click(object sender, EventArgs e)
        {
            // On check s'il a bien selectionné un organisateur à supprimé
            // On check s'il essaye pas de supprimer l'organisateur connecté
            if (_organisateurSelectionne == null)
            {
                MessageBox.Show("Aucun organisateur sélectionné.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_organisateurSelectionne == _organisateurConnecte)
            {
                MessageBox.Show("Vous ne pouvez pas supprimer votre propre compte.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_organisateurSelectionne.NomRole == "Administrateur")
            {
                MessageBox.Show("Vous ne pouvez pas supprimer de compte Administrateur.\nVeuillez contacter un SuperAdmin.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Êtes vous sûr de vouloir supprimer ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            _serviceOrganisateur.Supprimer(_organisateurSelectionne.Login);
            MessageBox.Show("L'organisateur a bien été supprimé.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ChargerOrganisateurs();
            Raz_Zones();
        }

        /// <summary>
        /// Remet le formulaire à vide sans sauvegarder les modifications.
        /// </summary>
        private void BoutonEffacer_Click(object sender, EventArgs e)
        {
            Raz_Zones();
        }

        /// <summary>
        /// Gère les clics sur le DataGrid des organisateurs.
        /// Si le clic est sur un en-tête de colonne, trie les données par ordre ASC ou DESC.
        /// Si le clic est sur une cellule, sélectionne l'organisateur et remplit le formulaire.
        /// </summary>
        private void DataGridOrganisateurs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignorer les clics sur l'en-tête (gérés pour le tri)
            if (e.RowIndex < 0)
            {
                // ordonner sur les champs login, mail et nom de rôle
                Dictionary<int, string> map = new()
                {
                    { dataGridOrganisateurs.Columns["Login"]!.Index, "Login" },
                    { dataGridOrganisateurs.Columns["Mail"]!.Index, "Mail" },
                    { dataGridOrganisateurs.Columns["NomRole"]!.Index, "NomRole" }
                };

                // Si la colonne cliquée n'appartient pas aux propriétés ci-dessus, ne rien faire,
                // sinon récupérer le nom de la propriété associée à la colonne cliquée
                if (!map.TryGetValue(e.ColumnIndex, out string? colonne))
                    return;

                // Inverser l'ordre
                ordreChamp = ordreChamp == "ASC" ? "DESC" : "ASC";

                // Appliquer le tri
                dataGridOrganisateurs.DataSource = _serviceOrganisateur.Lister("admin", colonne, ordreChamp);
                dataGridOrganisateurs.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection =
                    ordreChamp == "ASC" ? SortOrder.Ascending : SortOrder.Descending;

                MEP_DataGrid();
                return;
            }

            // Ne pas recharger le DataSource lors d'un clic sur une cellule : cela réinitialise la sélection
            _organisateurSelectionne = dataGridOrganisateurs.Rows[e.RowIndex].DataBoundItem as Organisateur;

            if (_organisateurSelectionne != null)
                RemplirFormulaire(_organisateurSelectionne);

            boutonModifier.Enabled = _organisateurSelectionne != null;
            boutonSupprimer.Enabled = _organisateurSelectionne != null;
        }

        /// <summary>
        /// Gère l'événement déclenché lorsque le texte de la zone de recherche est modifié.
        /// </summary>
        /// <remarks>Utilisez cet événement pour mettre à jour dynamiquement les résultats de recherche en
        /// fonction de la saisie de l'utilisateur.</remarks>
        /// <param name="sender">L'objet source de l'événement, généralement la zone de texte de recherche.</param>
        /// <param name="e">Les données associées à l'événement de modification du texte.</param>
        private void TextBoxRecherche_TextChanged(object sender, EventArgs e)
        {
            filtre = textBoxRecherche.Text;
            ChargerOrganisateurs();

        }
        #endregion

        #region Méthodes
        /// <summary>
        /// Permet de désactiver le tri automatique sur les colonnes d'un DataGridView pour gérer le tri manuellement dans l'événement CellClick.
        /// </summary>
        /// <param name="dataGrid">Le DataGridView dont les colonnes doivent être configurées.</param>
        private void DesactiverTrieAutomatique(DataGridView dataGrid)
        {
            foreach (DataGridViewColumn col in dataGrid.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }
        #endregion
    }
}