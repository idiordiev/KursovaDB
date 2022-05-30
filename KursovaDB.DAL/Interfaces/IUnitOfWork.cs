using System.Threading.Tasks;

namespace KursovaDB.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        ICitizenRepository CitizenRepository { get; }
        IRequestRepository RequestRepository { get; }
        IRequestStatusRepository RequestStatusRepository { get; }
        ISocialServiceRepository SocialServiceRepository { get; }
        ISpecialistRepository SpecialistRepository { get; }

        Task SaveAsync();
    }
}