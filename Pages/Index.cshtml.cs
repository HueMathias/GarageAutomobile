using ConstellationGarage.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ConstellationGarage.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly GarageautomobileContext _context;

        public IndexModel(ILogger<IndexModel> logger, GarageautomobileContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            int nbUsed = (from s in _context.Cars
                                  where s.New == false
                                  select s).Count();

            ViewData["nbUsed"] = nbUsed;
            if (nbUsed > 1)
                ViewData["nbUsed"] += " stock cars available";
            else
                ViewData["nbUsed"] += " car in stock available";


            int nbNew = (from s in _context.Cars
                          where s.New == true
                          select s).Count();
            ViewData["nbNew"] = nbNew;
            if (nbNew > 1)
                ViewData["nbNew"] += " stock cars available";
            else
                ViewData["nbNew"] += " car in stock available";
        }
    }
}