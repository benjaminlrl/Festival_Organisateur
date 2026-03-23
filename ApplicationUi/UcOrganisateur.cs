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

namespace ApplicationUi
{
    public partial class UcOrganisateur : UserControl
    {
        private readonly IOrganisateurService _serviceOrganisateur;
        private readonly IRoleService _serviceRole;
        private Organisateur? _organisateurSelectionne = null;
        private readonly Organisateur _organisateurConnecte;

        public UcOrganisateur(Organisateur unOrganisateurConnecte)
        {
            InitializeComponent();
            _serviceOrganisateur = new OrganisateurService(new ApplicationDbContext());
            _serviceRole = new RoleService(new ApplicationDbContext());
            _organisateurConnecte = unOrganisateurConnecte;
            ChargerOrganisateurs();
            ChargerRoles();
            buttonModifier.Enabled = _organisateurSelectionne != null;
            buttonSupprimer.Enabled = _organisateurSelectionne != null;
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcOrganisateur, "Modifier") != "true")
            {
                buttonModifier.Visible = false;
            }
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcOrganisateur, "Supprimer") != "true")
            {
                buttonSupprimer.Visible = false;
            }
        }

        #region Chargement

        private void ChargerOrganisateurs()
        {
            // On charge la liste des organisateurs dans le dataGrid (sans les logins contenant admin)
            dataGridOrganisateurs.DataSource = null;
            var listeOrganisateur = _serviceOrganisateur.Lister()
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
            comboBoxRole.DataSource = _serviceRole.Lister();
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

        #region Evènements

        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            // On check si l'identifiant & le mot de passe sont valides, puis on créer un nouvel organisateur
            if (Validations.IdentifiantValide(textBoxLogin.Text) == false)
            {
                labelError.Text = "Le login doit contenir entre 3 et 12 caractères.";
                return;
            }
            if (Validations.MdpValide(textBoxMotDePasse.Text) != "true")
                labelError.Text = Validations.MdpValide(textBoxMotDePasse.Text);

            _serviceOrganisateur.Creer(new Organisateur
            {
                Login = textBoxLogin.Text,
                Mail = textBoxMail.Text,
                motPasse = textBoxMotDePasse.Text,
                IdRole = (int)comboBoxRole.SelectedValue
            });
            ChargerOrganisateurs();
            Raz_Zones();
        }

        private void buttonModifier_Click(object sender, EventArgs e)
        {
            // On check si l'identifiant & le mot de passe sont valides, puis on modifie l'organisateur selectionné
            if (Validations.IdentifiantValide(textBoxLogin.Text) == false)
            {
                labelError.Text = "Le login doit contenir entre 3 et 12 caractères.";
                return;
            }
            if(textBoxMotDePasse.Text != "")
                if (Validations.MdpValide(textBoxMotDePasse.Text) != "true")
                    labelError.Text = Validations.MdpValide(textBoxMotDePasse.Text);

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
            // On check si un orgnisateur est sélectionné, puis on le supprime
            //Ne pas pouvoir suppr l'organisateur connecté
            //Ne pas pouvoir suppr "admin"
            if (_organisateurSelectionne == null)
            {
                labelError.Text = "Aucun organisateur sélectionné.";
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

        #endregion
    }
}