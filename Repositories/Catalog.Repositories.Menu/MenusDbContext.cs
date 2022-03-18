using Catalog.Repositories.Menus.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Catalog.Repositories.Menus
{
    public class MenusDbContext : DbContext
    {
        public MenusDbContext(DbContextOptions options) : base(options)
        {
        }

        #region Entites

        public DbSet<MenuEntity> Menues { get; set; }

        #endregion Entites

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}