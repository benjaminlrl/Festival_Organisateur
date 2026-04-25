namespace ApplicationUi
{
    partial class UcEspaces
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
            groupBox1 = new GroupBox();
            label1 = new Label();
            textBoxRecherche = new TextBox();
            buttonAjouter = new Button();
            buttonEffacer = new Button();
            buttonModifier = new Button();
            buttonSupprimer = new Button();
            labelSuperficie = new Label();
            textBoxNom = new TextBox();
            labelNom = new Label();
            labelCapaciteMaxi = new Label();
            dataGridEspaces = new DataGridView();
            numericUpDownSuperficie = new NumericUpDown();
            tableLayoutPanel = new TableLayoutPanel();
            dataGridTournois = new DataGridView();
            textBoxDescription = new TextBox();
            labelDescription = new Label();
            numericUpDownCapaciteMaxi = new NumericUpDown();
            labelStatutTournoi = new Label();
            panelForm = new Panel();
            tableLayoutPanelCRUD = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBoxStatsEspaces = new GroupBox();
            labelStatEspacesLibres = new Label();
            labelStatEspacesTotal = new Label();
            labelTitreEspaces = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            labelPostesJeu = new Label();
            dataGridPostesJeu = new DataGridView();
            process1 = new System.Diagnostics.Process();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridEspaces).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSuperficie).BeginInit();
            tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridTournois).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCapaciteMaxi).BeginInit();
            panelForm.SuspendLayout();
            tableLayoutPanelCRUD.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            groupBoxStatsEspaces.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridPostesJeu).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBoxRecherche);
            groupBox1.Controls.Add(buttonAjouter);
            groupBox1.Controls.Add(buttonEffacer);
            groupBox1.Controls.Add(buttonModifier);
            groupBox1.Controls.Add(buttonSupprimer);
            groupBox1.Location = new Point(2, 219);
            groupBox1.Margin = new Padding(2, 3, 2, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2, 3, 2, 3);
            groupBox1.Size = new Size(1250, 175);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "⚡ Actions";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(32, 104);
            label1.Name = "label1";
            label1.Size = new Size(131, 30);
            label1.TabIndex = 1;
            label1.Text = "Recherche :";
            // 
            // textBoxRecherche
            // 
            textBoxRecherche.Location = new Point(169, 105);
            textBoxRecherche.Name = "textBoxRecherche";
            textBoxRecherche.Size = new Size(1001, 31);
            textBoxRecherche.TabIndex = 0;
            textBoxRecherche.TextChanged += TextBoxRecherche_TextChanged;
            // 
            // buttonAjouter
            // 
            buttonAjouter.BackColor = Color.FromArgb(76, 175, 80);
            buttonAjouter.FlatAppearance.BorderSize = 0;
            buttonAjouter.FlatStyle = FlatStyle.Flat;
            buttonAjouter.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonAjouter.ForeColor = Color.White;
            buttonAjouter.Location = new Point(203, 20);
            buttonAjouter.Name = "buttonAjouter";
            buttonAjouter.Size = new Size(120, 36);
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
            buttonEffacer.Location = new Point(56, 20);
            buttonEffacer.Name = "buttonEffacer";
            buttonEffacer.Size = new Size(120, 36);
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
            buttonModifier.Location = new Point(354, 20);
            buttonModifier.Name = "buttonModifier";
            buttonModifier.Size = new Size(154, 36);
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
            buttonSupprimer.Location = new Point(536, 20);
            buttonSupprimer.Name = "buttonSupprimer";
            buttonSupprimer.Size = new Size(157, 36);
            buttonSupprimer.TabIndex = 5;
            buttonSupprimer.Text = "🗑️    Supprimer";
            buttonSupprimer.UseVisualStyleBackColor = false;
            buttonSupprimer.Click += ButtonSupprimer_Click;
            // 
            // labelSuperficie
            // 
            labelSuperficie.AutoSize = true;
            labelSuperficie.Dock = DockStyle.Fill;
            labelSuperficie.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelSuperficie.Location = new Point(364, 0);
            labelSuperficie.Name = "labelSuperficie";
            labelSuperficie.Size = new Size(294, 28);
            labelSuperficie.TabIndex = 14;
            labelSuperficie.Text = "Superficie en m² :*";
            // 
            // textBoxNom
            // 
            tableLayoutPanel.SetColumnSpan(textBoxNom, 2);
            textBoxNom.Location = new Point(3, 31);
            textBoxNom.Multiline = true;
            textBoxNom.Name = "textBoxNom";
            textBoxNom.PlaceholderText = "Ex: Espace playstation";
            textBoxNom.Size = new Size(203, 25);
            textBoxNom.TabIndex = 0;
            // 
            // labelNom
            // 
            labelNom.AutoSize = true;
            labelNom.Dock = DockStyle.Fill;
            labelNom.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelNom.Location = new Point(4, 0);
            labelNom.Margin = new Padding(4, 0, 4, 0);
            labelNom.Name = "labelNom";
            labelNom.Size = new Size(272, 28);
            labelNom.TabIndex = 6;
            labelNom.Text = "Nom de l'espace :*";
            // 
            // labelCapaciteMaxi
            // 
            labelCapaciteMaxi.AutoSize = true;
            labelCapaciteMaxi.Dock = DockStyle.Fill;
            labelCapaciteMaxi.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelCapaciteMaxi.Location = new Point(664, 0);
            labelCapaciteMaxi.Name = "labelCapaciteMaxi";
            labelCapaciteMaxi.Size = new Size(209, 28);
            labelCapaciteMaxi.TabIndex = 8;
            labelCapaciteMaxi.Text = "Capacité maximale :*";
            // 
            // dataGridEspaces
            // 
            dataGridEspaces.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridEspaces.BackgroundColor = Color.White;
            dataGridEspaces.BorderStyle = BorderStyle.None;
            dataGridEspaces.ColumnHeadersHeight = 34;
            dataGridEspaces.Dock = DockStyle.Fill;
            dataGridEspaces.Location = new Point(3, 406);
            dataGridEspaces.Name = "dataGridEspaces";
            dataGridEspaces.ReadOnly = true;
            dataGridEspaces.RowHeadersWidth = 62;
            dataGridEspaces.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridEspaces.Size = new Size(1256, 439);
            dataGridEspaces.TabIndex = 4;
            dataGridEspaces.CellClick += DataGridEspaces_CellClick;
            // 
            // numericUpDownSuperficie
            // 
            numericUpDownSuperficie.Dock = DockStyle.Fill;
            numericUpDownSuperficie.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDownSuperficie.Location = new Point(364, 31);
            numericUpDownSuperficie.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            numericUpDownSuperficie.Minimum = new decimal(new int[] { 9, 0, 0, 0 });
            numericUpDownSuperficie.Name = "numericUpDownSuperficie";
            numericUpDownSuperficie.Size = new Size(294, 31);
            numericUpDownSuperficie.TabIndex = 15;
            numericUpDownSuperficie.Value = new decimal(new int[] { 12, 0, 0, 0 });
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel.ColumnCount = 5;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42.33871F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.2983875F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45.29058F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 215F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 370F));
            tableLayoutPanel.Controls.Add(dataGridTournois, 4, 1);
            tableLayoutPanel.Controls.Add(textBoxNom, 0, 1);
            tableLayoutPanel.Controls.Add(labelNom, 0, 0);
            tableLayoutPanel.Controls.Add(textBoxDescription, 0, 3);
            tableLayoutPanel.Controls.Add(labelDescription, 0, 2);
            tableLayoutPanel.Controls.Add(labelSuperficie, 2, 0);
            tableLayoutPanel.Controls.Add(numericUpDownSuperficie, 2, 1);
            tableLayoutPanel.Controls.Add(labelCapaciteMaxi, 3, 0);
            tableLayoutPanel.Controls.Add(numericUpDownCapaciteMaxi, 3, 1);
            tableLayoutPanel.Controls.Add(labelStatutTournoi, 4, 0);
            tableLayoutPanel.Location = new Point(3, 3);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 4;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 53F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 16F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 16F));
            tableLayoutPanel.Size = new Size(1248, 210);
            tableLayoutPanel.TabIndex = 0;
            // 
            // dataGridTournois
            // 
            dataGridTournois.AllowUserToAddRows = false;
            dataGridTournois.AllowUserToDeleteRows = false;
            dataGridTournois.AllowUserToOrderColumns = true;
            dataGridTournois.BackgroundColor = Color.White;
            dataGridTournois.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridTournois.Dock = DockStyle.Fill;
            dataGridTournois.Location = new Point(878, 31);
            dataGridTournois.Margin = new Padding(2, 3, 2, 3);
            dataGridTournois.Name = "dataGridTournois";
            dataGridTournois.ReadOnly = true;
            dataGridTournois.RowHeadersWidth = 62;
            tableLayoutPanel.SetRowSpan(dataGridTournois, 3);
            dataGridTournois.Size = new Size(368, 176);
            dataGridTournois.TabIndex = 19;
            // 
            // textBoxDescription
            // 
            tableLayoutPanel.SetColumnSpan(textBoxDescription, 4);
            textBoxDescription.Location = new Point(3, 106);
            textBoxDescription.Multiline = true;
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.PlaceholderText = "Ex: Description de l'espace";
            textBoxDescription.Size = new Size(564, 49);
            textBoxDescription.TabIndex = 17;
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            tableLayoutPanel.SetColumnSpan(labelDescription, 3);
            labelDescription.Dock = DockStyle.Fill;
            labelDescription.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelDescription.Location = new Point(3, 63);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(655, 40);
            labelDescription.TabIndex = 16;
            labelDescription.Text = "Description de l'espace  :*";
            labelDescription.TextAlign = ContentAlignment.BottomLeft;
            // 
            // numericUpDownCapaciteMaxi
            // 
            numericUpDownCapaciteMaxi.Dock = DockStyle.Fill;
            numericUpDownCapaciteMaxi.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDownCapaciteMaxi.Location = new Point(665, 31);
            numericUpDownCapaciteMaxi.Margin = new Padding(4, 3, 4, 3);
            numericUpDownCapaciteMaxi.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numericUpDownCapaciteMaxi.Name = "numericUpDownCapaciteMaxi";
            numericUpDownCapaciteMaxi.Size = new Size(207, 31);
            numericUpDownCapaciteMaxi.TabIndex = 3;
            // 
            // labelStatutTournoi
            // 
            labelStatutTournoi.BackColor = Color.FromArgb(255, 224, 192);
            labelStatutTournoi.Dock = DockStyle.Fill;
            labelStatutTournoi.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelStatutTournoi.ForeColor = Color.Chocolate;
            labelStatutTournoi.Location = new Point(880, 0);
            labelStatutTournoi.Margin = new Padding(4, 0, 4, 0);
            labelStatutTournoi.Name = "labelStatutTournoi";
            labelStatutTournoi.Size = new Size(364, 28);
            labelStatutTournoi.TabIndex = 18;
            labelStatutTournoi.Text = "Tournoi en cours";
            labelStatutTournoi.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelForm
            // 
            panelForm.BackColor = Color.White;
            panelForm.Controls.Add(tableLayoutPanelCRUD);
            panelForm.Dock = DockStyle.Fill;
            panelForm.Location = new Point(4, 3);
            panelForm.Margin = new Padding(4, 3, 4, 3);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(1254, 397);
            panelForm.TabIndex = 3;
            // 
            // tableLayoutPanelCRUD
            // 
            tableLayoutPanelCRUD.ColumnCount = 1;
            tableLayoutPanelCRUD.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelCRUD.Controls.Add(tableLayoutPanel, 0, 0);
            tableLayoutPanelCRUD.Controls.Add(groupBox1, 0, 1);
            tableLayoutPanelCRUD.Dock = DockStyle.Fill;
            tableLayoutPanelCRUD.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanelCRUD.Location = new Point(0, 0);
            tableLayoutPanelCRUD.Name = "tableLayoutPanelCRUD";
            tableLayoutPanelCRUD.RowCount = 2;
            tableLayoutPanelCRUD.RowStyles.Add(new RowStyle(SizeType.Percent, 54.4270821F));
            tableLayoutPanelCRUD.RowStyles.Add(new RowStyle(SizeType.Percent, 45.5729179F));
            tableLayoutPanelCRUD.Size = new Size(1254, 397);
            tableLayoutPanelCRUD.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 74.87981F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.1201916F));
            tableLayoutPanel1.Controls.Add(panelForm, 0, 0);
            tableLayoutPanel1.Controls.Add(dataGridEspaces, 0, 1);
            tableLayoutPanel1.Controls.Add(groupBoxStatsEspaces, 1, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 47.636364F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 52.363636F));
            tableLayoutPanel1.Size = new Size(1686, 848);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // groupBoxStatsEspaces
            // 
            groupBoxStatsEspaces.BackColor = Color.White;
            groupBoxStatsEspaces.Controls.Add(labelStatEspacesLibres);
            groupBoxStatsEspaces.Controls.Add(labelStatEspacesTotal);
            groupBoxStatsEspaces.Controls.Add(labelTitreEspaces);
            groupBoxStatsEspaces.Dock = DockStyle.Top;
            groupBoxStatsEspaces.Location = new Point(1266, 408);
            groupBoxStatsEspaces.Margin = new Padding(4, 5, 4, 5);
            groupBoxStatsEspaces.Name = "groupBoxStatsEspaces";
            groupBoxStatsEspaces.Padding = new Padding(4, 5, 4, 5);
            groupBoxStatsEspaces.Size = new Size(416, 213);
            groupBoxStatsEspaces.TabIndex = 7;
            groupBoxStatsEspaces.TabStop = false;
            // 
            // labelStatEspacesLibres
            // 
            labelStatEspacesLibres.Font = new Font("Segoe UI", 9.75F);
            labelStatEspacesLibres.Location = new Point(-1, 143);
            labelStatEspacesLibres.Margin = new Padding(4, 0, 4, 0);
            labelStatEspacesLibres.Name = "labelStatEspacesLibres";
            labelStatEspacesLibres.Size = new Size(411, 33);
            labelStatEspacesLibres.TabIndex = 2;
            labelStatEspacesLibres.Text = "Disponibles : 8";
            labelStatEspacesLibres.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelStatEspacesTotal
            // 
            labelStatEspacesTotal.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            labelStatEspacesTotal.ForeColor = Color.FromArgb(255, 152, 0);
            labelStatEspacesTotal.Location = new Point(0, 57);
            labelStatEspacesTotal.Margin = new Padding(4, 0, 4, 0);
            labelStatEspacesTotal.Name = "labelStatEspacesTotal";
            labelStatEspacesTotal.Size = new Size(409, 75);
            labelStatEspacesTotal.TabIndex = 1;
            labelStatEspacesTotal.Text = "12";
            labelStatEspacesTotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelTitreEspaces
            // 
            labelTitreEspaces.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelTitreEspaces.ForeColor = Color.FromArgb(100, 100, 100);
            labelTitreEspaces.Location = new Point(9, 23);
            labelTitreEspaces.Margin = new Padding(4, 0, 4, 0);
            labelTitreEspaces.Name = "labelTitreEspaces";
            labelTitreEspaces.Size = new Size(400, 33);
            labelTitreEspaces.TabIndex = 0;
            labelTitreEspaces.Text = "🏢 ESPACES";
            labelTitreEspaces.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(labelPostesJeu, 0, 0);
            tableLayoutPanel2.Controls.Add(dataGridPostesJeu, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(1265, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 11.3350124F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 88.6649857F));
            tableLayoutPanel2.Size = new Size(418, 397);
            tableLayoutPanel2.TabIndex = 8;
            // 
            // labelPostesJeu
            // 
            labelPostesJeu.BackColor = Color.DarkBlue;
            labelPostesJeu.Dock = DockStyle.Fill;
            labelPostesJeu.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelPostesJeu.ForeColor = Color.White;
            labelPostesJeu.Location = new Point(4, 0);
            labelPostesJeu.Margin = new Padding(4, 0, 4, 0);
            labelPostesJeu.Name = "labelPostesJeu";
            labelPostesJeu.Size = new Size(410, 45);
            labelPostesJeu.TabIndex = 19;
            labelPostesJeu.Text = "Postes de jeu associés";
            labelPostesJeu.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dataGridPostesJeu
            // 
            dataGridPostesJeu.AllowUserToAddRows = false;
            dataGridPostesJeu.AllowUserToDeleteRows = false;
            dataGridPostesJeu.AllowUserToOrderColumns = true;
            dataGridPostesJeu.BackgroundColor = Color.White;
            dataGridPostesJeu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridPostesJeu.Dock = DockStyle.Fill;
            dataGridPostesJeu.Location = new Point(3, 48);
            dataGridPostesJeu.Name = "dataGridPostesJeu";
            dataGridPostesJeu.ReadOnly = true;
            dataGridPostesJeu.RowHeadersWidth = 62;
            dataGridPostesJeu.Size = new Size(412, 346);
            dataGridPostesJeu.TabIndex = 5;
            // 
            // process1
            // 
            process1.StartInfo.CreateNewProcessGroup = false;
            process1.StartInfo.Domain = "";
            process1.StartInfo.LoadUserProfile = false;
            process1.StartInfo.Password = null;
            process1.StartInfo.StandardErrorEncoding = null;
            process1.StartInfo.StandardInputEncoding = null;
            process1.StartInfo.StandardOutputEncoding = null;
            process1.StartInfo.UseCredentialsForNetworkingOnly = false;
            process1.StartInfo.UserName = "";
            process1.SynchronizingObject = this;
            // 
            // UcEspaces
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 255);
            Controls.Add(tableLayoutPanel1);
            Name = "UcEspaces";
            Size = new Size(1686, 848);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridEspaces).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSuperficie).EndInit();
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridTournois).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCapaciteMaxi).EndInit();
            panelForm.ResumeLayout(false);
            tableLayoutPanelCRUD.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            groupBoxStatsEspaces.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridPostesJeu).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private Button buttonAjouter;
        private Button buttonEffacer;
        private Button buttonModifier;
        private Button buttonSupprimer;
        private Label labelSuperficie;
        private TextBox textBoxNom;
        private Label labelNom;
        private Label labelCapaciteMaxi;
        private DataGridView dataGridEspaces;
        private NumericUpDown numericUpDownSuperficie;
        private TableLayoutPanel tableLayoutPanel;
        private Panel panelForm;
        private Label labelDescription;
        private TableLayoutPanel tableLayoutPanel1;
        private System.Diagnostics.Process process1;
        private TableLayoutPanel tableLayoutPanelCRUD;
        private DataGridView dataGridPostesJeu;
        private TextBox textBoxRecherche;
        private Label label1;
        private GroupBox groupBoxStatsEspaces;
        private Label labelStatEspacesLibres;
        private Label labelStatEspacesTotal;
        private Label labelTitreEspaces;
        private TextBox textBoxDescription;
        private NumericUpDown numericUpDownCapaciteMaxi;
        private Label labelStatutTournoi;
        private DataGridView dataGridTournois;
        private TableLayoutPanel tableLayoutPanel2;
        private Label labelPostesJeu;
    }
}
