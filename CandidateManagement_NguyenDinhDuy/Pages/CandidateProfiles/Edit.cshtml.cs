using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CandidateManagement.DataAccess.Models;
using CandidateManagement.DataAccess.Repositories;

namespace CandidateManagement_NguyenDinhDuy.Pages.CandidateProfiles
{
    public class EditModel : PageModel
    {
        private readonly IRepository<CandidateProfile> _candidateRepository;
        private readonly IRepository<JobPosting> _postingRepository;

        public EditModel(IRepository<CandidateProfile> candidateRepository, IRepository<JobPosting> postingRepository)
        {
            _candidateRepository = candidateRepository;
            _postingRepository = postingRepository;
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; }

        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CandidateProfile = _candidateRepository.GetById(id);

            if (CandidateProfile == null)
            {
                return NotFound();
            }
            ViewData["PostingId"] = new SelectList(_postingRepository.GetAll().ToList(), "PostingId", "JobPostingTitle");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _candidateRepository.Update(CandidateProfile);
            return RedirectToPage("./Index");
        }
    }
}
