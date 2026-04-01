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
            labelTournoi = new Label();
            textBoxLibelle = new TextBox();
            comboBoxTournoi = new ComboBox();
            textBoxRang = new TextBox();
            panelButtons = new Panel();
            groupBox1 = new GroupBox();
            buttonAjouter = new Button();
            buttonEffacer = new Button();
            buttonModifier = new Button();
            buttonSupprimer = new Button();
            label1 = new Label();
            dataGridLots = new DataGridView();
            label2 = new Label();
            textBoxRecherche = new TextBox();
            panelForm.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            panelButtons.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridLots).BeginInit();
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
            labelLibelle.Size = new Size(86, 23);
            labelLibelle.TabIndex = 0;
            labelLibelle.Text = "Libelle * :";
            // 
            // labelRang
            // 
            labelRang.AutoSize = true;
            labelRang.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelRang.Location = new Point(297, 0);
            labelRang.Margin = new Padding(4, 0, 4, 0);
            labelRang.Name = "labelRang";
            labelRang.Size = new Size(74, 23);
            labelRang.TabIndex = 1;
            labelRang.Text = "Rang * :";
            // 
            // labelTournoi
            // 
            labelTournoi.AutoSize = true;
            labelTournoi.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelTournoi.Location = new Point(590, 0);
            labelTournoi.Margin = new Padding(4, 0, 4, 0);
            labelTournoi.Name = "labelTournoi";
            labelTournoi.Size = new Size(153, 23);
            labelTournoi.TabIndex = 3;
            labelTournoi.Text = "Tournoi associé * :";
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
            // comboBoxTournoi
            // 
            comboBoxTournoi.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTournoi.Location = new Point(590, 39);
            comboBoxTournoi.Margin = new Padding(4);
            comboBoxTournoi.Name = "comboBoxTournoi";
            comboBoxTournoi.Size = new Size(210, 31);
            comboBoxTournoi.TabIndex = 3;
            // 
            // textBoxRang
            // 
            textBoxRang.Location = new Point(297, 39);
            textBoxRang.Margin = new Padding(4);
            textBoxRang.Name = "textBoxRang";
            textBoxRang.PlaceholderText = "1";
            textBoxRang.Size = new Size(210, 27);
            textBoxRang.TabIndex = 4;
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
            label1.Size = new Size(0, 23);
            label1.TabIndex = 6;
            // 
            // dataGridLots
            // 
            dataGridLots.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridLots.BackgroundColor = Color.White;
            dataGridLots.BorderStyle = BorderStyle.None;
            dataGridLots.ColumnHeadersHeight = 34;
            dataGridLots.Location = new Point(19, 320);
            dataGridLots.Margin = new Padding(4);
            dataGridLots.Name = "dataGridLots";
            dataGridLots.ReadOnly = true;
            dataGridLots.RowHeadersWidth = 62;
            dataGridLots.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridLots.Size = new Size(900, 434);
            dataGridLots.TabIndex = 2;
            dataGridLots.CellClick += dataGridLotComposants_CellClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(119, 275);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(112, 25);
            label2.TabIndex = 4;
            label2.Text = "Recherche :";
            // 
            // textBoxRecherche
            // 
            textBoxRecherche.Location = new Point(252, 275);
            textBoxRecherche.Margin = new Padding(2);
            textBoxRecherche.Name = "textBoxRecherche";
            textBoxRecherche.Size = new Size(574, 27);
            textBoxRecherche.TabIndex = 5;
            textBoxRecherche.TextChanged += textBoxRecherche_TextChanged;
            // 
            // UcLots
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(227, 242, 253);
            Controls.Add(textBoxRecherche);
            Controls.Add(label2);
            Controls.Add(panelForm);
            Controls.Add(dataGridLots);
            Font = new Font("Trebuchet MS", 10F);
            Margin = new Padding(4);
            Name = "UcLots";
            Size = new Size(950, 809);
            panelForm.ResumeLayout(false);
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            panelButtons.ResumeLayout(false);
            panelButtons.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridLots).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private Button buttonAjouter;
        private Button buttonEffacer;
        private Button buttonModifier;
        private Button buttonSupprimer;
        private Label label1;
        private DataGridView dataGridLots;
        private Label label2;
        private TextBox textBoxRecherche;
        private TextBox textBoxRang;
    }
}