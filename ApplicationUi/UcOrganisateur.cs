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

        public UcOrganisateur()
        {
            InitializeComponent();
            _serviceOrganisateur = new OrganisateurService(new ApplicationDbContext());
            _serviceRole = new RoleService(new ApplicationDbContext());
            ChargerOrganisateurs();
            ChargerRoles();
            buttonModifier.Enabled = _organisateurSelectionne != null;
            buttonSupprimer.Enabled = _organisateurSelectionne != null;
        }

        #region Chargement

        private void ChargerOrganisateurs()
        {
            // On charge la liste des organisateurs dans le dataGrid
            dataGridOrganisateurs.DataSource = null;
            dataGridOrganisateurs.DataSource = _serviceOrganisateur.Lister();
            MEP_DataGrid();
        }

        private void MEP_DataGrid()
        {
            // On affiche et modifie l'affichage des colonnes du dataGrid
            dataGridOrganisateurs.Columns["IdRole"].Visible = false;
            dataGridOrganisateurs.Columns["Login"].DisplayIndex = 0;
            dataGridOrganisateurs.Columns["Mail"].DisplayIndex = 1;
            dataGridOrganisateurs.Columns["motPasse"].DisplayIndex = 2;
            dataGridOrganisateurs.Columns["motPasse"].HeaderText = "Mot de passe";
            dataGridOrganisateurs.Columns["Role"].Visible = false;
            dataGridOrganisateurs.Columns["NomRole"].HeaderText = "Rôle";

            // Code garder si on veut cacher le hashage du mot de passe dans le dataGrid
            //foreach (DataGridViewRow row in dataGridOrganisateurs.Rows)
            //{
            //    row.Cells["motPasse"].Value = "••••••••";
            //}
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
            // On remettre tous les champs à vide
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
            // TODO : valider les champs puis appeler _serviceOrganisateur.Creer(...)
        }

        private void buttonModifier_Click(object sender, EventArgs e)
        {
            // TODO : valider les champs puis appeler _serviceOrganisateur.Modifier(...)
        }

        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            // TODO : appeler _serviceOrganisateur.Supprimer(_organisateurSelectionne.Login)
        }

        private void buttonEffacer_Click(object sender, EventArgs e)
        {
            Raz_Zones();
        }

        private void dataGridOrganisateurs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // On récupére l'organisateur cliqué et appeler RemplirFormulaire(...)
            if (e.RowIndex < 0)
                return;

            _organisateurSelectionne = dataGridOrganisateurs.Rows[e.RowIndex].DataBoundItem as Organisateur;

            if (_organisateurSelectionne != null)
                RemplirFormulaire(_organisateurSelectionne);

            buttonModifier.Enabled = _organisateurSelectionne != null;
            buttonSupprimer.Enabled = _organisateurSelectionne != null;
        }

        #endregion

        #region Validations

        public static bool MdpValide(string motDePasse)
        {
            if (motDePasse.Length < 12)
                return false;
            if (motDePasse.Any(char.IsUpper) == false)
                return false;
            if (motDePasse.Any(char.IsDigit) == false)
                return false;
            if (motDePasse.Any(ch => !char.IsLetterOrDigit(ch)) == false)
                return false;
            return true;
        }

        public static bool IdentifiantValide(string identifiant)
        {
            if (identifiant.Length < 3 || identifiant.Length > 12)
                return false;
            return true;
        }

        #endregion
    }
}