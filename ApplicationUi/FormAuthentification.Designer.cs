namespace ApplicationUi
{
    partial class FormAuthentification
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelCard = new Panel();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            labelMdpMin = new Label();
            labelTitle = new Label();
            labelUsername = new Label();
            txtUsername = new TextBox();
            labelPassword = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnQuitter = new Button();
            panelCard.SuspendLayout();
            SuspendLayout();
            // 
            // panelCard
            // 
            panelCard.BackColor = Color.White;
            panelCard.Controls.Add(label4);
            panelCard.Controls.Add(label3);
            panelCard.Controls.Add(label2);
            panelCard.Controls.Add(label1);
            panelCard.Controls.Add(labelMdpMin);
            panelCard.Controls.Add(labelTitle);
            panelCard.Controls.Add(labelUsername);
            panelCard.Controls.Add(txtUsername);
            panelCard.Controls.Add(labelPassword);
            panelCard.Controls.Add(txtPassword);
            panelCard.Controls.Add(btnLogin);
            panelCard.Location = new Point(38, 35);
            panelCard.Name = "panelCard";
            panelCard.Padding = new Padding(25, 30, 25, 19);
            panelCard.Size = new Size(360, 403);
            panelCard.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 7F, FontStyle.Italic);
            label4.ForeColor = Color.FromArgb(52, 73, 94);
            label4.Location = new Point(28, 299);
            label4.Name = "label4";
            label4.Size = new Size(41, 12);
            label4.TabIndex = 11;
            label4.Text = "1 chiffre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 7F, FontStyle.Italic);
            label3.ForeColor = Color.FromArgb(52, 73, 94);
            label3.Location = new Point(28, 285);
            label3.Name = "label3";
            label3.Size = new Size(89, 12);
            label3.TabIndex = 10;
            label3.Text = "1 caractère spéciale";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 7F, FontStyle.Italic);
            label2.ForeColor = Color.FromArgb(52, 73, 94);
            label2.Location = new Point(29, 271);
            label2.Name = "label2";
            label2.Size = new Size(57, 12);
            label2.TabIndex = 9;
            label2.Text = "1 majuscule";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 7F, FontStyle.Italic);
            label1.ForeColor = Color.FromArgb(52, 73, 94);
            label1.Location = new Point(28, 181);
            label1.Name = "label1";
            label1.Size = new Size(106, 12);
            label1.TabIndex = 8;
            label1.Text = "Entre 3 et 12 caractères";
            // 
            // labelMdpMin
            // 
            labelMdpMin.AutoSize = true;
            labelMdpMin.Font = new Font("Segoe UI", 7F, FontStyle.Italic);
            labelMdpMin.ForeColor = Color.FromArgb(52, 73, 94);
            labelMdpMin.Location = new Point(28, 257);
            labelMdpMin.Name = "labelMdpMin";
            labelMdpMin.Size = new Size(108, 12);
            labelMdpMin.TabIndex = 7;
            labelMdpMin.Text = "Minimum 12 caractères";
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI Light", 24F);
            labelTitle.ForeColor = Color.FromArgb(52, 73, 94);
            labelTitle.Location = new Point(97, 53);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(163, 45);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Connexion";
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Font = new Font("Segoe UI", 10F);
            labelUsername.ForeColor = Color.FromArgb(52, 73, 94);
            labelUsername.Location = new Point(32, 131);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(114, 19);
            labelUsername.TabIndex = 1;
            labelUsername.Text = "Nom d'utilisateur";
            // 
            // txtUsername
            // 
            txtUsername.AccessibleDescription = "";
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Font = new Font("Segoe UI", 10F);
            txtUsername.Location = new Point(32, 156);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = " Votre identifiant";
            txtUsername.Size = new Size(300, 25);
            txtUsername.TabIndex = 2;
            txtUsername.Enter += txt_Enter;
            txtUsername.Leave += txt_Leave;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Segoe UI", 10F);
            labelPassword.ForeColor = Color.FromArgb(52, 73, 94);
            labelPassword.Location = new Point(32, 206);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(92, 19);
            labelPassword.TabIndex = 3;
            labelPassword.Text = "Mot de passe";
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(32, 231);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = " Votre mot de passe";
            txtPassword.Size = new Size(300, 25);
            txtPassword.TabIndex = 4;
            txtPassword.Enter += txt_Enter;
            txtPassword.KeyPress += txtPassword_KeyPress;
            txtPassword.Leave += txt_Leave;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(52, 152, 219);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(32, 335);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(300, 45);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Se connecter";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_ClickAsync;
            // 
            // btnQuitter
            // 
            btnQuitter.BackColor = Color.FromArgb(60, 60, 60);
            btnQuitter.FlatAppearance.BorderSize = 0;
            btnQuitter.FlatStyle = FlatStyle.Flat;
            btnQuitter.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnQuitter.ForeColor = Color.White;
            btnQuitter.Image = Properties.Resources.deconnecter;
            btnQuitter.ImageAlign = ContentAlignment.MiddleLeft;
            btnQuitter.Location = new Point(308, 444);
            btnQuitter.Name = "btnQuitter";
            btnQuitter.Size = new Size(133, 54);
            btnQuitter.TabIndex = 8;
            btnQuitter.Text = "       Quitter";
            btnQuitter.UseVisualStyleBackColor = false;
            btnQuitter.Click += btnQuitter_Click;
            // 
            // FormAuthentification
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 242, 245);
            ClientSize = new Size(440, 499);
            Controls.Add(btnQuitter);
            Controls.Add(panelCard);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormAuthentification";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Authentification";
            panelCard.ResumeLayout(false);
            panelCard.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private Button btnQuitter;
        private Label labelMdpMin;
        private Label label1;
        private Label label4;
        private Label label3;
        private Label label2;
    }
}