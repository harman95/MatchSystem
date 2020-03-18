using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MatchSystem.BizLayer;
using MatchSystem.Data;

namespace MatchSystem.Pages.Seat
{
    public class DetailsModel : PageModel
    {
        private readonly MatchSystem.Data.ApplicationDbContext _context;

        public DetailsModel(MatchSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public MatchSystem.BizLayer.Seat Seat { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Seat = await _context.Seats.SingleOrDefaultAsync(m => m.ID == id);

            if (Seat == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
