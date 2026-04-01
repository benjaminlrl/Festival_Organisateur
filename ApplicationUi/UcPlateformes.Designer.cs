namespace ApplicationUi
{
    partial class UcPlateformes
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
            tableLayoutPanel = new TableLayoutPanel();
            textBoxNom = new TextBox();
            labelNom = new Label();
            dataGridJeux = new DataGridView();
            labelJeux = new Label();
            panelButtons = new Panel();
            groupBox1 = new GroupBox();
            buttonAjouter = new Button();
            buttonEffacer = new Button();
            buttonModifier = new Button();
            buttonSupprimer = new Button();
            label1 = new Label();
            dataGridPlateformes = new DataGridView();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            label2 = new Label();
            textBoxRecherche = new TextBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            labelPostesJeu = new Label();
            dataGridPostesJeu = new DataGridView();
            panelForm.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridJeux).BeginInit();
            panelButtons.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridPlateformes).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridPostesJeu).BeginInit();
            SuspendLayout();
            // 
            // panelForm
            // 
            panelForm.BackColor = Color.White;
            panelForm.Controls.Add(tableLayoutPanel);
            panelForm.Controls.Add(panelButtons);
            panelForm.Dock = DockStyle.Fill;
            panelForm.Location = new Point(4, 4);
            panelForm.Margin = new Padding(4);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(904, 325);
            panelForm.TabIndex = 5;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 3;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32.6507378F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
            tableLayoutPanel.Controls.Add(textBoxNom, 0, 1);
            tableLayoutPanel.Controls.Add(labelNom, 0, 0);
            tableLayoutPanel.Controls.Add(dataGridJeux, 1, 1);
            tableLayoutPanel.Controls.Add(labelJeux, 1, 0);
            tableLayoutPanel.Location = new Point(10, 12);
            tableLayoutPanel.Margin = new Padding(4);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 3;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.Size = new Size(879, 224);
            tableLayoutPanel.TabIndex = 0;
            // 
            // textBoxNom
            // 
            textBoxNom.Location = new Point(4, 39);
            textBoxNom.Margin = new Padding(4);
            textBoxNom.Name = "textBoxNom";
            textBoxNom.PlaceholderText = "Ex: Playstation 4";
            textBoxNom.Size = new Size(285, 31);
            textBoxNom.TabIndex = 0;
            // 
            // labelNom
            // 
            labelNom.AutoSize = true;
            labelNom.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelNom.Location = new Point(4, 0);
            labelNom.Margin = new Padding(4, 0, 4, 0);
            labelNom.Name = "labelNom";
            labelNom.Size = new Size(232, 28);
            labelNom.TabIndex = 6;
            labelNom.Text = "Nom de la plateforme :";
            // 
            // dataGridJeux
            // 
            dataGridJeux.AccessibleDescription = "Jeux associés à la plateforme";
            dataGridJeux.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridJeux.BackgroundColor = Color.White;
            dataGridJeux.BorderStyle = BorderStyle.None;
            dataGridJeux.ColumnHeadersHeight = 34;
            tableLayoutPanel.SetColumnSpan(dataGridJeux, 2);
            dataGridJeux.Dock = DockStyle.Fill;
            dataGridJeux.Location = new Point(297, 38);
            dataGridJeux.Margin = new Padding(4, 3, 4, 3);
            dataGridJeux.Name = "dataGridJeux";
            dataGridJeux.ReadOnly = true;
            dataGridJeux.RowHeadersWidth = 62;
            tableLayoutPanel.SetRowSpan(dataGridJeux, 2);
            dataGridJeux.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridJeux.Size = new Size(578, 183);
            dataGridJeux.TabIndex = 9;
            // 
            // labelJeux
            // 
            labelJeux.BackColor = Color.FromArgb(192, 192, 255);
            tableLayoutPanel.SetColumnSpan(labelJeux, 2);
            labelJeux.Dock = DockStyle.Fill;
            labelJeux.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelJeux.ForeColor = Color.FromArgb(0, 0, 64);
            labelJeux.Location = new Point(296, 0);
            labelJeux.Name = "labelJeux";
            labelJeux.Size = new Size(580, 35);
            labelJeux.TabIndex = 10;
            labelJeux.Text = "Jeux associés";
            labelJeux.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(groupBox1);
            panelButtons.Controls.Add(label1);
            panelButtons.Location = new Point(10, 155);
            panelButtons.Margin = new Padding(4);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(879, 166);
            panelButtons.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonAjouter);
            groupBox1.Controls.Add(buttonEffacer);
            groupBox1.Controls.Add(buttonModifier);
            groupBox1.Controls.Add(buttonSupprimer);
            groupBox1.Location = new Point(0, 81);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(879, 82);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "⚡ Actions";
            // 
            // buttonAjouter
            // 
            buttonAjouter.AccessibleDescription = "Permet d'ajouter une plateforme";
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
            buttonEffacer.AccessibleDescription = "Vide le champ du formulaire";
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
            buttonEffacer.Text = " Effacer";
            buttonEffacer.UseVisualStyleBackColor = false;
            buttonEffacer.Click += buttonModifier_Click;
            // 
            // buttonModifier
            // 
            buttonModifier.AccessibleDescription = "Permet de modifier une plateforme";
            buttonModifier.BackColor = Color.FromArgb(33, 150, 243);
            buttonModifier.FlatAppearance.BorderSize = 0;
            buttonModifier.FlatStyle = FlatStyle.Flat;
            buttonModifier.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonModifier.ForeColor = Color.White;
            buttonModifier.Location = new Point(470, 25);
            buttonModifier.Margin = new Padding(4);
            buttonModifier.Name = "buttonModifier";
            buttonModifier.Size = new Size(180, 45);
            buttonModifier.TabIndex = 4;
            buttonModifier.Text = "✏️    Modifier";
            buttonModifier.UseVisualStyleBackColor = false;
            buttonModifier.Click += buttonAjouter_Click;
            // 
            // buttonSupprimer
            // 
            buttonSupprimer.AccessibleDescription = "Permet de supprimer une plateforme";
            buttonSupprimer.BackColor = Color.FromArgb(244, 67, 54);
            buttonSupprimer.FlatAppearance.BorderSize = 0;
            buttonSupprimer.FlatStyle = FlatStyle.Flat;
            buttonSupprimer.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonSupprimer.ForeColor = Color.White;
            buttonSupprimer.Location = new Point(670, 25);
            buttonSupprimer.Margin = new Padding(4);
            buttonSupprimer.Name = "buttonSupprimer";
            buttonSupprimer.Size = new Size(202, 45);
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
            label1.Size = new Size(0, 25);
            label1.TabIndex = 6;
            // 
            // dataGridPlateformes
            // 
            dataGridPlateformes.AccessibleDescription = "Toutes les plateformes enregistrées dans la base de données";
            dataGridPlateformes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridPlateformes.BackgroundColor = Color.White;
            dataGridPlateformes.BorderStyle = BorderStyle.None;
            dataGridPlateformes.ColumnHeadersHeight = 34;
            dataGridPlateformes.Dock = DockStyle.Fill;
            dataGridPlateformes.Location = new Point(4, 381);
            dataGridPlateformes.Margin = new Padding(4);
            dataGridPlateformes.Name = "dataGridPlateformes";
            dataGridPlateformes.ReadOnly = true;
            dataGridPlateformes.RowHeadersWidth = 62;
            dataGridPlateformes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridPlateformes.Size = new Size(904, 329);
            dataGridPlateformes.TabIndex = 6;
            dataGridPlateformes.CellClick += dataGridPlateformes_CellClick;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 69.2895355F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.7104664F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(panelForm, 0, 0);
            tableLayoutPanel1.Controls.Add(dataGridPlateformes, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 1, 0);
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 88.20375F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.7962465F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 336F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1317, 714);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.7640457F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 81.2359543F));
            tableLayoutPanel2.Controls.Add(label2, 0, 0);
            tableLayoutPanel2.Controls.Add(textBoxRecherche, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Bottom;
            tableLayoutPanel2.Location = new Point(3, 347);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(906, 27);
            tableLayoutPanel2.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(131, 27);
            label2.TabIndex = 1;
            label2.Text = "Recherche :";
            // 
            // textBoxRecherche
            // 
            textBoxRecherche.Location = new Point(173, 3);
            textBoxRecherche.Name = "textBoxRecherche";
            textBoxRecherche.Size = new Size(717, 31);
            textBoxRecherche.TabIndex = 0;
            textBoxRecherche.TextChanged += textBoxRecherche_TextChanged;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(labelPostesJeu, 0, 0);
            tableLayoutPanel3.Controls.Add(dataGridPostesJeu, 0, 1);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(915, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 14.6788988F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 85.3211F));
            tableLayoutPanel3.Size = new Size(399, 327);
            tableLayoutPanel3.TabIndex = 9;
            // 
            // labelPostesJeu
            // 
            labelPostesJeu.BackColor = Color.FromArgb(192, 192, 255);
            tableLayoutPanel3.SetColumnSpan(labelPostesJeu, 2);
            labelPostesJeu.Dock = DockStyle.Fill;
            labelPostesJeu.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPostesJeu.ForeColor = Color.FromArgb(0, 0, 64);
            labelPostesJeu.Location = new Point(3, 0);
            labelPostesJeu.Name = "labelPostesJeu";
            labelPostesJeu.Size = new Size(393, 48);
            labelPostesJeu.TabIndex = 11;
            labelPostesJeu.Text = "Postes de jeu associés";
            labelPostesJeu.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dataGridPostesJeu
            // 
            dataGridPostesJeu.AccessibleDescription = "Postes de jeu liés à la plateforme séléctionnée";
            dataGridPostesJeu.BackgroundColor = Color.White;
            dataGridPostesJeu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridPostesJeu.Dock = DockStyle.Fill;
            dataGridPostesJeu.Location = new Point(3, 51);
            dataGridPostesJeu.Name = "dataGridPostesJeu";
            dataGridPostesJeu.RowHeadersWidth = 62;
            dataGridPostesJeu.Size = new Size(393, 273);
            dataGridPostesJeu.TabIndex = 7;
            // 
            // UcPlateformes
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(128, 128, 255);
            Controls.Add(tableLayoutPanel1);
            Name = "UcPlateformes";
            Size = new Size(1334, 720);
            panelForm.ResumeLayout(false);
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridJeux).EndInit();
            panelButtons.ResumeLayout(false);
            panelButtons.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridPlateformes).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridPostesJeu).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelForm;
        private TableLayoutPanel tableLayoutPanel;
        private Label labelDescription;
        private Label labelSuperficie;
        private NumericUpDown numericUpDownCapaciteMaxi;
        private TextBox textBoxNom;
        private Label labelNom;
        private Label labelCapaciteMaxi;
        private NumericUpDown numericUpDownSuperficie;
        private TextBox textBoxDescription;
        private Panel panelButtons;
        private GroupBox groupBox1;
        private Button buttonAjouter;
        private Button buttonEffacer;
        private Button buttonModifier;
        private Button buttonSupprimer;
        private Label label1;
        private DataGridView dataGridPlateformes;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label2;
        private TextBox textBoxRecherche;
        private DataGridView dataGridPostesJeu;
        private DataGridView dataGridJeux;
        private Label labelJeux;
        private TableLayoutPanel tableLayoutPanel3;
        private Label labelPostesJeu;
    }
}
