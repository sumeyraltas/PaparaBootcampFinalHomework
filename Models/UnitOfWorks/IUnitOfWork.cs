using Microsoft.EntityFrameworkCore.Storage;

namespace PaparaBootcampFinalHomework.Models.UnitOfWorks
{
    public interface IUnitOfWork
    {
        int Commit();
        Task<int> CommitAsync();
        IDbContextTransaction BeginTransaction();
    }
}