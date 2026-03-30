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
            btnLotComposant = new Button();
            btnOrganisateur = new Button();
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
            panelMenu.Controls.Add(btnLotComposant);
            panelMenu.Controls.Add(btnOrganisateur);
            panelMenu.Controls.Add(btnQuitter);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.FlowDirection = FlowDirection.TopDown;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Margin = new Padding(3, 4, 3, 4);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(229, 933);
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
            btnPlateformes.Location = new Point(0, 67);
            btnPlateformes.Margin = new Padding(0, 67, 0, 5);
            btnPlateformes.Name = "btnPlateformes";
            btnPlateformes.Size = new Size(229, 67);
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
            btnPostes.Location = new Point(0, 150);
            btnPostes.Margin = new Padding(0, 11, 0, 5);
            btnPostes.Name = "btnPostes";
            btnPostes.Size = new Size(238, 67);
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
            btnEspaces.Location = new Point(0, 233);
            btnEspaces.Margin = new Padding(0, 11, 0, 5);
            btnEspaces.Name = "btnEspaces";
            btnEspaces.Size = new Size(229, 67);
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
            btnTournois.Location = new Point(0, 316);
            btnTournois.Margin = new Padding(0, 11, 0, 5);
            btnTournois.Name = "btnTournois";
            btnTournois.Size = new Size(229, 67);
            btnTournois.TabIndex = 3;
            btnTournois.Text = "Tournois";
            btnTournois.UseVisualStyleBackColor = false;
            btnTournois.Click += btnTournois_Click;
            // 
            // btnLotComposant
            // 
            btnLotComposant.BackColor = Color.Blue;
            btnLotComposant.BackgroundImageLayout = ImageLayout.None;
            btnLotComposant.FlatAppearance.BorderSize = 0;
            btnLotComposant.FlatStyle = FlatStyle.Flat;
            btnLotComposant.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnLotComposant.ForeColor = Color.White;
            btnLotComposant.Image = Properties.Resources.tournoi;
            btnLotComposant.ImageAlign = ContentAlignment.MiddleLeft;
            btnLotComposant.Location = new Point(0, 399);
            btnLotComposant.Margin = new Padding(0, 11, 0, 5);
            btnLotComposant.Name = "btnLotComposant";
            btnLotComposant.Size = new Size(229, 91);
            btnLotComposant.TabIndex = 6;
            btnLotComposant.Text = "      Composant des lots";
            btnLotComposant.UseVisualStyleBackColor = false;
            btnLotComposant.Click += btnLotComposant_Click;
            // 
            // btnOrganisateur
            // 
            btnOrganisateur.BackColor = Color.FromArgb(192, 0, 0);
            btnOrganisateur.BackgroundImageLayout = ImageLayout.None;
            btnOrganisateur.FlatAppearance.BorderSize = 0;
            btnOrganisateur.FlatStyle = FlatStyle.Flat;
            btnOrganisateur.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnOrganisateur.ForeColor = Color.White;
            btnOrganisateur.Image = Properties.Resources.tournoi;
            btnOrganisateur.ImageAlign = ContentAlignment.MiddleLeft;
            btnOrganisateur.Location = new Point(0, 506);
            btnOrganisateur.Margin = new Padding(0, 11, 0, 5);
            btnOrganisateur.Name = "btnOrganisateur";
            btnOrganisateur.Size = new Size(229, 67);
            btnOrganisateur.TabIndex = 5;
            btnOrganisateur.Text = "      Organisateurs";
            btnOrganisateur.UseVisualStyleBackColor = false;
            btnOrganisateur.Click += btnOrganisateur_Click;
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
            btnQuitter.Location = new Point(3, 582);
            btnQuitter.Margin = new Padding(3, 4, 3, 4);
            btnQuitter.Name = "btnQuitter";
            btnQuitter.Size = new Size(229, 67);
            btnQuitter.TabIndex = 4;
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
            panelHeader.Size = new Size(996, 67);
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
            panelContent.Location = new Point(229, 67);
            panelContent.Margin = new Padding(3, 4, 3, 4);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(996, 866);
            panelContent.TabIndex = 0;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 248);
            ClientSize = new Size(1225, 933);
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
        private Button btnOrganisateur;
        private Button btnLotComposant;
    }
}
