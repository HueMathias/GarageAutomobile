using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ConstellationGarage.Models;

namespace ConstellationGarage.Pages.Brands
{
    public class IndexModel : PageModel
    {
        private readonly GarageautomobileContext _context;

        public IndexModel(GarageautomobileContext context)
        {
            _context = context;
        }

        public IList<Brand> Brand { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Brands != null)
            {
                Brand = await _context.Brands.ToListAsync();
            }
        }
    }
}
