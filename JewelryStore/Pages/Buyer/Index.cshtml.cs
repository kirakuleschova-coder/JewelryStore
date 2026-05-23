using JewelryStore.Data;
using JewelryStore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JewelryStore.Pages.Buyer
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<JewelryStore.Model.Buyer> Buyers { get; set; }

        public void OnGet()
        {
            Buyers = _context.Buyers.ToList();
        }
    }
}