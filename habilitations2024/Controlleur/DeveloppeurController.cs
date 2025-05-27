using System.Collections.Generic;

namespace habilitations2024.Controleur
{
    /// <summary>
    /// Contrôleur gérant la logique métier liée aux développeurs.
    /// </summary>
    public class DeveloppeurController
    {
        private readonly DeveloppeurAccess _developpeurAccess = new DeveloppeurAccess();

        /// <summary>
        /// Obtient la liste des profils distincts des développeurs.
        /// </summary>
        /// <returns>Liste des profils</returns>
        public List<string> GetLesProfils()
        {
            try
            {
                return _developpeurAccess.GetLesProfils();
            }
            catch
            {
                // Log ou traitement erreur ici si besoin
                throw;
            }
        }

        /// <summary>
        /// Obtient la liste des développeurs, filtrée par profil si précisé.
        /// </summary>
        /// <param name="profil">Profil à filtrer, optionnel</param>
        /// <returns>Liste des développeurs</returns>
        public List<Developpeur> GetLesDeveloppeurs(string profil = "")
        {
            try
            {
                return _developpeurAccess.GetLesDeveloppeurs(profil);
            }
            catch
            {
                // Log ou traitement erreur ici si besoin
                throw;
            }
        }

        /// <summary>
        /// Ajoute un nouveau développeur.
        /// </summary>
        /// <param name="developpeur">Développeur à ajouter</param>
        public void AjouterDeveloppeur(Developpeur developpeur)
        {
            try
            {
                _developpeurAccess.AjouterDeveloppeur(developpeur);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Modifie un développeur existant.
        /// </summary>
        /// <param name="developpeur">Développeur modifié</param>
        public void ModifierDeveloppeur(Developpeur developpeur)
        {
            try
            {
                _developpeurAccess.ModifierDeveloppeur(developpeur);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Supprime un développeur par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant du développeur à supprimer</param>
        public void SupprimerDeveloppeur(int id)
        {
            try
            {
                _developpeurAccess.SupprimerDeveloppeur(id);
            }
            catch
            {
                throw;
            }
        }
    }
}
