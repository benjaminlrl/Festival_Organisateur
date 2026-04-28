namespace ApplicationUi
{
    partial class UcPostesDeJeu
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
            panelForm = new Panel();
            tableLayoutPanel3 = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            label2 = new Label();
            buttonAjouter = new Button();
            textBoxRecherche = new TextBox();
            buttonEffacer = new Button();
            buttonModifier = new Button();
            buttonSupprimer = new Button();
            tableLayoutPanel = new TableLayoutPanel();
            textBoxReference = new TextBox();
            labelReference = new Label();
            labelFonctionnel = new Label();
            flowLayoutPanelFonctionnel = new FlowLayoutPanel();
            radioButtonFonctionnelTrue = new RadioButton();
            radioButtonFonctionnelFalse = new RadioButton();
            labelPlateforme = new Label();
            comboBoxPlateforme = new ComboBox();
            labelEspace = new Label();
            comboBoxEspace = new ComboBox();
            labelStatutTournoi = new Label();
            dataGridTournois = new DataGridView();
            dataGridPostesJeu = new DataGridView();
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBoxStatsPostesJeu = new GroupBox();
            labelStatPostesJeuFonctionnels = new Label();
            labelStatPostesJeuTotal = new Label();
            labelTitreEspaces = new Label();
            panelForm.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            groupBox1.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            flowLayoutPanelFonctionnel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridTournois).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridPostesJeu).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            groupBoxStatsPostesJeu.SuspendLayout();
            SuspendLayout();
            // 
            // panelForm
            // 
            panelForm.BackColor = Color.White;
            panelForm.Controls.Add(tableLayoutPanel3);
            panelForm.Dock = DockStyle.Fill;
            panelForm.Location = new Point(3, 2);
            panelForm.Margin = new Padding(3, 2, 3, 2);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(679, 194);
            panelForm.TabIndex = 5;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 93.551796F));
            tableLayoutPanel3.Controls.Add(groupBox1, 0, 1);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Margin = new Padding(2);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 52.2471924F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 47.7528076F));
            tableLayoutPanel3.Size = new Size(679, 194);
            tableLayoutPanel3.TabIndex = 8;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(buttonAjouter);
            groupBox1.Controls.Add(textBoxRecherche);
            groupBox1.Controls.Add(buttonEffacer);
            groupBox1.Controls.Add(buttonModifier);
            groupBox1.Controls.Add(buttonSupprimer);
            groupBox1.Location = new Point(2, 103);
            groupBox1.Margin = new Padding(2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2);
            groupBox1.Size = new Size(615, 89);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "⚡ Actions";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(49, 61);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(89, 20);
            label2.TabIndex = 1;
            label2.Text = "Recherche :";
            // 
            // buttonAjouter
            // 
            buttonAjouter.BackColor = Color.FromArgb(76, 175, 80);
            buttonAjouter.FlatAppearance.BorderSize = 0;
            buttonAjouter.FlatStyle = FlatStyle.Flat;
            buttonAjouter.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonAjouter.ForeColor = Color.White;
            buttonAjouter.Location = new Point(189, 15);
            buttonAjouter.Margin = new Padding(3, 2, 3, 2);
            buttonAjouter.Name = "buttonAjouter";
            buttonAjouter.Size = new Size(105, 27);
            buttonAjouter.TabIndex = 6;
            buttonAjouter.Text = "➕  Ajouter";
            buttonAjouter.UseVisualStyleBackColor = false;
            buttonAjouter.Click += ButtonAjouter_Click;
            // 
            // textBoxRecherche
            // 
            textBoxRecherche.Location = new Point(145, 61);
            textBoxRecherche.Margin = new Padding(2);
            textBoxRecherche.Name = "textBoxRecherche";
            textBoxRecherche.Size = new Size(430, 23);
            textBoxRecherche.TabIndex = 0;
            textBoxRecherche.TextChanged += TextBoxRecherche_TextChanged;
            // 
            // buttonEffacer
            // 
            buttonEffacer.BackColor = Color.MediumPurple;
            buttonEffacer.FlatAppearance.BorderSize = 0;
            buttonEffacer.FlatStyle = FlatStyle.Flat;
            buttonEffacer.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonEffacer.ForeColor = Color.White;
            buttonEffacer.Location = new Point(49, 15);
            buttonEffacer.Margin = new Padding(3, 2, 3, 2);
            buttonEffacer.Name = "buttonEffacer";
            buttonEffacer.Size = new Size(105, 27);
            buttonEffacer.TabIndex = 3;
            buttonEffacer.Text = " Effacer";
            buttonEffacer.UseVisualStyleBackColor = false;
            buttonEffacer.Click += ButtonEffacer_Click;
            // 
            // buttonModifier
            // 
            buttonModifier.BackColor = Color.FromArgb(33, 150, 243);
            buttonModifier.FlatAppearance.BorderSize = 0;
            buttonModifier.FlatStyle = FlatStyle.Flat;
            buttonModifier.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonModifier.ForeColor = Color.White;
            buttonModifier.Location = new Point(310, 15);
            buttonModifier.Margin = new Padding(3, 2, 3, 2);
            buttonModifier.Name = "buttonModifier";
            buttonModifier.Size = new Size(124, 27);
            buttonModifier.TabIndex = 4;
            buttonModifier.Text = "✏️    Modifier";
            buttonModifier.UseVisualStyleBackColor = false;
            buttonModifier.Click += ButtonModifier_Click;
            // 
            // buttonSupprimer
            // 
            buttonSupprimer.BackColor = Color.FromArgb(244, 67, 54);
            buttonSupprimer.FlatAppearance.BorderSize = 0;
            buttonSupprimer.FlatStyle = FlatStyle.Flat;
            buttonSupprimer.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonSupprimer.ForeColor = Color.White;
            buttonSupprimer.Location = new Point(440, 15);
            buttonSupprimer.Margin = new Padding(3, 2, 3, 2);
            buttonSupprimer.Name = "buttonSupprimer";
            buttonSupprimer.Size = new Size(134, 27);
            buttonSupprimer.TabIndex = 5;
            buttonSupprimer.Text = "🗑️    Supprimer";
            buttonSupprimer.UseVisualStyleBackColor = false;
            buttonSupprimer.Click += ButtonSupprimer_Click;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 3;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 267F));
            tableLayoutPanel.Controls.Add(textBoxReference, 0, 1);
            tableLayoutPanel.Controls.Add(labelReference, 0, 0);
            tableLayoutPanel.Controls.Add(labelFonctionnel, 0, 2);
            tableLayoutPanel.Controls.Add(flowLayoutPanelFonctionnel, 0, 3);
            tableLayoutPanel.Controls.Add(labelPlateforme, 1, 0);
            tableLayoutPanel.Controls.Add(comboBoxPlateforme, 1, 1);
            tableLayoutPanel.Controls.Add(labelEspace, 1, 2);
            tableLayoutPanel.Controls.Add(comboBoxEspace, 1, 3);
            tableLayoutPanel.Controls.Add(labelStatutTournoi, 2, 0);
            tableLayoutPanel.Controls.Add(dataGridTournois, 2, 1);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(3, 2);
            tableLayoutPanel.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 4;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 21F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 16F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 12F));
            tableLayoutPanel.Size = new Size(673, 97);
            tableLayoutPanel.TabIndex = 0;
            // 
            // textBoxReference
            // 
            textBoxReference.Dock = DockStyle.Fill;
            textBoxReference.Location = new Point(3, 23);
            textBoxReference.Margin = new Padding(3, 2, 3, 2);
            textBoxReference.Name = "textBoxReference";
            textBoxReference.PlaceholderText = "Généré automatiquement";
            textBoxReference.ReadOnly = true;
            textBoxReference.Size = new Size(197, 23);
            textBoxReference.TabIndex = 0;
            // 
            // labelReference
            // 
            labelReference.AutoSize = true;
            labelReference.Dock = DockStyle.Fill;
            labelReference.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelReference.Location = new Point(3, 0);
            labelReference.Name = "labelReference";
            labelReference.Size = new Size(197, 21);
            labelReference.TabIndex = 6;
            labelReference.Text = "Référence :";
            // 
            // labelFonctionnel
            // 
            labelFonctionnel.AutoSize = true;
            labelFonctionnel.Dock = DockStyle.Fill;
            labelFonctionnel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelFonctionnel.Location = new Point(3, 47);
            labelFonctionnel.Name = "labelFonctionnel";
            labelFonctionnel.Size = new Size(197, 16);
            labelFonctionnel.TabIndex = 8;
            labelFonctionnel.Text = "Fonctionnel";
            // 
            // flowLayoutPanelFonctionnel
            // 
            flowLayoutPanelFonctionnel.Controls.Add(radioButtonFonctionnelTrue);
            flowLayoutPanelFonctionnel.Controls.Add(radioButtonFonctionnelFalse);
            flowLayoutPanelFonctionnel.Dock = DockStyle.Fill;
            flowLayoutPanelFonctionnel.Location = new Point(2, 65);
            flowLayoutPanelFonctionnel.Margin = new Padding(2);
            flowLayoutPanelFonctionnel.Name = "flowLayoutPanelFonctionnel";
            flowLayoutPanelFonctionnel.Size = new Size(199, 30);
            flowLayoutPanelFonctionnel.TabIndex = 18;
            // 
            // radioButtonFonctionnelTrue
            // 
            radioButtonFonctionnelTrue.AutoSize = true;
            radioButtonFonctionnelTrue.Location = new Point(2, 2);
            radioButtonFonctionnelTrue.Margin = new Padding(2);
            radioButtonFonctionnelTrue.Name = "radioButtonFonctionnelTrue";
            radioButtonFonctionnelTrue.Size = new Size(44, 19);
            radioButtonFonctionnelTrue.TabIndex = 1;
            radioButtonFonctionnelTrue.TabStop = true;
            radioButtonFonctionnelTrue.Text = "Oui";
            radioButtonFonctionnelTrue.UseVisualStyleBackColor = true;
            radioButtonFonctionnelTrue.CheckedChanged += RadioButtonFonctionnelTrue_CheckedChanged;
            // 
            // radioButtonFonctionnelFalse
            // 
            radioButtonFonctionnelFalse.AutoSize = true;
            radioButtonFonctionnelFalse.Location = new Point(50, 2);
            radioButtonFonctionnelFalse.Margin = new Padding(2);
            radioButtonFonctionnelFalse.Name = "radioButtonFonctionnelFalse";
            radioButtonFonctionnelFalse.Size = new Size(48, 19);
            radioButtonFonctionnelFalse.TabIndex = 2;
            radioButtonFonctionnelFalse.TabStop = true;
            radioButtonFonctionnelFalse.Text = "Non";
            radioButtonFonctionnelFalse.UseVisualStyleBackColor = true;
            radioButtonFonctionnelFalse.CheckedChanged += RadioButtonFonctionnelFalse_CheckedChanged;
            // 
            // labelPlateforme
            // 
            labelPlateforme.AutoSize = true;
            labelPlateforme.Dock = DockStyle.Fill;
            labelPlateforme.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelPlateforme.Location = new Point(206, 0);
            labelPlateforme.Name = "labelPlateforme";
            labelPlateforme.Size = new Size(197, 21);
            labelPlateforme.TabIndex = 21;
            labelPlateforme.Text = "Plateforme :";
            // 
            // comboBoxPlateforme
            // 
            comboBoxPlateforme.Dock = DockStyle.Fill;
            comboBoxPlateforme.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPlateforme.Location = new Point(206, 23);
            comboBoxPlateforme.Margin = new Padding(3, 2, 3, 2);
            comboBoxPlateforme.Name = "comboBoxPlateforme";
            comboBoxPlateforme.Size = new Size(197, 23);
            comboBoxPlateforme.TabIndex = 22;
            // 
            // labelEspace
            // 
            labelEspace.AutoSize = true;
            labelEspace.Dock = DockStyle.Fill;
            labelEspace.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelEspace.Location = new Point(206, 47);
            labelEspace.Name = "labelEspace";
            labelEspace.Size = new Size(197, 16);
            labelEspace.TabIndex = 19;
            labelEspace.Text = "Espace / Lieu :";
            // 
            // comboBoxEspace
            // 
            comboBoxEspace.Dock = DockStyle.Fill;
            comboBoxEspace.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEspace.Location = new Point(206, 65);
            comboBoxEspace.Margin = new Padding(3, 2, 3, 2);
            comboBoxEspace.Name = "comboBoxEspace";
            comboBoxEspace.Size = new Size(197, 23);
            comboBoxEspace.TabIndex = 20;
            // 
            // labelStatutTournoi
            // 
            labelStatutTournoi.BackColor = Color.FromArgb(255, 224, 192);
            labelStatutTournoi.Dock = DockStyle.Fill;
            labelStatutTournoi.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelStatutTournoi.ForeColor = Color.Chocolate;
            labelStatutTournoi.Location = new Point(409, 0);
            labelStatutTournoi.Name = "labelStatutTournoi";
            labelStatutTournoi.Size = new Size(261, 21);
            labelStatutTournoi.TabIndex = 23;
            labelStatutTournoi.Text = "Tournoi en cours";
            labelStatutTournoi.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dataGridTournois
            // 
            dataGridTournois.AllowUserToAddRows = false;
            dataGridTournois.AllowUserToDeleteRows = false;
            dataGridTournois.AllowUserToOrderColumns = true;
            dataGridTournois.BackgroundColor = Color.White;
            dataGridTournois.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridTournois.Dock = DockStyle.Fill;
            dataGridTournois.Location = new Point(408, 23);
            dataGridTournois.Margin = new Padding(2);
            dataGridTournois.Name = "dataGridTournois";
            dataGridTournois.ReadOnly = true;
            dataGridTournois.RowHeadersWidth = 62;
            tableLayoutPanel.SetRowSpan(dataGridTournois, 3);
            dataGridTournois.Size = new Size(263, 72);
            dataGridTournois.TabIndex = 24;
            dataGridTournois.CellContentDoubleClick += DataGridTournois_CellContentDoubleClick;
            // 
            // dataGridPostesJeu
            // 
            dataGridPostesJeu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridPostesJeu.BackgroundColor = Color.White;
            dataGridPostesJeu.BorderStyle = BorderStyle.None;
            dataGridPostesJeu.ColumnHeadersHeight = 34;
            dataGridPostesJeu.Dock = DockStyle.Fill;
            dataGridPostesJeu.Location = new Point(3, 200);
            dataGridPostesJeu.Margin = new Padding(3, 2, 3, 2);
            dataGridPostesJeu.Name = "dataGridPostesJeu";
            dataGridPostesJeu.ReadOnly = true;
            dataGridPostesJeu.RowHeadersWidth = 62;
            dataGridPostesJeu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridPostesJeu.Size = new Size(679, 230);
            dataGridPostesJeu.TabIndex = 6;
            dataGridPostesJeu.CellClick += DataGridPostesJeu_CellClick;
            dataGridPostesJeu.CellDoubleClick += DataGridPostesJeu_CellContentDoubleClick;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 71.7717743F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.2282276F));
            tableLayoutPanel1.Controls.Add(groupBoxStatsPostesJeu, 1, 1);
            tableLayoutPanel1.Controls.Add(dataGridPostesJeu, 0, 1);
            tableLayoutPanel1.Controls.Add(panelForm, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 45.97222F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 54.02778F));
            tableLayoutPanel1.Size = new Size(955, 432);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // groupBoxStatsPostesJeu
            // 
            groupBoxStatsPostesJeu.BackColor = Color.White;
            groupBoxStatsPostesJeu.Controls.Add(labelStatPostesJeuFonctionnels);
            groupBoxStatsPostesJeu.Controls.Add(labelStatPostesJeuTotal);
            groupBoxStatsPostesJeu.Controls.Add(labelTitreEspaces);
            groupBoxStatsPostesJeu.Dock = DockStyle.Top;
            groupBoxStatsPostesJeu.Location = new Point(688, 201);
            groupBoxStatsPostesJeu.Name = "groupBoxStatsPostesJeu";
            groupBoxStatsPostesJeu.Size = new Size(264, 120);
            groupBoxStatsPostesJeu.TabIndex = 8;
            groupBoxStatsPostesJeu.TabStop = false;
            // 
            // labelStatPostesJeuFonctionnels
            // 
            labelStatPostesJeuFonctionnels.Font = new Font("Segoe UI", 9.75F);
            labelStatPostesJeuFonctionnels.Location = new Point(0, 85);
            labelStatPostesJeuFonctionnels.Name = "labelStatPostesJeuFonctionnels";
            labelStatPostesJeuFonctionnels.Size = new Size(252, 20);
            labelStatPostesJeuFonctionnels.TabIndex = 2;
            labelStatPostesJeuFonctionnels.Text = "Fonctionnels : 8";
            labelStatPostesJeuFonctionnels.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelStatPostesJeuTotal
            // 
            labelStatPostesJeuTotal.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            labelStatPostesJeuTotal.ForeColor = Color.FromArgb(255, 152, 0);
            labelStatPostesJeuTotal.Location = new Point(46, 40);
            labelStatPostesJeuTotal.Name = "labelStatPostesJeuTotal";
            labelStatPostesJeuTotal.Size = new Size(175, 45);
            labelStatPostesJeuTotal.TabIndex = 1;
            labelStatPostesJeuTotal.Text = "12";
            labelStatPostesJeuTotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelTitreEspaces
            // 
            labelTitreEspaces.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelTitreEspaces.ForeColor = Color.FromArgb(100, 100, 100);
            labelTitreEspaces.Location = new Point(0, 15);
            labelTitreEspaces.Name = "labelTitreEspaces";
            labelTitreEspaces.Size = new Size(252, 20);
            labelTitreEspaces.TabIndex = 0;
            labelTitreEspaces.Text = "🏢 POSTES DE JEU";
            labelTitreEspaces.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UcPostesDeJeu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Cornsilk;
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(2);
            Name = "UcPostesDeJeu";
            Size = new Size(955, 432);
            panelForm.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            flowLayoutPanelFonctionnel.ResumeLayout(false);
            flowLayoutPanelFonctionnel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridTournois).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridPostesJeu).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            groupBoxStatsPostesJeu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelForm;
        private TableLayoutPanel tableLayoutPanel;
        private Label labelReference;
        private Label labelFonctionnel;
        private GroupBox groupBox1;
        private Button buttonAjouter;
        private Button buttonEffacer;
        private Button buttonModifier;
        private Button buttonSupprimer;
        private DataGridView dataGridPostesJeu;
        private FlowLayoutPanel flowLayoutPanelFonctionnel;
        private RadioButton radioButtonFonctionnelTrue;
        private RadioButton radioButtonFonctionnelFalse;
        private Label labelEspace;
        private Label labelPlateforme;
        private ComboBox comboBoxEspace;
        private ComboBox comboBoxPlateforme;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBoxStatsPostesJeu;
        private Label labelStatPostesJeuFonctionnels;
        private Label labelStatPostesJeuTotal;
        private Label labelTitreEspaces;
        private Label label2;
        private TextBox textBoxRecherche;
        private DataGridView dataGridTournois;
        private Label labelStatutTournoi;
        private TableLayoutPanel tableLayoutPanel3;
        private TextBox textBoxReference;
    }
}
