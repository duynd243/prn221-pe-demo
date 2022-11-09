using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CandidateManagement.DataAccess.Models;
using CandidateManagement.DataAccess.Repositories;

namespace CandidateManagement_NguyenDinhDuy.Pages.CandidateProfiles
{
    public class CreateModel : PageModel
    {
        private readonly IRepository<CandidateProfile> _candidateRepository;
        private readonly IRepository<JobPosting> _postingRepository;

        public CreateModel(IRepository<CandidateProfile> candidateRepository, IRepository<JobPosting> postingRepository)
        {
            _candidateRepository = candidateRepository;
            _postingRepository = postingRepository;
        }

        public IActionResult OnGet()
        {
        ViewData["PostingId"] = new SelectList(_postingRepository.GetAll().ToList(), "PostingId", "JobPostingTitle");
            return Page();
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; }

        public string ErrorMessage { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            ViewData["PostingId"] = new SelectList(_postingRepository.GetAll().ToList(), "PostingId", "JobPostingTitle");
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var profile = _candidateRepository.GetById(CandidateProfile.CandidateId);

            if(profile != null)
            {
                // đã tồn tại
                ErrorMessage = "Candidate ID already exists";
                return Page();
            }
            _candidateRepository.Add(CandidateProfile);

            return RedirectToPage("./Index");
        }
    }
}
