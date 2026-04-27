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
            boutonAjouterLot = new Button();
            boutonEffacer = new Button();
            boutonModifier = new Button();
            boutonSupprimerLot = new Button();
            label1 = new Label();
            label2 = new Label();
            textBoxRecherche = new TextBox();
            dataGridLotComposants = new DataGridView();
            dataGridLotComposantsDunLot = new DataGridView();
            panel1 = new Panel();
            groupBox2 = new GroupBox();
            boutonAjouterLotComposant = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            comboBoxLotComposant = new ComboBox();
            labelComposant = new Label();
            panel2 = new Panel();
            label6 = new Label();
            panel3 = new Panel();
            groupBox3 = new GroupBox();
            boutonSupprimerLotComposant = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            comboBoxLotComposantDunLot = new ComboBox();
            labelComposantDunLot = new Label();
            panel4 = new Panel();
            label4 = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            groupBox4 = new GroupBox();
            labelStatsComposantDunLotTotal = new Label();
            labelTitreComposantDunLot = new Label();
            dataGridLots = new DataGridView();
            groupBoxStatsEspaces = new GroupBox();
            labelStatLotNonAttribue = new Label();
            labelStatLotsTotal = new Label();
            labelTitreLot = new Label();
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
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridLots).BeginInit();
            groupBoxStatsEspaces.SuspendLayout();
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
            panelForm.Size = new Size(906, 264);
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
            labelLibelle.Size = new Size(67, 17);
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
            labelRang.Size = new Size(57, 17);
            labelRang.TabIndex = 1;
            labelRang.Text = "Rang * :";
            // 
            // textBoxLibelle
            // 
            textBoxLibelle.Location = new Point(4, 39);
            textBoxLibelle.Margin = new Padding(4);
            textBoxLibelle.Name = "textBoxLibelle";
            textBoxLibelle.PlaceholderText = "Ex: Lot de clavier";
            textBoxLibelle.Size = new Size(210, 23);
            textBoxLibelle.TabIndex = 0;
            // 
            // textBoxRang
            // 
            textBoxRang.Location = new Point(270, 39);
            textBoxRang.Margin = new Padding(4);
            textBoxRang.Name = "textBoxRang";
            textBoxRang.PlaceholderText = "1,2,3...";
            textBoxRang.Size = new Size(210, 23);
            textBoxRang.TabIndex = 4;
            // 
            // labelTournoi
            // 
            labelTournoi.AutoSize = true;
            labelTournoi.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelTournoi.Location = new Point(536, 0);
            labelTournoi.Margin = new Padding(4, 0, 4, 0);
            labelTournoi.Name = "labelTournoi";
            labelTournoi.Size = new Size(122, 17);
            labelTournoi.TabIndex = 3;
            labelTournoi.Text = "Tournoi associé * :";
            // 
            // comboBoxTournoi
            // 
            comboBoxTournoi.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTournoi.Location = new Point(536, 39);
            comboBoxTournoi.Margin = new Padding(4);
            comboBoxTournoi.Name = "comboBoxTournoi";
            comboBoxTournoi.Size = new Size(210, 26);
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
            groupBox1.Controls.Add(boutonAjouterLot);
            groupBox1.Controls.Add(boutonEffacer);
            groupBox1.Controls.Add(boutonModifier);
            groupBox1.Controls.Add(boutonSupprimerLot);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(879, 82);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "⚡ Actions";
            // 
            // boutonAjouterLot
            // 
            boutonAjouterLot.BackColor = Color.FromArgb(76, 175, 80);
            boutonAjouterLot.FlatAppearance.BorderSize = 0;
            boutonAjouterLot.FlatStyle = FlatStyle.Flat;
            boutonAjouterLot.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            boutonAjouterLot.ForeColor = Color.White;
            boutonAjouterLot.Location = new Point(270, 25);
            boutonAjouterLot.Margin = new Padding(4);
            boutonAjouterLot.Name = "boutonAjouterLot";
            boutonAjouterLot.Size = new Size(150, 45);
            boutonAjouterLot.TabIndex = 6;
            boutonAjouterLot.Text = "➕  Ajouter";
            boutonAjouterLot.UseVisualStyleBackColor = false;
            boutonAjouterLot.Click += BoutonAjouterLot_Click;
            // 
            // boutonEffacer
            // 
            boutonEffacer.BackColor = Color.MediumPurple;
            boutonEffacer.FlatAppearance.BorderSize = 0;
            boutonEffacer.FlatStyle = FlatStyle.Flat;
            boutonEffacer.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            boutonEffacer.ForeColor = Color.White;
            boutonEffacer.Location = new Point(70, 25);
            boutonEffacer.Margin = new Padding(4);
            boutonEffacer.Name = "boutonEffacer";
            boutonEffacer.Size = new Size(150, 45);
            boutonEffacer.TabIndex = 3;
            boutonEffacer.Text = " \U0001f9fd  Effacer";
            boutonEffacer.UseVisualStyleBackColor = false;
            boutonEffacer.Click += BoutonEffacer_Click;
            // 
            // boutonModifier
            // 
            boutonModifier.BackColor = Color.FromArgb(33, 150, 243);
            boutonModifier.FlatAppearance.BorderSize = 0;
            boutonModifier.FlatStyle = FlatStyle.Flat;
            boutonModifier.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            boutonModifier.ForeColor = Color.White;
            boutonModifier.Location = new Point(470, 25);
            boutonModifier.Margin = new Padding(4);
            boutonModifier.Name = "boutonModifier";
            boutonModifier.Size = new Size(150, 45);
            boutonModifier.TabIndex = 4;
            boutonModifier.Text = "✏️    Modifier";
            boutonModifier.UseVisualStyleBackColor = false;
            boutonModifier.Click += BoutonModifierLot_Click;
            // 
            // boutonSupprimerLot
            // 
            boutonSupprimerLot.BackColor = Color.FromArgb(244, 67, 54);
            boutonSupprimerLot.FlatAppearance.BorderSize = 0;
            boutonSupprimerLot.FlatStyle = FlatStyle.Flat;
            boutonSupprimerLot.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            boutonSupprimerLot.ForeColor = Color.White;
            boutonSupprimerLot.Location = new Point(670, 25);
            boutonSupprimerLot.Margin = new Padding(4);
            boutonSupprimerLot.Name = "boutonSupprimerLot";
            boutonSupprimerLot.Size = new Size(162, 45);
            boutonSupprimerLot.TabIndex = 5;
            boutonSupprimerLot.Text = "🗑️    Supprimer";
            boutonSupprimerLot.UseVisualStyleBackColor = false;
            boutonSupprimerLot.Click += BoutonSupprimerLot_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 18);
            label1.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(53, 226);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(89, 20);
            label2.TabIndex = 4;
            label2.Text = "Recherche :";
            // 
            // textBoxRecherche
            // 
            textBoxRecherche.Location = new Point(182, 226);
            textBoxRecherche.Margin = new Padding(2);
            textBoxRecherche.Name = "textBoxRecherche";
            textBoxRecherche.PlaceholderText = "Ex: Clavier";
            textBoxRecherche.Size = new Size(574, 23);
            textBoxRecherche.TabIndex = 5;
            textBoxRecherche.TextChanged += TextBoxRecherche_TextChanged;
            // 
            // dataGridLotComposants
            // 
            dataGridLotComposants.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridLotComposants.BackgroundColor = Color.White;
            dataGridLotComposants.BorderStyle = BorderStyle.None;
            dataGridLotComposants.ColumnHeadersHeight = 34;
            dataGridLotComposants.Dock = DockStyle.Fill;
            dataGridLotComposants.Location = new Point(918, 276);
            dataGridLotComposants.Margin = new Padding(4);
            dataGridLotComposants.Name = "dataGridLotComposants";
            dataGridLotComposants.ReadOnly = true;
            dataGridLotComposants.RowHeadersWidth = 62;
            dataGridLotComposants.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridLotComposants.Size = new Size(259, 329);
            dataGridLotComposants.TabIndex = 6;
            dataGridLotComposants.CellClick += DataGridLotComposants_CellClick;
            // 
            // dataGridLotComposantsDunLot
            // 
            dataGridLotComposantsDunLot.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridLotComposantsDunLot.BackgroundColor = Color.White;
            dataGridLotComposantsDunLot.BorderStyle = BorderStyle.None;
            dataGridLotComposantsDunLot.ColumnHeadersHeight = 34;
            dataGridLotComposantsDunLot.Dock = DockStyle.Fill;
            dataGridLotComposantsDunLot.Location = new Point(1185, 276);
            dataGridLotComposantsDunLot.Margin = new Padding(4);
            dataGridLotComposantsDunLot.Name = "dataGridLotComposantsDunLot";
            dataGridLotComposantsDunLot.ReadOnly = true;
            dataGridLotComposantsDunLot.RowHeadersWidth = 62;
            dataGridLotComposantsDunLot.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridLotComposantsDunLot.Size = new Size(297, 329);
            dataGridLotComposantsDunLot.TabIndex = 7;
            dataGridLotComposantsDunLot.CellClick += DataGridLotComposantsDunLot_CellClick;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(918, 4);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(259, 264);
            panel1.TabIndex = 2;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(boutonAjouterLotComposant);
            groupBox2.Location = new Point(10, 125);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(229, 82);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "⚡ Actions";
            // 
            // boutonAjouterLotComposant
            // 
            boutonAjouterLotComposant.BackColor = Color.FromArgb(76, 175, 80);
            boutonAjouterLotComposant.FlatAppearance.BorderSize = 0;
            boutonAjouterLotComposant.FlatStyle = FlatStyle.Flat;
            boutonAjouterLotComposant.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            boutonAjouterLotComposant.ForeColor = Color.White;
            boutonAjouterLotComposant.Location = new Point(28, 25);
            boutonAjouterLotComposant.Margin = new Padding(4);
            boutonAjouterLotComposant.Name = "boutonAjouterLotComposant";
            boutonAjouterLotComposant.Size = new Size(186, 45);
            boutonAjouterLotComposant.TabIndex = 6;
            boutonAjouterLotComposant.Text = "➕  Ajouter au lot";
            boutonAjouterLotComposant.UseVisualStyleBackColor = false;
            boutonAjouterLotComposant.Click += BoutonAjouterLotComposant_Click;
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
            comboBoxLotComposant.Size = new Size(210, 26);
            comboBoxLotComposant.TabIndex = 4;
            // 
            // labelComposant
            // 
            labelComposant.AutoSize = true;
            labelComposant.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelComposant.Location = new Point(4, 0);
            labelComposant.Margin = new Padding(4, 0, 4, 0);
            labelComposant.Name = "labelComposant";
            labelComposant.Size = new Size(139, 17);
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
            label6.Size = new Size(0, 18);
            label6.TabIndex = 6;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(groupBox3);
            panel3.Controls.Add(tableLayoutPanel2);
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(1185, 4);
            panel3.Margin = new Padding(4);
            panel3.Name = "panel3";
            panel3.Size = new Size(297, 264);
            panel3.TabIndex = 8;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(boutonSupprimerLotComposant);
            groupBox3.Location = new Point(10, 125);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(245, 82);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "⚡ Actions";
            // 
            // boutonSupprimerLotComposant
            // 
            boutonSupprimerLotComposant.BackColor = Color.FromArgb(244, 67, 54);
            boutonSupprimerLotComposant.FlatAppearance.BorderSize = 0;
            boutonSupprimerLotComposant.FlatStyle = FlatStyle.Flat;
            boutonSupprimerLotComposant.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            boutonSupprimerLotComposant.ForeColor = Color.White;
            boutonSupprimerLotComposant.Location = new Point(15, 25);
            boutonSupprimerLotComposant.Margin = new Padding(4);
            boutonSupprimerLotComposant.Name = "boutonSupprimerLotComposant";
            boutonSupprimerLotComposant.Size = new Size(223, 45);
            boutonSupprimerLotComposant.TabIndex = 7;
            boutonSupprimerLotComposant.Text = "🗑️    Supprimer du lot";
            boutonSupprimerLotComposant.UseVisualStyleBackColor = false;
            boutonSupprimerLotComposant.Click += BoutonSupprimerLotComposant_Click;
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
            comboBoxLotComposantDunLot.Size = new Size(210, 26);
            comboBoxLotComposantDunLot.TabIndex = 4;
            // 
            // labelComposantDunLot
            // 
            labelComposantDunLot.AutoSize = true;
            labelComposantDunLot.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelComposantDunLot.Location = new Point(4, 0);
            labelComposantDunLot.Margin = new Padding(4, 0, 4, 0);
            labelComposantDunLot.Name = "labelComposantDunLot";
            labelComposantDunLot.Size = new Size(214, 17);
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
            label4.Size = new Size(0, 18);
            label4.TabIndex = 6;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.BackColor = Color.MediumSlateBlue;
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 77.3978348F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.602169F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 304F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Controls.Add(groupBox4, 2, 2);
            tableLayoutPanel3.Controls.Add(panelForm, 0, 0);
            tableLayoutPanel3.Controls.Add(panel1, 1, 0);
            tableLayoutPanel3.Controls.Add(panel3, 2, 0);
            tableLayoutPanel3.Controls.Add(dataGridLotComposantsDunLot, 2, 1);
            tableLayoutPanel3.Controls.Add(dataGridLotComposants, 1, 1);
            tableLayoutPanel3.Controls.Add(dataGridLots, 0, 1);
            tableLayoutPanel3.Controls.Add(groupBoxStatsEspaces, 0, 2);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 44.6327667F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 55.3672333F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 260F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new Size(1486, 870);
            tableLayoutPanel3.TabIndex = 9;
            // 
            // groupBox4
            // 
            groupBox4.BackColor = Color.White;
            groupBox4.Controls.Add(labelStatsComposantDunLotTotal);
            groupBox4.Controls.Add(labelTitreComposantDunLot);
            groupBox4.Dock = DockStyle.Fill;
            groupBox4.Location = new Point(1184, 613);
            groupBox4.Margin = new Padding(3, 4, 3, 4);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(3, 4, 3, 4);
            groupBox4.Size = new Size(299, 253);
            groupBox4.TabIndex = 10;
            groupBox4.TabStop = false;
            // 
            // labelStatsComposantDunLotTotal
            // 
            labelStatsComposantDunLotTotal.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            labelStatsComposantDunLotTotal.ForeColor = Color.FromArgb(255, 152, 0);
            labelStatsComposantDunLotTotal.Location = new Point(1, 95);
            labelStatsComposantDunLotTotal.Name = "labelStatsComposantDunLotTotal";
            labelStatsComposantDunLotTotal.Size = new Size(297, 60);
            labelStatsComposantDunLotTotal.TabIndex = 1;
            labelStatsComposantDunLotTotal.Text = "12";
            labelStatsComposantDunLotTotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelTitreComposantDunLot
            // 
            labelTitreComposantDunLot.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelTitreComposantDunLot.ForeColor = Color.FromArgb(100, 100, 100);
            labelTitreComposantDunLot.Location = new Point(0, 55);
            labelTitreComposantDunLot.Name = "labelTitreComposantDunLot";
            labelTitreComposantDunLot.Size = new Size(293, 27);
            labelTitreComposantDunLot.TabIndex = 0;
            labelTitreComposantDunLot.Text = "🏢 COMPOSANTS DU LOT";
            labelTitreComposantDunLot.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dataGridLots
            // 
            dataGridLots.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridLots.BackgroundColor = Color.White;
            dataGridLots.BorderStyle = BorderStyle.None;
            dataGridLots.ColumnHeadersHeight = 34;
            dataGridLots.Dock = DockStyle.Fill;
            dataGridLots.Location = new Point(4, 276);
            dataGridLots.Margin = new Padding(4);
            dataGridLots.Name = "dataGridLots";
            dataGridLots.ReadOnly = true;
            dataGridLots.RowHeadersWidth = 62;
            dataGridLots.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridLots.Size = new Size(906, 329);
            dataGridLots.TabIndex = 2;
            dataGridLots.CellClick += DataGridLots_CellClick;
            // 
            // groupBoxStatsEspaces
            // 
            groupBoxStatsEspaces.BackColor = Color.White;
            groupBoxStatsEspaces.Controls.Add(labelStatLotNonAttribue);
            groupBoxStatsEspaces.Controls.Add(labelStatLotsTotal);
            groupBoxStatsEspaces.Controls.Add(labelTitreLot);
            groupBoxStatsEspaces.Dock = DockStyle.Fill;
            groupBoxStatsEspaces.Location = new Point(3, 613);
            groupBoxStatsEspaces.Margin = new Padding(3, 4, 3, 4);
            groupBoxStatsEspaces.Name = "groupBoxStatsEspaces";
            groupBoxStatsEspaces.Padding = new Padding(3, 4, 3, 4);
            groupBoxStatsEspaces.Size = new Size(908, 253);
            groupBoxStatsEspaces.TabIndex = 9;
            groupBoxStatsEspaces.TabStop = false;
            // 
            // labelStatLotNonAttribue
            // 
            labelStatLotNonAttribue.Font = new Font("Segoe UI", 9.75F);
            labelStatLotNonAttribue.Location = new Point(1, 172);
            labelStatLotNonAttribue.Name = "labelStatLotNonAttribue";
            labelStatLotNonAttribue.Size = new Size(907, 27);
            labelStatLotNonAttribue.TabIndex = 2;
            labelStatLotNonAttribue.Text = "Lots non attribués : 8";
            labelStatLotNonAttribue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelStatLotsTotal
            // 
            labelStatLotsTotal.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            labelStatLotsTotal.ForeColor = Color.FromArgb(255, 152, 0);
            labelStatLotsTotal.Location = new Point(1, 79);
            labelStatLotsTotal.Name = "labelStatLotsTotal";
            labelStatLotsTotal.Size = new Size(907, 60);
            labelStatLotsTotal.TabIndex = 1;
            labelStatLotsTotal.Text = "12";
            labelStatLotsTotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelTitreLot
            // 
            labelTitreLot.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelTitreLot.ForeColor = Color.FromArgb(100, 100, 100);
            labelTitreLot.Location = new Point(1, 24);
            labelTitreLot.Name = "labelTitreLot";
            labelTitreLot.Size = new Size(907, 27);
            labelTitreLot.TabIndex = 0;
            labelTitreLot.Text = "🏢 LOTS";
            labelTitreLot.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UcLots
            // 
            AutoScaleDimensions = new SizeF(7F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(227, 242, 253);
            Controls.Add(tableLayoutPanel3);
            Font = new Font("Trebuchet MS", 10F);
            Margin = new Padding(4);
            Name = "UcLots";
            Size = new Size(1486, 870);
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
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridLots).EndInit();
            groupBoxStatsEspaces.ResumeLayout(false);
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
        private Button boutonAjouterLot;
        private Button boutonEffacer;
        private Button boutonModifier;
        private Button boutonSupprimerLot;
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
        private Button boutonAjouterLotComposant;
        private Panel panel2;
        private Label label6;
        private ComboBox comboBoxLotComposant;
        private Panel panel3;
        private GroupBox groupBox3;
        private Button boutonSupprimerLotComposant;
        private TableLayoutPanel tableLayoutPanel2;
        private ComboBox comboBoxLotComposantDunLot;
        private Label labelComposantDunLot;
        private Panel panel4;
        private Label label4;
        private TableLayoutPanel tableLayoutPanel3;
        private DataGridView dataGridLots;
        private GroupBox groupBoxStatsEspaces;
        private Label labelStatLotNonAttribue;
        private Label labelStatLotsTotal;
        private Label labelTitreLot;
        private GroupBox groupBox4;
        private Label labelStatsComposantDunLotTotal;
        private Label labelTitreComposantDunLot;
    }
}