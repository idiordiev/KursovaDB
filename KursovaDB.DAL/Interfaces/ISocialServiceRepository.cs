using System.Collections.Generic;
using System.Threading.Tasks;
using KursovaDB.DAL.Entities;

namespace KursovaDB.DAL.Interfaces
{
    public interface ISocialServiceRepository : IRepository<SocialService>
    {
        Task<IEnumerable<SocialService>> GetAllWithDetailsAsync();
        Task<SocialService> GetByIdWithDetailsAsync(int id);
    }
}