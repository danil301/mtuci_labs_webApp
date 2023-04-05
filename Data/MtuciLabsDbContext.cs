using Microsoft.EntityFrameworkCore;
using mtuci_labs.Models;

namespace mtuci_labs.Data
{
    public class MtuciLabsDbContext : DbContext
    {
        public MtuciLabsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Subject> Subjects { get; set; }
    }
}
