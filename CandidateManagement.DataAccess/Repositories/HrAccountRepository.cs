using CandidateManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.DataAccess.Repositories
{
    public class HrAccountRepository : IRepository<Hraccount>
    {
        private readonly CandidateManagementContext _context;

        public HrAccountRepository(CandidateManagementContext context)
        {
            _context = context;
        }


        public void Add(Hraccount entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Hraccount> GetAll()
        {
            throw new NotImplementedException();
        }

        public Hraccount GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Hraccount Login(string email, string password)
        {
            return _context.Hraccounts.FirstOrDefault
                (account => account.Email.Equals(email) && account.Password == password);
        }

        public void Update(Hraccount entity)
        {
            throw new NotImplementedException();
        }
    }
}
