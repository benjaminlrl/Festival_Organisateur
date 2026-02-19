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
            panelButtons = new Panel();
            groupBox1 = new GroupBox();
            buttonAjouter = new Button();
            buttonEffacer = new Button();
            buttonModifier = new Button();
            buttonSupprimer = new Button();
            label1 = new Label();
            labelSuperficie = new Label();
            numericUpDownCapaciteMaxi = new NumericUpDown();
            textBoxNom = new TextBox();
            labelNom = new Label();
            labelCapaciteMaxi = new Label();
            dataGridTournois = new DataGridView();
            numericUpDownSuperficie = new NumericUpDown();
            tableLayoutPanel = new TableLayoutPanel();
            panelForm = new Panel();
            labelDescription = new Label();
            textBoxDescription = new TextBox();
            panelButtons.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCapaciteMaxi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridTournois).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSuperficie).BeginInit();
            tableLayoutPanel.SuspendLayout();
            panelForm.SuspendLayout();
            SuspendLayout();
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
            // labelSuperficie
            // 
            labelSuperficie.AutoSize = true;
            labelSuperficie.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelSuperficie.Location = new Point(294, 79);
            labelSuperficie.Margin = new Padding(4, 0, 4, 0);
            labelSuperficie.Name = "labelSuperficie";
            labelSuperficie.Size = new Size(179, 26);
            labelSuperficie.TabIndex = 14;
            labelSuperficie.Text = "Superficie en m² :";
            // 
            // numericUpDownCapaciteMaxi
            // 
            numericUpDownCapaciteMaxi.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDownCapaciteMaxi.Location = new Point(4, 109);
            numericUpDownCapaciteMaxi.Margin = new Padding(4);
            numericUpDownCapaciteMaxi.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            numericUpDownCapaciteMaxi.Name = "numericUpDownCapaciteMaxi";
            numericUpDownCapaciteMaxi.Size = new Size(88, 31);
            numericUpDownCapaciteMaxi.TabIndex = 3;
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
            labelNom.Size = new Size(195, 28);
            labelNom.TabIndex = 6;
            labelNom.Text = "Nom de l'espace * :";
            // 
            // labelCapaciteMaxi
            // 
            labelCapaciteMaxi.AutoSize = true;
            labelCapaciteMaxi.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelCapaciteMaxi.Location = new Point(4, 79);
            labelCapaciteMaxi.Margin = new Padding(4, 0, 4, 0);
            labelCapaciteMaxi.Name = "labelCapaciteMaxi";
            labelCapaciteMaxi.Size = new Size(205, 26);
            labelCapaciteMaxi.TabIndex = 8;
            labelCapaciteMaxi.Text = "Capacité maximale*:";
            // 
            // dataGridTournois
            // 
            dataGridTournois.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridTournois.BackgroundColor = Color.White;
            dataGridTournois.BorderStyle = BorderStyle.None;
            dataGridTournois.ColumnHeadersHeight = 34;
            dataGridTournois.Location = new Point(23, 277);
            dataGridTournois.Margin = new Padding(4);
            dataGridTournois.Name = "dataGridTournois";
            dataGridTournois.ReadOnly = true;
            dataGridTournois.RowHeadersWidth = 62;
            dataGridTournois.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridTournois.Size = new Size(900, 383);
            dataGridTournois.TabIndex = 4;
            // 
            // numericUpDownSuperficie
            // 
            numericUpDownSuperficie.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDownSuperficie.Location = new Point(294, 109);
            numericUpDownSuperficie.Margin = new Padding(4);
            numericUpDownSuperficie.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            numericUpDownSuperficie.Minimum = new decimal(new int[] { 9, 0, 0, 0 });
            numericUpDownSuperficie.Name = "numericUpDownSuperficie";
            numericUpDownSuperficie.Size = new Size(88, 31);
            numericUpDownSuperficie.TabIndex = 15;
            numericUpDownSuperficie.Value = new decimal(new int[] { 12, 0, 0, 0 });
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 3;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
            tableLayoutPanel.Controls.Add(labelDescription, 1, 0);
            tableLayoutPanel.Controls.Add(labelSuperficie, 1, 2);
            tableLayoutPanel.Controls.Add(numericUpDownCapaciteMaxi, 0, 3);
            tableLayoutPanel.Controls.Add(textBoxNom, 0, 1);
            tableLayoutPanel.Controls.Add(labelNom, 0, 0);
            tableLayoutPanel.Controls.Add(labelCapaciteMaxi, 0, 2);
            tableLayoutPanel.Controls.Add(numericUpDownSuperficie, 1, 3);
            tableLayoutPanel.Controls.Add(textBoxDescription, 1, 1);
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
            // panelForm
            // 
            panelForm.BackColor = Color.White;
            panelForm.Controls.Add(tableLayoutPanel);
            panelForm.Controls.Add(panelButtons);
            panelForm.Location = new Point(23, 17);
            panelForm.Margin = new Padding(4);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(900, 253);
            panelForm.TabIndex = 3;
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelDescription.Location = new Point(294, 0);
            labelDescription.Margin = new Padding(4, 0, 4, 0);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(252, 28);
            labelDescription.TabIndex = 16;
            labelDescription.Text = "Description de l'espace *:";
            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(294, 39);
            textBoxDescription.Margin = new Padding(4);
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.PlaceholderText = "Ex: Tournoi Mario Kart Débutant";
            textBoxDescription.Size = new Size(282, 31);
            textBoxDescription.TabIndex = 17;
            // 
            // UcEspaces
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridTournois);
            Controls.Add(panelForm);
            Name = "UcEspaces";
            Size = new Size(949, 720);
            panelButtons.ResumeLayout(false);
            panelButtons.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDownCapaciteMaxi).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridTournois).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSuperficie).EndInit();
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            panelForm.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelButtons;
        private GroupBox groupBox1;
        private Button buttonAjouter;
        private Button buttonEffacer;
        private Button buttonModifier;
        private Button buttonSupprimer;
        private Label label1;
        private Label labelSuperficie;
        private NumericUpDown numericUpDownCapaciteMaxi;
        private TextBox textBoxNom;
        private Label labelNom;
        private Label labelCapaciteMaxi;
        private DataGridView dataGridTournois;
        private NumericUpDown numericUpDownSuperficie;
        private TableLayoutPanel tableLayoutPanel;
        private Panel panelForm;
        private Label labelDescription;
        private TextBox textBoxDescription;
    }
}
