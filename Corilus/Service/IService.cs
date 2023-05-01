using Corilus.Models;

namespace Corilus.Service
{
    public interface IService
    {
        Task createFile(IFormFile file);
        Task<IEnumerable<ErrorFile>> GetAllFiles();
        //Task SegmentReceptionFile(IFormFile file,int id);

    }
}
