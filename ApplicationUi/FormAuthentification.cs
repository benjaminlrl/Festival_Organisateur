using Lib_Entities.Entities;
using Lib_Metier.Data.Configurations;
using Lib_Services.Interfaces;
using Lib_Services.Services;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace ApplicationUi
{
    public partial class FormAuthentification : Form
    {
        private readonly IOrganisateurService _organisateurService;
        private Organisateur organisateurConnecte;
        public FormAuthentification()
        {
            InitializeComponent();
            _organisateurService = new OrganisateurService(new ApplicationDbContext());
            ArrondirLesCoins(panelCard, 15);
        }

        #region Chargements
        // Effet de focus sur les champs (fait par IA)
        private void textBox_Enter(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            tb.BackColor = Color.FromArgb(245, 248, 250);
            tb.BorderStyle = BorderStyle.FixedSingle;
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            tb.BackColor = Color.White;
            tb.BorderStyle = BorderStyle.FixedSingle;
        }

        // Pour arrondir les coins de l'application (fait par IA)
        private void ArrondirLesCoins(Control ctrl, int rayon)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, rayon, rayon, 180, 90);
            path.AddArc(ctrl.Width - rayon, 0, rayon, rayon, 270, 90);
            path.AddArc(ctrl.Width - rayon, ctrl.Height - rayon, rayon, rayon, 0, 90);
            path.AddArc(0, ctrl.Height - rayon, rayon, rayon, 90, 90);
            path.CloseAllFigures();
            ctrl.Region = new Region(path);
        }
        #endregion

        #region Évènements 
        private async void BoutonLogin_ClickAsync(object sender, EventArgs e)
        {
            // On check si le username n'est pas vide
            if (string.IsNullOrWhiteSpace(textBoxUsername.Text))
            {
                Log.Error("L'identifiant est vide.");
                MessageBox.Show("L'Identifiant ne peut pas être vide.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // On check si le mot de passe n'est pas vide
            if (string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                Log.Error("Le mot de passe est vide.");
                MessageBox.Show("Le Mot de Passe ne peut pas être vide.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // On check si l'identifiant & le mot de passe correspondent à un compte dans la base de données
            if (!_organisateurService.EstIdentique(textBoxPassword.Text, textBoxUsername.Text.Trim()))
            {
                Log.Error("Login ou mot de passe incorrect.");
                MessageBox.Show("Login ou mot de passe incorrect.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // On check s'il n'y a aucune erreur sur le compte récupéré
            organisateurConnecte = _organisateurService.Obtenir(textBoxUsername.Text);
            if (organisateurConnecte == null)
            {
                Log.Error("Une erreur technique est survenue lors de la récupération du compte.");
                MessageBox.Show("Erreur de récupération de votre compte.\nVeuillez contacter un administrateur.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Hide();
            new FormMain(organisateurConnecte).Show();
        }

        private void BoutonQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Validation par touche Entrée
        private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                BoutonLogin.PerformClick();
                e.Handled = true;
            }
        }

        #endregion
    }
}
