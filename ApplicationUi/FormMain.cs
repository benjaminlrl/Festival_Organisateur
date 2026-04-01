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
    public partial class FormMain : Form
    {
        private readonly IOrganisateurService _serviceOrganisateur;
        private readonly Organisateur _organisateurConnecte;
        public FormMain(Organisateur unOrganisateurConnecte)
        {

            InitializeComponent();
            _serviceOrganisateur = new OrganisateurService(new ApplicationDbContext());
            _organisateurConnecte = unOrganisateurConnecte;
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcTournois, "Consulter") == false)
            {
                btnTournois.Visible = false;
            }
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcOrganisateurs, "Consulter") == false)
            {
                btnOrganisateurs.Visible = false;
            }
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcEspaces, "Consulter") == false)
            {
                btnEspaces.Visible = false;
            }
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcPlateformes, "Consulter") == false)
            {
                btnPlateformes.Visible = false;
            }
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcPostesDeJeu, "Consulter") == false)
            {
                btnPostes.Visible = false;
            }
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcLotComposants, "Consulter") == false)
            {
                btnLotComposants.Visible = false;
            }
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcLots, "Consulter") == false)
            {
                btnLots.Visible = false;
            }
        }


        // ===============================
        // Navigation UserControls
        // ===============================
        private void LoadUserControl(UserControl control, string titre)
        {
            panelContent.SuspendLayout();

            // Nettoyage propre
            foreach (Control c in panelContent.Controls)
                c.Dispose();

            panelContent.Controls.Clear();

            // Chargement
            control.Dock = DockStyle.Fill;
            panelContent.Controls.Add(control);

            // Mise à jour du titre
            lblTitre.Text = titre;

            panelContent.ResumeLayout();
        }

        // ===============================
        // Actions Associées au Menu
        // ===============================
        private void btnQuitter_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnTournois_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UcTournois(_organisateurConnecte), "Gestion des tournois");
        }

        private void btnEspaces_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UcEspaces(_organisateurConnecte), "Gestion des espaces");
        }

        private void btnPostes_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UcPostesDeJeu(_organisateurConnecte), "Gestion des postes de jeu");
        }

        private void btnPlateformes_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UcPlateformes(_organisateurConnecte), "Gestion des plateformes");
        }

        private void btnOrganisateurs_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UcOrganisateurs(_organisateurConnecte), "Gestion des Organisateurs");
        }

        private void btnLotComposants_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UcLotComposants(_organisateurConnecte), "Gestion des Lots Composants");
        }
        private void btnLots_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UcLots(_organisateurConnecte), "Gestion des Lots");
        }

        private void buttonJeux_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UcJeux(_organisateurConnecte), "Gestion des jeux");
        }

        private void buttonVoter_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UcVoter(_organisateurConnecte), "Voter pour 3 jeux");
        }
    }
}
