using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetIncident.Core.Model;

namespace ProjetIncident.Core.DataAccess
{
    public class IncidentsDBContext : DbContext
    {

        #region Singleton

        private static IncidentsDBContext _context = null;
        public async static Task<IncidentsDBContext> GetCurrent() {

            if(_context == null){
                _context = new IncidentsDBContext(
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "incidents.db")
                );
                await _context.Database.MigrateAsync();
            }
            return _context;
        }

        #endregion

        public string DatabasePath { get; }
        public DbSet<User> Users { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Photo> Photos { get; set; }

        public IncidentsDBContext(string databasePath)
        {
            DatabasePath = databasePath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"Filename={DatabasePath}");
        }
    }
}
