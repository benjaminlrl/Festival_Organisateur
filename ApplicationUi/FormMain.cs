using Lib_Entities.Entities;
using Lib_Metier.Data.Configurations;
using Lib_Services.Exceptions;
using Lib_Services.Interfaces;
using Lib_Services.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static Lib_Services.Exceptions.JeuSoumisVoteException;
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
            if (_serviceOrganisateur.EstAutoriser(_organisateurConnecte, Organisateur.LesUC.UcTournois, "Consulter") == false)
            {
                btnTournois.Visible = false;
            }
            if (_serviceOrganisateur.EstAutoriser(_organisateurConnecte, Organisateur.LesUC.UcOrganisateurs, "Consulter") == false)
            {
                btnOrganisateurs.Visible = false;
            }
            if (_serviceOrganisateur.EstAutoriser(_organisateurConnecte, Organisateur.LesUC.UcEspaces, "Consulter") == false)
            {
                btnEspaces.Visible = false;
            }
            if (_serviceOrganisateur.EstAutoriser(_organisateurConnecte, Organisateur.LesUC.UcPlateformes, "Consulter") == false)
            {
                btnPlateformes.Visible = false;
            }
            if (_serviceOrganisateur.EstAutoriser(_organisateurConnecte, Organisateur.LesUC.UcPostesDeJeu, "Consulter") == false)
            {
                btnPostes.Visible = false;
            }
            if (_serviceOrganisateur.EstAutoriser(_organisateurConnecte, Organisateur.LesUC.UcLotComposants, "Consulter") == false)
            {
                btnLotComposants.Visible = false;
            }
            if (_serviceOrganisateur.EstAutoriser(_organisateurConnecte, Organisateur.LesUC.UcLots, "Consulter") == false)
            {
                btnLots.Visible = false;
            }
            if (_serviceOrganisateur.EstAutoriser(_organisateurConnecte, Organisateur.LesUC.UcJeuxSoumisVote, "Consulter") == false)
            {
                btnVoter.Visible = false;
            }
            if (_serviceOrganisateur.EstAutoriser(_organisateurConnecte, Organisateur.LesUC.UcParticiper, "Consulter") == false)
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
        private void BtnDeconnexion_Click(object? sender, EventArgs e)
        {
            try
            {
                var formAuth = new FormAuthentification();
                formAuth.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erreur inattendue lors du chargement du formulaire.");
                MessageBox.Show("Une erreur inattendue est survenue.");
            }           
        }
        private void BtnQuitter_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }
        private void BtnTournois_Click(object sender, EventArgs e)
        {
            try
            {
                LoadUserControl(new UcTournois(_organisateurConnecte), "Gestion des tournois");
            }
            catch (TournoiException ex)
            {
                Log.Warning("[{Code}] {Message}", ex.CodeErreur, ex.Message);
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erreur inattendue lors du chargement du formulaire.");
                MessageBox.Show("Une erreur inattendue est survenue.");
            }
        }

        private void BtnEspaces_Click(object sender, EventArgs e)
        {            
            try
            {
                UcEspaces uc = new(_organisateurConnecte);

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
            catch (EspaceException ex)
            {
                Log.Warning("[{Code}] {Message}", ex.CodeErreur, ex.Message);
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erreur inattendue lors du chargement du formulaire.");
                MessageBox.Show("Une erreur inattendue est survenue.");
            }
        }

        private void BtnPostes_Click(object sender, EventArgs e)
        {            
            try
            {
                UcPostesDeJeu uc = new(_organisateurConnecte);

                uc.NaviguerVersTournois += (tournoi) =>
                {
                    // Récupère le premier poste de jeu de la plateforme 
                    LoadUserControl(new UcTournois(_organisateurConnecte, tournoi), "Gestion des tournois");
                };

                uc.NaviguerVersEspaces += (espace) =>
                {
                    // Récupère le premier poste de jeu de la plateforme 
                    LoadUserControl(new UcEspaces(_organisateurConnecte, espace), "Gestion des espaces");
                };

                LoadUserControl(uc, "Gestion des postes de jeu");
            }
            catch (PosteJeuException ex)
            {
                Log.Warning("[{Code}] {Message}", ex.CodeErreur, ex.Message);
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erreur inattendue lors du chargement du formulaire.");
                MessageBox.Show("Une erreur inattendue est survenue.");
            }
        }

        private void BtnPlateformes_Click(object sender, EventArgs e)
        {            
            try
            {
                UcPlateformes uc = new (_organisateurConnecte);

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
            catch (PlateformeException ex)
            {
                Log.Warning("[{Code}] {Message}", ex.CodeErreur, ex.Message);
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erreur inattendue lors du chargement du formulaire.");
                MessageBox.Show("Une erreur inattendue est survenue.");
            }
        }

        private void BtnOrganisateurs_Click(object sender, EventArgs e)
        {
            try
            {
                LoadUserControl(new UcOrganisateurs(_organisateurConnecte), "Gestion des Organisateurs");
            }
            catch (OrganisateurException ex)
            {
                Log.Warning("[{Code}] {Message}", ex.CodeErreur, ex.Message);
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erreur inattendue lors du chargement du formulaire.");
                MessageBox.Show("Une erreur inattendue est survenue.");
            }
        }

        private void BtnLotComposants_Click(object sender, EventArgs e)
        {
            try
            {
                LoadUserControl(new UcLotComposants(_organisateurConnecte), "Gestion des Lots Composants");
            }
            catch (LotComposantException ex)
            {
                Log.Warning("[{Code}] {Message}", ex.CodeErreur, ex.Message);
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erreur inattendue lors du chargement du formulaire.");
                MessageBox.Show("Une erreur inattendue est survenue.");
            }
        }
        private void BtnLots_Click(object sender, EventArgs e)
        {
            try
            {
                LoadUserControl(new UcLots(_organisateurConnecte), "Gestion des Lots");
            }
            catch (LotException ex)
            {
                Log.Warning("[{Code}] {Message}", ex.CodeErreur, ex.Message);
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erreur inattendue lors du chargement du formulaire.");
                MessageBox.Show("Une erreur inattendue est survenue.");
            }
        }

        private void BtnJeux_Click(object sender, EventArgs e)
        {           
            try
            {
                UcJeux uc = new(_organisateurConnecte);
                LoadUserControl(uc, "Gestion des jeux");
            }
            catch (JeuException ex)
            {
                Log.Warning("[{Code}] {Message}", ex.CodeErreur, ex.Message);
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erreur inattendue lors du chargement du formulaire.");
                MessageBox.Show("Une erreur inattendue est survenue.");
            }
        }

        private void BtnVoter_Click(object sender, EventArgs e)
        {            
            try
            {
                UcJeuxSoumisVote uc = new(_organisateurConnecte);

                uc.NaviguerVersJeux += (jeu) =>
                {
                    // Récupère le premier poste de jeu de la plateforme 
                    LoadUserControl(new UcJeux(_organisateurConnecte, jeu), "Gestion des jeux");
                };
                uc.NaviguerVersPlateformes += (plateforme) =>
                {
                    // Récupère le premier poste de jeu de la plateforme 
                    LoadUserControl(new UcPlateformes(_organisateurConnecte, plateforme), "Gestion des plateformes");
                };
                LoadUserControl(uc, "Gestion des jeux ouverts aux votes");
            }
            catch (JeuSoumisVoteException ex)
            {
                Log.Warning("[{Code}] {Message}", ex.CodeErreur, ex.Message);
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erreur inattendue lors du chargement du formulaire.");
                MessageBox.Show("Une erreur inattendue est survenue.");
            }
        }

        private void BtnParticiper_Click(object sender, EventArgs e)
        {
            try
            {
                LoadUserControl(new UcParticiper(_organisateurConnecte), "Gestion des participations");
            }
            catch (ParticiperException ex)
            {
                Log.Warning("[{Code}] {Message}", ex.CodeErreur, ex.Message);
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erreur inattendue lors du chargement du formulaire.");
                MessageBox.Show("Une erreur inattendue est survenue.");
            }
        }
    }
}
