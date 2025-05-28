using System.Collections.Generic;
using habilitations2024.Models;
using habilitations2024.DAL;

namespace habilitations2024.Controllers
{
    public class AbsenceController
    {
        private readonly IAbsenceRepository _repo;

        public AbsenceController(IAbsenceRepository repo)
        {
            _repo = repo;
        }

        public List<Absence> GetAllAbsences() => _repo.GetAllAbsences();

        public void AjouterAbsence(Absence a) => _repo.AjouterAbsence(a);

        public void ModifierAbsence(Absence a) => _repo.ModifierAbsence(a);

        public void SupprimerAbsence(int id) => _repo.SupprimerAbsence(id);
    }
}
