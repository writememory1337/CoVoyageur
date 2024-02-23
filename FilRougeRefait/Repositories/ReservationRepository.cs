using CoVoyageur.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CoVoyageur.API.Data;
using Microsoft.EntityFrameworkCore;

namespace CoVoyageur.API.Repositories
{
    public class ReservationRepository : IRepository<Reservation>
    {
        private readonly ApplicationDbContext _db;

        public ReservationRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Reservation>> GetAll()
        {
            return await _db.Reservations.ToListAsync();
        }

        public async Task<List<Reservation>> GetAll(Expression<Func<Reservation, bool>> predicate)
        {
            return await _db.Reservations.Where(predicate).ToListAsync();
        }

        public async Task<Reservation?> GetById(int id)
        {
            return await _db.Reservations.FindAsync(id);
        }

        public async Task<Reservation?> Get(Expression<Func<Reservation, bool>> predicate)
        {
            return await _db.Reservations.FirstOrDefaultAsync(predicate);
        }

        public async Task<Reservation?> Add(Reservation reservation)
        {
            var added = await _db.Reservations.AddAsync(reservation);
            await _db.SaveChangesAsync();
            return added.Entity;
        }

        public async Task<Reservation?> Update(Reservation reservation)
        {
            var reservationDb = await GetById(reservation.ID);
            if (reservationDb == null)
                return null;

            reservationDb.ID_Ride = reservation.ID_Ride;
            reservationDb.ID_Passenger = reservation.ID_Passenger;
            reservationDb.Statuts = reservation.Statuts;
            reservationDb.Travel = reservation.Travel;
            reservationDb.Passenger = reservation.Passenger;

            await _db.SaveChangesAsync();
            return reservationDb;
        }

        public async Task<bool> Delete(int id)
        {
            var reservation = await GetById(id);
            if (reservation == null)
                return false;

            _db.Reservations.Remove(reservation);
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
