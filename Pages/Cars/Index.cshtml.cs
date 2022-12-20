using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ConstellationGarage.Models;

namespace ConstellationGarage.Pages.Cars
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

        public IList<Car> Car { get;set; } = default!;

        public string? Sort { get; set; }
        public PaginatedList<Car> Cars { get; set; }
        public async Task OnGetAsync(string sortOrder, int? pageIndex)
        {
            if (_context.Cars != null)
            {
                Sort = string.IsNullOrEmpty(sortOrder) ? "" : sortOrder;

                IQueryable<Car> carsIQ = from s in _context.Cars
                select s;

                carsIQ = Sort switch
                {
                    "color" => carsIQ.OrderBy(s => s.Color),
                    "fuel" => carsIQ.OrderBy(s => s.Essence),
                    _ => carsIQ
                };

                var pageSize = Configuration.GetValue("PageSize", 10);
                Cars = await PaginatedList<Car>.CreateAsync(carsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
            }
        }
    }
}
