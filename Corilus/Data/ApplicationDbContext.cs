using Corilus.Models;
using Microsoft.EntityFrameworkCore;

namespace Corilus.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<ErrorFile> Files { get; set; }
        public DbSet<RecordModel> Records { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ErrorFile>().HasData(
                new ErrorFile()
                {
                    Id = 1,
                    Name = "Facturation1",
                    Size = 52,
                    Description = "Description du premier fichier de facturation 1",
                    Content = "Content 1",
                    Created_date = DateTime.Now
                },
                new ErrorFile()
                {
                    Id = 2,
                    Name = "Facturation2",
                    Size = 42,
                    Description = "Description du premier fichier de facturation 2",
                    Content = "Content 2",
                    Created_date = DateTime.Now,
                    Records = new RecordModel(),
                }
                ) ;
            modelBuilder.Entity<RecordModel>(entity => { entity.HasKey(e => e.Id);
            });
            modelBuilder.Entity<ErrorFile>(entity => {
                entity.HasKey(e => e.Id);
            });
            ;
            
        }

    }

}
    