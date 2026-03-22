using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using Font = System.Drawing.Font;

namespace ApplicationUi
{
        partial class FormDashboard
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip = new MenuStrip();
            menuTournois = new ToolStripMenuItem();
            menuGestionTournois = new ToolStripMenuItem();
            menuInscriptions = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            menuResultats = new ToolStripMenuItem();
            menuLots = new ToolStripMenuItem();
            menuInfrastructure = new ToolStripMenuItem();
            menuEspaces = new ToolStripMenuItem();
            menuPostesJeu = new ToolStripMenuItem();
            menuPlateformes = new ToolStripMenuItem();
            menuJeux = new ToolStripMenuItem();
            menuParticipants = new ToolStripMenuItem();
            menuJoueurs = new ToolStripMenuItem();
            menuOrganisateurs = new ToolStripMenuItem();
            menuStatistiques = new ToolStripMenuItem();
            menuRapports = new ToolStripMenuItem();
            menuExport = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            menuParametres = new ToolStripMenuItem();
            menuAPropos = new ToolStripMenuItem();
            menuDeconnexion = new ToolStripMenuItem();
            panelTop = new Panel();
            labelUtilisateur = new Label();
            labelTitreFestival = new Label();
            panelMain = new Panel();
            panelStatistiques = new Panel();
            groupBoxStatsTournois = new GroupBox();
            labelStatEnCours = new Label();
            labelStatPlanifies = new Label();
            labelStatTotal = new Label();
            labelTitreTournois = new Label();
            groupBoxStatsParticipants = new GroupBox();
            labelStatInscrits = new Label();
            labelStatCapacite = new Label();
            labelTitreParticipants = new Label();
            groupBoxStatsEspaces = new GroupBox();
            labelStatEspacesLibres = new Label();
            labelStatEspacesTotal = new Label();
            labelTitreEspaces = new Label();
            groupBoxStatsPostes = new GroupBox();
            labelStatPostesHS = new Label();
            labelStatPostesFonctionnels = new Label();
            labelTitrePostes = new Label();
            panelAccesRapide = new Panel();
            groupBoxAccesRapide = new GroupBox();
            buttonVoirStatistiques = new Button();
            buttonGestionLots = new Button();
            buttonGestionInscriptions = new Button();
            buttonNouveauTournoi = new Button();
            panelProchainsTournois = new Panel();
            groupBoxProchainsTournois = new GroupBox();
            listViewProchainsTournois = new ListView();
            columnNom = new ColumnHeader();
            columnDate = new ColumnHeader();
            columnParticipants = new ColumnHeader();
            columnStatut = new ColumnHeader();
            panelAlertesNotifications = new Panel();
            groupBoxAlertesNotifications = new GroupBox();
            listViewAlertes = new ListView();
            columnTypeAlerte = new ColumnHeader();
            columnMessageAlerte = new ColumnHeader();
            statusStrip = new StatusStrip();
            toolStripStatusLabelUtilisateur = new ToolStripStatusLabel();
            toolStripStatusLabelSeparator = new ToolStripStatusLabel();
            toolStripStatusLabelDate = new ToolStripStatusLabel();
            toolStripStatusLabelSeparator2 = new ToolStripStatusLabel();
            toolStripStatusLabelVersion = new ToolStripStatusLabel();
            menuStrip.SuspendLayout();
            panelTop.SuspendLayout();
            panelMain.SuspendLayout();
            panelStatistiques.SuspendLayout();
            groupBoxStatsTournois.SuspendLayout();
            groupBoxStatsParticipants.SuspendLayout();
            groupBoxStatsEspaces.SuspendLayout();
            groupBoxStatsPostes.SuspendLayout();
            panelAccesRapide.SuspendLayout();
            groupBoxAccesRapide.SuspendLayout();
            panelProchainsTournois.SuspendLayout();
            groupBoxProchainsTournois.SuspendLayout();
            panelAlertesNotifications.SuspendLayout();
            groupBoxAlertesNotifications.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.BackColor = Color.FromArgb(63, 81, 181);
            menuStrip.Font = new Font("Segoe UI", 10F);
            menuStrip.ImageScalingSize = new Size(24, 24);
            menuStrip.Items.AddRange(new ToolStripItem[] { menuTournois, menuInfrastructure, menuParticipants, menuStatistiques, menuParametres, menuAPropos, menuDeconnexion });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(11, 5, 0, 5);
            menuStrip.Size = new Size(2000, 42);
            menuStrip.TabIndex = 0;
            // 
            // menuTournois
            // 
            menuTournois.DropDownItems.AddRange(new ToolStripItem[] { menuGestionTournois, menuInscriptions, toolStripSeparator1, menuResultats, menuLots });
            menuTournois.ForeColor = Color.White;
            menuTournois.Name = "menuTournois";
            menuTournois.Size = new Size(134, 32);
            menuTournois.Text = "🏆 Tournois";
            // 
            // menuGestionTournois
            // 
            menuGestionTournois.Name = "menuGestionTournois";
            menuGestionTournois.ShortcutKeys = Keys.Control | Keys.T;
            menuGestionTournois.Size = new Size(361, 36);
            menuGestionTournois.Text = "Gestion des tournois";
            menuGestionTournois.Click += menuGestionTournois_Click;
            // 
            // menuInscriptions
            // 
            menuInscriptions.Name = "menuInscriptions";
            menuInscriptions.Size = new Size(361, 36);
            menuInscriptions.Text = "Inscriptions";
            menuInscriptions.Click += menuInscriptions_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(358, 6);
            // 
            // menuResultats
            // 
            menuResultats.Name = "menuResultats";
            menuResultats.Size = new Size(361, 36);
            menuResultats.Text = "Résultats et classements";
            menuResultats.Click += menuResultats_Click;
            // 
            // menuLots
            // 
            menuLots.Name = "menuLots";
            menuLots.Size = new Size(361, 36);
            menuLots.Text = "Gestion des lots";
            menuLots.Click += menuLots_Click;
            // 
            // menuInfrastructure
            // 
            menuInfrastructure.DropDownItems.AddRange(new ToolStripItem[] { menuEspaces, menuPostesJeu, menuPlateformes, menuJeux });
            menuInfrastructure.ForeColor = Color.White;
            menuInfrastructure.Name = "menuInfrastructure";
            menuInfrastructure.Size = new Size(176, 32);
            menuInfrastructure.Text = "🏢 Infrastructure";
            // 
            // menuEspaces
            // 
            menuEspaces.Name = "menuEspaces";
            menuEspaces.ShortcutKeys = Keys.Control | Keys.E;
            menuEspaces.Size = new Size(295, 36);
            menuEspaces.Text = "Espaces";
            menuEspaces.Click += menuEspaces_Click;
            // 
            // menuPostesJeu
            // 
            menuPostesJeu.Name = "menuPostesJeu";
            menuPostesJeu.ShortcutKeys = Keys.Control | Keys.P;
            menuPostesJeu.Size = new Size(295, 36);
            menuPostesJeu.Text = "Postes de jeu";
            menuPostesJeu.Click += menuPostesJeu_Click;
            // 
            // menuPlateformes
            // 
            menuPlateformes.Name = "menuPlateformes";
            menuPlateformes.Size = new Size(295, 36);
            menuPlateformes.Text = "Plateformes";
            menuPlateformes.Click += menuPlateformes_Click;
            // 
            // menuJeux
            // 
            menuJeux.Name = "menuJeux";
            menuJeux.Size = new Size(295, 36);
            menuJeux.Text = "Jeux vidéo";
            menuJeux.Click += menuJeux_Click;
            // 
            // menuParticipants
            // 
            menuParticipants.DropDownItems.AddRange(new ToolStripItem[] { menuJoueurs, menuOrganisateurs });
            menuParticipants.ForeColor = Color.White;
            menuParticipants.Name = "menuParticipants";
            menuParticipants.Size = new Size(161, 32);
            menuParticipants.Text = "👥 Participants";
            // 
            // menuJoueurs
            // 
            menuJoueurs.Name = "menuJoueurs";
            menuJoueurs.ShortcutKeys = Keys.Control | Keys.J;
            menuJoueurs.Size = new Size(244, 36);
            menuJoueurs.Text = "Joueurs";
            menuJoueurs.Click += menuJoueurs_Click;
            // 
            // menuOrganisateurs
            // 
            menuOrganisateurs.Name = "menuOrganisateurs";
            menuOrganisateurs.Size = new Size(244, 36);
            menuOrganisateurs.Text = "Organisateurs";
            menuOrganisateurs.Click += menuOrganisateurs_Click;
            // 
            // menuStatistiques
            // 
            menuStatistiques.DropDownItems.AddRange(new ToolStripItem[] { menuRapports, menuExport, toolStripSeparator2 });
            menuStatistiques.ForeColor = Color.White;
            menuStatistiques.Name = "menuStatistiques";
            menuStatistiques.Size = new Size(160, 32);
            menuStatistiques.Text = "📊 Statistiques";
            // 
            // menuRapports
            // 
            menuRapports.Name = "menuRapports";
            menuRapports.Size = new Size(194, 36);
            menuRapports.Text = "Rapports";
            menuRapports.Click += menuRapports_Click;
            // 
            // menuExport
            // 
            menuExport.Name = "menuExport";
            menuExport.Size = new Size(194, 36);
            menuExport.Text = "Exporter";
            menuExport.Click += menuExport_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(191, 6);
            // 
            // menuParametres
            // 
            menuParametres.ForeColor = Color.White;
            menuParametres.Name = "menuParametres";
            menuParametres.Size = new Size(156, 32);
            menuParametres.Text = "⚙️ Paramètres";
            menuParametres.Click += menuParametres_Click;
            // 
            // menuAPropos
            // 
            menuAPropos.ForeColor = Color.White;
            menuAPropos.Name = "menuAPropos";
            menuAPropos.Size = new Size(141, 32);
            menuAPropos.Text = "ℹ️ À propos";
            menuAPropos.Click += menuAPropos_Click;
            // 
            // menuDeconnexion
            // 
            menuDeconnexion.Alignment = ToolStripItemAlignment.Right;
            menuDeconnexion.ForeColor = Color.White;
            menuDeconnexion.Name = "menuDeconnexion";
            menuDeconnexion.Size = new Size(174, 32);
            menuDeconnexion.Text = "🚪 Déconnexion";
            menuDeconnexion.Click += menuDeconnexion_Click;
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(63, 81, 181);
            panelTop.Controls.Add(labelUtilisateur);
            panelTop.Controls.Add(labelTitreFestival);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 42);
            panelTop.Margin = new Padding(4, 5, 4, 5);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(2000, 133);
            panelTop.TabIndex = 1;
            // 
            // labelUtilisateur
            // 
            labelUtilisateur.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelUtilisateur.Font = new Font("Segoe UI", 10F);
            labelUtilisateur.ForeColor = Color.White;
            labelUtilisateur.Location = new Point(1571, 75);
            labelUtilisateur.Margin = new Padding(4, 0, 4, 0);
            labelUtilisateur.Name = "labelUtilisateur";
            labelUtilisateur.Size = new Size(400, 38);
            labelUtilisateur.TabIndex = 1;
            labelUtilisateur.Text = "👤 Connecté : Admin";
            labelUtilisateur.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelTitreFestival
            // 
            labelTitreFestival.AutoSize = true;
            labelTitreFestival.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            labelTitreFestival.ForeColor = Color.White;
            labelTitreFestival.Location = new Point(29, 33);
            labelTitreFestival.Margin = new Padding(4, 0, 4, 0);
            labelTitreFestival.Name = "labelTitreFestival";
            labelTitreFestival.Size = new Size(605, 54);
            labelTitreFestival.TabIndex = 0;
            labelTitreFestival.Text = "🎮 Festival Gaming Tours 2026";
            // 
            // panelMain
            // 
            panelMain.AutoScroll = true;
            panelMain.BackColor = Color.FromArgb(240, 240, 240);
            panelMain.Controls.Add(panelStatistiques);
            panelMain.Controls.Add(panelAccesRapide);
            panelMain.Controls.Add(panelProchainsTournois);
            panelMain.Controls.Add(panelAlertesNotifications);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 175);
            panelMain.Margin = new Padding(4, 5, 4, 5);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(21, 25, 21, 25);
            panelMain.Size = new Size(2000, 1158);
            panelMain.TabIndex = 2;
            // 
            // panelStatistiques
            // 
            panelStatistiques.Controls.Add(groupBoxStatsTournois);
            panelStatistiques.Controls.Add(groupBoxStatsParticipants);
            panelStatistiques.Controls.Add(groupBoxStatsEspaces);
            panelStatistiques.Controls.Add(groupBoxStatsPostes);
            panelStatistiques.Dock = DockStyle.Top;
            panelStatistiques.Location = new Point(21, 875);
            panelStatistiques.Margin = new Padding(4, 5, 4, 5);
            panelStatistiques.Name = "panelStatistiques";
            panelStatistiques.Size = new Size(1958, 233);
            panelStatistiques.TabIndex = 0;
            // 
            // groupBoxStatsTournois
            // 
            groupBoxStatsTournois.BackColor = Color.White;
            groupBoxStatsTournois.Controls.Add(labelStatEnCours);
            groupBoxStatsTournois.Controls.Add(labelStatPlanifies);
            groupBoxStatsTournois.Controls.Add(labelStatTotal);
            groupBoxStatsTournois.Controls.Add(labelTitreTournois);
            groupBoxStatsTournois.FlatStyle = FlatStyle.Flat;
            groupBoxStatsTournois.Location = new Point(14, 17);
            groupBoxStatsTournois.Margin = new Padding(4, 5, 4, 5);
            groupBoxStatsTournois.Name = "groupBoxStatsTournois";
            groupBoxStatsTournois.Padding = new Padding(4, 5, 4, 5);
            groupBoxStatsTournois.Size = new Size(457, 200);
            groupBoxStatsTournois.TabIndex = 0;
            groupBoxStatsTournois.TabStop = false;
            // 
            // labelStatEnCours
            // 
            labelStatEnCours.Font = new Font("Segoe UI", 9.75F);
            labelStatEnCours.Location = new Point(243, 142);
            labelStatEnCours.Margin = new Padding(4, 0, 4, 0);
            labelStatEnCours.Name = "labelStatEnCours";
            labelStatEnCours.Size = new Size(186, 33);
            labelStatEnCours.TabIndex = 3;
            labelStatEnCours.Text = "En cours : 3";
            // 
            // labelStatPlanifies
            // 
            labelStatPlanifies.Font = new Font("Segoe UI", 9.75F);
            labelStatPlanifies.Location = new Point(29, 142);
            labelStatPlanifies.Margin = new Padding(4, 0, 4, 0);
            labelStatPlanifies.Name = "labelStatPlanifies";
            labelStatPlanifies.Size = new Size(186, 33);
            labelStatPlanifies.TabIndex = 2;
            labelStatPlanifies.Text = "Planifiés : 12";
            // 
            // labelStatTotal
            // 
            labelStatTotal.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            labelStatTotal.ForeColor = Color.FromArgb(76, 175, 80);
            labelStatTotal.Location = new Point(29, 58);
            labelStatTotal.Margin = new Padding(4, 0, 4, 0);
            labelStatTotal.Name = "labelStatTotal";
            labelStatTotal.Size = new Size(400, 75);
            labelStatTotal.TabIndex = 1;
            labelStatTotal.Text = "24";
            labelStatTotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelTitreTournois
            // 
            labelTitreTournois.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelTitreTournois.ForeColor = Color.FromArgb(100, 100, 100);
            labelTitreTournois.Location = new Point(29, 25);
            labelTitreTournois.Margin = new Padding(4, 0, 4, 0);
            labelTitreTournois.Name = "labelTitreTournois";
            labelTitreTournois.Size = new Size(400, 33);
            labelTitreTournois.TabIndex = 0;
            labelTitreTournois.Text = "🏆 TOURNOIS";
            labelTitreTournois.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBoxStatsParticipants
            // 
            groupBoxStatsParticipants.BackColor = Color.White;
            groupBoxStatsParticipants.Controls.Add(labelStatInscrits);
            groupBoxStatsParticipants.Controls.Add(labelStatCapacite);
            groupBoxStatsParticipants.Controls.Add(labelTitreParticipants);
            groupBoxStatsParticipants.Location = new Point(500, 17);
            groupBoxStatsParticipants.Margin = new Padding(4, 5, 4, 5);
            groupBoxStatsParticipants.Name = "groupBoxStatsParticipants";
            groupBoxStatsParticipants.Padding = new Padding(4, 5, 4, 5);
            groupBoxStatsParticipants.Size = new Size(457, 200);
            groupBoxStatsParticipants.TabIndex = 1;
            groupBoxStatsParticipants.TabStop = false;
            // 
            // labelStatInscrits
            // 
            labelStatInscrits.Font = new Font("Segoe UI", 9.75F);
            labelStatInscrits.Location = new Point(29, 142);
            labelStatInscrits.Margin = new Padding(4, 0, 4, 0);
            labelStatInscrits.Name = "labelStatInscrits";
            labelStatInscrits.Size = new Size(400, 33);
            labelStatInscrits.TabIndex = 2;
            labelStatInscrits.Text = "Taux de remplissage : 78%";
            labelStatInscrits.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelStatCapacite
            // 
            labelStatCapacite.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            labelStatCapacite.ForeColor = Color.FromArgb(33, 150, 243);
            labelStatCapacite.Location = new Point(29, 58);
            labelStatCapacite.Margin = new Padding(4, 0, 4, 0);
            labelStatCapacite.Name = "labelStatCapacite";
            labelStatCapacite.Size = new Size(400, 75);
            labelStatCapacite.TabIndex = 1;
            labelStatCapacite.Text = "342";
            labelStatCapacite.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelTitreParticipants
            // 
            labelTitreParticipants.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelTitreParticipants.ForeColor = Color.FromArgb(100, 100, 100);
            labelTitreParticipants.Location = new Point(29, 25);
            labelTitreParticipants.Margin = new Padding(4, 0, 4, 0);
            labelTitreParticipants.Name = "labelTitreParticipants";
            labelTitreParticipants.Size = new Size(400, 33);
            labelTitreParticipants.TabIndex = 0;
            labelTitreParticipants.Text = "👥 PARTICIPANTS";
            labelTitreParticipants.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBoxStatsEspaces
            // 
            groupBoxStatsEspaces.BackColor = Color.White;
            groupBoxStatsEspaces.Controls.Add(labelStatEspacesLibres);
            groupBoxStatsEspaces.Controls.Add(labelStatEspacesTotal);
            groupBoxStatsEspaces.Controls.Add(labelTitreEspaces);
            groupBoxStatsEspaces.Location = new Point(986, 17);
            groupBoxStatsEspaces.Margin = new Padding(4, 5, 4, 5);
            groupBoxStatsEspaces.Name = "groupBoxStatsEspaces";
            groupBoxStatsEspaces.Padding = new Padding(4, 5, 4, 5);
            groupBoxStatsEspaces.Size = new Size(457, 200);
            groupBoxStatsEspaces.TabIndex = 2;
            groupBoxStatsEspaces.TabStop = false;
            // 
            // labelStatEspacesLibres
            // 
            labelStatEspacesLibres.Font = new Font("Segoe UI", 9.75F);
            labelStatEspacesLibres.Location = new Point(29, 142);
            labelStatEspacesLibres.Margin = new Padding(4, 0, 4, 0);
            labelStatEspacesLibres.Name = "labelStatEspacesLibres";
            labelStatEspacesLibres.Size = new Size(400, 33);
            labelStatEspacesLibres.TabIndex = 2;
            labelStatEspacesLibres.Text = "Disponibles : 8";
            labelStatEspacesLibres.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelStatEspacesTotal
            // 
            labelStatEspacesTotal.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            labelStatEspacesTotal.ForeColor = Color.FromArgb(255, 152, 0);
            labelStatEspacesTotal.Location = new Point(29, 58);
            labelStatEspacesTotal.Margin = new Padding(4, 0, 4, 0);
            labelStatEspacesTotal.Name = "labelStatEspacesTotal";
            labelStatEspacesTotal.Size = new Size(400, 75);
            labelStatEspacesTotal.TabIndex = 1;
            labelStatEspacesTotal.Text = "12";
            labelStatEspacesTotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelTitreEspaces
            // 
            labelTitreEspaces.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelTitreEspaces.ForeColor = Color.FromArgb(100, 100, 100);
            labelTitreEspaces.Location = new Point(29, 25);
            labelTitreEspaces.Margin = new Padding(4, 0, 4, 0);
            labelTitreEspaces.Name = "labelTitreEspaces";
            labelTitreEspaces.Size = new Size(400, 33);
            labelTitreEspaces.TabIndex = 0;
            labelTitreEspaces.Text = "🏢 ESPACES";
            labelTitreEspaces.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBoxStatsPostes
            // 
            groupBoxStatsPostes.BackColor = Color.White;
            groupBoxStatsPostes.Controls.Add(labelStatPostesHS);
            groupBoxStatsPostes.Controls.Add(labelStatPostesFonctionnels);
            groupBoxStatsPostes.Controls.Add(labelTitrePostes);
            groupBoxStatsPostes.Location = new Point(1471, 17);
            groupBoxStatsPostes.Margin = new Padding(4, 5, 4, 5);
            groupBoxStatsPostes.Name = "groupBoxStatsPostes";
            groupBoxStatsPostes.Padding = new Padding(4, 5, 4, 5);
            groupBoxStatsPostes.Size = new Size(457, 200);
            groupBoxStatsPostes.TabIndex = 3;
            groupBoxStatsPostes.TabStop = false;
            // 
            // labelStatPostesHS
            // 
            labelStatPostesHS.Font = new Font("Segoe UI", 9.75F);
            labelStatPostesHS.Location = new Point(243, 142);
            labelStatPostesHS.Margin = new Padding(4, 0, 4, 0);
            labelStatPostesHS.Name = "labelStatPostesHS";
            labelStatPostesHS.Size = new Size(186, 33);
            labelStatPostesHS.TabIndex = 2;
            labelStatPostesHS.Text = "HS : 5";
            // 
            // labelStatPostesFonctionnels
            // 
            labelStatPostesFonctionnels.Font = new Font("Segoe UI", 9.75F);
            labelStatPostesFonctionnels.Location = new Point(29, 142);
            labelStatPostesFonctionnels.Margin = new Padding(4, 0, 4, 0);
            labelStatPostesFonctionnels.Name = "labelStatPostesFonctionnels";
            labelStatPostesFonctionnels.Size = new Size(186, 33);
            labelStatPostesFonctionnels.TabIndex = 1;
            labelStatPostesFonctionnels.Text = "OK : 42";
            // 
            // labelTitrePostes
            // 
            labelTitrePostes.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelTitrePostes.ForeColor = Color.FromArgb(100, 100, 100);
            labelTitrePostes.Location = new Point(29, 25);
            labelTitrePostes.Margin = new Padding(4, 0, 4, 0);
            labelTitrePostes.Name = "labelTitrePostes";
            labelTitrePostes.Size = new Size(400, 33);
            labelTitrePostes.TabIndex = 0;
            labelTitrePostes.Text = "🎮 POSTES DE JEU";
            labelTitrePostes.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelAccesRapide
            // 
            panelAccesRapide.Controls.Add(groupBoxAccesRapide);
            panelAccesRapide.Dock = DockStyle.Top;
            panelAccesRapide.Location = new Point(21, 692);
            panelAccesRapide.Margin = new Padding(4, 5, 4, 5);
            panelAccesRapide.Name = "panelAccesRapide";
            panelAccesRapide.Padding = new Padding(0, 25, 0, 0);
            panelAccesRapide.Size = new Size(1958, 183);
            panelAccesRapide.TabIndex = 1;
            // 
            // groupBoxAccesRapide
            // 
            groupBoxAccesRapide.BackColor = Color.White;
            groupBoxAccesRapide.Controls.Add(buttonVoirStatistiques);
            groupBoxAccesRapide.Controls.Add(buttonGestionLots);
            groupBoxAccesRapide.Controls.Add(buttonGestionInscriptions);
            groupBoxAccesRapide.Controls.Add(buttonNouveauTournoi);
            groupBoxAccesRapide.Dock = DockStyle.Fill;
            groupBoxAccesRapide.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxAccesRapide.Location = new Point(0, 25);
            groupBoxAccesRapide.Margin = new Padding(4, 5, 4, 5);
            groupBoxAccesRapide.Name = "groupBoxAccesRapide";
            groupBoxAccesRapide.Padding = new Padding(21, 25, 21, 25);
            groupBoxAccesRapide.Size = new Size(1958, 158);
            groupBoxAccesRapide.TabIndex = 0;
            groupBoxAccesRapide.TabStop = false;
            groupBoxAccesRapide.Text = "⚡ Accès Rapide";
            // 
            // buttonVoirStatistiques
            // 
            buttonVoirStatistiques.BackColor = Color.FromArgb(156, 39, 176);
            buttonVoirStatistiques.FlatAppearance.BorderSize = 0;
            buttonVoirStatistiques.FlatStyle = FlatStyle.Flat;
            buttonVoirStatistiques.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonVoirStatistiques.ForeColor = Color.White;
            buttonVoirStatistiques.Location = new Point(1279, 50);
            buttonVoirStatistiques.Margin = new Padding(4, 5, 4, 5);
            buttonVoirStatistiques.Name = "buttonVoirStatistiques";
            buttonVoirStatistiques.Size = new Size(386, 83);
            buttonVoirStatistiques.TabIndex = 3;
            buttonVoirStatistiques.Text = "📊 Voir statistiques détaillées";
            buttonVoirStatistiques.UseVisualStyleBackColor = false;
            buttonVoirStatistiques.Click += buttonVoirStatistiques_Click;
            // 
            // buttonGestionLots
            // 
            buttonGestionLots.BackColor = Color.FromArgb(255, 193, 7);
            buttonGestionLots.FlatAppearance.BorderSize = 0;
            buttonGestionLots.FlatStyle = FlatStyle.Flat;
            buttonGestionLots.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonGestionLots.ForeColor = Color.White;
            buttonGestionLots.Location = new Point(864, 50);
            buttonGestionLots.Margin = new Padding(4, 5, 4, 5);
            buttonGestionLots.Name = "buttonGestionLots";
            buttonGestionLots.Size = new Size(386, 83);
            buttonGestionLots.TabIndex = 2;
            buttonGestionLots.Text = "🎁 Gérer les lots";
            buttonGestionLots.UseVisualStyleBackColor = false;
            buttonGestionLots.Click += buttonGestionLots_Click;
            // 
            // buttonGestionInscriptions
            // 
            buttonGestionInscriptions.BackColor = Color.FromArgb(33, 150, 243);
            buttonGestionInscriptions.FlatAppearance.BorderSize = 0;
            buttonGestionInscriptions.FlatStyle = FlatStyle.Flat;
            buttonGestionInscriptions.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonGestionInscriptions.ForeColor = Color.White;
            buttonGestionInscriptions.Location = new Point(450, 50);
            buttonGestionInscriptions.Margin = new Padding(4, 5, 4, 5);
            buttonGestionInscriptions.Name = "buttonGestionInscriptions";
            buttonGestionInscriptions.Size = new Size(386, 83);
            buttonGestionInscriptions.TabIndex = 1;
            buttonGestionInscriptions.Text = "📝 Gérer les inscriptions";
            buttonGestionInscriptions.UseVisualStyleBackColor = false;
            buttonGestionInscriptions.Click += buttonGestionInscriptions_Click;
            // 
            // buttonNouveauTournoi
            // 
            buttonNouveauTournoi.BackColor = Color.FromArgb(76, 175, 80);
            buttonNouveauTournoi.FlatAppearance.BorderSize = 0;
            buttonNouveauTournoi.FlatStyle = FlatStyle.Flat;
            buttonNouveauTournoi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonNouveauTournoi.ForeColor = Color.White;
            buttonNouveauTournoi.Location = new Point(36, 50);
            buttonNouveauTournoi.Margin = new Padding(4, 5, 4, 5);
            buttonNouveauTournoi.Name = "buttonNouveauTournoi";
            buttonNouveauTournoi.Size = new Size(386, 83);
            buttonNouveauTournoi.TabIndex = 0;
            buttonNouveauTournoi.Text = "➕ Créer un nouveau tournoi";
            buttonNouveauTournoi.UseVisualStyleBackColor = false;
            buttonNouveauTournoi.Click += buttonNouveauTournoi_Click;
            // 
            // panelProchainsTournois
            // 
            panelProchainsTournois.Controls.Add(groupBoxProchainsTournois);
            panelProchainsTournois.Dock = DockStyle.Top;
            panelProchainsTournois.Location = new Point(21, 325);
            panelProchainsTournois.Margin = new Padding(4, 5, 4, 5);
            panelProchainsTournois.Name = "panelProchainsTournois";
            panelProchainsTournois.Padding = new Padding(0, 25, 0, 0);
            panelProchainsTournois.Size = new Size(1958, 367);
            panelProchainsTournois.TabIndex = 2;
            // 
            // groupBoxProchainsTournois
            // 
            groupBoxProchainsTournois.BackColor = Color.White;
            groupBoxProchainsTournois.Controls.Add(listViewProchainsTournois);
            groupBoxProchainsTournois.Dock = DockStyle.Fill;
            groupBoxProchainsTournois.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxProchainsTournois.Location = new Point(0, 25);
            groupBoxProchainsTournois.Margin = new Padding(4, 5, 4, 5);
            groupBoxProchainsTournois.Name = "groupBoxProchainsTournois";
            groupBoxProchainsTournois.Padding = new Padding(21, 25, 21, 25);
            groupBoxProchainsTournois.Size = new Size(1958, 342);
            groupBoxProchainsTournois.TabIndex = 0;
            groupBoxProchainsTournois.TabStop = false;
            groupBoxProchainsTournois.Text = "📅 Prochains Tournois (7 jours)";
            // 
            // listViewProchainsTournois
            // 
            listViewProchainsTournois.Columns.AddRange(new ColumnHeader[] { columnNom, columnDate, columnParticipants, columnStatut });
            listViewProchainsTournois.Dock = DockStyle.Fill;
            listViewProchainsTournois.Font = new Font("Segoe UI", 9.75F);
            listViewProchainsTournois.FullRowSelect = true;
            listViewProchainsTournois.GridLines = true;
            listViewProchainsTournois.Location = new Point(21, 52);
            listViewProchainsTournois.Margin = new Padding(4, 5, 4, 5);
            listViewProchainsTournois.MultiSelect = false;
            listViewProchainsTournois.Name = "listViewProchainsTournois";
            listViewProchainsTournois.Size = new Size(1916, 265);
            listViewProchainsTournois.TabIndex = 0;
            listViewProchainsTournois.UseCompatibleStateImageBehavior = false;
            listViewProchainsTournois.View = View.Details;
            listViewProchainsTournois.DoubleClick += listViewProchainsTournois_DoubleClick;
            // 
            // columnNom
            // 
            columnNom.Text = "Nom du tournoi";
            columnNom.Width = 400;
            // 
            // columnDate
            // 
            columnDate.Text = "Date et heure";
            columnDate.Width = 200;
            // 
            // columnParticipants
            // 
            columnParticipants.Text = "Inscrits / Capacité";
            columnParticipants.Width = 180;
            // 
            // columnStatut
            // 
            columnStatut.Text = "Statut";
            columnStatut.Width = 150;
            // 
            // panelAlertesNotifications
            // 
            panelAlertesNotifications.Controls.Add(groupBoxAlertesNotifications);
            panelAlertesNotifications.Dock = DockStyle.Top;
            panelAlertesNotifications.Location = new Point(21, 25);
            panelAlertesNotifications.Margin = new Padding(4, 5, 4, 5);
            panelAlertesNotifications.Name = "panelAlertesNotifications";
            panelAlertesNotifications.Padding = new Padding(0, 25, 0, 0);
            panelAlertesNotifications.Size = new Size(1958, 300);
            panelAlertesNotifications.TabIndex = 3;
            // 
            // groupBoxAlertesNotifications
            // 
            groupBoxAlertesNotifications.BackColor = Color.White;
            groupBoxAlertesNotifications.Controls.Add(listViewAlertes);
            groupBoxAlertesNotifications.Dock = DockStyle.Fill;
            groupBoxAlertesNotifications.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxAlertesNotifications.Location = new Point(0, 25);
            groupBoxAlertesNotifications.Margin = new Padding(4, 5, 4, 5);
            groupBoxAlertesNotifications.Name = "groupBoxAlertesNotifications";
            groupBoxAlertesNotifications.Padding = new Padding(21, 25, 21, 25);
            groupBoxAlertesNotifications.Size = new Size(1958, 275);
            groupBoxAlertesNotifications.TabIndex = 0;
            groupBoxAlertesNotifications.TabStop = false;
            groupBoxAlertesNotifications.Text = "🔔 Alertes et Notifications";
            // 
            // listViewAlertes
            // 
            listViewAlertes.Columns.AddRange(new ColumnHeader[] { columnTypeAlerte, columnMessageAlerte });
            listViewAlertes.Dock = DockStyle.Fill;
            listViewAlertes.Font = new Font("Segoe UI", 9.75F);
            listViewAlertes.FullRowSelect = true;
            listViewAlertes.GridLines = true;
            listViewAlertes.Location = new Point(21, 52);
            listViewAlertes.Margin = new Padding(4, 5, 4, 5);
            listViewAlertes.Name = "listViewAlertes";
            listViewAlertes.Size = new Size(1916, 198);
            listViewAlertes.TabIndex = 0;
            listViewAlertes.UseCompatibleStateImageBehavior = false;
            listViewAlertes.View = View.Details;
            // 
            // columnTypeAlerte
            // 
            columnTypeAlerte.Text = "Type";
            columnTypeAlerte.Width = 150;
            // 
            // columnMessageAlerte
            // 
            columnMessageAlerte.Text = "Message";
            columnMessageAlerte.Width = 1000;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(24, 24);
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelUtilisateur, toolStripStatusLabelSeparator, toolStripStatusLabelDate, toolStripStatusLabelSeparator2, toolStripStatusLabelVersion });
            statusStrip.Location = new Point(0, 1301);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(1, 0, 20, 0);
            statusStrip.Size = new Size(2000, 32);
            statusStrip.TabIndex = 3;
            // 
            // toolStripStatusLabelUtilisateur
            // 
            toolStripStatusLabelUtilisateur.Name = "toolStripStatusLabelUtilisateur";
            toolStripStatusLabelUtilisateur.Size = new Size(153, 25);
            toolStripStatusLabelUtilisateur.Text = "Connecté : Admin";
            // 
            // toolStripStatusLabelSeparator
            // 
            toolStripStatusLabelSeparator.Name = "toolStripStatusLabelSeparator";
            toolStripStatusLabelSeparator.Size = new Size(16, 25);
            toolStripStatusLabelSeparator.Text = "|";
            // 
            // toolStripStatusLabelDate
            // 
            toolStripStatusLabelDate.Name = "toolStripStatusLabelDate";
            toolStripStatusLabelDate.Size = new Size(280, 25);
            toolStripStatusLabelDate.Text = "Mercredi 5 février 2026 - 08:35:42";
            // 
            // toolStripStatusLabelSeparator2
            // 
            toolStripStatusLabelSeparator2.Name = "toolStripStatusLabelSeparator2";
            toolStripStatusLabelSeparator2.Size = new Size(16, 25);
            toolStripStatusLabelSeparator2.Text = "|";
            // 
            // toolStripStatusLabelVersion
            // 
            toolStripStatusLabelVersion.Name = "toolStripStatusLabelVersion";
            toolStripStatusLabelVersion.Size = new Size(99, 25);
            toolStripStatusLabelVersion.Text = "Version 1.0";
            // 
            // FormDashboard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2000, 1333);
            Controls.Add(statusStrip);
            Controls.Add(panelMain);
            Controls.Add(panelTop);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(1705, 1129);
            Name = "FormDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "🎮 Gestion Festival Gaming - Dashboard Organisateur";
            WindowState = FormWindowState.Maximized;
            Load += FormDashboard_Load;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelMain.ResumeLayout(false);
            panelStatistiques.ResumeLayout(false);
            groupBoxStatsTournois.ResumeLayout(false);
            groupBoxStatsParticipants.ResumeLayout(false);
            groupBoxStatsEspaces.ResumeLayout(false);
            groupBoxStatsPostes.ResumeLayout(false);
            panelAccesRapide.ResumeLayout(false);
            groupBoxAccesRapide.ResumeLayout(false);
            panelProchainsTournois.ResumeLayout(false);
            groupBoxProchainsTournois.ResumeLayout(false);
            panelAlertesNotifications.ResumeLayout(false);
            groupBoxAlertesNotifications.ResumeLayout(false);
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
            private ToolStripMenuItem menuTournois;
            private ToolStripMenuItem menuGestionTournois;
            private ToolStripMenuItem menuInscriptions;
            private ToolStripSeparator toolStripSeparator1;
            private ToolStripMenuItem menuResultats;
            private ToolStripMenuItem menuLots;
            private ToolStripMenuItem menuInfrastructure;
            private ToolStripMenuItem menuEspaces;
            private ToolStripMenuItem menuPostesJeu;
            private ToolStripMenuItem menuPlateformes;
            private ToolStripMenuItem menuJeux;
            private ToolStripMenuItem menuParticipants;
            private ToolStripMenuItem menuJoueurs;
            private ToolStripMenuItem menuOrganisateurs;
            private ToolStripMenuItem menuStatistiques;
            private ToolStripMenuItem menuRapports;
            private ToolStripMenuItem menuExport;
            private ToolStripSeparator toolStripSeparator2;
            private ToolStripMenuItem menuParametres;
            private ToolStripMenuItem menuAPropos;
            private ToolStripMenuItem menuDeconnexion;
            private Panel panelTop;
            private Label labelTitreFestival;
            private Label labelUtilisateur;
            private Panel panelMain;
            private Panel panelStatistiques;
            private GroupBox groupBoxStatsTournois;
            private Label labelTitreTournois;
            private Label labelStatTotal;
            private Label labelStatPlanifies;
            private Label labelStatEnCours;
            private GroupBox groupBoxStatsParticipants;
            private Label labelTitreParticipants;
            private Label labelStatCapacite;
            private Label labelStatInscrits;
            private GroupBox groupBoxStatsEspaces;
            private Label labelTitreEspaces;
            private Label labelStatEspacesTotal;
            private Label labelStatEspacesLibres;
            private GroupBox groupBoxStatsPostes;
            private Label labelTitrePostes;
            private Label labelStatPostesFonctionnels;
            private Label labelStatPostesHS;
            private Panel panelAccesRapide;
            private GroupBox groupBoxAccesRapide;
            private Button buttonNouveauTournoi;
            private Button buttonGestionInscriptions;
            private Button buttonGestionLots;
            private Button buttonVoirStatistiques;
            private Panel panelProchainsTournois;
            private GroupBox groupBoxProchainsTournois;
            private ListView listViewProchainsTournois;
            private ColumnHeader columnNom;
            private ColumnHeader columnDate;
            private ColumnHeader columnParticipants;
            private ColumnHeader columnStatut;
            private Panel panelAlertesNotifications;
            private GroupBox groupBoxAlertesNotifications;
            private ListView listViewAlertes;
            private ColumnHeader columnTypeAlerte;
            private ColumnHeader columnMessageAlerte;
            private StatusStrip statusStrip;
            private ToolStripStatusLabel toolStripStatusLabelUtilisateur;
            private ToolStripStatusLabel toolStripStatusLabelSeparator;
            private ToolStripStatusLabel toolStripStatusLabelDate;
            private ToolStripStatusLabel toolStripStatusLabelSeparator2;
            private ToolStripStatusLabel toolStripStatusLabelVersion;
        }
    }
