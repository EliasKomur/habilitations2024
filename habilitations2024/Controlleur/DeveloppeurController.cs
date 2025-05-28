using System;
using System.Collections.Generic;
using habilitations2024.DAL;
using habilitations2024.Modele;

namespace habilitations2024.Controleur
{
    /// <summary>
    /// Contrôleur pour la gestion métier des développeurs.
    /// </summary>
    public class DeveloppeurController
    {
        private readonly IDeveloppeurAccess _developpeurAccess;

        /// <summary>
        /// Injection de la dépendance pour l'accès aux données.
        /// </summary>
        public DeveloppeurController(IDeveloppeurAccess developpeurAccess)
        {
            _developpeurAccess = developpeurAccess;
        }

        /// <summary>
        /// Retourne la liste des profils distincts.
        /// </summary>
        public List<string> GetLesProfils()
        {
            try
            {
                return _developpeurAccess.GetLesProfils();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Retourne la liste des développeurs, filtrée par profil si besoin.
        /// </summary>
        public List<Developpeur> GetLesDeveloppeurs(string profil = "")
        {
            try
            {
                return _developpeurAccess.GetLesDeveloppeurs(profil);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Ajoute un développeur.
        /// </summary>
        public void AjouterDeveloppeur(Developpeur d)
        {
            _developpeurAccess.AjouterDeveloppeur(d);
        }

        /// <summary>
        /// Modifie un développeur.
        /// </summary>
        public void ModifierDeveloppeur(Developpeur d)
        {
            _developpeurAccess.ModifierDeveloppeur(d);
        }

        /// <summary>
        /// Supprime un développeur par son Id.
        /// </summary>
        public void SupprimerDeveloppeur(int id)
        {
            _developpeurAccess.SupprimerDeveloppeur(id);
        }
    }
}
