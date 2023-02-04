using CRUD.Models;
using CRUD.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRUD
{
    public class Contexto : DbContext
    {
        public DbSet<Musica> Musicas { get; set; }
        public DbSet<Cantor> Cantor { get; set; }       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Musica>().HasOne(m => m.Cantor).WithOne().HasForeignKey("Cantor");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder op)
        {
            op.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MusicasDB;Trusted_Connection=true;");
        }
    }
}
