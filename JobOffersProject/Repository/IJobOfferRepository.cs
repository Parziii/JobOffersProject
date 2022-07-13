using JobOffersProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobOffersProject.Repository
{
    public interface IJobOfferRepository
    {
        IEnumerable<JobOffer> GetJobOffers();

        JobOffer GetOfferByID(int jobOfferId);

        void InsertJobOffer(JobOffer jobOffer);

        void DeleteJobOffer(int jobOfferId);

        void UpdateJobOffer(JobOffer jobOffer);

        void Save();
    }
}