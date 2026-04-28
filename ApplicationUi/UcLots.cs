using Lib_Entities.Entities;
using Lib_Metier.Data.Configurations;
using Lib_Services.Interfaces;
using Lib_Services.Services;
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
    public partial class UcLots : UserControl
    {
        private readonly IOrganisateurService _serviceOrganisateur;
        private readonly ITournoiService _serviceTournoi;
        private readonly ILotService _serviceLot;
        private readonly ILotComposantService _serviceLotComposant;
        private readonly Organisateur _organisateurConnecte;
        private LotComposant? _lotComposantSelectionnee = null;
        private LotComposant? _lotComposantDunLotSelectionnee = null;
        private Lot? _lotSelectionnee = null;
        private Lot? unNouveauLot;
        private List<LotComposant> listeLotComposants;
        private List<LotComposant> listeLotComposantsDunLot;
        string filtre;
        string ordreChampLots = "DESC";
        string ordreChampComposants = "DESC";
        string ordreChampComposantsDunLot = "DESC";

        public UcLots(Organisateur unOrganisateurConnecte)
        {
            InitializeComponent();
            var context = new ApplicationDbContext();
            _serviceOrganisateur = new OrganisateurService(context);
            _serviceTournoi = new TournoiService(context);
            _serviceLot = new LotService(context);
            _serviceLotComposant = new LotComposantService(context);
            _organisateurConnecte = unOrganisateurConnecte;
            filtre = "";
            ChargerLots();
            ChargerTournoi();
            Raz_Zones();
            DemarrageLotComposants();
            DemarrageLotComposantsDunlot();
            boutonModifier.Enabled = _lotSelectionnee != null;
            boutonSupprimerLot.Enabled = _lotSelectionnee != null;
            if (_serviceOrganisateur.EstAutoriser(_organisateurConnecte, Organisateur.LesUC.UcLots, "Ajouter") == false)
            {
                boutonAjouterLot.Visible = false;
            }
            if (_serviceOrganisateur.EstAutoriser(_organisateurConnecte, Organisateur.LesUC.UcLots, "Modifier") == false)
            {
                boutonModifier.Visible = false;
            }
            if (_serviceOrganisateur.EstAutoriser(_organisateurConnecte, Organisateur.LesUC.UcLots, "Supprimer") == false)
            {
                boutonSupprimerLot.Visible = false;
            }
        }

        #region Chargement

        /// <summary>
        /// Met en page les DataGrids en configurant la visibilité, l'ordre d'affichage
        /// et le redimensionnement automatique des colonnes selon le formulaire ciblé.
        /// </summary>
        /// <param name="unFormulaire">Nom du formulaire ciblé : "Lots", "LotComposants" ou "LotComposantsDunLot".</param>
        private void MEP_DataGrid(string unFormulaire)
        {
            // Ici on affiche et modifie l'affichage des colonnes du dataGrid
            if (unFormulaire == "Lots")
            {
                DesactiverTrieAutomatique(dataGridLots);
                dataGridLots.Columns["Numero"].DisplayIndex = 0;
                dataGridLots.Columns["LotComposant"].Visible = false;
                dataGridLots.Columns["EstAttribue"].Visible = false;
                dataGridLots.Columns["NumeroTournoi"].Visible = false;
                dataGridLots.Columns["Tournoi"].Visible = false;
                dataGridLots.Columns["Numero"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridLots.Columns["Libelle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridLots.Columns["ValeurTotale"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridLots.Columns["RangAttribution"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridLots.Columns["NomTournoi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridLots.Columns["NomTournoi"].HeaderText = "Tournoi associé";
            }
            else if (unFormulaire == "LotComposants")
            {
                DesactiverTrieAutomatique(dataGridLotComposants);
                dataGridLotComposants.Columns["Numero"].DisplayIndex = 0;
                dataGridLotComposants.Columns["Lot"].Visible = false;
                dataGridLotComposants.Columns["NumeroLot"].Visible = false;
                dataGridLotComposants.Columns["Valeur"].Visible = false;
                dataGridLotComposants.Columns["Description"].Visible = false;
                dataGridLotComposants.Columns["Numero"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridLotComposants.Columns["Libelle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            else if (unFormulaire == "LotComposantsDunLot")
            {
                DesactiverTrieAutomatique(dataGridLotComposantsDunLot);
                dataGridLotComposantsDunLot.Columns["Numero"].DisplayIndex = 0;
                dataGridLotComposantsDunLot.Columns["Lot"].Visible = false;
                dataGridLotComposantsDunLot.Columns["NumeroLot"].Visible = false;
                dataGridLotComposantsDunLot.Columns["Valeur"].Visible = false;
                dataGridLotComposantsDunLot.Columns["Description"].Visible = false;
                dataGridLotComposantsDunLot.Columns["Numero"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridLotComposantsDunLot.Columns["Libelle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        /// <summary>
        /// Charge la liste des lots dans le DataGrid en appliquant le filtre de recherche en cours.
        /// </summary>
        private void ChargerLots()
        {
            // On charge la liste des lots dans le dataGrid
            dataGridLots.DataSource = null;
            var listeLots = _serviceLot.Lister(filtre)
                .ToList();
            dataGridLots.DataSource = listeLots;
            MEP_DataGrid("Lots");
            ChargerStatistiquesLots();
        }

        /// <summary>
        /// Charge la liste des tournois dans la ComboBox en ajoutant un élément "Aucun" en tête de liste.
        /// Sélectionne "Aucun" par défaut.
        /// </summary>
        private void ChargerTournoi()
        {
            // On charge les tournois uniquement pour la combobox, pas besoin de les charger dans un dataGrid
            comboBoxTournoi.DisplayMember = "Nom";
            comboBoxTournoi.ValueMember = "NumeroTournoi";
            comboBoxTournoi.DataSource = null;
            comboBoxTournoi.DataSource = _serviceTournoi.Lister("");
            MEP_DataGrid("Lots");
        }

        /// <summary>
        /// Charge la liste des lots composants non encore associés à un lot dans le DataGrid et la ComboBox.
        /// Sélectionne automatiquement le premier élément si la liste n'est pas vide.
        /// </summary>
        private void ChargerLotComposants()
        {
            // On charge les lots composants dans la combobox ainsi que la liste des lots composants dans le dataGrid
            dataGridLotComposants.DataSource = null;
            var listeLotComposantsCharger = _serviceLotComposant.Lister(filtre)
                .Where(t => t.NumeroLot == null) // On affiche que les lots composants qui ne sont pas encore associés à un lot
                .ToList();
            dataGridLotComposants.DataSource = listeLotComposantsCharger;
            comboBoxLotComposant.DataSource = listeLotComposantsCharger;

            // On force l'affichage et la selection au 1er composant chargé
            if (comboBoxLotComposant.Items.Count > 0)
            {
                comboBoxLotComposant.SelectedIndex = 0;
                _lotComposantSelectionnee = listeLotComposantsCharger[0];
            }
            else
            {
                comboBoxLotComposant.SelectedItem = null;
                _lotComposantSelectionnee = null;
            }
            MEP_DataGrid("LotComposants");
        }

        /// <summary>
        /// Charge la liste des lots composants associés au lot sélectionné dans le DataGrid et la ComboBox.
        /// Sélectionne automatiquement le premier élément si la liste n'est pas vide.
        /// </summary>
        private void ChargerLotComposantsDunLot()
        {
            // On charge les lots composants du lot selectionné dans le dataGrid
            dataGridLotComposantsDunLot.DataSource = null;
            var listeLotComposantsDunLotCharger = _serviceLotComposant.ListerParNumeroDunLot(_lotSelectionnee.Numero)
                .Where(t => t.NumeroLot != null) // On affiche que les lots composants qui sont associés à un lot
                .ToList();
            dataGridLotComposantsDunLot.DataSource = listeLotComposantsDunLotCharger;
            comboBoxLotComposantDunLot.DataSource = listeLotComposantsDunLotCharger;

            // On force l'affichage et la selection au 1er composant chargé
            if (comboBoxLotComposantDunLot.Items.Count > 0)
            {
                comboBoxLotComposantDunLot.SelectedIndex = 0;
                _lotComposantDunLotSelectionnee = listeLotComposantsDunLotCharger[0];
            }
            else
            {
                comboBoxLotComposantDunLot.SelectedItem = null;
                _lotComposantDunLotSelectionnee = null;
            }

            // On met à jour les stats du nombre de composants associés au lot
            labelStatsComposantDunLotTotal.Text = $"{listeLotComposantsDunLotCharger.Count()}";
            MEP_DataGrid("LotComposantsDunLot");
        }

        /// <summary>
        /// Initialise la ComboBox des lots composants d'un lot avec un élément "Aucun" par défaut.
        /// Appelée une seule fois au démarrage du formulaire.
        /// </summary>
        private void DemarrageLotComposantsDunlot()
        {
            var lotcomposantsDunLot = _serviceLotComposant.Lister("");
            // On charge la liste des lots composants dans le comboBox
            // On ajoute un élément "Aucun" en tête de liste
            comboBoxLotComposantDunLot.DisplayMember = "Libelle";
            comboBoxLotComposantDunLot.ValueMember = "Numero";
            comboBoxLotComposantDunLot.DataSource = null;

            // On met les stats à 0 au démarrage du formulaire
            labelStatsComposantDunLotTotal.Text = "0";

            listeLotComposantsDunLot = new List<LotComposant>();
            comboBoxLotComposantDunLot.DataSource = listeLotComposantsDunLot;
        }

        /// <summary>
        /// Initialise la ComboBox des lots composants avec un élément "Aucun" par défaut.
        /// Appelée une seule fois au démarrage du formulaire.
        /// </summary>
        private void DemarrageLotComposants()
        {
            var lotcomposants = _serviceLotComposant.Lister("");
            // On charge la liste des lots composants dans le comboBox
            // On ajoute un élément "Aucun" en tête de liste
            comboBoxLotComposant.DisplayMember = "Libelle";
            comboBoxLotComposant.ValueMember = "Numero";
            comboBoxLotComposant.DataSource = null;

            listeLotComposants = new List<LotComposant>();
            comboBoxLotComposant.DataSource = listeLotComposants;
        }

        /// <summary>
        /// Remplit les champs du formulaire avec les données du lot sélectionné.
        /// Sélectionne "Aucun" dans la ComboBox si le lot n'est associé à aucun tournoi.
        /// </summary>
        /// <param name="lot">Le lot dont les données sont affichées.</param>
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

        /// <summary>
        /// Sélectionne dans la ComboBox le lot composant correspondant à celui passé en paramètre.
        /// </summary>
        /// <param name="lotComposant">Le lot composant à sélectionner dans la ComboBox.</param>
        private void RemplirFormulaireLotComposant(LotComposant lotComposant)
        {
            // On remplie la combobox avec les données du Lot Composant sélectionné
            comboBoxLotComposant.SelectedValue = lotComposant.Numero;
        }

        /// <summary>
        /// Sélectionne dans la ComboBox du lot le lot composant correspondant à celui passé en paramètre.
        /// </summary>
        /// <param name="lotComposant">Le lot composant à sélectionner dans la ComboBox.</param>
        private void RemplirFormulaireLotComposantDunLot(LotComposant lotComposant)
        {
            // On remplie la combobox avec les données du Lot Composant sélectionné
            comboBoxLotComposantDunLot.SelectedValue = lotComposant.Numero;
        }

        /// <summary>
        /// Remet tous les champs du formulaire à vide et désélectionne le lot en cours.
        /// Désactive également les boutons Modifier et Supprimer.
        /// </summary>
        private void Raz_Zones()
        {
            // On remet tous les champs à vide
            textBoxLibelle.Clear();
            textBoxRang.Clear();
            _lotSelectionnee = null;
            boutonModifier.Enabled = _lotSelectionnee != null;
            boutonSupprimerLot.Enabled = _lotSelectionnee != null;
        }

        /// <summary>
        /// Resélectionne dans le DataGrid la ligne correspondant au lot actuellement sélectionné,
        /// après un rafraîchissement de la source de données.
        /// </summary>
        private void ChargerCellOrigine()
        {
            // Code fait par IA (ChatGPT)
            var row = dataGridLots.Rows
                .Cast<DataGridViewRow>()
                .FirstOrDefault(r => (r.DataBoundItem as Lot)?.Numero == _lotSelectionnee.Numero);

            if (row != null)
            {
                dataGridLots.CurrentCell = row.Cells[0];
                row.Selected = true;
            }
        }

        /// <summary>
        /// Permet de charger les statistiques liées aux lots, notamment le nombre total de lot 
        /// et le nombre de lot non attribué (sans tournoi associé). 
        /// Les statistiques sont affichées dans des labels dédiés, 
        /// avec une indication visuelle (couleur) pour les lots non attribués.
        /// Cette méthode est appelée après le chargement des lots pour garantir 
        /// que les statistiques sont à jour.
        /// </summary>
        private void ChargerStatistiquesLots()
        {
            var liste = _serviceLot.Lister(filtre);
            int nbTotal = liste.Count();
            labelStatLotsTotal.Text = $"{nbTotal}";
        }

        #endregion

        #region Evènements

        /// <summary>
        /// Crée un nouveau lot avec les données saisies dans le formulaire.
        /// Vérifie que les champs sont valides et que les règles métier sont respectées.
        /// Met à jour EstAttribue si un tournoi est sélectionné.
        /// </summary>
        private void BoutonAjouterLot_Click(object sender, EventArgs e)
        {
            try
            {
                // On vérifie d'abord que le rang n'est pas vide
                if (string.IsNullOrWhiteSpace(textBoxRang.Text))
                {
                    MessageBox.Show("Le rang ne peut pas être vide.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // On crée un nouveau lot composant avec les données des champs
                unNouveauLot = new Lot
                {
                    Libelle = textBoxLibelle.Text,
                    RangAttribution = int.Parse(textBoxRang.Text),
                    ValeurTotale = 0,
                    NumeroTournoi = (int)comboBoxTournoi.SelectedValue
                };

                // On oublie pas de mettre "estAttribue" à true si un tournoi est sélectionné (= le NumeroTournoi pas null)
                if (unNouveauLot.NumeroTournoi != null)
                {
                    unNouveauLot.EstAttribue = true;
                }
                // On crée le lot en base
                _serviceLot.Creer(unNouveauLot);
                MessageBox.Show("Le lot a bien été créé.", "Création", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ChargerLots();
                Raz_Zones();
            }
            catch (LotException ex)
            {
                Log.Warning("[{Code}] {Message}", ex.CodeErreur, ex.Message);
                MessageBox.Show(ex.Message, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DbException ex)
            {
                Log.Error(ex, "Une erreur technique est survenue lors de la création du lot.");
                MessageBox.Show("Erreur technique, réessayez plus tard.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Une erreur inattendue est survenue.");
                MessageBox.Show("Une erreur inattendue est survenue.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Supprime le lot sélectionné après vérification qu'un lot est bien sélectionné.
        /// </summary>
        private void BoutonSupprimerLot_Click(object sender, EventArgs e)
        {
            try
            {
                // On check si un orgnisateur est sélectionné, puis on le supprime
                // Ne pas pouvoir suppr si aucun lot composant n'est sélectionné
                if (_lotSelectionnee == null)
                {
                    MessageBox.Show("Aucun Lot sélectionné.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MessageBox.Show("Êtes vous sûr de vouloir supprimer ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                _serviceLot.Supprimer(_lotSelectionnee);
                MessageBox.Show("Le lot a bien été supprimé.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ChargerLots();
                Raz_Zones();
            }
            catch (OrganisateurException ex)
            {
                Log.Warning("[{Code}] {Message}", ex.CodeErreur, ex.Message);
                MessageBox.Show(ex.Message, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /// Modifie le lot sélectionné avec les nouvelles valeurs saisies dans le formulaire.
        /// Met à jour uniquement les champs modifiés et gère le tournoi nullable.
        /// Met à jour EstAttribue si un tournoi est associé.
        /// </summary>
        private void BoutonModifierLot_Click(object sender, EventArgs e)
        {
            // On check s'il a bien selectionné un lot composant à modifier
            if (_lotSelectionnee == null)
            {
                MessageBox.Show("Aucun Lot sélectionné.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Modifiée seulement les valeurs qui ont été modifiées
                if (textBoxLibelle.Text != "" || _lotSelectionnee.Libelle != textBoxLibelle.Text)
                    _lotSelectionnee.Libelle = textBoxLibelle.Text;
                if (textBoxRang.Text.ToString() != "" || _lotSelectionnee.RangAttribution != int.Parse(textBoxRang.Text))
                    _lotSelectionnee.RangAttribution = int.Parse(textBoxRang.Text);
                // Gestion du tournoi nullable
                int? nouveauNumeroTournoi = comboBoxTournoi.SelectedValue is int valLot ? valLot : (int?)null; //ternaire qui met à null si "Aucun" est sélectionné
                if (nouveauNumeroTournoi != _lotSelectionnee.NumeroTournoi)
                {
                    _lotSelectionnee.NumeroTournoi = nouveauNumeroTournoi;
                    if (_lotSelectionnee.EstAttribue != true) // On modifie uniquement si le champ est pas déjà à true
                        _lotSelectionnee.EstAttribue = true;
                }
                // On modifie le lot en base
                _serviceLot.Modifier(_lotSelectionnee);
                MessageBox.Show("Le lot a bien été modifié.", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ChargerLots();
                Raz_Zones();
            }
            catch (LotException ex)
            {
                Log.Warning("[{Code}] {Message}", ex.CodeErreur, ex.Message);
                MessageBox.Show(ex.Message, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DbException ex)
            {
                Log.Error(ex, "Une erreur technique est survenue lors de la modification du lot.");
                MessageBox.Show("Erreur technique, réessayez plus tard.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Une erreur inattendue est survenue.");
                MessageBox.Show("Une erreur inattendue est survenue.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Associe le lot composant sélectionné au lot en cours, met à jour la valeur totale du lot
        /// et rafraîchit les DataGrids.
        /// Vérifie qu'un lot et un composant sont bien sélectionnés, et que le composant n'est pas déjà associé.
        /// </summary>
        private void BoutonAjouterLotComposant_Click(object sender, EventArgs e)
        {
            if (_lotSelectionnee == null)
            {
                MessageBox.Show("Aucun Lot sélectionné.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_lotComposantSelectionnee == null)
            {
                MessageBox.Show("Aucun Composant sélectionné.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_lotComposantSelectionnee.NumeroLot == _lotSelectionnee.Numero)
            {
                MessageBox.Show("Le Lot selectionné contient déjà ce composant.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show($"Le lot composant a bien été ajouté au lot {_lotSelectionnee.Libelle}.", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _lotComposantSelectionnee.NumeroLot = _lotSelectionnee.Numero;
            _serviceLotComposant.Modifier(_lotComposantSelectionnee);
            _lotSelectionnee.ValeurTotale += _lotComposantSelectionnee.Valeur;
            _serviceLot.Modifier(_lotSelectionnee);
            ChargerLots();
            ChargerLotComposants();
            ChargerLotComposantsDunLot();
            ChargerCellOrigine();
        }

        /// <summary>
        /// Dissocie le lot composant sélectionné du lot en cours, met à jour la valeur totale du lot
        /// et rafraîchit les DataGrids.
        /// Vérifie qu'un lot et un composant sont bien sélectionnés, et que le composant appartient bien au lot.
        /// </summary>
        private void BoutonSupprimerLotComposant_Click(object sender, EventArgs e)
        {
            if (_lotSelectionnee == null)
            {
                MessageBox.Show("Aucun Lot sélectionné.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_lotComposantDunLotSelectionnee == null)
            {
                MessageBox.Show("Aucun Composant sélectionné.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_lotComposantDunLotSelectionnee.NumeroLot != _lotSelectionnee.Numero)
            {
                MessageBox.Show("Le Lot selectionné ne contient pas ce composant.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show($"Êtes vous sûr de vouloir supprimer {_lotComposantDunLotSelectionnee.Libelle} du lot {_lotSelectionnee.Libelle} ?"
            , "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            MessageBox.Show($"Le lot composant {_lotComposantDunLotSelectionnee.Libelle} du lot {_lotSelectionnee.Libelle} a bien été supprimé."
                , "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _lotComposantDunLotSelectionnee.NumeroLot = null;
            _serviceLotComposant.Modifier(_lotComposantDunLotSelectionnee);
            _lotSelectionnee.ValeurTotale -= _lotComposantDunLotSelectionnee.Valeur;
            _serviceLot.Modifier(_lotSelectionnee);
            ChargerLots();
            ChargerLotComposants();
            ChargerLotComposantsDunLot();
            ChargerCellOrigine();
        }

        /// <summary>
        /// Remet le formulaire à vide sans sauvegarder les modifications.
        /// </summary>
        private void BoutonEffacer_Click(object sender, EventArgs e)
        {
            Raz_Zones();
        }

        /// <summary>
        /// Gère les clics sur le DataGrid des lots.
        /// Si le clic est sur un en-tête de colonne, trie les données par ordre ASC ou DESC.
        /// Si le clic est sur une cellule, sélectionne le lot, remplit le formulaire
        /// et charge les lots composants associés.
        /// </summary>
        private void DataGridLots_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignorer les clics sur l'en-tête (gérés pour le tri)
            if (e.RowIndex < 0)
            {
                // ordonner sur les champs numero, libelle, valeur totale, rang attribution et est attribue
                Dictionary<int, string> map = new()
                {
                    { dataGridLots.Columns["Numero"].Index, "Numero"},
                    { dataGridLots.Columns["Libelle"].Index, "Libelle" },
                    { dataGridLots.Columns["ValeurTotale"].Index, "ValeurTotale" },
                    { dataGridLots.Columns["RangAttribution"].Index, "RangAttribution" },
                    { dataGridLots.Columns["EstAttribue"].Index, "EstAttribue" }
                };

                // Si la colonne cliquée n'appartient pas aux propriétés ci-dessus, ne rien faire,
                // sinon récupérer le nom de la propriété associée à la colonne cliquée
                if (!map.TryGetValue(e.ColumnIndex, out string? colonne))
                    return;

                // Inverser l’ordre
                ordreChampLots = ordreChampLots == "ASC" ? "DESC" : "ASC";

                // Appliquer le tri
                dataGridLots.DataSource = _serviceLot.Lister(filtre, colonne, ordreChampLots);
                dataGridLots.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection =
                    ordreChampLots == "ASC" ? SortOrder.Ascending : SortOrder.Descending;

                MEP_DataGrid("Lots");
                return;
            }

            // Ne pas recharger le DataSource lors d'un clic sur une cellule : cela réinitialise la sélection
            _lotSelectionnee = dataGridLots.Rows[e.RowIndex].DataBoundItem as Lot;

            if (_lotSelectionnee != null)
            {
                RemplirFormulaireLot(_lotSelectionnee);
                ChargerLotComposantsDunLot();
                ChargerLotComposants();
            }

            boutonModifier.Enabled = _lotSelectionnee != null;
            boutonSupprimerLot.Enabled = _lotSelectionnee != null;
        }

        /// <summary>
        /// Gère les clics sur le DataGrid des lots composants disponibles (non associés à un lot).
        /// Si le clic est sur un en-tête de colonne, trie les données par ordre ASC ou DESC.
        /// Si le clic est sur une cellule, sélectionne le lot composant et remplit la ComboBox.
        /// </summary>
        private void DataGridLotComposants_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignorer les clics sur l'en-tête (gérés pour le tri)
            if (e.RowIndex < 0)
            {
                // ordonner sur les champs numero et libelle
                Dictionary<int, string> map = new()
                {
                    { dataGridLotComposants.Columns["Numero"].Index, "Numero" },
                    { dataGridLotComposants.Columns["Libelle"].Index, "Libelle" }
                };

                // Si la colonne cliquée n'appartient pas aux propriétés ci-dessus, ne rien faire,
                // sinon récupérer le nom de la propriété associée à la colonne cliquée
                if (!map.TryGetValue(e.ColumnIndex, out string? colonne))
                    return;

                // Inverser l’ordre
                ordreChampComposants = ordreChampComposants == "ASC" ? "DESC" : "ASC";

                // Appliquer le tri
                dataGridLotComposants.DataSource = _serviceLotComposant.Lister(filtre, colonne, ordreChampComposants);
                dataGridLotComposants.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection =
                    ordreChampComposants == "ASC" ? SortOrder.Ascending : SortOrder.Descending;

                MEP_DataGrid("LotComposants");
                return;
            }

            // Ne pas recharger le DataSource lors d'un clic sur une cellule : cela réinitialise la sélection
            _lotComposantSelectionnee = dataGridLotComposants.Rows[e.RowIndex].DataBoundItem as LotComposant;

            if (_lotComposantSelectionnee != null)
                RemplirFormulaireLotComposant(_lotComposantSelectionnee);
        }

        /// <summary>
        /// Gère les clics sur le DataGrid des lots composants associés au lot sélectionné.
        /// Si le clic est sur un en-tête de colonne, trie les données par ordre ASC ou DESC.
        /// Si le clic est sur une cellule, sélectionne le lot composant et remplit la ComboBox.
        /// </summary>
        private void DataGridLotComposantsDunLot_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignorer les clics sur l'en-tête (gérés pour le tri)
            if (e.RowIndex < 0)
            {
                // ordonner sur les champs numero et libelle
                Dictionary<int, string> map = new()
                {
                    { dataGridLotComposantsDunLot.Columns["Numero"].Index, "Numero" },
                    { dataGridLotComposantsDunLot.Columns["Libelle"].Index, "Libelle"}
                };
                // Si la colonne cliquée n'appartient pas aux propriétés ci-dessus, ne rien faire,
                // sinon récupérer le nom de la propriété associée à la colonne cliquée
                if (!map.TryGetValue(e.ColumnIndex, out string? colonne))
                    return;

                // Inverser l’ordre
                ordreChampComposantsDunLot = ordreChampComposantsDunLot == "ASC" ? "DESC" : "ASC";

                // Appliquer le tri
                dataGridLotComposantsDunLot.DataSource = _serviceLotComposant.ListerParNumeroDunLot(_lotComposantDunLotSelectionnee.Numero, colonne, ordreChampComposantsDunLot);
                dataGridLotComposantsDunLot.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection =
                    ordreChampComposantsDunLot == "ASC" ? SortOrder.Ascending : SortOrder.Descending;

                MEP_DataGrid("LotComposantsDunLot");
                return;
            }

            // Ne pas recharger le DataSource lors d'un clic sur une cellule : cela réinitialise la sélection
            _lotComposantDunLotSelectionnee = dataGridLotComposantsDunLot.Rows[e.RowIndex].DataBoundItem as LotComposant;

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
        private void TextBoxRecherche_TextChanged(object sender, EventArgs e)
        {
            filtre = textBoxRecherche.Text;
            ChargerLots();
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