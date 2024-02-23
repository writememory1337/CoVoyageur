using CoVoyageur.Core.Models;
using System.Linq.Expressions;
using CoVoyageur.API.Data;
using CoVoyageur.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CoVoyageur.API.Repositories
{
    public class ReservationRepository : IRepository<Reservation>
    {
        private ApplicationDbContext _db { get; }
        public ReservationRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task<List<Reservation>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Reservation>> GetAll(Expression<Func<Reservation, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Reservation?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Reservation?> Get(Expression<Func<Reservation, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Reservation?> Add(Reservation entity)
        {
            throw new NotImplementedException();
        }

        public Task<Reservation?> Update(Reservation entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
