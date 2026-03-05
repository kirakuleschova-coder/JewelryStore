using JewelryStore.Data;
using JewelryStore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JewelryStore.Pages.Buyer
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public JewelryStore.Model.Buyer Student { get; set; }

        public IActionResult OnGet(int id)
        {
            Student = _context.Buyers.Find(id);

            if (Student == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Buyers.Update(Student);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
