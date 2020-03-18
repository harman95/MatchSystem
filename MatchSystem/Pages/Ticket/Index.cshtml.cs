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
    public class IndexModel : PageModel
    {
        private readonly MatchSystem.Data.ApplicationDbContext _context;

        public IndexModel(MatchSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<MatchSystem.BizLayer.Ticket> Ticket { get;set; }

        public async Task OnGetAsync()
        {
            Ticket = await _context.Tickets.ToListAsync();
        }
    }
}
