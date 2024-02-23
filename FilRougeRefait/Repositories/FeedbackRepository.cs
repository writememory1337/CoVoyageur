using CoVoyageur.Core.Models;
using System.Linq.Expressions;
using CoVoyageur.API.Data;
using CoVoyageur.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CoVoyageur.API.Repositories
{
    public class FeedbackRepository : IRepository<Feedback>
    {
        private ApplicationDbContext _db { get; }
        public FeedbackRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task<List<Feedback>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Feedback>> GetAll(Expression<Func<Feedback, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Feedback?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Feedback?> Get(Expression<Func<Feedback, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Feedback?> Add(Feedback entity)
        {
            throw new NotImplementedException();
        }

        public Task<Feedback?> Update(Feedback entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
