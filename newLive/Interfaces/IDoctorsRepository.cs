using newLive.Dtos;
using newLive.Models;

namespace newLive.Interfaces
{
    public interface IDoctorsRepository
    {
        public Task<IEnumerable<DoctorsWithSectionsDto>> GetAllDoctorsWithSections();
        public Task<bool> DeleteDoctorById(int id);

        public Task<Doctorsinfo> AddDoctor(DoctorsDto doctorDto);

    }
}
