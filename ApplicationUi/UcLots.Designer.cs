using System.Windows.Forms;

namespace ApplicationUi
{
    partial class UcLots
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelForm = new Panel();
            tableLayoutPanel = new TableLayoutPanel();
            labelLibelle = new Label();
            labelRang = new Label();
            textBoxLibelle = new TextBox();
            textBoxRang = new TextBox();
            labelTournoi = new Label();
            comboBoxTournoi = new ComboBox();
            panelButtons = new Panel();
            groupBox1 = new GroupBox();
            buttonAjouterLot = new Button();
            buttonEffacer = new Button();
            buttonModifier = new Button();
            buttonSupprimerLot = new Button();
            label1 = new Label();
            label2 = new Label();
            textBoxRecherche = new TextBox();
            dataGridLotComposants = new DataGridView();
            dataGridLotComposantsDunLot = new DataGridView();
            panel1 = new Panel();
            groupBox2 = new GroupBox();
            buttonAjouterLotComposant = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            comboBoxLotComposant = new ComboBox();
            labelComposant = new Label();
            panel2 = new Panel();
            label6 = new Label();
            panel3 = new Panel();
            groupBox3 = new GroupBox();
            buttonSupprimerLotComposant = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            comboBoxLotComposantDunLot = new ComboBox();
            labelComposantDunLot = new Label();
            panel4 = new Panel();
            label4 = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            dataGridLots = new DataGridView();
            panelForm.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            panelButtons.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridLotComposants).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridLotComposantsDunLot).BeginInit();
            panel1.SuspendLayout();
            groupBox2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            groupBox3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel4.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridLots).BeginInit();
            SuspendLayout();
            // 
            // panelForm
            // 
            panelForm.BackColor = Color.White;
            panelForm.Controls.Add(tableLayoutPanel);
            panelForm.Controls.Add(panelButtons);
            panelForm.Controls.Add(label2);
            panelForm.Controls.Add(textBoxRecherche);
            panelForm.Dock = DockStyle.Fill;
            panelForm.Location = new Point(4, 4);
            panelForm.Margin = new Padding(4);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(903, 334);
            panelForm.TabIndex = 1;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 3;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel.Controls.Add(labelLibelle, 0, 0);
            tableLayoutPanel.Controls.Add(labelRang, 1, 0);
            tableLayoutPanel.Controls.Add(textBoxLibelle, 0, 1);
            tableLayoutPanel.Controls.Add(textBoxRang, 1, 1);
            tableLayoutPanel.Controls.Add(labelTournoi, 2, 0);
            tableLayoutPanel.Controls.Add(comboBoxTournoi, 2, 1);
            tableLayoutPanel.Location = new Point(10, 12);
            tableLayoutPanel.Margin = new Padding(4);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 3;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.Size = new Size(799, 110);
            tableLayoutPanel.TabIndex = 0;
            // 
            // labelLibelle
            // 
            labelLibelle.AutoSize = true;
            labelLibelle.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelLibelle.Location = new Point(4, 0);
            labelLibelle.Margin = new Padding(4, 0, 4, 0);
            labelLibelle.Name = "labelLibelle";
            labelLibelle.Size = new Size(86, 23);
            labelLibelle.TabIndex = 0;
            labelLibelle.Text = "Libelle * :";
            // 
            // labelRang
            // 
            labelRang.AutoSize = true;
            labelRang.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelRang.Location = new Point(270, 0);
            labelRang.Margin = new Padding(4, 0, 4, 0);
            labelRang.Name = "labelRang";
            labelRang.Size = new Size(74, 23);
            labelRang.TabIndex = 1;
            labelRang.Text = "Rang * :";
            // 
            // textBoxLibelle
            // 
            textBoxLibelle.Location = new Point(4, 39);
            textBoxLibelle.Margin = new Padding(4);
            textBoxLibelle.Name = "textBoxLibelle";
            textBoxLibelle.PlaceholderText = "Ex: 1er Prix";
            textBoxLibelle.Size = new Size(210, 27);
            textBoxLibelle.TabIndex = 0;
            // 
            // textBoxRang
            // 
            textBoxRang.Location = new Point(270, 39);
            textBoxRang.Margin = new Padding(4);
            textBoxRang.Name = "textBoxRang";
            textBoxRang.PlaceholderText = "1";
            textBoxRang.Size = new Size(210, 27);
            textBoxRang.TabIndex = 4;
            // 
            // labelTournoi
            // 
            labelTournoi.AutoSize = true;
            labelTournoi.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelTournoi.Location = new Point(536, 0);
            labelTournoi.Margin = new Padding(4, 0, 4, 0);
            labelTournoi.Name = "labelTournoi";
            labelTournoi.Size = new Size(153, 23);
            labelTournoi.TabIndex = 3;
            labelTournoi.Text = "Tournoi associé * :";
            // 
            // comboBoxTournoi
            // 
            comboBoxTournoi.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTournoi.Location = new Point(536, 39);
            comboBoxTournoi.Margin = new Padding(4);
            comboBoxTournoi.Name = "comboBoxTournoi";
            comboBoxTournoi.Size = new Size(210, 31);
            comboBoxTournoi.TabIndex = 3;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(groupBox1);
            panelButtons.Controls.Add(label1);
            panelButtons.Location = new Point(10, 125);
            panelButtons.Margin = new Padding(4);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(879, 82);
            panelButtons.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonAjouterLot);
            groupBox1.Controls.Add(buttonEffacer);
            groupBox1.Controls.Add(buttonModifier);
            groupBox1.Controls.Add(buttonSupprimerLot);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(879, 82);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "⚡ Actions";
            // 
            // buttonAjouterLot
            // 
            buttonAjouterLot.BackColor = Color.FromArgb(76, 175, 80);
            buttonAjouterLot.FlatAppearance.BorderSize = 0;
            buttonAjouterLot.FlatStyle = FlatStyle.Flat;
            buttonAjouterLot.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonAjouterLot.ForeColor = Color.White;
            buttonAjouterLot.Location = new Point(270, 25);
            buttonAjouterLot.Margin = new Padding(4);
            buttonAjouterLot.Name = "buttonAjouterLot";
            buttonAjouterLot.Size = new Size(150, 45);
            buttonAjouterLot.TabIndex = 6;
            buttonAjouterLot.Text = "➕  Ajouter";
            buttonAjouterLot.UseVisualStyleBackColor = false;
            buttonAjouterLot.Click += buttonAjouterLot_Click;
            // 
            // buttonEffacer
            // 
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
            buttonEffacer.Text = " \U0001f9fd  Effacer";
            buttonEffacer.UseVisualStyleBackColor = false;
            buttonEffacer.Click += buttonEffacer_Click;
            // 
            // buttonModifier
            // 
            buttonModifier.BackColor = Color.FromArgb(33, 150, 243);
            buttonModifier.FlatAppearance.BorderSize = 0;
            buttonModifier.FlatStyle = FlatStyle.Flat;
            buttonModifier.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonModifier.ForeColor = Color.White;
            buttonModifier.Location = new Point(470, 25);
            buttonModifier.Margin = new Padding(4);
            buttonModifier.Name = "buttonModifier";
            buttonModifier.Size = new Size(150, 45);
            buttonModifier.TabIndex = 4;
            buttonModifier.Text = "✏️    Modifier";
            buttonModifier.UseVisualStyleBackColor = false;
            buttonModifier.Click += buttonModifier_Click;
            // 
            // buttonSupprimerLot
            // 
            buttonSupprimerLot.BackColor = Color.FromArgb(244, 67, 54);
            buttonSupprimerLot.FlatAppearance.BorderSize = 0;
            buttonSupprimerLot.FlatStyle = FlatStyle.Flat;
            buttonSupprimerLot.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonSupprimerLot.ForeColor = Color.White;
            buttonSupprimerLot.Location = new Point(670, 25);
            buttonSupprimerLot.Margin = new Padding(4);
            buttonSupprimerLot.Name = "buttonSupprimerLot";
            buttonSupprimerLot.Size = new Size(162, 45);
            buttonSupprimerLot.TabIndex = 5;
            buttonSupprimerLot.Text = "🗑️    Supprimer";
            buttonSupprimerLot.UseVisualStyleBackColor = false;
            buttonSupprimerLot.Click += buttonSupprimerLot_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 23);
            label1.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(59, 265);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(112, 25);
            label2.TabIndex = 4;
            label2.Text = "Recherche :";
            // 
            // textBoxRecherche
            // 
            textBoxRecherche.Location = new Point(222, 265);
            textBoxRecherche.Margin = new Padding(2);
            textBoxRecherche.Name = "textBoxRecherche";
            textBoxRecherche.Size = new Size(574, 27);
            textBoxRecherche.TabIndex = 5;
            textBoxRecherche.TextChanged += textBoxRecherche_TextChanged;
            // 
            // dataGridLotComposants
            // 
            dataGridLotComposants.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridLotComposants.BackgroundColor = Color.White;
            dataGridLotComposants.BorderStyle = BorderStyle.None;
            dataGridLotComposants.ColumnHeadersHeight = 34;
            dataGridLotComposants.Dock = DockStyle.Fill;
            dataGridLotComposants.Location = new Point(915, 346);
            dataGridLotComposants.Margin = new Padding(4);
            dataGridLotComposants.Name = "dataGridLotComposants";
            dataGridLotComposants.ReadOnly = true;
            dataGridLotComposants.RowHeadersWidth = 62;
            dataGridLotComposants.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridLotComposants.Size = new Size(271, 358);
            dataGridLotComposants.TabIndex = 6;
            dataGridLotComposants.CellClick += dataGridLotComposants_CellClick;
            // 
            // dataGridLotComposantsDunLot
            // 
            dataGridLotComposantsDunLot.BackgroundColor = Color.White;
            dataGridLotComposantsDunLot.BorderStyle = BorderStyle.None;
            dataGridLotComposantsDunLot.ColumnHeadersHeight = 34;
            dataGridLotComposantsDunLot.Dock = DockStyle.Fill;
            dataGridLotComposantsDunLot.Location = new Point(1194, 346);
            dataGridLotComposantsDunLot.Margin = new Padding(4);
            dataGridLotComposantsDunLot.Name = "dataGridLotComposantsDunLot";
            dataGridLotComposantsDunLot.ReadOnly = true;
            dataGridLotComposantsDunLot.RowHeadersWidth = 62;
            dataGridLotComposantsDunLot.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridLotComposantsDunLot.Size = new Size(260, 358);
            dataGridLotComposantsDunLot.TabIndex = 7;
            dataGridLotComposantsDunLot.CellClick += dataGridLotComposantsDunLot_CellClick;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(915, 4);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(271, 210);
            panel1.TabIndex = 2;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(buttonAjouterLotComposant);
            groupBox2.Location = new Point(10, 125);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(229, 82);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "⚡ Actions";
            // 
            // buttonAjouterLotComposant
            // 
            buttonAjouterLotComposant.BackColor = Color.FromArgb(76, 175, 80);
            buttonAjouterLotComposant.FlatAppearance.BorderSize = 0;
            buttonAjouterLotComposant.FlatStyle = FlatStyle.Flat;
            buttonAjouterLotComposant.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonAjouterLotComposant.ForeColor = Color.White;
            buttonAjouterLotComposant.Location = new Point(28, 25);
            buttonAjouterLotComposant.Margin = new Padding(4);
            buttonAjouterLotComposant.Name = "buttonAjouterLotComposant";
            buttonAjouterLotComposant.Size = new Size(186, 45);
            buttonAjouterLotComposant.TabIndex = 6;
            buttonAjouterLotComposant.Text = "➕  Ajouter au lot";
            buttonAjouterLotComposant.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(comboBoxLotComposant, 0, 1);
            tableLayoutPanel1.Controls.Add(labelComposant, 0, 0);
            tableLayoutPanel1.Location = new Point(10, 12);
            tableLayoutPanel1.Margin = new Padding(4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(229, 110);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // comboBoxLotComposant
            // 
            comboBoxLotComposant.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxLotComposant.Location = new Point(4, 39);
            comboBoxLotComposant.Margin = new Padding(4);
            comboBoxLotComposant.Name = "comboBoxLotComposant";
            comboBoxLotComposant.Size = new Size(210, 31);
            comboBoxLotComposant.TabIndex = 4;
            // 
            // labelComposant
            // 
            labelComposant.AutoSize = true;
            labelComposant.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelComposant.Location = new Point(4, 0);
            labelComposant.Margin = new Padding(4, 0, 4, 0);
            labelComposant.Name = "labelComposant";
            labelComposant.Size = new Size(180, 23);
            labelComposant.TabIndex = 0;
            labelComposant.Text = "Composant de Lot * :";
            // 
            // panel2
            // 
            panel2.Controls.Add(label6);
            panel2.Location = new Point(10, 125);
            panel2.Margin = new Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new Size(229, 82);
            panel2.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(0, 0);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(0, 23);
            label6.TabIndex = 6;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(groupBox3);
            panel3.Controls.Add(tableLayoutPanel2);
            panel3.Controls.Add(panel4);
            panel3.Location = new Point(1194, 4);
            panel3.Margin = new Padding(4);
            panel3.Name = "panel3";
            panel3.Size = new Size(259, 210);
            panel3.TabIndex = 8;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(buttonSupprimerLotComposant);
            groupBox3.Location = new Point(10, 125);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(245, 82);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "⚡ Actions";
            // 
            // buttonSupprimerLotComposant
            // 
            buttonSupprimerLotComposant.BackColor = Color.FromArgb(244, 67, 54);
            buttonSupprimerLotComposant.FlatAppearance.BorderSize = 0;
            buttonSupprimerLotComposant.FlatStyle = FlatStyle.Flat;
            buttonSupprimerLotComposant.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonSupprimerLotComposant.ForeColor = Color.White;
            buttonSupprimerLotComposant.Location = new Point(15, 25);
            buttonSupprimerLotComposant.Margin = new Padding(4);
            buttonSupprimerLotComposant.Name = "buttonSupprimerLotComposant";
            buttonSupprimerLotComposant.Size = new Size(223, 45);
            buttonSupprimerLotComposant.TabIndex = 7;
            buttonSupprimerLotComposant.Text = "🗑️    Supprimer du lot";
            buttonSupprimerLotComposant.UseVisualStyleBackColor = false;
            buttonSupprimerLotComposant.Click += buttonSupprimerLotComposant_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.Controls.Add(comboBoxLotComposantDunLot, 0, 1);
            tableLayoutPanel2.Controls.Add(labelComposantDunLot, 0, 0);
            tableLayoutPanel2.Location = new Point(10, 12);
            tableLayoutPanel2.Margin = new Padding(4);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(229, 110);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // comboBoxLotComposantDunLot
            // 
            comboBoxLotComposantDunLot.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxLotComposantDunLot.Location = new Point(4, 39);
            comboBoxLotComposantDunLot.Margin = new Padding(4);
            comboBoxLotComposantDunLot.Name = "comboBoxLotComposantDunLot";
            comboBoxLotComposantDunLot.Size = new Size(210, 31);
            comboBoxLotComposantDunLot.TabIndex = 4;
            // 
            // labelComposantDunLot
            // 
            labelComposantDunLot.AutoSize = true;
            labelComposantDunLot.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelComposantDunLot.Location = new Point(4, 0);
            labelComposantDunLot.Margin = new Padding(4, 0, 4, 0);
            labelComposantDunLot.Name = "labelComposantDunLot";
            labelComposantDunLot.Size = new Size(163, 35);
            labelComposantDunLot.TabIndex = 0;
            labelComposantDunLot.Text = "Composant du Lot selectionné * :";
            // 
            // panel4
            // 
            panel4.Controls.Add(label4);
            panel4.Location = new Point(10, 125);
            panel4.Margin = new Padding(4);
            panel4.Name = "panel4";
            panel4.Size = new Size(229, 82);
            panel4.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(0, 0);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(0, 23);
            label4.TabIndex = 6;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 76.51007F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.489933F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 267F));
            tableLayoutPanel3.Controls.Add(panelForm, 0, 0);
            tableLayoutPanel3.Controls.Add(panel1, 1, 0);
            tableLayoutPanel3.Controls.Add(panel3, 2, 0);
            tableLayoutPanel3.Controls.Add(dataGridLotComposantsDunLot, 2, 1);
            tableLayoutPanel3.Controls.Add(dataGridLots, 0, 1);
            tableLayoutPanel3.Controls.Add(dataGridLotComposants, 1, 1);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 48.39109F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 51.60891F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 307F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new Size(1458, 708);
            tableLayoutPanel3.TabIndex = 9;
            // 
            // dataGridLots
            // 
            dataGridLots.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridLots.BackgroundColor = Color.White;
            dataGridLots.BorderStyle = BorderStyle.None;
            dataGridLots.ColumnHeadersHeight = 34;
            dataGridLots.Dock = DockStyle.Fill;
            dataGridLots.Location = new Point(4, 346);
            dataGridLots.Margin = new Padding(4);
            dataGridLots.Name = "dataGridLots";
            dataGridLots.ReadOnly = true;
            dataGridLots.RowHeadersWidth = 62;
            dataGridLots.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridLots.Size = new Size(903, 358);
            dataGridLots.TabIndex = 2;
            dataGridLots.CellClick += dataGridLots_CellClick;
            // 
            // UcLots
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(227, 242, 253);
            Controls.Add(tableLayoutPanel3);
            Font = new Font("Trebuchet MS", 10F);
            Margin = new Padding(4);
            Name = "UcLots";
            Size = new Size(1458, 708);
            panelForm.ResumeLayout(false);
            panelForm.PerformLayout();
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            panelButtons.ResumeLayout(false);
            panelButtons.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridLotComposants).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridLotComposantsDunLot).EndInit();
            panel1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridLots).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelForm;
        private TableLayoutPanel tableLayoutPanel;
        private TextBox textBoxLibelle;
        private ComboBox comboBoxTournoi;
        private Label labelLibelle;
        private Label labelRang;
        private Label labelTournoi;
        private Panel panelButtons;
        private GroupBox groupBox1;
        private Button buttonAjouterLot;
        private Button buttonEffacer;
        private Button buttonModifier;
        private Button buttonSupprimerLot;
        private Label label1;
        private Label label2;
        private TextBox textBoxRecherche;
        private TextBox textBoxRang;
        private DataGridView dataGridLotComposants;
        private DataGridView dataGridLotComposantsDunLot;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label labelComposant;
        private GroupBox groupBox2;
        private Button buttonAjouterLotComposant;
        private Panel panel2;
        private Label label6;
        private ComboBox comboBoxLotComposant;
        private Panel panel3;
        private GroupBox groupBox3;
        private Button buttonSupprimerLotComposant;
        private TableLayoutPanel tableLayoutPanel2;
        private ComboBox comboBoxLotComposantDunLot;
        private Label labelComposantDunLot;
        private Panel panel4;
        private Label label4;
        private TableLayoutPanel tableLayoutPanel3;
        private DataGridView dataGridLots;
    }
}