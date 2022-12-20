using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ConstellationGarage.Models;

namespace ConstellationGarage.Pages.Brands
{
    public class DetailsModel : PageModel
    {
        private readonly ConstellationGarage.Models.GarageautomobileContext _context;

        public DetailsModel(ConstellationGarage.Models.GarageautomobileContext context)
        {
            _context = context;
        }

      public Brand Brand { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Brands == null)
            {
                return NotFound();
            }

            var brand = await _context.Brands.FirstOrDefaultAsync(m => m.Code == id);
            if (brand == null)
            {
                return NotFound();
            }
            else 
            {
                Brand = brand;
            }
            return Page();
        }
    }
}
