using ConstellationGarage.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConstellationGarage.ViewComponents
{
    public class UpMenuViewComponent : ViewComponent
    {
        private readonly GarageautomobileContext _context;
        public UpMenuViewComponent(GarageautomobileContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var tables = _context.Model.GetEntityTypes()
                .OrderBy(t => t.Name)
                .ToList();
            return await Task.FromResult(View(tables));
        }
    }
}
