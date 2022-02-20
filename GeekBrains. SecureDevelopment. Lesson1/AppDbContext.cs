using GeekBrains._SecureDevelopment._Lesson1.Models;
using Microsoft.EntityFrameworkCore;

namespace GeekBrains._SecureDevelopment._Lesson1
{
    internal class AppDbContext : DbContext
    {
        internal AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        internal DbSet<Bankcard> ListBankCard { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Data Source=localhost;Initial Catalog=postgrdb;User ID=user;Password=123;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }
    }
}
