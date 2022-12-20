using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ConstellationGarage.Models;

namespace ConstellationGarage.Pages.Brands
{
    public class EditModel : PageModel
    {
        private readonly GarageautomobileContext _context;

        public EditModel(GarageautomobileContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Brand Brand { get; set; } = default!;
        [BindProperty]
        public IFormFile Icon { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Brands == null)
            {
                return NotFound();
            }

            var brand =  await _context.Brands.FirstOrDefaultAsync(m => m.Code == id);
            if (brand == null)
            {
                return NotFound();
            }
            Brand = brand;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
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

            _context.Attach(Brand).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandExists(Brand.Code))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BrandExists(string id)
        {
          return _context.Brands.Any(e => e.Code == id);
        }
    }
}
