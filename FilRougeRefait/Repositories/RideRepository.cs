using CoVoyageur.Core.Models;
using System.Linq.Expressions;
using CoVoyageur.API.Data;
using CoVoyageur.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CoVoyageur.API.Repositories
{
    public class RideRepository : IRepository<Ride>
    {
        private ApplicationDbContext _db { get; }
        public RideRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task<List<Ride>> GetAll()
        {
            return _db.Rides.ToListAsync(); //fait

        }

        public async Task<List<Ride>> GetAll(Expression<Func<Ride, bool>> predicate)
        {
            return await _db.Rides.Where(predicate).ToListAsync(); //fait
        }

        public async Task<Ride?> GetById(int id)
        {
            return await _db.Rides.FindAsync(id); //fait
        }

        public async Task<Ride?> Get(Expression<Func<Ride, bool>> predicate)
        {
            return await _db.Rides.FirstOrDefaultAsync(predicate); //fait
        }

        public async Task<Ride?> Add(Ride usr)
        {
            var added = await _db.Rides.AddAsync(usr); //fait
            await _db.SaveChangesAsync();
            return added.Entity;
        }

        public async Task<Ride?> Update(Ride ride)
        {
            var rideDb = await GetById(ride.ID);//fait
            if (rideDb == null)
                return null;

            if (rideDb.Reservations != ride.Reservations) rideDb.Reservations = ride.Reservations;
            if (rideDb.DateHour != ride.DateHour) rideDb.DateHour = ride.DateHour;
            if (rideDb.Departure != ride.Departure) rideDb.Departure = ride.Departure;
            if (rideDb.Arrival != ride.Arrival) rideDb.Arrival = ride.Arrival;
            if (rideDb.NbPlaces != ride.NbPlaces) rideDb.NbPlaces = ride.NbPlaces;

            if (await _db.SaveChangesAsync() == 0)
                return null;

            return rideDb;
        }

        public async Task<bool> Delete(int id)//fait
        {
            var ride = await GetById(id);
            if (ride == null)
                return false;
            _db.Rides.Remove(ride);
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
