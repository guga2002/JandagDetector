using ManageLIbrary.Models;
using Microsoft.EntityFrameworkCore;

namespace ManageLIbrary.Dbcontexti
{
    public class GlobalDbContext:DbContext
    {
        public GlobalDbContext(DbContextOptions<GlobalDbContext> ops):base(ops)
        {
                
        }

        public DbSet<Chanell> chanells { get; set; }

    }
}
