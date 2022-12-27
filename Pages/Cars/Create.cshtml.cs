using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ConstellationGarage.Models;

namespace ConstellationGarage.Pages.Cars
{
    public class CreateModel : PageModel
    {
        private readonly GarageautomobileContext _context;

        public CreateModel(GarageautomobileContext context)
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
