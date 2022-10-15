using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace VivaBillingNewWeb.Database
{
    public class DBConnection:DbContext
    {
        public DbSet<States> states { get; set; }
        public DbSet<Countries> countries { get; set; }
        public DbSet<Customers> customers { get; set; }
        public DbSet<Sizes> sizes { get; set; }
        public DbSet<Products> products { get; set; }
        public DbSet<PaymentMethods> paymentMethods { get; set; }
        public DbSet<ProductTypes> productTypes { get; set; }
        public DbSet<Jobs> jobs { get; set; }
        public DbSet<Prices> prices { get; set; }
        public DbSet<Invoices> invoices { get; set; }
        public DbSet<EmailVerifications> emailVerifications { get; set; }
        public DbSet<MobileVerifications> mobileVerifications { get; set; }
        public DbSet<Logins> logins { get; set; }
        public DbSet<Commands> commands { get; set; }
        public DbSet<DailyCount> dailyCount { get; set; }
        public DbSet<MacAddresses> macAddresses { get; set; }
        
       public DBConnection() : base("Server=you_server;Database=your_database;Integrated Security=true;")
        {
            System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<DBConnection, DataContextConfiguration>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<States>().HasKey(m => new { m.ID });
            modelBuilder.Entity<Countries>().HasKey(m => new { m.ID });
            modelBuilder.Entity<Customers>().HasKey(m => new { m.ID });
            modelBuilder.Entity<Sizes>().HasKey(m => new {m.ID});
            modelBuilder.Entity<Products>().HasKey(m => new {m.ID});
            modelBuilder.Entity<PaymentMethods>().HasKey(m => new {m.ID });
            modelBuilder.Entity<ProductTypes>().HasKey(m => new {m.ID });
            modelBuilder.Entity<Jobs>().HasKey(m => new {m.ID });
            modelBuilder.Entity<Prices>().HasKey(m => new {m.ID });
            modelBuilder.Entity<Invoices>().HasKey(m => new {m.ID });
            modelBuilder.Entity<MobileVerifications>().HasKey(m => new {m.ID });
            modelBuilder.Entity<EmailVerifications>().HasKey(m => new {m.ID });
            modelBuilder.Entity<Logins>().HasKey(m => new {m.ID });
            modelBuilder.Entity<Commands>().HasKey(m => new {m.ID });
            modelBuilder.Entity<DailyCount>().HasKey(m => new {m.ID });
            modelBuilder.Entity<MacAddresses>().HasKey(m => new {m.ID });
        }
    }
    internal sealed class DataContextConfiguration : DbMigrationsConfiguration<DBConnection>
    {
        public DataContextConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "DataContext";
        }
    }
}