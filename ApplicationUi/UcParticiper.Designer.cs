namespace ApplicationUi
{
    partial class UcParticiper
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
            process1 = new System.Diagnostics.Process();
            dataGridParticipationsJoueur = new DataGridView();
            label1 = new Label();
            labelNom = new Label();
            textBoxRecherche = new TextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            panelForm = new Panel();
            tableLayoutPanelCRUD = new TableLayoutPanel();
            tableLayoutPanel = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            radioButtonLotRemisTrue = new RadioButton();
            radioButtonLotRemisFalse = new RadioButton();
            numericUpDownRang = new NumericUpDown();
            comboBoxUtilisateur = new ComboBox();
            comboBoxTournoi = new ComboBox();
            labelComentaire = new Label();
            textBoxCommentaire = new TextBox();
            labelEvaluation = new Label();
            trackBarEvaluation = new TrackBar();
            labelTournoi = new Label();
            labelDateHeureInscription = new Label();
            labelLot = new Label();
            dateTimePickerDateHeureInscription = new DateTimePicker();
            labelRang = new Label();
            label2 = new Label();
            numericUpDownScoreFinal = new NumericUpDown();
            label84 = new Label();
            labelStatutTournoi = new Label();
            groupBox1 = new GroupBox();
            buttonAjouter = new Button();
            buttonEffacer = new Button();
            buttonModifier = new Button();
            buttonSupprimer = new Button();
            dataGridParticipations = new DataGridView();
            tableLayoutPanel2 = new TableLayoutPanel();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridParticipationsJoueur).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            panelForm.SuspendLayout();
            tableLayoutPanelCRUD.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRang).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarEvaluation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownScoreFinal).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridParticipations).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
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
            // dataGridParticipationsJoueur
            // 
            dataGridParticipationsJoueur.AccessibleDescription = "Participations associés à l'utilisateur séléctionné";
            dataGridParticipationsJoueur.AllowUserToAddRows = false;
            dataGridParticipationsJoueur.AllowUserToDeleteRows = false;
            dataGridParticipationsJoueur.AllowUserToOrderColumns = true;
            dataGridParticipationsJoueur.BackgroundColor = Color.White;
            dataGridParticipationsJoueur.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridParticipationsJoueur.Dock = DockStyle.Fill;
            dataGridParticipationsJoueur.Location = new Point(3, 48);
            dataGridParticipationsJoueur.Name = "dataGridParticipationsJoueur";
            dataGridParticipationsJoueur.ReadOnly = true;
            dataGridParticipationsJoueur.RowHeadersWidth = 62;
            dataGridParticipationsJoueur.Size = new Size(424, 386);
            dataGridParticipationsJoueur.TabIndex = 5;
            dataGridParticipationsJoueur.CellClick += DataGridParticipationsJoueur_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(70, 125);
            label1.Name = "label1";
            label1.Size = new Size(131, 30);
            label1.TabIndex = 1;
            label1.Text = "Recherche :";
            // 
            // labelNom
            // 
            labelNom.AutoSize = true;
            labelNom.Dock = DockStyle.Fill;
            labelNom.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelNom.Location = new Point(254, 73);
            labelNom.Margin = new Padding(4, 0, 4, 0);
            labelNom.Name = "labelNom";
            labelNom.Size = new Size(260, 31);
            labelNom.TabIndex = 6;
            labelNom.Text = "Id utilisateur :";
            // 
            // textBoxRecherche
            // 
            textBoxRecherche.Location = new Point(197, 126);
            textBoxRecherche.Name = "textBoxRecherche";
            textBoxRecherche.Size = new Size(888, 31);
            textBoxRecherche.TabIndex = 0;
            textBoxRecherche.TextChanged += TextBoxRecherche_TextChanged;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 74.35294F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.6470585F));
            tableLayoutPanel1.Controls.Add(panelForm, 0, 0);
            tableLayoutPanel1.Controls.Add(dataGridParticipations, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50.51311F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 49.48689F));
            tableLayoutPanel1.Size = new Size(1700, 877);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // panelForm
            // 
            panelForm.BackColor = Color.White;
            panelForm.Controls.Add(tableLayoutPanelCRUD);
            panelForm.Dock = DockStyle.Fill;
            panelForm.Location = new Point(4, 3);
            panelForm.Margin = new Padding(4, 3, 4, 3);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(1256, 437);
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
            tableLayoutPanelCRUD.RowStyles.Add(new RowStyle(SizeType.Percent, 51.52941F));
            tableLayoutPanelCRUD.RowStyles.Add(new RowStyle(SizeType.Percent, 48.47059F));
            tableLayoutPanelCRUD.Size = new Size(1256, 437);
            tableLayoutPanelCRUD.TabIndex = 8;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel.ColumnCount = 5;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 39.38849F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42.2712936F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.29653F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 226F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 387F));
            tableLayoutPanel.Controls.Add(flowLayoutPanel1, 3, 3);
            tableLayoutPanel.Controls.Add(numericUpDownRang, 2, 1);
            tableLayoutPanel.Controls.Add(comboBoxUtilisateur, 1, 3);
            tableLayoutPanel.Controls.Add(comboBoxTournoi, 0, 1);
            tableLayoutPanel.Controls.Add(labelComentaire, 4, 0);
            tableLayoutPanel.Controls.Add(textBoxCommentaire, 4, 1);
            tableLayoutPanel.Controls.Add(labelEvaluation, 3, 0);
            tableLayoutPanel.Controls.Add(trackBarEvaluation, 3, 1);
            tableLayoutPanel.Controls.Add(labelTournoi, 0, 0);
            tableLayoutPanel.Controls.Add(labelNom, 1, 2);
            tableLayoutPanel.Controls.Add(labelDateHeureInscription, 0, 2);
            tableLayoutPanel.Controls.Add(labelLot, 3, 2);
            tableLayoutPanel.Controls.Add(dateTimePickerDateHeureInscription, 0, 3);
            tableLayoutPanel.Controls.Add(labelRang, 2, 0);
            tableLayoutPanel.Controls.Add(label2, 2, 2);
            tableLayoutPanel.Controls.Add(numericUpDownScoreFinal, 2, 3);
            tableLayoutPanel.Controls.Add(label84, 1, 0);
            tableLayoutPanel.Controls.Add(labelStatutTournoi, 1, 1);
            tableLayoutPanel.Location = new Point(4, 3);
            tableLayoutPanel.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 4;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.Size = new Size(1248, 219);
            tableLayoutPanel.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(radioButtonLotRemisTrue);
            flowLayoutPanel1.Controls.Add(radioButtonLotRemisFalse);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(637, 107);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(220, 109);
            flowLayoutPanel1.TabIndex = 39;
            // 
            // radioButtonLotRemisTrue
            // 
            radioButtonLotRemisTrue.AutoSize = true;
            radioButtonLotRemisTrue.Location = new Point(3, 3);
            radioButtonLotRemisTrue.Name = "radioButtonLotRemisTrue";
            radioButtonLotRemisTrue.Size = new Size(65, 29);
            radioButtonLotRemisTrue.TabIndex = 1;
            radioButtonLotRemisTrue.TabStop = true;
            radioButtonLotRemisTrue.Text = "Oui";
            radioButtonLotRemisTrue.UseVisualStyleBackColor = true;
            radioButtonLotRemisTrue.CheckedChanged += RadioButtonLotRemisTrue_CheckedChanged;
            // 
            // radioButtonLotRemisFalse
            // 
            radioButtonLotRemisFalse.AutoSize = true;
            radioButtonLotRemisFalse.Location = new Point(74, 3);
            radioButtonLotRemisFalse.Name = "radioButtonLotRemisFalse";
            radioButtonLotRemisFalse.Size = new Size(71, 29);
            radioButtonLotRemisFalse.TabIndex = 2;
            radioButtonLotRemisFalse.TabStop = true;
            radioButtonLotRemisFalse.Text = "Non";
            radioButtonLotRemisFalse.UseVisualStyleBackColor = true;
            radioButtonLotRemisFalse.CheckedChanged += RadioButtonLotRemisFalse_CheckedChanged;
            // 
            // numericUpDownRang
            // 
            numericUpDownRang.Dock = DockStyle.Fill;
            numericUpDownRang.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDownRang.Location = new Point(522, 39);
            numericUpDownRang.Margin = new Padding(4);
            numericUpDownRang.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            numericUpDownRang.Name = "numericUpDownRang";
            numericUpDownRang.Size = new Size(108, 31);
            numericUpDownRang.TabIndex = 37;
            // 
            // comboBoxUtilisateur
            // 
            comboBoxUtilisateur.Dock = DockStyle.Fill;
            comboBoxUtilisateur.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxUtilisateur.Location = new Point(254, 108);
            comboBoxUtilisateur.Margin = new Padding(4);
            comboBoxUtilisateur.Name = "comboBoxUtilisateur";
            comboBoxUtilisateur.Size = new Size(260, 33);
            comboBoxUtilisateur.TabIndex = 33;
            // 
            // comboBoxTournoi
            // 
            comboBoxTournoi.Dock = DockStyle.Fill;
            comboBoxTournoi.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTournoi.Location = new Point(4, 39);
            comboBoxTournoi.Margin = new Padding(4);
            comboBoxTournoi.Name = "comboBoxTournoi";
            comboBoxTournoi.Size = new Size(242, 33);
            comboBoxTournoi.TabIndex = 32;
            // 
            // labelComentaire
            // 
            labelComentaire.BackColor = Color.MidnightBlue;
            labelComentaire.Dock = DockStyle.Fill;
            labelComentaire.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelComentaire.ForeColor = Color.AliceBlue;
            labelComentaire.Location = new Point(864, 0);
            labelComentaire.Margin = new Padding(4, 0, 4, 0);
            labelComentaire.Name = "labelComentaire";
            labelComentaire.Size = new Size(380, 35);
            labelComentaire.TabIndex = 18;
            labelComentaire.Text = "Commentaire";
            labelComentaire.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxCommentaire
            // 
            textBoxCommentaire.Dock = DockStyle.Fill;
            textBoxCommentaire.Location = new Point(863, 38);
            textBoxCommentaire.Multiline = true;
            textBoxCommentaire.Name = "textBoxCommentaire";
            textBoxCommentaire.PlaceholderText = "Laisser un commentaire sur le tournoi...";
            tableLayoutPanel.SetRowSpan(textBoxCommentaire, 3);
            textBoxCommentaire.Size = new Size(382, 178);
            textBoxCommentaire.TabIndex = 19;
            // 
            // labelEvaluation
            // 
            labelEvaluation.AutoSize = true;
            labelEvaluation.Dock = DockStyle.Fill;
            labelEvaluation.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelEvaluation.Location = new Point(638, 0);
            labelEvaluation.Margin = new Padding(4, 0, 4, 0);
            labelEvaluation.Name = "labelEvaluation";
            labelEvaluation.Size = new Size(218, 35);
            labelEvaluation.TabIndex = 8;
            labelEvaluation.Text = "Évaluation :";
            // 
            // trackBarEvaluation
            // 
            trackBarEvaluation.BackColor = Color.White;
            trackBarEvaluation.Dock = DockStyle.Fill;
            trackBarEvaluation.Location = new Point(637, 38);
            trackBarEvaluation.Name = "trackBarEvaluation";
            trackBarEvaluation.Size = new Size(220, 32);
            trackBarEvaluation.TabIndex = 20;
            // 
            // labelTournoi
            // 
            labelTournoi.AutoSize = true;
            labelTournoi.Dock = DockStyle.Fill;
            labelTournoi.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelTournoi.Location = new Point(4, 0);
            labelTournoi.Margin = new Padding(4, 0, 4, 0);
            labelTournoi.Name = "labelTournoi";
            labelTournoi.Size = new Size(242, 35);
            labelTournoi.TabIndex = 16;
            labelTournoi.Text = "Nom du tournoi:";
            // 
            // labelDateHeureInscription
            // 
            labelDateHeureInscription.AutoSize = true;
            labelDateHeureInscription.Dock = DockStyle.Fill;
            labelDateHeureInscription.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelDateHeureInscription.Location = new Point(4, 73);
            labelDateHeureInscription.Margin = new Padding(4, 0, 4, 0);
            labelDateHeureInscription.Name = "labelDateHeureInscription";
            labelDateHeureInscription.Size = new Size(242, 31);
            labelDateHeureInscription.TabIndex = 21;
            labelDateHeureInscription.Text = "Date d'inscription :";
            // 
            // labelLot
            // 
            labelLot.AutoSize = true;
            labelLot.Dock = DockStyle.Fill;
            labelLot.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelLot.Location = new Point(638, 73);
            labelLot.Margin = new Padding(4, 0, 4, 0);
            labelLot.Name = "labelLot";
            labelLot.Size = new Size(218, 31);
            labelLot.TabIndex = 25;
            labelLot.Text = "Lot remis :";
            // 
            // dateTimePickerDateHeureInscription
            // 
            dateTimePickerDateHeureInscription.CustomFormat = "dd/MM/yyyy HH:mm";
            dateTimePickerDateHeureInscription.Dock = DockStyle.Fill;
            dateTimePickerDateHeureInscription.Format = DateTimePickerFormat.Custom;
            dateTimePickerDateHeureInscription.Location = new Point(4, 108);
            dateTimePickerDateHeureInscription.Margin = new Padding(4);
            dateTimePickerDateHeureInscription.MaxDate = new DateTime(2026, 5, 25, 17, 0, 0, 0);
            dateTimePickerDateHeureInscription.MinDate = new DateTime(2026, 5, 23, 9, 0, 0, 0);
            dateTimePickerDateHeureInscription.Name = "dateTimePickerDateHeureInscription";
            dateTimePickerDateHeureInscription.ShowUpDown = true;
            dateTimePickerDateHeureInscription.Size = new Size(242, 31);
            dateTimePickerDateHeureInscription.TabIndex = 34;
            dateTimePickerDateHeureInscription.Value = new DateTime(2026, 5, 23, 9, 0, 0, 0);
            // 
            // labelRang
            // 
            labelRang.AutoSize = true;
            labelRang.Dock = DockStyle.Fill;
            labelRang.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelRang.Location = new Point(522, 0);
            labelRang.Margin = new Padding(4, 0, 4, 0);
            labelRang.Name = "labelRang";
            labelRang.Size = new Size(108, 35);
            labelRang.TabIndex = 23;
            labelRang.Text = "Rang :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label2.Location = new Point(522, 73);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(108, 31);
            label2.TabIndex = 35;
            label2.Text = "Score final :";
            // 
            // numericUpDownScoreFinal
            // 
            numericUpDownScoreFinal.Dock = DockStyle.Fill;
            numericUpDownScoreFinal.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDownScoreFinal.Location = new Point(522, 108);
            numericUpDownScoreFinal.Margin = new Padding(4);
            numericUpDownScoreFinal.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            numericUpDownScoreFinal.Name = "numericUpDownScoreFinal";
            numericUpDownScoreFinal.Size = new Size(108, 31);
            numericUpDownScoreFinal.TabIndex = 38;
            // 
            // label84
            // 
            label84.AutoSize = true;
            label84.Dock = DockStyle.Fill;
            label84.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label84.Location = new Point(253, 0);
            label84.Name = "label84";
            label84.Size = new Size(262, 35);
            label84.TabIndex = 40;
            label84.Text = "Satut :";
            label84.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelStatutTournoi
            // 
            labelStatutTournoi.AutoSize = true;
            labelStatutTournoi.Dock = DockStyle.Fill;
            labelStatutTournoi.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelStatutTournoi.Location = new Point(253, 35);
            labelStatutTournoi.Name = "labelStatutTournoi";
            labelStatutTournoi.Size = new Size(262, 38);
            labelStatutTournoi.TabIndex = 41;
            labelStatutTournoi.Text = "labelStatutTournoi";
            labelStatutTournoi.TextAlign = ContentAlignment.MiddleCenter;
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
            groupBox1.Location = new Point(3, 228);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1250, 206);
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
            buttonAjouter.Location = new Point(255, 41);
            buttonAjouter.Margin = new Padding(4, 3, 4, 3);
            buttonAjouter.Name = "buttonAjouter";
            buttonAjouter.Size = new Size(150, 45);
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
            buttonEffacer.Location = new Point(70, 41);
            buttonEffacer.Margin = new Padding(4, 3, 4, 3);
            buttonEffacer.Name = "buttonEffacer";
            buttonEffacer.Size = new Size(150, 45);
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
            buttonModifier.Location = new Point(445, 41);
            buttonModifier.Margin = new Padding(4, 3, 4, 3);
            buttonModifier.Name = "buttonModifier";
            buttonModifier.Size = new Size(193, 45);
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
            buttonSupprimer.Location = new Point(671, 41);
            buttonSupprimer.Margin = new Padding(4, 3, 4, 3);
            buttonSupprimer.Name = "buttonSupprimer";
            buttonSupprimer.Size = new Size(196, 45);
            buttonSupprimer.TabIndex = 5;
            buttonSupprimer.Text = "🗑️    Supprimer";
            buttonSupprimer.UseVisualStyleBackColor = false;
            buttonSupprimer.Click += ButtonSupprimer_Click;
            // 
            // dataGridParticipations
            // 
            dataGridParticipations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridParticipations.BackgroundColor = Color.White;
            dataGridParticipations.BorderStyle = BorderStyle.None;
            dataGridParticipations.ColumnHeadersHeight = 34;
            dataGridParticipations.Dock = DockStyle.Fill;
            dataGridParticipations.Location = new Point(4, 446);
            dataGridParticipations.Margin = new Padding(4, 3, 4, 3);
            dataGridParticipations.Name = "dataGridParticipations";
            dataGridParticipations.ReadOnly = true;
            dataGridParticipations.RowHeadersWidth = 62;
            dataGridParticipations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridParticipations.Size = new Size(1256, 428);
            dataGridParticipations.TabIndex = 4;
            dataGridParticipations.CellClick += DataGridParticipations_CellClick;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(label3, 0, 0);
            tableLayoutPanel2.Controls.Add(dataGridParticipationsJoueur, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(1267, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10.3529415F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 89.64706F));
            tableLayoutPanel2.Size = new Size(430, 437);
            tableLayoutPanel2.TabIndex = 6;
            // 
            // label3
            // 
            label3.BackColor = Color.MidnightBlue;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label3.ForeColor = Color.AliceBlue;
            label3.Location = new Point(4, 0);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(422, 45);
            label3.TabIndex = 19;
            label3.Text = "Participations de l'utilisateur";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UcParticiper
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "UcParticiper";
            Size = new Size(1700, 877);
            ((System.ComponentModel.ISupportInitialize)dataGridParticipationsJoueur).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            panelForm.ResumeLayout(false);
            tableLayoutPanelCRUD.ResumeLayout(false);
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRang).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarEvaluation).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownScoreFinal).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridParticipations).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Diagnostics.Process process1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panelForm;
        private TableLayoutPanel tableLayoutPanelCRUD;
        private TableLayoutPanel tableLayoutPanel;
        private Label labelNom;
        private Label labelTournoi;
        private Label labelEvaluation;
        private Label labelComentaire;
        private GroupBox groupBox1;
        private Button buttonAjouter;
        private Button buttonEffacer;
        private Button buttonModifier;
        private Button buttonSupprimer;
        private DataGridView dataGridParticipations;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox textBoxRecherche;
        private Label label1;
        private DataGridView dataGridParticipationsJoueur;
        private TextBox textBoxCommentaire;
        private TrackBar trackBarEvaluation;
        private Label labelDateHeureInscription;
        private Label labelRang;
        private Label labelLot;
        private ComboBox comboBoxUtilisateur;
        private ComboBox comboBoxTournoi;
        private DateTimePicker dateTimePickerDateHeureInscription;
        private Label label2;
        private NumericUpDown numericUpDownRang;
        private FlowLayoutPanel flowLayoutPanel1;
        private RadioButton radioButtonLotRemisTrue;
        private RadioButton radioButtonLotRemisFalse;
        private NumericUpDown numericUpDownScoreFinal;
        private Label label3;
        private Label label84;
        private Label labelStatutTournoi;
    }
}
