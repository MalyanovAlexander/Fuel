using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuel.Services
{
    public class TripsDataProvider
    {
        private readonly FuelDB _db;

        public TripsDataProvider(FuelDB db) { _db = db; }

        public IEnumerable<Trip> GetTrips() => _db.Trips.ToArray();
    }
}
