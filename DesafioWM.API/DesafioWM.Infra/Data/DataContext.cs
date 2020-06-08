using DesafioWM.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesafioWM.Infra.Data
{
    public class DataContext : DbContext
    {
        public DbSet<AnuncioEntity> Anuncios { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnuncioEntity>();
        }
    }
}
