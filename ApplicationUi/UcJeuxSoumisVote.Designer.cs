namespace ApplicationUi
{
    partial class UcJeuxSoumisVote
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            label2 = new Label();
            textBoxRecherche = new TextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            dataGridClassement = new DataGridView();
            tableLayoutPanel4 = new TableLayoutPanel();
            labelClassement = new Label();
            panelForm = new Panel();
            tableLayoutPanel = new TableLayoutPanel();
            comboBoxJeu = new ComboBox();
            label3 = new Label();
            dateTimePickerDateFinVote = new DateTimePicker();
            comboBoxPlateforme = new ComboBox();
            labelPlateforme = new Label();
            labelTitre = new Label();
            labelDescription = new Label();
            textBoxDescription = new TextBox();
            labelDateDebutVote = new Label();
            dateTimePickerDateDebutVote = new DateTimePicker();
            panelButtons = new Panel();
            groupBox1 = new GroupBox();
            buttonModifier = new Button();
            buttonAjouter = new Button();
            buttonEffacer = new Button();
            buttonSupprimer = new Button();
            label1 = new Label();
            dataGridJeuSoumisVote = new DataGridView();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridClassement).BeginInit();
            tableLayoutPanel4.SuspendLayout();
            panelForm.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            panelButtons.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridJeuSoumisVote).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(75, 64);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(89, 20);
            label2.TabIndex = 1;
            label2.Text = "Recherche :";
            // 
            // textBoxRecherche
            // 
            textBoxRecherche.Font = new Font("Segoe UI", 11F);
            textBoxRecherche.Location = new Point(171, 59);
            textBoxRecherche.Margin = new Padding(2);
            textBoxRecherche.Name = "textBoxRecherche";
            textBoxRecherche.PlaceholderText = "Ex: Mari...";
            textBoxRecherche.Size = new Size(649, 27);
            textBoxRecherche.TabIndex = 0;
            textBoxRecherche.TextChanged += TextBoxRecherche_TextChanged;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67.49249F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 504F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 1, 0);
            tableLayoutPanel1.Controls.Add(panelForm, 0, 0);
            tableLayoutPanel1.Controls.Add(dataGridJeuSoumisVote, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 53.5897446F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 46.4102554F));
            tableLayoutPanel1.Size = new Size(1431, 468);
            tableLayoutPanel1.TabIndex = 8;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(dataGridClassement, 0, 1);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel4, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(930, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 14.6788988F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 85.3211F));
            tableLayoutPanel3.Size = new Size(498, 244);
            tableLayoutPanel3.TabIndex = 10;
            // 
            // dataGridClassement
            // 
            dataGridClassement.AccessibleDescription = "Jeux déjà votés par l'utilisateur";
            dataGridClassement.AllowUserToAddRows = false;
            dataGridClassement.AllowUserToDeleteRows = false;
            dataGridClassement.BackgroundColor = Color.White;
            dataGridClassement.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridClassement.Dock = DockStyle.Fill;
            dataGridClassement.Location = new Point(3, 38);
            dataGridClassement.Name = "dataGridClassement";
            dataGridClassement.ReadOnly = true;
            dataGridClassement.RowHeadersWidth = 62;
            dataGridClassement.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridClassement.Size = new Size(492, 203);
            dataGridClassement.TabIndex = 7;
            dataGridClassement.CellClick += DataGridClassement_CellClick;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(labelClassement, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(2, 2);
            tableLayoutPanel4.Margin = new Padding(2);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Size = new Size(494, 31);
            tableLayoutPanel4.TabIndex = 8;
            // 
            // labelClassement
            // 
            labelClassement.BackColor = Color.FromArgb(192, 192, 255);
            labelClassement.Dock = DockStyle.Fill;
            labelClassement.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelClassement.ForeColor = Color.FromArgb(0, 0, 64);
            labelClassement.Location = new Point(3, 0);
            labelClassement.Name = "labelClassement";
            labelClassement.Size = new Size(488, 31);
            labelClassement.TabIndex = 11;
            labelClassement.Text = "Classement des jeux et plateformes";
            labelClassement.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelForm
            // 
            panelForm.BackColor = Color.White;
            panelForm.Controls.Add(tableLayoutPanel);
            panelForm.Controls.Add(panelButtons);
            panelForm.Dock = DockStyle.Fill;
            panelForm.Location = new Point(3, 2);
            panelForm.Margin = new Padding(3, 2, 3, 2);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(921, 246);
            panelForm.TabIndex = 5;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 4;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40.8163261F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 59.1836739F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 206F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 209F));
            tableLayoutPanel.Controls.Add(comboBoxJeu, 0, 1);
            tableLayoutPanel.Controls.Add(label3, 3, 2);
            tableLayoutPanel.Controls.Add(dateTimePickerDateFinVote, 3, 3);
            tableLayoutPanel.Controls.Add(comboBoxPlateforme, 2, 1);
            tableLayoutPanel.Controls.Add(labelPlateforme, 2, 0);
            tableLayoutPanel.Controls.Add(labelTitre, 0, 0);
            tableLayoutPanel.Controls.Add(labelDescription, 1, 0);
            tableLayoutPanel.Controls.Add(textBoxDescription, 1, 1);
            tableLayoutPanel.Controls.Add(labelDateDebutVote, 3, 0);
            tableLayoutPanel.Controls.Add(dateTimePickerDateDebutVote, 3, 1);
            tableLayoutPanel.Location = new Point(10, 12);
            tableLayoutPanel.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 5;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 43F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.Size = new Size(890, 133);
            tableLayoutPanel.TabIndex = 0;
            // 
            // comboBoxJeu
            // 
            comboBoxJeu.Dock = DockStyle.Fill;
            comboBoxJeu.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxJeu.Location = new Point(4, 39);
            comboBoxJeu.Margin = new Padding(4);
            comboBoxJeu.Name = "comboBoxJeu";
            comboBoxJeu.Size = new Size(185, 23);
            comboBoxJeu.TabIndex = 33;
            comboBoxJeu.SelectedIndexChanged += ComboBoxJeu_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label3.Location = new Point(684, 78);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(202, 27);
            label3.TabIndex = 31;
            label3.Text = "Date butoire des votes :";
            label3.TextAlign = ContentAlignment.BottomLeft;
            // 
            // dateTimePickerDateFinVote
            // 
            dateTimePickerDateFinVote.Dock = DockStyle.Fill;
            dateTimePickerDateFinVote.Format = DateTimePickerFormat.Short;
            dateTimePickerDateFinVote.Location = new Point(683, 108);
            dateTimePickerDateFinVote.Name = "dateTimePickerDateFinVote";
            dateTimePickerDateFinVote.Size = new Size(204, 23);
            dateTimePickerDateFinVote.TabIndex = 32;
            // 
            // comboBoxPlateforme
            // 
            comboBoxPlateforme.Dock = DockStyle.Fill;
            comboBoxPlateforme.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPlateforme.Location = new Point(478, 39);
            comboBoxPlateforme.Margin = new Padding(4);
            comboBoxPlateforme.Name = "comboBoxPlateforme";
            comboBoxPlateforme.Size = new Size(198, 23);
            comboBoxPlateforme.TabIndex = 29;
            comboBoxPlateforme.SelectedIndexChanged += ComboBoxPlateforme_SelectedIndexChanged;
            // 
            // labelPlateforme
            // 
            labelPlateforme.AutoSize = true;
            labelPlateforme.Dock = DockStyle.Fill;
            labelPlateforme.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelPlateforme.Location = new Point(478, 0);
            labelPlateforme.Margin = new Padding(4, 0, 4, 0);
            labelPlateforme.Name = "labelPlateforme";
            labelPlateforme.Size = new Size(198, 35);
            labelPlateforme.TabIndex = 21;
            labelPlateforme.Text = "Plateforme :";
            labelPlateforme.TextAlign = ContentAlignment.BottomLeft;
            // 
            // labelTitre
            // 
            labelTitre.AutoSize = true;
            labelTitre.Dock = DockStyle.Fill;
            labelTitre.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelTitre.Location = new Point(3, 0);
            labelTitre.Name = "labelTitre";
            labelTitre.Size = new Size(187, 35);
            labelTitre.TabIndex = 6;
            labelTitre.Text = "Jeu :";
            labelTitre.TextAlign = ContentAlignment.BottomLeft;
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Dock = DockStyle.Fill;
            labelDescription.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelDescription.Location = new Point(197, 0);
            labelDescription.Margin = new Padding(4, 0, 4, 0);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(273, 35);
            labelDescription.TabIndex = 26;
            labelDescription.Text = "Description :";
            labelDescription.TextAlign = ContentAlignment.BottomLeft;
            // 
            // textBoxDescription
            // 
            textBoxDescription.Dock = DockStyle.Fill;
            textBoxDescription.Enabled = false;
            textBoxDescription.Location = new Point(197, 38);
            textBoxDescription.Margin = new Padding(4, 3, 4, 3);
            textBoxDescription.Multiline = true;
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.PlaceholderText = "Ex: Mariokart 8 est un jeu de courses";
            textBoxDescription.ReadOnly = true;
            tableLayoutPanel.SetRowSpan(textBoxDescription, 3);
            textBoxDescription.Size = new Size(273, 106);
            textBoxDescription.TabIndex = 25;
            // 
            // labelDateDebutVote
            // 
            labelDateDebutVote.AutoSize = true;
            labelDateDebutVote.Dock = DockStyle.Fill;
            labelDateDebutVote.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelDateDebutVote.Location = new Point(684, 0);
            labelDateDebutVote.Margin = new Padding(4, 0, 4, 0);
            labelDateDebutVote.Name = "labelDateDebutVote";
            labelDateDebutVote.Size = new Size(202, 35);
            labelDateDebutVote.TabIndex = 19;
            labelDateDebutVote.Text = "Date d'ouverture des votes:";
            labelDateDebutVote.TextAlign = ContentAlignment.BottomLeft;
            // 
            // dateTimePickerDateDebutVote
            // 
            dateTimePickerDateDebutVote.Dock = DockStyle.Fill;
            dateTimePickerDateDebutVote.Format = DateTimePickerFormat.Short;
            dateTimePickerDateDebutVote.Location = new Point(683, 38);
            dateTimePickerDateDebutVote.Name = "dateTimePickerDateDebutVote";
            dateTimePickerDateDebutVote.Size = new Size(204, 23);
            dateTimePickerDateDebutVote.TabIndex = 24;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(groupBox1);
            panelButtons.Controls.Add(label1);
            panelButtons.Location = new Point(3, 150);
            panelButtons.Margin = new Padding(3, 2, 3, 2);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(902, 84);
            panelButtons.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(buttonModifier);
            groupBox1.Controls.Add(buttonAjouter);
            groupBox1.Controls.Add(textBoxRecherche);
            groupBox1.Controls.Add(buttonEffacer);
            groupBox1.Controls.Add(buttonSupprimer);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Margin = new Padding(2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2);
            groupBox1.Size = new Size(902, 84);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "⚡ Actions";
            // 
            // buttonModifier
            // 
            buttonModifier.BackColor = Color.FromArgb(33, 150, 243);
            buttonModifier.FlatAppearance.BorderSize = 0;
            buttonModifier.FlatStyle = FlatStyle.Flat;
            buttonModifier.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonModifier.ForeColor = Color.White;
            buttonModifier.Location = new Point(338, 15);
            buttonModifier.Margin = new Padding(4);
            buttonModifier.Name = "buttonModifier";
            buttonModifier.Size = new Size(136, 27);
            buttonModifier.TabIndex = 7;
            buttonModifier.Text = "✏️    Modifier";
            buttonModifier.UseVisualStyleBackColor = false;
            buttonModifier.Click += ButtonModifier_Click;
            // 
            // buttonAjouter
            // 
            buttonAjouter.BackColor = Color.FromArgb(76, 175, 80);
            buttonAjouter.FlatAppearance.BorderSize = 0;
            buttonAjouter.FlatStyle = FlatStyle.Flat;
            buttonAjouter.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonAjouter.ForeColor = Color.White;
            buttonAjouter.Location = new Point(171, 15);
            buttonAjouter.Margin = new Padding(4, 3, 4, 3);
            buttonAjouter.Name = "buttonAjouter";
            buttonAjouter.Size = new Size(132, 27);
            buttonAjouter.TabIndex = 6;
            buttonAjouter.Text = "➕  Ajouter";
            buttonAjouter.UseVisualStyleBackColor = false;
            buttonAjouter.Click += ButtonAjouter_Click;
            // 
            // buttonEffacer
            // 
            buttonEffacer.BackColor = Color.MediumPurple;
            buttonEffacer.FlatAppearance.BorderSize = 0;
            buttonEffacer.FlatStyle = FlatStyle.Flat;
            buttonEffacer.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonEffacer.ForeColor = Color.White;
            buttonEffacer.Location = new Point(28, 15);
            buttonEffacer.Margin = new Padding(3, 2, 3, 2);
            buttonEffacer.Name = "buttonEffacer";
            buttonEffacer.Size = new Size(105, 27);
            buttonEffacer.TabIndex = 3;
            buttonEffacer.Text = " Effacer";
            buttonEffacer.UseVisualStyleBackColor = false;
            buttonEffacer.Click += ButtonEffacer_Click;
            // 
            // buttonSupprimer
            // 
            buttonSupprimer.BackColor = Color.FromArgb(244, 67, 54);
            buttonSupprimer.FlatAppearance.BorderSize = 0;
            buttonSupprimer.FlatStyle = FlatStyle.Flat;
            buttonSupprimer.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonSupprimer.ForeColor = Color.White;
            buttonSupprimer.Location = new Point(504, 15);
            buttonSupprimer.Margin = new Padding(4, 3, 4, 3);
            buttonSupprimer.Name = "buttonSupprimer";
            buttonSupprimer.Size = new Size(158, 27);
            buttonSupprimer.TabIndex = 5;
            buttonSupprimer.Text = "🗑️    Supprimer";
            buttonSupprimer.UseVisualStyleBackColor = false;
            buttonSupprimer.Click += ButtonSupprimer_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 6;
            // 
            // dataGridJeuSoumisVote
            // 
            dataGridJeuSoumisVote.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridJeuSoumisVote.BackgroundColor = Color.White;
            dataGridJeuSoumisVote.BorderStyle = BorderStyle.None;
            dataGridJeuSoumisVote.ColumnHeadersHeight = 34;
            dataGridJeuSoumisVote.Dock = DockStyle.Fill;
            dataGridJeuSoumisVote.Location = new Point(4, 253);
            dataGridJeuSoumisVote.Margin = new Padding(4, 3, 4, 3);
            dataGridJeuSoumisVote.Name = "dataGridJeuSoumisVote";
            dataGridJeuSoumisVote.ReadOnly = true;
            dataGridJeuSoumisVote.RowHeadersWidth = 62;
            dataGridJeuSoumisVote.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridJeuSoumisVote.Size = new Size(919, 212);
            dataGridJeuSoumisVote.TabIndex = 6;
            dataGridJeuSoumisVote.CellClick += DataGridJeuSoumisVote_CellClick;
            dataGridJeuSoumisVote.CellContentDoubleClick += DataGridJeuSoumisVote_CellContentDoubleClick;
            // 
            // UcJeuxSoumisVote
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MintCream;
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(2);
            Name = "UcJeuxSoumisVote";
            Size = new Size(1431, 610);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridClassement).EndInit();
            tableLayoutPanel4.ResumeLayout(false);
            panelForm.ResumeLayout(false);
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            panelButtons.ResumeLayout(false);
            panelButtons.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridJeuSoumisVote).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label label2;
        private TextBox textBoxRecherche;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panelForm;
        private TableLayoutPanel tableLayoutPanel;
        private Label labelTitre;
        private Label labelPlateforme;
        private Label labelDateDebutVote;
        private Panel panelButtons;
        private GroupBox groupBox1;
        private Button buttonAjouter;
        private Button buttonEffacer;
        private Button buttonSupprimer;
        private Label label1;
        private DateTimePicker dateTimePickerDateDebutVote;
        private Label labelDescription;
        private TextBox textBoxDescription;
        private DataGridView dataGridJeuSoumisVote;
        private ComboBox comboBoxPlateforme;
        private TableLayoutPanel tableLayoutPanel3;
        private DataGridView dataGridClassement;
        private Label labelClassement;
        private TableLayoutPanel tableLayoutPanel4;
        private Label label3;
        private DateTimePicker dateTimePickerDateFinVote;
        private ComboBox comboBoxJeu;
        private Button buttonModifier;
    }
}
