using newLive.Models;

namespace newLive.Interfaces
{
    public interface ILoginRepository
    {
        public Task<Login?> FindByUsernameAndType(string username, string type);
        public Task<Doctorsinfo> GetDoctor();
    }
}
