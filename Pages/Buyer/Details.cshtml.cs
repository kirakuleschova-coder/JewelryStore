using JewelryStore.Data;
using JewelryStore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JewelryStore.Pages.Buyer
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public JewelryStore.Model.Buyer Buyer { get; set; }

        public IActionResult OnGet(int id)
        {
            Buyer = _context.Buyers.FirstOrDefault(s => s.Id == id);

            if (Buyer == null)
                return NotFound();

            return Page();
        }
    }
}