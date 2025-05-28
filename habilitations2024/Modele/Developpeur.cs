namespace habilitations2024.Modele
{
    /// <summary>
    /// Représente un développeur avec ses propriétés.
    /// </summary>
    public class Developpeur
    {
        /// <summary>
        /// Identifiant unique du développeur.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nom du développeur.
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Prénom du développeur.
        /// </summary>
        public string Prenom { get; set; }

        /// <summary>
        /// Profil (rôle/fonction) du développeur.
        /// </summary>
        public string Profil { get; set; }
    }
}