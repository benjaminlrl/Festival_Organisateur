using Lib_Entities.Entities;
using Lib_Metier.Data.Configurations;
using Lib_Services.Interfaces;
using Lib_Services.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ApplicationUi
{
    public partial class UcLots : UserControl
    {
        private readonly IOrganisateurService _serviceOrganisateur;
        private readonly ITournoiService _serviceTournoi;
        private readonly ILotService _serviceLot;
        private readonly ILotComposantService _serviceLotComposant;
        private Lot? _lotSelectionnee = null;
        private Lot? unNouveauLot;
        private readonly Organisateur _organisateurConnecte;
        string filtre;

        public UcLots(Organisateur unOrganisateurConnecte)
        {
            InitializeComponent();
            _serviceOrganisateur = new OrganisateurService(new ApplicationDbContext());
            _serviceTournoi = new TournoiService(new ApplicationDbContext());
            _serviceLot = new LotService(new ApplicationDbContext());
            _serviceLotComposant = new LotComposantService(new ApplicationDbContext());
            _organisateurConnecte = unOrganisateurConnecte;
            filtre = "";
            ChargerLots();
            ChargerTournoi();
            buttonModifier.Enabled = _lotSelectionnee != null;
            buttonSupprimer.Enabled = _lotSelectionnee != null;
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcLots, "Ajouter") == false)
            {
                buttonAjouter.Visible = false;
            }
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcLots, "Modifier") == false)
            {
                buttonModifier.Visible = false;
            }
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcLots, "Supprimer") == false)
            {
                buttonSupprimer.Visible = false;
            }
        }

        #region Chargement

        private void ChargerLots()
        {
            // On charge la liste des lots composants dans le dataGrid
            dataGridLots.DataSource = null;
            var listeLots = _serviceLot.Lister(filtre)
                .ToList();
            dataGridLots.DataSource = listeLots;
            MEP_DataGrid();
        }

        private void MEP_DataGrid()
        {
            // On affiche et modifie l'affichage des colonnes du dataGrid
            dataGridLots.Columns["Numero"].DisplayIndex = 0;
            dataGridLots.Columns["LotComposant"].Visible = false;
            dataGridLots.Columns["NumeroTournoi"].Visible = false;
            // EstAttribuer faire la coche comme dans espaces
        }

        private void ChargerTournoi()
        {
            // On charge les lots dans la comboBox
            comboBoxTournoi.DataSource = null;
            comboBoxTournoi.DisplayMember = "Libelle";
            comboBoxTournoi.ValueMember = "NumeroTournoi";
            comboBoxTournoi.DataSource = _serviceTournoi.Lister(filtre);
        }

        private void Raz_Zones()
        {
            // On remet tous les champs à vide
            textBoxLibelle.Clear();
            textBoxRang.Clear();
            comboBoxTournoi.SelectedItem = null;
            _lotSelectionnee = null;
            buttonModifier.Enabled = _lotSelectionnee != null;
            buttonSupprimer.Enabled = _lotSelectionnee != null;
        }

        private void RemplirFormulaire(Lot lot)
        {
            // On remplie les champs avec les données de l'organisateur sélectionné
            textBoxLibelle.Text = lot.Libelle;
            textBoxRang.Text = lot.ValeurTotale.ToString();
            if(lot.NumeroTournoi == null)
            {
                comboBoxTournoi.SelectedValue = "Aucun";
            }
            else
            {
                comboBoxTournoi.SelectedValue = lot.NumeroTournoi;
            }
        }

        #endregion

        #region Validations
        /// <summary>
        /// Permet de voir si un lot est conformes aux règles de sécurité suivantes 
        /// </summary>
        /// <param name="lot">Instance de <see cref="Lot"/> à créer.</param>>
        /// <returns>true si tout est respectés, sinon false.</returns>
        public bool LotValide(Lot lot)
        {
            var erreurs = _serviceLot.LotValide(lot);
            if (erreurs.Any())
            {
                MessageBox.Show(string.Join("\n", erreurs), "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        #endregion

        #region Evènements

        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            // On crée un nouveau lot composant avec les données des champs
            unNouveauLot = new Lot
            {
                Libelle = textBoxLibelle.Text,
                RangAttribution = int.Parse(textBoxRang.Text),
                ValeurTotale = 0,
                NumeroTournoi = comboBoxTournoi.SelectedValue != null ? (int)comboBoxTournoi.SelectedValue : null
            };

            // On check si le lot composant est valide
            if (LotValide(unNouveauLot) == false)
            {
                return;
            }
            
            // On crée le lot composant en bdd
            _serviceLot.Creer(unNouveauLot);
            ChargerLots();
            Raz_Zones();
        }

        private void buttonModifier_Click(object sender, EventArgs e)
        {
            // On check s'il a bien selectionné un lot composant à modifier
            if (_lotSelectionnee == null)
            {
                MessageBox.Show("Aucun Lot Composant sélectionné.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // On check si le lot composant est valide
            if (LotValide(_lotSelectionnee) == false)
            {
                return;
            }

            // Modifiée seulement les valeurs qui ont été modifiées
            if (textBoxLibelle.Text != "" || _lotSelectionnee.Libelle != textBoxLibelle.Text)
                _lotSelectionnee.Libelle = textBoxLibelle.Text;
            if (textBoxRang.Text.ToString() != "" || _lotSelectionnee.RangAttribution != int.Parse(textBoxRang.Text))
                _lotSelectionnee.RangAttribution = int.Parse(textBoxRang.Text);
            if ((int)comboBoxTournoi.SelectedValue != _lotSelectionnee.NumeroTournoi)
                _lotSelectionnee.NumeroTournoi = (int)comboBoxTournoi.SelectedValue;

            _serviceLot.Modifier(_lotSelectionnee);
            ChargerLots();
            Raz_Zones();
        }

        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            // On check si un orgnisateur est sélectionné, puis on le supprime
            // Ne pas pouvoir suppr si aucun lot composant n'est sélectionné
            if (_lotSelectionnee == null)
            {
                MessageBox.Show("Aucun Lot sélectionné.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _serviceLotComposant.Supprimer(_lotSelectionnee.Numero);
            ChargerLots();
            Raz_Zones();
        }

        private void buttonEffacer_Click(object sender, EventArgs e)
        {
            Raz_Zones();
        }

        private void dataGridLotComposants_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // On récupére le lot composant cliqué et on appelle RemplirFormulaire(...)
            if (e.RowIndex < 0)
                return;

            _lotSelectionnee = dataGridLots.Rows[e.RowIndex].DataBoundItem as Lot;

            if (_lotSelectionnee != null)
                RemplirFormulaire(_lotSelectionnee);

            buttonModifier.Enabled = _lotSelectionnee != null;
            buttonSupprimer.Enabled = _lotSelectionnee != null;
        }

        /// <summary>
        /// Gère l'événement déclenché lorsque le texte de la zone de recherche est modifié.
        /// </summary>
        /// <remarks>Utilisez cet événement pour mettre à jour dynamiquement les résultats de recherche en
        /// fonction de la saisie de l'utilisateur.</remarks>
        /// <param name="sender">L'objet source de l'événement, généralement la zone de texte de recherche.</param>
        /// <param name="e">Les données associées à l'événement de modification du texte.</param>
        private void textBoxRecherche_TextChanged(object sender, EventArgs e)
        {
            filtre = textBoxRecherche.Text;
            ChargerLots();
        }

        #endregion
    }
}