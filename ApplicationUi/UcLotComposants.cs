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
    public partial class UcLotComposants : UserControl
    {
        private readonly IOrganisateurService _serviceOrganisateur;
        private readonly ILotService _serviceLot;
        private readonly ILotComposantService _serviceLotComposant;
        private LotComposant? _lotComposantSelectionne = null;
        private LotComposant? unNouveauLotComposant;
        private readonly Organisateur _organisateurConnecte;
        string filtre;

        public UcLotComposants(Organisateur unOrganisateurConnecte)
        {
            InitializeComponent();
            _serviceOrganisateur = new OrganisateurService(new ApplicationDbContext());
            _serviceLot = new LotService(new ApplicationDbContext());
            _serviceLotComposant = new LotComposantService(new ApplicationDbContext());
            _organisateurConnecte = unOrganisateurConnecte;
            filtre = "";
            ChargerLotComposants();
            ChargerLots();
            buttonModifier.Enabled = _lotComposantSelectionne != null;
            buttonSupprimer.Enabled = _lotComposantSelectionne != null;
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcLotComposants, "Ajouter") == false)
            {
                buttonAjouter.Visible = false;
            }
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcLotComposants, "Modifier") == false)
            {
                buttonModifier.Visible = false;
            }
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcLotComposants, "Supprimer") == false)
            {
                buttonSupprimer.Visible = false;
            }
        }

        #region Chargement

        private void ChargerLotComposants()
        {
            // On charge la liste des lots composants dans le dataGrid
            dataGridLotComposants.DataSource = null;
            var listeLotComposants = _serviceLotComposant.Lister(filtre)
                .ToList();
            dataGridLotComposants.DataSource = listeLotComposants;
            MEP_DataGrid();
        }

        private void MEP_DataGrid()
        {
            // On affiche et modifie l'affichage des colonnes du dataGrid
            dataGridLotComposants.Columns["Numero"].DisplayIndex = 0;
            dataGridLotComposants.Columns["Lot"].Visible = false;
        }

        private void ChargerLots()
        {
            // On charge les lots dans la comboBox
            comboBoxLot.DataSource = null;
            comboBoxLot.DisplayMember = "Libelle";
            comboBoxLot.ValueMember = "NumeroLot";
            comboBoxLot.DataSource = _serviceLot.Lister(filtre);
        }

        private void Raz_Zones()
        {
            // On remet tous les champs à vide
            textBoxLibelle.Clear();
            textBoxDescription.Clear();
            textBoxValeur.Clear();
            comboBoxLot.SelectedItem = null;
            _lotComposantSelectionne = null;
            buttonModifier.Enabled = _lotComposantSelectionne != null;
            buttonSupprimer.Enabled = _lotComposantSelectionne != null;
        }

        private void RemplirFormulaire(LotComposant lotComposant)
        {
            // On remplie les champs avec les données de l'organisateur sélectionné
            textBoxLibelle.Text = lotComposant.Libelle;
            textBoxDescription.Text = lotComposant.Valeur.ToString();
            textBoxValeur.Clear();
            if(lotComposant.NumeroLot == null)
            {
                comboBoxLot.SelectedValue = "Aucun";
            }
            else
            {
                comboBoxLot.SelectedValue = lotComposant.NumeroLot;
            }
        }

        #endregion

        #region Validations
        /// <summary>
        /// Permet de voir si un lot composant est conformes aux règles de sécurité suivantes 
        /// </summary>
        /// <param name="lotComposant">Instance de <see cref="LotComposant"/> à créer.</param>>
        /// <returns>true si tout est respectés, sinon false.</returns>
        public bool LotComposantValide(LotComposant lotComposant)
        {
            var erreurs = _serviceLotComposant.LotComposantValide(lotComposant);
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
            unNouveauLotComposant = new LotComposant
            {
                Libelle = textBoxLibelle.Text,
                Description = textBoxDescription.Text,
                Valeur = int.Parse(textBoxValeur.Text),
                NumeroLot = comboBoxLot.SelectedValue != null ? (int)comboBoxLot.SelectedValue : null
            };

            // On check si le lot composant est valide
            if (LotComposantValide(unNouveauLotComposant) == false)
            {
                return;
            }
            
            // On crée le lot composant en bdd
            _serviceLotComposant.Creer(unNouveauLotComposant);
            ChargerLotComposants();
            Raz_Zones();
        }

        private void buttonModifier_Click(object sender, EventArgs e)
        {
            // On check s'il a bien selectionné un lot composant à modifier
            if (_lotComposantSelectionne == null)
            {
                MessageBox.Show("Aucun Lot Composant sélectionné.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // On check si le lot composant est valide
            if (LotComposantValide(_lotComposantSelectionne) == false)
            {
                return;
            }

            // Modifiée seulement les valeurs qui ont été modifiées
            if (textBoxLibelle.Text != "" || _lotComposantSelectionne.Libelle != textBoxLibelle.Text)
                _lotComposantSelectionne.Libelle = textBoxLibelle.Text;
            if (textBoxDescription.Text != "" || _lotComposantSelectionne.Description != textBoxDescription.Text)
                _lotComposantSelectionne.Description = textBoxDescription.Text;
            if (textBoxValeur.Text.ToString() != "" || _lotComposantSelectionne.Valeur != int.Parse(textBoxValeur.Text))
                _lotComposantSelectionne.Valeur = int.Parse(textBoxValeur.Text);
            if ((int)comboBoxLot.SelectedValue != _lotComposantSelectionne.NumeroLot)
                _lotComposantSelectionne.NumeroLot = (int)comboBoxLot.SelectedValue;

            _serviceLotComposant.Modifier(_lotComposantSelectionne);
            ChargerLotComposants();
            Raz_Zones();
        }

        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            // On check si un orgnisateur est sélectionné, puis on le supprime
            // Ne pas pouvoir suppr si aucun lot composant n'est sélectionné
            if (_lotComposantSelectionne == null)
            {
                MessageBox.Show("Aucun Lot Composant sélectionné.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _serviceLotComposant.Supprimer(_lotComposantSelectionne.Numero);
            ChargerLotComposants();
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

            _lotComposantSelectionne = dataGridLotComposants.Rows[e.RowIndex].DataBoundItem as LotComposant;

            if (_lotComposantSelectionne != null)
                RemplirFormulaire(_lotComposantSelectionne);

            buttonModifier.Enabled = _lotComposantSelectionne != null;
            buttonSupprimer.Enabled = _lotComposantSelectionne != null;
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
            ChargerLotComposants();
        }

        #endregion
    }
}