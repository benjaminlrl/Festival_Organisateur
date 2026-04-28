using ApplicationUi.Properties;
using System.Resources;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Font = System.Drawing.Font;

namespace ApplicationUi
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelMenu = new FlowLayoutPanel();
            btnPlateformes = new Button();
            btnPostes = new Button();
            btnEspaces = new Button();
            btnTournois = new Button();
            buttonJeux = new Button();
            btnOrganisateurs = new Button();
            btnLots = new Button();
            btnLotComposants = new Button();
            btnVoter = new Button();
            btnParticiper = new Button();
            BtnDeconnexion = new Button();
            BtnQuitter = new Button();
            panelHeader = new Panel();
            lblTitre = new Label();
            panelContent = new Panel();
            panelMenu.SuspendLayout();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(63, 81, 181);
            panelMenu.Controls.Add(btnPlateformes);
            panelMenu.Controls.Add(btnPostes);
            panelMenu.Controls.Add(btnEspaces);
            panelMenu.Controls.Add(btnTournois);
            panelMenu.Controls.Add(buttonJeux);
            panelMenu.Controls.Add(btnOrganisateurs);
            panelMenu.Controls.Add(btnLots);
            panelMenu.Controls.Add(btnLotComposants);
            panelMenu.Controls.Add(btnVoter);
            panelMenu.Controls.Add(btnParticiper);
            panelMenu.Controls.Add(BtnDeconnexion);
            panelMenu.Controls.Add(BtnQuitter);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.FlowDirection = FlowDirection.TopDown;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(200, 661);
            panelMenu.TabIndex = 2;
            panelMenu.WrapContents = false;
            // 
            // btnPlateformes
            // 
            btnPlateformes.BackColor = Color.FromArgb(156, 39, 176);
            btnPlateformes.FlatAppearance.BorderSize = 0;
            btnPlateformes.FlatStyle = FlatStyle.Flat;
            btnPlateformes.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnPlateformes.ForeColor = Color.White;
            btnPlateformes.Image = Properties.Resources.plateforme;
            btnPlateformes.ImageAlign = ContentAlignment.MiddleLeft;
            btnPlateformes.Location = new Point(0, 49);
            btnPlateformes.Margin = new Padding(0, 49, 0, 5);
            btnPlateformes.Name = "btnPlateformes";
            btnPlateformes.Size = new Size(200, 49);
            btnPlateformes.TabIndex = 0;
            btnPlateformes.Text = "      Plateformes";
            btnPlateformes.UseVisualStyleBackColor = false;
            btnPlateformes.Click += BtnPlateformes_Click;
            // 
            // btnPostes
            // 
            btnPostes.BackColor = Color.FromArgb(255, 193, 7);
            btnPostes.FlatAppearance.BorderSize = 0;
            btnPostes.FlatStyle = FlatStyle.Flat;
            btnPostes.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnPostes.ForeColor = Color.White;
            btnPostes.Image = Properties.Resources.postes;
            btnPostes.ImageAlign = ContentAlignment.MiddleLeft;
            btnPostes.Location = new Point(0, 110);
            btnPostes.Margin = new Padding(0, 7, 0, 5);
            btnPostes.Name = "btnPostes";
            btnPostes.Size = new Size(209, 50);
            btnPostes.TabIndex = 1;
            btnPostes.Text = "       Postes de jeu";
            btnPostes.UseVisualStyleBackColor = false;
            btnPostes.Click += BtnPostes_Click;
            // 
            // btnEspaces
            // 
            btnEspaces.BackColor = Color.FromArgb(33, 150, 243);
            btnEspaces.FlatAppearance.BorderSize = 0;
            btnEspaces.FlatStyle = FlatStyle.Flat;
            btnEspaces.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnEspaces.ForeColor = Color.White;
            btnEspaces.Image = Properties.Resources.espaces;
            btnEspaces.ImageAlign = ContentAlignment.MiddleLeft;
            btnEspaces.Location = new Point(0, 172);
            btnEspaces.Margin = new Padding(0, 7, 0, 5);
            btnEspaces.Name = "btnEspaces";
            btnEspaces.Size = new Size(200, 49);
            btnEspaces.TabIndex = 2;
            btnEspaces.Text = "Espaces";
            btnEspaces.UseVisualStyleBackColor = false;
            btnEspaces.Click += BtnEspaces_Click;
            // 
            // btnTournois
            // 
            btnTournois.BackColor = Color.FromArgb(76, 175, 80);
            btnTournois.BackgroundImageLayout = ImageLayout.None;
            btnTournois.FlatAppearance.BorderSize = 0;
            btnTournois.FlatStyle = FlatStyle.Flat;
            btnTournois.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnTournois.ForeColor = Color.White;
            btnTournois.Image = Properties.Resources.tournoi;
            btnTournois.ImageAlign = ContentAlignment.MiddleLeft;
            btnTournois.Location = new Point(0, 233);
            btnTournois.Margin = new Padding(0, 7, 0, 5);
            btnTournois.Name = "btnTournois";
            btnTournois.Size = new Size(200, 49);
            btnTournois.TabIndex = 3;
            btnTournois.Text = "Tournois";
            btnTournois.UseVisualStyleBackColor = false;
            btnTournois.Click += BtnTournois_Click;
            // 
            // buttonJeux
            // 
            buttonJeux.BackColor = Color.FromArgb(255, 128, 0);
            buttonJeux.BackgroundImageLayout = ImageLayout.None;
            buttonJeux.FlatAppearance.BorderSize = 0;
            buttonJeux.FlatStyle = FlatStyle.Flat;
            buttonJeux.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            buttonJeux.ForeColor = Color.White;
            buttonJeux.Image = Properties.Resources.jeux;
            buttonJeux.ImageAlign = ContentAlignment.MiddleLeft;
            buttonJeux.Location = new Point(0, 294);
            buttonJeux.Margin = new Padding(0, 7, 0, 5);
            buttonJeux.Name = "buttonJeux";
            buttonJeux.Size = new Size(200, 49);
            buttonJeux.TabIndex = 4;
            buttonJeux.Text = "Jeux";
            buttonJeux.UseVisualStyleBackColor = false;
            buttonJeux.Click += BtnJeux_Click;
            // 
            // btnOrganisateurs
            // 
            btnOrganisateurs.BackColor = Color.DarkSalmon;
            btnOrganisateurs.BackgroundImageLayout = ImageLayout.None;
            btnOrganisateurs.FlatAppearance.BorderSize = 0;
            btnOrganisateurs.FlatStyle = FlatStyle.Flat;
            btnOrganisateurs.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnOrganisateurs.ForeColor = Color.White;
            btnOrganisateurs.Image = Properties.Resources.organisateur;
            btnOrganisateurs.ImageAlign = ContentAlignment.MiddleLeft;
            btnOrganisateurs.Location = new Point(0, 355);
            btnOrganisateurs.Margin = new Padding(0, 7, 0, 5);
            btnOrganisateurs.Name = "btnOrganisateurs";
            btnOrganisateurs.Size = new Size(200, 49);
            btnOrganisateurs.TabIndex = 5;
            btnOrganisateurs.Text = "      Organisateurs";
            btnOrganisateurs.UseVisualStyleBackColor = false;
            btnOrganisateurs.Click += BtnOrganisateurs_Click;
            // 
            // btnLots
            // 
            btnLots.BackColor = Color.MediumSlateBlue;
            btnLots.BackgroundImageLayout = ImageLayout.None;
            btnLots.FlatAppearance.BorderSize = 0;
            btnLots.FlatStyle = FlatStyle.Flat;
            btnLots.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnLots.ForeColor = Color.White;
            btnLots.Image = Properties.Resources.lots;
            btnLots.ImageAlign = ContentAlignment.MiddleLeft;
            btnLots.Location = new Point(0, 416);
            btnLots.Margin = new Padding(0, 7, 0, 5);
            btnLots.Name = "btnLots";
            btnLots.Size = new Size(200, 49);
            btnLots.TabIndex = 6;
            btnLots.Text = "Lots";
            btnLots.UseVisualStyleBackColor = true;
            btnLots.Click += BtnLots_Click;
            // 
            // btnLotComposants
            // 
            btnLotComposants.BackColor = Color.CornflowerBlue;
            btnLotComposants.BackgroundImageLayout = ImageLayout.None;
            btnLotComposants.FlatAppearance.BorderSize = 0;
            btnLotComposants.FlatStyle = FlatStyle.Flat;
            btnLotComposants.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnLotComposants.ForeColor = Color.White;
            btnLotComposants.Image = Properties.Resources.lotcomposant;
            btnLotComposants.ImageAlign = ContentAlignment.MiddleLeft;
            btnLotComposants.Location = new Point(0, 477);
            btnLotComposants.Margin = new Padding(0, 7, 0, 3);
            btnLotComposants.Name = "btnLotComposants";
            btnLotComposants.Size = new Size(203, 68);
            btnLotComposants.TabIndex = 7;
            btnLotComposants.Text = "      Composant des lots";
            btnLotComposants.UseVisualStyleBackColor = false;
            btnLotComposants.Click += BtnLotComposants_Click;
            // 
            // btnVoter
            // 
            btnVoter.BackColor = Color.FromArgb(0, 192, 0);
            btnVoter.BackgroundImageLayout = ImageLayout.None;
            btnVoter.FlatAppearance.BorderSize = 0;
            btnVoter.FlatStyle = FlatStyle.Flat;
            btnVoter.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnVoter.ForeColor = Color.White;
            btnVoter.Image = Properties.Resources.vote;
            btnVoter.ImageAlign = ContentAlignment.MiddleLeft;
            btnVoter.Location = new Point(0, 555);
            btnVoter.Margin = new Padding(0, 7, 0, 5);
            btnVoter.Name = "btnVoter";
            btnVoter.Size = new Size(200, 49);
            btnVoter.TabIndex = 8;
            btnVoter.Text = "Votes";
            btnVoter.UseVisualStyleBackColor = false;
            btnVoter.Click += BtnVoter_Click;
            // 
            // btnParticiper
            // 
            btnParticiper.BackColor = Color.YellowGreen;
            btnParticiper.BackgroundImageLayout = ImageLayout.None;
            btnParticiper.FlatAppearance.BorderSize = 0;
            btnParticiper.FlatStyle = FlatStyle.Flat;
            btnParticiper.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnParticiper.ForeColor = Color.White;
            btnParticiper.Image = Properties.Resources.participer;
            btnParticiper.ImageAlign = ContentAlignment.MiddleLeft;
            btnParticiper.Location = new Point(0, 616);
            btnParticiper.Margin = new Padding(0, 7, 0, 5);
            btnParticiper.Name = "btnParticiper";
            btnParticiper.Size = new Size(200, 49);
            btnParticiper.TabIndex = 9;
            btnParticiper.Text = "      Participations";
            btnParticiper.UseVisualStyleBackColor = false;
            btnParticiper.Click += BtnParticiper_Click;
            // 
            // BtnDeconnexion
            // 
            BtnDeconnexion.BackColor = Color.Gray;
            BtnDeconnexion.FlatAppearance.BorderSize = 0;
            BtnDeconnexion.FlatStyle = FlatStyle.Flat;
            BtnDeconnexion.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            BtnDeconnexion.ForeColor = Color.White;
            BtnDeconnexion.Image = Properties.Resources.deconnecter;
            BtnDeconnexion.ImageAlign = ContentAlignment.MiddleLeft;
            BtnDeconnexion.Location = new Point(3, 673);
            BtnDeconnexion.Name = "BtnDeconnexion";
            BtnDeconnexion.Size = new Size(197, 49);
            BtnDeconnexion.TabIndex = 10;
            BtnDeconnexion.Text = "     Déconnexion";
            BtnDeconnexion.UseVisualStyleBackColor = false;
            BtnDeconnexion.Click += BtnDeconnexion_Click;
            // 
            // BtnQuitter
            // 
            BtnQuitter.BackColor = Color.FromArgb(60, 60, 60);
            BtnQuitter.FlatAppearance.BorderSize = 0;
            BtnQuitter.FlatStyle = FlatStyle.Flat;
            BtnQuitter.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            BtnQuitter.ForeColor = Color.White;
            BtnQuitter.Image = Properties.Resources.deconnecter;
            BtnQuitter.ImageAlign = ContentAlignment.MiddleLeft;
            BtnQuitter.Location = new Point(3, 728);
            BtnQuitter.Name = "BtnQuitter";
            BtnQuitter.Size = new Size(197, 49);
            BtnQuitter.TabIndex = 11;
            BtnQuitter.Text = " Quitter";
            BtnQuitter.UseVisualStyleBackColor = false;
            BtnQuitter.Click += BtnQuitter_Click;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(63, 81, 181);
            panelHeader.Controls.Add(lblTitre);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            panelHeader.ForeColor = SystemColors.ControlLightLight;
            panelHeader.Location = new Point(200, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(872, 49);
            panelHeader.TabIndex = 1;
            // 
            // lblTitre
            // 
            lblTitre.AutoSize = true;
            lblTitre.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitre.Location = new Point(20, 12);
            lblTitre.Name = "lblTitre";
            lblTitre.Size = new Size(270, 25);
            lblTitre.TabIndex = 0;
            lblTitre.Text = "Espace de Gestion du Festival";
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.FromArgb(245, 246, 248);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(200, 49);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(872, 612);
            panelContent.TabIndex = 0;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 248);
            ClientSize = new Size(1072, 661);
            ControlBox = false;
            Controls.Add(panelContent);
            Controls.Add(panelHeader);
            Controls.Add(panelMenu);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormMain";
            Text = "Application de Festival Organisateur";
            WindowState = FormWindowState.Maximized;
            panelMenu.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel panelMenu;
        private Button btnTournois;
        private Button btnEspaces;
        private Button btnPostes;
        private Button btnPlateformes;
        private Button BtnDeconnexion ;
        private Panel panelHeader;
        private Label lblTitre;

        private Panel panelContent;
        private Button btnOrganisateurs;
        private Button btnLotComposants;
        private Button buttonJeux;
        private Button btnLots;
        private Button btnVoter;
        private Button btnParticiper;
        private Button BtnQuitter;
    }
}
