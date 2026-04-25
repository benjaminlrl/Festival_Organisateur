using Lib_Entities.Entities;
using Lib_Metier.Data.Configurations;
using Lib_Services.Interfaces;
using Lib_Services.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        string ordreChamp = "ASC";

        public UcOrganisateurs(Organisateur unOrganisateurConnecte)
        {
            InitializeComponent();
            var context = new ApplicationDbContext();
            _serviceOrganisateur = new OrganisateurService(context);
            _serviceRole = new RoleService(context);
            _organisateurConnecte = unOrganisateurConnecte;
            filtre = "";
            ChargerOrganisateurs();
            ChargerRoles();
            buttonModifier.Enabled = _organisateurSelectionne != null;
            buttonSupprimer.Enabled = _organisateurSelectionne != null;
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcOrganisateurs, "Ajouter") == false)
            {
                buttonAjouter.Visible = false;
            }
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcOrganisateurs, "Modifier") == false)
            {
                buttonModifier.Visible = false;
            }
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcOrganisateurs, "Supprimer") == false)
            {
                buttonSupprimer.Visible = false;
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

            dataGridOrganisateurs.Columns["IdRole"].Visible = false;
            dataGridOrganisateurs.Columns["Login"].DisplayIndex = 0;
            dataGridOrganisateurs.Columns["Mail"].DisplayIndex = 1;
            dataGridOrganisateurs.Columns["motPasse"].Visible = false;
            dataGridOrganisateurs.Columns["Role"].Visible = false;
            dataGridOrganisateurs.Columns["NomRole"].HeaderText = "Rôle";
            dataGridOrganisateurs.Columns["Login"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridOrganisateurs.Columns["Mail"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
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
            buttonModifier.Enabled = _organisateurSelectionne != null;
            buttonSupprimer.Enabled = _organisateurSelectionne != null;
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
        /// Permet de voir si un mot de passe est conformes aux règles de sécurité suivantes 
        /// </summary>
        /// <param name="motDePasse"></param>
        /// <returns>true si tout est respectés, sinon false.</returns>
        public bool MdpValide(string motDePasse)
        {
            var erreurs = _serviceOrganisateur.MdpValide(motDePasse);
            if (erreurs.Any())
            {
                MessageBox.Show(string.Join("\n", erreurs), "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Permet de voir si un identifaint est conformes aux règles de sécurité suivantes
        /// </summary>
        /// <param name="identifiant"></param>
        /// <returns>true si tout est respectés, sinon false.</returns>
        public bool IdentifiantValide(string identifiant)
        {
            var erreurs = _serviceOrganisateur.IdentifiantValide(identifiant);
            if (erreurs.Any())
            {
                MessageBox.Show(string.Join("\n", erreurs), "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
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
        private void ButtonAjouter_Click(object sender, EventArgs e)
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

            // On check si l'identifiant n'existe pas déjà
            if (_serviceOrganisateur.Obtenir(_unNouveauOrganisateur.Login) != null)
            {
                MessageBox.Show("Ce login est déjà utilisé.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // On check si l'identifiant est valide
            if (IdentifiantValide(textBoxLogin.Text) == false)
            {
                return;
            }
            // On check si le mot de passe est valide
            if (MdpValide(textBoxMotDePasse.Text) == false)
            {
                return;
            }

            // On créé l'organisateur en bdd
            MessageBox.Show("L'organisateur a bien été ajouté.", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _serviceOrganisateur.Creer(_unNouveauOrganisateur);
            ChargerOrganisateurs();
            Raz_Zones();
        }

        /// <summary>
        /// Modifie l'organisateur sélectionné avec les nouvelles valeurs saisies.
        /// Vérifie que les champs sont valides et que le login n'a pas été modifié.
        /// Le mot de passe est hashé via BCrypt avant d'être sauvegardé.
        /// </summary>
        private void ButtonModifier_Click(object sender, EventArgs e)
        {
            // On check s'il a bien selectionné un organisateur à modifier
            if (_organisateurSelectionne == null)
            {
                MessageBox.Show("Aucun Organisateur sélectionné.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // On check si l'identifiant & le mot de passe sont valides, puis on modifie l'organisateur selectionné
            if (IdentifiantValide(textBoxLogin.Text) == false)
            {
                return;
            }
            if (textBoxMotDePasse.Text != "")
                if (MdpValide(textBoxMotDePasse.Text) == false)
                    return;

            // On check si il essaye de modifier le login (on a pas le droit)
            if (textBoxLogin.Text != _organisateurSelectionne.Login)
            {
                MessageBox.Show("Vous ne pouvez pas modifier le login d'un organisateur.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxLogin.Text = _organisateurSelectionne.Login;
                return;
            }

            // Modifiée seulement les valeurs qui ont été modifiées
            if (textBoxMail.Text != "" || _organisateurSelectionne.Mail != textBoxMail.Text)
                _organisateurSelectionne.Mail = textBoxMail.Text;
            if (textBoxMotDePasse.Text != "" || _organisateurSelectionne.motPasse != textBoxMotDePasse.Text)
                _organisateurSelectionne.motPasse = BCrypt.Net.BCrypt.HashPassword(textBoxMotDePasse.Text); // on oublie pas de hashé via BCrypt
            if ((int)comboBoxRole.SelectedValue != _organisateurSelectionne.IdRole)
                _organisateurSelectionne.IdRole = (int)comboBoxRole.SelectedValue;

            MessageBox.Show("Le lot composant a bien été modifié.", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _serviceOrganisateur.Modifier(_organisateurSelectionne);
            ChargerOrganisateurs();
            Raz_Zones();
        }

        /// <summary>
        /// Supprime l'organisateur sélectionné après vérification.
        /// Empêche la suppression de son propre compte et des comptes Administrateur.
        /// </summary>
        private void ButtonSupprimer_Click(object sender, EventArgs e)
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
            MessageBox.Show("L'organisateur a bien été supprimé.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _serviceOrganisateur.Supprimer(_organisateurSelectionne.Login);
            ChargerOrganisateurs();
            Raz_Zones();
        }

        /// <summary>
        /// Remet le formulaire à vide sans sauvegarder les modifications.
        /// </summary>
        private void ButtonEffacer_Click(object sender, EventArgs e)
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
                    { dataGridOrganisateurs.Columns["Login"].Index, "Login" },
                    { dataGridOrganisateurs.Columns["Mail"].Index, "Mail" },
                    { dataGridOrganisateurs.Columns["NomRole"].Index, "NomRole" }
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

            buttonModifier.Enabled = _organisateurSelectionne != null;
            buttonSupprimer.Enabled = _organisateurSelectionne != null;
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