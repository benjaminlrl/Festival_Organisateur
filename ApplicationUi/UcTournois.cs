using Lib_Entities.Entities;
using Lib_Metier.Data.Configurations;
using Lib_Services.Interfaces;
using Lib_Services.Services;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace ApplicationUi
{
    public partial class UcTournois : UserControl
    {
        private readonly ITournoiService _serviceTournoi;
        private readonly IEspaceService _serviceEspace;
        private readonly IOrganisateurService _serviceOrganisateur;
        private String statutSelectionne = "Planifié";
        private Tournoi? _tournoiSelectionne = null;
        private string filtre;
        private string ordreChamp;
        private readonly Organisateur _organisateurConnecte;


        public UcTournois(Organisateur unOrganisateurConnecte)
        {
            InitializeComponent();
            var context = new ApplicationDbContext();
            _serviceOrganisateur = new OrganisateurService(context);
            _serviceTournoi = new TournoiService(context);
            _serviceEspace = new EspaceService(context);
            ChargerTournois();
            ChargerEspaces();
            buttonModifier.Enabled = _tournoiSelectionne != null;
            buttonSupprimer.Enabled = _tournoiSelectionne != null;
            _organisateurConnecte = unOrganisateurConnecte;
            buttonEffacer.Text = " 🧽  Effacer";
            filtre = "";
            ordreChamp = "ASC";
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcTournois, "Ajouter") == false)
            {
                buttonAjouter.Visible = false;
            }
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcTournois, "Modifier") == false)
            {
                buttonModifier.Visible = false;
            }
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcTournois, "Supprimer") == false)
            {
                buttonSupprimer.Visible = false;
            }
        }

        #region Chargements
        private void ChargerTournois()
        {
            dataGridTournois.DataSource = null;
            dataGridTournois.DataSource = _serviceTournoi.Lister(filtre);
            MEP_DataGrid();
        }
        private void MEP_DataGrid()
        {
            dataGridTournois.Columns["NumeroTournoi"].Visible = false;
            dataGridTournois.Columns["IdEspace"].Visible = false;
            dataGridTournois.Columns["Espace"].Visible = false;
            dataGridTournois.Columns["NomEspace"].HeaderText = "Espace";
            dataGridTournois.Columns["Nom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
        private void ChargerEspaces()
        {
            comboBoxEspace.DataSource = null;
            comboBoxEspace.DataSource = _serviceEspace.Lister("");
            comboBoxEspace.DisplayMember = "Nom";
            comboBoxEspace.ValueMember = "IdEspace";
        }
        private void Raz_Zones()
        {
            comboBoxEspace.SelectedItem = null;
            textBoxNom.Clear();
            dateTimePickerDateTournoi.Value = dateTimePickerDateTournoi.MinDate;
            numericUpDownNbParticip.Value = numericUpDownNbParticip.Minimum;
            numericUpDownDuree.Value = numericUpDownDuree.Minimum;
            _tournoiSelectionne = null;
            buttonModifier.Enabled = _tournoiSelectionne != null;
            buttonSupprimer.Enabled = _tournoiSelectionne != null;
            radioButtonEnCours.Checked = false;
            radioButtonPlanifié.Checked = true;
            radioButtonTermine.Checked = false;
        }
        private void RemplirFormulaire(Tournoi tournoi)
        {
            textBoxNom.Text = tournoi.Nom;
            dateTimePickerDateTournoi.Value = tournoi.DateHeure;
            numericUpDownNbParticip.Value = tournoi.NbParticipants;
            numericUpDownDuree.Value = tournoi.DureePrevue;

            // ComboBox Espace
            comboBoxEspace.SelectedItem = tournoi.Espace;
            comboBoxEspace.SelectedValue = tournoi.IdEspace;

            // Statut (RadioButtons)
            radioButtonPlanifié.Checked = tournoi.Statut == "Planifié";
            radioButtonEnCours.Checked = tournoi.Statut == "En cours";
            radioButtonTermine.Checked = tournoi.Statut == "Terminé";
        }

        #endregion

        #region Evènements
        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            if (ValiderTournoi())
            {
                var tournoi = new Tournoi
                {
                    Nom = textBoxNom.Text,
                    DateHeure = dateTimePickerDateTournoi.Value,
                    NbParticipants = (int)numericUpDownNbParticip.Value,
                    DureePrevue = (int)numericUpDownDuree.Value,
                    Statut = statutSelectionne,
                    IdEspace = ((Espace)comboBoxEspace.SelectedItem).IdEspace
                };
                _serviceTournoi.Creer(tournoi);
                ChargerTournois();
                Raz_Zones();
            }
        }
        private void buttonModifier_Click(object sender, EventArgs e)
        {
            if (dataGridTournois.CurrentRow == null)
                return;

            if (_tournoiSelectionne == null)
                return;
            //var tournoi = (Tournoi)dataGridTournois.CurrentRow.DataBoundItem;

            _tournoiSelectionne.Nom = textBoxNom.Text;
            _tournoiSelectionne.DateHeure = dateTimePickerDateTournoi.Value;
            _tournoiSelectionne.NbParticipants = (int)numericUpDownNbParticip.Value;
            _tournoiSelectionne.DureePrevue = (int)numericUpDownDuree.Value;
            _tournoiSelectionne.Statut = statutSelectionne;
            _tournoiSelectionne.IdEspace = ((Espace)comboBoxEspace.SelectedItem).IdEspace;

            _serviceTournoi.Modifier(_tournoiSelectionne);
            ChargerTournois();
            Raz_Zones();
        }
        private void buttonEffacer_Click(object sender, EventArgs e)
        {
            Raz_Zones();
        }
        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            if (dataGridTournois.CurrentRow == null)
                return;

            if (_tournoiSelectionne == null)
                return;
            //var tournoi = (Tournoi)dataGridTournois.CurrentRow.DataBoundItem;

            _serviceTournoi.Supprimer(_tournoiSelectionne.NumeroTournoi);
            _tournoiSelectionne = null;
            ChargerTournois();
            Raz_Zones();
        }
        private void radioButtonPlanifié_CheckedChanged(object sender, EventArgs e)
        {
            statutSelectionne = "Planifié";
        }
        private void radioButtonEnCours_CheckedChanged(object sender, EventArgs e)
        {
            statutSelectionne = "En cours";
        }
        private void radioButtonTermine_CheckedChanged(object sender, EventArgs e)
        {
            statutSelectionne = "Terminé";
        }
        private void dataGridTournois_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignorer les clics sur l'en-tête (gérés pour le tri)
            if (e.RowIndex < 0)
            {   // ordonner sur les champs descriptions, superficie, capaciteMaxi
                var donnees = _serviceTournoi.Lister(filtre);
                
                // Utiliser un dictionnaire
                var map = new Dictionary<int, Func<Tournoi, object>>
                {
                    {dataGridTournois.Columns["DateHeure"].Index, t => t.DateHeure},
                    {dataGridTournois.Columns["NbParticipants"].Index, t => t.NbParticipants},
                    {dataGridTournois.Columns["DureePrevue"].Index, t => t.DureePrevue},
                    {dataGridTournois.Columns["Nom"].Index, t => t.Nom},
                    {dataGridTournois.Columns["Statut"].Index, t => t.Statut}
                };

                if (!map.TryGetValue(e.ColumnIndex, out var keySelector))
                    return;

                dataGridTournois.DataSource = ordreChamp == "ASC"
                    ? donnees.OrderByDescending(keySelector).ToList()
                    : donnees.OrderBy(keySelector).ToList();

                ordreChamp = ordreChamp == "ASC" ? "DESC" : "ASC";

                MEP_DataGrid();
                return;
            }

            // Ne pas recharger le DataSource lors d'un clic sur une cellule : cela réinitialise la sélection
            _tournoiSelectionne = dataGridTournois.Rows[e.RowIndex].DataBoundItem as Tournoi;

            if (_tournoiSelectionne != null)
                RemplirFormulaire(_tournoiSelectionne);

            buttonModifier.Enabled = _tournoiSelectionne != null;
            buttonSupprimer.Enabled = _tournoiSelectionne != null;
        }

        #endregion

        #region Validations
        private bool ValiderHoraire(DateTime dateHeure)
        {
            var jour = dateHeure.DayOfWeek; // Lundi, Mardi...
            TimeSpan horaire = dateHeure.TimeOfDay;

            // Horaires variables selon le jour
            if (jour == DayOfWeek.Saturday)
            {
                if (horaire < TimeSpan.FromHours(10) || horaire > TimeSpan.FromHours(20))
                    return false;
            }
            else if (jour == DayOfWeek.Sunday)
            {
                if (horaire < TimeSpan.FromHours(10) || horaire > TimeSpan.FromHours(18))
                    return false;
            }

            return true;
        }
        private bool ValiderTournoi()
        {
            DateTime dateHeureChoisie = dateTimePickerDateTournoi.Value;
            bool retour = true;
            if (!ValiderHoraire(dateHeureChoisie))
            {
                MessageBox.Show("Horaire invalide pour le jour sélectionné !");
                retour = false;
            }
            return retour;
        }

        #endregion

        /// <summary>
        /// Permet de filtrer la liste des tournois affichés en fonction du texte saisi dans la zone de recherche.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxRecherche_TextChanged(object sender, EventArgs e)
        {
            filtre = textBoxRecherche.Text;
            ChargerTournois();
        }
    }
}

