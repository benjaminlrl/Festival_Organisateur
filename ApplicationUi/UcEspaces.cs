using Lib_Entities.Entities;
using Lib_Metier.Data.Configurations;
using Lib_Services.Interfaces;
using Lib_Services.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ApplicationUi
{
    public partial class UcEspaces : UserControl
    {
        private readonly IEspaceService _serviceEspace;
        private readonly IPosteJeuService _servicePosteJeu;
        private Espace? _espaceSelectionee = null;
        public UcEspaces()
        {
            InitializeComponent();
            _serviceEspace = new EspaceService(new ApplicationDbContext());
            _servicePosteJeu = new PosteJeuService(new ApplicationDbContext());
            buttonModifier.Enabled = _espaceSelectionee != null;
            buttonSupprimer.Enabled = _espaceSelectionee != null;
            buttonEffacer.Text = " 🧽  Effacer";
            ChargerEspaces();
        }
        #region Evènements
        private void ChargerEspaces(string filtre = "")
        {
            dataGridEspaces.DataSource = null;
            dataGridEspaces.DataSource = _serviceEspace.Lister(filtre);
            MEP_DataGrid();
        }

        /// <summary>
        /// Charge les postes de jeux de l'espace selectionnee
        /// </summary>
        private void ChargerPostesJeu()
        {
            dataGridPostesJeu.DataSource = null;
            dataGridPostesJeu.DataSource = _espaceSelectionee.PostesJeu.ToList();
            MEP_DataGridPostesJeu();
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
        }
        private void MEP_DataGrid()
        // TODO: Modifier les données de la grille pour afficher les informations du poste de jeu 
        {
            dataGridEspaces.Columns["idEspace"].Visible = false;
            dataGridEspaces.Columns["Tournois"].Visible = false;
            dataGridEspaces.Columns["PostesJeu"].Visible = false;
            dataGridEspaces.Columns["Nom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void MEP_DataGridPostesJeu()
        {
            if (dataGridPostesJeu != null)
                dataGridPostesJeu.Columns["Reference"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void dataGridEspaces_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            List<PosteJeu> postesJeu = new List<PosteJeu>();
            // on ne gère le clic que sur les lignes, pas sur les en-têtes
            if (e.RowIndex < 0)
                return;

            _espaceSelectionee = dataGridEspaces.Rows[e.RowIndex].DataBoundItem as Espace;

            if (_espaceSelectionee != null)
                RemplirFormulaire(_espaceSelectionee);

            buttonModifier.Enabled = _espaceSelectionee != null;
            buttonSupprimer.Enabled = _espaceSelectionee != null;
        }

        private void RemplirFormulaire(Espace espace)
        {
            textBoxNom.Text = espace.Nom;
            textBoxDescription.Text = espace.Description;
            numericUpDownCapaciteMaxi.Value = espace.CapaciteMaxi;
            numericUpDownSuperficie.Value = espace.Superficie;
            ChargerPostesJeu();
        }
        #endregion
        #region Validations
        private bool ValiderEspace()
        {

            if (string.IsNullOrWhiteSpace(textBoxNom.Text))
            {
                MessageBox.Show("Le nom de l'espace est requis.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (numericUpDownCapaciteMaxi.Value <= 0)
            {
                MessageBox.Show("La capacité maximale doit être supérieure à zéro.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (numericUpDownSuperficie.Value <= 0)
            {
                MessageBox.Show("La superficie doit être supérieure à zéro.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (textBoxDescription.Text.Length > 500)
            {
                MessageBox.Show("La description ne peut pas dépasser 500 caractères.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (_espaceSelectionee != null && _serviceEspace.NomExiste(_espaceSelectionee.Nom))
            {
                MessageBox.Show("Un autre espace avec ce nom existe déjà.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        #endregion
        #region Boutons
        public void buttonAjouter_Click(object sender, EventArgs e)
        {
            if (ValiderEspace())
            {
                var espace = new Espace
                {
                    Nom = textBoxNom.Text,
                    Description = textBoxDescription.Text,
                    CapaciteMaxi = (int)numericUpDownCapaciteMaxi.Value,
                    Superficie = (int)numericUpDownSuperficie.Value,
                };
                _serviceEspace.Creer(espace);
                ChargerEspaces();
                Raz_Zones();
            }

        }
        private void buttonModifier_Click(object sender, EventArgs e)
        {
            if (dataGridEspaces.CurrentRow == null)
                return;

            if (_espaceSelectionee == null)
                return;
            var espace = (Espace)dataGridEspaces.CurrentRow.DataBoundItem;

            _espaceSelectionee.Nom = textBoxNom.Text;
            _espaceSelectionee.Description = textBoxDescription.Text;
            _espaceSelectionee.CapaciteMaxi = (int)numericUpDownCapaciteMaxi.Value;
            _espaceSelectionee.Superficie = (int)numericUpDownSuperficie.Value;

            _serviceEspace.Modifier(_espaceSelectionee);
            ChargerEspaces();
            Raz_Zones();
        }
        private void buttonEffacer_Click(object sender, EventArgs e)
        {
            Raz_Zones();
        }
        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            if (dataGridEspaces.CurrentRow == null)
                return;

            if (_espaceSelectionee == null)
                return;
            var espace = (Espace)dataGridEspaces.CurrentRow.DataBoundItem;

            _serviceEspace.Supprimer(_espaceSelectionee.IdEspace);
            _espaceSelectionee = null;
            ChargerEspaces();
            Raz_Zones();

        }

        private void textBoxRecherche_TextChanged(object sender, EventArgs e)
        {
            ChargerEspaces(textBoxRecherche.Text);
        }

        #endregion

        private void buttonPostesJeu_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
