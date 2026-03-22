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
    public partial class FormMain : Form
    {
        private readonly IOrganisateurService _organisateurService;
        private readonly Organisateur organisateurConnecte;
        public FormMain(Organisateur organisateurConnecte)
        {
            InitializeComponent();
            _organisateurService = new OrganisateurService(new ApplicationDbContext());
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
        private void btnTournois_Click(object sender, EventArgs e)
        {

            if (_organisateurService.estAutoriser(organisateurConnecte, Organisateur.LesUC.UcTournois, "Consultation") == "true")
            {
                LoadUserControl(new UcTournois(), "Gestion des tournois");
            }
        }

        private void btnQuitter_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnOrganisateur_Click(object sender, EventArgs e)
        {
            if (_organisateurService.estAutoriser(organisateurConnecte, Organisateur.LesUC.UcOrganisateur, "Consultation") == "true")
            {
                LoadUserControl(new UcOrganisateur(), "Gestion des Organisateurs");
            }
        }
    }
}
