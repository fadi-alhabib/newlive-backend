using newLive.Dtos;
using newLive.Models;

namespace newLive.Interfaces
{
    public interface IPatientsRepository
    {
        public Task<IEnumerable<Patientinfo>> GetAllPatients();

        public Task<Patientinfo> AddPatient(PatientsDto patientsDto);

        public Task<Patientinfo?> GetPatientByID(int pid);
    }
}
