    using Lib_Entities.Entities;
using Lib_Metier.Data.Configurations;
using Lib_Services.Interfaces;
using Lib_Services.Services;
using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace ApplicationUi
    {
        public partial class FormDashboard : Form
        {
            private readonly ITournoiService _tournoiRepository;
            private readonly IEspaceService _espaceRepository;
            private readonly IPosteJeuService _posteJeuRepository;
            private Timer _timerHorloge;
            private string _utilisateurConnecte = "Admin"; // À remplacer par le vrai utilisateur

            public FormDashboard()
            {
                InitializeComponent();

            _tournoiRepository = new TournoiService(new ApplicationDbContext());
            _espaceRepository = new EspaceService(new ApplicationDbContext());
            _posteJeuRepository = new PosteJeuService(new ApplicationDbContext());
        }

            #region Chargement et initialisation

            private void FormDashboard_Load(object sender, EventArgs e)
            {
                ChargerStatistiques();
                ChargerProchainsTournois();
                ChargerAlertesNotifications();
                InitialiserHorloge();
                MettreAJourInfoUtilisateur();
            }

            private void InitialiserHorloge()
            {
                _timerHorloge = new Timer();
                _timerHorloge.Interval = 1000; // 1 seconde
                _timerHorloge.Tick += TimerHorloge_Tick;
                _timerHorloge.Start();
            }

            private void TimerHorloge_Tick(object sender, EventArgs e)
            {
                toolStripStatusLabelDate.Text = DateTime.Now.ToString("dddd d MMMM yyyy - HH:mm:ss");
            }

            private void MettreAJourInfoUtilisateur()
            {
                labelUtilisateur.Text = $"👤 Connecté : {_utilisateurConnecte}";
                toolStripStatusLabelUtilisateur.Text = $"Connecté : {_utilisateurConnecte}";
            }

            #endregion

            #region Statistiques

            private void ChargerStatistiques()
            {
                try
                {
                    // Statistiques Tournois
                    var tournois = _tournoiRepository.Lister("");
                    labelStatTotal.Text = tournois.Count.ToString();

                    int planifies = tournois.Count(t => t.Statut?.ToLower() == "planifié");
                    int enCours = tournois.Count(t => t.Statut?.ToLower() == "en cours");

                    labelStatPlanifies.Text = $"Planifiés : {planifies}";
                    labelStatEnCours.Text = $"En cours : {enCours}";

                    // Statistiques Participants (exemple fictif)
                    int totalInscrits = 342; // À calculer depuis la table Participer
                    int capaciteTotale = 440;
                    int tauxRemplissage = capaciteTotale > 0 ? (int)((double)totalInscrits / capaciteTotale * 100) : 0;

                    labelStatCapacite.Text = totalInscrits.ToString();
                    labelStatInscrits.Text = $"Taux de remplissage : {tauxRemplissage}%";

                    // Statistiques Espaces
                    var espaces = _espaceRepository.Lister("");
                    labelStatEspacesTotal.Text = espaces.Count.ToString();

                    // Espaces disponibles (sans tournoi programmé aujourd'hui)
                    int espacesLibres = 8; // À calculer
                    labelStatEspacesLibres.Text = $"Disponibles : {espacesLibres}";

                    // Statistiques Postes
                    //var postesJeu = _posteJeuRepository.Lister();
                    //int postesFonctionnels = postesJeu.Count(p => p.EstFonctionnel);
                    //int postesHS = postesJeu.Count - postesFonctionnels;

                    //labelStatPostesFonctionnels.Text = $"OK : {postesFonctionnels}";
                    //labelStatPostesHS.Text = $"HS : {postesHS}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors du chargement des statistiques : {ex.Message}",
                                   "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            #endregion

            #region Prochains Tournois

            private void ChargerProchainsTournois()
            {
                try
                {
                    listViewProchainsTournois.Items.Clear();

                    // Récupérer les tournois des 7 prochains jours
                    //var tournois = _tournoiRepository.Lister()
                    //    .Where(t => t.DateHeure.HasValue &&
                    //                t.DateHeure.Value >= DateTime.Now &&
                    //                t.DateHeure.Value <= DateTime.Now.AddDays(7))
                    //    .OrderBy(t => t.DateHeure)
                    //    .Take(10)
                    //    .ToList();

                    //foreach (var tournoi in tournois)
                    //{
                    //    var item = new ListViewItem(tournoi.Nom ?? "Sans nom");
                    //    item.SubItems.Add(tournoi.DateHeure?.ToString("dd/MM/yyyy HH:mm") ?? "N/A");

                    //    // Participants (exemple fictif - à récupérer depuis la table Participer)
                    //    int inscrits = 12; // À calculer
                    //    int capacite = tournoi.NbParticipants ?? 0;
                    //    item.SubItems.Add($"{inscrits} / {capacite}");

                    //    item.SubItems.Add(tournoi.Statut ?? "N/A");

                    //    // Colorer selon le statut
                    //    switch (tournoi.Statut?.ToLower())
                    //    {
                    //        case "planifié":
                    //            item.BackColor = System.Drawing.Color.FromArgb(200, 230, 201);
                    //            break;
                    //        case "en cours":
                    //            item.BackColor = System.Drawing.Color.FromArgb(179, 229, 252);
                    //            break;
                    //        case "terminé":
                    //            item.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
                    //            break;
                    //    }

                    //    item.Tag = tournoi; // Stocker l'objet pour double-clic
                    //    listViewProchainsTournois.Items.Add(item);
                    //}

                    //if (tournois.Count == 0)
                    //{
                    //    var item = new ListViewItem("Aucun tournoi prévu dans les 7 prochains jours");
                    //    item.Font = new System.Drawing.Font(item.Font, System.Drawing.FontStyle.Italic);
                    //    item.ForeColor = System.Drawing.Color.Gray;
                    //    listViewProchainsTournois.Items.Add(item);
                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors du chargement des tournois : {ex.Message}",
                                   "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void listViewProchainsTournois_DoubleClick(object sender, EventArgs e)
            {
                if (listViewProchainsTournois.SelectedItems.Count > 0 &&
                    listViewProchainsTournois.SelectedItems[0].Tag is Tournoi)
                {
                    // Ouvrir le formulaire de gestion des tournois
                    menuGestionTournois_Click(sender, e);
                }
            }

            #endregion

            #region Alertes et Notifications

            private void ChargerAlertesNotifications()
            {
                try
                {
                    listViewAlertes.Items.Clear();

                    // Exemple d'alertes (à calculer dynamiquement)

                    // Vérifier les postes HS
                    //var postesHS = _posteJeuRepository.Lister().Count(p => !p.EstFonctionnel);
                    //if (postesHS > 0)
                    //{
                    //    var item = new ListViewItem("⚠️ Matériel");
                    //    item.SubItems.Add($"{postesHS} poste(s) de jeu hors service");
                    //    item.BackColor = System.Drawing.Color.FromArgb(255, 243, 224);
                    //    listViewAlertes.Items.Add(item);
                    //}

                    // Vérifier les tournois sans inscription
                    //var tournoisSansInscription = _tournoiRepository.Lister()
                    //    .Count(t => t.DateHeure.HasValue &&
                    //               t.DateHeure.Value <= DateTime.Now.AddDays(3) &&
                    //               t.DateHeure.Value >= DateTime.Now);

                    //if (tournoisSansInscription > 0)
                    //{
                    //    var item = new ListViewItem("ℹ️ Information");
                    //    item.SubItems.Add($"{tournoisSansInscription} tournoi(s) dans moins de 3 jours avec peu d'inscrits");
                    //    item.BackColor = System.Drawing.Color.FromArgb(227, 242, 253);
                    //    listViewAlertes.Items.Add(item);
                    //}

                    // Alerte espaces
                    var item3 = new ListViewItem("✅ Succès");
                    item3.SubItems.Add("Tous les espaces sont prêts pour le festival");
                    item3.BackColor = System.Drawing.Color.FromArgb(200, 230, 201);
                    listViewAlertes.Items.Add(item3);

                    if (listViewAlertes.Items.Count == 0)
                    {
                        var item = new ListViewItem("ℹ️ Information");
                        item.SubItems.Add("Aucune alerte pour le moment");
                        item.Font = new System.Drawing.Font(item.Font, System.Drawing.FontStyle.Italic);
                        item.ForeColor = System.Drawing.Color.Gray;
                        listViewAlertes.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors du chargement des alertes : {ex.Message}",
                                   "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            #endregion

            #region Menu Tournois

            private void menuGestionTournois_Click(object sender, EventArgs e)
            {
                //OuvrirFormulaire(new FormHome());
            }

            private void menuInscriptions_Click(object sender, EventArgs e)
            {
                MessageBox.Show("Fonctionnalité à implémenter par les étudiants",
                               "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            private void menuResultats_Click(object sender, EventArgs e)
            {
                MessageBox.Show("Fonctionnalité à implémenter par les étudiants",
                               "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            private void menuLots_Click(object sender, EventArgs e)
            {
                MessageBox.Show("Fonctionnalité à implémenter par les étudiants",
                               "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            #endregion

            #region Menu Infrastructure

            private void menuEspaces_Click(object sender, EventArgs e)
            {
                MessageBox.Show("Fonctionnalité à implémenter : FormEspaces",
                               "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            private void menuPostesJeu_Click(object sender, EventArgs e)
            {
                MessageBox.Show("Fonctionnalité à implémenter : FormPostesJeu",
                               "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            private void menuPlateformes_Click(object sender, EventArgs e)
            {
                MessageBox.Show("Fonctionnalité à implémenter : FormPlateformes",
                               "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            private void menuJeux_Click(object sender, EventArgs e)
            {
                MessageBox.Show("Fonctionnalité à implémenter : FormJeux",
                               "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            #endregion

            #region Menu Participants

            private void menuJoueurs_Click(object sender, EventArgs e)
            {
                MessageBox.Show("Fonctionnalité à implémenter : FormJoueurs",
                               "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            private void menuOrganisateurs_Click(object sender, EventArgs e)
            {
                MessageBox.Show("Fonctionnalité à implémenter : FormOrganisateurs",
                               "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            #endregion

            #region Menu Statistiques

            private void menuRapports_Click(object sender, EventArgs e)
            {
                MessageBox.Show("Fonctionnalité à implémenter : FormRapports",
                               "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            private void menuExport_Click(object sender, EventArgs e)
            {
                MessageBox.Show("Fonctionnalité à implémenter : Export Excel/PDF",
                               "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            #endregion

            #region Menu Paramètres et Système

            private void menuParametres_Click(object sender, EventArgs e)
            {
                MessageBox.Show("Fonctionnalité à implémenter : Paramètres",
                               "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            private void menuAPropos_Click(object sender, EventArgs e)
            {
                MessageBox.Show(
                    "🎮 Gestion de Festival Gaming\n" +
                    "Version 1.0\n\n" +
                    "Développé dans le cadre d'un projet pédagogique\n" +
                    "Architecture professionnelle - Pattern Repository\n\n" +
                    "© 2026 - Tous droits réservés",
                    "À propos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            private void menuDeconnexion_Click(object sender, EventArgs e)
            {
                var resultat = MessageBox.Show(
                    "Êtes-vous sûr de vouloir vous déconnecter ?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultat == DialogResult.Yes)
                {
                    _timerHorloge?.Stop();

                    // Retourner au formulaire de connexion (à implémenter)
                    MessageBox.Show("Déconnexion...\n(Retour au formulaire de connexion à implémenter)",
                                   "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // this.Close();
                    // FormLogin formLogin = new FormLogin();
                    // formLogin.Show();
                }
            }

            #endregion

            #region Boutons Accès Rapide

            private void buttonNouveauTournoi_Click(object sender, EventArgs e)
            {
                //OuvrirFormulaire(new FormHome());
            }

            private void buttonGestionInscriptions_Click(object sender, EventArgs e)
            {
                menuInscriptions_Click(sender, e);
            }

            private void buttonGestionLots_Click(object sender, EventArgs e)
            {
                menuLots_Click(sender, e);
            }

            private void buttonVoirStatistiques_Click(object sender, EventArgs e)
            {
                menuRapports_Click(sender, e);
            }

            #endregion

            #region Méthodes utilitaires

            private void OuvrirFormulaire(Form formulaire)
            {
                formulaire.ShowDialog();

                // Rafraîchir le dashboard après fermeture du formulaire
                ChargerStatistiques();
                ChargerProchainsTournois();
                ChargerAlertesNotifications();
            }

            protected override void OnFormClosing(FormClosingEventArgs e)
            {
                _timerHorloge?.Stop();
                base.OnFormClosing(e);
            }

            #endregion
        }
    }