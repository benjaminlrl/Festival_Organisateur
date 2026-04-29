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
                btnTournois.Visible = false;

            if (_serviceOrganisateur.EstAutoriser(_organisateurConnecte, Organisateur.LesUC.UcOrganisateurs, "Consulter") == false)
                btnOrganisateurs.Visible = false;

            if (_serviceOrganisateur.EstAutoriser(_organisateurConnecte, Organisateur.LesUC.UcEspaces, "Consulter") == false)
                btnEspaces.Visible = false;

            if (_serviceOrganisateur.EstAutoriser(_organisateurConnecte, Organisateur.LesUC.UcPlateformes, "Consulter") == false)
                btnPlateformes.Visible = false;

            if (_serviceOrganisateur.EstAutoriser(_organisateurConnecte, Organisateur.LesUC.UcPostesDeJeu, "Consulter") == false)
                btnPostes.Visible = false;

            if (_serviceOrganisateur.EstAutoriser(_organisateurConnecte, Organisateur.LesUC.UcLotComposants, "Consulter") == false)
                btnLotComposants.Visible = false;

            if (_serviceOrganisateur.EstAutoriser(_organisateurConnecte, Organisateur.LesUC.UcLots, "Consulter") == false)
                btnLots.Visible = false;

            if (_serviceOrganisateur.EstAutoriser(_organisateurConnecte, Organisateur.LesUC.UcJeuxSoumisVote, "Consulter") == false)
                btnVoter.Visible = false;

            if (_serviceOrganisateur.EstAutoriser(_organisateurConnecte, Organisateur.LesUC.UcParticiper, "Consulter") == false)
                btnParticiper.Visible = false;
        }

        // ===============================
        // Navigation UserControls
        // ===============================
        private void LoadUserControl(UserControl control, string titre)
        {
            panelContent.SuspendLayout();

            foreach (Control c in panelContent.Controls)
                c.Dispose();

            panelContent.Controls.Clear();

            control.Dock = DockStyle.Fill;
            panelContent.Controls.Add(control);

            lblTitre.Text = titre;

            panelContent.ResumeLayout();
        }

        // ===============================
        // Méthodes Helper de Navigation
        // ===============================

        private void ChargerUcTournois(Tournoi? tournoi = null)
        {
            UcTournois uc = new(_organisateurConnecte, tournoi);
            uc.NaviguerVersEspaces += (espace) => ChargerUcEspaces(espace);
            uc.NaviguerVersJeux += (jeu) => ChargerUcJeux(jeu);
            LoadUserControl(uc, "Gestion des tournois");
        }

        private void ChargerUcEspaces(Espace? espace = null)
        {
            UcEspaces uc = new(_organisateurConnecte, espace);
            uc.NaviguerVersPostesJeu += (posteJeu) => ChargerUcPostesDeJeu(posteJeu);
            uc.NaviguerVersTournois += (tournoi) => ChargerUcTournois(tournoi);
            LoadUserControl(uc, "Gestion des espaces");
        }

        private void ChargerUcPostesDeJeu(PosteJeu? posteJeu = null)
        {
            UcPostesDeJeu uc = new(_organisateurConnecte, posteJeu);
            uc.NaviguerVersTournois += (tournoi) => ChargerUcTournois(tournoi);
            uc.NaviguerVersEspaces += (espace) => ChargerUcEspaces(espace);
            uc.NaviguerVersPlateformes += (plateforme) => ChargerUcPlateformes(plateforme);
            LoadUserControl(uc, "Gestion des postes de jeu");
        }

        private void ChargerUcPlateformes(Plateforme? plateforme = null)
        {
            UcPlateformes uc = new(_organisateurConnecte, plateforme);
            uc.NaviguerVersPostesJeu += (posteJeu) => ChargerUcPostesDeJeu(posteJeu);
            uc.NaviguerVersJeux += (jeu) => ChargerUcJeux(jeu);
            LoadUserControl(uc, "Gestion des plateformes");
        }

        private void ChargerUcJeux(Jeu? jeu = null)
        {
            UcJeux uc = new(_organisateurConnecte, jeu);
            LoadUserControl(uc, "Gestion des jeux");
        }

        private void ChargerUcJeuxSoumisVote()
        {
            UcJeuxSoumisVote uc = new(_organisateurConnecte);
            uc.NaviguerVersJeux += (jeu) => ChargerUcJeux(jeu);
            uc.NaviguerVersPlateformes += (plateforme) => ChargerUcPlateformes(plateforme);
            LoadUserControl(uc, "Gestion des jeux ouverts aux votes");
        }

        private void ChargerUcParticiper()
        {
            UcParticiper uc = new(_organisateurConnecte);
            uc.NaviguerVersTournois += (tournoi) => ChargerUcTournois(tournoi);
            LoadUserControl(uc, "Gestion des participations");
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
            try { ChargerUcTournois(); }
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
            try { ChargerUcEspaces(); }
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
            try { ChargerUcPostesDeJeu(); }
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
            try { ChargerUcPlateformes(); }
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
            try { ChargerUcJeux(); }
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
            try { ChargerUcJeuxSoumisVote(); }
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
            try { ChargerUcParticiper(); }
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