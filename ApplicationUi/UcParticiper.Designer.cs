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
            labelStatEspacesLibres = new Label();
            labelStatEspacesTotal = new Label();
            dataGridParticipationsUtilisateur = new DataGridView();
            groupBoxStatsEspaces = new GroupBox();
            labelTitreEspaces = new Label();
            label1 = new Label();
            labelNom = new Label();
            textBoxRecherche = new TextBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panelForm = new Panel();
            tableLayoutPanelCRUD = new TableLayoutPanel();
            tableLayoutPanel = new TableLayoutPanel();
            comboBoxUtilisateur = new ComboBox();
            comboBoxTournoi = new ComboBox();
            comboBoxLotRemis = new ComboBox();
            labelStatutTournoi = new Label();
            textBox1 = new TextBox();
            labelEvaluation = new Label();
            trackBarEvaluation = new TrackBar();
            labelTournoi = new Label();
            labelDateHeureInscription = new Label();
            labelLot = new Label();
            dateTimePickerDateTournoi = new DateTimePicker();
            labelRang = new Label();
            textBox3 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            groupBox1 = new GroupBox();
            buttonAjouter = new Button();
            buttonEffacer = new Button();
            buttonModifier = new Button();
            buttonSupprimer = new Button();
            dataGridParticipations = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridParticipationsUtilisateur).BeginInit();
            groupBoxStatsEspaces.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panelForm.SuspendLayout();
            tableLayoutPanelCRUD.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarEvaluation).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridParticipations).BeginInit();
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
            labelStatEspacesTotal.Size = new Size(408, 75);
            labelStatEspacesTotal.TabIndex = 1;
            labelStatEspacesTotal.Text = "12";
            labelStatEspacesTotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dataGridParticipationsUtilisateur
            // 
            dataGridParticipationsUtilisateur.AccessibleDescription = "Participations associés à l'utilisateur séléctionné";
            dataGridParticipationsUtilisateur.AllowUserToAddRows = false;
            dataGridParticipationsUtilisateur.AllowUserToDeleteRows = false;
            dataGridParticipationsUtilisateur.AllowUserToOrderColumns = true;
            dataGridParticipationsUtilisateur.BackgroundColor = Color.White;
            dataGridParticipationsUtilisateur.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridParticipationsUtilisateur.Dock = DockStyle.Fill;
            dataGridParticipationsUtilisateur.Location = new Point(1275, 3);
            dataGridParticipationsUtilisateur.Name = "dataGridParticipationsUtilisateur";
            dataGridParticipationsUtilisateur.ReadOnly = true;
            dataGridParticipationsUtilisateur.RowHeadersWidth = 62;
            dataGridParticipationsUtilisateur.Size = new Size(422, 386);
            dataGridParticipationsUtilisateur.TabIndex = 5;
            // 
            // groupBoxStatsEspaces
            // 
            groupBoxStatsEspaces.BackColor = Color.White;
            groupBoxStatsEspaces.Controls.Add(labelStatEspacesLibres);
            groupBoxStatsEspaces.Controls.Add(labelStatEspacesTotal);
            groupBoxStatsEspaces.Controls.Add(labelTitreEspaces);
            groupBoxStatsEspaces.Dock = DockStyle.Top;
            groupBoxStatsEspaces.Location = new Point(1276, 659);
            groupBoxStatsEspaces.Margin = new Padding(4, 5, 4, 5);
            groupBoxStatsEspaces.Name = "groupBoxStatsEspaces";
            groupBoxStatsEspaces.Padding = new Padding(4, 5, 4, 5);
            groupBoxStatsEspaces.Size = new Size(420, 213);
            groupBoxStatsEspaces.TabIndex = 7;
            groupBoxStatsEspaces.TabStop = false;
            // 
            // labelTitreEspaces
            // 
            labelTitreEspaces.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelTitreEspaces.ForeColor = Color.FromArgb(100, 100, 100);
            labelTitreEspaces.Location = new Point(8, 24);
            labelTitreEspaces.Margin = new Padding(4, 0, 4, 0);
            labelTitreEspaces.Name = "labelTitreEspaces";
            labelTitreEspaces.Size = new Size(400, 33);
            labelTitreEspaces.TabIndex = 0;
            labelTitreEspaces.Text = "🏢 ESPACES";
            labelTitreEspaces.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(131, 30);
            label1.TabIndex = 1;
            label1.Text = "Recherche :";
            // 
            // labelNom
            // 
            labelNom.AutoSize = true;
            labelNom.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelNom.Location = new Point(223, 0);
            labelNom.Margin = new Padding(4, 0, 4, 0);
            labelNom.Name = "labelNom";
            labelNom.Size = new Size(139, 35);
            labelNom.TabIndex = 6;
            labelNom.Text = "Id utilisateur :";
            // 
            // textBoxRecherche
            // 
            textBoxRecherche.Location = new Point(240, 3);
            textBoxRecherche.Name = "textBoxRecherche";
            textBoxRecherche.Size = new Size(1001, 31);
            textBoxRecherche.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.7640457F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 81.2359543F));
            tableLayoutPanel2.Controls.Add(textBoxRecherche, 1, 0);
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Bottom;
            tableLayoutPanel2.Location = new Point(3, 400);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(1266, 35);
            tableLayoutPanel2.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 74.87981F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.1201916F));
            tableLayoutPanel1.Controls.Add(panelForm, 0, 0);
            tableLayoutPanel1.Controls.Add(dataGridParticipations, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(dataGridParticipationsUtilisateur, 1, 0);
            tableLayoutPanel1.Controls.Add(groupBoxStatsEspaces, 1, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 89.49772F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10.5022831F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 216F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 222F));
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
            panelForm.Size = new Size(1264, 386);
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
            tableLayoutPanelCRUD.RowStyles.Add(new RowStyle(SizeType.Percent, 66.1721039F));
            tableLayoutPanelCRUD.RowStyles.Add(new RowStyle(SizeType.Percent, 33.8278923F));
            tableLayoutPanelCRUD.Size = new Size(1264, 386);
            tableLayoutPanelCRUD.TabIndex = 8;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel.ColumnCount = 5;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 39.38849F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.1582737F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.4532356F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 238F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 461F));
            tableLayoutPanel.Controls.Add(comboBoxUtilisateur, 1, 1);
            tableLayoutPanel.Controls.Add(comboBoxTournoi, 0, 1);
            tableLayoutPanel.Controls.Add(comboBoxLotRemis, 3, 3);
            tableLayoutPanel.Controls.Add(labelStatutTournoi, 4, 0);
            tableLayoutPanel.Controls.Add(textBox1, 4, 1);
            tableLayoutPanel.Controls.Add(labelEvaluation, 3, 0);
            tableLayoutPanel.Controls.Add(trackBarEvaluation, 3, 1);
            tableLayoutPanel.Controls.Add(labelTournoi, 0, 0);
            tableLayoutPanel.Controls.Add(labelNom, 1, 0);
            tableLayoutPanel.Controls.Add(labelDateHeureInscription, 0, 2);
            tableLayoutPanel.Controls.Add(labelLot, 3, 2);
            tableLayoutPanel.Controls.Add(dateTimePickerDateTournoi, 0, 3);
            tableLayoutPanel.Controls.Add(labelRang, 2, 0);
            tableLayoutPanel.Controls.Add(textBox3, 2, 1);
            tableLayoutPanel.Controls.Add(label2, 2, 2);
            tableLayoutPanel.Controls.Add(textBox2, 2, 3);
            tableLayoutPanel.Location = new Point(4, 3);
            tableLayoutPanel.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 4;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 59F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 65F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.Size = new Size(1256, 249);
            tableLayoutPanel.TabIndex = 0;
            // 
            // comboBoxUtilisateur
            // 
            comboBoxUtilisateur.Dock = DockStyle.Fill;
            comboBoxUtilisateur.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxUtilisateur.Location = new Point(223, 39);
            comboBoxUtilisateur.Margin = new Padding(4);
            comboBoxUtilisateur.Name = "comboBoxUtilisateur";
            comboBoxUtilisateur.Size = new Size(143, 33);
            comboBoxUtilisateur.TabIndex = 33;
            // 
            // comboBoxTournoi
            // 
            comboBoxTournoi.Dock = DockStyle.Fill;
            comboBoxTournoi.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTournoi.Location = new Point(4, 39);
            comboBoxTournoi.Margin = new Padding(4);
            comboBoxTournoi.Name = "comboBoxTournoi";
            comboBoxTournoi.Size = new Size(211, 33);
            comboBoxTournoi.TabIndex = 32;
            // 
            // comboBoxLotRemis
            // 
            comboBoxLotRemis.Dock = DockStyle.Fill;
            comboBoxLotRemis.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxLotRemis.Location = new Point(560, 133);
            comboBoxLotRemis.Margin = new Padding(4);
            comboBoxLotRemis.Name = "comboBoxLotRemis";
            comboBoxLotRemis.Size = new Size(230, 33);
            comboBoxLotRemis.TabIndex = 30;
            // 
            // labelStatutTournoi
            // 
            labelStatutTournoi.BackColor = Color.MidnightBlue;
            labelStatutTournoi.Dock = DockStyle.Fill;
            labelStatutTournoi.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelStatutTournoi.ForeColor = Color.AliceBlue;
            labelStatutTournoi.Location = new Point(798, 0);
            labelStatutTournoi.Margin = new Padding(4, 0, 4, 0);
            labelStatutTournoi.Name = "labelStatutTournoi";
            labelStatutTournoi.Size = new Size(454, 35);
            labelStatutTournoi.TabIndex = 18;
            labelStatutTournoi.Text = "Commentaire";
            labelStatutTournoi.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(797, 38);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Laisser un commentaire sur le tournoi...";
            tableLayoutPanel.SetRowSpan(textBox1, 3);
            textBox1.Size = new Size(456, 208);
            textBox1.TabIndex = 19;
            // 
            // labelEvaluation
            // 
            labelEvaluation.AutoSize = true;
            labelEvaluation.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelEvaluation.Location = new Point(560, 0);
            labelEvaluation.Margin = new Padding(4, 0, 4, 0);
            labelEvaluation.Name = "labelEvaluation";
            labelEvaluation.Size = new Size(123, 28);
            labelEvaluation.TabIndex = 8;
            labelEvaluation.Text = "Évaluation :";
            // 
            // trackBarEvaluation
            // 
            trackBarEvaluation.BackColor = Color.White;
            trackBarEvaluation.Dock = DockStyle.Fill;
            trackBarEvaluation.Location = new Point(559, 38);
            trackBarEvaluation.Name = "trackBarEvaluation";
            trackBarEvaluation.Size = new Size(232, 53);
            trackBarEvaluation.TabIndex = 20;
            // 
            // labelTournoi
            // 
            labelTournoi.AutoSize = true;
            labelTournoi.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelTournoi.Location = new Point(4, 0);
            labelTournoi.Margin = new Padding(4, 0, 4, 0);
            labelTournoi.Name = "labelTournoi";
            labelTournoi.Size = new Size(169, 28);
            labelTournoi.TabIndex = 16;
            labelTournoi.Text = "Nom du tournoi:";
            // 
            // labelDateHeureInscription
            // 
            labelDateHeureInscription.AutoSize = true;
            labelDateHeureInscription.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelDateHeureInscription.Location = new Point(4, 94);
            labelDateHeureInscription.Margin = new Padding(4, 0, 4, 0);
            labelDateHeureInscription.Name = "labelDateHeureInscription";
            labelDateHeureInscription.Size = new Size(193, 28);
            labelDateHeureInscription.TabIndex = 21;
            labelDateHeureInscription.Text = "Date d'inscription :";
            // 
            // labelLot
            // 
            labelLot.AutoSize = true;
            labelLot.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelLot.Location = new Point(560, 94);
            labelLot.Margin = new Padding(4, 0, 4, 0);
            labelLot.Name = "labelLot";
            labelLot.Size = new Size(111, 28);
            labelLot.TabIndex = 25;
            labelLot.Text = "Lot remis :";
            // 
            // dateTimePickerDateTournoi
            // 
            dateTimePickerDateTournoi.CustomFormat = "dd/MM/yyyy HH:mm";
            dateTimePickerDateTournoi.Dock = DockStyle.Fill;
            dateTimePickerDateTournoi.Format = DateTimePickerFormat.Custom;
            dateTimePickerDateTournoi.Location = new Point(4, 133);
            dateTimePickerDateTournoi.Margin = new Padding(4);
            dateTimePickerDateTournoi.MaxDate = new DateTime(2026, 5, 25, 17, 0, 0, 0);
            dateTimePickerDateTournoi.MinDate = new DateTime(2026, 5, 23, 9, 0, 0, 0);
            dateTimePickerDateTournoi.Name = "dateTimePickerDateTournoi";
            dateTimePickerDateTournoi.ShowUpDown = true;
            dateTimePickerDateTournoi.Size = new Size(211, 31);
            dateTimePickerDateTournoi.TabIndex = 34;
            dateTimePickerDateTournoi.Value = new DateTime(2026, 5, 23, 9, 0, 0, 0);
            // 
            // labelRang
            // 
            labelRang.AutoSize = true;
            labelRang.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelRang.Location = new Point(374, 0);
            labelRang.Margin = new Padding(4, 0, 4, 0);
            labelRang.Name = "labelRang";
            labelRang.Size = new Size(71, 28);
            labelRang.TabIndex = 23;
            labelRang.Text = "Rang :";
            // 
            // textBox3
            // 
            textBox3.Enabled = false;
            textBox3.Location = new Point(374, 38);
            textBox3.Margin = new Padding(4, 3, 4, 3);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Ex: 8/26";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(144, 31);
            textBox3.TabIndex = 24;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label2.Location = new Point(374, 94);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(124, 28);
            label2.TabIndex = 35;
            label2.Text = "Score final :";
            // 
            // textBox2
            // 
            textBox2.Enabled = false;
            textBox2.Location = new Point(374, 132);
            textBox2.Margin = new Padding(4, 3, 4, 3);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Ex: 253 points";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(144, 31);
            textBox2.TabIndex = 36;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(buttonAjouter);
            groupBox1.Controls.Add(buttonEffacer);
            groupBox1.Controls.Add(buttonModifier);
            groupBox1.Controls.Add(buttonSupprimer);
            groupBox1.Location = new Point(3, 258);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1258, 125);
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
            buttonAjouter.Location = new Point(254, 25);
            buttonAjouter.Margin = new Padding(4, 3, 4, 3);
            buttonAjouter.Name = "buttonAjouter";
            buttonAjouter.Size = new Size(150, 45);
            buttonAjouter.TabIndex = 6;
            buttonAjouter.Text = "➕  Ajouter";
            buttonAjouter.UseVisualStyleBackColor = false;
            // 
            // buttonEffacer
            // 
            buttonEffacer.BackColor = Color.MediumPurple;
            buttonEffacer.FlatAppearance.BorderSize = 0;
            buttonEffacer.FlatStyle = FlatStyle.Flat;
            buttonEffacer.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonEffacer.ForeColor = Color.White;
            buttonEffacer.Location = new Point(70, 25);
            buttonEffacer.Margin = new Padding(4, 3, 4, 3);
            buttonEffacer.Name = "buttonEffacer";
            buttonEffacer.Size = new Size(150, 45);
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
            buttonModifier.Location = new Point(443, 25);
            buttonModifier.Margin = new Padding(4, 3, 4, 3);
            buttonModifier.Name = "buttonModifier";
            buttonModifier.Size = new Size(193, 45);
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
            buttonSupprimer.Location = new Point(670, 25);
            buttonSupprimer.Margin = new Padding(4, 3, 4, 3);
            buttonSupprimer.Name = "buttonSupprimer";
            buttonSupprimer.Size = new Size(196, 45);
            buttonSupprimer.TabIndex = 5;
            buttonSupprimer.Text = "🗑️    Supprimer";
            buttonSupprimer.UseVisualStyleBackColor = false;
            // 
            // dataGridParticipations
            // 
            dataGridParticipations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridParticipations.BackgroundColor = Color.White;
            dataGridParticipations.BorderStyle = BorderStyle.None;
            dataGridParticipations.ColumnHeadersHeight = 34;
            dataGridParticipations.Dock = DockStyle.Fill;
            dataGridParticipations.Location = new Point(4, 441);
            dataGridParticipations.Margin = new Padding(4, 3, 4, 3);
            dataGridParticipations.Name = "dataGridParticipations";
            dataGridParticipations.ReadOnly = true;
            dataGridParticipations.RowHeadersWidth = 62;
            tableLayoutPanel1.SetRowSpan(dataGridParticipations, 2);
            dataGridParticipations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridParticipations.Size = new Size(1264, 433);
            dataGridParticipations.TabIndex = 4;
            // 
            // UcParticiper
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "UcParticiper";
            Size = new Size(1700, 877);
            ((System.ComponentModel.ISupportInitialize)dataGridParticipationsUtilisateur).EndInit();
            groupBoxStatsEspaces.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panelForm.ResumeLayout(false);
            tableLayoutPanelCRUD.ResumeLayout(false);
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarEvaluation).EndInit();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridParticipations).EndInit();
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
        private Label labelStatutTournoi;
        private GroupBox groupBox1;
        private Button buttonAjouter;
        private Button buttonEffacer;
        private Button buttonModifier;
        private Button buttonSupprimer;
        private DataGridView dataGridParticipations;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox textBoxRecherche;
        private Label label1;
        private DataGridView dataGridParticipationsUtilisateur;
        private GroupBox groupBoxStatsEspaces;
        private Label labelStatEspacesLibres;
        private Label labelStatEspacesTotal;
        private Label labelTitreEspaces;
        private TextBox textBox1;
        private TrackBar trackBarEvaluation;
        private Label labelDateHeureInscription;
        private Label labelRang;
        private TextBox textBox3;
        private Label labelLot;
        private ComboBox comboBoxLotRemis;
        private ComboBox comboBoxUtilisateur;
        private ComboBox comboBoxTournoi;
        private DateTimePicker dateTimePickerDateTournoi;
        private Label label2;
        private TextBox textBox2;
    }
}
