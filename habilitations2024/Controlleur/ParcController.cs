using System.Collections.Generic;
using habilitations2024.Models;
using habilitations2024.DAL;

namespace habilitations2024.Controllers
{
    public class ParcController
    {
        private readonly IParcRepository _repo;

        public ParcController(IParcRepository repo)
        {
            _repo = repo;
        }

        public List<Parc> GetAllParc() => _repo.GetAllParc();

        public void AjouterParc(Parc p) => _repo.AjouterParc(p);

        public void ModifierParc(Parc p) => _repo.ModifierParc(p);

        public void SupprimerParc(int id) => _repo.SupprimerParc(id);
    }
}
