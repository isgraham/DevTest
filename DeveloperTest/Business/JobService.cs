using System.Linq;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.Database;
using DeveloperTest.Database.Models;
using DeveloperTest.Models;
using Microsoft.EntityFrameworkCore;

namespace DeveloperTest.Business
{
    public class JobService : IJobService
    {
        private readonly ApplicationDbContext context;

        public JobService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public JobModel[] GetJobs()
        {
            return
                (from job in context.Jobs
                 join customer in context.Customers on job.CustomerId equals customer.CustomerId into customers
                 from nullCustomer in customers.DefaultIfEmpty()
                 select new JobModel
                 {
                     JobId = job.JobId,
                     Engineer = job.Engineer,
                     When = job.When,
                     Customer = nullCustomer != null ?
                     new CustomerModel
                     {
                         CustomerId = nullCustomer.CustomerId,
                         Name = nullCustomer.Name,
                         Type = nullCustomer.Type,
                     } : null
                 }).ToArray();
        }

        public JobModel GetJob(int jobId)
        {
            return
                (from job in context.Jobs
                 .Where(x => x.JobId == jobId)
                 join customer in context.Customers on job.CustomerId equals customer.CustomerId into customers
                 from nullCustomer in customers.DefaultIfEmpty()
                 select new JobModel
                 {
                     JobId = job.JobId,
                     Engineer = job.Engineer,
                     When = job.When,
                     Customer = nullCustomer != null ?
                     new CustomerModel
                     {
                         CustomerId = nullCustomer.CustomerId,
                         Name = nullCustomer.Name,
                         Type = nullCustomer.Type,
                     } : null
                 }).SingleOrDefault();
        }

        public JobModel CreateJob(BaseJobModel model)
        {
            var addedJob = context.Jobs.Add(new Job
            {
                Engineer = model.Engineer,
                When = model.When,
                CustomerId = model.Customer.CustomerId
            });

            context.SaveChanges();

            return new JobModel
            {
                JobId = addedJob.Entity.JobId,
                Engineer = addedJob.Entity.Engineer,
                When = addedJob.Entity.When,
                Customer = new CustomerModel
                {
                    CustomerId = model.Customer.CustomerId,
                    Name = model.Customer.Name,
                    Type = model.Customer.Type,
                }
            };
        }
    }
}