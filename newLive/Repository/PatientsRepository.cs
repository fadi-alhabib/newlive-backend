using Microsoft.EntityFrameworkCore;
using newLive.Dtos;
using newLive.Interfaces;
using newLive.Models;

namespace newLive.Repository
{
    public class PatientsRepository : IPatientsRepository
    {
        private readonly PatientinfoContext _context;

        public PatientsRepository(PatientinfoContext context)
        {
            _context = context;
        }

        public async Task<Patientinfo> AddPatient(PatientsDto patientsDto)
        {
            Patientinfo patientinfo = new()
            {
                Address = patientsDto.Address,
                Age = patientsDto.Age,
                EMail = patientsDto.EMail,
                Gender = patientsDto.Gender,
                Patientid = patientsDto.Patientid,
                PatientName = patientsDto.PatientName,
                Phonenumber = patientsDto.Phonenumber,
            };
            await _context.Patientinfos.AddAsync(patientinfo);
            _context.SaveChanges();
            return patientinfo;
        }

        public async Task<IEnumerable<Patientinfo>> GetAllPatients() => await _context.Patientinfos.ToListAsync();

        public async Task<Patientinfo?> GetPatientByID(int pid) => await _context.Patientinfos.Where(o => o.Patientid == pid).FirstOrDefaultAsync();

    }
}
