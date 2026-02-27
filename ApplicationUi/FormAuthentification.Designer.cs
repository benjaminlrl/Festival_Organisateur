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
            label1 = new Label();
            labelMdpMin = new Label();
            labelError = new Label();
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
            panelCard.Controls.Add(label1);
            panelCard.Controls.Add(labelMdpMin);
            panelCard.Controls.Add(labelError);
            panelCard.Controls.Add(labelTitle);
            panelCard.Controls.Add(labelUsername);
            panelCard.Controls.Add(txtUsername);
            panelCard.Controls.Add(labelPassword);
            panelCard.Controls.Add(txtPassword);
            panelCard.Controls.Add(btnLogin);
            panelCard.Location = new Point(55, 57);
            panelCard.Margin = new Padding(4, 5, 4, 5);
            panelCard.Name = "panelCard";
            panelCard.Padding = new Padding(36, 50, 36, 33);
            panelCard.Size = new Size(514, 671);
            panelCard.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            label1.ForeColor = Color.FromArgb(52, 73, 94);
            label1.Location = new Point(40, 302);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(173, 21);
            label1.TabIndex = 8;
            label1.Text = "Entre 3 et 12 caractères";
            // 
            // labelMdpMin
            // 
            labelMdpMin.AutoSize = true;
            labelMdpMin.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            labelMdpMin.ForeColor = Color.FromArgb(52, 73, 94);
            labelMdpMin.Location = new Point(40, 427);
            labelMdpMin.Margin = new Padding(4, 0, 4, 0);
            labelMdpMin.Name = "labelMdpMin";
            labelMdpMin.Size = new Size(174, 21);
            labelMdpMin.TabIndex = 7;
            labelMdpMin.Text = "Minimum 12 caractères";
            // 
            // labelError
            // 
            labelError.Font = new Font("Segoe UI", 10F);
            labelError.ForeColor = Color.FromArgb(255, 128, 128);
            labelError.Location = new Point(101, 153);
            labelError.Margin = new Padding(4, 0, 4, 0);
            labelError.Name = "labelError";
            labelError.Size = new Size(299, 42);
            labelError.TabIndex = 6;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI Light", 24F);
            labelTitle.ForeColor = Color.FromArgb(52, 73, 94);
            labelTitle.Location = new Point(135, 71);
            labelTitle.Margin = new Padding(4, 0, 4, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(244, 65);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Connexion";
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Font = new Font("Segoe UI", 10F);
            labelUsername.ForeColor = Color.FromArgb(52, 73, 94);
            labelUsername.Location = new Point(46, 219);
            labelUsername.Margin = new Padding(4, 0, 4, 0);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(164, 28);
            labelUsername.TabIndex = 1;
            labelUsername.Text = "Nom d'utilisateur";
            // 
            // txtUsername
            // 
            txtUsername.AccessibleDescription = "";
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Font = new Font("Segoe UI", 10F);
            txtUsername.Location = new Point(46, 260);
            txtUsername.Margin = new Padding(4, 5, 4, 5);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = " Votre identifiant";
            txtUsername.Size = new Size(428, 34);
            txtUsername.TabIndex = 2;
            txtUsername.Enter += txt_Enter;
            txtUsername.Leave += txt_Leave;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Segoe UI", 10F);
            labelPassword.ForeColor = Color.FromArgb(52, 73, 94);
            labelPassword.Location = new Point(46, 344);
            labelPassword.Margin = new Padding(4, 0, 4, 0);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(129, 28);
            labelPassword.TabIndex = 3;
            labelPassword.Text = "Mot de passe";
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(46, 385);
            txtPassword.Margin = new Padding(4, 5, 4, 5);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = " Votre mot de passe";
            txtPassword.Size = new Size(428, 34);
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
            btnLogin.Location = new Point(46, 504);
            btnLogin.Margin = new Padding(4, 5, 4, 5);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(429, 75);
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
            btnQuitter.Location = new Point(456, 766);
            btnQuitter.Margin = new Padding(4, 5, 4, 5);
            btnQuitter.Name = "btnQuitter";
            btnQuitter.Size = new Size(174, 67);
            btnQuitter.TabIndex = 8;
            btnQuitter.Text = "  Quitter";
            btnQuitter.UseVisualStyleBackColor = false;
            btnQuitter.Click += btnQuitter_Click;
            // 
            // FormAuthentification
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 242, 245);
            ClientSize = new Size(629, 833);
            Controls.Add(btnQuitter);
            Controls.Add(panelCard);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 5, 4, 5);
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
        private Label labelError;
        private Label labelMdpMin;
        private Label label1;
    }
}