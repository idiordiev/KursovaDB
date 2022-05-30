using System.Collections.Generic;
using System.Threading.Tasks;
using KursovaDB.DAL.Entities;

namespace KursovaDB.DAL.Interfaces
{
    public interface ISpecialistRepository : IRepository<Specialist>
    {
        Task<IEnumerable<Specialist>> GetAllWithDetailsAsync();
        Task<Specialist> GetByIdWithDetailsAsync(int id);
    }
}