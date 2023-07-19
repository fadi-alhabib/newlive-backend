
using Microsoft.EntityFrameworkCore;
using newLive.Interfaces;
using newLive.Models;


namespace newLive.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly PatientinfoContext _context;

        public LoginRepository(PatientinfoContext dbContext)
        {
            _context = dbContext;

        }

        public async Task<Login?> FindByUsernameAndType(string username, string type)
        {
            return await _context.Logins.Where(l => l.Username == username && l.Usertype == type).FirstAsync();
        }

        public async Task<Doctorsinfo> GetDoctor()
        {
            return await _context.Doctorsinfos.FirstAsync();
        }
    }
}
