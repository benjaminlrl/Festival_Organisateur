using Lib_Entities.Entities;
using Lib_Metier.Data.Configurations;
using Lib_Services.Interfaces;
using Lib_Services.Services;
using Lib_Services.Exceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Serilog;

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
        string filtre;
        string ordreChamp = "DESC";
        Lot? lotActuelle;
        Lot? lotAncien;

        public UcLotComposants(Organisateur unOrganisateurConnecte)
        {
            InitializeComponent();
            var context = new ApplicationDbContext();
            _serviceOrganisateur = new OrganisateurService(context);
            _serviceLot = new LotService(context);
            _serviceLotComposant = new LotComposantService(context);
            listeLots = new List<Lot>();
            _organisateurConnecte = unOrganisateurConnecte;
            filtre = "";
            ChargerLots();
            Raz_Zones();
            boutonModifier.Enabled = _lotComposantSelectionne != null;
            boutonSupprimer.Enabled = _lotComposantSelectionne != null;

            if (_serviceOrganisateur.EstAutoriser(_organisateurConnecte, Organisateur.LesUC.UcLotComposants, "Ajouter") == false)
            {
                boutonAjouter.Visible = false;
            }
            if (_serviceOrganisateur.EstAutoriser(_organisateurConnecte, Organisateur.LesUC.UcLotComposants, "Modifier") == false)
            {
                boutonModifier.Visible = false;
            }
            if (_serviceOrganisateur.EstAutoriser(_organisateurConnecte, Organisateur.LesUC.UcLotComposants, "Supprimer") == false)
            {
                boutonSupprimer.Visible = false;
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
            listeLots.AddRange(lots);

            comboBoxLot.DataSource = listeLots;
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
            _lotComposantSelectionne = null;
            boutonModifier.Enabled = _lotComposantSelectionne != null;
            boutonSupprimer.Enabled = _lotComposantSelectionne != null;
            ChargerStatistiques();
            ChargerLotComposants();
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
            if (lotComposant.NumeroLot == null)
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
            var liste = _serviceLotComposant.Lister(filtre);
            int nbTotal = liste.Count();
            labelStatComposantsTotal.Text = $"{nbTotal}";
        }

        #endregion

        #region Evènements

        /// <summary>
        /// Crée un nouveau lot composant avec les données saisies dans le formulaire.
        /// Vérifie que les champs sont valides et que les règles métier sont respectées.
        /// </summary>
        private void BoutonAjouter_Click(object sender, EventArgs e)
        {
            // On vérifie d'abord que la veleur n'est pas vide
            if (string.IsNullOrWhiteSpace(textBoxValeur.Text))
            {
                MessageBox.Show("La valeur ne peut pas être vide.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                // On crée un nouveau lot composant avec les données des champs
                unNouveauLotComposant = new LotComposant
                {
                    Libelle = textBoxLibelle.Text,
                    Description = textBoxDescription.Text,
                    Valeur = int.Parse(textBoxValeur.Text),
                    NumeroLot = (int)comboBoxLot.SelectedValue
                };

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
            catch (LotComposantException ex)
            {
                Log.Warning("[{Code}] {Message}", ex.CodeErreur, ex.Message);
                MessageBox.Show(ex.Message);
            }
            catch (DbException ex)
            {
                Log.Error(ex, "Une erreur technique est survenue lors de l'ajout du lot composant.");
                MessageBox.Show("Erreur technique, réessayez plus tard.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Une erreur inattendue est survenue.");
                MessageBox.Show("Une erreur inattendue est survenue.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Modifie le lot composant sélectionné avec les nouvelles valeurs saisies dans le formulaire.
        /// Met à jour uniquement les champs modifiés et gère le lot nullable.
        /// </summary>
        private void BoutonModifier_Click(object sender, EventArgs e)
        {
            // On check s'il a bien selectionné un lot composant à modifier
            if (_lotComposantSelectionne == null)
            {
                MessageBox.Show("Aucun Lot Composant sélectionné.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                // Gestion du lot nullable
                int? nouveauNumeroLot = comboBoxLot.SelectedValue is int valLot ? valLot : (int?)null; //ternaire qui met à null si "Aucun" est sélectionné
                if (nouveauNumeroLot != _lotComposantSelectionne.NumeroLot)
                {
                    lotActuelle = nouveauNumeroLot.HasValue
                        ? _serviceLot.Obtenir(nouveauNumeroLot.Value)
                        : null;

                    lotAncien = _lotComposantSelectionne.NumeroLot.HasValue
                        ? _serviceLot.Obtenir(_lotComposantSelectionne.NumeroLot.Value)
                        : null;

                    _lotComposantSelectionne.NumeroLot = nouveauNumeroLot;
                }
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
                // Modifiée seulement les valeurs qui ont été modifiées
                if (textBoxLibelle.Text != "" || _lotComposantSelectionne.Libelle != textBoxLibelle.Text)
                     _lotComposantSelectionne.Libelle = textBoxLibelle.Text;
                if (textBoxDescription.Text != "" || _lotComposantSelectionne.Description != textBoxDescription.Text)
                     _lotComposantSelectionne.Description = textBoxDescription.Text;
                if (textBoxValeur.Text != "" || _lotComposantSelectionne.Valeur != int.Parse(textBoxValeur.Text))
                     _lotComposantSelectionne.Valeur = int.Parse(textBoxValeur.Text);
                _serviceLotComposant.Modifier(_lotComposantSelectionne);
                MessageBox.Show("Le lot composant a bien été modifié.", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ChargerLotComposants();
                Raz_Zones();
            }
            catch (LotComposantException ex)
            {
                Log.Warning("[{Code}] {Message}", ex.CodeErreur, ex.Message);
                MessageBox.Show(ex.Message);
            }
            catch (DbException ex)
            {
                Log.Error(ex, "Une erreur technique est survenue lors de la modification du lot composant.");
                MessageBox.Show("Erreur technique, réessayez plus tard.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Une erreur inattendue est survenue.");
                MessageBox.Show("Une erreur inattendue est survenue.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Supprime le lot composant sélectionné après vérification qu'un lot composant est bien sélectionné.
        /// </summary>
        private void BoutonSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                // On check si un lot composant est sélectionné, puis on le supprime
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
                _serviceLotComposant.Supprimer(_lotComposantSelectionne);
                MessageBox.Show("Le lot composant a bien été supprimé.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ChargerLotComposants();
                Raz_Zones();
            }
            catch (OrganisateurException ex)
            {
                Log.Warning("[{Code}] {Message}", ex.CodeErreur, ex.Message);
                MessageBox.Show(ex.Message);
            }
            catch (DbException ex)
            {
                Log.Error(ex, "Une erreur technique est survenue lors de la modification de l'organisateur.");
                MessageBox.Show("Erreur technique, réessayez plus tard.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Une erreur inattendue est survenue.");
                MessageBox.Show("Une erreur inattendue est survenue.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Remet le formulaire à vide sans sauvegarder les modifications.
        /// </summary>
        private void BoutonEffacer_Click(object sender, EventArgs e)
        {
            Raz_Zones();
        }

        /// <summary>
        /// Gère les clics sur le DataGrid des lots composants.
        /// Si le clic est sur un en-tête de colonne, trie les données par ordre ASC ou DESC.
        /// Si le clic est sur une cellule, sélectionne le lot composant et remplit le formulaire.
        /// </summary>
        private void DataGridLotComposants_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignorer les clics sur l'en-tête (gérés pour le tri)
            if (e.RowIndex < 0)
            {
                // ordonner sur les champs numero, libelle, description et valeur
                Dictionary<int, string> map = new()
                {
                    { dataGridLotComposants.Columns["Numero"].Index, "Numero" },
                    { dataGridLotComposants.Columns["Libelle"].Index, "Libelle" },
                    { dataGridLotComposants.Columns["Description"].Index, "Description" },
                    { dataGridLotComposants.Columns["Valeur"].Index, "Valeur" }
                };

                // Si la colonne cliquée n'appartient pas aux propriétés ci-dessus, ne rien faire,
                // sinon récupérer le nom de la propriété associée à la colonne cliquée
                if (!map.TryGetValue(e.ColumnIndex, out string? colonne))
                    return;

                // Inverser l’ordre
                ordreChamp = ordreChamp == "ASC" ? "DESC" : "ASC";

                // Appliquer le tri
                dataGridLotComposants.DataSource = _serviceLotComposant.Lister(filtre, colonne, ordreChamp);
                dataGridLotComposants.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection =
                    ordreChamp == "ASC" ? SortOrder.Ascending : SortOrder.Descending;

                MEP_DataGridLotComposants();
                return;
            }

            // Ne pas recharger le DataSource lors d'un clic sur une cellule : cela réinitialise la sélection
            _lotComposantSelectionne = dataGridLotComposants.Rows[e.RowIndex].DataBoundItem as LotComposant;

            if (_lotComposantSelectionne != null)
                RemplirFormulaire(_lotComposantSelectionne);

            boutonModifier.Enabled = _lotComposantSelectionne != null;
            boutonSupprimer.Enabled = _lotComposantSelectionne != null;
        }

        /// <summary>
        /// Gère l'événement déclenché lorsque le texte de la zone de recherche est modifié.
        /// </summary>
        /// <remarks>Utilisez cet événement pour mettre à jour dynamiquement les résultats de recherche en
        /// fonction de la saisie de l'utilisateur.</remarks>
        /// <param name="sender">L'objet source de l'événement, généralement la zone de texte de recherche.</param>
        /// <param name="e">Les données associées à l'événement de modification du texte.</param>
        private void TextBoxRecherche_TextChanged(object sender, EventArgs e)
        {
            filtre = textBoxRecherche.Text;
            ChargerLotComposants();
            ChargerStatistiques();
        }

        #endregion

        #region Méthodes
        /// <summary>
        /// Permet de désactiver le tri automatique sur les colonnes d'un DataGridView pour gérer le tri manuellement dans l'événement CellClick.
        /// </summary>
        /// <param name="dataGrid">Le DataGridView dont les colonnes doivent être configurées.</param>
        static void DesactiverTrieAutomatique(DataGridView dataGrid)
        {
            foreach (DataGridViewColumn col in dataGrid.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }
        #endregion
    }
}