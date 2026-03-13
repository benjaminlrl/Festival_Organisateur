using Lib_Entities.Entities;
using Lib_Metier.Data.Configurations;
using Lib_Services.Interfaces;
using Lib_Services.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ApplicationUi
{
    public partial class UcPostesDeJeu : UserControl
    {
        private readonly ITournoiService _serviceTournoi;
        private readonly IEspaceService _serviceEspace;
        private readonly IPosteJeuService _servicePosteJeu;
        private readonly IPlateformeService _servicePlateforme;
        private bool fonctionnelSelectionne = false;
        private PosteJeu? _posteJeuSelectionne = null;

        public UcPostesDeJeu()
        {
            InitializeComponent();
            _serviceTournoi = new TournoiService(new ApplicationDbContext());
            _serviceEspace = new EspaceService(new ApplicationDbContext());
            _servicePosteJeu = new PosteJeuService(new ApplicationDbContext());
            _servicePlateforme = new PlateformeService(new ApplicationDbContext());
            ChargerPlateformes();
            ChargerEspaces();
            ChargerPostesDeJeu();
            buttonModifier.Enabled = _posteJeuSelectionne != null;
            buttonSupprimer.Enabled = _posteJeuSelectionne != null;
            buttonEffacer.Text = " 🧽  Effacer";
        }
        #region Evènements
        private void ChargerPostesDeJeu()
        {
            dataGridPostesJeu.DataSource = null;
            dataGridPostesJeu.DataSource = _servicePosteJeu.Lister();
            MEP_DataGrid();
        }
        private void ChargerEspaces()
        {
            comboBoxEspace.DataSource = null;
            comboBoxEspace.DataSource = _serviceEspace.Lister();
            // charge les espaces dans le comboBox et affiche le nom tout en conservant l'id en valeur
            comboBoxEspace.DisplayMember = "Nom";
            comboBoxEspace.ValueMember = "IdEspace";
        }

        private void ChargerPlateformes()
        {
            comboBoxPlateforme.DataSource = null;
            comboBoxPlateforme.DataSource = _servicePlateforme.Lister();
            // charge les plateformes dans le comboBox et affiche le libellé tout en conservant l'id en valeur
            comboBoxPlateforme.DisplayMember = "Libelle";
            comboBoxPlateforme.ValueMember = "IdPlateforme";
        }
        /// <summary>
        /// Resets all tournament-related input fields and controls to their default values.
        /// </summary>
        /// <remarks>Use this method to clear the current tournament selection and prepare the form for
        /// entering a new tournament. All user input fields are cleared or set to their minimum values, and the status
        /// controls are reset to indicate a planned tournament.</remarks>
        private void Raz_Zones()
        {
            textBoxReference.Clear();
            comboBoxPlateforme.SelectedItem = null;
            comboBoxEspace.SelectedItem = null;
            _posteJeuSelectionne = null;
            buttonModifier.Enabled = _posteJeuSelectionne != null;
            buttonSupprimer.Enabled = _posteJeuSelectionne != null;
            radioButtonFonctionnelTrue.Checked = false;
            radioButtonFonctionnelFalse.Checked = false;
        }
        private void MEP_DataGrid()
        // TODO: Modifier les données de la grille pour afficher les informations du poste de jeu 
        {
            dataGridPostesJeu.Columns["Espace"].Visible = false;
            dataGridPostesJeu.Columns["Plateforme"].Visible = false;
            dataGridPostesJeu.Columns["NumeroPoste"].Visible = false;
            dataGridPostesJeu.Columns["Reference"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void dataGridPostesJeu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // on ne gère le clic que sur les lignes, pas sur les en-têtes
            if (e.RowIndex < 0)
                return;

            _posteJeuSelectionne = dataGridPostesJeu.Rows[e.RowIndex].DataBoundItem as PosteJeu;

            if (_posteJeuSelectionne != null) 
                RemplirFormulaire(_posteJeuSelectionne);

            buttonModifier.Enabled = _posteJeuSelectionne != null;
            buttonSupprimer.Enabled = _posteJeuSelectionne != null;
        }

        private void RemplirFormulaire(PosteJeu posteJeu)
        {
            textBoxReference.Text = posteJeu.Reference;

            // ComboBox Espace
            comboBoxEspace.SelectedItem = posteJeu.Espace;
            comboBoxEspace.SelectedValue = posteJeu.IdEspace;

            // ComboBox Plateforme
            comboBoxPlateforme.SelectedItem = posteJeu.Plateforme;
            comboBoxPlateforme.SelectedValue = posteJeu.IdPlateforme;

            // Fonctionnel (RadioButtons)
            if (posteJeu.Fonctionnel)
            {
                radioButtonFonctionnelTrue.Checked = true;
            }
            else
            {
                radioButtonFonctionnelFalse.Checked = true;
            }
        }

        private void radioButtonFonctionnelFalse_CheckedChanged(object sender, EventArgs e)
        {
            fonctionnelSelectionne = false;
        }

        private void radioButtonFonctionnelTrue_CheckedChanged(object sender, EventArgs e)
        {
            fonctionnelSelectionne = true;
        }
        #endregion
        #region Validations
        private bool ValiderPosteJeu()
        {
            // valider que la référence n'est pas vide ou composée uniquement d'espaces
            if (string.IsNullOrWhiteSpace(textBoxReference.Text))
            {
                MessageBox.Show("La référence du poste de jeu est obligatoire.",
                    "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                // on efface le contenu pour forcer l'utilisateur à saisir une valeur valide
                textBoxReference.Clear();
                return false;
            }
            else
            {
                // vérifie que la référence saisie n'existe pas déjà pour un autre poste de jeu
                if (_servicePosteJeu.ReferenceExiste(textBoxReference.Text) != null)
                {
                    MessageBox.Show($"Le poste de {textBoxReference.Text} existe déjà",
                        "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // on efface le contenu pour forcer l'utilisateur à saisir une valeur valide
                    textBoxReference.Clear();
                    return false;
                }
            }
            return true;
        }
        #endregion
        #region Boutons
        public void buttonAjouter_Click(object sender, EventArgs e)
        {
            if (ValiderPosteJeu())
            {
                var posteJeu = new PosteJeu
                {
                    Reference = textBoxReference.Text,
                    Fonctionnel = fonctionnelSelectionne,
                    IdPlateforme = ((Plateforme)comboBoxPlateforme.SelectedItem).IdPlateforme,
                    IdEspace = ((Espace)comboBoxEspace.SelectedItem).IdEspace
                };
                _servicePosteJeu.Creer(posteJeu);
                ChargerPostesDeJeu();
                Raz_Zones();
            }

        }
        private void buttonModifier_Click(object sender, EventArgs e)
        {
            if (dataGridPostesJeu.CurrentRow == null)
                return;

            if (_posteJeuSelectionne == null)
                return;
            var posteJeu = (PosteJeu)dataGridPostesJeu.CurrentRow.DataBoundItem;

            _posteJeuSelectionne.Reference = textBoxReference.Text;
            _posteJeuSelectionne.Fonctionnel = fonctionnelSelectionne; // true ou false selon le choix de l'utilisateur
            _posteJeuSelectionne.IdEspace = ((Espace)comboBoxEspace.SelectedItem).IdEspace;
            _posteJeuSelectionne.IdPlateforme = ((Plateforme)comboBoxPlateforme.SelectedItem).IdPlateforme;

            _servicePosteJeu.Modifier(_posteJeuSelectionne);
            ChargerPostesDeJeu();
            Raz_Zones();
        }
        private void buttonEffacer_Click(object sender, EventArgs e)
        {
            Raz_Zones();
        }
        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            if (dataGridPostesJeu.CurrentRow == null)
                return;

            if (_posteJeuSelectionne == null)
                return;
            var posteJeu = (PosteJeu)dataGridPostesJeu.CurrentRow.DataBoundItem;

            _servicePosteJeu.Supprimer(_posteJeuSelectionne.NumeroPoste);
            _posteJeuSelectionne = null;
            ChargerPostesDeJeu();
            Raz_Zones();

        }

        #endregion
    }
}
