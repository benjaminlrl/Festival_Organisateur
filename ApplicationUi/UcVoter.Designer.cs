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
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
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
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
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
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(131, 30);
            label2.TabIndex = 1;
            label2.Text = "Recherche :";
            // 
            // textBoxRecherche
            // 
            textBoxRecherche.Location = new Point(218, 3);
            textBoxRecherche.Name = "textBoxRecherche";
            textBoxRecherche.Size = new Size(928, 31);
            textBoxRecherche.TabIndex = 0;
            textBoxRecherche.TextChanged += textBoxRecherche_TextChanged;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.7640457F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 81.2359543F));
            tableLayoutPanel2.Controls.Add(label2, 0, 0);
            tableLayoutPanel2.Controls.Add(textBoxRecherche, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Bottom;
            tableLayoutPanel2.Location = new Point(3, 276);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(1151, 32);
            tableLayoutPanel2.TabIndex = 9;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67.49249F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(panelForm, 0, 0);
            tableLayoutPanel1.Controls.Add(dataGridJeux, 0, 2);
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 83.80567F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.1943321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 310F));
            tableLayoutPanel1.Size = new Size(1157, 622);
            tableLayoutPanel1.TabIndex = 8;
            // 
            // panelForm
            // 
            panelForm.BackColor = Color.White;
            panelForm.Controls.Add(tableLayoutPanel);
            panelForm.Controls.Add(panelButtons);
            panelForm.Location = new Point(4, 3);
            panelForm.Margin = new Padding(4, 3, 4, 3);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(1149, 253);
            panelForm.TabIndex = 5;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 4;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 239F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 279F));
            tableLayoutPanel.Controls.Add(textBoxPegi, 1, 3);
            tableLayoutPanel.Controls.Add(comboBoxPlateforme, 2, 1);
            tableLayoutPanel.Controls.Add(labelPegi, 1, 2);
            tableLayoutPanel.Controls.Add(textBoxTitre, 0, 1);
            tableLayoutPanel.Controls.Add(labelPlateforme, 2, 0);
            tableLayoutPanel.Controls.Add(textBoxEditeur, 0, 3);
            tableLayoutPanel.Controls.Add(labelEditeur, 0, 2);
            tableLayoutPanel.Controls.Add(labelTitre, 0, 0);
            tableLayoutPanel.Controls.Add(labelDescription, 1, 0);
            tableLayoutPanel.Controls.Add(textBoxDescription, 1, 1);
            tableLayoutPanel.Controls.Add(labelDateSortie, 3, 0);
            tableLayoutPanel.Controls.Add(dateTimePickerDateSortie, 3, 1);
            tableLayoutPanel.Location = new Point(10, 12);
            tableLayoutPanel.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 5;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 43F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.Size = new Size(1129, 143);
            tableLayoutPanel.TabIndex = 0;
            // 
            // textBoxPegi
            // 
            textBoxPegi.Dock = DockStyle.Fill;
            textBoxPegi.Enabled = false;
            textBoxPegi.Location = new Point(308, 108);
            textBoxPegi.Name = "textBoxPegi";
            textBoxPegi.PlaceholderText = "3";
            textBoxPegi.Size = new Size(299, 31);
            textBoxPegi.TabIndex = 30;
            // 
            // comboBoxPlateforme
            // 
            comboBoxPlateforme.Dock = DockStyle.Fill;
            comboBoxPlateforme.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPlateforme.Location = new Point(614, 39);
            comboBoxPlateforme.Margin = new Padding(4);
            comboBoxPlateforme.Name = "comboBoxPlateforme";
            tableLayoutPanel.SetRowSpan(comboBoxPlateforme, 3);
            comboBoxPlateforme.Size = new Size(231, 33);
            comboBoxPlateforme.TabIndex = 29;
            // 
            // labelPegi
            // 
            labelPegi.AutoSize = true;
            labelPegi.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelPegi.Location = new Point(309, 78);
            labelPegi.Margin = new Padding(4, 0, 4, 0);
            labelPegi.Name = "labelPegi";
            labelPegi.Size = new Size(63, 27);
            labelPegi.TabIndex = 27;
            labelPegi.Text = "Pegi :";
            // 
            // textBoxTitre
            // 
            textBoxTitre.Dock = DockStyle.Fill;
            textBoxTitre.Enabled = false;
            textBoxTitre.Location = new Point(4, 38);
            textBoxTitre.Margin = new Padding(4, 3, 4, 3);
            textBoxTitre.Name = "textBoxTitre";
            textBoxTitre.PlaceholderText = "Ex: Mariokart 8";
            textBoxTitre.Size = new Size(297, 31);
            textBoxTitre.TabIndex = 0;
            // 
            // labelPlateforme
            // 
            labelPlateforme.AutoSize = true;
            labelPlateforme.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelPlateforme.Location = new Point(614, 0);
            labelPlateforme.Margin = new Padding(4, 0, 4, 0);
            labelPlateforme.Name = "labelPlateforme";
            labelPlateforme.Size = new Size(128, 28);
            labelPlateforme.TabIndex = 21;
            labelPlateforme.Text = "Plateforme :";
            // 
            // textBoxEditeur
            // 
            textBoxEditeur.Dock = DockStyle.Fill;
            textBoxEditeur.Enabled = false;
            textBoxEditeur.Location = new Point(3, 108);
            textBoxEditeur.Name = "textBoxEditeur";
            textBoxEditeur.PlaceholderText = "Editeur";
            textBoxEditeur.Size = new Size(299, 31);
            textBoxEditeur.TabIndex = 23;
            // 
            // labelEditeur
            // 
            labelEditeur.AutoSize = true;
            labelEditeur.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelEditeur.Location = new Point(4, 78);
            labelEditeur.Margin = new Padding(4, 0, 4, 0);
            labelEditeur.Name = "labelEditeur";
            labelEditeur.Size = new Size(80, 27);
            labelEditeur.TabIndex = 8;
            labelEditeur.Text = "Editeur";
            // 
            // labelTitre
            // 
            labelTitre.AutoSize = true;
            labelTitre.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelTitre.Location = new Point(4, 0);
            labelTitre.Margin = new Padding(4, 0, 4, 0);
            labelTitre.Name = "labelTitre";
            labelTitre.Size = new Size(68, 28);
            labelTitre.TabIndex = 6;
            labelTitre.Text = "Titre :";
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelDescription.Location = new Point(309, 0);
            labelDescription.Margin = new Padding(4, 0, 4, 0);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(132, 28);
            labelDescription.TabIndex = 26;
            labelDescription.Text = "Description :";
            // 
            // textBoxDescription
            // 
            textBoxDescription.Dock = DockStyle.Fill;
            textBoxDescription.Enabled = false;
            textBoxDescription.Location = new Point(309, 38);
            textBoxDescription.Margin = new Padding(4, 3, 4, 3);
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.PlaceholderText = "Ex: Mariokart 8 est un jeu de courses";
            textBoxDescription.Size = new Size(297, 31);
            textBoxDescription.TabIndex = 25;
            // 
            // labelDateSortie
            // 
            labelDateSortie.AutoSize = true;
            labelDateSortie.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelDateSortie.Location = new Point(853, 0);
            labelDateSortie.Margin = new Padding(4, 0, 4, 0);
            labelDateSortie.Name = "labelDateSortie";
            labelDateSortie.Size = new Size(158, 28);
            labelDateSortie.TabIndex = 19;
            labelDateSortie.Text = "Date de sortie :";
            // 
            // dateTimePickerDateSortie
            // 
            dateTimePickerDateSortie.Dock = DockStyle.Fill;
            dateTimePickerDateSortie.Enabled = false;
            dateTimePickerDateSortie.Format = DateTimePickerFormat.Short;
            dateTimePickerDateSortie.Location = new Point(852, 38);
            dateTimePickerDateSortie.Name = "dateTimePickerDateSortie";
            dateTimePickerDateSortie.Size = new Size(274, 31);
            dateTimePickerDateSortie.TabIndex = 24;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(groupBox1);
            panelButtons.Controls.Add(label1);
            panelButtons.Location = new Point(10, 155);
            panelButtons.Margin = new Padding(4, 3, 4, 3);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(879, 82);
            panelButtons.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonVoter);
            groupBox1.Controls.Add(buttonEffacer);
            groupBox1.Controls.Add(buttonSupprimer);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(879, 82);
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
            buttonVoter.Location = new Point(231, 25);
            buttonVoter.Margin = new Padding(4, 3, 4, 3);
            buttonVoter.Name = "buttonVoter";
            buttonVoter.Size = new Size(305, 45);
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
            buttonEffacer.Location = new Point(40, 25);
            buttonEffacer.Margin = new Padding(4, 3, 4, 3);
            buttonEffacer.Name = "buttonEffacer";
            buttonEffacer.Size = new Size(150, 45);
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
            buttonSupprimer.Location = new Point(567, 25);
            buttonSupprimer.Margin = new Padding(4, 3, 4, 3);
            buttonSupprimer.Name = "buttonSupprimer";
            buttonSupprimer.Size = new Size(305, 45);
            buttonSupprimer.TabIndex = 5;
            buttonSupprimer.Text = "🗑️    Supprimer mon vote";
            buttonSupprimer.UseVisualStyleBackColor = false;
            buttonSupprimer.Click += buttonSupprimer_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 25);
            label1.TabIndex = 6;
            // 
            // dataGridJeux
            // 
            dataGridJeux.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridJeux.BackgroundColor = Color.White;
            dataGridJeux.BorderStyle = BorderStyle.None;
            dataGridJeux.ColumnHeadersHeight = 34;
            dataGridJeux.Dock = DockStyle.Fill;
            dataGridJeux.Location = new Point(4, 314);
            dataGridJeux.Margin = new Padding(4, 3, 4, 3);
            dataGridJeux.Name = "dataGridJeux";
            dataGridJeux.ReadOnly = true;
            dataGridJeux.RowHeadersWidth = 62;
            dataGridJeux.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridJeux.Size = new Size(1149, 305);
            dataGridJeux.TabIndex = 6;
            dataGridJeux.CellClick += dataGridJeux_CellClick;
            // 
            // UcVoter
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MintCream;
            Controls.Add(tableLayoutPanel1);
            Name = "UcVoter";
            Size = new Size(1186, 644);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panelForm.ResumeLayout(false);
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
        private TableLayoutPanel tableLayoutPanel2;
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
    }
}
