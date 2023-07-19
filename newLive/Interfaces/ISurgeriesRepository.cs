using newLive.Dtos;
using newLive.Models;

namespace newLive.Interfaces
{
    public interface ISurgeriesRepository
    {
        public Task<Surgerytblinfo> GetSurgeryByPID(int PID);

        public Task<IEnumerable<Surgerytblinfo>> GetSurgeriesByDoctorName(string doctorName);

        public Task<IEnumerable<Surgerytblinfo>> GetAllSurgeries();

        //public Task<bool> DeleteSurgery(SurgeryDto surgery);

        public Task<Surgerytblinfo> AddSurgery(SurgeryDto surgeryDto);
    }
}
