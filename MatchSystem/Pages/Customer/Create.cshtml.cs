using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MatchSystem.BizLayer;
using MatchSystem.Data;

namespace MatchSystem.Pages.Customer
{
    public class CreateModel : PageModel
    {
        private readonly MatchSystem.Data.ApplicationDbContext _context;

        public CreateModel(MatchSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["SeatID"] = new SelectList(_context.Seats, "ID", "SeatNumber");
        ViewData["TicketID"] = new SelectList(_context.Tickets, "ID", "Number");
            return Page();
        }

        [BindProperty]
        public MatchSystem.BizLayer.Customer Customer { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Customers.Add(Customer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}