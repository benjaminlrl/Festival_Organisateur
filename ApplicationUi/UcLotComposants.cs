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
        private List<Lot>? listeLots;
        int? nouveauNumeroLot;
        string filtre;
        string ordreChamp = "ASC";
        Lot? lotActuelle;
        Lot? lotAncien;

        public UcLotComposants(Organisateur unOrganisateurConnecte)
        {
            InitializeComponent();
            _serviceOrganisateur = new OrganisateurService(new ApplicationDbContext());
            _serviceLot = new LotService(new ApplicationDbContext());
            _serviceLotComposant = new LotComposantService(new ApplicationDbContext());
            listeLots = new List<Lot>();
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

        /// <summary>
        /// Met en page le DataGrid des lots composants en configurant la visibilité
        /// et le redimensionnement automatique des colonnes.
        /// </summary>
        private void MEP_DataGridLotComposants()
        {
            // On affiche et modifie l'affichage des colonnes du dataGrid
            DesactiverTrieAutomatique(dataGridLotComposants);

            dataGridLotComposants.Columns["Numero"].DisplayIndex = 0;
            dataGridLotComposants.Columns["Lot"].Visible = false;
            dataGridLotComposants.Columns["NumeroLot"].Visible = false;
            dataGridLotComposants.Columns["Numero"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridLotComposants.Columns["Libelle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridLotComposants.Columns["Valeur"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridLotComposants.Columns["NomLot"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridLotComposants.Columns["NomLot"].HeaderText = "Lot associé";
        }

        /// <summary>
        /// Charge la liste des lots composants dans le DataGrid en appliquant le filtre de recherche en cours.
        /// </summary>
        private void ChargerLotComposants()
        {
            // On charge la liste des lots composants dans le dataGrid
            dataGridLotComposants.DataSource = null;
            var listeLotComposants = _serviceLotComposant.Lister(filtre)
                .ToList();
            dataGridLotComposants.DataSource = listeLotComposants;
            MEP_DataGridLotComposants();
        }

        /// <summary>
        /// Charge la liste des lots dans la ComboBox en ajoutant un élément "Aucun" en tête de liste.
        /// Sélectionne "Aucun" par défaut.
        /// </summary>
        private void ChargerLots()
        {
            // On charge les lots dans la comboBox
            var lots = _serviceLot.Lister("");

            // On ajoute un élément "Aucun" en tête de liste
            comboBoxLot.DisplayMember = "Libelle";
            comboBoxLot.ValueMember = "Numero";
            comboBoxLot.DataSource = null;

            listeLots = new List<Lot>();
            listeLots.Add(new Lot { Numero = null, Libelle = "Aucun" });
            listeLots.AddRange(lots);

            comboBoxLot.DataSource = listeLots;
            comboBoxLot.SelectedIndex = 0; // sélectionne "Aucun" par défaut
        }

        /// <summary>
        /// Remet tous les champs du formulaire à vide et désélectionne le lot composant en cours.
        /// Désactive également les boutons Modifier et Supprimer.
        /// </summary>
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

        /// <summary>
        /// Remplit les champs du formulaire avec les données du lot composant sélectionné.
        /// Sélectionne "Aucun" dans la ComboBox si le lot composant n'est associé à aucun lot.
        /// </summary>
        /// <param name="lotComposant">Le lot composant dont les données sont affichées.</param>
        private void RemplirFormulaire(LotComposant lotComposant)
        {
            // On remplie les champs avec les données du lot composant sélectionné
            textBoxLibelle.Text = lotComposant.Libelle;
            textBoxDescription.Text = lotComposant.Description;
            textBoxValeur.Text = lotComposant.Valeur.ToString();
            if(lotComposant.NumeroLot == null)
            {
                comboBoxLot.SelectedValue = "Aucun";
            }
            else
            {
                comboBoxLot.SelectedValue = lotComposant.NumeroLot;
            }
        }

        /// <summary>
        /// Permet de charger les statistiques liées aux lots composants, notamment le nombre total de composant 
        /// et le nombre de composant non attribué (sans lot associé). 
        /// Les statistiques sont affichées dans des labels dédiés, 
        /// avec une indication visuelle (couleur) pour les composants non attribués.
        /// Cette méthode est appelée après le chargement des composants pour garantir 
        /// que les statistiques sont à jour.
        /// </summary>
        private void ChargerStatistiques()
        {
            // Un lot composant est considéré comme non attribués quand il dispose d'aucun lot associé
            int nbComposantNonAttribue = _serviceLotComposant.Lister(filtre)
                                    .Count(e => e.Lot == null);

            labelStatComposantsTotal.Text = $"{_serviceLotComposant.Lister(filtre).Count()}";

            if (nbComposantNonAttribue == 0)
            {
                labelStatComposantNonAttribuer.Text = "Aucun composant non attribué";
                labelStatComposantNonAttribuer.ForeColor = Color.Red;
            }
            else
            {
                labelStatComposantNonAttribuer.Text = $"Composants non attribués : {nbComposantNonAttribue}";
                labelStatComposantNonAttribuer.ForeColor = Color.Green;
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
            var erreurs = _serviceLotComposant.ValiderLotComposant(lotComposant);
            if (erreurs.Any())
            {
                MessageBox.Show(string.Join("\n", erreurs), "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        /// <summary>
        /// Permet de voir si tout les champs d'un lot composant ne sont pas vides
        /// </summary>
        /// <returns>true si tout est respectés, sinon false.</returns>
        public bool ChampVide()
        {
            if (string.IsNullOrWhiteSpace(textBoxLibelle.Text))
            {
                MessageBox.Show("Le Libelle ne peut pas être vide", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxDescription.Text))
            {
                MessageBox.Show("La Description ne peut pas être vide", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxValeur.Text))
            {
                MessageBox.Show("La Valeur ne peut pas être vide", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        #endregion

        #region Evènements

        /// <summary>
        /// Crée un nouveau lot composant avec les données saisies dans le formulaire.
        /// Vérifie que les champs sont valides et que les règles métier sont respectées.
        /// </summary>
        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            // On check si les champs sont vides
            if (ChampVide() == false)
            {
                return;
            }

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
            // On ajoute sa valeur à la valeur totale du lot associé si il en a un
            if (unNouveauLotComposant.NumeroLot != null)
            {
                lotActuelle = _serviceLot.Obtenir(unNouveauLotComposant.NumeroLot.Value);
                lotActuelle.ValeurTotale += unNouveauLotComposant.Valeur;
                _serviceLot.Modifier(lotActuelle);
            }

            MessageBox.Show("Le lot composant a bien été ajouté.", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ChargerLotComposants();
            Raz_Zones();
        }

        /// <summary>
        /// Modifie le lot composant sélectionné avec les nouvelles valeurs saisies dans le formulaire.
        /// Met à jour uniquement les champs modifiés et gère le lot nullable.
        /// </summary>
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
            if (textBoxValeur.Text != "" || _lotComposantSelectionne.Valeur != int.Parse(textBoxValeur.Text))
                _lotComposantSelectionne.Valeur = int.Parse(textBoxValeur.Text);
            // Gestion du lot nullable
            nouveauNumeroLot = comboBoxLot.SelectedValue is int valLot ? valLot : (int?)null; //ternaire qui met à null si "Aucun" est sélectionné
            if (nouveauNumeroLot != _lotComposantSelectionne.NumeroLot)
            {
                lotActuelle = nouveauNumeroLot.HasValue
                    ? _serviceLot.Obtenir(nouveauNumeroLot.Value)
                    : null;

                lotAncien = _lotComposantSelectionne.NumeroLot.HasValue
                    ? _serviceLot.Obtenir(_lotComposantSelectionne.NumeroLot.Value)
                    : null;

                _lotComposantSelectionne.NumeroLot = nouveauNumeroLot;

                // aucun lot -> un lot 
                if (lotAncien == null && lotActuelle != null)
                {
                    lotActuelle.ValeurTotale += _lotComposantSelectionne.Valeur;
                    _serviceLot.Modifier(lotActuelle);
                }
                // un lot -> aucun lot
                else if (lotActuelle == null && lotAncien != null)
                {
                    lotAncien.ValeurTotale -= _lotComposantSelectionne.Valeur;
                    _serviceLot.Modifier(lotAncien);
                }
                // un lot -> un autre lot
                else if (lotActuelle != null && lotAncien != null)
                {
                    lotActuelle.ValeurTotale += _lotComposantSelectionne.Valeur;
                    _serviceLot.Modifier(lotActuelle);
                    lotAncien.ValeurTotale -= _lotComposantSelectionne.Valeur;
                    _serviceLot.Modifier(lotAncien);
                }
            }

            MessageBox.Show("Le lot composant a bien été modifié.", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _serviceLotComposant.Modifier(_lotComposantSelectionne);
            ChargerLotComposants();
            Raz_Zones();
        }

        /// <summary>
        /// Supprime le lot composant sélectionné après vérification qu'un lot composant est bien sélectionné.
        /// </summary>
        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            // On check si un orgnisateur est sélectionné, puis on le supprime
            // Ne pas pouvoir suppr si aucun lot composant n'est sélectionné
            if (_lotComposantSelectionne == null)
            {
                MessageBox.Show("Aucun Lot Composant sélectionné.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Êtes vous sûr de vouloir supprimer ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            // On retire la valeur du lot composant si il a un lot associé
            if (_lotComposantSelectionne.NumeroLot != null)
            {
                lotActuelle = _serviceLot.Obtenir(_lotComposantSelectionne.NumeroLot.Value);
                lotActuelle.ValeurTotale -= _lotComposantSelectionne.Valeur;
                _serviceLot.Modifier(lotActuelle);
            }
            MessageBox.Show("Le lot composant a bien été supprimé.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _serviceLotComposant.Supprimer(_lotComposantSelectionne.Numero.Value);
            ChargerLotComposants();
            Raz_Zones();
        }

        /// <summary>
        /// Remet le formulaire à vide sans sauvegarder les modifications.
        /// </summary>
        private void buttonEffacer_Click(object sender, EventArgs e)
        {
            Raz_Zones();
        }

        /// <summary>
        /// Gère les clics sur le DataGrid des lots composants.
        /// Si le clic est sur un en-tête de colonne, trie les données par ordre ASC ou DESC.
        /// Si le clic est sur une cellule, sélectionne le lot composant et remplit le formulaire.
        /// </summary>
        private void dataGridLotComposants_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignorer les clics sur l'en-tête (gérés pour le tri)
            if (e.RowIndex < 0)
            {
                // ordonner sur les champs numero, libelle, description et valeur
                var donnees = _serviceLotComposant.Lister(filtre);
                var map = new Dictionary<int, Func<LotComposant, object>>
                {
                    { dataGridLotComposants.Columns["Numero"].Index, lc => lc.Numero },
                    { dataGridLotComposants.Columns["Libelle"].Index, lc => lc.Libelle },
                    { dataGridLotComposants.Columns["Description"].Index, lc => lc.Description },
                    { dataGridLotComposants.Columns["Valeur"].Index, lc => lc.Valeur }
                };

                if (!map.TryGetValue(e.ColumnIndex, out var keySelector))
                    return;
                // Appliquer le tri
                dataGridLotComposants.DataSource = ordreChamp == "ASC"
                    ? donnees.OrderByDescending(keySelector).ToList()
                    : donnees.OrderBy(keySelector).ToList();
                // Inverser l’ordre
                ordreChamp = ordreChamp == "ASC" ? "DESC" : "ASC";
                MEP_DataGridLotComposants();
                return;
            }

            // Ne pas recharger le DataSource lors d'un clic sur une cellule : cela réinitialise la sélection
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

        #region Méthodes
        /// <summary>
        /// Permet de désactiver le tri automatique sur les colonnes d'un DataGridView pour gérer le tri manuellement dans l'événement CellClick.
        /// </summary>
        /// <param name="dataGrid">Le DataGridView dont les colonnes doivent être configurées.</param>
        private void DesactiverTrieAutomatique(DataGridView dataGrid)
        {
            foreach (DataGridViewColumn col in dataGrid.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }
        #endregion
    }
}