using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using quitanda_online.Data;
using quitanda_online.Models;

namespace quitanda_online.Pages.ProductCRUD
{
    public class IndexModel : PageModel
    {
        private readonly quitanda_online.Data.ApplicationDBContext _context;

        public IndexModel(quitanda_online.Data.ApplicationDBContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Product != null)
            {
                Product = await _context.Product.ToListAsync();
            }
        }
        public async Task<IActionResult> OnPostDeleteAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Product.FindAsync(id);

            if (produto != null)
            {
                _context.Product.Remove(produto);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
