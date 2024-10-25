using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ticari.Entities.Entities.Concrete;






namespace Ticari.Entities.DBContexts
{
    public class SQLDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-2KPKJ12;Database=TicariPaket;Trusted_Connection=true;TrustServerCertificate=true");

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Gsm116> Gsm116s { get; set; }
        public DbSet<MyUser> Users { get; set; }
        public DbSet<Role> Roller { get; set; }
        public DbSet<Menu> Menuler { get; set; }

        public SQLDbContext()
        {
            
        }

        public SQLDbContext(DbContextOptions<SQLDbContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
    
}
