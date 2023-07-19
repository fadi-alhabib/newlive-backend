using newLive.Dtos;
using newLive.Models;

namespace newLive.Interfaces
{
    public interface IAppointmentsRepository
    {
        public Task<IEnumerable<Booktbl>> GetAllAppointments();

        public Task<Booktbl> GetAppointmentByPName(string pName);

        public Task<Booktbl> AddAppointment(AppointmentsDto appointment);

        //public Task<bool> DeleteAppointmentByPName(string pName);
    }
}
