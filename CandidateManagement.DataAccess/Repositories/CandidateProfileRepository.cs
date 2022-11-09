using CandidateManagement.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.DataAccess.Repositories
{
    public class CandidateProfileRepository : IRepository<CandidateProfile>
    {

        private readonly CandidateManagementContext _context;

        public CandidateProfileRepository(CandidateManagementContext context)
        {
            _context = context;
        }

        public void Add(CandidateProfile entity)
        {
            _context.CandidateProfiles.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var profile = _context.CandidateProfiles.Find(id);
            if (profile != null)
            {
                _context.CandidateProfiles.Remove(profile);
                _context.SaveChanges();
            }
        }

        public IEnumerable<CandidateProfile> GetAll()
        {
            return _context.CandidateProfiles
                .Include(c=>c.Posting)
                .ToList();
        }

        public CandidateProfile GetById(string id)
        {
            return _context.CandidateProfiles.Find(id);
        }

        public void Update(CandidateProfile entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
