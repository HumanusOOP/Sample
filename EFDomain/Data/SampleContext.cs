using Microsoft.EntityFrameworkCore;

namespace EFDomain.Data
{
    public class SampleContext : DbContext
    {
        public SampleContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Value> Entities { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}
