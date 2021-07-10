using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BillableTransactionDatabase.Models
{
    public partial class BillableTransactionDBContext : DbContext
    {
        private readonly IConfiguration configuration;
        private static ILogger<BillableTransactionDBContext> _logger;

        public BillableTransactionDBContext(IConfiguration config, ILogger<BillableTransactionDBContext> logger)
        {
            configuration = config;
            _logger = logger;
        }

        public DbSet<Transaction> transaction { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                _logger.LogInformation("DB CONNECTION STRING => " + configuration.GetConnectionString("TransactionsDB"));
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("TransactionsDB"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Amount)
                    .IsRequired()
                    .HasColumnName("amount")
                    .HasMaxLength(50);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.PaymentStatus)
                    .IsRequired()
                    .HasColumnName("paymentStatus");
            });
        }
    }
}
