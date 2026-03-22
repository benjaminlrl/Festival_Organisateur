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
    public partial class UcPlateformes : UserControl
    {
        private readonly IPlateformeService _servicePlateforme;
        private readonly IEspaceService _serviceEspace;
        private Plateforme? _plateformeSelectionee = null;
        private string filtre;
        public UcPlateformes()
        {
            InitializeComponent();
            _servicePlateforme = new PlateformeService(new ApplicationDbContext());
            buttonModifier.Enabled = _plateformeSelectionee != null;
            buttonSupprimer.Enabled = _plateformeSelectionee != null;
            filtre = "";
            buttonEffacer.Text = " 🧽  Effacer";
            ChargerPlateformes();
        }
        #region Evènements
        private void ChargerPlateformes()
        {
            dataGridPlateformes.DataSource = null;
            dataGridPlateformes.DataSource = _servicePlateforme.Lister(filtre);
            MEP_DataGrid();
        }

        private void ChargerPostesJeu()
        {
            dataGridPostesJeu.DataSource = null;
            dataGridPostesJeu.DataSource = _plateformeSelectionee.PostesJeu.ToList();
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
        }
        private void MEP_DataGrid()
        // TODO: Modifier les données de la grille pour afficher les informations du poste de jeu 
        {
            dataGridPlateformes.Columns["idPlateforme"].Visible = false;
            dataGridPlateformes.Columns["Libelle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void dataGridPlateformes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // on ne gère le clic que sur les lignes, pas sur les en-têtes
            if (e.RowIndex < 0)
                return;

            _plateformeSelectionee = dataGridPlateformes.Rows[e.RowIndex].DataBoundItem as Plateforme;

            if (_plateformeSelectionee != null)
                RemplirFormulaire(_plateformeSelectionee);

            buttonModifier.Enabled = _plateformeSelectionee != null;
            buttonSupprimer.Enabled = _plateformeSelectionee != null;
        }

        private void RemplirFormulaire(Plateforme plateforme)
        {
            textBoxNom.Text = plateforme.Libelle;
            ChargerPostesJeu();
        }
        #endregion
        #region Validations
        private bool ValiderPLateforme()
        {
            return true;
        }
        #endregion
        #region Boutons
        public void buttonAjouter_Click(object sender, EventArgs e)
        {
            if (ValiderPLateforme())
            {
                var plateforme = new Plateforme
                {
                    Libelle = textBoxNom.Text
                };
                _servicePlateforme.Creer(plateforme);
                ChargerPlateformes();
                Raz_Zones();
            }

        }
        private void buttonModifier_Click(object sender, EventArgs e)
        {
            if (dataGridPlateformes.CurrentRow == null)
                return;

            if (_plateformeSelectionee == null)
                return;
            var plateforme = (Plateforme)dataGridPlateformes.CurrentRow.DataBoundItem;

            _plateformeSelectionee.Libelle = textBoxNom.Text;

            _servicePlateforme.Modifier(_plateformeSelectionee);
            ChargerPlateformes();
            Raz_Zones();
        }
        private void buttonEffacer_Click(object sender, EventArgs e)
        {
            Raz_Zones();
        }
        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            if (dataGridPlateformes.CurrentRow == null)
                return;

            if (_plateformeSelectionee == null)
                return;
            var posteJeu = (PosteJeu)dataGridPlateformes.CurrentRow.DataBoundItem;

            _servicePlateforme.Supprimer(_plateformeSelectionee.IdPlateforme);
            _plateformeSelectionee = null;
            ChargerPlateformes();
            Raz_Zones();

        }
        #endregion
    }
}
