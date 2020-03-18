using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MatchSystem.BizLayer;
using MatchSystem.Data;

namespace MatchSystem.Pages.Customer
{
    public class EditModel : PageModel
    {
        private readonly MatchSystem.Data.ApplicationDbContext _context;

        public EditModel(MatchSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["SeatID"] = new SelectList(_context.Seats, "ID", "SeatNumber");
           ViewData["TicketID"] = new SelectList(_context.Tickets, "ID", "Number");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(Customer.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.ID == id);
        }
    }
}
