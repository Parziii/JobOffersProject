using JobOffersProject.Model;
using JobOffersProject.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobOffersProject.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class JobOfferController : ControllerBase
    {
        private readonly IJobOfferRepository _jobOfferRepository;

        public JobOfferController(IJobOfferRepository jobOfferRepository)
        {
            _jobOfferRepository = jobOfferRepository;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var jobOffers = _jobOfferRepository.GetJobOffers()
            .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
            .Take(validFilter.PageSize)
            .ToList();
            var totalRecords = _jobOfferRepository.GetJobOffers().Count();
            return Ok(new PagedResponse<List<JobOffer>>(jobOffers, validFilter.PageNumber, validFilter.PageSize, totalRecords / validFilter.PageSize, totalRecords));
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var product = _jobOfferRepository.GetOfferByID(id);
            return new OkObjectResult(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody] JobOffer jobOffer)
        {
            using (var scope = new TransactionScope())
            {
                _jobOfferRepository.InsertJobOffer(jobOffer);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = jobOffer.Id }, jobOffer);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] JobOffer jobOffer)
        {
            if (jobOffer != null)
            {
                using (var scope = new TransactionScope())
                {
                    _jobOfferRepository.UpdateJobOffer(jobOffer);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _jobOfferRepository.DeleteJobOffer(id);
            return new OkResult();
        }
    }
}