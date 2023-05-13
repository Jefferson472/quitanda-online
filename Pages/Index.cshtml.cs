using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using quitanda_online.Data;
using quitanda_online.Models;

namespace quitanda_online.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly quitanda_online.Data.ApplicationDBContext _context;

        public IList<Product> Products { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ApplicationDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task OnGetAsync()
        {
            if (_context.Product != null)
            {
                Products = await _context.Product.ToListAsync();
            }
        }
    }
}