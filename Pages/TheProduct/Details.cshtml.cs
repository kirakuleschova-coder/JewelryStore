using JewelryStore.Data;
using JewelryStore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JewelryStore.Pages.Decoration
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public JewelryStore.Model.TheProduct TheProduct { get; set; }

        public IActionResult OnGet(int id)
        {
            TheProduct = _context.TheProducts.FirstOrDefault(b => b.Id == id);

            if (TheProduct == null)
                return NotFound();

            return Page();
        }
    }
}
