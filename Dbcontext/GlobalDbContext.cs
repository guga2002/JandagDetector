using db.Models;
using Microsoft.EntityFrameworkCore;

namespace ManageLIbrary.Dbcontexti
{
    public class GlobalDbContext:DbContext
    {
        public GlobalDbContext(DbContextOptions<GlobalDbContext> ops):base(ops)
        {
                
        }

        public DbSet<Chanell> chanells { get; set; }
        public DbSet<ChanellSource> chnaellSource { get; set; }
        public DbSet<Desclamber> Desclambers { get; set; }
        public DbSet<Packages> Packgages { get; set; }

        public DbSet<Reciever> Recievers { get; set; }

        public DbSet<Status> Status { get; set; }

        public DbSet<Transcoder> Transcoder { get; set; }

    }
}
