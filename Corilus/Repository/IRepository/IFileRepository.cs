using Corilus.Models;

namespace Corilus.Repository.IRepository
{
    public interface IFileRepository : IRepository<ErrorFile>
    {
        Task CreateAsync(ErrorFile entity);
     Task<ErrorFile> UpdateAsync(ErrorFile entity);
     
    }
     
}
