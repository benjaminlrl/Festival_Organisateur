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
            labelPostesJeu = new Label();
            textBoxNom = new TextBox();
            dataGridPostesJeu = new DataGridView();
            labelNom = new Label();
            dataGridJeux = new DataGridView();
            labelJeux = new Label();
            panelButtons = new Panel();
            groupBox1 = new GroupBox();
            label2 = new Label();
            buttonAjouter = new Button();
            buttonEffacer = new Button();
            textBoxRecherche = new TextBox();
            buttonModifier = new Button();
            buttonSupprimer = new Button();
            label1 = new Label();
            dataGridPlateformes = new DataGridView();
            tableLayoutPanel1 = new TableLayoutPanel();
            panelForm.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridPostesJeu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridJeux).BeginInit();
            panelButtons.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridPlateformes).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelForm
            // 
            panelForm.BackColor = Color.White;
            tableLayoutPanel1.SetColumnSpan(panelForm, 2);
            panelForm.Controls.Add(tableLayoutPanel);
            panelForm.Controls.Add(panelButtons);
            panelForm.Dock = DockStyle.Fill;
            panelForm.Location = new Point(3, 2);
            panelForm.Margin = new Padding(3, 2, 3, 2);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(916, 216);
            panelForm.TabIndex = 5;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 4;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 43.4065933F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.664835F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 297F));
            tableLayoutPanel.Controls.Add(labelPostesJeu, 3, 0);
            tableLayoutPanel.Controls.Add(textBoxNom, 0, 1);
            tableLayoutPanel.Controls.Add(dataGridPostesJeu, 3, 1);
            tableLayoutPanel.Controls.Add(labelNom, 0, 0);
            tableLayoutPanel.Controls.Add(dataGridJeux, 1, 1);
            tableLayoutPanel.Controls.Add(labelJeux, 1, 0);
            tableLayoutPanel.Location = new Point(7, 7);
            tableLayoutPanel.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 3;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 21F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 12F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 12F));
            tableLayoutPanel.Size = new Size(906, 109);
            tableLayoutPanel.TabIndex = 0;
            // 
            // labelPostesJeu
            // 
            labelPostesJeu.BackColor = Color.FromArgb(192, 192, 255);
            labelPostesJeu.Dock = DockStyle.Fill;
            labelPostesJeu.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPostesJeu.ForeColor = Color.FromArgb(0, 0, 64);
            labelPostesJeu.Location = new Point(609, 0);
            labelPostesJeu.Margin = new Padding(2, 0, 2, 0);
            labelPostesJeu.Name = "labelPostesJeu";
            labelPostesJeu.Size = new Size(295, 21);
            labelPostesJeu.TabIndex = 11;
            labelPostesJeu.Text = "Postes de jeu associés";
            labelPostesJeu.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxNom
            // 
            textBoxNom.Dock = DockStyle.Fill;
            textBoxNom.Location = new Point(3, 23);
            textBoxNom.Margin = new Padding(3, 2, 3, 2);
            textBoxNom.Name = "textBoxNom";
            textBoxNom.PlaceholderText = "Ex: Playstation 4";
            textBoxNom.Size = new Size(258, 23);
            textBoxNom.TabIndex = 0;
            // 
            // dataGridPostesJeu
            // 
            dataGridPostesJeu.AccessibleDescription = "Postes de jeu liés à la plateforme séléctionnée";
            dataGridPostesJeu.AllowUserToAddRows = false;
            dataGridPostesJeu.AllowUserToDeleteRows = false;
            dataGridPostesJeu.BackgroundColor = Color.White;
            dataGridPostesJeu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridPostesJeu.Dock = DockStyle.Fill;
            dataGridPostesJeu.Location = new Point(609, 23);
            dataGridPostesJeu.Margin = new Padding(2);
            dataGridPostesJeu.Name = "dataGridPostesJeu";
            dataGridPostesJeu.ReadOnly = true;
            dataGridPostesJeu.RowHeadersWidth = 62;
            tableLayoutPanel.SetRowSpan(dataGridPostesJeu, 2);
            dataGridPostesJeu.Size = new Size(295, 84);
            dataGridPostesJeu.TabIndex = 7;
            dataGridPostesJeu.CellDoubleClick += DataGridPostesJeu_CellDoubleClick;
            // 
            // labelNom
            // 
            labelNom.AutoSize = true;
            labelNom.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelNom.Location = new Point(3, 0);
            labelNom.Name = "labelNom";
            labelNom.Size = new Size(152, 17);
            labelNom.TabIndex = 6;
            labelNom.Text = "Nom de la plateforme :";
            // 
            // dataGridJeux
            // 
            dataGridJeux.AccessibleDescription = "Jeux associés à la plateforme";
            dataGridJeux.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridJeux.BackgroundColor = Color.White;
            dataGridJeux.BorderStyle = BorderStyle.None;
            tableLayoutPanel.SetColumnSpan(dataGridJeux, 2);
            dataGridJeux.Dock = DockStyle.Fill;
            dataGridJeux.Location = new Point(267, 23);
            dataGridJeux.Margin = new Padding(3, 2, 3, 2);
            dataGridJeux.Name = "dataGridJeux";
            dataGridJeux.ReadOnly = true;
            dataGridJeux.RowHeadersWidth = 62;
            tableLayoutPanel.SetRowSpan(dataGridJeux, 2);
            dataGridJeux.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridJeux.Size = new Size(337, 84);
            dataGridJeux.TabIndex = 9;
            dataGridJeux.CellContentDoubleClick += dataGridJeux_CellContentDoubleClick;
            // 
            // labelJeux
            // 
            labelJeux.BackColor = Color.FromArgb(192, 192, 255);
            tableLayoutPanel.SetColumnSpan(labelJeux, 2);
            labelJeux.Dock = DockStyle.Fill;
            labelJeux.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelJeux.ForeColor = Color.FromArgb(0, 0, 64);
            labelJeux.Location = new Point(266, 0);
            labelJeux.Margin = new Padding(2, 0, 2, 0);
            labelJeux.Name = "labelJeux";
            labelJeux.Size = new Size(339, 21);
            labelJeux.TabIndex = 10;
            labelJeux.Text = "Jeux associés";
            labelJeux.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(groupBox1);
            panelButtons.Controls.Add(label1);
            panelButtons.Location = new Point(7, 121);
            panelButtons.Margin = new Padding(3, 2, 3, 2);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(889, 92);
            panelButtons.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(buttonAjouter);
            groupBox1.Controls.Add(buttonEffacer);
            groupBox1.Controls.Add(textBoxRecherche);
            groupBox1.Controls.Add(buttonModifier);
            groupBox1.Controls.Add(buttonSupprimer);
            groupBox1.Location = new Point(0, 8);
            groupBox1.Margin = new Padding(2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2);
            groupBox1.Size = new Size(699, 82);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "⚡ Actions";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(33, 54);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(89, 20);
            label2.TabIndex = 1;
            label2.Text = "Recherche :";
            // 
            // buttonAjouter
            // 
            buttonAjouter.AccessibleDescription = "Permet d'ajouter une plateforme";
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
            // buttonEffacer
            // 
            buttonEffacer.AccessibleDescription = "Vide le champ du formulaire";
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
            // textBoxRecherche
            // 
            textBoxRecherche.Location = new Point(129, 55);
            textBoxRecherche.Margin = new Padding(2);
            textBoxRecherche.Name = "textBoxRecherche";
            textBoxRecherche.Size = new Size(512, 23);
            textBoxRecherche.TabIndex = 0;
            textBoxRecherche.TextChanged += TextBoxRecherche_TextChanged;
            // 
            // buttonModifier
            // 
            buttonModifier.AccessibleDescription = "Permet de modifier une plateforme";
            buttonModifier.BackColor = Color.FromArgb(33, 150, 243);
            buttonModifier.FlatAppearance.BorderSize = 0;
            buttonModifier.FlatStyle = FlatStyle.Flat;
            buttonModifier.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonModifier.ForeColor = Color.White;
            buttonModifier.Location = new Point(329, 15);
            buttonModifier.Margin = new Padding(3, 2, 3, 2);
            buttonModifier.Name = "buttonModifier";
            buttonModifier.Size = new Size(126, 27);
            buttonModifier.TabIndex = 4;
            buttonModifier.Text = "✏️    Modifier";
            buttonModifier.UseVisualStyleBackColor = false;
            buttonModifier.Click += ButtonModifier_Click;
            // 
            // buttonSupprimer
            // 
            buttonSupprimer.AccessibleDescription = "Permet de supprimer une plateforme";
            buttonSupprimer.BackColor = Color.FromArgb(244, 67, 54);
            buttonSupprimer.FlatAppearance.BorderSize = 0;
            buttonSupprimer.FlatStyle = FlatStyle.Flat;
            buttonSupprimer.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonSupprimer.ForeColor = Color.White;
            buttonSupprimer.Location = new Point(469, 15);
            buttonSupprimer.Margin = new Padding(3, 2, 3, 2);
            buttonSupprimer.Name = "buttonSupprimer";
            buttonSupprimer.Size = new Size(141, 27);
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
            // dataGridPlateformes
            // 
            dataGridPlateformes.AccessibleDescription = "Toutes les plateformes enregistrées dans la base de données";
            dataGridPlateformes.AllowUserToAddRows = false;
            dataGridPlateformes.AllowUserToDeleteRows = false;
            dataGridPlateformes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridPlateformes.BackgroundColor = Color.White;
            dataGridPlateformes.BorderStyle = BorderStyle.None;
            dataGridPlateformes.ColumnHeadersHeight = 34;
            dataGridPlateformes.Dock = DockStyle.Fill;
            dataGridPlateformes.Location = new Point(3, 222);
            dataGridPlateformes.Margin = new Padding(3, 2, 3, 2);
            dataGridPlateformes.Name = "dataGridPlateformes";
            dataGridPlateformes.ReadOnly = true;
            dataGridPlateformes.RowHeadersWidth = 62;
            dataGridPlateformes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridPlateformes.Size = new Size(632, 204);
            dataGridPlateformes.TabIndex = 6;
            dataGridPlateformes.CellClick += DataGridPlateformes_CellClick;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 69.2895355F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.7104664F));
            tableLayoutPanel1.Controls.Add(panelForm, 0, 0);
            tableLayoutPanel1.Controls.Add(dataGridPlateformes, 0, 1);
            tableLayoutPanel1.Location = new Point(2, 2);
            tableLayoutPanel1.Margin = new Padding(2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 51.5406151F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 48.4593849F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 12F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 12F));
            tableLayoutPanel1.Size = new Size(922, 428);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // UcPlateformes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(128, 128, 255);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(2);
            Name = "UcPlateformes";
            Size = new Size(934, 432);
            panelForm.ResumeLayout(false);
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridPostesJeu).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridJeux).EndInit();
            panelButtons.ResumeLayout(false);
            panelButtons.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridPlateformes).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelForm;
        private TableLayoutPanel tableLayoutPanel;
        private TextBox textBoxNom;
        private Label labelNom;
        private Panel panelButtons;
        private GroupBox groupBox1;
        private Button buttonAjouter;
        private Button buttonEffacer;
        private Button buttonModifier;
        private Button buttonSupprimer;
        private Label label1;
        private DataGridView dataGridPlateformes;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label2;
        private TextBox textBoxRecherche;
        private DataGridView dataGridPostesJeu;
        private DataGridView dataGridJeux;
        private Label labelJeux;
        private Label labelPostesJeu;
    }
}
