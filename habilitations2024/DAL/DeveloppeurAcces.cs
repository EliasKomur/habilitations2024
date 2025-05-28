using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace habilitations2024.DAL
{
    /// <summary>
    /// Classe d'accès aux données pour la table "developpeur".
    /// </summary>
    public class DeveloppeurAccess : IDeveloppeurAccess
    {
        private string connexionString = "server=localhost;uid=root;pwd=EK7_stesteve;database=habilitations2024;";

        /// <summary>
        /// Retourne la liste des développeurs, filtrée par profil si spécifié.
        /// </summary>
        public List<Modele.Developpeur> GetLesDeveloppeurs(string profil = "")
        {
            List<Modele.Developpeur> liste = new List<Modele.Developpeur>();
            MySqlConnection connexion = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;

            try
            {
                connexion = new MySqlConnection(connexionString);
                connexion.Open();

                string requete = "SELECT Id, Nom, Prenom, Profil FROM developpeur";
                if (!string.IsNullOrEmpty(profil))
                {
                    requete += " WHERE Profil = @profil";
                }

                cmd = new MySqlCommand(requete, connexion);

                if (!string.IsNullOrEmpty(profil))
                {
                    cmd.Parameters.AddWithValue("@profil", profil);
                }

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Modele.Developpeur d = new Modele.Developpeur();
                    d.Id = reader.GetInt32("Id");
                    d.Nom = reader.GetString("Nom");
                    d.Prenom = reader.GetString("Prenom");
                    d.Profil = reader.GetString("Profil");
                    liste.Add(d);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la récupération des développeurs : " + ex.Message);
                // Optionnel : throw; si tu veux remonter l'exception
            }
            finally
            {
                if (reader != null) { reader.Close(); reader.Dispose(); }
                if (cmd != null) { cmd.Dispose(); }
                if (connexion != null) { connexion.Close(); connexion.Dispose(); }
            }

            return liste;
        }

        /// <summary>
        /// Ajoute un nouveau développeur.
        /// </summary>
        public void AjouterDeveloppeur(Modele.Developpeur d)
        {
            MySqlConnection connexion = null;
            MySqlCommand cmd = null;
            try
            {
                connexion = new MySqlConnection(connexionString);
                connexion.Open();

                string requete = "INSERT INTO developpeur (Nom, Prenom, Profil) VALUES (@nom, @prenom, @profil)";
                cmd = new MySqlCommand(requete, connexion);
                cmd.Parameters.AddWithValue("@nom", d.Nom);
                cmd.Parameters.AddWithValue("@prenom", d.Prenom);
                cmd.Parameters.AddWithValue("@profil", d.Profil);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de l'ajout du développeur : " + ex.Message);
                throw;
            }
            finally
            {
                if (cmd != null) { cmd.Dispose(); }
                if (connexion != null) { connexion.Close(); connexion.Dispose(); }
            }
        }

        /// <summary>
        /// Modifie un développeur existant.
        /// </summary>
        public void ModifierDeveloppeur(Modele.Developpeur d)
        {
            MySqlConnection connexion = null;
            MySqlCommand cmd = null;
            try
            {
                connexion = new MySqlConnection(connexionString);
                connexion.Open();

                string requete = "UPDATE developpeur SET Nom=@nom, Prenom=@prenom, Profil=@profil WHERE Id=@id";
                cmd = new MySqlCommand(requete, connexion);
                cmd.Parameters.AddWithValue("@nom", d.Nom);
                cmd.Parameters.AddWithValue("@prenom", d.Prenom);
                cmd.Parameters.AddWithValue("@profil", d.Profil);
                cmd.Parameters.AddWithValue("@id", d.Id);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la modification du développeur : " + ex.Message);
                throw;
            }
            finally
            {
                if (cmd != null) { cmd.Dispose(); }
                if (connexion != null) { connexion.Close(); connexion.Dispose(); }
            }
        }

        /// <summary>
        /// Supprime un développeur par son identifiant.
        /// </summary>
        public void SupprimerDeveloppeur(int id)
        {
            MySqlConnection connexion = null;
            MySqlCommand cmd = null;
            try
            {
                connexion = new MySqlConnection(connexionString);
                connexion.Open();

                string requete = "DELETE FROM developpeur WHERE Id=@id";
                cmd = new MySqlCommand(requete, connexion);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la suppression du développeur : " + ex.Message);
                throw;
            }
            finally
            {
                if (cmd != null) { cmd.Dispose(); }
                if (connexion != null) { connexion.Close(); connexion.Dispose(); }
            }
        }

        /// <summary>
        /// Retourne la liste des profils distincts.
        /// </summary>
        public List<string> GetLesProfils()
        {
            List<string> profils = new List<string>();
            MySqlConnection connexion = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;

            try
            {
                connexion = new MySqlConnection(connexionString);
                connexion.Open();

                string requete = "SELECT DISTINCT Profil FROM developpeur ORDER BY Profil";
                cmd = new MySqlCommand(requete, connexion);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    profils.Add(reader.GetString("Profil"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la récupération des profils : " + ex.Message);
                throw;
            }
            finally
            {
                if (reader != null) { reader.Close(); reader.Dispose(); }
                if (cmd != null) { cmd.Dispose(); }
                if (connexion != null) { connexion.Close(); connexion.Dispose(); }
            }

            return profils;
        }
    }
}
