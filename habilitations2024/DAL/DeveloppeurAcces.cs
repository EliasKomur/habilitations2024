using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace habilitations2024
{
    public class DeveloppeurAccess
    {
        // Chaîne de connexion vers la base MySQL, adapte si besoin
        private readonly string connexionString = "server=localhost;uid=root;pwd=EK7_stesteve;database=habilitations2024;";

        /// <summary>
        /// Retourne la liste des développeurs, filtrée par profil si indiqué.
        /// </summary>
        /// <param name="profil">Profil à filtrer, ou null/chaine vide pour tous les développeurs</param>
        /// <returns>Liste des développeurs</returns>
        public List<Developpeur> GetLesDeveloppeurs(string profil = "")
        {
            var liste = new List<Developpeur>();

            try
            {
                using (var connexion = new MySqlConnection(connexionString))
                {
                    connexion.Open();

                    string requete = "SELECT Id, Nom, Prenom, Profil FROM developpeur";

                    if (!string.IsNullOrEmpty(profil))
                    {
                        requete += " WHERE Profil = @profil";
                    }

                    using (var cmd = new MySqlCommand(requete, connexion))
                    {
                        if (!string.IsNullOrEmpty(profil))
                        {
                            cmd.Parameters.AddWithValue("@profil", profil);
                        }

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                liste.Add(new Developpeur
                                {
                                    Id = reader.GetInt32("Id"),
                                    Nom = reader.GetString("Nom"),
                                    Prenom = reader.GetString("Prenom"),
                                    Profil = reader.GetString("Profil")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log ou gestion personnalisée ici (throw ou retour vide)
                Console.WriteLine("Erreur lors de la récupération des développeurs : " + ex.Message);
                // Tu peux aussi choisir de relancer l’exception : throw;
            }

            return liste;
        }

        /// <summary>
        /// Ajoute un développeur dans la base.
        /// </summary>
        public void AjouterDeveloppeur(Developpeur d)
        {
            try
            {
                using (var connexion = new MySqlConnection(connexionString))
                {
                    connexion.Open();
                    string requete = "INSERT INTO developpeur (Nom, Prenom, Profil) VALUES (@nom, @prenom, @profil)";
                    using (var cmd = new MySqlCommand(requete, connexion))
                    {
                        cmd.Parameters.AddWithValue("@nom", d.Nom);
                        cmd.Parameters.AddWithValue("@prenom", d.Prenom);
                        cmd.Parameters.AddWithValue("@profil", d.Profil);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de l'ajout du développeur : " + ex.Message);
                throw; // Relance pour informer appelant
            }
        }

        /// <summary>
        /// Modifie un développeur existant.
        /// </summary>
        public void ModifierDeveloppeur(Developpeur d)
        {
            try
            {
                using (var connexion = new MySqlConnection(connexionString))
                {
                    connexion.Open();
                    string requete = "UPDATE developpeur SET Nom=@nom, Prenom=@prenom, Profil=@profil WHERE Id=@id";
                    using (var cmd = new MySqlCommand(requete, connexion))
                    {
                        cmd.Parameters.AddWithValue("@nom", d.Nom);
                        cmd.Parameters.AddWithValue("@prenom", d.Prenom);
                        cmd.Parameters.AddWithValue("@profil", d.Profil);
                        cmd.Parameters.AddWithValue("@id", d.Id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la modification du développeur : " + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Supprime un développeur par son Id.
        /// </summary>
        public void SupprimerDeveloppeur(int id)
        {
            try
            {
                using (var connexion = new MySqlConnection(connexionString))
                {
                    connexion.Open();
                    string requete = "DELETE FROM developpeur WHERE Id=@id";
                    using (var cmd = new MySqlCommand(requete, connexion))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la suppression du développeur : " + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Retourne la liste des profils distincts dans la table développeurs.
        /// </summary>
        public List<string> GetLesProfils()
        {
            var profils = new List<string>();

            try
            {
                using (var connexion = new MySqlConnection(connexionString))
                {
                    connexion.Open();
                    string requete = "SELECT DISTINCT Profil FROM developpeur ORDER BY Profil";
                    using (var cmd = new MySqlCommand(requete, connexion))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            profils.Add(reader.GetString("Profil"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la récupération des profils : " + ex.Message);
                throw;
            }

            return profils;
        }
    }

    /// <summary>
    /// Modèle représentant un développeur.
    /// </summary>
    public class Developpeur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Profil { get; set; }
    }
}
