using System.Windows.Forms;

namespace ApplicationUi
{
    partial class UcTournois
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
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            label2 = new Label();
            textBoxRecherche = new TextBox();
            dataGridTournois = new DataGridView();
            panelForm = new Panel();
            tableLayoutPanel = new TableLayoutPanel();
            comboBoxJeu = new ComboBox();
            label3 = new Label();
            labelDuree = new Label();
            labelDateHeure = new Label();
            numericUpDownNbParticip = new NumericUpDown();
            comboBoxEspace = new ComboBox();
            textBoxNom = new TextBox();
            labelNom = new Label();
            labelNbParticipants = new Label();
            labelEspace = new Label();
            dateTimePickerDateTournoi = new DateTimePicker();
            numericUpDownDuree = new NumericUpDown();
            flowLayoutPanel1 = new FlowLayoutPanel();
            radioButtonPlanifié = new RadioButton();
            radioButtonEnCours = new RadioButton();
            radioButtonTermine = new RadioButton();
            labelStatut = new Label();
            labelParticipantsInscrits = new Label();
            panelButtons = new Panel();
            groupBox1 = new GroupBox();
            buttonAjouter = new Button();
            buttonEffacer = new Button();
            buttonModifier = new Button();
            buttonSupprimer = new Button();
            label1 = new Label();
            labelParticipantsInscrits = new Label();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridTournois).BeginInit();
            panelForm.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownNbParticip).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDuree).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            panelButtons.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(dataGridTournois, 0, 2);
            tableLayoutPanel1.Controls.Add(panelForm, 0, 0);
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 86.44068F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 13.5593224F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 424F));
            tableLayoutPanel1.Size = new Size(1401, 720);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.7640457F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 81.2359543F));
            tableLayoutPanel2.Controls.Add(label2, 0, 0);
            tableLayoutPanel2.Controls.Add(textBoxRecherche, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Bottom;
            tableLayoutPanel2.Location = new Point(3, 262);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(1395, 30);
            tableLayoutPanel2.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(131, 30);
            label2.TabIndex = 1;
            label2.Text = "Recherche :";
            // 
            // textBoxRecherche
            // 
            textBoxRecherche.Location = new Point(264, 3);
            textBoxRecherche.Name = "textBoxRecherche";
            textBoxRecherche.Size = new Size(717, 31);
            textBoxRecherche.TabIndex = 0;
            textBoxRecherche.TextChanged += TextBoxRecherche_TextChanged;
            // 
            // dataGridTournois
            // 
            dataGridTournois.AllowUserToAddRows = false;
            dataGridTournois.AllowUserToDeleteRows = false;
            dataGridTournois.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridTournois.BackgroundColor = Color.White;
            dataGridTournois.BorderStyle = BorderStyle.None;
            dataGridTournois.ColumnHeadersHeight = 34;
            dataGridTournois.Dock = DockStyle.Bottom;
            dataGridTournois.Location = new Point(4, 333);
            dataGridTournois.Margin = new Padding(4);
            dataGridTournois.Name = "dataGridTournois";
            dataGridTournois.ReadOnly = true;
            dataGridTournois.RowHeadersWidth = 62;
            dataGridTournois.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridTournois.Size = new Size(1393, 383);
            dataGridTournois.TabIndex = 2;
            dataGridTournois.CellClick += DataGridTournois_CellClick;
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
            panelForm.Size = new Size(1393, 247);
            panelForm.TabIndex = 2;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 4;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24.11111F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42.88889F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 417F));
            tableLayoutPanel.Controls.Add(comboBoxJeu, 2, 1);
            tableLayoutPanel.Controls.Add(label3, 2, 0);
            tableLayoutPanel.Controls.Add(labelDuree, 1, 2);
            tableLayoutPanel.Controls.Add(labelDateHeure, 1, 0);
            tableLayoutPanel.Controls.Add(numericUpDownNbParticip, 0, 3);
            tableLayoutPanel.Controls.Add(comboBoxEspace, 2, 3);
            tableLayoutPanel.Controls.Add(textBoxNom, 0, 1);
            tableLayoutPanel.Controls.Add(labelNom, 0, 0);
            tableLayoutPanel.Controls.Add(labelNbParticipants, 0, 2);
            tableLayoutPanel.Controls.Add(labelEspace, 2, 2);
            tableLayoutPanel.Controls.Add(dateTimePickerDateTournoi, 1, 1);
            tableLayoutPanel.Controls.Add(numericUpDownDuree, 1, 3);
            tableLayoutPanel.Controls.Add(flowLayoutPanel1, 3, 1);
            tableLayoutPanel.Controls.Add(labelStatut, 3, 0);
            tableLayoutPanel.Controls.Add(labelParticipantsInscrits, 3, 3);
            tableLayoutPanel.Dock = DockStyle.Top;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Margin = new Padding(4);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 5;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.Size = new Size(1393, 143);
            tableLayoutPanel.TabIndex = 0;
            // 
            // comboBoxJeu
            // 
            comboBoxJeu.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxJeu.Location = new Point(561, 39);
            comboBoxJeu.Margin = new Padding(4);
            comboBoxJeu.Name = "comboBoxJeu";
            comboBoxJeu.Size = new Size(291, 34);
            comboBoxJeu.TabIndex = 18;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label3.Location = new Point(561, 0);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(70, 28);
            label3.TabIndex = 17;
            label3.Text = "Jeu * :";
            // 
            // labelDuree
            // 
            labelDuree.AutoSize = true;
            labelDuree.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelDuree.Location = new Point(326, 79);
            labelDuree.Margin = new Padding(4, 0, 4, 0);
            labelDuree.Name = "labelDuree";
            labelDuree.Size = new Size(151, 26);
            labelDuree.TabIndex = 14;
            labelDuree.Text = "Durée prévue :";
            // 
            // labelDateHeure
            // 
            labelDateHeure.AutoSize = true;
            labelDateHeure.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelDateHeure.Location = new Point(326, 0);
            labelDateHeure.Margin = new Padding(4, 0, 4, 0);
            labelDateHeure.Name = "labelDateHeure";
            labelDateHeure.Size = new Size(153, 28);
            labelDateHeure.TabIndex = 7;
            labelDateHeure.Text = "Date et heure :";
            // 
            // numericUpDownNbParticip
            // 
            numericUpDownNbParticip.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDownNbParticip.Location = new Point(4, 109);
            numericUpDownNbParticip.Margin = new Padding(4);
            numericUpDownNbParticip.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            numericUpDownNbParticip.Name = "numericUpDownNbParticip";
            numericUpDownNbParticip.Size = new Size(88, 31);
            numericUpDownNbParticip.TabIndex = 3;
            // 
            // comboBoxEspace
            // 
            comboBoxEspace.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEspace.Location = new Point(561, 109);
            comboBoxEspace.Margin = new Padding(4);
            comboBoxEspace.Name = "comboBoxEspace";
            comboBoxEspace.Size = new Size(291, 34);
            comboBoxEspace.TabIndex = 5;
            // 
            // textBoxNom
            // 
            textBoxNom.Location = new Point(4, 39);
            textBoxNom.Margin = new Padding(4);
            textBoxNom.Name = "textBoxNom";
            textBoxNom.PlaceholderText = "Ex: Tournoi Mario Kart Débutant";
            textBoxNom.Size = new Size(281, 31);
            textBoxNom.TabIndex = 0;
            // 
            // labelNom
            // 
            labelNom.AutoSize = true;
            labelNom.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelNom.Location = new Point(4, 0);
            labelNom.Margin = new Padding(4, 0, 4, 0);
            labelNom.Name = "labelNom";
            labelNom.Size = new Size(190, 28);
            labelNom.TabIndex = 6;
            labelNom.Text = "Nom du tournoi * :";
            // 
            // labelNbParticipants
            // 
            labelNbParticipants.AutoSize = true;
            labelNbParticipants.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelNbParticipants.Location = new Point(4, 79);
            labelNbParticipants.Margin = new Padding(4, 0, 4, 0);
            labelNbParticipants.Name = "labelNbParticipants";
            labelNbParticipants.Size = new Size(249, 26);
            labelNbParticipants.TabIndex = 8;
            labelNbParticipants.Text = "Nombre de participants :";
            // 
            // labelEspace
            // 
            labelEspace.AutoSize = true;
            labelEspace.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelEspace.Location = new Point(561, 79);
            labelEspace.Margin = new Padding(4, 0, 4, 0);
            labelEspace.Name = "labelEspace";
            labelEspace.Size = new Size(147, 26);
            labelEspace.TabIndex = 13;
            labelEspace.Text = "Espace / Lieu :";
            // 
            // dateTimePickerDateTournoi
            // 
            dateTimePickerDateTournoi.CustomFormat = "dd/MM/yyyy HH:mm";
            dateTimePickerDateTournoi.Format = DateTimePickerFormat.Custom;
            dateTimePickerDateTournoi.Location = new Point(326, 39);
            dateTimePickerDateTournoi.Margin = new Padding(4);
            dateTimePickerDateTournoi.MaxDate = new DateTime(2026, 5, 25, 17, 0, 0, 0);
            dateTimePickerDateTournoi.MinDate = new DateTime(2026, 5, 23, 9, 0, 0, 0);
            dateTimePickerDateTournoi.Name = "dateTimePickerDateTournoi";
            dateTimePickerDateTournoi.ShowUpDown = true;
            dateTimePickerDateTournoi.Size = new Size(200, 31);
            dateTimePickerDateTournoi.TabIndex = 1;
            dateTimePickerDateTournoi.Value = new DateTime(2026, 5, 23, 9, 0, 0, 0);
            // 
            // numericUpDownDuree
            // 
            numericUpDownDuree.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDownDuree.Location = new Point(326, 109);
            numericUpDownDuree.Margin = new Padding(4);
            numericUpDownDuree.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            numericUpDownDuree.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDownDuree.Name = "numericUpDownDuree";
            numericUpDownDuree.Size = new Size(88, 31);
            numericUpDownDuree.TabIndex = 15;
            numericUpDownDuree.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(radioButtonPlanifié);
            flowLayoutPanel1.Controls.Add(radioButtonEnCours);
            flowLayoutPanel1.Controls.Add(radioButtonTermine);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(978, 38);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(412, 38);
            flowLayoutPanel1.TabIndex = 16;
            // 
            // radioButtonPlanifié
            // 
            radioButtonPlanifié.AutoSize = true;
            radioButtonPlanifié.Location = new Point(10, 3);
            radioButtonPlanifié.Margin = new Padding(10, 3, 5, 3);
            radioButtonPlanifié.Name = "radioButtonPlanifié";
            radioButtonPlanifié.Size = new Size(106, 30);
            radioButtonPlanifié.TabIndex = 0;
            radioButtonPlanifié.TabStop = true;
            radioButtonPlanifié.Text = "Planifié";
            radioButtonPlanifié.UseVisualStyleBackColor = true;
            // 
            // radioButtonEnCours
            // 
            radioButtonEnCours.AutoSize = true;
            radioButtonEnCours.Location = new Point(126, 3);
            radioButtonEnCours.Margin = new Padding(5, 3, 5, 3);
            radioButtonEnCours.Name = "radioButtonEnCours";
            radioButtonEnCours.Size = new Size(115, 30);
            radioButtonEnCours.TabIndex = 1;
            radioButtonEnCours.TabStop = true;
            radioButtonEnCours.Text = "En Cours";
            radioButtonEnCours.UseVisualStyleBackColor = true;
            // 
            // radioButtonTermine
            // 
            radioButtonTermine.AutoSize = true;
            radioButtonTermine.Location = new Point(251, 3);
            radioButtonTermine.Margin = new Padding(5, 3, 3, 3);
            radioButtonTermine.Name = "radioButtonTermine";
            radioButtonTermine.Size = new Size(111, 30);
            radioButtonTermine.TabIndex = 2;
            radioButtonTermine.TabStop = true;
            radioButtonTermine.Text = "Terminé";
            radioButtonTermine.UseVisualStyleBackColor = true;
            // 
            // labelStatut
            // 
            labelStatut.AutoSize = true;
            labelStatut.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelStatut.Location = new Point(979, 0);
            labelStatut.Margin = new Padding(4, 0, 4, 0);
            labelStatut.Name = "labelStatut";
            labelStatut.Size = new Size(81, 28);
            labelStatut.TabIndex = 11;
            labelStatut.Text = "Statut :";
            // 
            // labelParticipantsInscrits
            // 
            labelParticipantsInscrits.AutoSize = true;
            labelParticipantsInscrits.BackColor = Color.DarkBlue;
            labelParticipantsInscrits.Dock = DockStyle.Fill;
            labelParticipantsInscrits.Font = new Font("Trebuchet MS", 10F, FontStyle.Bold);
            labelParticipantsInscrits.ForeColor = Color.White;
            labelParticipantsInscrits.Location = new Point(978, 105);
            labelParticipantsInscrits.Name = "labelParticipantsInscrits";
            labelParticipantsInscrits.Size = new Size(412, 41);
            labelParticipantsInscrits.TabIndex = 19;
            labelParticipantsInscrits.Text = "Participants inscrits : 0/10";
            labelParticipantsInscrits.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(groupBox1);
            panelButtons.Controls.Add(label1);
            panelButtons.Location = new Point(10, 155);
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
            groupBox1.Dock = DockStyle.Bottom;
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
            buttonAjouter.Click += ButtonAjouter_Click;
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
            buttonEffacer.Click += ButtonEffacer_Click;
            // 
            // buttonModifier
            // 
            buttonModifier.BackColor = Color.FromArgb(33, 150, 243);
            buttonModifier.FlatAppearance.BorderSize = 0;
            buttonModifier.FlatStyle = FlatStyle.Flat;
            buttonModifier.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonModifier.ForeColor = Color.White;
            buttonModifier.Location = new Point(450, 25);
            buttonModifier.Margin = new Padding(4);
            buttonModifier.Name = "buttonModifier";
            buttonModifier.Size = new Size(176, 45);
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
            buttonSupprimer.Location = new Point(652, 25);
            buttonSupprimer.Margin = new Padding(4);
            buttonSupprimer.Name = "buttonSupprimer";
            buttonSupprimer.Size = new Size(202, 45);
            buttonSupprimer.TabIndex = 5;
            buttonSupprimer.Text = "🗑️    Supprimer";
            buttonSupprimer.UseVisualStyleBackColor = false;
            buttonSupprimer.Click += ButtonSupprimer_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 26);
            label1.TabIndex = 6;
            // 
            // labelParticipantsInscrits
            // 
            labelParticipantsInscrits.AutoSize = true;
            labelParticipantsInscrits.BackColor = Color.DarkBlue;
            labelParticipantsInscrits.Dock = DockStyle.Fill;
            labelParticipantsInscrits.Font = new Font("Trebuchet MS", 10F, FontStyle.Bold);
            labelParticipantsInscrits.ForeColor = Color.White;
            labelParticipantsInscrits.Location = new Point(978, 105);
            labelParticipantsInscrits.Name = "labelParticipantsInscrits";
            labelParticipantsInscrits.Size = new Size(412, 41);
            labelParticipantsInscrits.TabIndex = 19;
            labelParticipantsInscrits.Text = "Participants inscrits : 0/10";
            labelParticipantsInscrits.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UcTournois
            // 
            AutoScaleDimensions = new SizeF(11F, 26F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(227, 242, 225);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Trebuchet MS", 10F);
            Margin = new Padding(4);
            Name = "UcTournois";
            Size = new Size(1666, 1004);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridTournois).EndInit();
            panelForm.ResumeLayout(false);
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownNbParticip).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDuree).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            panelButtons.ResumeLayout(false);
            panelButtons.PerformLayout();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panelForm;
        private TableLayoutPanel tableLayoutPanel;
        private Label labelDuree;
        private Label labelStatut;
        private Label labelDateHeure;
        private NumericUpDown numericUpDownNbParticip;
        private ComboBox comboBoxEspace;
        private TextBox textBoxNom;
        private Label labelNom;
        private Label labelNbParticipants;
        private Label labelEspace;
        private DateTimePicker dateTimePickerDateTournoi;
        private NumericUpDown numericUpDownDuree;
        private FlowLayoutPanel flowLayoutPanel1;
        private RadioButton radioButtonPlanifié;
        private RadioButton radioButtonEnCours;
        private RadioButton radioButtonTermine;
        private Panel panelButtons;
        private GroupBox groupBox1;
        private Button buttonAjouter;
        private Button buttonEffacer;
        private Button buttonModifier;
        private Button buttonSupprimer;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label2;
        private TextBox textBoxRecherche;
        private Label label3;
        private ComboBox comboBoxJeu;
        private DataGridView dataGridTournois;
        private Label labelParticipantsInscrits;
    }
}



