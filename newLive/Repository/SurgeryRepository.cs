using Microsoft.EntityFrameworkCore;
using newLive.Dtos;
using newLive.Interfaces;
using newLive.Models;

namespace newLive.Repository
{
    public class SurgeryRepository : ISurgeriesRepository
    {
        private readonly PatientinfoContext _context;

        public SurgeryRepository(PatientinfoContext context)
        {
            _context = context;
        }

        public async Task<Surgerytblinfo> AddSurgery(SurgeryDto surgeryDto)
        {
            Surgerytblinfo surgery = new Surgerytblinfo
            {
                DoctorIdName = surgeryDto.DoctorIdName,
                PatientId = surgeryDto.PatientId,
                SurgeryDate = surgeryDto.SurgeryDate,
                SurgeryRoom = surgeryDto.SurgeryRoom,
                SurgeryTime = surgeryDto.SurgeryTime,
                SurgeryType = surgeryDto.SurgeryType
            };
            await _context.Surgerytblinfos.AddAsync(surgery);
            await _context.SaveChangesAsync();

            return surgery;
        }

        //public async Task<bool> DeleteSurgery(SurgeryDto surgery)
        //{
        //    string sqlQuery = "DELETE FROM surgerytblinfos WHERE surgery_date = @surgery_date AND surgery_room = @surgery_room AND surgery_time = @surgery_time AND surgery_type = @surgery_type AND [doctor ID&Name] = @doctorNID AND [patient ID] = @PID ";
        //    int numberOfEffected = await _context.Database.ExecuteSqlRawAsync(sqlQuery
        //        , new SqlParameter("@surgery_date", surgery.SurgeryDate)
        //        , new SqlParameter("@surgery_room", surgery.SurgeryRoom)
        //        , new SqlParameter("@surgery_time", surgery.SurgeryTime)
        //        , new SqlParameter("@surgery_type", surgery.SurgeryType)
        //        , new SqlParameter("@doctorNID", surgery.DoctorIdName)
        //        , new SqlParameter("@PID", (int)surgery.PatientId)
        //        );
        //    if (numberOfEffected == 0)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        public async Task<IEnumerable<Surgerytblinfo>> GetAllSurgeries() => await _context.Surgerytblinfos.ToListAsync();

        public async Task<IEnumerable<Surgerytblinfo>> GetSurgeriesByDoctorName(string doctorName) => await _context.Surgerytblinfos
            .Where(o => o.DoctorIdName.Contains(doctorName))
            .ToListAsync();

        public async Task<Surgerytblinfo> GetSurgeryByPID(int PID) => await _context.Surgerytblinfos.Where(o => o.PatientId == PID).FirstOrDefaultAsync();

    }
}
