using System.Collections.Generic;
using System.Threading.Tasks;
using KursovaDB.DAL.Entities;

namespace KursovaDB.DAL.Interfaces
{
    public interface ICitizenRepository : IRepository<Citizen>
    {
        Task<IEnumerable<Citizen>> GetAllWithDetailsAsync();
        Task<Citizen> GetByIdWithDetailsAsync(int id);
    }
}