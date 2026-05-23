using JewelryStore.Data;
using JewelryStore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JewelryStore.Pages.Buyer
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public JewelryStore.Model.Buyer Buyer { get; set; }
        public void OnGet() { }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Buyers.Add(Buyer);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }

    }
}
