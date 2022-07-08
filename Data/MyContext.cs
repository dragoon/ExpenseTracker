using Microsoft.EntityFrameworkCore;
using ExpenseTracking.Models;

namespace ExpenseTracking.Data
{
    public class MyContext : DbContext
    {
        public MyContext (DbContextOptions<MyContext> options)
            : base(options)
        {
        }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expense>().ToTable("Expense");
            modelBuilder.Entity<Currency>().ToTable("Currency");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<ExpenseType>().ToTable("ExpenseType");
        }
    }
}
