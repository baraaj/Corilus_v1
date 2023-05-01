using Corilus.Data;
using Corilus.Models;
using Corilus.Repository.IRepository;

namespace Corilus.Repository
{
    public class FileRepository : Repository<ErrorFile>, IFileRepository
    {
        private readonly ApplicationDbContext DbSet;
        public FileRepository(ApplicationDbContext db) : base(db)
        {
            DbSet = db;
        }
        public async Task CreateAsync(ErrorFile entity)
        {
            await DbSet.AddAsync(entity);
            await Save();
        }
         
        public async Task<ErrorFile> UpdateAsync(ErrorFile entity)
        {
            entity.Updated_date = DateTime.Now;
            DbSet.Files.Update(entity);
            await DbSet.SaveChangesAsync();
            return entity;
        }
        
         
    }
}

