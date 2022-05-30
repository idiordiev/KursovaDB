using System.Collections.Generic;
using System.Threading.Tasks;
using KursovaDB.DAL.Data;
using KursovaDB.DAL.Entities;
using KursovaDB.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KursovaDB.DAL.Repositories
{
    public class CitizenRepository : ICitizenRepository
    {
        private readonly ApplicationDbContext _context;

        public CitizenRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Citizen>> GetAllAsync()
        {
            return await _context.Citizen.ToListAsync();
        }

        public async Task<Citizen> GetByIdAsync(int id)
        {
            return await _context.Citizen.FindAsync(id);
        }

        public async Task AddAsync(Citizen entity)
        {
            await _context.Citizen.AddAsync(entity);
        }

        public void Delete(Citizen entity)
        {
            _context.Citizen.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            Citizen citizen = await _context.Citizen.FindAsync(id);
            _context.Citizen.Remove(citizen);
        }

        public void Update(Citizen entity)
        {
            _context.Citizen.Update(entity);
        }

        public async Task<IEnumerable<Citizen>> GetAllWithDetailsAsync()
        {
            return await _context.Citizen.Include(c => c.Request)
                .ThenInclude(r => r.Status)
                .ToListAsync();
        }

        public async Task<Citizen> GetByIdWithDetailsAsync(int id)
        {
            return await _context.Citizen.Include(c => c.Request)
                .ThenInclude(r => r.Status)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}