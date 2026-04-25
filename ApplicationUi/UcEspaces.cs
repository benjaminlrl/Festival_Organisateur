using Lib_Entities.Entities;
using Lib_Metier.Data.Configurations;
using Lib_Services.Interfaces;
using Lib_Services.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Serilog;

namespace ApplicationUi
{
    public partial class UcEspaces : UserControl
    {
        private readonly IEspaceService _serviceEspace;
        private readonly ITournoiService _serviceTournoi;
        private readonly IOrganisateurService _serviceOrganisateur;
        private readonly Organisateur _organisateurConnecte;
        private Espace? _espaceSelectionnee;
        // Champ pour stocker le texte de recherche et l'utiliser lors du rechargement des espaces
        private string filtre;
        // Champ pour stocker l'ordre de tri actuel sur la propriété de l'espace (ASC ou DESC)
        // et l'utiliser lors du rechargement des espaces
        private string ordreChamp;
        public UcEspaces(Organisateur unOrganisateurConnecte)
        {
            InitializeComponent();
            var context = new ApplicationDbContext();
            _serviceOrganisateur = new OrganisateurService(context);
            _serviceEspace = new EspaceService(context);
            _serviceTournoi = new TournoiService(context);

            _organisateurConnecte = unOrganisateurConnecte;
            _espaceSelectionnee = null;

            labelStatutTournoi.Visible = _espaceSelectionnee != null;
            dataGridTournois.Visible = _espaceSelectionnee != null;
            buttonEffacer.Text = "🧽  Effacer";

            ordreChamp = "DESC";
            filtre = "";

            Raz_Zones();

            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcEspaces, "Ajouter") == false)
            {
                buttonAjouter.Visible = false;
                DesactiverInputs();
            }
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcEspaces, "Modifier") == false)
            {
                buttonModifier.Visible = false;
                DesactiverInputs();
            }
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcEspaces, "Supprimer") == false)
            {
                buttonSupprimer.Visible = false;
                DesactiverInputs();
            }
        }

        #region Données
        /// <summary>
        /// Charge les espaces depuis la base de données et les affiche dans le DataGridView.
        /// </summary>
        /// <param name="filtre"></param>
        private void ChargerEspaces()
        {
            dataGridEspaces.DataSource = null;
            dataGridEspaces.DataSource = _serviceEspace.Lister(filtre);
            MEP_DataGridEspaces();
            ChargerStatistiques();
        }

        /// <summary>
        /// Charge les postes de jeux de l'espace selectionne
        /// </summary>
        private void ChargerPostesJeu()
        {
            // Si l'espace est null, on ne fait rien
            if (_espaceSelectionnee == null)
            {
                dataGridPostesJeu.DataSource = null;
                dataGridPostesJeu.Visible = true;
                return;
            }
            // Si il n'y a aucun poste de jeu associé à l'espace, on affiche un message et on masque le datagrid
            if (_espaceSelectionnee.PostesJeu.Count <= 0)
            {
                labelPostesJeu.Text = "Aucun poste de jeu associé";
                dataGridPostesJeu.Visible = false;
            }
            else
            {
                // Si il y a un ou plusieurs postes de jeu associés à l'espace,
                // on affiche le nombre de postes de jeu associés et on affiche le datagrid
                if (_espaceSelectionnee.PostesJeu.Count > 1)
                    labelPostesJeu.Text = "Postes de jeu associés";
                else
                    labelPostesJeu.Text = "Poste de jeu associé";

                dataGridPostesJeu.Visible = true;
                dataGridPostesJeu.DataSource = _espaceSelectionnee.PostesJeu.ToList();
                MEP_DataGridPostesJeu();
            }
        }
        /// <summary>
        /// Permet de charger les tournois associés à l'espace sélectionné et d'afficher une indication visuelle
        /// du statut de ces tournois (en cours, planifié ou aucun tournoi).
        /// </summary>
        /// <param name="tournoisEspace">La liste des tournois de l'espace</param>
        private void ChargerTournois(ICollection<Tournoi>? tournoisEspace)
        {
            if (tournoisEspace == null)
            {
                dataGridTournois.DataSource = null;
                dataGridTournois.Visible = false;
                return;
            }

            dataGridTournois.DataSource = tournoisEspace.ToList();
            dataGridTournois.Visible = true;
            MEP_DataGridTournois();
        }

        /// <summary>
        /// Permet de charger les statistiques liées aux espaces, notamment le nombre total d'espaces 
        /// et le nombre d'espaces libres (sans tournoi associé). 
        /// Les statistiques sont affichées dans des labels dédiés, 
        /// avec une indication visuelle (couleur) pour les espaces libres.
        /// Cette méthode est appelée après le chargement des espaces pour garantir 
        /// que les statistiques sont à jour.
        /// </summary>
        private void ChargerStatistiques()
        {
            // Un espace libre est un espace qui n'a pas de tournoi futur associé ou dont tous les tournois sont terminés
            int nbEspacesLibres = _serviceEspace.CompterEspacesDisponibles(filtre);
            int nbEspacesTotal = _serviceEspace.CompterEspacesTotal(filtre);
            labelStatEspacesTotal.Text = $"{nbEspacesTotal}";

            if (nbEspacesLibres == 0)
            {
                labelStatEspacesLibres.Text = "Aucun espace libre";
                labelStatEspacesLibres.ForeColor = Color.Red;
            }
            else
            {
                labelStatEspacesLibres.Text = $"Disponibles : {nbEspacesLibres}";
                labelStatEspacesLibres.ForeColor = Color.Green;
            }
        }

        private void MEP_DataGridEspaces()
        {
            DesactiverTrieAutomatique(dataGridEspaces);

            dataGridEspaces.Columns["idEspace"].Visible = false;
            dataGridEspaces.Columns["Tournois"].Visible = false;
            dataGridEspaces.Columns["PostesJeu"].Visible = false;
            dataGridEspaces.Columns["Capacitemaxi"].Visible = false;
            dataGridEspaces.Columns["Superficie"].Visible = false;

            dataGridEspaces.Columns["Nom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridEspaces.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void MEP_DataGridPostesJeu()
        {
            DesactiverTrieAutomatique(dataGridPostesJeu);

            dataGridPostesJeu.Columns["NumeroPoste"].Visible = false;
            dataGridPostesJeu.Columns["IdPlateforme"].Visible = false;
            dataGridPostesJeu.Columns["Plateforme"].Visible = false;
            dataGridPostesJeu.Columns["NomPlateforme"].Visible = false;
            dataGridPostesJeu.Columns["IdEspace"].Visible = false;
            dataGridPostesJeu.Columns["Espace"].Visible = false;
            dataGridPostesJeu.Columns["NomEspace"].Visible = false;

            dataGridPostesJeu.Columns["Reference"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridPostesJeu.Columns["Fonctionnel"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void MEP_DataGridTournois()
        {
            DesactiverTrieAutomatique(dataGridTournois);

            dataGridTournois.Visible = true;
            dataGridTournois.Columns["NumeroTournoi"].Visible = false;
            dataGridTournois.Columns["IdEspace"].Visible = false;
            dataGridTournois.Columns["Espace"].Visible = false;
            dataGridTournois.Columns["IdJeu"].Visible = false;
            dataGridTournois.Columns["Jeu"].Visible = false;
            dataGridTournois.Columns["NbParticipants"].Visible = false;
            dataGridTournois.Columns["NomEspace"].Visible = false;
            dataGridTournois.Columns["TitreJeu"].Visible = false;
            dataGridTournois.Columns["Statut"].Visible = false;
            dataGridTournois.Columns["DureePrevue"].Visible = false;
            dataGridTournois.Columns["Lot"].Visible = false;

            dataGridTournois.Columns["DateHeure"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridTournois.Columns["Nom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridTournois.Columns["DateHeure"].HeaderText = "Début";

            dataGridTournois.Columns["Nom"].DisplayIndex = 1;
        }

        #endregion  

        #region Evènements
        #region Boutons
        /// <summary>
        /// Gère l'événement de clic sur le bouton d'ajout pour créer un nouvel espace à partir des informations saisies
        /// par l'utilisateur.
        /// </summary>
        /// <remarks>Cette méthode valide les champs de saisie avant de créer un nouvel espace. Si la
        /// validation échoue, aucun espace n'est ajouté.</remarks>
        /// <param name="sender">L'objet à l'origine de l'événement, généralement le bouton Ajouter.</param>
        /// <param name="e">Les données d'événement associées au clic du bouton.</param>
        private void ButtonAjouter_Click(object sender, EventArgs e)
        {
            Espace espace = new()
            {
                Nom = textBoxNom.Text,
                Description = textBoxDescription.Text,
                CapaciteMaxi = (int)numericUpDownCapaciteMaxi.Value,
                Superficie = (int)numericUpDownSuperficie.Value,
            };

            try
            {
                _serviceEspace.Creer(espace);
                MessageBox.Show("L'espace a bien été ajouté.", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Raz_Zones();
            }
            catch (EspaceException ex)
            {
                Log.Warning("[{Code}] {Message}", ex.CodeErreur, ex.Message);
                MessageBox.Show(ex.Message);
            }
            catch (DbException ex)
            {
                Log.Error(ex, "Une erreur technique est survenue lors de l'ajout de l'espace.");
                MessageBox.Show("Erreur technique, réessayez plus tard.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Une erreur inattendue est survenue.");
                MessageBox.Show("Une erreur inattendue est survenue.");
            }
        }

        /// <summary>
        /// Gère l'événement de clic sur le bouton de modification pour appliquer les changements apportés à l'espace
        /// sélectionné.
        /// </summary>
        /// <remarks>Cette méthode met à jour les informations de l'espace actuellement sélectionné dans
        /// le tableau, puis recharge la liste des espaces et réinitialise les zones de saisie. Aucun traitement n'est
        /// effectué si aucune ligne n'est sélectionnée ou si aucun espace n'est sélectionné.</remarks>
        /// <param name="sender">L'objet à l'origine de l'événement, généralement le bouton Modifier.</param>
        /// <param name="e">Les données d'événement associées au clic sur le bouton.</param>
        private void ButtonModifier_Click(object sender, EventArgs e)
        {
            // Si aucune ligne n'est sélectionnée, ne rien faire
            if (dataGridEspaces.CurrentRow == null || _espaceSelectionnee == null)
                return;

            _espaceSelectionnee.Nom = textBoxNom.Text;
            _espaceSelectionnee.Description = textBoxDescription.Text;
            _espaceSelectionnee.CapaciteMaxi = (int)numericUpDownCapaciteMaxi.Value;
            _espaceSelectionnee.Superficie = (int)numericUpDownSuperficie.Value;

            try
            {
                _serviceEspace.Modifier(_espaceSelectionnee);
                MessageBox.Show("L'espace a bien été modifié.", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Raz_Zones();
            }
            catch (EspaceException ex)
            {
                Log.Warning("[{Code}] {Message}", ex.CodeErreur, ex.Message);
                MessageBox.Show(ex.Message);
            }
            catch (DbException ex)
            {
                Log.Error(ex, "Une erreur technique est survenue lors de la modification de l'espace.");
                MessageBox.Show("Erreur technique, réessayez plus tard.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Une erreur inattendue est survenue.");
                MessageBox.Show("Une erreur inattendue est survenue.");
            }

        }
        /// <summary>
        /// Gère l'événement de clic sur le bouton Effacer et réinitialise les zones de saisie du formulaire.
        /// </summary>
        /// <param name="sender">L'objet à l'origine de l'événement, généralement le bouton Effacer.</param>
        /// <param name="e">Les données d'événement associées au clic sur le bouton.</param>
        private void ButtonEffacer_Click(object sender, EventArgs e)
        {
            Raz_Zones();
        }

        /// <summary>
        /// Gère l'événement de clic sur le bouton de suppression pour retirer l'espace sélectionné de la liste.
        /// </summary>
        /// <remarks>Cette méthode vérifie qu'une ligne et un espace sont sélectionnés avant de procéder à
        /// la suppression. Après la suppression, la liste des espaces est rechargée et les zones associées sont
        /// réinitialisées.</remarks>
        /// <param name="sender">L'objet source de l'événement, généralement le bouton de suppression.</param>
        /// <param name="e">Les données d'événement associées au clic sur le bouton.</param>
        private void ButtonSupprimer_Click(object sender, EventArgs e)
        {
            // Si aucune ligne n'est sélectionnée, ne rien faire
            if (dataGridEspaces.CurrentRow == null || _espaceSelectionnee == null)
                return;

            if (MessageBox.Show("Êtes vous sûr de vouloir supprimer ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            _serviceEspace.Supprimer(_espaceSelectionnee.IdEspace);
            MessageBox.Show("L'espace a bien été supprimé.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Raz_Zones();
        }
        #endregion 

        private void DataGridEspaces_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Gestion des clics sur l'en-tête (gérés pour le tri)
            if (e.RowIndex < 0)
            {
                // Association des index avec les propriétés de l'objet
                Dictionary<int, string> map = new ()
                {
                    { dataGridEspaces.Columns["Nom"].Index,          "Nom" },
                    { dataGridEspaces.Columns["Description"].Index,  "Description" },
                    { dataGridEspaces.Columns["Superficie"].Index,   "Superficie" },
                    { dataGridEspaces.Columns["CapaciteMaxi"].Index, "CapaciteMaxi" },
                };
                // Si la colonne cliquée n'appartient pas aux propriétés ci-dessus, ne rien faire,
                // sinon récupérer le nom de la propriété associée à la colonne cliquée
                if (!map.TryGetValue(e.ColumnIndex, out string? colonne))
                    return;

                // permutation de l'ordre stocké
                ordreChamp = ordreChamp == "ASC" ? "DESC" : "ASC";

                dataGridEspaces.DataSource = _serviceEspace.Lister(filtre, colonne, ordreChamp);
                dataGridEspaces.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection =
                    ordreChamp == "ASC" ? SortOrder.Ascending : SortOrder.Descending;
                
                MEP_DataGridEspaces();
                return;
            }

            // Ne pas recharger le DataSource lors d'un clic sur une cellule : cela réinitialise la sélection
            _espaceSelectionnee = dataGridEspaces.Rows[e.RowIndex].DataBoundItem as Espace;

            if (_espaceSelectionnee != null)
                RemplirFormulaire();

            AfficherBoutons();
        }

        /// <summary>
        /// Gère l'événement déclenché lorsque le texte de la zone de recherche est modifié.
        /// </summary>
        /// <remarks>Utilisez cet événement pour mettre à jour dynamiquement les résultats de recherche en
        /// fonction de la saisie de l'utilisateur.</remarks>
        /// <param name="sender">L'objet source de l'événement, généralement la zone de texte de recherche.</param>
        /// <param name="e">Les données associées à l'événement de modification du texte.</param>
        private void TextBoxRecherche_TextChanged(object sender, EventArgs e)
        {
            filtre = textBoxRecherche.Text;
            ChargerEspaces();
        }

        #endregion

        #region Méthodes

        /// <summary>
        /// Permet de désactiver les champs de saisie du formulaire si l'utilisateur 
        /// n'a pas les droits nécessaires pour ajouter ou modifier des espaces.
        /// </summary>
        private void DesactiverInputs()
        {
            textBoxNom.Enabled = false;
            textBoxDescription.Enabled = false;
            numericUpDownCapaciteMaxi.Enabled = false;
            numericUpDownSuperficie.Enabled = false;
        }

        /// <summary>
        /// Permet de déterminer d'afficher une indication visuelle sur les tournois associés à l'espace sélectionné, 
        /// en fonction de leur statut (en cours, planifié ou aucun tournoi).
        /// </summary>
        private void StatutTournois()
        {
            if (_espaceSelectionnee == null)
            {
                labelStatutTournoi.Visible = _espaceSelectionnee != null;
                return;
            }

            labelStatutTournoi.Visible = _espaceSelectionnee != null;

            List<Tournoi> enCours = _serviceTournoi.ListerTournoisEnCoursEspace(_espaceSelectionnee.IdEspace);
            List<Tournoi> futurs = _serviceTournoi.ListerTournoisPlanifiesEspace(_espaceSelectionnee.IdEspace);

            if (enCours.Count > 0)
            {
                labelStatutTournoi.Text = "Tournoi en cours";
                labelStatutTournoi.ForeColor = Color.Maroon;
                labelStatutTournoi.BackColor = Color.FromArgb(255, 128, 128);

                ChargerTournois(enCours);
            }
            else
            {
                if (futurs.Count > 0)
                {
                    labelStatutTournoi.Text = futurs.Count > 1
                        ? "Tournois programmés"
                        : "Tournoi programmé";

                    labelStatutTournoi.ForeColor = Color.Chocolate;
                    labelStatutTournoi.BackColor = Color.FromArgb(255, 224, 192);

                    ChargerTournois(futurs);
                }
                // Si il n'y a ni tournoi en cours ni tournoi planifié, alors l'espace est considéré comme libre
                else
                {
                    labelStatutTournoi.Text = "Espace libre";
                    labelStatutTournoi.ForeColor = Color.DarkGreen;
                    labelStatutTournoi.BackColor = Color.FromArgb(192, 255, 192);
                    ChargerTournois(null);
                }
            }
        }

        /// <summary>
        /// Resets all tournament-related input fields and controls to their default values.
        /// </summary>
        /// <remarks>Use this method to clear the current tournament selection and prepare the form for
        /// entering a new tournament. All user input fields are cleared or set to their minimum values, and the status
        /// controls are reset to indicate a planned tournament.</remarks>
        private void Raz_Zones()
        {
            textBoxNom.Clear();
            textBoxDescription.Clear();

            numericUpDownCapaciteMaxi.Value = numericUpDownCapaciteMaxi.Minimum;
            numericUpDownSuperficie.Value = numericUpDownSuperficie.Minimum;

            filtre = "";

            // Réinitialiser la sélection de l'espace
            _espaceSelectionnee = null;

            labelStatutTournoi.Visible = _espaceSelectionnee != null;
            dataGridPostesJeu.Visible = _espaceSelectionnee != null;
            dataGridTournois.Visible = _espaceSelectionnee != null;

            // Recharger les espaces pour réinitialiser la sélection et les statistiques
            ChargerEspaces();

            AfficherBoutons();
        }

        /// <summary>
        /// Remplit les champs du formulaire avec les informations de l'espace spécifié.
        /// </summary>
        /// <remarks>Cette méthode met à jour les contrôles du formulaire pour refléter les propriétés de
        /// l'espace fourni. Elle doit être appelée lors de l'affichage ou de la modification d'un espace
        /// existant.</remarks>
        private void RemplirFormulaire()
        {
            if (_espaceSelectionnee == null)
            {
                MessageBox.Show("Aucun espace sélectionné.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            textBoxNom.Text = _espaceSelectionnee.Nom;
            textBoxDescription.Text = _espaceSelectionnee.Description;
            numericUpDownCapaciteMaxi.Value = _espaceSelectionnee.CapaciteMaxi;
            numericUpDownSuperficie.Value = _espaceSelectionnee.Superficie;

            dataGridPostesJeu.Visible = _espaceSelectionnee != null;
            dataGridTournois.Visible = _espaceSelectionnee != null;

            ChargerPostesJeu();
            StatutTournois();
            AfficherBoutons();
        }

        /// <summary>
        /// Permet d'afficher ou de masquer les boutons d'action en fonction de la sélection actuelle d'un espace.
        /// </summary>
        private void AfficherBoutons()
        {
            buttonAjouter.Enabled = _espaceSelectionnee == null;

            // Si aucun espace n'est sélectionné, les boutons de modification, suppression et effacement sont désactivés
            buttonModifier.Enabled = _espaceSelectionnee != null;
            buttonSupprimer.Enabled = _espaceSelectionnee != null;
            buttonEffacer.Enabled = _espaceSelectionnee != null;
        }

        /// <summary>
        /// Permet de désactiver le tri automatique sur les colonnes d'un DataGridView pour gérer le tri manuellement dans l'événement CellClick.
        /// </summary>
        /// <param name="dataGrid">Le DataGridView dont les colonnes doivent être configurées.</param>
        static void DesactiverTrieAutomatique(DataGridView dataGrid)
        {
            foreach (DataGridViewColumn col in dataGrid.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }
        #endregion
    }
}
