using System.Collections.Generic;
using System.Threading.Tasks;
using KursovaDB.DAL.Data;
using KursovaDB.DAL.Entities;
using KursovaDB.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KursovaDB.DAL.Repositories
{
    public class RequestStatusRepository : IRequestStatusRepository
    {
        private readonly ApplicationDbContext _context;

        public RequestStatusRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<RequestStatus>> GetAllAsync()
        {
            return await _context.RequestStatus.ToListAsync();
        }

        public async Task<RequestStatus> GetByIdAsync(int id)
        {
            return await _context.RequestStatus.FindAsync(id);
        }

        public async Task AddAsync(RequestStatus entity)
        {
            await _context.RequestStatus.AddAsync(entity);
        }

        public void Delete(RequestStatus entity)
        {
            _context.RequestStatus.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            RequestStatus status = await _context.RequestStatus.FindAsync(id);
            _context.RequestStatus.Remove(status);
        }

        public void Update(RequestStatus entity)
        {
            _context.RequestStatus.Update(entity);
        }
    }
}