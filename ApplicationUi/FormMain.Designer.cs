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
            btnQuitter = new Button();
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
            panelMenu.Controls.Add(btnQuitter);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.FlowDirection = FlowDirection.TopDown;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Margin = new Padding(3, 4, 3, 4);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(229, 881);
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
            btnPlateformes.Location = new Point(0, 65);
            btnPlateformes.Margin = new Padding(0, 65, 0, 7);
            btnPlateformes.Name = "btnPlateformes";
            btnPlateformes.Size = new Size(229, 65);
            btnPlateformes.TabIndex = 0;
            btnPlateformes.Text = "      Plateformes";
            btnPlateformes.UseVisualStyleBackColor = false;
            btnPlateformes.Click += btnPlateformes_Click;
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
            btnPostes.Location = new Point(0, 146);
            btnPostes.Margin = new Padding(0, 9, 0, 7);
            btnPostes.Name = "btnPostes";
            btnPostes.Size = new Size(239, 67);
            btnPostes.TabIndex = 1;
            btnPostes.Text = "        Postes de jeu";
            btnPostes.UseVisualStyleBackColor = false;
            btnPostes.Click += btnPostes_Click;
            // 
            // btnEspaces
            // 
            btnEspaces.BackColor = Color.FromArgb(33, 150, 243);
            btnEspaces.BackgroundImageLayout = ImageLayout.None;
            btnEspaces.FlatAppearance.BorderSize = 0;
            btnEspaces.FlatStyle = FlatStyle.Flat;
            btnEspaces.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnEspaces.ForeColor = Color.White;
            btnEspaces.Image = Properties.Resources.espace;
            btnEspaces.ImageAlign = ContentAlignment.MiddleLeft;
            btnEspaces.Location = new Point(0, 229);
            btnEspaces.Margin = new Padding(0, 9, 0, 7);
            btnEspaces.Name = "btnEspaces";
            btnEspaces.Size = new Size(229, 65);
            btnEspaces.TabIndex = 2;
            btnEspaces.Text = "Espaces";
            btnEspaces.UseVisualStyleBackColor = false;
            btnEspaces.Click += btnEspaces_Click;
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
            btnTournois.Location = new Point(0, 310);
            btnTournois.Margin = new Padding(0, 9, 0, 7);
            btnTournois.Name = "btnTournois";
            btnTournois.Size = new Size(229, 65);
            btnTournois.TabIndex = 3;
            btnTournois.Text = "Tournois";
            btnTournois.UseVisualStyleBackColor = false;
            btnTournois.Click += btnTournois_Click;
            // 
            // buttonJeux
            // 
            buttonJeux.BackColor = Color.FromArgb(255, 128, 0);
            buttonJeux.BackgroundImageLayout = ImageLayout.None;
            buttonJeux.FlatAppearance.BorderSize = 0;
            buttonJeux.FlatStyle = FlatStyle.Flat;
            buttonJeux.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            buttonJeux.ForeColor = Color.White;
            buttonJeux.Image = Properties.Resources.espace;
            buttonJeux.ImageAlign = ContentAlignment.MiddleLeft;
            buttonJeux.Location = new Point(0, 391);
            buttonJeux.Margin = new Padding(0, 9, 0, 7);
            buttonJeux.Name = "buttonJeux";
            buttonJeux.Size = new Size(229, 65);
            buttonJeux.TabIndex = 4;
            buttonJeux.Text = "Jeux";
            buttonJeux.UseVisualStyleBackColor = false;
            buttonJeux.Click += buttonJeux_Click;
            // 
            // btnOrganisateurs
            // 
            btnOrganisateurs.BackColor = Color.FromArgb(192, 0, 0);
            btnOrganisateurs.BackgroundImageLayout = ImageLayout.None;
            btnOrganisateurs.FlatAppearance.BorderSize = 0;
            btnOrganisateurs.FlatStyle = FlatStyle.Flat;
            btnOrganisateurs.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnOrganisateurs.ForeColor = Color.White;
            btnOrganisateurs.Image = Properties.Resources.tournoi;
            btnOrganisateurs.ImageAlign = ContentAlignment.MiddleLeft;
            btnOrganisateurs.Location = new Point(0, 472);
            btnOrganisateurs.Margin = new Padding(0, 9, 0, 7);
            btnOrganisateurs.Name = "btnOrganisateurs";
            btnOrganisateurs.Size = new Size(229, 65);
            btnOrganisateurs.TabIndex = 5;
            btnOrganisateurs.Text = "      Organisateurs";
            btnOrganisateurs.UseVisualStyleBackColor = false;
            btnOrganisateurs.Click += btnOrganisateurs_Click;
            // 
            // btnLots
            // 
            btnLots.BackColor = Color.FromArgb(128, 128, 255);
            btnLots.BackgroundImageLayout = ImageLayout.None;
            btnLots.FlatAppearance.BorderSize = 0;
            btnLots.FlatStyle = FlatStyle.Flat;
            btnLots.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnLots.ForeColor = Color.White;
            btnLots.Image = Properties.Resources.tournoi;
            btnLots.ImageAlign = ContentAlignment.MiddleLeft;
            btnLots.Location = new Point(0, 553);
            btnLots.Margin = new Padding(0, 9, 0, 7);
            btnLots.Name = "btnLots";
            btnLots.Size = new Size(229, 65);
            btnLots.TabIndex = 7;
            btnLots.Text = "Lots";
            btnLots.UseVisualStyleBackColor = false;
            btnLots.Click += btnLots_Click;
            // 
            // btnLotComposants
            // 
            btnLotComposants.BackColor = Color.Blue;
            btnLotComposants.BackgroundImageLayout = ImageLayout.None;
            btnLotComposants.FlatAppearance.BorderSize = 0;
            btnLotComposants.FlatStyle = FlatStyle.Flat;
            btnLotComposants.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnLotComposants.ForeColor = Color.White;
            btnLotComposants.Image = Properties.Resources.tournoi;
            btnLotComposants.ImageAlign = ContentAlignment.MiddleLeft;
            btnLotComposants.Location = new Point(0, 634);
            btnLotComposants.Margin = new Padding(0, 9, 0, 4);
            btnLotComposants.Name = "btnLotComposants";
            btnLotComposants.Size = new Size(225, 91);
            btnLotComposants.TabIndex = 6;
            btnLotComposants.Text = "      Composant des lots";
            btnLotComposants.UseVisualStyleBackColor = false;
            btnLotComposants.Click += btnLotComposants_Click;
            // 
            // btnQuitter
            // 
            btnQuitter.BackColor = Color.FromArgb(60, 60, 60);
            btnQuitter.FlatAppearance.BorderSize = 0;
            btnQuitter.FlatStyle = FlatStyle.Flat;
            btnQuitter.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnQuitter.ForeColor = Color.White;
            btnQuitter.Image = Properties.Resources.deconnecter;
            btnQuitter.ImageAlign = ContentAlignment.MiddleLeft;
            btnQuitter.Location = new Point(3, 733);
            btnQuitter.Margin = new Padding(3, 4, 3, 4);
            btnQuitter.Name = "btnQuitter";
            btnQuitter.Size = new Size(229, 65);
            btnQuitter.TabIndex = 6;
            btnQuitter.Text = "  Quitter";
            btnQuitter.UseVisualStyleBackColor = false;
            btnQuitter.Click += btnQuitter_Click;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(63, 81, 181);
            panelHeader.Controls.Add(lblTitre);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            panelHeader.ForeColor = SystemColors.ControlLightLight;
            panelHeader.Location = new Point(229, 0);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(996, 65);
            panelHeader.TabIndex = 1;
            // 
            // lblTitre
            // 
            lblTitre.AutoSize = true;
            lblTitre.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitre.Location = new Point(23, 16);
            lblTitre.Name = "lblTitre";
            lblTitre.Size = new Size(349, 32);
            lblTitre.TabIndex = 0;
            lblTitre.Text = "Espace de Gestion du Festival";
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.FromArgb(245, 246, 248);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(229, 65);
            panelContent.Margin = new Padding(3, 4, 3, 4);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(996, 816);
            panelContent.TabIndex = 0;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 248);
            ClientSize = new Size(1225, 881);
            ControlBox = false;
            Controls.Add(panelContent);
            Controls.Add(panelHeader);
            Controls.Add(panelMenu);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
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
        private Button btnQuitter ;
        private Panel panelHeader;
        private Label lblTitre;

        private Panel panelContent;
        private Button btnOrganisateurs;
        private Button btnLotComposants;
        private Button buttonJeux;
        private Button btnLots;
    }
}
