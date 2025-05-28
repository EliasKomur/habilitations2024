using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using habilitations2024.Controleur;
using habilitations2024.Modele;
using habilitations2024.DAL;

namespace habilitations2024.Tests
{
    /// <summary>
    /// Classe de tests unitaires pour DeveloppeurController.
    /// </summary>
    [TestClass]
    public class DeveloppeurControllerTests
    {
        private DeveloppeurController _controller = null!;

        /// <summary>
        /// Faux accès aux données simulant une base de données.
        /// </summary>
        private class FakeDeveloppeurAccess : IDeveloppeurAccess
        {
            private readonly List<Developpeur> _fakeData = new List<Developpeur>
            {
                new Developpeur { Id = 1, Nom = "Durand", Prenom = "Alice", Profil = "Admin" },
                new Developpeur { Id = 2, Nom = "Martin", Prenom = "Bob", Profil = "User" },
                new Developpeur { Id = 3, Nom = "Dupont", Prenom = "Chloé", Profil = "Admin" },
                new Developpeur { Id = 4, Nom = "Lemoine", Prenom = "David", Profil = "User" },
                new Developpeur { Id = 5, Nom = "Petit", Prenom = "Emma", Profil = "Manager" }
            };

            public List<Developpeur> GetAllDeveloppeurs()
            {
                return _fakeData;
            }

            public List<Developpeur> GetLesDeveloppeurs(string profil)
            {
                if (string.IsNullOrWhiteSpace(profil))
                    return _fakeData;
                else
                    return _fakeData.FindAll(d => d.Profil == profil);
            }

            public List<string> GetLesProfils()
            {
                HashSet<string> profils = new HashSet<string>();
                foreach (var d in _fakeData)
                {
                    profils.Add(d.Profil);
                }
                return new List<string>(profils);
            }

            public void AjouterDeveloppeur(Developpeur developpeur)
            {
                throw new NotImplementedException("Non utilisé dans les tests.");
            }

            public void ModifierDeveloppeur(Developpeur developpeur)
            {
                throw new NotImplementedException("Non utilisé dans les tests.");
            }

            public void SupprimerDeveloppeur(int id)
            {
                throw new NotImplementedException("Non utilisé dans les tests.");
            }
        }

        /// <summary>
        /// Initialise le contrôleur avec le faux accès aux données avant chaque test.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            _controller = new DeveloppeurController(new FakeDeveloppeurAccess());
        }

        /// <summary>
        /// Vérifie que les développeurs pour un profil donné sont correctement filtrés.
        /// </summary>
        [TestMethod]
        public void GetLesDeveloppeurs_ProfilSelectionne_RetourneNombreAttendu()
        {
            // Arrange
            string profilTest = "Admin";
            int nombreAttendu = 2;

            // Act
            List<Developpeur> result = _controller.GetLesDeveloppeurs(profilTest);

            // Assert
            Assert.AreEqual(nombreAttendu, result.Count,
                $"Le nombre de développeurs pour le profil '{profilTest}' doit être {nombreAttendu}.");
        }

        /// <summary>
        /// Vérifie que tous les développeurs sont retournés si aucun profil n’est sélectionné.
        /// </summary>
        [TestMethod]
        public void GetLesDeveloppeurs_AucunProfilSelectionne_RetourneTousLesDeveloppeurs()
        {
            // Arrange
            int nombreTotalAttendu = 5;

            // Act
            List<Developpeur> result1 = _controller.GetLesDeveloppeurs("");
            List<Developpeur> result2 = _controller.GetLesDeveloppeurs(null);

            // Assert
            Assert.AreEqual(nombreTotalAttendu, result1.Count,
                "Tous les développeurs doivent être retournés si le profil est vide.");
            Assert.AreEqual(nombreTotalAttendu, result2.Count,
                "Tous les développeurs doivent être retournés si le profil est null.");
        }
    }
}