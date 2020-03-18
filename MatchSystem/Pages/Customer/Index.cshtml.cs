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
    public class IndexModel : PageModel
    {
        private readonly MatchSystem.Data.ApplicationDbContext _context;

        public IndexModel(MatchSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<MatchSystem.BizLayer.Customer> Customer { get;set; }

        public async Task OnGetAsync()
        {
            Customer = await _context.Customers
                .Include(c => c.Seat)
                .Include(c => c.Ticket).ToListAsync();
        }
    }
}
