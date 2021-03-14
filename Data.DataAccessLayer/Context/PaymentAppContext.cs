using Data.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.DataAccessLayer.Context
{
    public class PaymentAppContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public PaymentAppContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>()
                .HasIndex(team => new { team.CreditCardNumber })
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }

        #region DbSets

        public DbSet<Payment> Payments { get; set; }

        #endregion
    }
}
