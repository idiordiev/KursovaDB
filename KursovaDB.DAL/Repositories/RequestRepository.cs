using System.Collections.Generic;
using System.Threading.Tasks;
using KursovaDB.DAL.Data;
using KursovaDB.DAL.Entities;
using KursovaDB.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KursovaDB.DAL.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly ApplicationDbContext _context;

        public RequestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Request>> GetAllAsync()
        {
            return await _context.Request.ToListAsync();
        }

        public async Task<Request> GetByIdAsync(int id)
        {
            return await _context.Request.FindAsync(id);
        }

        public async Task AddAsync(Request entity)
        {
            await _context.Request.AddAsync(entity);
        }

        public void Delete(Request entity)
        {
            _context.Request.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            Request request = await _context.Request.FindAsync(id);
            _context.Request.Remove(request);
        }

        public void Update(Request entity)
        {
            _context.Request.Update(entity);
        }

        public async Task<IEnumerable<Request>> GetAllWithDetailsAsync()
        {
            return await _context.Request.Include(r => r.Status)
                .Include(r => r.Citizen)
                .Include(r => r.Specialist)
                .ThenInclude(s => s.Service)
                .ToListAsync();
        }

        public async Task<Request> GetByIdWithDetailsAsync(int id)
        {
            return await _context.Request.Include(r => r.Status)
                .Include(r => r.Citizen)
                .Include(r => r.Specialist)
                .ThenInclude(s => s.Service)
                .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}