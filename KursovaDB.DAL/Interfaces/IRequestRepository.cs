using System.Collections.Generic;
using System.Threading.Tasks;
using KursovaDB.DAL.Entities;

namespace KursovaDB.DAL.Interfaces
{
    public interface IRequestRepository : IRepository<Request>
    {
        Task<IEnumerable<Request>> GetAllWithDetailsAsync();
        Task<Request> GetByIdWithDetailsAsync(int id);
    }
}