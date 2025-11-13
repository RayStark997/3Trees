using ThreeTrees.Data.Map;
using ThreeTrees.Model;
using Microsoft.EntityFrameworkCore;

namespace ThreeTrees.Data
{
    public class ThreeTreesDBContext : DbContext
    {
        public ThreeTreesDBContext(DbContextOptions<ThreeTreesDBContext> options)
            : base(options)
        {
        }

        public DbSet<TrilhaModel> Trilhas {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TrilhaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
