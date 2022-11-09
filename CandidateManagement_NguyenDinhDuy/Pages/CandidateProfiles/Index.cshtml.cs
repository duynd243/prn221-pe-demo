using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CandidateManagement.DataAccess.Models;
using CandidateManagement.DataAccess.Repositories;

namespace CandidateManagement_NguyenDinhDuy.Pages.CandidateProfiles
{
    public class IndexModel : PageModel
    {
        private readonly IRepository<CandidateProfile> _repository;

        public IndexModel(IRepository<CandidateProfile> repository)
        {
            _repository = repository;
        }

        public IList<CandidateProfile> CandidateProfile { get;set; }

        public void OnGetAsync()
        {
            CandidateProfile = _repository.GetAll().ToList();
        }
    }
}
