using Microsoft.EntityFrameworkCore;
using EFCoreUTN.Entities;

namespace EfCoreUTN
{

    public class EFUserContext : DbContext
    {

        public DbSet<Rol> Roles { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Domicilio> Domicilios { get; set; }

        public EFUserContext()
        {

        }

        public EFUserContext(DbContextOptions<EFUserContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Filename=UsersDB.sqlite").LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);


            optionsBuilder.UseSqlServer(
            @"Server=LOCALHOST\SQLEXPRESS19;Database=EFUserDB;Trusted_Connection=True").LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);

            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Domicilios)
            .WithOne().OnDelete(DeleteBehavior.Cascade);
        }

    }

}