using DACA.Models;
using Microsoft.EntityFrameworkCore;

namespace DACA
{
    public class EduBD_context : DbContext
    {
        public EduBD_context(): base()
        { 
        }
        public EduBD_context(DbContextOptions<EduBD_context> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Class> Classes{ get; set; }
        public DbSet<Students> Students { get; set; }
    }
}
