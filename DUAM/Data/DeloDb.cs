using DUAM.Models;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DUAM.Data
{
    class DeloDb : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DeloDb(DbContextOptions<DeloDb> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasNoKey();
        }
    }
}
