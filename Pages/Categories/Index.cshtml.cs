using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ConstellationGarage.Models;

namespace ConstellationGarage.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ConstellationGarage.Models.GarageautomobileContext _context;

        public IndexModel(ConstellationGarage.Models.GarageautomobileContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Categories != null)
            {
                Category = await _context.Categories.ToListAsync();
            }
        }
    }
}
