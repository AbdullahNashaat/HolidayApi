using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;


namespace HolidayApi.Model
{
    public class HolidayContext : DbContext
    {

        public HolidayContext(DbContextOptions<HolidayContext> options)
           : base(options)
        {
            // Creates the database if not exists
            Database.EnsureCreated();

        }
        public DbSet<Holiday> Holiday { get; set; }

        public DbSet<Country> Country { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=Holiday;user=root;password=root");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}

