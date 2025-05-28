using System.Collections.Generic;
using habilitations2024.Models;

namespace habilitations2024.DAL
{
    public interface IAbsenceRepository
    {
        List<Absence> GetAllAbsences();
        void AjouterAbsence(Absence a);
        void ModifierAbsence(Absence a);
        void SupprimerAbsence(int id);
    }
}