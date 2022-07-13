using JobOffersProject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobOffersProject.DbContexts
{
    public class JobOfferContext : DbContext
    {
        public JobOfferContext(DbContextOptions<JobOfferContext> options) : base(options)
        {
        }

        public DbSet<JobOffer> JobOffers { get; set; }
    }
}