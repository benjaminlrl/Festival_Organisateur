namespace ApplicationUi
{
    partial class UcPostesDeJeu
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
            textBoxReference = new TextBox();
            labelReference = new Label();
            labelFonctionnel = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            radioButtonFonctionnelTrue = new RadioButton();
            radioButtonFonctionnelFalse = new RadioButton();
            labelPlateforme = new Label();
            comboBoxPlateforme = new ComboBox();
            labelEspace = new Label();
            comboBoxEspace = new ComboBox();
            panelButtons = new Panel();
            groupBox1 = new GroupBox();
            buttonAjouter = new Button();
            buttonEffacer = new Button();
            buttonModifier = new Button();
            buttonSupprimer = new Button();
            label1 = new Label();
            dataGridPostesJeu = new DataGridView();
            panelForm.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panelButtons.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridPostesJeu).BeginInit();
            SuspendLayout();
            // 
            // panelForm
            // 
            panelForm.BackColor = Color.White;
            panelForm.Controls.Add(tableLayoutPanel);
            panelForm.Controls.Add(panelButtons);
            panelForm.Location = new Point(24, 39);
            panelForm.Margin = new Padding(4);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(900, 253);
            panelForm.TabIndex = 5;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tableLayoutPanel.Controls.Add(textBoxReference, 0, 1);
            tableLayoutPanel.Controls.Add(labelReference, 0, 0);
            tableLayoutPanel.Controls.Add(labelFonctionnel, 0, 2);
            tableLayoutPanel.Controls.Add(flowLayoutPanel1, 0, 3);
            tableLayoutPanel.Controls.Add(labelPlateforme, 1, 0);
            tableLayoutPanel.Controls.Add(comboBoxPlateforme, 1, 1);
            tableLayoutPanel.Controls.Add(labelEspace, 1, 2);
            tableLayoutPanel.Controls.Add(comboBoxEspace, 1, 3);
            tableLayoutPanel.Location = new Point(10, 12);
            tableLayoutPanel.Margin = new Padding(4);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 5;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.Size = new Size(879, 143);
            tableLayoutPanel.TabIndex = 0;
            // 
            // textBoxReference
            // 
            textBoxReference.Location = new Point(4, 39);
            textBoxReference.Margin = new Padding(4);
            textBoxReference.Name = "textBoxReference";
            textBoxReference.PlaceholderText = "Ex: Tournoi Mario Kart Débutant";
            textBoxReference.Size = new Size(281, 31);
            textBoxReference.TabIndex = 0;
            // 
            // labelReference
            // 
            labelReference.AutoSize = true;
            labelReference.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelReference.Location = new Point(4, 0);
            labelReference.Margin = new Padding(4, 0, 4, 0);
            labelReference.Name = "labelReference";
            labelReference.Size = new Size(118, 28);
            labelReference.TabIndex = 6;
            labelReference.Text = "Référence :";
            // 
            // labelFonctionnel
            // 
            labelFonctionnel.AutoSize = true;
            labelFonctionnel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelFonctionnel.Location = new Point(4, 79);
            labelFonctionnel.Margin = new Padding(4, 0, 4, 0);
            labelFonctionnel.Name = "labelFonctionnel";
            labelFonctionnel.Size = new Size(123, 26);
            labelFonctionnel.TabIndex = 8;
            labelFonctionnel.Text = "Fonctionnel";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(radioButtonFonctionnelTrue);
            flowLayoutPanel1.Controls.Add(radioButtonFonctionnelFalse);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(3, 108);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(433, 35);
            flowLayoutPanel1.TabIndex = 18;
            // 
            // radioButtonFonctionnelTrue
            // 
            radioButtonFonctionnelTrue.AutoSize = true;
            radioButtonFonctionnelTrue.Location = new Point(3, 3);
            radioButtonFonctionnelTrue.Name = "radioButtonFonctionnelTrue";
            radioButtonFonctionnelTrue.Size = new Size(65, 29);
            radioButtonFonctionnelTrue.TabIndex = 1;
            radioButtonFonctionnelTrue.TabStop = true;
            radioButtonFonctionnelTrue.Text = "Oui";
            radioButtonFonctionnelTrue.UseVisualStyleBackColor = true;
            radioButtonFonctionnelTrue.CheckedChanged += radioButtonFonctionnelTrue_CheckedChanged_1;
            // 
            // radioButtonFonctionnelFalse
            // 
            radioButtonFonctionnelFalse.AutoSize = true;
            radioButtonFonctionnelFalse.Location = new Point(74, 3);
            radioButtonFonctionnelFalse.Name = "radioButtonFonctionnelFalse";
            radioButtonFonctionnelFalse.Size = new Size(71, 29);
            radioButtonFonctionnelFalse.TabIndex = 2;
            radioButtonFonctionnelFalse.TabStop = true;
            radioButtonFonctionnelFalse.Text = "Non";
            radioButtonFonctionnelFalse.UseVisualStyleBackColor = true;
            radioButtonFonctionnelFalse.CheckedChanged += radioButtonFonctionnelFalse_CheckedChanged;
            // 
            // labelPlateforme
            // 
            labelPlateforme.AutoSize = true;
            labelPlateforme.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelPlateforme.Location = new Point(443, 0);
            labelPlateforme.Margin = new Padding(4, 0, 4, 0);
            labelPlateforme.Name = "labelPlateforme";
            labelPlateforme.Size = new Size(128, 28);
            labelPlateforme.TabIndex = 21;
            labelPlateforme.Text = "Plateforme :";
            // 
            // comboBoxPlateforme
            // 
            comboBoxPlateforme.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPlateforme.Location = new Point(443, 39);
            comboBoxPlateforme.Margin = new Padding(4);
            comboBoxPlateforme.Name = "comboBoxPlateforme";
            comboBoxPlateforme.Size = new Size(217, 33);
            comboBoxPlateforme.TabIndex = 22;
            // 
            // labelEspace
            // 
            labelEspace.AutoSize = true;
            labelEspace.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelEspace.Location = new Point(443, 79);
            labelEspace.Margin = new Padding(4, 0, 4, 0);
            labelEspace.Name = "labelEspace";
            labelEspace.Size = new Size(147, 26);
            labelEspace.TabIndex = 19;
            labelEspace.Text = "Espace / Lieu :";
            // 
            // comboBoxEspace
            // 
            comboBoxEspace.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEspace.Location = new Point(443, 109);
            comboBoxEspace.Margin = new Padding(4);
            comboBoxEspace.Name = "comboBoxEspace";
            comboBoxEspace.Size = new Size(217, 33);
            comboBoxEspace.TabIndex = 20;
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
            buttonSupprimer.Size = new Size(150, 45);
            buttonSupprimer.TabIndex = 5;
            buttonSupprimer.Text = "🗑️    Supprimer";
            buttonSupprimer.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 25);
            label1.TabIndex = 6;
            // 
            // dataGridPostesJeu
            // 
            dataGridPostesJeu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridPostesJeu.BackgroundColor = Color.White;
            dataGridPostesJeu.BorderStyle = BorderStyle.None;
            dataGridPostesJeu.ColumnHeadersHeight = 34;
            dataGridPostesJeu.Location = new Point(24, 299);
            dataGridPostesJeu.Margin = new Padding(4);
            dataGridPostesJeu.Name = "dataGridPostesJeu";
            dataGridPostesJeu.ReadOnly = true;
            dataGridPostesJeu.RowHeadersWidth = 62;
            dataGridPostesJeu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridPostesJeu.Size = new Size(900, 383);
            dataGridPostesJeu.TabIndex = 6;
            dataGridPostesJeu.CellContentClick += dataGridPostesJeu_CellContentClick;
            // 
            // UcPostesDeJeu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Cornsilk;
            Controls.Add(panelForm);
            Controls.Add(dataGridPostesJeu);
            Name = "UcPostesDeJeu";
            Size = new Size(949, 720);
            panelForm.ResumeLayout(false);
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            panelButtons.ResumeLayout(false);
            panelButtons.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridPostesJeu).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelForm;
        private TableLayoutPanel tableLayoutPanel;
        private TextBox textBoxReference;
        private Label labelReference;
        private Label labelFonctionnel;
        private Panel panelButtons;
        private GroupBox groupBox1;
        private Button buttonAjouter;
        private Button buttonEffacer;
        private Button buttonModifier;
        private Button buttonSupprimer;
        private Label label1;
        private DataGridView dataGridPostesJeu;
        private FlowLayoutPanel flowLayoutPanel1;
        private RadioButton radioButtonFonctionnelTrue;
        private RadioButton radioButtonFonctionnelFalse;
        private Label labelEspace;
        private Label labelPlateforme;
        private ComboBox comboBoxEspace;
        private ComboBox comboBoxPlateforme;
    }
}
