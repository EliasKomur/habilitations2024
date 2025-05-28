using System.Collections.Generic;
using habilitations2024.Models;

namespace habilitations2024.DAL
{
    public interface IPersonnelRepository
    {
        List<Personnel> GetAllPersonnel();
        void AjouterPersonnel(Personnel p);
        void ModifierPersonnel(Personnel p);
        void SupprimerPersonnel(int id);
    }
}