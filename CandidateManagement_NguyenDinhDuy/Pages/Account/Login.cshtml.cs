using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CandidateManagement.DataAccess.Models;
using CandidateManagement.DataAccess.Repositories;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace CandidateManagement_NguyenDinhDuy.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly IRepository<Hraccount> _hrAccountRepository;

        public LoginModel(IRepository<Hraccount> hrAccountRepository)
        {
            _hrAccountRepository = hrAccountRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Hraccount Hraccount { get; set; }

        public string ErrorMessage { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPost()
        {
            var account = ((HrAccountRepository)_hrAccountRepository).Login(Hraccount.Email, Hraccount.Password);

            if(account == null || account.MemberRole != 2)
            {
                ErrorMessage = "You are not allowed to do this function!";
                return Page();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, account.Email),
                new Claim(ClaimTypes.Role, "Manager")
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties { };

            // Issue cookie
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity),
                authProperties);

            return RedirectToPage("/CandidateProfiles/Index");
        }
    }
}
