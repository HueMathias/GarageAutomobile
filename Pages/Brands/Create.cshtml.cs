using ConstellationGarage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ConstellationGarage.Pages.Brands
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
            return Page();
        }

        [BindProperty]
        public Brand Brand { get; set; }
        [BindProperty]
        public IFormFile Icon { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            using (var target = new MemoryStream())
            {
                Icon.CopyTo(target);
                Brand.Icon = target.ToArray();
            }

            _context.Brands.Add(Brand);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
