using JobOffersProject.DbContexts;
using JobOffersProject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobOffersProject.Repository
{
    public class JobOfferRepository : IJobOfferRepository
    {
        private readonly JobOfferContext _dbContext;

        public JobOfferRepository(JobOfferContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteJobOffer(int jobOfferId)
        {
            var jobOffer = _dbContext.JobOffers.Find(jobOfferId);
            _dbContext.JobOffers.Remove(jobOffer);
            Save();
        }

        public IEnumerable<JobOffer> GetJobOffers()
        {
            return _dbContext.JobOffers.ToList();
        }

        public JobOffer GetOfferByID(int jobOfferId)
        {
            return _dbContext.JobOffers.Find(jobOfferId);
        }

        public void InsertJobOffer(JobOffer jobOffer)
        {
            _dbContext.Add(jobOffer);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateJobOffer(JobOffer jobOffer)
        {
            _dbContext.Entry(jobOffer).State = EntityState.Modified;
            Save();
        }
    }
}