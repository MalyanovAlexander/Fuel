using Fuel.Migrations;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuel
{
    /// <summary>
    /// Класс контекста БД
    /// </summary>
    public class FuelDB : DbContext
    {
        public FuelDB(string ConnectionString) : base(ConnectionString) { }

        public FuelDB() : this("name=FuelDB") { }

        static FuelDB()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FuelDB, Configuration>());
        }

        public DbSet<Trip> Trips { get; set; }
    }
}
