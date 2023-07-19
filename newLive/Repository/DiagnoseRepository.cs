using newLive.Dtos;
using newLive.Interfaces;
using newLive.Models;

namespace newLive.Repository
{
    public class DiagnoseRepository : IDiagnoseRepository
    {
        private readonly PatientinfoContext _context;

        public DiagnoseRepository(PatientinfoContext context)
        {
            _context = context;
        }

        public async Task<Dignose> AddDiagnouseByDoctor(DiagnouseDto diagnouseDto)
        {
            Dignose diagnouse = new()
            {
                Digognses = diagnouseDto.Digognses,
                DoctorName = diagnouseDto.DoctorName,
                PatientId = diagnouseDto.PatientId,
                PatientName = diagnouseDto.PatientName
            };
            await _context.Dignoses.AddAsync(diagnouse);
            _context.SaveChanges();
            return diagnouse;
        }

        public async Task<Dignose?> GetDiagnouseByPID(int pid)
        {
            Dignose? dignose = await _context.Dignoses.FindAsync(pid);
            return dignose;
        }
    }
}
