using GeekBrains._SecureDevelopment._Lesson1.Models;
using Microsoft.EntityFrameworkCore;

namespace GeekBrains._SecureDevelopment._Lesson1
{
    internal class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        internal AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        internal DbSet<Bankcard> listbankcard { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=host.docker.internal;Port=5432;Database=postgrdb;Username=user;Password=123");

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.HasDefaultSchema("TECHREP");
        //}

    }
}
