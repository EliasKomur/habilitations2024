using System.Collections.Generic;
using habilitations2024.Models;
using habilitations2024.DAL;

namespace habilitations2024.Controllers
{
    public class PersonnelController
    {
        private readonly IPersonnelRepository _repo;

        public PersonnelController(IPersonnelRepository repo)
        {
            _repo = repo;
        }

        public List<Personnel> GetAllPersonnel() => _repo.GetAllPersonnel();

        public void AjouterPersonnel(Personnel p) => _repo.AjouterPersonnel(p);

        public void ModifierPersonnel(Personnel p) => _repo.ModifierPersonnel(p);

        public void SupprimerPersonnel(int id) => _repo.SupprimerPersonnel(id);
    }
}