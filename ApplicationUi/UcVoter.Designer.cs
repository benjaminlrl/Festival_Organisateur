namespace ApplicationUi
{
    partial class UcVoter
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
            dataGridJeuxVotes = new DataGridView();
            tableLayoutPanel4 = new TableLayoutPanel();
            labelNbVotes = new Label();
            labelVotes = new Label();
            panelForm = new Panel();
            tableLayoutPanel = new TableLayoutPanel();
            textBoxPegi = new TextBox();
            comboBoxPlateforme = new ComboBox();
            labelPegi = new Label();
            textBoxTitre = new TextBox();
            labelPlateforme = new Label();
            textBoxEditeur = new TextBox();
            labelEditeur = new Label();
            labelTitre = new Label();
            labelDescription = new Label();
            textBoxDescription = new TextBox();
            labelDateSortie = new Label();
            dateTimePickerDateSortie = new DateTimePicker();
            panelButtons = new Panel();
            groupBox1 = new GroupBox();
            buttonVoter = new Button();
            buttonEffacer = new Button();
            buttonSupprimer = new Button();
            label1 = new Label();
            dataGridJeux = new DataGridView();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridJeuxVotes).BeginInit();
            tableLayoutPanel4.SuspendLayout();
            panelForm.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            panelButtons.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridJeux).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(35, 166);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(89, 20);
            label2.TabIndex = 1;
            label2.Text = "Recherche :";
            // 
            // textBoxRecherche
            // 
            textBoxRecherche.Font = new Font("Segoe UI", 11F);
            textBoxRecherche.Location = new Point(131, 165);
            textBoxRecherche.Margin = new Padding(2, 2, 2, 2);
            textBoxRecherche.Name = "textBoxRecherche";
            textBoxRecherche.PlaceholderText = "Ex: Mari...";
            textBoxRecherche.Size = new Size(649, 27);
            textBoxRecherche.TabIndex = 0;
            textBoxRecherche.TextChanged += textBoxRecherche_TextChanged;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67.49249F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 6F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 403F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 2, 0);
            tableLayoutPanel1.Controls.Add(panelForm, 0, 0);
            tableLayoutPanel1.Controls.Add(dataGridJeux, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(2, 2, 2, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 45.8974342F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 54.1025658F));
            tableLayoutPanel1.Size = new Size(1210, 468);
            tableLayoutPanel1.TabIndex = 8;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(dataGridJeuxVotes, 0, 1);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel4, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(809, 2);
            tableLayoutPanel3.Margin = new Padding(2, 2, 2, 2);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 14.6788988F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 85.3211F));
            tableLayoutPanel3.Size = new Size(399, 210);
            tableLayoutPanel3.TabIndex = 10;
            // 
            // dataGridJeuxVotes
            // 
            dataGridJeuxVotes.AccessibleDescription = "Jeux déjà votés par l'utilisateur";
            dataGridJeuxVotes.AllowUserToAddRows = false;
            dataGridJeuxVotes.AllowUserToDeleteRows = false;
            dataGridJeuxVotes.BackgroundColor = Color.White;
            dataGridJeuxVotes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridJeuxVotes.Dock = DockStyle.Fill;
            dataGridJeuxVotes.Location = new Point(2, 32);
            dataGridJeuxVotes.Margin = new Padding(2, 2, 2, 2);
            dataGridJeuxVotes.Name = "dataGridJeuxVotes";
            dataGridJeuxVotes.ReadOnly = true;
            dataGridJeuxVotes.RowHeadersWidth = 62;
            dataGridJeuxVotes.Size = new Size(395, 176);
            dataGridJeuxVotes.TabIndex = 7;
            dataGridJeuxVotes.CellClick += dataGridJeuxVotes_CellClick;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 3;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 68F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 165F));
            tableLayoutPanel4.Controls.Add(labelNbVotes, 2, 0);
            tableLayoutPanel4.Controls.Add(labelVotes, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(2, 2);
            tableLayoutPanel4.Margin = new Padding(2, 2, 2, 2);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Size = new Size(395, 26);
            tableLayoutPanel4.TabIndex = 8;
            // 
            // labelNbVotes
            // 
            labelNbVotes.BackColor = Color.YellowGreen;
            labelNbVotes.Dock = DockStyle.Fill;
            labelNbVotes.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelNbVotes.ForeColor = Color.FromArgb(0, 0, 64);
            labelNbVotes.Location = new Point(232, 0);
            labelNbVotes.Margin = new Padding(2, 0, 2, 0);
            labelNbVotes.Name = "labelNbVotes";
            labelNbVotes.Size = new Size(161, 26);
            labelNbVotes.TabIndex = 12;
            labelNbVotes.Text = "x votes restants";
            labelNbVotes.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelVotes
            // 
            labelVotes.BackColor = Color.FromArgb(192, 192, 255);
            labelVotes.Dock = DockStyle.Fill;
            labelVotes.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelVotes.ForeColor = Color.FromArgb(0, 0, 64);
            labelVotes.Location = new Point(2, 0);
            labelVotes.Margin = new Padding(2, 0, 2, 0);
            labelVotes.Name = "labelVotes";
            labelVotes.Size = new Size(158, 26);
            labelVotes.TabIndex = 11;
            labelVotes.Text = "Jeux votés";
            labelVotes.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelForm
            // 
            panelForm.BackColor = Color.White;
            panelForm.Controls.Add(label2);
            panelForm.Controls.Add(tableLayoutPanel);
            panelForm.Controls.Add(textBoxRecherche);
            panelForm.Controls.Add(panelButtons);
            panelForm.Dock = DockStyle.Fill;
            panelForm.Location = new Point(3, 2);
            panelForm.Margin = new Padding(3, 2, 3, 2);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(795, 210);
            panelForm.TabIndex = 5;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 4;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 167F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 196F));
            tableLayoutPanel.Controls.Add(textBoxPegi, 2, 3);
            tableLayoutPanel.Controls.Add(comboBoxPlateforme, 2, 1);
            tableLayoutPanel.Controls.Add(labelPegi, 2, 2);
            tableLayoutPanel.Controls.Add(textBoxTitre, 0, 1);
            tableLayoutPanel.Controls.Add(labelPlateforme, 2, 0);
            tableLayoutPanel.Controls.Add(textBoxEditeur, 0, 3);
            tableLayoutPanel.Controls.Add(labelEditeur, 0, 2);
            tableLayoutPanel.Controls.Add(labelTitre, 0, 0);
            tableLayoutPanel.Controls.Add(labelDescription, 1, 0);
            tableLayoutPanel.Controls.Add(textBoxDescription, 1, 1);
            tableLayoutPanel.Controls.Add(labelDateSortie, 3, 0);
            tableLayoutPanel.Controls.Add(dateTimePickerDateSortie, 3, 1);
            tableLayoutPanel.Location = new Point(7, 7);
            tableLayoutPanel.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 5;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 21F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 16F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 12F));
            tableLayoutPanel.Size = new Size(790, 86);
            tableLayoutPanel.TabIndex = 0;
            // 
            // textBoxPegi
            // 
            textBoxPegi.Dock = DockStyle.Fill;
            textBoxPegi.Enabled = false;
            textBoxPegi.Location = new Point(428, 65);
            textBoxPegi.Margin = new Padding(2, 2, 2, 2);
            textBoxPegi.Name = "textBoxPegi";
            textBoxPegi.PlaceholderText = "3";
            textBoxPegi.Size = new Size(163, 23);
            textBoxPegi.TabIndex = 30;
            // 
            // comboBoxPlateforme
            // 
            comboBoxPlateforme.Dock = DockStyle.Fill;
            comboBoxPlateforme.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPlateforme.Location = new Point(429, 23);
            comboBoxPlateforme.Margin = new Padding(3, 2, 3, 2);
            comboBoxPlateforme.Name = "comboBoxPlateforme";
            comboBoxPlateforme.Size = new Size(161, 23);
            comboBoxPlateforme.TabIndex = 29;
            comboBoxPlateforme.SelectedIndexChanged += comboBoxPlateforme_SelectedIndexChanged;
            // 
            // labelPegi
            // 
            labelPegi.AutoSize = true;
            labelPegi.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelPegi.Location = new Point(429, 47);
            labelPegi.Name = "labelPegi";
            labelPegi.Size = new Size(43, 16);
            labelPegi.TabIndex = 27;
            labelPegi.Text = "Pegi :";
            // 
            // textBoxTitre
            // 
            textBoxTitre.Dock = DockStyle.Fill;
            textBoxTitre.Enabled = false;
            textBoxTitre.Location = new Point(3, 23);
            textBoxTitre.Margin = new Padding(3, 2, 3, 2);
            textBoxTitre.Name = "textBoxTitre";
            textBoxTitre.PlaceholderText = "Ex: Mariokart 8";
            textBoxTitre.Size = new Size(207, 23);
            textBoxTitre.TabIndex = 0;
            // 
            // labelPlateforme
            // 
            labelPlateforme.AutoSize = true;
            labelPlateforme.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelPlateforme.Location = new Point(429, 0);
            labelPlateforme.Name = "labelPlateforme";
            labelPlateforme.Size = new Size(84, 17);
            labelPlateforme.TabIndex = 21;
            labelPlateforme.Text = "Plateforme :";
            // 
            // textBoxEditeur
            // 
            textBoxEditeur.Dock = DockStyle.Fill;
            textBoxEditeur.Enabled = false;
            textBoxEditeur.Location = new Point(2, 65);
            textBoxEditeur.Margin = new Padding(2, 2, 2, 2);
            textBoxEditeur.Name = "textBoxEditeur";
            textBoxEditeur.PlaceholderText = "Editeur";
            textBoxEditeur.Size = new Size(209, 23);
            textBoxEditeur.TabIndex = 23;
            // 
            // labelEditeur
            // 
            labelEditeur.AutoSize = true;
            labelEditeur.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelEditeur.Location = new Point(3, 47);
            labelEditeur.Name = "labelEditeur";
            labelEditeur.Size = new Size(52, 16);
            labelEditeur.TabIndex = 8;
            labelEditeur.Text = "Editeur";
            // 
            // labelTitre
            // 
            labelTitre.AutoSize = true;
            labelTitre.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelTitre.Location = new Point(3, 0);
            labelTitre.Name = "labelTitre";
            labelTitre.Size = new Size(45, 17);
            labelTitre.TabIndex = 6;
            labelTitre.Text = "Titre :";
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelDescription.Location = new Point(216, 0);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(87, 17);
            labelDescription.TabIndex = 26;
            labelDescription.Text = "Description :";
            // 
            // textBoxDescription
            // 
            textBoxDescription.Dock = DockStyle.Fill;
            textBoxDescription.Enabled = false;
            textBoxDescription.Location = new Point(216, 23);
            textBoxDescription.Margin = new Padding(3, 2, 3, 2);
            textBoxDescription.Multiline = true;
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.PlaceholderText = "Ex: Mariokart 8 est un jeu de courses";
            tableLayoutPanel.SetRowSpan(textBoxDescription, 3);
            textBoxDescription.Size = new Size(207, 63);
            textBoxDescription.TabIndex = 25;
            // 
            // labelDateSortie
            // 
            labelDateSortie.AutoSize = true;
            labelDateSortie.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelDateSortie.Location = new Point(596, 0);
            labelDateSortie.Name = "labelDateSortie";
            labelDateSortie.Size = new Size(103, 17);
            labelDateSortie.TabIndex = 19;
            labelDateSortie.Text = "Date de sortie :";
            // 
            // dateTimePickerDateSortie
            // 
            dateTimePickerDateSortie.Dock = DockStyle.Fill;
            dateTimePickerDateSortie.Enabled = false;
            dateTimePickerDateSortie.Format = DateTimePickerFormat.Short;
            dateTimePickerDateSortie.Location = new Point(595, 23);
            dateTimePickerDateSortie.Margin = new Padding(2, 2, 2, 2);
            dateTimePickerDateSortie.Name = "dateTimePickerDateSortie";
            dateTimePickerDateSortie.Size = new Size(193, 23);
            dateTimePickerDateSortie.TabIndex = 24;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(groupBox1);
            panelButtons.Controls.Add(label1);
            panelButtons.Location = new Point(7, 93);
            panelButtons.Margin = new Padding(3, 2, 3, 2);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(615, 49);
            panelButtons.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonVoter);
            groupBox1.Controls.Add(buttonEffacer);
            groupBox1.Controls.Add(buttonSupprimer);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Margin = new Padding(2, 2, 2, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2, 2, 2, 2);
            groupBox1.Size = new Size(615, 49);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "⚡ Actions";
            // 
            // buttonVoter
            // 
            buttonVoter.BackColor = Color.FromArgb(76, 175, 80);
            buttonVoter.FlatAppearance.BorderSize = 0;
            buttonVoter.FlatStyle = FlatStyle.Flat;
            buttonVoter.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonVoter.ForeColor = Color.White;
            buttonVoter.Location = new Point(162, 15);
            buttonVoter.Margin = new Padding(3, 2, 3, 2);
            buttonVoter.Name = "buttonVoter";
            buttonVoter.Size = new Size(214, 27);
            buttonVoter.TabIndex = 6;
            buttonVoter.Text = "➕  Voter";
            buttonVoter.UseVisualStyleBackColor = false;
            buttonVoter.Click += buttonVoter_Click;
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
            buttonEffacer.Click += buttonEffacer_Click;
            // 
            // buttonSupprimer
            // 
            buttonSupprimer.BackColor = Color.FromArgb(244, 67, 54);
            buttonSupprimer.FlatAppearance.BorderSize = 0;
            buttonSupprimer.FlatStyle = FlatStyle.Flat;
            buttonSupprimer.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonSupprimer.ForeColor = Color.White;
            buttonSupprimer.Location = new Point(397, 15);
            buttonSupprimer.Margin = new Padding(3, 2, 3, 2);
            buttonSupprimer.Name = "buttonSupprimer";
            buttonSupprimer.Size = new Size(214, 27);
            buttonSupprimer.TabIndex = 5;
            buttonSupprimer.Text = "🗑️    Supprimer mon vote";
            buttonSupprimer.UseVisualStyleBackColor = false;
            buttonSupprimer.Click += buttonSupprimer_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 6;
            // 
            // dataGridJeux
            // 
            dataGridJeux.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridJeux.BackgroundColor = Color.White;
            dataGridJeux.BorderStyle = BorderStyle.None;
            dataGridJeux.ColumnHeadersHeight = 34;
            dataGridJeux.Dock = DockStyle.Fill;
            dataGridJeux.Location = new Point(3, 216);
            dataGridJeux.Margin = new Padding(3, 2, 3, 2);
            dataGridJeux.Name = "dataGridJeux";
            dataGridJeux.ReadOnly = true;
            dataGridJeux.RowHeadersWidth = 62;
            dataGridJeux.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridJeux.Size = new Size(795, 250);
            dataGridJeux.TabIndex = 6;
            dataGridJeux.CellClick += dataGridJeux_CellClick;
            // 
            // UcVoter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MintCream;
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "UcVoter";
            Size = new Size(1210, 468);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridJeuxVotes).EndInit();
            tableLayoutPanel4.ResumeLayout(false);
            panelForm.ResumeLayout(false);
            panelForm.PerformLayout();
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            panelButtons.ResumeLayout(false);
            panelButtons.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridJeux).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label label2;
        private TextBox textBoxRecherche;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panelForm;
        private TableLayoutPanel tableLayoutPanel;
        private TextBox textBoxTitre;
        private Label labelTitre;
        private Label labelEditeur;
        private Label labelPlateforme;
        private Label labelDateSortie;
        private Panel panelButtons;
        private GroupBox groupBox1;
        private Button buttonVoter;
        private Button buttonEffacer;
        private Button buttonSupprimer;
        private Label label1;
        private TextBox textBoxEditeur;
        private DateTimePicker dateTimePickerDateSortie;
        private Label labelDescription;
        private TextBox textBoxDescription;
        private Label labelPegi;
        private DataGridView dataGridJeux;
        private TextBox textBoxPegi;
        private ComboBox comboBoxPlateforme;
        private TableLayoutPanel tableLayoutPanel3;
        private DataGridView dataGridJeuxVotes;
        private Label labelVotes;
        private TableLayoutPanel tableLayoutPanel4;
        private Label labelNbVotes;
    }
}