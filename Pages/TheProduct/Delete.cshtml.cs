using JewelryStore.Data;
using JewelryStore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JewelryStore.Pages.Decoration
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
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
            var book = _context.TheProducts.Find(TheProduct.Id);

            if (book != null)
            {
                _context.TheProducts.Remove(book);
                _context.SaveChanges();
            }

            return RedirectToPage("Index");
        }
    }
}
