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
        public async Task OnGetAsync(string sortOrder, int? pageIndex, string? sortDefault)
        {
            IQueryable<Car> carsIQ = from s in _context.Cars select s;
            Sort = string.IsNullOrEmpty(sortOrder) ? "" : sortOrder;

            if (_context.Cars != null)
            {
                if (sortDefault != null)
                {
                    switch (sortDefault) {
                        case "used":
                            carsIQ = from s in _context.Cars
                                     where s.New == false
                                     select s;
                            break;
                        case "new":
                            carsIQ = from s in _context.Cars
                                     where s.New == true
                                     select s;
                            break;
                        default:
                            sortDefault = sortDefault.ToLower();
                            carsIQ = from s in _context.Cars select s;
                            carsIQ = carsIQ.Where(x => 
                                x.CodeCategorie.ToLower().Contains(sortDefault) ||
                                x.CodeBrand.ToLower().Contains(sortDefault) ||
                                x.Color.ToLower().Contains(sortDefault)
                            );
                            break;
                    }                                             
                }
                else
                {
                    carsIQ = Sort switch
                    {
                        "color" => carsIQ.OrderBy(s => s.Color),
                        "fuel" => carsIQ.OrderBy(s => s.Essence),
                        _ => carsIQ
                    };
                }

                var pageSize = Configuration.GetValue("PageSize", 10);
                Cars = await PaginatedList<Car>.CreateAsync(carsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
            }
        }
    }
}
