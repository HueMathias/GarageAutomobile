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
        private readonly IConfiguration Configuration;

        public IndexModel(ConstellationGarage.Models.GarageautomobileContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public IList<Category> Category { get;set; } = default!;
        public PaginatedList<Category> Categories { get; set; }

        public async Task OnGetAsync(int? pageIndex)
        {
            if (_context.Categories != null)
            {
                IQueryable<Category> categoriesIQ = from s in _context.Categories
                                         select s;


                var pageSize = Configuration.GetValue("PageSize", 10);
                Categories = await PaginatedList<Category>.CreateAsync(categoriesIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
            }
        }
    }
}
