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
    public partial class UcPostesDeJeu : UserControl
    {
        private readonly ITournoiService _serviceTournoi;
        private readonly IEspaceService _serviceEspace;
        private readonly IPosteJeuService _servicePosteJeu;
        private bool fonctionnelSelectionne = false;
        private Tournoi? _tournoiSelectionne = null;

        public UcPostesDeJeu()
        {
            InitializeComponent();
            _serviceTournoi = new TournoiService(new ApplicationDbContext());
            _serviceEspace = new EspaceService(new ApplicationDbContext());
            _servicePosteJeu = new PosteJeuService(new ApplicationDbContext());
            buttonModifier.Enabled = _tournoiSelectionne != null;
            buttonSupprimer.Enabled = _tournoiSelectionne != null;
            buttonEffacer.Text = " 🧽  Effacer";
        }

        private void tableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        #region Evènements
        private void ChargerPostesDeJeu()
        {
            dataGridPostesJeu.DataSource = null;
            dataGridPostesJeu.DataSource = _servicePosteJeu.Lister();
            MEP_DataGrid();
        }
        private void MEP_DataGrid()
        // TODO: Modifier les données de la grille pour afficher les informations du poste de jeu 
        {
            dataGridPosteJeu.Columns["NumeroTournoi"].Visible = false;
            dataGridPosteJeu.Columns["IdEspace"].Visible = false;
            dataGridPosteJeu.Columns["Espace"].Visible = false;
            dataGridPosteJeu.Columns["NomEspace"].HeaderText = "Espace";
            dataGridPosteJeu.Columns["Nom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        public void buttonAjouter_Click(object sender, EventArgs e)
        {
            // TODO: Ajouter la validation des champs avant de créer un poste de jeu
            if (ValiderTournoi())
            {
                var posteJeu = new PosteJeu
                {
                    Reference = textBoxReference.Text,
                    Fonctionnel = fonctionnelSelectionne,
                    IdPlateform = ((Plateforme)comboBoxPlateforme.SelectedItem).IdPlateforme,
                    IdEspace = ((Espace)comboBoxEspace.SelectedItem).IdEspace
                };
                _servicePosteJeu.Creer(posteJeu);
                ChargerTournois();
                Raz_Zones();
            }
            // TODO: Ajouter les méthodes manquantes

        }
        #endregion
    }
}
