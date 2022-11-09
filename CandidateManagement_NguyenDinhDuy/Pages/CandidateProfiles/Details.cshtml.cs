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
    public class DetailsModel : PageModel
    {
        private readonly IRepository<CandidateProfile> _repository;

        public DetailsModel(IRepository<CandidateProfile> repository)
        {
            _repository = repository;
        }

        public CandidateProfile CandidateProfile { get; set; }

        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CandidateProfile = _repository.GetById(id);

            if (CandidateProfile == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
