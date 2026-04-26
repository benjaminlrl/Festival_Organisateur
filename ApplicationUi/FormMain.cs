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
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcVoter, "Consulter") == false)
            {
                btnVoter.Visible = false;
            }
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcParticiper, "Consulter") == false)
            {
                btnParticiper.Visible = false;
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
        private void BtnQuitter_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }
        private void BtnTournois_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UcTournois(_organisateurConnecte), "Gestion des tournois");
        }

        private void BtnEspaces_Click(object sender, EventArgs e)
        {
            UcEspaces uc = new (_organisateurConnecte);

            uc.NaviguerVersPostesJeu += (posteJeu) =>
            {
                // Récupère le premier poste de jeu de la plateforme 
                LoadUserControl(new UcPostesDeJeu(_organisateurConnecte, posteJeu), "Gestion des postes de jeu");
            };

            uc.NaviguerVersTournois += (tournoi) =>
            {
                // Récupère le premier tournoi de l'espace 
                LoadUserControl(new UcTournois(_organisateurConnecte, tournoi), "Gestion des tournois");
            };

            LoadUserControl(uc, "Gestion des espaces");
        }

        private void BtnPostes_Click(object sender, EventArgs e)
        {
            UcPostesDeJeu uc = new (_organisateurConnecte);

            uc.NaviguerVersTournois += (tournoi) =>
            {
                // Récupère le premier poste de jeu de la plateforme 
                LoadUserControl(new UcTournois(_organisateurConnecte, tournoi), "Gestion des tournois");
            };

            LoadUserControl(uc, "Gestion des postes de jeu");
        }

        private void BtnPlateformes_Click(object sender, EventArgs e)
        {
            var uc = new UcPlateformes(_organisateurConnecte);

            uc.NaviguerVersPostesJeu += (posteJeu) =>
            {
                // Récupère le premier poste de jeu de la plateforme 
                LoadUserControl(new UcPostesDeJeu(_organisateurConnecte, posteJeu), "Gestion des postes de jeu");
            };

            uc.NaviguerVersJeux += (jeu) =>
            {
                // Récupère le premier jeu de la plateforme 
                LoadUserControl(new UcJeux(_organisateurConnecte, jeu), "Gestion des jeux");
            };

            LoadUserControl(uc, "Gestion des plateformes"); 
        }

        private void BtnOrganisateurs_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UcOrganisateurs(_organisateurConnecte), "Gestion des Organisateurs");
        }

        private void BtnLotComposants_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UcLotComposants(_organisateurConnecte), "Gestion des Lots Composants");
        }
        private void BtnLots_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UcLots(_organisateurConnecte), "Gestion des Lots");
        }

        private void BtnJeux_Click(object sender, EventArgs e)
        {
            UcJeux uc = new (_organisateurConnecte);
            LoadUserControl(uc, "Gestion des jeux");
        }

        private void BtnVoter_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UcVoter(_organisateurConnecte), "Espace de votes");
        }

        private void BtnParticiper_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UcParticiper(_organisateurConnecte), "Gestion des participations");
        }
    }
}
