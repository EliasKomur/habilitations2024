using MySql.Data.MySqlClient;

namespace habilitations2024.DAL
{
    /// <summary>
    /// Gestionnaire de la connexion MySQL.
    /// </summary>
    public static class Connexion
    {
        /// <summary>
        /// Retourne une connexion MySQL configurée.
        /// </summary>
        public static MySqlConnection GetConnexion()
        {
            string connexionString = "server=localhost;database=habilitations2024;uid=root;pwd=EK7_stesteve;";
            return new MySqlConnection(connexionString);
        }
    }
}