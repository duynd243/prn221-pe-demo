using CandidateManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.DataAccess.Repositories
{
    public class JobPostingRepository : IRepository<JobPosting>
    {

        private readonly CandidateManagementContext _context;

        public JobPostingRepository(CandidateManagementContext context)
        {
            _context = context;
        }
        public void Add(JobPosting entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<JobPosting> GetAll()
        {
            return _context.JobPostings.ToList();
        }

        public JobPosting GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(JobPosting entity)
        {
            throw new NotImplementedException();
        }
    }
}
