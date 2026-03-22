using System.Windows.Forms;

namespace ApplicationUi
{
    partial class UcOrganisateur
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
            buttonAjouter = new Button();
            buttonEffacer = new Button();
            buttonModifier = new Button();
            buttonSupprimer = new Button();
            label1 = new Label();
            dataGridOrganisateurs = new DataGridView();
            labelError = new Label();
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
            panelForm.Location = new Point(20, 120);
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
            labelLogin.Size = new Size(78, 23);
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
            labelMail.Size = new Size(68, 23);
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
            labelMotDePasse.Size = new Size(139, 23);
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
            labelRole.Size = new Size(68, 23);
            labelRole.TabIndex = 3;
            labelRole.Text = "Rôle * :";
            // 
            // textBoxLogin
            // 
            textBoxLogin.Location = new Point(4, 39);
            textBoxLogin.Margin = new Padding(4);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.PlaceholderText = "Ex: jdupont";
            textBoxLogin.Size = new Size(210, 27);
            textBoxLogin.TabIndex = 0;
            // 
            // textBoxMail
            // 
            textBoxMail.Location = new Point(223, 39);
            textBoxMail.Margin = new Padding(4);
            textBoxMail.Name = "textBoxMail";
            textBoxMail.PlaceholderText = "Ex: jean@mail.com";
            textBoxMail.Size = new Size(210, 27);
            textBoxMail.TabIndex = 1;
            // 
            // textBoxMotDePasse
            // 
            textBoxMotDePasse.Location = new Point(442, 39);
            textBoxMotDePasse.Margin = new Padding(4);
            textBoxMotDePasse.Name = "textBoxMotDePasse";
            textBoxMotDePasse.PasswordChar = '●';
            textBoxMotDePasse.PlaceholderText = "Min. 12 caract., 1 maj., 1 spécial, 1 chiffre";
            textBoxMotDePasse.Size = new Size(210, 27);
            textBoxMotDePasse.TabIndex = 2;
            // 
            // comboBoxRole
            // 
            comboBoxRole.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRole.Location = new Point(661, 39);
            comboBoxRole.Margin = new Padding(4);
            comboBoxRole.Name = "comboBoxRole";
            comboBoxRole.Size = new Size(210, 31);
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
            groupBox1.Controls.Add(buttonAjouter);
            groupBox1.Controls.Add(buttonEffacer);
            groupBox1.Controls.Add(buttonModifier);
            groupBox1.Controls.Add(buttonSupprimer);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(879, 82);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "⚡ Actions";
            // 
            // buttonAjouter
            // 
            buttonAjouter.BackColor = Color.FromArgb(76, 175, 80);
            buttonAjouter.FlatAppearance.BorderSize = 0;
            buttonAjouter.FlatStyle = FlatStyle.Flat;
            buttonAjouter.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonAjouter.ForeColor = Color.White;
            buttonAjouter.Location = new Point(270, 25);
            buttonAjouter.Margin = new Padding(4);
            buttonAjouter.Name = "buttonAjouter";
            buttonAjouter.Size = new Size(150, 45);
            buttonAjouter.TabIndex = 6;
            buttonAjouter.Text = "➕  Ajouter";
            buttonAjouter.UseVisualStyleBackColor = false;
            buttonAjouter.Click += buttonAjouter_Click;
            // 
            // buttonEffacer
            // 
            buttonEffacer.BackColor = Color.MediumPurple;
            buttonEffacer.FlatAppearance.BorderSize = 0;
            buttonEffacer.FlatStyle = FlatStyle.Flat;
            buttonEffacer.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonEffacer.ForeColor = Color.White;
            buttonEffacer.Location = new Point(70, 25);
            buttonEffacer.Margin = new Padding(4);
            buttonEffacer.Name = "buttonEffacer";
            buttonEffacer.Size = new Size(150, 45);
            buttonEffacer.TabIndex = 3;
            buttonEffacer.Text = " \U0001f9fd  Effacer";
            buttonEffacer.UseVisualStyleBackColor = false;
            buttonEffacer.Click += buttonEffacer_Click;
            // 
            // buttonModifier
            // 
            buttonModifier.BackColor = Color.FromArgb(33, 150, 243);
            buttonModifier.FlatAppearance.BorderSize = 0;
            buttonModifier.FlatStyle = FlatStyle.Flat;
            buttonModifier.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonModifier.ForeColor = Color.White;
            buttonModifier.Location = new Point(470, 25);
            buttonModifier.Margin = new Padding(4);
            buttonModifier.Name = "buttonModifier";
            buttonModifier.Size = new Size(150, 45);
            buttonModifier.TabIndex = 4;
            buttonModifier.Text = "✏️    Modifier";
            buttonModifier.UseVisualStyleBackColor = false;
            buttonModifier.Click += buttonModifier_Click;
            // 
            // buttonSupprimer
            // 
            buttonSupprimer.BackColor = Color.FromArgb(244, 67, 54);
            buttonSupprimer.FlatAppearance.BorderSize = 0;
            buttonSupprimer.FlatStyle = FlatStyle.Flat;
            buttonSupprimer.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonSupprimer.ForeColor = Color.White;
            buttonSupprimer.Location = new Point(670, 25);
            buttonSupprimer.Margin = new Padding(4);
            buttonSupprimer.Name = "buttonSupprimer";
            buttonSupprimer.Size = new Size(162, 45);
            buttonSupprimer.TabIndex = 5;
            buttonSupprimer.Text = "🗑️    Supprimer";
            buttonSupprimer.UseVisualStyleBackColor = false;
            buttonSupprimer.Click += buttonSupprimer_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 23);
            label1.TabIndex = 6;
            // 
            // dataGridOrganisateurs
            // 
            dataGridOrganisateurs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridOrganisateurs.BackgroundColor = Color.White;
            dataGridOrganisateurs.BorderStyle = BorderStyle.None;
            dataGridOrganisateurs.ColumnHeadersHeight = 34;
            dataGridOrganisateurs.Location = new Point(20, 361);
            dataGridOrganisateurs.Margin = new Padding(4);
            dataGridOrganisateurs.Name = "dataGridOrganisateurs";
            dataGridOrganisateurs.ReadOnly = true;
            dataGridOrganisateurs.RowHeadersWidth = 62;
            dataGridOrganisateurs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridOrganisateurs.Size = new Size(900, 434);
            dataGridOrganisateurs.TabIndex = 2;
            dataGridOrganisateurs.CellClick += dataGridOrganisateurs_CellClick;
            // 
            // labelError
            // 
            labelError.Font = new Font("Segoe UI Light", 14F);
            labelError.ForeColor = Color.FromArgb(255, 128, 128);
            labelError.Location = new Point(235, 18);
            labelError.Margin = new Padding(4, 0, 4, 0);
            labelError.Name = "labelError";
            labelError.Size = new Size(469, 84);
            labelError.TabIndex = 3;
            labelError.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UcOrganisateur
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(227, 242, 253);
            Controls.Add(labelError);
            Controls.Add(panelForm);
            Controls.Add(dataGridOrganisateurs);
            Font = new Font("Trebuchet MS", 10F);
            Margin = new Padding(4);
            Name = "UcOrganisateur";
            Size = new Size(950, 809);
            panelForm.ResumeLayout(false);
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            panelButtons.ResumeLayout(false);
            panelButtons.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridOrganisateurs).EndInit();
            ResumeLayout(false);
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
        private Button buttonAjouter;
        private Button buttonEffacer;
        private Button buttonModifier;
        private Button buttonSupprimer;
        private Label label1;
        private DataGridView dataGridOrganisateurs;
        private Label labelError;
    }
}