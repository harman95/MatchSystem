using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MatchSystem.BizLayer;
using MatchSystem.Data;

namespace MatchSystem.Pages.Ticket
{
    public class DetailsModel : PageModel
    {
        private readonly MatchSystem.Data.ApplicationDbContext _context;

        public DetailsModel(MatchSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public MatchSystem.BizLayer.Ticket Ticket { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ticket = await _context.Tickets.SingleOrDefaultAsync(m => m.ID == id);

            if (Ticket == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
