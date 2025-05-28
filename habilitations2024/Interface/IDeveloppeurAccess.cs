using System.Collections.Generic;

namespace habilitations2024.DAL
{
    /// <summary>
    /// Interface pour l'accès aux données des développeurs.
    /// </summary>
    public interface IDeveloppeurAccess
    {
        List<Modele.Developpeur> GetLesDeveloppeurs(string profil = "");
        List<string> GetLesProfils();
        void AjouterDeveloppeur(Modele.Developpeur d);
        void ModifierDeveloppeur(Modele.Developpeur d);
        void SupprimerDeveloppeur(int id);
    }
}