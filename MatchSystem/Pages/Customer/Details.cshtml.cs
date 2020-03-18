using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MatchSystem.BizLayer;
using MatchSystem.Data;

namespace MatchSystem.Pages.Customer
{
    public class DetailsModel : PageModel
    {
        private readonly MatchSystem.Data.ApplicationDbContext _context;

        public DetailsModel(MatchSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public MatchSystem.BizLayer.Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customers
                .Include(c => c.Seat)
                .Include(c => c.Ticket).SingleOrDefaultAsync(m => m.ID == id);

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
