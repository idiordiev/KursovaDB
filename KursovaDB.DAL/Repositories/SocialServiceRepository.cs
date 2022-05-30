using System.Collections.Generic;
using System.Threading.Tasks;
using KursovaDB.DAL.Data;
using KursovaDB.DAL.Entities;
using KursovaDB.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KursovaDB.DAL.Repositories
{
    public class SocialServiceRepository : ISocialServiceRepository
    {
        private readonly ApplicationDbContext _context;

        public SocialServiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SocialService>> GetAllAsync()
        {
            return await _context.SocialService.ToListAsync();
        }

        public async Task<SocialService> GetByIdAsync(int id)
        {
            return await _context.SocialService.FindAsync(id);
        }

        public async Task AddAsync(SocialService entity)
        {
            await _context.SocialService.AddAsync(entity);
        }

        public void Delete(SocialService entity)
        {
            _context.SocialService.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            SocialService service = await _context.SocialService.FindAsync(id);
            _context.SocialService.Remove(service);
        }

        public void Update(SocialService entity)
        {
            _context.SocialService.Update(entity);
        }

        public async Task<IEnumerable<SocialService>> GetAllWithDetailsAsync()
        {
            return await _context.SocialService.Include(sc => sc.Specialist)
                .ThenInclude(s => s.Request)
                .ThenInclude(r => r.Status)
                .ToListAsync();
        }

        public async Task<SocialService> GetByIdWithDetailsAsync(int id)
        {
            return await _context.SocialService.Include(sc => sc.Specialist)
                .ThenInclude(s => s.Request)
                .ThenInclude(r => r.Status)
                .FirstOrDefaultAsync(sc => sc.Id == id);
        }
    }
}