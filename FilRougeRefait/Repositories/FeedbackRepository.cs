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
    public class FeedbackRepository : IRepository<Feedback>
    {
        private readonly ApplicationDbContext _db;

        public FeedbackRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Feedback>> GetAll()
        {
            return await _db.Feedbacks.ToListAsync();
        }

        public async Task<List<Feedback>> GetAll(Expression<Func<Feedback, bool>> predicate)
        {
            return await _db.Feedbacks.Where(predicate).ToListAsync();
        }

        public async Task<Feedback?> GetById(int id)
        {
            return await _db.Feedbacks.FindAsync(id);
        }

        public async Task<Feedback?> Get(Expression<Func<Feedback, bool>> predicate)
        {
            return await _db.Feedbacks.FirstOrDefaultAsync(predicate);
        }

        public async Task<Feedback?> Add(Feedback feedback)
        {
            var added = await _db.Feedbacks.AddAsync(feedback);
            await _db.SaveChangesAsync();
            return added.Entity;
        }

        public async Task<Feedback?> Update(Feedback feedback)
        {
            var feedbackDb = await GetById(feedback.ID);
            if (feedbackDb == null)
                return null;

            feedbackDb.ID_Driver = feedback.ID_Driver;
            feedbackDb.ID_Passenger = feedback.ID_Passenger;
            feedbackDb.Rating = feedback.Rating;
            feedbackDb.Comment = feedback.Comment;
            feedbackDb.DateHour = feedback.DateHour;
            feedbackDb.Author = feedback.Author;
            feedbackDb.Driver = feedback.Driver;

            await _db.SaveChangesAsync();
            return feedbackDb;
        }

        public async Task<bool> Delete(int id)
        {
            var feedback = await GetById(id);
            if (feedback == null)
                return false;

            _db.Feedbacks.Remove(feedback);
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
