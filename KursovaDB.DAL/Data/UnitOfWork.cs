using System.Threading.Tasks;
using KursovaDB.DAL.Interfaces;
using KursovaDB.DAL.Repositories;

namespace KursovaDB.DAL.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        private ICitizenRepository _citizenRepository;
        private IRequestRepository _requestRepository;
        private IRequestStatusRepository _requestStatusRepository;
        private ISocialServiceRepository _socialServiceRepository;
        private ISpecialistRepository _specialistRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICitizenRepository CitizenRepository
        {
            get
            {
                if (_citizenRepository == null)
                    _citizenRepository = new CitizenRepository(_context);
                return _citizenRepository;
            }
        }

        public IRequestRepository RequestRepository
        {
            get
            {
                if (_requestRepository == null)
                    _requestRepository = new RequestRepository(_context);
                return _requestRepository;
            }
        }

        public IRequestStatusRepository RequestStatusRepository
        {
            get
            {
                if (_requestStatusRepository == null)
                    _requestStatusRepository = new RequestStatusRepository(_context);
                return _requestStatusRepository;
            }
        }

        public ISocialServiceRepository SocialServiceRepository
        {
            get
            {
                if (_socialServiceRepository == null)
                    _socialServiceRepository = new SocialServiceRepository(_context);
                return _socialServiceRepository;
            }
        }

        public ISpecialistRepository SpecialistRepository
        {
            get
            {
                if (_specialistRepository == null)
                    _specialistRepository = new SpecialistRepository(_context);
                return _specialistRepository;
            }
        }

        public Task SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}