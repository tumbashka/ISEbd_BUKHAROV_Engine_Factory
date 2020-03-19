using EngineFactoryDatabaseImplements.Models;
using Microsoft.EntityFrameworkCore;

namespace EngineFactoryDatabaseImplements
{
    public class EngineFactoryDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-98L3NOK\SQLEXPRESS;Initial Catalog=EngineFactoryDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Detail> Details { set; get; }
        public virtual DbSet<Engine> Engines { set; get; }
        public virtual DbSet<EngineDetail> EngineDetails { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
    }
}