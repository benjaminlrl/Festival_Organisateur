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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
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
            panelMenu.Margin = new Padding(4, 5, 4, 5);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(286, 1227);
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
            btnPlateformes.Location = new Point(0, 82);
            btnPlateformes.Margin = new Padding(0, 82, 0, 8);
            btnPlateformes.Name = "btnPlateformes";
            btnPlateformes.Size = new Size(286, 82);
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
            btnPostes.Location = new Point(0, 184);
            btnPostes.Margin = new Padding(0, 12, 0, 8);
            btnPostes.Name = "btnPostes";
            btnPostes.Size = new Size(299, 83);
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
            btnEspaces.Image = (System.Drawing.Image)resources.GetObject("btnEspaces.Image");
            btnEspaces.ImageAlign = ContentAlignment.MiddleLeft;
            btnEspaces.Location = new Point(0, 287);
            btnEspaces.Margin = new Padding(0, 12, 0, 8);
            btnEspaces.Name = "btnEspaces";
            btnEspaces.Size = new Size(286, 82);
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
            btnTournois.Image = (System.Drawing.Image)resources.GetObject("btnTournois.Image");
            btnTournois.ImageAlign = ContentAlignment.MiddleLeft;
            btnTournois.Location = new Point(0, 389);
            btnTournois.Margin = new Padding(0, 12, 0, 8);
            btnTournois.Name = "btnTournois";
            btnTournois.Size = new Size(286, 82);
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
            buttonJeux.Image = Properties.Resources.espaces;
            buttonJeux.ImageAlign = ContentAlignment.MiddleLeft;
            buttonJeux.Location = new Point(0, 491);
            buttonJeux.Margin = new Padding(0, 12, 0, 8);
            buttonJeux.Name = "buttonJeux";
            buttonJeux.Size = new Size(286, 82);
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
            btnOrganisateurs.Image = Properties.Resources.tournoi;
            btnOrganisateurs.ImageAlign = ContentAlignment.MiddleLeft;
            btnOrganisateurs.Location = new Point(0, 593);
            btnOrganisateurs.Margin = new Padding(0, 12, 0, 8);
            btnOrganisateurs.Name = "btnOrganisateurs";
            btnOrganisateurs.Size = new Size(286, 82);
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
            btnLots.Image = Properties.Resources.tournoi;
            btnLots.ImageAlign = ContentAlignment.MiddleLeft;
            btnLots.Location = new Point(0, 695);
            btnLots.Margin = new Padding(0, 12, 0, 8);
            btnLots.Name = "btnLots";
            btnLots.Size = new Size(286, 82);
            btnLots.TabIndex = 6;
            btnLots.Text = "Lots";
            btnLots.UseVisualStyleBackColor = false;
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
            btnLotComposants.Image = Properties.Resources.tournoi;
            btnLotComposants.ImageAlign = ContentAlignment.MiddleLeft;
            btnLotComposants.Location = new Point(0, 797);
            btnLotComposants.Margin = new Padding(0, 12, 0, 5);
            btnLotComposants.Name = "btnLotComposants";
            btnLotComposants.Size = new Size(290, 113);
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
            btnVoter.Image = (System.Drawing.Image)resources.GetObject("btnVoter.Image");
            btnVoter.ImageAlign = ContentAlignment.MiddleLeft;
            btnVoter.Location = new Point(0, 927);
            btnVoter.Margin = new Padding(0, 12, 0, 8);
            btnVoter.Name = "btnVoter";
            btnVoter.Size = new Size(286, 82);
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
            btnParticiper.Image = (System.Drawing.Image)resources.GetObject("btnParticiper.Image");
            btnParticiper.ImageAlign = ContentAlignment.MiddleLeft;
            btnParticiper.Location = new Point(0, 1029);
            btnParticiper.Margin = new Padding(0, 12, 0, 8);
            btnParticiper.Name = "btnParticiper";
            btnParticiper.Size = new Size(286, 82);
            btnParticiper.TabIndex = 9;
            btnParticiper.Text = "Participations";
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
            BtnDeconnexion.Location = new Point(4, 1124);
            BtnDeconnexion.Margin = new Padding(4, 5, 4, 5);
            BtnDeconnexion.Name = "BtnDeconnexion";
            BtnDeconnexion.Size = new Size(281, 82);
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
            BtnQuitter.Location = new Point(4, 1216);
            BtnQuitter.Margin = new Padding(4, 5, 4, 5);
            BtnQuitter.Name = "BtnQuitter";
            BtnQuitter.Size = new Size(281, 82);
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
            panelHeader.Location = new Point(286, 0);
            panelHeader.Margin = new Padding(4, 5, 4, 5);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1245, 82);
            panelHeader.TabIndex = 1;
            // 
            // lblTitre
            // 
            lblTitre.AutoSize = true;
            lblTitre.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitre.Location = new Point(29, 20);
            lblTitre.Margin = new Padding(4, 0, 4, 0);
            lblTitre.Name = "lblTitre";
            lblTitre.Size = new Size(401, 38);
            lblTitre.TabIndex = 0;
            lblTitre.Text = "Espace de Gestion du Festival";
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.FromArgb(245, 246, 248);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(286, 82);
            panelContent.Margin = new Padding(4, 5, 4, 5);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1245, 1145);
            panelContent.TabIndex = 0;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 248);
            ClientSize = new Size(1531, 1227);
            ControlBox = false;
            Controls.Add(panelContent);
            Controls.Add(panelHeader);
            Controls.Add(panelMenu);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "FormMain";
            Text = "Back-office organisateur";
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
