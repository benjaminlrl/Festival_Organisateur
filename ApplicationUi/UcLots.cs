using Lib_Entities.Entities;
using Lib_Metier.Data.Configurations;
using Lib_Services.Interfaces;
using Lib_Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.Logging;
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
        private LotComposant? _lotComposantSelectionnee = null;
        private LotComposant? _lotComposantDunLotSelectionnee = null;
        private Lot? _lotSelectionnee = null;
        private Lot? unNouveauLot;
        private readonly Organisateur _organisateurConnecte;
        string filtre;
        int? nouveauNumeroTournoi;

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
            buttonSupprimerLot.Enabled = _lotSelectionnee != null;
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcLots, "Ajouter") == false)
            {
                buttonAjouterLot.Visible = false;
            }
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcLots, "Modifier") == false)
            {
                buttonModifier.Visible = false;
            }
            if (_serviceOrganisateur.estAutoriser(_organisateurConnecte, Organisateur.LesUC.UcLots, "Supprimer") == false)
            {
                buttonSupprimerLot.Visible = false;
            }
        }

        #region Chargement
        private void MEP_DataGrid(string unFormulaire)
        {
            // Ici on affiche et modifie l'affichage des colonnes du dataGrid
            if (unFormulaire == "Lots")
            {
                dataGridLots.Columns["Numero"].DisplayIndex = 0;
                dataGridLots.Columns["LotComposant"].Visible = false;
                dataGridLots.Columns["NumeroTournoi"].Visible = false;
            }
            else if (unFormulaire == "LotComposants")
            {
                dataGridLotComposants.Columns["Numero"].DisplayIndex = 0;
                dataGridLotComposants.Columns["Lot"].Visible = false;
                dataGridLotComposants.Columns["NumeroLot"].Visible = false;
                dataGridLotComposants.Columns["Valeur"].Visible = false;
                dataGridLotComposants.Columns["Description"].Visible = false;
            }
            else if (unFormulaire == "LotComposantsDunLot")
            {
                dataGridLotComposants.Columns["Numero"].DisplayIndex = 0;
                dataGridLotComposants.Columns["Lot"].Visible = false;
                dataGridLotComposants.Columns["NumeroLot"].Visible = false;
                dataGridLotComposants.Columns["Valeur"].Visible = false;
                dataGridLotComposants.Columns["Description"].Visible = false;
            }
        }
        private void ChargerLots()
        {
            // On charge la liste des lots dans le dataGrid
            dataGridLots.DataSource = null;
            var listeLots = _serviceLot.Lister(filtre)
                .ToList();
            dataGridLots.DataSource = listeLots;
            MEP_DataGrid("Lots");
        }

        private void ChargerTournoi()
        {
            // On charge les tournois uniquement pour la combobox, pas besoin de les charger dans un dataGrid

            var tournois = _serviceTournoi.Lister("");
            // On ajoute un élément "Aucun" en tête de liste
            comboBoxTournoi.DisplayMember = "Nom";
            comboBoxTournoi.ValueMember = "NumeroTournoi";
            comboBoxTournoi.DataSource = null;

            var liste = new List<Tournoi>();
            liste.Add(new Tournoi { NumeroTournoi = null, Nom = "Aucun" });
            liste.AddRange(tournois);

            comboBoxTournoi.DataSource = liste;
            comboBoxTournoi.SelectedIndex = 0; // sélectionne "Aucun" par défaut


            MEP_DataGrid("Lots");
        }

        private void ChargerLotComposants()
        {
            // On charge les lots composants dans la combobox ainsi que la liste des lots composants dans le dataGrid
            dataGridLotComposants.DataSource = null;
            var listeLotComposants = _serviceLotComposant.Lister(filtre)
                .Where(t => t.NumeroLot == null) // On affiche que les lots composants qui ne sont pas encore associés à un lot
                .ToList();
            dataGridLotComposants.DataSource = listeLotComposants;
            MEP_DataGrid("LotComposants");

            // On charge la liste des lots composants dans le comboBox
            // On ajoute un élément "Aucun" en tête de liste
            comboBoxLotComposant.DisplayMember = "Libelle";
            comboBoxLotComposant.ValueMember = "Numero";
            comboBoxLotComposant.DataSource = null;

            var liste = new List<LotComposant>();
            liste.Add(new LotComposant { Numero = null, Libelle = "Aucun" });
            liste.AddRange(liste);

            comboBoxLotComposant.DataSource = liste;
            comboBoxLotComposant.SelectedIndex = 0; // sélectionne "Aucun" par défaut
        }

        private void ChargerLotComposantsDunLot()
        {
            // On charge les lots composants du lot selectionné dans le dataGrid
            dataGridLotComposants.DataSource = null;
            var listeLotComposantsDunLot = _serviceLotComposant.ListerParNumeroDunLot(_lotSelectionnee.Numero.Value)
                .Where(t => t.NumeroLot != null) // On affiche que les lots composants qui sont associés à un lot
                .ToList();
            comboBoxLotComposant.DataSource = listeLotComposantsDunLot;
            MEP_DataGrid("LotComposantsDunLot");

            // On charge la liste des lots composants dans le comboBox
            // On ajoute un élément "Aucun" en tête de liste
            comboBoxLotComposantDunLot.DisplayMember = "Libelle";
            comboBoxLotComposantDunLot.ValueMember = "Numero";
            comboBoxLotComposantDunLot.DataSource = null;

            var liste = new List<LotComposant>();
            liste.Add(new LotComposant { Numero = null, Libelle = "Aucun" });
            liste.AddRange(liste);

            comboBoxLotComposantDunLot.DataSource = liste;
            comboBoxLotComposantDunLot.SelectedIndex = 0; // sélectionne "Aucun" par défaut
        }


        private void RemplirFormulaireLot(Lot lot)
        {
            // On remplie les champs avec les données du Lot sélectionné
            textBoxLibelle.Text = lot.Libelle;
            textBoxRang.Text = lot.RangAttribution.ToString();
            if (lot.NumeroTournoi == null)
            {
                comboBoxTournoi.SelectedValue = "Aucun";
            }
            else
            {
                comboBoxTournoi.SelectedValue = lot.NumeroTournoi;
            }
        }

        private void RemplirFormulaireLotComposant(LotComposant lotComposant)
        {
            // On remplie la combobox avec les données du Lot Composant sélectionné
            comboBoxLotComposant.SelectedValue = lotComposant.Numero;
        }

        private void RemplirFormulaireLotComposantDunLot(LotComposant lotComposant)
        {
            // On remplie la combobox avec les données du Lot Composant sélectionné
            comboBoxLotComposantDunLot.SelectedValue = lotComposant.Numero;
        }

        private void Raz_Zones()
        {
            // On remet tous les champs à vide
            textBoxLibelle.Clear();
            textBoxRang.Clear();
            comboBoxTournoi.SelectedItem = null;
            //comboBoxLotComposant.SelectedItem = null;
            //comboBoxLotComposantDunLot.SelectedItem = null;
            _lotSelectionnee = null;
            //_lotComposantSelectionnee = null;
            //_lotComposantDunLotSelectionnee = null;
            buttonModifier.Enabled = _lotSelectionnee != null;
            buttonSupprimerLot.Enabled = _lotSelectionnee != null;
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

        private void buttonAjouterLotComposant_Click(object sender, EventArgs e)
        {
            if (_lotSelectionnee == null)
            {
                MessageBox.Show("Aucun Lot sélectionné.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_lotComposantSelectionnee == null)
            {
                MessageBox.Show("Aucun Lot Composant sélectionné.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_lotComposantSelectionnee.NumeroLot == _lotSelectionnee.Numero.Value)
            {
                MessageBox.Show("Le Lot selectionné contient déjà ce composant.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _lotComposantSelectionnee.NumeroLot = _lotSelectionnee.Numero.Value;
            _serviceLotComposant.Modifier(_lotComposantSelectionnee);
            ChargerLotComposants();
            ChargerLotComposantsDunLot();
            // On enlève juste le lot composant selectionné
            comboBoxLotComposant.SelectedItem = null;
            _lotComposantSelectionnee = null;
        }
        private void buttonAjouterLot_Click(object sender, EventArgs e)
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
        private void buttonSupprimerLotComposant_Click(object sender, EventArgs e)
        {
            if (_lotSelectionnee == null)
            {
                MessageBox.Show("Aucun Lot sélectionné.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_lotComposantDunLotSelectionnee == null)
            {
                MessageBox.Show("Aucun Lot Composant sélectionné.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_lotComposantDunLotSelectionnee.NumeroLot != _lotSelectionnee.Numero.Value)
            {
                MessageBox.Show("Le Lot selectionné ne contient pas ce composant.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _lotComposantDunLotSelectionnee.NumeroLot = null;
            _serviceLotComposant.Modifier(_lotComposantDunLotSelectionnee);
            ChargerLotComposants();
            ChargerLotComposantsDunLot();
            // On enlève juste le lot composant selectionné
            comboBoxLotComposant.SelectedItem = null;
            _lotComposantDunLotSelectionnee = null;
        }
        private void buttonSupprimerLot_Click(object sender, EventArgs e)
        {
            // On check si un orgnisateur est sélectionné, puis on le supprime
            // Ne pas pouvoir suppr si aucun lot composant n'est sélectionné
            if (_lotSelectionnee == null)
            {
                MessageBox.Show("Aucun Lot sélectionné.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _serviceLot.Supprimer(_lotSelectionnee.Numero.Value);
            ChargerLots();
            Raz_Zones();
        }
        private void buttonModifier_Click(object sender, EventArgs e)
        {
            // On check s'il a bien selectionné un lot composant à modifier
            if (_lotSelectionnee == null)
            {
                MessageBox.Show("Aucun Lot sélectionné.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            // Gestion du tournoi nullable
            nouveauNumeroTournoi = comboBoxTournoi.SelectedValue is int valLot ? valLot : (int?)null; //ternaire qui met à null si "Aucun" est sélectionné
            if (nouveauNumeroTournoi != _lotSelectionnee.NumeroTournoi)
                _lotSelectionnee.NumeroTournoi = nouveauNumeroTournoi;

            _serviceLot.Modifier(_lotSelectionnee);
            ChargerLots();
            Raz_Zones();
        }
        private void buttonEffacer_Click(object sender, EventArgs e)
        {
            Raz_Zones();
        }

        private void dataGridLots_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // On récupére le lot composant cliqué et on appelle RemplirFormulaireLot(...)
            if (e.RowIndex < 0)
                return;

            _lotSelectionnee = dataGridLots.Rows[e.RowIndex].DataBoundItem as Lot;

            if (_lotSelectionnee != null)
            {
                RemplirFormulaireLot(_lotSelectionnee);
                ChargerLotComposantsDunLot();
                ChargerLotComposants();
            }

            buttonModifier.Enabled = _lotSelectionnee != null;
            buttonSupprimerLot.Enabled = _lotSelectionnee != null;
        }
        private void dataGridLotComposants_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // On récupére le lot composant cliqué et on appelle RemplirFormulaireLotComposant(...)
            if (e.RowIndex < 0)
                return;

            _lotComposantSelectionnee = dataGridLotComposants.Rows[e.RowIndex].DataBoundItem as LotComposant;

            if (_lotComposantSelectionnee != null)
                RemplirFormulaireLotComposant(_lotComposantSelectionnee);
        }

        private void dataGridLotComposantsDunLot_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // On récupére le lot composant cliqué et on appelle RemplirFormulaireLotComposant(...)
            if (e.RowIndex < 0)
                return;

            _lotComposantDunLotSelectionnee = dataGridLotComposants.Rows[e.RowIndex].DataBoundItem as LotComposant;

            if (_lotComposantDunLotSelectionnee != null)
                RemplirFormulaireLotComposantDunLot(_lotComposantDunLotSelectionnee);
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