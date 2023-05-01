using AutoMapper;
using Corilus.Models;
using Corilus.Repository.IRepository;

namespace Corilus.Service
{
    public class Service: IService
    {
        private readonly IFileRepository _dbFile;

        private readonly IMapper _mapper;

        public Task createFile(IFormFile file)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ErrorFile>> GetAllFiles()
        {
            throw new NotImplementedException();
        }
    }
}
