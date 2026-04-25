using Lib_Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Services.Interfaces
{
    public interface IOrganisateurService
    {
        #region Lecture
        /// <summary>
        ///  Retourne la liste complète des organisateurs présents en base, 
        ///  avec possibilité de filtrer
        ///  
        ///  Permet également de trier les résultats par une colonne spécifiée 
        ///  (Login, Mail, NomRole) 
        ///  et dans un ordre donné (ASC ou DESC).
        /// </summary>
        /// <param name="filtre">Optionnel, filtre</param>
        /// <param name="propriete">Optionnel, propriété de trie</param>
        /// <param name="ordre">Optionnel, ordre de trie</param>
        /// <returns>Liste d'objets <see cref="Organisateur"/>.</returns>
        List<Organisateur> Lister(string filtre = "", string propriete = "", string ordre = "");

        /// <summary>
        /// Récupère un organisateur par son login.
        /// </summary>
        /// <param name="Login">Login de l'organisateur cherché.</param>
        /// <returns>L'entité <see cref="Organisateur"/> si trouvée, sinon null.</returns>
        Organisateur? Obtenir(string Login);
        #endregion
        #region CUD
        /// <summary>
        /// Crée un nouvel organisateur en base.
        /// Appelle immédiatement <c>SaveChanges()</c> pour persister l'entité.
        /// </summary>
        /// <param name="organisateur">Instance de <see cref="Organisateur"/> à créer.</param>
        void Creer(Organisateur organisateur);

        /// <summary>
        /// Met à jour un organisateur existant.
        /// L'appel à <c>Update</c> marque toutes les propriétés comme modifiées.
        /// </summary>
        /// <param name="organisateur">Instance modifiée de <see cref="Organisateur"/>.</param>
        void Modifier(Organisateur organisateur);

        /// <summary>
        /// Supprime un organisateur identifié par son login s'il existe.
        /// </summary>
        /// <param name="login">login de l'organisateur à supprimer.</param>
        void Supprimer(string login);
        #endregion
        #region Validations
        /// <summary>
        /// Vérifie si les informations d'identification fournies correspondent à un organisateur existant.
        /// </summary>
        /// <param name="motDePasse">Le mot de passe hashé de l'organisateur.</param>
        /// <param name="identifiant">Le login de l'organisateur.</param>
        /// <returns>True si il est identique, false si non</returns>
        bool EstIdentique(string motDePasse, string login);

        /// <summary>
        /// Retourne si l'organisateur peut faire une action en rapport avec un userController
        /// Consulter - Modifier - Supprimer - Ajouter
        /// </summary>
        /// <returns>true si il a l'autorisation, sinon false.</returns>
        bool estAutoriser(Organisateur organisateur, Organisateur.LesUC unUC, string action);

        /// <summary>
        /// Permet de voir si un mot de passe est conformes aux règles de sécurité suivantes 
        /// </summary>
        /// <param name="motDePasse"></param>
        /// <returns>la liste des msgs d'erreurs.</returns>
        List<string> MdpValide(string motDePasse);

        /// <summary>
        /// Permet de voir si un identifiant est conformes aux règles de sécurité suivantes
        /// </summary>
        /// <param name="identifiant"></param>
        /// <returns>la liste des msgs d'erreurs.</returns>
        List<string> IdentifiantValide(string identifiant);
        #endregion
    }
}
