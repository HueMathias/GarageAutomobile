using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ConstellationGarage.Models;

namespace ConstellationGarage.Pages.Cars
{
    public class CreateModel : PageModel
    {
        private readonly ConstellationGarage.Models.GarageautomobileContext _context;

        public CreateModel(ConstellationGarage.Models.GarageautomobileContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CodeBrand"] = new SelectList(_context.Brands, "Code", "Code");
        ViewData["CodeCategorie"] = new SelectList(_context.Categories, "Code", "Code");
            return Page();
        }

        [BindProperty]
        public Car Car { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cars.Add(Car);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
