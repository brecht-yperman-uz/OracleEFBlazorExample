using Microsoft.EntityFrameworkCore;

namespace BlazorApp
{
    public class MyContext : DbContext
    {
        public MyContext()
        {
        }

        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("BYPERMAN");

            modelBuilder.Entity<VirtualNumber>().HasNoKey().ToView("VIRTUAL_NUMBERS").Property(v => v.RowNumber).HasColumnName("ROWNUMBER");
        }

        public DbSet<VirtualNumber> VirtualNumbers { get; set; } = null!;
    }
}
