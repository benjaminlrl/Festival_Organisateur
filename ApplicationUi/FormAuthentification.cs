using Lib_Metier.Data.Configurations;
using Lib_Services.Interfaces;
using Lib_Services.Services;
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
        public FormAuthentification()
        {
            InitializeComponent();
            _organisateurService = new OrganisateurService(new ApplicationDbContext());
            ArrondirLesCoins(panelCard, 15);

        }

        // Boutton Connexion
        private async void btnLogin_ClickAsync(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                labelError.Text = "Veuillez remplir tous les champs.";
                await Task.Delay(5000);
                labelError.Text = "";
                return;
            }

            if (_organisateurService.EstIdentique(txtPassword.Text, txtUsername.Text.Trim()))
            {
                this.Hide();
                new FormMain().Show();
            }else
            {
                labelError.Text = "Login ou mot de passe incorrect.";
                await Task.Delay(5000);
                labelError.Text = "";
            }
        }

        // Validation par touche Entrée
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin.PerformClick();
                e.Handled = true;
            }
        }

        // Boutton Quitter
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Effet de focus sur les champs (fait par IA)
        private void txt_Enter(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            tb.BackColor = Color.FromArgb(245, 248, 250);
            tb.BorderStyle = BorderStyle.FixedSingle;
        }

        private void txt_Leave(object sender, EventArgs e)
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
    }
}
