using System.Windows.Forms;

namespace ApplicationUi
{
    partial class UcOrganisateurs
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
            panelForm = new Panel();
            tableLayoutPanel = new TableLayoutPanel();
            labelLogin = new Label();
            labelMail = new Label();
            labelMotDePasse = new Label();
            labelRole = new Label();
            textBoxLogin = new TextBox();
            textBoxMail = new TextBox();
            textBoxMotDePasse = new TextBox();
            comboBoxRole = new ComboBox();
            panelButtons = new Panel();
            groupBox1 = new GroupBox();
            boutonAjouter = new Button();
            boutonEffacer = new Button();
            boutonModifier = new Button();
            boutonSupprimer = new Button();
            label1 = new Label();
            dataGridOrganisateurs = new DataGridView();
            label2 = new Label();
            textBoxRecherche = new TextBox();
            panelForm.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            panelButtons.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridOrganisateurs).BeginInit();
            SuspendLayout();
            // 
            // panelForm
            // 
            panelForm.BackColor = Color.White;
            panelForm.Controls.Add(tableLayoutPanel);
            panelForm.Controls.Add(panelButtons);
            panelForm.Location = new Point(20, 39);
            panelForm.Margin = new Padding(4);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(900, 210);
            panelForm.TabIndex = 1;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 4;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel.Controls.Add(labelLogin, 0, 0);
            tableLayoutPanel.Controls.Add(labelMail, 1, 0);
            tableLayoutPanel.Controls.Add(labelMotDePasse, 2, 0);
            tableLayoutPanel.Controls.Add(labelRole, 3, 0);
            tableLayoutPanel.Controls.Add(textBoxLogin, 0, 1);
            tableLayoutPanel.Controls.Add(textBoxMail, 1, 1);
            tableLayoutPanel.Controls.Add(textBoxMotDePasse, 2, 1);
            tableLayoutPanel.Controls.Add(comboBoxRole, 3, 1);
            tableLayoutPanel.Location = new Point(10, 12);
            tableLayoutPanel.Margin = new Padding(4);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 3;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.Size = new Size(879, 110);
            tableLayoutPanel.TabIndex = 0;
            // 
            // labelLogin
            // 
            labelLogin.AutoSize = true;
            labelLogin.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelLogin.Location = new Point(4, 0);
            labelLogin.Margin = new Padding(4, 0, 4, 0);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(61, 17);
            labelLogin.TabIndex = 0;
            labelLogin.Text = "Login * :";
            // 
            // labelMail
            // 
            labelMail.AutoSize = true;
            labelMail.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelMail.Location = new Point(223, 0);
            labelMail.Margin = new Padding(4, 0, 4, 0);
            labelMail.Name = "labelMail";
            labelMail.Size = new Size(53, 17);
            labelMail.TabIndex = 1;
            labelMail.Text = "Mail * :";
            // 
            // labelMotDePasse
            // 
            labelMotDePasse.AutoSize = true;
            labelMotDePasse.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelMotDePasse.Location = new Point(442, 0);
            labelMotDePasse.Margin = new Padding(4, 0, 4, 0);
            labelMotDePasse.Name = "labelMotDePasse";
            labelMotDePasse.Size = new Size(108, 17);
            labelMotDePasse.TabIndex = 2;
            labelMotDePasse.Text = "Mot de passe * :";
            // 
            // labelRole
            // 
            labelRole.AutoSize = true;
            labelRole.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelRole.Location = new Point(661, 0);
            labelRole.Margin = new Padding(4, 0, 4, 0);
            labelRole.Name = "labelRole";
            labelRole.Size = new Size(53, 17);
            labelRole.TabIndex = 3;
            labelRole.Text = "Rôle * :";
            // 
            // textBoxLogin
            // 
            textBoxLogin.Location = new Point(4, 39);
            textBoxLogin.Margin = new Padding(4);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.PlaceholderText = "Ex: jdupont";
            textBoxLogin.Size = new Size(210, 23);
            textBoxLogin.TabIndex = 0;
            // 
            // textBoxMail
            // 
            textBoxMail.Location = new Point(223, 39);
            textBoxMail.Margin = new Padding(4);
            textBoxMail.Name = "textBoxMail";
            textBoxMail.PlaceholderText = "Ex: jean@mail.com";
            textBoxMail.Size = new Size(210, 23);
            textBoxMail.TabIndex = 1;
            // 
            // textBoxMotDePasse
            // 
            textBoxMotDePasse.Location = new Point(442, 39);
            textBoxMotDePasse.Margin = new Padding(4);
            textBoxMotDePasse.Name = "textBoxMotDePasse";
            textBoxMotDePasse.PasswordChar = '●';
            textBoxMotDePasse.PlaceholderText = "Min. 12 caract., 1 maj., 1 spécial, 1 chiffre";
            textBoxMotDePasse.Size = new Size(210, 23);
            textBoxMotDePasse.TabIndex = 2;
            // 
            // comboBoxRole
            // 
            comboBoxRole.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRole.Location = new Point(661, 39);
            comboBoxRole.Margin = new Padding(4);
            comboBoxRole.Name = "comboBoxRole";
            comboBoxRole.Size = new Size(210, 26);
            comboBoxRole.TabIndex = 3;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(groupBox1);
            panelButtons.Controls.Add(label1);
            panelButtons.Location = new Point(10, 125);
            panelButtons.Margin = new Padding(4);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(879, 82);
            panelButtons.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(boutonAjouter);
            groupBox1.Controls.Add(boutonEffacer);
            groupBox1.Controls.Add(boutonModifier);
            groupBox1.Controls.Add(boutonSupprimer);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(879, 82);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "⚡ Actions";
            // 
            // boutonAjouter
            // 
            boutonAjouter.BackColor = Color.FromArgb(76, 175, 80);
            boutonAjouter.FlatAppearance.BorderSize = 0;
            boutonAjouter.FlatStyle = FlatStyle.Flat;
            boutonAjouter.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            boutonAjouter.ForeColor = Color.White;
            boutonAjouter.Location = new Point(270, 25);
            boutonAjouter.Margin = new Padding(4);
            boutonAjouter.Name = "boutonAjouter";
            boutonAjouter.Size = new Size(150, 45);
            boutonAjouter.TabIndex = 6;
            boutonAjouter.Text = "➕  Ajouter";
            boutonAjouter.UseVisualStyleBackColor = false;
            boutonAjouter.Click += BoutonAjouter_Click;
            // 
            // boutonEffacer
            // 
            boutonEffacer.BackColor = Color.MediumPurple;
            boutonEffacer.FlatAppearance.BorderSize = 0;
            boutonEffacer.FlatStyle = FlatStyle.Flat;
            boutonEffacer.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            boutonEffacer.ForeColor = Color.White;
            boutonEffacer.Location = new Point(70, 25);
            boutonEffacer.Margin = new Padding(4);
            boutonEffacer.Name = "boutonEffacer";
            boutonEffacer.Size = new Size(150, 45);
            boutonEffacer.TabIndex = 3;
            boutonEffacer.Text = " \U0001f9fd  Effacer";
            boutonEffacer.UseVisualStyleBackColor = false;
            boutonEffacer.Click += BoutonEffacer_Click;
            // 
            // boutonModifier
            // 
            boutonModifier.BackColor = Color.FromArgb(33, 150, 243);
            boutonModifier.FlatAppearance.BorderSize = 0;
            boutonModifier.FlatStyle = FlatStyle.Flat;
            boutonModifier.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            boutonModifier.ForeColor = Color.White;
            boutonModifier.Location = new Point(470, 25);
            boutonModifier.Margin = new Padding(4);
            boutonModifier.Name = "boutonModifier";
            boutonModifier.Size = new Size(150, 45);
            boutonModifier.TabIndex = 4;
            boutonModifier.Text = "✏️    Modifier";
            boutonModifier.UseVisualStyleBackColor = false;
            boutonModifier.Click += BoutonModifier_Click;
            // 
            // boutonSupprimer
            // 
            boutonSupprimer.BackColor = Color.FromArgb(244, 67, 54);
            boutonSupprimer.FlatAppearance.BorderSize = 0;
            boutonSupprimer.FlatStyle = FlatStyle.Flat;
            boutonSupprimer.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            boutonSupprimer.ForeColor = Color.White;
            boutonSupprimer.Location = new Point(670, 25);
            boutonSupprimer.Margin = new Padding(4);
            boutonSupprimer.Name = "boutonSupprimer";
            boutonSupprimer.Size = new Size(162, 45);
            boutonSupprimer.TabIndex = 5;
            boutonSupprimer.Text = "🗑️    Supprimer";
            boutonSupprimer.UseVisualStyleBackColor = false;
            boutonSupprimer.Click += BoutonSupprimer_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 18);
            label1.TabIndex = 6;
            // 
            // dataGridOrganisateurs
            // 
            dataGridOrganisateurs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridOrganisateurs.BackgroundColor = Color.White;
            dataGridOrganisateurs.BorderStyle = BorderStyle.None;
            dataGridOrganisateurs.ColumnHeadersHeight = 34;
            dataGridOrganisateurs.Location = new Point(20, 330);
            dataGridOrganisateurs.Margin = new Padding(4);
            dataGridOrganisateurs.Name = "dataGridOrganisateurs";
            dataGridOrganisateurs.ReadOnly = true;
            dataGridOrganisateurs.RowHeadersWidth = 62;
            dataGridOrganisateurs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridOrganisateurs.Size = new Size(900, 434);
            dataGridOrganisateurs.TabIndex = 2;
            dataGridOrganisateurs.CellClick += DataGridOrganisateurs_CellClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(116, 279);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(89, 20);
            label2.TabIndex = 3;
            label2.Text = "Recherche :";
            // 
            // textBoxRecherche
            // 
            textBoxRecherche.Location = new Point(253, 279);
            textBoxRecherche.Margin = new Padding(2);
            textBoxRecherche.Name = "textBoxRecherche";
            textBoxRecherche.PlaceholderText = "Ex: jean";
            textBoxRecherche.Size = new Size(574, 23);
            textBoxRecherche.TabIndex = 4;
            textBoxRecherche.TextChanged += TextBoxRecherche_TextChanged;
            // 
            // UcOrganisateurs
            // 
            AutoScaleDimensions = new SizeF(7F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSalmon;
            Controls.Add(textBoxRecherche);
            Controls.Add(label2);
            Controls.Add(panelForm);
            Controls.Add(dataGridOrganisateurs);
            Font = new Font("Trebuchet MS", 10F);
            Margin = new Padding(4);
            Name = "UcOrganisateurs";
            Size = new Size(950, 809);
            panelForm.ResumeLayout(false);
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            panelButtons.ResumeLayout(false);
            panelButtons.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridOrganisateurs).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelForm;
        private TableLayoutPanel tableLayoutPanel;
        private TextBox textBoxLogin;
        private TextBox textBoxMail;
        private TextBox textBoxMotDePasse;
        private ComboBox comboBoxRole;
        private Label labelLogin;
        private Label labelMail;
        private Label labelMotDePasse;
        private Label labelRole;
        private Panel panelButtons;
        private GroupBox groupBox1;
        private Button boutonAjouter;
        private Button boutonEffacer;
        private Button boutonModifier;
        private Button boutonSupprimer;
        private Label label1;
        private DataGridView dataGridOrganisateurs;
        private Label label2;
        private TextBox textBoxRecherche;
    }
}