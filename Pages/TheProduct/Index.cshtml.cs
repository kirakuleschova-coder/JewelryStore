using JewelryStore.Data;
using JewelryStore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JewelryStore.Pages.Decoration
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<JewelryStore.Model.TheProduct> TheProducts { get; set; }

        public void OnGet()
        {
            TheProducts = _context.TheProducts.ToList();
        }
    }
}
