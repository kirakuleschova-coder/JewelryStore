using JewelryStore.Data;
using JewelryStore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JewelryStore.Pages.Decoration
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public JewelryStore.Model.TheProduct TheProduct { get; set; }

        public IActionResult OnGet(int id)
        {
            TheProduct = _context.TheProducts.Find(id);

            if (TheProduct == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.TheProducts.Update(TheProduct);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
   