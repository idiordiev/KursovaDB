using System.Collections.Generic;
using System.Threading.Tasks;
using KursovaDB.DAL.Data;
using KursovaDB.DAL.Entities;
using KursovaDB.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KursovaDB.DAL.Repositories
{
    public class SpecialistRepository : ISpecialistRepository
    {
        private readonly ApplicationDbContext _context;

        public SpecialistRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Specialist>> GetAllAsync()
        {
            return await _context.Specialist.ToListAsync();
        }

        public async Task<Specialist> GetByIdAsync(int id)
        {
            return await _context.Specialist.FindAsync(id);
        }

        public async Task AddAsync(Specialist entity)
        {
            await _context.Specialist.AddAsync(entity);
        }

        public void Delete(Specialist entity)
        {
            _context.Specialist.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            Specialist specialist = await _context.Specialist.FindAsync(id);
            _context.Specialist.Remove(specialist);
        }

        public void Update(Specialist entity)
        {
            _context.Specialist.Update(entity);
        }

        public async Task<IEnumerable<Specialist>> GetAllWithDetailsAsync()
        {
            return await _context.Specialist.Include(s => s.Service)
                .Include(s => s.Request)
                .ThenInclude(r => r.Status)
                .ToListAsync();
        }

        public async Task<Specialist> GetByIdWithDetailsAsync(int id)
        {
            return await _context.Specialist.Include(s => s.Service)
                .Include(s => s.Request)
                .ThenInclude(r => r.Status)
                .FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}