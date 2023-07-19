using newLive.Dtos;
using newLive.Models;

namespace newLive.Interfaces
{
    public interface IDiagnoseRepository
    {
        public Task<Dignose?> GetDiagnouseByPID(int pid);

        public Task<Dignose> AddDiagnouseByDoctor(DiagnouseDto diagnouseDto);
    }
}
