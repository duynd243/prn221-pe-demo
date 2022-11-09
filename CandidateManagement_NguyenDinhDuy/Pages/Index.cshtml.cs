using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidateManagement_NguyenDinhDuy.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            if(HttpContext.User.Identity != null && HttpContext.User.Identity.IsAuthenticated)
            {
                // đã login => candidate page
                return Redirect("/CandidateProfiles");
            }
            else
            {
                // chưa login => đến trang login
                return Redirect("/Account/Login");
            }
        }
    }
}
