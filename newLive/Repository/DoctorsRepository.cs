using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using newLive.Dtos;
using newLive.Interfaces;
using newLive.Models;
using System.Data;

namespace newLive.Repository
{
    public class DoctorsRepository : IDoctorsRepository
    {
        private readonly PatientinfoContext _context;

        public DoctorsRepository(PatientinfoContext dbContext)
        {
            _context = dbContext;

        }
        public async Task<Doctorsinfo> AddDoctor(DoctorsDto doctorDto)
        {
            Doctorsinfo doctor = new Doctorsinfo
            {
                DoctorId = doctorDto.DoctorId,
                DEmail = doctorDto.DEmail,
                DAddress = doctorDto.DAddress,
                DGender = doctorDto.DGender,
                DoctorAge = doctorDto.DoctorAge,
                DoctorName = doctorDto.DoctorName,
                DPhone = doctorDto.DPhone,
                DSpcelization = doctorDto.DSpcelization,
                HireDate = DateTime.UtcNow
            };
            await _context.Doctorsinfos.AddAsync(doctor);
            _context.SaveChanges();
            return doctor;
        }

        public async Task<bool> DeleteDoctorById(int id)
        {
            Doctorsinfo doctor = await _context.Doctorsinfos.Where(d => d.DoctorId == id).FirstOrDefaultAsync();
            if (doctor == null)
            {
                return false;
            }
            _context.Doctorsinfos.Remove(doctor);
            await _context.SaveChangesAsync();
            return true;
        }

        [Authorize(Roles = "doctor")]
        public async Task<IEnumerable<DoctorsWithSectionsDto>> GetAllDoctorsWithSections()
        {
            IEnumerable<DoctorsWithSectionsDto> doctors = await _context.Doctorssections
                .Include(s => s.Sections)
                .Select(o => new DoctorsWithSectionsDto
                {
                    DoctorId = o.DoctorId,
                    Doctorname = o.Doctorname,
                    SectionName = o.Sections.Sectionsname
                }).ToListAsync();

            return doctors;
        }
    }
}
