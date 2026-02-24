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
        private Espace? _espaceSelectionee = null;
        public UcEspaces()
        {
            InitializeComponent();
            _serviceEspace = new EspaceService(new ApplicationDbContext());
            buttonModifier.Enabled = _espaceSelectionee != null;
            buttonSupprimer.Enabled = _espaceSelectionee != null;
            buttonEffacer.Text = " 🧽  Effacer";
            ChargerEspaces();
        }
        #region Evènements
        private void ChargerEspaces()
        {
            dataGridEspaces.DataSource = null;
            dataGridEspaces.DataSource = _serviceEspace.Lister();
            MEP_DataGrid();
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
            dataGridEspaces.Columns["Nom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void dataGridEspaces_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
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
        }
        #endregion
        #region Validations
        private bool ValiderEspace()
        {
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

        #endregion
    }
}
