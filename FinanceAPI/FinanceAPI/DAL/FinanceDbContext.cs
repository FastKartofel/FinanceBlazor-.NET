using Microsoft.EntityFrameworkCore;

namespace FinanceAPI.DAL
{
    public class FinanceDbContext : DbContext
    {
        public FinanceDbContext(DbContextOptions<FinanceDbContext> options) : base(options) { }

        public FinanceDbContext() { }

        public DbSet<User> Users { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Watchlist> Watchlists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Watchlist>()
                .HasKey(w => w.WatchlistId);

            modelBuilder.Entity<Watchlist>()
                .HasOne(w => w.User)
                .WithMany(u => u.Watchlists)
                .HasForeignKey(w => w.UserId);

            // Configure the many-to-many relationship
            modelBuilder.Entity<Watchlist>()
                .HasMany(w => w.Companies)
                .WithMany(c => c.Watchlists)
                .UsingEntity(j => j.ToTable("WatchlistCompanies"));
        }
    }
}