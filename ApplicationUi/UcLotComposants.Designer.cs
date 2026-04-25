using System.Windows.Forms;

namespace ApplicationUi
{
    partial class UcLotComposants
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
            labelDescription = new Label();
            labelValeur = new Label();
            labelLot = new Label();
            textBoxLibelle = new TextBox();
            textBoxDescription = new TextBox();
            textBoxValeur = new TextBox();
            comboBoxLot = new ComboBox();
            panelButtons = new Panel();
            groupBox1 = new GroupBox();
            buttonAjouter = new Button();
            buttonEffacer = new Button();
            buttonModifier = new Button();
            buttonSupprimer = new Button();
            label1 = new Label();
            dataGridLotComposants = new DataGridView();
            label2 = new Label();
            textBoxRecherche = new TextBox();
            groupBoxStatsEspaces = new GroupBox();
            labelStatComposantNonAttribuer = new Label();
            labelStatComposantsTotal = new Label();
            labelTitreComposant = new Label();
            panelForm.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            panelButtons.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridLotComposants).BeginInit();
            groupBoxStatsEspaces.SuspendLayout();
            SuspendLayout();
            // 
            // panelForm
            // 
            panelForm.BackColor = Color.White;
            panelForm.Controls.Add(tableLayoutPanel);
            panelForm.Controls.Add(panelButtons);
            panelForm.Location = new Point(19, 36);
            panelForm.Margin = new Padding(4);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(900, 210);
            panelForm.TabIndex = 1;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 4;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel.Controls.Add(labelLibelle, 0, 0);
            tableLayoutPanel.Controls.Add(labelDescription, 1, 0);
            tableLayoutPanel.Controls.Add(labelValeur, 2, 0);
            tableLayoutPanel.Controls.Add(labelLot, 3, 0);
            tableLayoutPanel.Controls.Add(textBoxLibelle, 0, 1);
            tableLayoutPanel.Controls.Add(textBoxDescription, 1, 1);
            tableLayoutPanel.Controls.Add(textBoxValeur, 2, 1);
            tableLayoutPanel.Controls.Add(comboBoxLot, 3, 1);
            tableLayoutPanel.Location = new Point(10, 12);
            tableLayoutPanel.Margin = new Padding(4);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 3;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.Size = new Size(879, 110);
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
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelDescription.Location = new Point(223, 0);
            labelDescription.Margin = new Padding(4, 0, 4, 0);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(97, 17);
            labelDescription.TabIndex = 1;
            labelDescription.Text = "Description * :";
            // 
            // labelValeur
            // 
            labelValeur.AutoSize = true;
            labelValeur.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelValeur.Location = new Point(442, 0);
            labelValeur.Margin = new Padding(4, 0, 4, 0);
            labelValeur.Name = "labelValeur";
            labelValeur.Size = new Size(132, 17);
            labelValeur.TabIndex = 2;
            labelValeur.Text = "Valeur (en euros) * :";
            // 
            // labelLot
            // 
            labelLot.AutoSize = true;
            labelLot.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelLot.Location = new Point(661, 0);
            labelLot.Margin = new Padding(4, 0, 4, 0);
            labelLot.Name = "labelLot";
            labelLot.Size = new Size(94, 17);
            labelLot.TabIndex = 3;
            labelLot.Text = "Lot associé * :";
            // 
            // textBoxLibelle
            // 
            textBoxLibelle.Location = new Point(4, 39);
            textBoxLibelle.Margin = new Padding(4);
            textBoxLibelle.Name = "textBoxLibelle";
            textBoxLibelle.PlaceholderText = "Ex: Playstation 5";
            textBoxLibelle.Size = new Size(210, 23);
            textBoxLibelle.TabIndex = 0;
            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(223, 39);
            textBoxDescription.Margin = new Padding(4);
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.PlaceholderText = "Ex: Console de jeu de type Playstation";
            textBoxDescription.Size = new Size(210, 23);
            textBoxDescription.TabIndex = 1;
            // 
            // textBoxValeur
            // 
            textBoxValeur.Location = new Point(442, 39);
            textBoxValeur.Margin = new Padding(4);
            textBoxValeur.Name = "textBoxValeur";
            textBoxValeur.PlaceholderText = "Ex: 300";
            textBoxValeur.Size = new Size(210, 23);
            textBoxValeur.TabIndex = 2;
            // 
            // comboBoxLot
            // 
            comboBoxLot.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxLot.Location = new Point(661, 39);
            comboBoxLot.Margin = new Padding(4);
            comboBoxLot.Name = "comboBoxLot";
            comboBoxLot.Size = new Size(210, 26);
            comboBoxLot.TabIndex = 3;
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
            groupBox1.Controls.Add(buttonAjouter);
            groupBox1.Controls.Add(buttonEffacer);
            groupBox1.Controls.Add(buttonModifier);
            groupBox1.Controls.Add(buttonSupprimer);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(879, 82);
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
            // buttonSupprimer
            // 
            buttonSupprimer.BackColor = Color.FromArgb(244, 67, 54);
            buttonSupprimer.FlatAppearance.BorderSize = 0;
            buttonSupprimer.FlatStyle = FlatStyle.Flat;
            buttonSupprimer.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonSupprimer.ForeColor = Color.White;
            buttonSupprimer.Location = new Point(670, 25);
            buttonSupprimer.Margin = new Padding(4);
            buttonSupprimer.Name = "buttonSupprimer";
            buttonSupprimer.Size = new Size(162, 45);
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
            label1.Size = new Size(0, 18);
            label1.TabIndex = 6;
            // 
            // dataGridLotComposants
            // 
            dataGridLotComposants.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridLotComposants.BackgroundColor = Color.White;
            dataGridLotComposants.BorderStyle = BorderStyle.None;
            dataGridLotComposants.ColumnHeadersHeight = 34;
            dataGridLotComposants.Location = new Point(19, 320);
            dataGridLotComposants.Margin = new Padding(4);
            dataGridLotComposants.Name = "dataGridLotComposants";
            dataGridLotComposants.ReadOnly = true;
            dataGridLotComposants.RowHeadersWidth = 62;
            dataGridLotComposants.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridLotComposants.Size = new Size(900, 434);
            dataGridLotComposants.TabIndex = 2;
            dataGridLotComposants.CellClick += dataGridLotComposants_CellClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(119, 275);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(89, 20);
            label2.TabIndex = 4;
            label2.Text = "Recherche :";
            // 
            // textBoxRecherche
            // 
            textBoxRecherche.Location = new Point(252, 275);
            textBoxRecherche.Margin = new Padding(2);
            textBoxRecherche.Name = "textBoxRecherche";
            textBoxRecherche.PlaceholderText = "Ex: Xbox";
            textBoxRecherche.Size = new Size(574, 23);
            textBoxRecherche.TabIndex = 5;
            textBoxRecherche.TextChanged += textBoxRecherche_TextChanged;
            // 
            // groupBoxStatsEspaces
            // 
            groupBoxStatsEspaces.BackColor = Color.White;
            groupBoxStatsEspaces.Controls.Add(labelStatComposantNonAttribuer);
            groupBoxStatsEspaces.Controls.Add(labelStatComposantsTotal);
            groupBoxStatsEspaces.Controls.Add(labelTitreComposant);
            groupBoxStatsEspaces.Location = new Point(939, 61);
            groupBoxStatsEspaces.Margin = new Padding(3, 4, 3, 4);
            groupBoxStatsEspaces.Name = "groupBoxStatsEspaces";
            groupBoxStatsEspaces.Padding = new Padding(3, 4, 3, 4);
            groupBoxStatsEspaces.Size = new Size(329, 170);
            groupBoxStatsEspaces.TabIndex = 8;
            groupBoxStatsEspaces.TabStop = false;
            // 
            // labelStatComposantNonAttribuer
            // 
            labelStatComposantNonAttribuer.Font = new Font("Segoe UI", 9.75F);
            labelStatComposantNonAttribuer.Location = new Point(-1, 115);
            labelStatComposantNonAttribuer.Name = "labelStatComposantNonAttribuer";
            labelStatComposantNonAttribuer.Size = new Size(329, 27);
            labelStatComposantNonAttribuer.TabIndex = 2;
            labelStatComposantNonAttribuer.Text = "Composants non attribués : 8";
            labelStatComposantNonAttribuer.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelStatComposantsTotal
            // 
            labelStatComposantsTotal.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            labelStatComposantsTotal.ForeColor = Color.FromArgb(255, 152, 0);
            labelStatComposantsTotal.Location = new Point(0, 45);
            labelStatComposantsTotal.Name = "labelStatComposantsTotal";
            labelStatComposantsTotal.Size = new Size(327, 60);
            labelStatComposantsTotal.TabIndex = 1;
            labelStatComposantsTotal.Text = "12";
            labelStatComposantsTotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelTitreComposant
            // 
            labelTitreComposant.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelTitreComposant.ForeColor = Color.FromArgb(100, 100, 100);
            labelTitreComposant.Location = new Point(7, 19);
            labelTitreComposant.Name = "labelTitreComposant";
            labelTitreComposant.Size = new Size(320, 27);
            labelTitreComposant.TabIndex = 0;
            labelTitreComposant.Text = "🏢 COMPOSANTS";
            labelTitreComposant.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UcLotComposants
            // 
            AutoScaleDimensions = new SizeF(7F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CornflowerBlue;
            Controls.Add(groupBoxStatsEspaces);
            Controls.Add(textBoxRecherche);
            Controls.Add(label2);
            Controls.Add(panelForm);
            Controls.Add(dataGridLotComposants);
            Font = new Font("Trebuchet MS", 10F);
            Margin = new Padding(4);
            Name = "UcLotComposants";
            Size = new Size(1301, 809);
            panelForm.ResumeLayout(false);
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            panelButtons.ResumeLayout(false);
            panelButtons.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridLotComposants).EndInit();
            groupBoxStatsEspaces.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelForm;
        private TableLayoutPanel tableLayoutPanel;
        private TextBox textBoxLibelle;
        private TextBox textBoxDescription;
        private TextBox textBoxValeur;
        private ComboBox comboBoxLot;
        private Label labelLibelle;
        private Label labelDescription;
        private Label labelValeur;
        private Label labelLot;
        private Panel panelButtons;
        private GroupBox groupBox1;
        private Button buttonAjouter;
        private Button buttonEffacer;
        private Button buttonModifier;
        private Button buttonSupprimer;
        private Label label1;
        private DataGridView dataGridLotComposants;
        private Label label2;
        private TextBox textBoxRecherche;
        private GroupBox groupBoxStatsEspaces;
        private Label labelStatComposantNonAttribuer;
        private Label labelStatComposantsTotal;
        private Label labelTitreComposant;
    }
}