using ConstellationGarage.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConstellationGarage.ViewComponents
{
    public class CarViewComponent : ViewComponent
    {
        private readonly GarageautomobileContext _context;
        public CarViewComponent(GarageautomobileContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            return await Task.FromResult(View(_context.Cars.ToList()));
        }
    }
}
