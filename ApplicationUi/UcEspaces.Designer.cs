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
            buttonAjouter = new Button();
            buttonEffacer = new Button();
            buttonModifier = new Button();
            buttonSupprimer = new Button();
            labelSuperficie = new Label();
            numericUpDownCapaciteMaxi = new NumericUpDown();
            textBoxNom = new TextBox();
            labelNom = new Label();
            labelCapaciteMaxi = new Label();
            dataGridEspaces = new DataGridView();
            numericUpDownSuperficie = new NumericUpDown();
            tableLayoutPanel = new TableLayoutPanel();
            labelDescription = new Label();
            textBoxDescription = new TextBox();
            panelForm = new Panel();
            tableLayoutPanelCRUD = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            label1 = new Label();
            textBoxRecherche = new TextBox();
            dataGridPostesJeu = new DataGridView();
            groupBoxStatsEspaces = new GroupBox();
            labelStatEspacesLibres = new Label();
            labelStatEspacesTotal = new Label();
            labelTitreEspaces = new Label();
            process1 = new System.Diagnostics.Process();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCapaciteMaxi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridEspaces).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSuperficie).BeginInit();
            tableLayoutPanel.SuspendLayout();
            panelForm.SuspendLayout();
            tableLayoutPanelCRUD.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridPostesJeu).BeginInit();
            groupBoxStatsEspaces.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(buttonAjouter);
            groupBox1.Controls.Add(buttonEffacer);
            groupBox1.Controls.Add(buttonModifier);
            groupBox1.Controls.Add(buttonSupprimer);
            groupBox1.Location = new Point(2, 116);
            groupBox1.Margin = new Padding(2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2);
            groupBox1.Size = new Size(617, 61);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "⚡ Actions";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // buttonAjouter
            // 
            buttonAjouter.BackColor = Color.FromArgb(76, 175, 80);
            buttonAjouter.FlatAppearance.BorderSize = 0;
            buttonAjouter.FlatStyle = FlatStyle.Flat;
            buttonAjouter.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonAjouter.ForeColor = Color.White;
            buttonAjouter.Location = new Point(178, 15);
            buttonAjouter.Margin = new Padding(3, 2, 3, 2);
            buttonAjouter.Name = "buttonAjouter";
            buttonAjouter.Size = new Size(105, 27);
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
            buttonEffacer.Location = new Point(49, 15);
            buttonEffacer.Margin = new Padding(3, 2, 3, 2);
            buttonEffacer.Name = "buttonEffacer";
            buttonEffacer.Size = new Size(105, 27);
            buttonEffacer.TabIndex = 3;
            buttonEffacer.Text = " Effacer";
            buttonEffacer.UseVisualStyleBackColor = false;
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
            buttonModifier.Size = new Size(135, 27);
            buttonModifier.TabIndex = 4;
            buttonModifier.Text = "✏️    Modifier";
            buttonModifier.UseVisualStyleBackColor = false;
            // 
            // buttonSupprimer
            // 
            buttonSupprimer.BackColor = Color.FromArgb(244, 67, 54);
            buttonSupprimer.FlatAppearance.BorderSize = 0;
            buttonSupprimer.FlatStyle = FlatStyle.Flat;
            buttonSupprimer.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonSupprimer.ForeColor = Color.White;
            buttonSupprimer.Location = new Point(469, 15);
            buttonSupprimer.Margin = new Padding(3, 2, 3, 2);
            buttonSupprimer.Name = "buttonSupprimer";
            buttonSupprimer.Size = new Size(137, 27);
            buttonSupprimer.TabIndex = 5;
            buttonSupprimer.Text = "🗑️    Supprimer";
            buttonSupprimer.UseVisualStyleBackColor = false;
            // 
            // labelSuperficie
            // 
            labelSuperficie.AutoSize = true;
            labelSuperficie.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelSuperficie.Location = new Point(3, 63);
            labelSuperficie.Name = "labelSuperficie";
            labelSuperficie.Size = new Size(117, 17);
            labelSuperficie.TabIndex = 14;
            labelSuperficie.Text = "Superficie en m² :";
            // 
            // numericUpDownCapaciteMaxi
            // 
            numericUpDownCapaciteMaxi.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDownCapaciteMaxi.Location = new Point(205, 90);
            numericUpDownCapaciteMaxi.Margin = new Padding(3, 2, 3, 2);
            numericUpDownCapaciteMaxi.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numericUpDownCapaciteMaxi.Name = "numericUpDownCapaciteMaxi";
            numericUpDownCapaciteMaxi.Size = new Size(61, 23);
            numericUpDownCapaciteMaxi.TabIndex = 3;
            // 
            // textBoxNom
            // 
            tableLayoutPanel.SetColumnSpan(textBoxNom, 2);
            textBoxNom.Location = new Point(3, 23);
            textBoxNom.Margin = new Padding(3, 2, 3, 2);
            textBoxNom.Multiline = true;
            textBoxNom.Name = "textBoxNom";
            textBoxNom.PlaceholderText = "Ex: Espace playstation";
            textBoxNom.Size = new Size(281, 20);
            textBoxNom.TabIndex = 0;
            // 
            // labelNom
            // 
            labelNom.AutoSize = true;
            labelNom.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelNom.Location = new Point(3, 0);
            labelNom.Name = "labelNom";
            labelNom.Size = new Size(128, 17);
            labelNom.TabIndex = 6;
            labelNom.Text = "Nom de l'espace * :";
            // 
            // labelCapaciteMaxi
            // 
            labelCapaciteMaxi.AutoSize = true;
            labelCapaciteMaxi.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelCapaciteMaxi.Location = new Point(205, 63);
            labelCapaciteMaxi.Name = "labelCapaciteMaxi";
            labelCapaciteMaxi.Size = new Size(134, 17);
            labelCapaciteMaxi.TabIndex = 8;
            labelCapaciteMaxi.Text = "Capacité maximale*:";
            // 
            // dataGridEspaces
            // 
            dataGridEspaces.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridEspaces.BackgroundColor = Color.White;
            dataGridEspaces.BorderStyle = BorderStyle.None;
            dataGridEspaces.ColumnHeadersHeight = 34;
            dataGridEspaces.Dock = DockStyle.Fill;
            dataGridEspaces.Location = new Point(3, 233);
            dataGridEspaces.Margin = new Padding(3, 2, 3, 2);
            dataGridEspaces.Name = "dataGridEspaces";
            dataGridEspaces.ReadOnly = true;
            dataGridEspaces.RowHeadersWidth = 62;
            dataGridEspaces.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridEspaces.Size = new Size(621, 211);
            dataGridEspaces.TabIndex = 4;
            dataGridEspaces.CellClick += dataGridEspaces_CellClick;
            // 
            // numericUpDownSuperficie
            // 
            numericUpDownSuperficie.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDownSuperficie.Location = new Point(3, 90);
            numericUpDownSuperficie.Margin = new Padding(3, 2, 3, 2);
            numericUpDownSuperficie.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            numericUpDownSuperficie.Minimum = new decimal(new int[] { 9, 0, 0, 0 });
            numericUpDownSuperficie.Name = "numericUpDownSuperficie";
            numericUpDownSuperficie.Size = new Size(61, 23);
            numericUpDownSuperficie.TabIndex = 15;
            numericUpDownSuperficie.Value = new decimal(new int[] { 12, 0, 0, 0 });
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel.ColumnCount = 3;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
            tableLayoutPanel.Controls.Add(textBoxNom, 0, 1);
            tableLayoutPanel.Controls.Add(labelNom, 0, 0);
            tableLayoutPanel.Controls.Add(labelDescription, 2, 0);
            tableLayoutPanel.Controls.Add(textBoxDescription, 2, 1);
            tableLayoutPanel.Controls.Add(numericUpDownCapaciteMaxi, 1, 4);
            tableLayoutPanel.Controls.Add(labelCapaciteMaxi, 1, 3);
            tableLayoutPanel.Controls.Add(labelSuperficie, 0, 3);
            tableLayoutPanel.Controls.Add(numericUpDownSuperficie, 0, 4);
            tableLayoutPanel.Location = new Point(3, 2);
            tableLayoutPanel.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 5;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 21F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 16F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 12F));
            tableLayoutPanel.Size = new Size(615, 110);
            tableLayoutPanel.TabIndex = 0;
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelDescription.Location = new Point(407, 0);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(165, 17);
            labelDescription.TabIndex = 16;
            labelDescription.Text = "Description de l'espace *:";
            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(407, 23);
            textBoxDescription.Margin = new Padding(3, 2, 3, 2);
            textBoxDescription.Multiline = true;
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.PlaceholderText = "Ex: Description de l'espace";
            tableLayoutPanel.SetRowSpan(textBoxDescription, 4);
            textBoxDescription.Size = new Size(198, 85);
            textBoxDescription.TabIndex = 17;
            // 
            // panelForm
            // 
            panelForm.BackColor = Color.White;
            panelForm.Controls.Add(tableLayoutPanelCRUD);
            panelForm.Location = new Point(3, 2);
            panelForm.Margin = new Padding(3, 2, 3, 2);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(621, 179);
            panelForm.TabIndex = 3;
            // 
            // tableLayoutPanelCRUD
            // 
            tableLayoutPanelCRUD.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanelCRUD.ColumnCount = 1;
            tableLayoutPanelCRUD.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelCRUD.Controls.Add(tableLayoutPanel, 0, 0);
            tableLayoutPanelCRUD.Controls.Add(groupBox1, 0, 1);
            tableLayoutPanelCRUD.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanelCRUD.Location = new Point(0, 0);
            tableLayoutPanelCRUD.Margin = new Padding(2);
            tableLayoutPanelCRUD.Name = "tableLayoutPanelCRUD";
            tableLayoutPanelCRUD.RowCount = 2;
            tableLayoutPanelCRUD.RowStyles.Add(new RowStyle(SizeType.Percent, 64.22288F));
            tableLayoutPanelCRUD.RowStyles.Add(new RowStyle(SizeType.Percent, 35.7771263F));
            tableLayoutPanelCRUD.Size = new Size(621, 179);
            tableLayoutPanelCRUD.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65.40146F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34.59854F));
            tableLayoutPanel1.Controls.Add(panelForm, 0, 0);
            tableLayoutPanel1.Controls.Add(dataGridEspaces, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(dataGridPostesJeu, 1, 0);
            tableLayoutPanel1.Controls.Add(groupBoxStatsEspaces, 1, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 80.15717F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 19.8428288F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 214F));
            tableLayoutPanel1.Size = new Size(959, 446);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.7640457F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 81.2359543F));
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Controls.Add(textBoxRecherche, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Bottom;
            tableLayoutPanel2.Location = new Point(2, 201);
            tableLayoutPanel2.Margin = new Padding(2);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(623, 28);
            tableLayoutPanel2.TabIndex = 6;
            tableLayoutPanel2.Paint += tableLayoutPanel2_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(2, 0);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(89, 20);
            label1.TabIndex = 1;
            label1.Text = "Recherche :";
            // 
            // textBoxRecherche
            // 
            textBoxRecherche.Location = new Point(118, 2);
            textBoxRecherche.Margin = new Padding(2);
            textBoxRecherche.Name = "textBoxRecherche";
            textBoxRecherche.Size = new Size(503, 23);
            textBoxRecherche.TabIndex = 0;
            textBoxRecherche.TextChanged += textBoxRecherche_TextChanged;
            // 
            // dataGridPostesJeu
            // 
            dataGridPostesJeu.AllowUserToAddRows = false;
            dataGridPostesJeu.AllowUserToDeleteRows = false;
            dataGridPostesJeu.AllowUserToOrderColumns = true;
            dataGridPostesJeu.BackgroundColor = Color.White;
            dataGridPostesJeu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridPostesJeu.Dock = DockStyle.Top;
            dataGridPostesJeu.Location = new Point(629, 2);
            dataGridPostesJeu.Margin = new Padding(2);
            dataGridPostesJeu.Name = "dataGridPostesJeu";
            dataGridPostesJeu.ReadOnly = true;
            dataGridPostesJeu.RowHeadersWidth = 62;
            dataGridPostesJeu.Size = new Size(328, 181);
            dataGridPostesJeu.TabIndex = 5;
            // 
            // groupBoxStatsEspaces
            // 
            groupBoxStatsEspaces.BackColor = Color.White;
            groupBoxStatsEspaces.Controls.Add(labelStatEspacesLibres);
            groupBoxStatsEspaces.Controls.Add(labelStatEspacesTotal);
            groupBoxStatsEspaces.Controls.Add(labelTitreEspaces);
            groupBoxStatsEspaces.Dock = DockStyle.Top;
            groupBoxStatsEspaces.Location = new Point(630, 234);
            groupBoxStatsEspaces.Name = "groupBoxStatsEspaces";
            groupBoxStatsEspaces.Size = new Size(326, 120);
            groupBoxStatsEspaces.TabIndex = 7;
            groupBoxStatsEspaces.TabStop = false;
            // 
            // labelStatEspacesLibres
            // 
            labelStatEspacesLibres.Font = new Font("Segoe UI", 9.75F);
            labelStatEspacesLibres.Location = new Point(20, 86);
            labelStatEspacesLibres.Name = "labelStatEspacesLibres";
            labelStatEspacesLibres.Size = new Size(280, 20);
            labelStatEspacesLibres.TabIndex = 2;
            labelStatEspacesLibres.Text = "Disponibles : 8";
            labelStatEspacesLibres.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelStatEspacesTotal
            // 
            labelStatEspacesTotal.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            labelStatEspacesTotal.ForeColor = Color.FromArgb(255, 152, 0);
            labelStatEspacesTotal.Location = new Point(20, 34);
            labelStatEspacesTotal.Name = "labelStatEspacesTotal";
            labelStatEspacesTotal.Size = new Size(280, 45);
            labelStatEspacesTotal.TabIndex = 1;
            labelStatEspacesTotal.Text = "12";
            labelStatEspacesTotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelTitreEspaces
            // 
            labelTitreEspaces.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelTitreEspaces.ForeColor = Color.FromArgb(100, 100, 100);
            labelTitreEspaces.Location = new Point(20, 15);
            labelTitreEspaces.Name = "labelTitreEspaces";
            labelTitreEspaces.Size = new Size(280, 20);
            labelTitreEspaces.TabIndex = 0;
            labelTitreEspaces.Text = "🏢 ESPACES";
            labelTitreEspaces.TextAlign = ContentAlignment.MiddleCenter;
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
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 255);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(2);
            Name = "UcEspaces";
            Size = new Size(959, 446);
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDownCapaciteMaxi).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridEspaces).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSuperficie).EndInit();
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            panelForm.ResumeLayout(false);
            tableLayoutPanelCRUD.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridPostesJeu).EndInit();
            groupBoxStatsEspaces.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private Button buttonAjouter;
        private Button buttonEffacer;
        private Button buttonModifier;
        private Button buttonSupprimer;
        private Label labelSuperficie;
        private NumericUpDown numericUpDownCapaciteMaxi;
        private TextBox textBoxNom;
        private Label labelNom;
        private Label labelCapaciteMaxi;
        private DataGridView dataGridEspaces;
        private NumericUpDown numericUpDownSuperficie;
        private TableLayoutPanel tableLayoutPanel;
        private Panel panelForm;
        private Label labelDescription;
        private TextBox textBoxDescription;
        private TableLayoutPanel tableLayoutPanel1;
        private System.Diagnostics.Process process1;
        private TableLayoutPanel tableLayoutPanelCRUD;
        private DataGridView dataGridPostesJeu;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox textBoxRecherche;
        private Label label1;
        private GroupBox groupBoxStatsEspaces;
        private Label labelStatEspacesLibres;
        private Label labelStatEspacesTotal;
        private Label labelTitreEspaces;
    }
}
