using Microsoft.EntityFrameworkCore;

namespace ProductsAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Comanda> Comenzi { get; set; }
        public DbSet<Produs> Produse { get; set; }
        public DbSet<Utilizator > Utilizatori { get; set; }
        public DbSet<ComandaProdus> ComandaProduse {  get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComandaProdus>()
                .HasKey(cp => new { cp.ComandaId, cp.ProdusId });

            modelBuilder.Entity<ComandaProdus>()
                .HasOne(cp => cp.Comanda)
                .WithMany(c => c.ComandaProduse)
                .HasForeignKey(cp => cp.ProdusId);

            modelBuilder.Entity<ComandaProdus>()
                .HasOne(cp => cp.Produs)
                .WithMany(p => p.ComandaProduse)
                .HasForeignKey(cp => cp.ProdusId);

            modelBuilder.Entity<Comanda>()
                .HasOne(c => c.Utilizator)
                .WithMany(u => u.Comenzi)
                .HasForeignKey(c => c.UtilizatorId);
        }
    }
}
