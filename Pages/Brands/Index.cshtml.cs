using ConstellationGarage.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConstellationGarage.Pages.Brands
{
    public class IndexModel : PageModel
    {
        private readonly GarageautomobileContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(GarageautomobileContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public IList<Brand> Brand { get; set; } = default!;
        public PaginatedList<Brand> Brands { get; set; }

        public async Task OnGetAsync(int? pageIndex)
        {
            if (_context.Brands != null)
            {
                IQueryable<Brand> brandsIQ = from s in _context.Brands
                                             select s;

                var pageSize = Configuration.GetValue("PageSize", 10);
                Brands = await PaginatedList<Brand>.CreateAsync(brandsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
            }
        }
    }
}
