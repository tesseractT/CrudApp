using CrudWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudWebApp.Data
{
    public class CrudDbContext: DbContext
    {
        public CrudDbContext(DbContextOptions<CrudDbContext> options):base(options)
        {

        }

        public DbSet<Candidates> CandidateInfo { get; set; }
    }

}
