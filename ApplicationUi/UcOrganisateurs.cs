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
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcOrganisateur, "Ajouter") == false)
            {
                buttonAjouter.Visible = false;
            }
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcOrganisateur, "Modifier") == false)
            {
                buttonModifier.Visible = false;
            }
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcOrganisateur, "Supprimer") == false)
            {
                buttonSupprimer.Visible = false;
            }
        }

        #region Chargement

        private void ChargerOrganisateurs()
        {
            // On charge la liste des organisateurs dans le dataGrid (sans les logins contenant "admin")
            dataGridOrganisateurs.DataSource = null;
            var listeOrganisateur = _serviceOrganisateur.Lister(filtre)
                .Where(o => !o.Login.Contains("admin"))
                .ToList();
            dataGridOrganisateurs.DataSource = listeOrganisateur;
            MEP_DataGrid();
        }

        private void MEP_DataGrid()
        {
            // On affiche et modifie l'affichage des colonnes du dataGrid
            dataGridOrganisateurs.Columns["IdRole"].Visible = false;
            dataGridOrganisateurs.Columns["Login"].DisplayIndex = 0;
            dataGridOrganisateurs.Columns["Mail"].DisplayIndex = 1;
            dataGridOrganisateurs.Columns["motPasse"].Visible = false;
            dataGridOrganisateurs.Columns["Role"].Visible = false;
            dataGridOrganisateurs.Columns["NomRole"].HeaderText = "Rôle";
        }

        private void ChargerRoles()
        {
            // On charge les rôles dans la comboBox
            comboBoxRole.DataSource = null;
            comboBoxRole.DataSource = _serviceRole.Lister(filtre);
            comboBoxRole.DisplayMember = "Libelle";
            comboBoxRole.ValueMember = "IdRole";
        }

        private void Raz_Zones()
        {
            // On remet tous les champs à vide
            textBoxLogin.Clear();
            textBoxMail.Clear();
            textBoxMotDePasse.Clear();
            comboBoxRole.SelectedItem = null;
            _organisateurSelectionne = null;
            buttonModifier.Enabled = _organisateurSelectionne != null;
            buttonSupprimer.Enabled = _organisateurSelectionne != null;
        }

        private void RemplirFormulaire(Organisateur organisateur)
        {
            // On remplie les champs avec les données de l'organisateur sélectionné
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

        #endregion

        #region Evènements

        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            // On crée un nouveau organisateur avec les données des champs
            _unNouveauOrganisateur = new Organisateur
            {
                Login = textBoxLogin.Text,
                Mail = textBoxMail.Text,
                motPasse = textBoxMotDePasse.Text,
                IdRole = (int)comboBoxRole.SelectedValue
            };

            // On check si l'identifiant & le mot de passe sont valides, puis on créer un nouvel organisateur
            if (IdentifiantValide(textBoxLogin.Text) == false)
            {
                return;
            }
            if (MdpValide(textBoxMotDePasse.Text) == false)
            {
                return;
            }

            // On créé l'organisateur en bdd
            _serviceOrganisateur.Creer(_unNouveauOrganisateur);
            ChargerOrganisateurs();
            Raz_Zones();
        }

        private void buttonModifier_Click(object sender, EventArgs e)
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

            // Modifiée seulement les valeurs qui ont été modifiées
            if (textBoxLogin.Text != "" || _organisateurSelectionne.Login != textBoxLogin.Text)
                _organisateurSelectionne.Login = textBoxLogin.Text;
            if (textBoxMail.Text != "" || _organisateurSelectionne.Mail != textBoxMail.Text)
                _organisateurSelectionne.Mail = textBoxMail.Text;
            if (textBoxMotDePasse.Text != "" || _organisateurSelectionne.motPasse != textBoxMotDePasse.Text)
                _organisateurSelectionne.motPasse = BCrypt.Net.BCrypt.HashPassword(textBoxMotDePasse.Text); // on oublie pas de hashé
            if ((int)comboBoxRole.SelectedValue != _organisateurSelectionne.IdRole)
                _organisateurSelectionne.IdRole = (int)comboBoxRole.SelectedValue;

            _serviceOrganisateur.Modifier(_organisateurSelectionne);
            ChargerOrganisateurs();
            Raz_Zones();
        }

        private void buttonSupprimer_Click(object sender, EventArgs e)
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
            _serviceOrganisateur.Supprimer(_organisateurSelectionne.Login);
            ChargerOrganisateurs();
            Raz_Zones();
        }

        private void buttonEffacer_Click(object sender, EventArgs e)
        {
            Raz_Zones();
        }

        private void dataGridOrganisateurs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // On récupére l'organisateur cliqué et on appelle RemplirFormulaire(...)
            if (e.RowIndex < 0)
                return;

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
        private void textBoxRecherche_TextChanged(object sender, EventArgs e)
        {
            filtre = textBoxRecherche.Text;
            ChargerOrganisateurs();

        }

        #endregion
    }
}