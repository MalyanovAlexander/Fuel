using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuel
{
    public class FuelDB : DbContext
    {
        public FuelDB(string ConnectionString) : base(ConnectionString) { }

        public FuelDB() : this("name=FuelDB") { }
        
        public DbSet<Trip> Trips { get; set; }
    }
}
