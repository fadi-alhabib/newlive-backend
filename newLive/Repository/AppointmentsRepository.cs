using Microsoft.EntityFrameworkCore;
using newLive.Dtos;
using newLive.Interfaces;
using newLive.Models;

namespace newLive.Repository
{
    public class AppointmentsRepository : IAppointmentsRepository
    {
        private readonly PatientinfoContext _context;

        public AppointmentsRepository(PatientinfoContext context)
        {
            _context = context;
        }

        public async Task<Booktbl> AddAppointment(AppointmentsDto appointmentDto)
        {
            Booktbl appointment = new()
            {
                Bookdoctor = appointmentDto.Bookdoctor,
                Bookname = appointmentDto.Bookname,
                Booksection = appointmentDto.Booksection,
                Bookdate = appointmentDto.Bookdate,
            };
            string sqlQuery = "INSERT INTO booktbl(bookdoctor, bookname, booksection, bookdate) VALUES ({0}, {1}, {2}, {3})";
            await _context.Database.ExecuteSqlRawAsync(
                sqlQuery,
                appointmentDto.Bookdoctor,
                appointmentDto.Bookname,
                appointmentDto.Booksection,
                appointmentDto.Bookdate
                );
            return appointment;
        }
        public async Task<IEnumerable<Booktbl>> GetAllAppointments() => await _context.Booktbls.ToListAsync();


        public async Task<Booktbl> GetAppointmentByPName(string pName) => await _context.Booktbls.Where(o => o.Bookname == pName).FirstOrDefaultAsync();

    }
}
