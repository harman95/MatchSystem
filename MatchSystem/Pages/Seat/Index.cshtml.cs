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
    public class IndexModel : PageModel
    {
        private readonly MatchSystem.Data.ApplicationDbContext _context;

        public IndexModel(MatchSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<MatchSystem.BizLayer.Seat> Seat { get;set; }

        public async Task OnGetAsync()
        {
            Seat = await _context.Seats.ToListAsync();
        }
    }
}
